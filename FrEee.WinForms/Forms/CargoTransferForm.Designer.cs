﻿namespace FrEee.WinForms.Forms
{
    partial class CargoTransferForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.clDrop = new FrEee.WinForms.Controls.CargoList();
			this.clLoad = new FrEee.WinForms.Controls.CargoList();
			this.clTo = new FrEee.WinForms.Controls.CargoList();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtFromContainer = new System.Windows.Forms.Label();
			this.ddlToContainer = new System.Windows.Forms.ComboBox();
			this.clFrom = new FrEee.WinForms.Controls.CargoList();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnLoad = new FrEee.WinForms.Controls.GameButton();
			this.btnCancel = new FrEee.WinForms.Controls.GameButton();
			this.btnOK = new FrEee.WinForms.Controls.GameButton();
			this.btnDrop = new FrEee.WinForms.Controls.GameButton();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.clDrop, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.clLoad, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.clTo, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.txtFromContainer, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.ddlToContainer, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.clFrom, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.btnDrop, 0, 4);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 561);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// clDrop
			// 
			this.clDrop.BackColor = System.Drawing.Color.Black;
			this.clDrop.CargoContainer = null;
			this.clDrop.CargoDelta = null;
			this.clDrop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.clDrop.ForeColor = System.Drawing.Color.White;
			this.clDrop.Location = new System.Drawing.Point(395, 295);
			this.clDrop.Name = "clDrop";
			this.clDrop.Size = new System.Drawing.Size(386, 238);
			this.clDrop.TabIndex = 10;
			this.clDrop.Enter += new System.EventHandler(this.cl_Enter);
			this.clDrop.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cargoList_MouseDoubleClick);
			// 
			// clLoad
			// 
			this.clLoad.BackColor = System.Drawing.Color.Black;
			this.clLoad.CargoContainer = null;
			this.clLoad.CargoDelta = null;
			this.clLoad.Dock = System.Windows.Forms.DockStyle.Fill;
			this.clLoad.ForeColor = System.Drawing.Color.White;
			this.clLoad.Location = new System.Drawing.Point(3, 295);
			this.clLoad.Name = "clLoad";
			this.clLoad.Size = new System.Drawing.Size(386, 238);
			this.clLoad.TabIndex = 9;
			this.clLoad.Enter += new System.EventHandler(this.cl_Enter);
			this.clLoad.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cargoList_MouseDoubleClick);
			// 
			// clTo
			// 
			this.clTo.BackColor = System.Drawing.Color.Black;
			this.clTo.CargoContainer = null;
			this.clTo.CargoDelta = null;
			this.clTo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.clTo.ForeColor = System.Drawing.Color.White;
			this.clTo.Location = new System.Drawing.Point(395, 51);
			this.clTo.Name = "clTo";
			this.clTo.Size = new System.Drawing.Size(386, 238);
			this.clTo.TabIndex = 7;
			this.clTo.Enter += new System.EventHandler(this.cl_Enter);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label2.Location = new System.Drawing.Point(395, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Cargo To:";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label1.Location = new System.Drawing.Point(3, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Cargo From:";
			// 
			// txtFromContainer
			// 
			this.txtFromContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtFromContainer.AutoSize = true;
			this.txtFromContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtFromContainer.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.txtFromContainer.Location = new System.Drawing.Point(3, 32);
			this.txtFromContainer.Name = "txtFromContainer";
			this.txtFromContainer.Size = new System.Drawing.Size(99, 16);
			this.txtFromContainer.TabIndex = 4;
			this.txtFromContainer.Text = "From Container";
			// 
			// ddlToContainer
			// 
			this.ddlToContainer.DisplayMember = "Name";
			this.ddlToContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ddlToContainer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlToContainer.FormattingEnabled = true;
			this.ddlToContainer.Location = new System.Drawing.Point(395, 27);
			this.ddlToContainer.Name = "ddlToContainer";
			this.ddlToContainer.Size = new System.Drawing.Size(386, 21);
			this.ddlToContainer.TabIndex = 5;
			this.ddlToContainer.SelectedIndexChanged += new System.EventHandler(this.ddlToContainer_SelectedIndexChanged);
			// 
			// clFrom
			// 
			this.clFrom.BackColor = System.Drawing.Color.Black;
			this.clFrom.CargoContainer = null;
			this.clFrom.CargoDelta = null;
			this.clFrom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.clFrom.ForeColor = System.Drawing.Color.White;
			this.clFrom.Location = new System.Drawing.Point(3, 51);
			this.clFrom.Name = "clFrom";
			this.clFrom.Size = new System.Drawing.Size(386, 238);
			this.clFrom.TabIndex = 6;
			this.clFrom.Enter += new System.EventHandler(this.cl_Enter);
			this.clFrom.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cargoList_MouseDoubleClick);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnLoad);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnOK);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(392, 536);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(392, 25);
			this.panel1.TabIndex = 11;
			// 
			// btnLoad
			// 
			this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLoad.BackColor = System.Drawing.Color.Black;
			this.btnLoad.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.btnLoad.Location = new System.Drawing.Point(3, 3);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(100, 19);
			this.btnLoad.TabIndex = 2;
			this.btnLoad.Text = "<";
			this.btnLoad.UseVisualStyleBackColor = false;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.BackColor = System.Drawing.Color.Black;
			this.btnCancel.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.btnCancel.Location = new System.Drawing.Point(183, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 19);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.BackColor = System.Drawing.Color.Black;
			this.btnOK.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.btnOK.Location = new System.Drawing.Point(289, 3);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(100, 19);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = false;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnDrop
			// 
			this.btnDrop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDrop.BackColor = System.Drawing.Color.Black;
			this.btnDrop.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.btnDrop.Location = new System.Drawing.Point(289, 539);
			this.btnDrop.Name = "btnDrop";
			this.btnDrop.Size = new System.Drawing.Size(100, 19);
			this.btnDrop.TabIndex = 3;
			this.btnDrop.Text = ">";
			this.btnDrop.UseVisualStyleBackColor = false;
			this.btnDrop.Click += new System.EventHandler(this.btnDrop_Click);
			// 
			// CargoTransferForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.tableLayoutPanel1);
			this.ForeColor = System.Drawing.Color.White;
			this.Name = "CargoTransferForm";
			this.Text = "Transfer Cargo";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CargoTransferForm_FormClosing);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label txtFromContainer;
		private System.Windows.Forms.ComboBox ddlToContainer;
		private Controls.CargoList clTo;
		private Controls.CargoList clFrom;
		private Controls.CargoList clDrop;
		private Controls.CargoList clLoad;
		private System.Windows.Forms.Panel panel1;
		private Controls.GameButton btnCancel;
		private Controls.GameButton btnOK;
		private Controls.GameButton btnLoad;
		private Controls.GameButton btnDrop;
    }
}