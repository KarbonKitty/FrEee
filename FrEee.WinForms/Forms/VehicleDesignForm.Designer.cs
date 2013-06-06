﻿namespace FrEee.WinForms.Forms
{
	partial class VehicleDesignForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.ddlRole = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.ddlName = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.chkOnlyLatest = new System.Windows.Forms.CheckBox();
			this.picPortrait = new System.Windows.Forms.PictureBox();
			this.btnWeaponsReport = new FrEee.WinForms.Controls.GameButton();
			this.btnMount = new FrEee.WinForms.Controls.GameButton();
			this.btnCancel = new FrEee.WinForms.Controls.GameButton();
			this.btnSave = new FrEee.WinForms.Controls.GameButton();
			this.pnlStats = new FrEee.WinForms.Controls.GamePanel();
			this.txtSupplyUsage = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.txtEvasion = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.txtAccuracy = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.txtRange = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.txtHull = new System.Windows.Forms.Label();
			this.txtArmor = new System.Windows.Forms.Label();
			this.txtShields = new System.Windows.Forms.Label();
			this.txtSpeed = new System.Windows.Forms.Label();
			this.txtSupplyStorage = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.txtCargo = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.txtSpaceFree = new System.Windows.Forms.Label();
			this.resCostRad = new FrEee.WinForms.Controls.ResourceDisplay();
			this.resCostOrg = new FrEee.WinForms.Controls.ResourceDisplay();
			this.resCostMin = new FrEee.WinForms.Controls.ResourceDisplay();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.gamePanel4 = new FrEee.WinForms.Controls.GamePanel();
			this.txtDetailDescription = new System.Windows.Forms.Label();
			this.resDetailRad = new FrEee.WinForms.Controls.ResourceDisplay();
			this.resDetailOrg = new FrEee.WinForms.Controls.ResourceDisplay();
			this.resDetailMin = new FrEee.WinForms.Controls.ResourceDisplay();
			this.txtDetailSize = new System.Windows.Forms.Label();
			this.txtDetailName = new System.Windows.Forms.Label();
			this.picDetailIcon = new FrEee.WinForms.Controls.GamePictureBox();
			this.gamePanel3 = new FrEee.WinForms.Controls.GamePanel();
			this.lstWarnings = new System.Windows.Forms.ListBox();
			this.gamePanel2 = new FrEee.WinForms.Controls.GamePanel();
			this.lstComponentsInstalled = new System.Windows.Forms.ListView();
			this.gamePanel1 = new FrEee.WinForms.Controls.GamePanel();
			this.lstComponentsAvailable = new System.Windows.Forms.ListView();
			this.btnHull = new FrEee.WinForms.Controls.GameButton();
			((System.ComponentModel.ISupportInitialize)(this.picPortrait)).BeginInit();
			this.pnlStats.SuspendLayout();
			this.gamePanel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picDetailIcon)).BeginInit();
			this.gamePanel3.SuspendLayout();
			this.gamePanel2.SuspendLayout();
			this.gamePanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(25, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Hull";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label2.Location = new System.Drawing.Point(13, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Role";
			// 
			// ddlRole
			// 
			this.ddlRole.BackColor = System.Drawing.Color.Black;
			this.ddlRole.Enabled = false;
			this.ddlRole.ForeColor = System.Drawing.Color.White;
			this.ddlRole.FormattingEnabled = true;
			this.ddlRole.Location = new System.Drawing.Point(80, 38);
			this.ddlRole.Name = "ddlRole";
			this.ddlRole.Size = new System.Drawing.Size(167, 21);
			this.ddlRole.TabIndex = 4;
			this.ddlRole.TextChanged += new System.EventHandler(this.ddlRole_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label3.Location = new System.Drawing.Point(13, 70);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Name";
			// 
			// ddlName
			// 
			this.ddlName.BackColor = System.Drawing.Color.Black;
			this.ddlName.Enabled = false;
			this.ddlName.ForeColor = System.Drawing.Color.White;
			this.ddlName.FormattingEnabled = true;
			this.ddlName.Location = new System.Drawing.Point(80, 67);
			this.ddlName.Name = "ddlName";
			this.ddlName.Size = new System.Drawing.Size(167, 21);
			this.ddlName.TabIndex = 6;
			this.ddlName.TextChanged += new System.EventHandler(this.ddlName_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label4.Location = new System.Drawing.Point(13, 139);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(112, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Components Available";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label5.Location = new System.Drawing.Point(254, 139);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(108, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Components Installed";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label6.Location = new System.Drawing.Point(13, 105);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(59, 13);
			this.label6.TabIndex = 13;
			this.label6.Text = "Use Mount";
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label7.AutoSize = true;
			this.label7.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label7.Location = new System.Drawing.Point(12, 527);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(52, 13);
			this.label7.TabIndex = 18;
			this.label7.Text = "Warnings";
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label8.AutoSize = true;
			this.label8.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label8.Location = new System.Drawing.Point(254, 527);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(96, 13);
			this.label8.TabIndex = 20;
			this.label8.Text = "Component Details";
			// 
			// chkOnlyLatest
			// 
			this.chkOnlyLatest.AutoSize = true;
			this.chkOnlyLatest.Checked = true;
			this.chkOnlyLatest.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkOnlyLatest.Location = new System.Drawing.Point(167, 139);
			this.chkOnlyLatest.Name = "chkOnlyLatest";
			this.chkOnlyLatest.Size = new System.Drawing.Size(79, 17);
			this.chkOnlyLatest.TabIndex = 21;
			this.chkOnlyLatest.Text = "Only Latest";
			this.chkOnlyLatest.UseVisualStyleBackColor = true;
			this.chkOnlyLatest.CheckedChanged += new System.EventHandler(this.chkOnlyLatest_CheckedChanged);
			// 
			// picPortrait
			// 
			this.picPortrait.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.picPortrait.Location = new System.Drawing.Point(551, 195);
			this.picPortrait.Name = "picPortrait";
			this.picPortrait.Size = new System.Drawing.Size(146, 146);
			this.picPortrait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picPortrait.TabIndex = 27;
			this.picPortrait.TabStop = false;
			// 
			// btnWeaponsReport
			// 
			this.btnWeaponsReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnWeaponsReport.BackColor = System.Drawing.Color.Black;
			this.btnWeaponsReport.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.btnWeaponsReport.Location = new System.Drawing.Point(551, 155);
			this.btnWeaponsReport.Name = "btnWeaponsReport";
			this.btnWeaponsReport.Size = new System.Drawing.Size(146, 29);
			this.btnWeaponsReport.TabIndex = 26;
			this.btnWeaponsReport.Text = "Weapons Report";
			this.btnWeaponsReport.UseVisualStyleBackColor = false;
			// 
			// btnMount
			// 
			this.btnMount.BackColor = System.Drawing.Color.Black;
			this.btnMount.Enabled = false;
			this.btnMount.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.btnMount.Location = new System.Drawing.Point(78, 100);
			this.btnMount.Name = "btnMount";
			this.btnMount.Size = new System.Drawing.Size(167, 23);
			this.btnMount.TabIndex = 25;
			this.btnMount.Text = "(none)";
			this.btnMount.UseVisualStyleBackColor = false;
			this.btnMount.Click += new System.EventHandler(this.btnMount_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.BackColor = System.Drawing.Color.Black;
			this.btnCancel.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.btnCancel.Location = new System.Drawing.Point(551, 560);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(146, 29);
			this.btnCancel.TabIndex = 24;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.BackColor = System.Drawing.Color.Black;
			this.btnSave.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.btnSave.Location = new System.Drawing.Point(551, 595);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(146, 29);
			this.btnSave.TabIndex = 23;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = false;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// pnlStats
			// 
			this.pnlStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlStats.BackColor = System.Drawing.Color.Black;
			this.pnlStats.BorderColor = System.Drawing.Color.CornflowerBlue;
			this.pnlStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlStats.Controls.Add(this.txtSupplyUsage);
			this.pnlStats.Controls.Add(this.label14);
			this.pnlStats.Controls.Add(this.txtEvasion);
			this.pnlStats.Controls.Add(this.label18);
			this.pnlStats.Controls.Add(this.txtAccuracy);
			this.pnlStats.Controls.Add(this.label11);
			this.pnlStats.Controls.Add(this.txtRange);
			this.pnlStats.Controls.Add(this.label22);
			this.pnlStats.Controls.Add(this.txtHull);
			this.pnlStats.Controls.Add(this.txtArmor);
			this.pnlStats.Controls.Add(this.txtShields);
			this.pnlStats.Controls.Add(this.txtSpeed);
			this.pnlStats.Controls.Add(this.txtSupplyStorage);
			this.pnlStats.Controls.Add(this.label17);
			this.pnlStats.Controls.Add(this.txtCargo);
			this.pnlStats.Controls.Add(this.label15);
			this.pnlStats.Controls.Add(this.label13);
			this.pnlStats.Controls.Add(this.label12);
			this.pnlStats.Controls.Add(this.txtSpaceFree);
			this.pnlStats.Controls.Add(this.resCostRad);
			this.pnlStats.Controls.Add(this.resCostOrg);
			this.pnlStats.Controls.Add(this.resCostMin);
			this.pnlStats.Controls.Add(this.label10);
			this.pnlStats.Controls.Add(this.label9);
			this.pnlStats.ForeColor = System.Drawing.Color.White;
			this.pnlStats.Location = new System.Drawing.Point(257, 8);
			this.pnlStats.Name = "pnlStats";
			this.pnlStats.Padding = new System.Windows.Forms.Padding(3);
			this.pnlStats.Size = new System.Drawing.Size(440, 128);
			this.pnlStats.TabIndex = 22;
			// 
			// txtSupplyUsage
			// 
			this.txtSupplyUsage.AutoSize = true;
			this.txtSupplyUsage.Location = new System.Drawing.Point(84, 87);
			this.txtSupplyUsage.Name = "txtSupplyUsage";
			this.txtSupplyUsage.Size = new System.Drawing.Size(53, 13);
			this.txtSupplyUsage.TabIndex = 28;
			this.txtSupplyUsage.Text = "0 / sector";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label14.Location = new System.Drawing.Point(3, 87);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(73, 13);
			this.label14.TabIndex = 27;
			this.label14.Text = "Supply Usage";
			// 
			// txtEvasion
			// 
			this.txtEvasion.AutoSize = true;
			this.txtEvasion.Location = new System.Drawing.Point(253, 62);
			this.txtEvasion.Name = "txtEvasion";
			this.txtEvasion.Size = new System.Drawing.Size(27, 13);
			this.txtEvasion.TabIndex = 26;
			this.txtEvasion.Text = "+0%";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label18.Location = new System.Drawing.Point(179, 61);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(45, 13);
			this.label18.TabIndex = 25;
			this.label18.Text = "Evasion";
			// 
			// txtAccuracy
			// 
			this.txtAccuracy.AutoSize = true;
			this.txtAccuracy.Location = new System.Drawing.Point(253, 49);
			this.txtAccuracy.Name = "txtAccuracy";
			this.txtAccuracy.Size = new System.Drawing.Size(27, 13);
			this.txtAccuracy.TabIndex = 24;
			this.txtAccuracy.Text = "+0%";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label11.Location = new System.Drawing.Point(179, 49);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(52, 13);
			this.label11.TabIndex = 23;
			this.label11.Text = "Accuracy";
			// 
			// txtRange
			// 
			this.txtRange.AutoSize = true;
			this.txtRange.Location = new System.Drawing.Point(84, 101);
			this.txtRange.Name = "txtRange";
			this.txtRange.Size = new System.Drawing.Size(50, 13);
			this.txtRange.TabIndex = 22;
			this.txtRange.Text = "0 sectors";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label22.Location = new System.Drawing.Point(3, 101);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(39, 13);
			this.label22.TabIndex = 21;
			this.label22.Text = "Range";
			// 
			// txtHull
			// 
			this.txtHull.AutoSize = true;
			this.txtHull.Location = new System.Drawing.Point(253, 32);
			this.txtHull.Name = "txtHull";
			this.txtHull.Size = new System.Drawing.Size(32, 13);
			this.txtHull.TabIndex = 20;
			this.txtHull.Text = "0 hull";
			// 
			// txtArmor
			// 
			this.txtArmor.AutoSize = true;
			this.txtArmor.Location = new System.Drawing.Point(253, 17);
			this.txtArmor.Name = "txtArmor";
			this.txtArmor.Size = new System.Drawing.Size(42, 13);
			this.txtArmor.TabIndex = 19;
			this.txtArmor.Text = "0 armor";
			// 
			// txtShields
			// 
			this.txtShields.AutoSize = true;
			this.txtShields.Location = new System.Drawing.Point(253, 4);
			this.txtShields.Name = "txtShields";
			this.txtShields.Size = new System.Drawing.Size(99, 13);
			this.txtShields.TabIndex = 18;
			this.txtShields.Text = "0 shields (+0 regen)";
			// 
			// txtSpeed
			// 
			this.txtSpeed.AutoSize = true;
			this.txtSpeed.Location = new System.Drawing.Point(84, 62);
			this.txtSpeed.Name = "txtSpeed";
			this.txtSpeed.Size = new System.Drawing.Size(73, 13);
			this.txtSpeed.TabIndex = 17;
			this.txtSpeed.Text = "0 sectors/turn";
			// 
			// txtSupplyStorage
			// 
			this.txtSupplyStorage.AutoSize = true;
			this.txtSupplyStorage.Location = new System.Drawing.Point(84, 75);
			this.txtSupplyStorage.Name = "txtSupplyStorage";
			this.txtSupplyStorage.Size = new System.Drawing.Size(13, 13);
			this.txtSupplyStorage.TabIndex = 16;
			this.txtSupplyStorage.Text = "0";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label17.Location = new System.Drawing.Point(3, 74);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(79, 13);
			this.label17.TabIndex = 15;
			this.label17.Text = "Supply Storage";
			// 
			// txtCargo
			// 
			this.txtCargo.AutoSize = true;
			this.txtCargo.Location = new System.Drawing.Point(254, 75);
			this.txtCargo.Name = "txtCargo";
			this.txtCargo.Size = new System.Drawing.Size(26, 13);
			this.txtCargo.TabIndex = 14;
			this.txtCargo.Text = "0kT";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label15.Location = new System.Drawing.Point(179, 75);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(75, 13);
			this.label15.TabIndex = 13;
			this.label15.Text = "Cargo Storage";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label13.Location = new System.Drawing.Point(179, 4);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(50, 13);
			this.label13.TabIndex = 11;
			this.label13.Text = "Durability";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label12.Location = new System.Drawing.Point(3, 61);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(38, 13);
			this.label12.TabIndex = 10;
			this.label12.Text = "Speed";
			// 
			// txtSpaceFree
			// 
			this.txtSpaceFree.AutoSize = true;
			this.txtSpaceFree.Location = new System.Drawing.Point(84, 3);
			this.txtSpaceFree.Name = "txtSpaceFree";
			this.txtSpaceFree.Size = new System.Drawing.Size(56, 13);
			this.txtSpaceFree.TabIndex = 9;
			this.txtSpaceFree.Text = "0kT / 0kT";
			// 
			// resCostRad
			// 
			this.resCostRad.Amount = 0;
			this.resCostRad.BackColor = System.Drawing.Color.Black;
			this.resCostRad.Change = null;
			this.resCostRad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.resCostRad.Location = new System.Drawing.Point(78, 47);
			this.resCostRad.Margin = new System.Windows.Forms.Padding(0);
			this.resCostRad.Name = "resCostRad";
			this.resCostRad.ResourceColor = System.Drawing.Color.Empty;
			this.resCostRad.Size = new System.Drawing.Size(60, 15);
			this.resCostRad.TabIndex = 8;
			// 
			// resCostOrg
			// 
			this.resCostOrg.Amount = 0;
			this.resCostOrg.BackColor = System.Drawing.Color.Black;
			this.resCostOrg.Change = null;
			this.resCostOrg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.resCostOrg.Location = new System.Drawing.Point(78, 32);
			this.resCostOrg.Margin = new System.Windows.Forms.Padding(0);
			this.resCostOrg.Name = "resCostOrg";
			this.resCostOrg.ResourceColor = System.Drawing.Color.Empty;
			this.resCostOrg.Size = new System.Drawing.Size(60, 15);
			this.resCostOrg.TabIndex = 7;
			// 
			// resCostMin
			// 
			this.resCostMin.Amount = 0;
			this.resCostMin.BackColor = System.Drawing.Color.Black;
			this.resCostMin.Change = null;
			this.resCostMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.resCostMin.Location = new System.Drawing.Point(78, 17);
			this.resCostMin.Margin = new System.Windows.Forms.Padding(0);
			this.resCostMin.Name = "resCostMin";
			this.resCostMin.ResourceColor = System.Drawing.Color.Empty;
			this.resCostMin.Size = new System.Drawing.Size(60, 15);
			this.resCostMin.TabIndex = 6;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label10.Location = new System.Drawing.Point(3, 17);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(28, 13);
			this.label10.TabIndex = 2;
			this.label10.Text = "Cost";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label9.Location = new System.Drawing.Point(3, 4);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(62, 13);
			this.label9.TabIndex = 1;
			this.label9.Text = "Space Free";
			// 
			// gamePanel4
			// 
			this.gamePanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.gamePanel4.BackColor = System.Drawing.Color.Black;
			this.gamePanel4.BorderColor = System.Drawing.Color.CornflowerBlue;
			this.gamePanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.gamePanel4.Controls.Add(this.txtDetailDescription);
			this.gamePanel4.Controls.Add(this.resDetailRad);
			this.gamePanel4.Controls.Add(this.resDetailOrg);
			this.gamePanel4.Controls.Add(this.resDetailMin);
			this.gamePanel4.Controls.Add(this.txtDetailSize);
			this.gamePanel4.Controls.Add(this.txtDetailName);
			this.gamePanel4.Controls.Add(this.picDetailIcon);
			this.gamePanel4.ForeColor = System.Drawing.Color.White;
			this.gamePanel4.Location = new System.Drawing.Point(253, 543);
			this.gamePanel4.Name = "gamePanel4";
			this.gamePanel4.Padding = new System.Windows.Forms.Padding(3);
			this.gamePanel4.Size = new System.Drawing.Size(292, 81);
			this.gamePanel4.TabIndex = 19;
			// 
			// txtDetailDescription
			// 
			this.txtDetailDescription.Location = new System.Drawing.Point(3, 46);
			this.txtDetailDescription.Name = "txtDetailDescription";
			this.txtDetailDescription.Size = new System.Drawing.Size(197, 30);
			this.txtDetailDescription.TabIndex = 6;
			this.txtDetailDescription.Text = "label9";
			// 
			// resDetailRad
			// 
			this.resDetailRad.Amount = 0;
			this.resDetailRad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.resDetailRad.BackColor = System.Drawing.Color.Black;
			this.resDetailRad.Change = null;
			this.resDetailRad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.resDetailRad.Location = new System.Drawing.Point(206, 61);
			this.resDetailRad.Margin = new System.Windows.Forms.Padding(0);
			this.resDetailRad.Name = "resDetailRad";
			this.resDetailRad.ResourceColor = System.Drawing.Color.Empty;
			this.resDetailRad.Size = new System.Drawing.Size(81, 15);
			this.resDetailRad.TabIndex = 5;
			// 
			// resDetailOrg
			// 
			this.resDetailOrg.Amount = 0;
			this.resDetailOrg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.resDetailOrg.BackColor = System.Drawing.Color.Black;
			this.resDetailOrg.Change = null;
			this.resDetailOrg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.resDetailOrg.Location = new System.Drawing.Point(206, 45);
			this.resDetailOrg.Margin = new System.Windows.Forms.Padding(0);
			this.resDetailOrg.Name = "resDetailOrg";
			this.resDetailOrg.ResourceColor = System.Drawing.Color.Empty;
			this.resDetailOrg.Size = new System.Drawing.Size(81, 15);
			this.resDetailOrg.TabIndex = 4;
			// 
			// resDetailMin
			// 
			this.resDetailMin.Amount = 0;
			this.resDetailMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.resDetailMin.BackColor = System.Drawing.Color.Black;
			this.resDetailMin.Change = null;
			this.resDetailMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.resDetailMin.Location = new System.Drawing.Point(206, 24);
			this.resDetailMin.Margin = new System.Windows.Forms.Padding(0);
			this.resDetailMin.Name = "resDetailMin";
			this.resDetailMin.ResourceColor = System.Drawing.Color.Empty;
			this.resDetailMin.Size = new System.Drawing.Size(81, 21);
			this.resDetailMin.TabIndex = 3;
			// 
			// txtDetailSize
			// 
			this.txtDetailSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDetailSize.Location = new System.Drawing.Point(238, 7);
			this.txtDetailSize.Name = "txtDetailSize";
			this.txtDetailSize.Size = new System.Drawing.Size(46, 13);
			this.txtDetailSize.TabIndex = 2;
			this.txtDetailSize.Text = "(no size)";
			this.txtDetailSize.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtDetailName
			// 
			this.txtDetailName.AutoSize = true;
			this.txtDetailName.Location = new System.Drawing.Point(45, 7);
			this.txtDetailName.Name = "txtDetailName";
			this.txtDetailName.Size = new System.Drawing.Size(81, 13);
			this.txtDetailName.TabIndex = 1;
			this.txtDetailName.Text = "(no component)";
			// 
			// picDetailIcon
			// 
			this.picDetailIcon.Location = new System.Drawing.Point(7, 7);
			this.picDetailIcon.Name = "picDetailIcon";
			this.picDetailIcon.Size = new System.Drawing.Size(32, 32);
			this.picDetailIcon.TabIndex = 0;
			this.picDetailIcon.TabStop = false;
			// 
			// gamePanel3
			// 
			this.gamePanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.gamePanel3.BackColor = System.Drawing.Color.Black;
			this.gamePanel3.BorderColor = System.Drawing.Color.CornflowerBlue;
			this.gamePanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.gamePanel3.Controls.Add(this.lstWarnings);
			this.gamePanel3.ForeColor = System.Drawing.Color.White;
			this.gamePanel3.Location = new System.Drawing.Point(12, 543);
			this.gamePanel3.Name = "gamePanel3";
			this.gamePanel3.Padding = new System.Windows.Forms.Padding(3);
			this.gamePanel3.Size = new System.Drawing.Size(234, 81);
			this.gamePanel3.TabIndex = 17;
			// 
			// lstWarnings
			// 
			this.lstWarnings.BackColor = System.Drawing.Color.Black;
			this.lstWarnings.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lstWarnings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstWarnings.ForeColor = System.Drawing.Color.Salmon;
			this.lstWarnings.FormattingEnabled = true;
			this.lstWarnings.Location = new System.Drawing.Point(3, 3);
			this.lstWarnings.Name = "lstWarnings";
			this.lstWarnings.Size = new System.Drawing.Size(226, 73);
			this.lstWarnings.TabIndex = 16;
			// 
			// gamePanel2
			// 
			this.gamePanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.gamePanel2.BackColor = System.Drawing.Color.Black;
			this.gamePanel2.BorderColor = System.Drawing.Color.CornflowerBlue;
			this.gamePanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.gamePanel2.Controls.Add(this.lstComponentsInstalled);
			this.gamePanel2.ForeColor = System.Drawing.Color.White;
			this.gamePanel2.Location = new System.Drawing.Point(253, 155);
			this.gamePanel2.Name = "gamePanel2";
			this.gamePanel2.Padding = new System.Windows.Forms.Padding(3);
			this.gamePanel2.Size = new System.Drawing.Size(292, 368);
			this.gamePanel2.TabIndex = 9;
			// 
			// lstComponentsInstalled
			// 
			this.lstComponentsInstalled.BackColor = System.Drawing.Color.Black;
			this.lstComponentsInstalled.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lstComponentsInstalled.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstComponentsInstalled.ForeColor = System.Drawing.Color.White;
			this.lstComponentsInstalled.HoverSelection = true;
			this.lstComponentsInstalled.Location = new System.Drawing.Point(3, 3);
			this.lstComponentsInstalled.Name = "lstComponentsInstalled";
			this.lstComponentsInstalled.Size = new System.Drawing.Size(284, 360);
			this.lstComponentsInstalled.TabIndex = 0;
			this.lstComponentsInstalled.UseCompatibleStateImageBehavior = false;
			this.lstComponentsInstalled.View = System.Windows.Forms.View.Tile;
			this.lstComponentsInstalled.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.lstComponentsInstalled_ItemMouseHover);
			this.lstComponentsInstalled.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstComponentsInstalled_MouseClick);
			this.lstComponentsInstalled.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstComponentsInstalled_MouseDoubleClick);
			// 
			// gamePanel1
			// 
			this.gamePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.gamePanel1.BackColor = System.Drawing.Color.Black;
			this.gamePanel1.BorderColor = System.Drawing.Color.CornflowerBlue;
			this.gamePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.gamePanel1.Controls.Add(this.lstComponentsAvailable);
			this.gamePanel1.ForeColor = System.Drawing.Color.White;
			this.gamePanel1.Location = new System.Drawing.Point(12, 155);
			this.gamePanel1.Name = "gamePanel1";
			this.gamePanel1.Padding = new System.Windows.Forms.Padding(3);
			this.gamePanel1.Size = new System.Drawing.Size(234, 368);
			this.gamePanel1.TabIndex = 7;
			// 
			// lstComponentsAvailable
			// 
			this.lstComponentsAvailable.BackColor = System.Drawing.Color.Black;
			this.lstComponentsAvailable.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lstComponentsAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstComponentsAvailable.ForeColor = System.Drawing.Color.White;
			this.lstComponentsAvailable.HoverSelection = true;
			this.lstComponentsAvailable.Location = new System.Drawing.Point(3, 3);
			this.lstComponentsAvailable.Name = "lstComponentsAvailable";
			this.lstComponentsAvailable.Size = new System.Drawing.Size(226, 360);
			this.lstComponentsAvailable.TabIndex = 0;
			this.lstComponentsAvailable.UseCompatibleStateImageBehavior = false;
			this.lstComponentsAvailable.View = System.Windows.Forms.View.Tile;
			this.lstComponentsAvailable.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.lstComponentsAvailable_ItemMouseHover);
			this.lstComponentsAvailable.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstComponentsAvailable_MouseClick);
			this.lstComponentsAvailable.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstComponentsAvailable_MouseDoubleClick);
			// 
			// btnHull
			// 
			this.btnHull.BackColor = System.Drawing.Color.Black;
			this.btnHull.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.btnHull.Location = new System.Drawing.Point(80, 8);
			this.btnHull.Name = "btnHull";
			this.btnHull.Size = new System.Drawing.Size(167, 23);
			this.btnHull.TabIndex = 2;
			this.btnHull.Text = "(choose)";
			this.btnHull.UseVisualStyleBackColor = false;
			this.btnHull.Click += new System.EventHandler(this.btnHull_Click);
			// 
			// VehicleDesignForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(709, 636);
			this.Controls.Add(this.picPortrait);
			this.Controls.Add(this.btnWeaponsReport);
			this.Controls.Add(this.btnMount);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.pnlStats);
			this.Controls.Add(this.chkOnlyLatest);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.gamePanel4);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.gamePanel3);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.gamePanel2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.gamePanel1);
			this.Controls.Add(this.ddlName);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.ddlRole);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnHull);
			this.Controls.Add(this.label1);
			this.ForeColor = System.Drawing.Color.White;
			this.MaximumSize = new System.Drawing.Size(725, 9999);
			this.MinimumSize = new System.Drawing.Size(725, 493);
			this.Name = "VehicleDesignForm";
			this.Text = "Vehicle Designer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VehicleDesignForm_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.picPortrait)).EndInit();
			this.pnlStats.ResumeLayout(false);
			this.pnlStats.PerformLayout();
			this.gamePanel4.ResumeLayout(false);
			this.gamePanel4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picDetailIcon)).EndInit();
			this.gamePanel3.ResumeLayout(false);
			this.gamePanel2.ResumeLayout(false);
			this.gamePanel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private Controls.GameButton btnHull;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox ddlRole;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox ddlName;
		private Controls.GamePanel gamePanel1;
		private System.Windows.Forms.ListView lstComponentsAvailable;
		private System.Windows.Forms.Label label4;
		private Controls.GamePanel gamePanel2;
		private System.Windows.Forms.ListView lstComponentsInstalled;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private Controls.GamePanel gamePanel3;
		private System.Windows.Forms.ListBox lstWarnings;
		private System.Windows.Forms.Label label7;
		private Controls.GamePanel gamePanel4;
		private System.Windows.Forms.Label label8;
		private Controls.GamePictureBox picDetailIcon;
		private System.Windows.Forms.Label txtDetailName;
		private System.Windows.Forms.Label txtDetailSize;
		private Controls.ResourceDisplay resDetailRad;
		private Controls.ResourceDisplay resDetailOrg;
		private Controls.ResourceDisplay resDetailMin;
		private System.Windows.Forms.Label txtDetailDescription;
		private System.Windows.Forms.CheckBox chkOnlyLatest;
		private Controls.GamePanel pnlStats;
		private Controls.ResourceDisplay resCostRad;
		private Controls.ResourceDisplay resCostOrg;
		private Controls.ResourceDisplay resCostMin;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label txtSpaceFree;
		private System.Windows.Forms.Label txtCargo;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label txtSupplyStorage;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label txtSpeed;
		private System.Windows.Forms.Label txtHull;
		private System.Windows.Forms.Label txtArmor;
		private System.Windows.Forms.Label txtShields;
		private System.Windows.Forms.Label txtRange;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label txtEvasion;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label txtAccuracy;
		private System.Windows.Forms.Label label11;
		private Controls.GameButton btnSave;
		private Controls.GameButton btnCancel;
		private Controls.GameButton btnMount;
		private Controls.GameButton btnWeaponsReport;
		private System.Windows.Forms.PictureBox picPortrait;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label txtSupplyUsage;
	}
}