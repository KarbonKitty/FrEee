using System.Linq;
using System.Windows.Forms;
using FrEee.Game.Interfaces;
using FrEee.Game.Objects.Vehicles;
using FrEee.Game.Objects.Orders;
using FrEee.Utility.Extensions;
using FrEee.WinForms.Utility.Extensions;
using System.Drawing;
using FrEee.Game.Objects.Civilization;
using FrEee.Game.Objects.Commands;
using FrEee.Utility;

namespace FrEee.WinForms.Controls
{
	/// <summary>
	/// A report on a ship or base.
	/// </summary>
	public partial class AutonomousSpaceVehicleReport : UserControl
	{
		public AutonomousSpaceVehicleReport()
		{
			InitializeComponent();
		}

		public AutonomousSpaceVehicleReport(AutonomousSpaceVehicle vehicle)
		{
			InitializeComponent();
			Vehicle = vehicle;
		}

		private AutonomousSpaceVehicle vehicle;
		public AutonomousSpaceVehicle Vehicle { get { return vehicle; } set { vehicle = value; Invalidate(); } }

		private void AutonomousSpaceVehicleReport_Paint(object sender, PaintEventArgs e)
		{
			if (vehicle == null)
				Visible = false;
			else
			{
				// pictures
				picOwnerFlag.Image = vehicle.Owner.Icon;
				picPortrait.Image = vehicle.Portrait;

				// name and stuff
				txtName.Text = vehicle.Name;
				txtRole.Text = vehicle.Design.Role;
				txtClass.Text = vehicle.Design.Name;
				txtSize.Text = vehicle.Design.Hull.Name + " (" + vehicle.Design.Hull.Size.Kilotons() + ")";
				txtMovement.Text = vehicle.MovementRemaining + " / " + vehicle.Design.Speed;
				progMovement.Maximum = vehicle.Design.Speed;
				progMovement.Value = vehicle.MovementRemaining;

				// supplies and stuff
				progSupplies.Maximum = vehicle.Design.SupplyStorage;
				progSupplies.Value = vehicle.SupplyRemaining;
				// will we even use ammo/fuel?
				progAmmunition.Visible = false;
				progFuel.Visible = false;

				// damage
				// TODO - let ships take damage
				progShields.Maximum = vehicle.Design.ShieldHitpoints;
				progShields.Value = progShields.Maximum;
				progArmor.Maximum = vehicle.Design.ArmorHitpoints;
				progArmor.Value = progArmor.Maximum;
				progHull.Maximum = vehicle.Design.HullHitpoints;
				progHull.Value = progHull.Maximum;

				// orders and stuff
				txtOrder.Text = vehicle.Orders.Any() ? vehicle.Orders.First().ToString() : "None";
				txtExperience.Text = "None"; // TODO - crew XP
				txtFleet.Text = "None"; // TODO - fleets
				
				// maintenance
				resMaintMin.Amount = vehicle.MaintenanceCost[Resource.Minerals];
				resMaintOrg.Amount = vehicle.MaintenanceCost[Resource.Organics];
				resMaintRad.Amount = vehicle.MaintenanceCost[Resource.Radioactives];

				// component summary
				txtComponentsFunctional.Text = vehicle.Components.Where(c => !c.IsDestroyed).Count() + " / " + vehicle.Components.Count + " functional";
				lstComponentsSummary.Initialize(32, 32);
				foreach (var g in vehicle.Components.GroupBy(c => c.Template))
				{
					var text = g.Any(c => c.IsDestroyed) ? g.Where(c => !c.IsDestroyed).Count() + " / " + g.Count() : g.Count().ToString();
					lstComponentsSummary.AddItemWithImage(null, text, g.First(), g.First().Template.Icon);
				}

				// cargo summary
				txtCargoSpaceFree.Text = string.Format("{0} / {1} free", (Vehicle.CargoStorage - (Vehicle.Cargo == null ? 0 : Vehicle.Cargo.Size)).Kilotons(), Vehicle.CargoStorage.Kilotons());
				lstCargoSummary.Initialize(32, 32);
				foreach (var ug in Vehicle.Cargo.Units.GroupBy(u => u.Design))
					lstCargoSummary.AddItemWithImage(ug.Key.VehicleTypeName, ug.Count() + "x " + ug.Key.Name, ug, ug.First().Icon);
				foreach (var pop in Vehicle.Cargo.Population)
					lstCargoSummary.AddItemWithImage("Population", pop.Value.ToUnitString(true) + " " + pop.Key.Name, pop, pop.Key.Icon);

				// orders detail
				lstOrdersDetail.Items.Clear();
				foreach (var o in vehicle.Orders)
					lstOrdersDetail.Items.Add(o);

				// component detail
				txtComponentsFunctionalDetail.Text = vehicle.Components.Where(c => !c.IsDestroyed).Count() + " / " + vehicle.Components.Count + " functional";
				lstComponentsDetail.Initialize(32, 32);
				foreach (var g in vehicle.Components.GroupBy(c => c.Template))
				{
					lstComponentsDetail.AddItemWithImage(null, g.Where(c => !c.IsDestroyed).Count() + "x " + g.First().Name, g.First(), g.First().Template.Icon);
					if (g.Where(c => c.IsDestroyed).Any())
						lstComponentsDetail.AddItemWithImage(null, g.Where(c => c.IsDestroyed).Count() + "x Damaged " + g.First().Name, g.First(), g.First().Template.Icon);
				}

				// cargo detail
				txtCargoSpaceFreeDetail.Text = string.Format("{0} / {1} free", (Vehicle.CargoStorage - Vehicle.Cargo.Size).Kilotons(), Vehicle.CargoStorage.Kilotons());
				lstCargoDetail.Initialize(32, 32);
				foreach (var ug in Vehicle.Cargo.Units.GroupBy(u => u.Design))
					lstCargoDetail.AddItemWithImage(ug.Key.VehicleTypeName, ug.Count() + "x " + ug.Key.Name, ug, ug.First().Icon);
				foreach (var pop in Vehicle.Cargo.Population)
					lstCargoDetail.AddItemWithImage("Population", pop.Value.ToUnitString(true) + " " + pop.Key.Name, pop, pop.Key.Icon);

				// abilities
				abilityTreeView.Abilities = Vehicle.UnstackedAbilities.StackToTree();
				abilityTreeView.IntrinsicAbilities = Vehicle.IntrinsicAbilities.Concat(Vehicle.Design.Hull.Abilities).Concat(Vehicle.Components.Where(c => !c.IsDestroyed).SelectMany(c => c.Abilities));
			}
		}

