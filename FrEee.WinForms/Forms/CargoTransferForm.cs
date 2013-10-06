﻿using FrEee.Game.Interfaces;
using FrEee.Game.Objects.Civilization;
using FrEee.Game.Objects.Orders;
using FrEee.Game.Objects.Space;
using FrEee.Utility;
using FrEee.Utility.Extensions;
using FrEee.WinForms.Controls;
using FrEee.WinForms.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace FrEee.WinForms.Forms
{
    public partial class CargoTransferForm : Form
    {
        public CargoTransferForm(ICargoTransferrer fromContainer, Sector targetSector)
        {
            InitializeComponent();

			clFrom.CargoContainer = fromContainer;
			txtFromContainer.Text = fromContainer.Name;
			ddlToContainer.Items.Add(targetSector);
			foreach (var cc in targetSector.SpaceObjects.OfType<ICargoTransferrer>().Where(cc => cc != fromContainer && cc.Owner == Empire.Current).OrderBy(cc => cc.Name))
				ddlToContainer.Items.Add(cc);
			ddlToContainer.SelectedIndex = 0;
			clLoad.CargoDelta = new CargoDelta();
			clDrop.CargoDelta = new CargoDelta();
        }

		private void ddlToContainer_SelectedIndexChanged(object sender, EventArgs e)
		{
			clTo.CargoContainer = (ICargoContainer)ddlToContainer.SelectedItem;
		}

		private bool changedLoad = false;
		private bool changedDrop = false;
		private bool abort = false;

		private void btnOK_Click(object sender, EventArgs e)
		{
			Save();
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			abort = true;
			Close();
		}

		private void Save()
		{
			if (changedLoad)
			{
				if (clTo.CargoContainer is ICargoTransferrer)
				{
					// loading from a ship, planet, etc.
					var order = new TransferCargoOrder(true, clLoad.CargoDelta, (ICargoTransferrer)clTo.CargoContainer);
					((ICargoTransferrer)clFrom.CargoContainer).IssueOrder(order);
				}
				else if (clTo.CargoContainer is Sector)
				{
					// recovering from space
					// NOTE - if movement orders prior to this order are changed, the sector being recovered from will change!
					var order = new TransferCargoOrder(true, clLoad.CargoDelta, null);
					((ICargoTransferrer)clFrom.CargoContainer).IssueOrder(order);
				}
				changedLoad = false;
			}
			if (changedDrop)
			{
				if (clTo.CargoContainer is ICargoTransferrer)
				{
					// dropping to a ship, planet, etc.
					var order = new TransferCargoOrder(false, clDrop.CargoDelta, (ICargoTransferrer)clTo.CargoContainer);
					((ICargoTransferrer)clFrom.CargoContainer).IssueOrder(order);
				}
				else if (clTo.CargoContainer is Sector)
				{
					// launching to space
					// NOTE - if movement orders prior to this order are changed, the sector being launched to will change!
					var order = new TransferCargoOrder(false, clDrop.CargoDelta, null);
					((ICargoTransferrer)clFrom.CargoContainer).IssueOrder(order);
				}
				changedDrop = false;
			}
		}

		private void CargoTransferForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if ((changedLoad || changedDrop) && !abort)
			{
				var result = MessageBox.Show("Save your changes?", "FrEee", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
				if (result == DialogResult.Yes)
					Save();
				else if (result == DialogResult.Cancel)
					e.Cancel = true;
				// else if (result == DialogResult.No) do nothing and let the window close
			}
		}

		private void btnDrop_Click(object sender, EventArgs e)
		{
			var cl = lastFocusedCargoList;
			if (cl != null)
			{
				if (cl == clFrom)
					AddToDropList();
				else if (cl == clLoad)
					RemoveFromLoadList();
			}
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			var cl = lastFocusedCargoList;
			if (cl != null)
			{
				if (cl == clTo)
					AddToLoadList();
				else if (cl == clDrop)
					RemoveFromDropList();
			}
		}

		private void cargoList_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (sender == clFrom)
				AddToDropList();
			else if (sender == clTo)
				AddToLoadList();
			else if (sender == clLoad)
				RemoveFromLoadList();
			else if (sender == clDrop)
				RemoveFromDropList();
		}

		private void AddToLoadList()
		{
			if (!IsQuantityValid)
			{
				MessageBox.Show(InvalidQuantityMessage);
				return;
			}
			switch (clTo.CurrentSelectionType)
			{
				case CargoList.SelectionType.Population:
					if (clTo.SelectedRace == null)
						clLoad.CargoDelta.AnyPopulation = Quantity;
					else
						clLoad.CargoDelta.RacePopulation[clTo.SelectedRace] = Quantity;
					break;
				case CargoList.SelectionType.Unit:
					clLoad.CargoDelta.Units.Add(clTo.SelectedUnit);
					break;
				case CargoList.SelectionType.UnitDesign:
					clLoad.CargoDelta.UnitDesignTonnage.Add(clTo.SelectedUnitDesign, Quantity.ToNullableInt());
					break;
				case CargoList.SelectionType.UnitRole:
					clLoad.CargoDelta.UnitRoleTonnage.Add(clTo.SelectedUnitRole, Quantity.ToNullableInt());
					break;
				case CargoList.SelectionType.UnitType:
					clLoad.CargoDelta.UnitTypeTonnage.Add(clTo.SelectedUnitType, Quantity.ToNullableInt());
					break;
			}
			if (clTo.CurrentSelectionType != CargoList.SelectionType.None)
			{
				clLoad.Bind();
				ddlToContainer.Enabled = false; // lock it until this order is done
				changedLoad = true;
			}
		}

		private void AddToDropList()
		{
			if (!IsQuantityValid)
			{
				MessageBox.Show(InvalidQuantityMessage);
				return;
			}
			switch (clFrom.CurrentSelectionType)
			{
				// TODO - let user specify quantity
				case CargoList.SelectionType.Population:
					if (clFrom.SelectedRace == null)
						clDrop.CargoDelta.AnyPopulation = Quantity;
					else
						clDrop.CargoDelta.RacePopulation[clFrom.SelectedRace] = Quantity;
					break;
				case CargoList.SelectionType.Unit:
					clDrop.CargoDelta.Units.Add(clFrom.SelectedUnit);
					break;
				case CargoList.SelectionType.UnitDesign:
					clDrop.CargoDelta.UnitDesignTonnage.Add(clFrom.SelectedUnitDesign, Quantity.ToNullableInt());
					break;
				case CargoList.SelectionType.UnitRole:
					clDrop.CargoDelta.UnitRoleTonnage.Add(clFrom.SelectedUnitRole, Quantity.ToNullableInt());
					break;
				case CargoList.SelectionType.UnitType:
					clDrop.CargoDelta.UnitTypeTonnage.Add(clFrom.SelectedUnitType, Quantity.ToNullableInt());
					break;
			}
			if (clFrom.CurrentSelectionType != CargoList.SelectionType.None)
			{
				clDrop.Bind();
				ddlToContainer.Enabled = false; // lock it until this order is done
				changedDrop = true;
			}
		}

		private void RemoveFromLoadList()
		{
			switch (clLoad.CurrentSelectionType)
			{
				case CargoList.SelectionType.Population:
					if (clLoad.SelectedRace == null)
						clLoad.CargoDelta.AnyPopulation = 0;
					else
						clLoad.CargoDelta.RacePopulation.Remove(clLoad.SelectedRace);
					break;
				case CargoList.SelectionType.Unit:
					clLoad.CargoDelta.Units.Remove(clLoad.SelectedUnit);
					break;
				case CargoList.SelectionType.UnitDesign:
					clLoad.CargoDelta.UnitDesignTonnage.Remove(clLoad.SelectedUnitDesign);
					break;
				case CargoList.SelectionType.UnitRole:
					clLoad.CargoDelta.UnitRoleTonnage.Remove(clLoad.SelectedUnitRole);
					break;
				case CargoList.SelectionType.UnitType:
					clLoad.CargoDelta.UnitTypeTonnage.Remove(clLoad.SelectedUnitType);
					break;
			}
			if (clLoad.CurrentSelectionType != CargoList.SelectionType.None)
				clLoad.Bind();
			// TODO - unlock if everything removed from both transfer lists
		}

		private void RemoveFromDropList()
		{
			switch (clDrop.CurrentSelectionType)
			{
				case CargoList.SelectionType.Population:
					if (clDrop.SelectedRace == null)
						clDrop.CargoDelta.AnyPopulation = 0;
					else
						clDrop.CargoDelta.RacePopulation.Remove(clDrop.SelectedRace);
					break;
				case CargoList.SelectionType.Unit:
					clDrop.CargoDelta.Units.Remove(clDrop.SelectedUnit);
					break;
				case CargoList.SelectionType.UnitDesign:
					clDrop.CargoDelta.UnitDesignTonnage.Remove(clDrop.SelectedUnitDesign);
					break;
				case CargoList.SelectionType.UnitRole:
					clDrop.CargoDelta.UnitRoleTonnage.Remove(clDrop.SelectedUnitRole);
					break;
				case CargoList.SelectionType.UnitType:
					clDrop.CargoDelta.UnitTypeTonnage.Remove(clDrop.SelectedUnitType);
					break;
			}
			if (clDrop.CurrentSelectionType != CargoList.SelectionType.None)
				clDrop.Bind();
			// TODO - unlock if everything removed from both transfer lists
		}

		private CargoList lastFocusedCargoList;

		private void cl_Enter(object sender, EventArgs e)
		{
			lastFocusedCargoList = (CargoList)sender;
			if (lastFocusedCargoList.CurrentSelectionType == CargoList.SelectionType.None)
				lblQuantityUnit.Text = "";
			else if (lastFocusedCargoList.CurrentSelectionType == CargoList.SelectionType.Population)
				lblQuantityUnit.Text = "people";
			else
				lblQuantityUnit.Text = "kT";
		}

		private void chkQuantity_CheckedChanged(object sender, EventArgs e)
		{
			txtQuantity.Enabled = !chkAll.Checked;
		}

		private bool IsQuantityValid
		{
			get
			{
				return chkAll.Checked || Quantity != null;
			}
		}

		private long? Quantity
		{
			get
			{
				if (!chkAll.Checked)
					return (long)Parser.Units(txtQuantity.Text);
				return null;
			}
		}

		private static readonly string InvalidQuantityMessage = "Invalid quantity specified. Please specify a numeric quantity, or uncheck the Quantity check box to load/drop all units/population. You may optionally use metric suffixes in the quantity.";
    }
}