		private void btnOrderToTop_Click(object sender, System.EventArgs e)
		{
			var order = (IMobileSpaceObjectOrder<AutonomousSpaceVehicle>)lstOrdersDetail.SelectedItem;
			if (order != null)
			{
				var cmd = new RearrangeOrdersCommand<AutonomousSpaceVehicle>(
					Empire.Current, vehicle, order, -vehicle.Orders.IndexOf(order));
				Empire.Current.Commands.Add(cmd);
				cmd.Execute(); // show change locally
				Invalidate();

				if (OrdersChanged != null)
					OrdersChanged();
			}
		}

		private void btnOrderToBottom_Click(object sender, System.EventArgs e)
		{
			var order = (IMobileSpaceObjectOrder<AutonomousSpaceVehicle>)lstOrdersDetail.SelectedItem;
			if (order != null)
			{
				var cmd = new RearrangeOrdersCommand<AutonomousSpaceVehicle>(
					Empire.Current, vehicle, order, Vehicle.Orders.Count - vehicle.Orders.IndexOf(order) - 1);
				Empire.Current.Commands.Add(cmd);
				cmd.Execute(); // show change locally
				Invalidate();

				if (OrdersChanged != null)
					OrdersChanged();
			}
		}

		private void btnOrderGoesUp_Click(object sender, System.EventArgs e)
		{
			var order = (IMobileSpaceObjectOrder<AutonomousSpaceVehicle>)lstOrdersDetail.SelectedItem;
			if (order != null && vehicle.Orders.IndexOf(order) > 0)
			{
				var cmd = new RearrangeOrdersCommand<AutonomousSpaceVehicle>(
					Empire.Current, vehicle, order, -1);
				Empire.Current.Commands.Add(cmd);
				cmd.Execute(); // show change locally
				Invalidate();

				if (OrdersChanged != null)
					OrdersChanged();
			}
			if (OrdersChanged != null)
				OrdersChanged();
		}

		private void btnOrderGoesDown_Click(object sender, System.EventArgs e)
		{
			var order = (IMobileSpaceObjectOrder<AutonomousSpaceVehicle>)lstOrdersDetail.SelectedItem;
			if (order != null && vehicle.Orders.IndexOf(order) < vehicle.Orders.Count - 1)
			{
				var cmd = new RearrangeOrdersCommand<AutonomousSpaceVehicle>(
					Empire.Current, vehicle, order, 1);
				Empire.Current.Commands.Add(cmd);
				cmd.Execute(); // show change locally
				Invalidate();

				if (OrdersChanged != null)
					OrdersChanged();
			}
		}

		private void btnClearOrders_Click(object sender, System.EventArgs e)
		{
			foreach (var order in vehicle.Orders.ToArray())
			{
				var cmd = new RemoveOrderCommand<AutonomousSpaceVehicle>(
					Empire.Current, vehicle, order);
				Empire.Current.Commands.Add(cmd);
				cmd.Execute(); // show change locally
				Invalidate();

				if (OrdersChanged != null)
					OrdersChanged();
			}
		}

		private void btnDeleteOrder_Click(object sender, System.EventArgs e)
		{
			var order = (IMobileSpaceObjectOrder<AutonomousSpaceVehicle>)lstOrdersDetail.SelectedItem;
			if (order != null)
			{
				var cmd = new RemoveOrderCommand<AutonomousSpaceVehicle>(
					Empire.Current, vehicle, order);
				Empire.Current.Commands.Add(cmd);
				cmd.Execute(); // show change locally
				Invalidate();

				if (OrdersChanged != null)
					OrdersChanged();
			}
		}

		public delegate void OrdersChangedDelegate();

		public event OrdersChangedDelegate OrdersChanged;
	}
}
