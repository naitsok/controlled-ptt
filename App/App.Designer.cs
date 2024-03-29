﻿namespace ControlledPTT
{
    partial class App
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(App));
            this.txtExpDir = new System.Windows.Forms.TextBox();
            this.btnSelectExpDir = new System.Windows.Forms.Button();
            this.txtExpFileName = new System.Windows.Forms.TextBox();
            this.pltTemperature = new OxyPlot.WindowsForms.PlotView();
            this.gbExperiment = new System.Windows.Forms.GroupBox();
            this.txtGainedThermalDose = new System.Windows.Forms.TextBox();
            this.lblGainedThermalDose = new System.Windows.Forms.Label();
            this.gbStopCondition = new System.Windows.Forms.GroupBox();
            this.lblThermalDose = new System.Windows.Forms.Label();
            this.nudThermalDose = new System.Windows.Forms.NumericUpDown();
            this.cmbStopCondition = new System.Windows.Forms.ComboBox();
            this.lblExpTime = new System.Windows.Forms.Label();
            this.nudExpTime = new System.Windows.Forms.NumericUpDown();
            this.txtElapsedTime = new System.Windows.Forms.TextBox();
            this.cbSaveHeader = new System.Windows.Forms.CheckBox();
            this.gbLaser = new System.Windows.Forms.GroupBox();
            this.btnRemoveLaser = new System.Windows.Forms.Button();
            this.btnStartLaser = new System.Windows.Forms.Button();
            this.btnLoadLaser = new System.Windows.Forms.Button();
            this.cmbLasers = new System.Windows.Forms.ComboBox();
            this.txtOperator = new System.Windows.Forms.TextBox();
            this.lblOperator = new System.Windows.Forms.Label();
            this.cbSaveData = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblFileDir = new System.Windows.Forms.Label();
            this.cmbExperimentType = new System.Windows.Forms.ComboBox();
            this.txtExperimentStarted = new System.Windows.Forms.TextBox();
            this.gbPID = new System.Windows.Forms.GroupBox();
            this.lblTargetTemp = new System.Windows.Forms.Label();
            this.nudTargetTemp = new System.Windows.Forms.NumericUpDown();
            this.nudDiffGain = new System.Windows.Forms.NumericUpDown();
            this.lblPropGain = new System.Windows.Forms.Label();
            this.lblRelativePower = new System.Windows.Forms.Label();
            this.txtRelativePower = new System.Windows.Forms.TextBox();
            this.nudIntGain = new System.Windows.Forms.NumericUpDown();
            this.lblDiffGain = new System.Windows.Forms.Label();
            this.lblIntGain = new System.Windows.Forms.Label();
            this.nudPropGain = new System.Windows.Forms.NumericUpDown();
            this.btnStartExperiment = new System.Windows.Forms.Button();
            this.lblElapsedTime = new System.Windows.Forms.Label();
            this.lblCalibratedTemperature = new System.Windows.Forms.Label();
            this.lblSensorTemp = new System.Windows.Forms.Label();
            this.txtCalibratedTemp = new System.Windows.Forms.TextBox();
            this.txtSensorTemp = new System.Windows.Forms.TextBox();
            this.gbSensor = new System.Windows.Forms.GroupBox();
            this.btnRemoveSensor = new System.Windows.Forms.Button();
            this.btnStartSensor = new System.Windows.Forms.Button();
            this.btnLoadSensor = new System.Windows.Forms.Button();
            this.cmbSensors = new System.Windows.Forms.ComboBox();
            this.cbUseCalibration = new System.Windows.Forms.CheckBox();
            this.pltLaserCurrent = new OxyPlot.WindowsForms.PlotView();
            this.pltAmbTemp = new OxyPlot.WindowsForms.PlotView();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.appSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCurrentConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.saveConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveConfigAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurrentConfigWhenClosingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSensorAndLaserPartsOnStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.experimentSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discrettizationTimemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDirectoryWithCurrentDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFileWithCurrentTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutControlledPTTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbCalibration = new System.Windows.Forms.GroupBox();
            this.txtIntercept = new System.Windows.Forms.TextBox();
            this.txtSlope = new System.Windows.Forms.TextBox();
            this.lblIntercept = new System.Windows.Forms.Label();
            this.lblSlope = new System.Windows.Forms.Label();
            this.btnModifyCalibration = new System.Windows.Forms.Button();
            this.btnNewCalibration = new System.Windows.Forms.Button();
            this.btnLoadCalibration = new System.Windows.Forms.Button();
            this.txtCalibration = new System.Windows.Forms.TextBox();
            this.ofdSelectSensor = new System.Windows.Forms.OpenFileDialog();
            this.fbdSelectDir = new System.Windows.Forms.FolderBrowserDialog();
            this.sfdSaveConfigAs = new System.Windows.Forms.SaveFileDialog();
            this.ttSaveHeader = new System.Windows.Forms.ToolTip(this.components);
            this.ofdSelectLaser = new System.Windows.Forms.OpenFileDialog();
            this.ofdLoadCalibration = new System.Windows.Forms.OpenFileDialog();
            this.ofdLoadConfig = new System.Windows.Forms.OpenFileDialog();
            this.btnExit = new System.Windows.Forms.Button();
            this.nudDiscretizationTimeToolStripMenuItem = new ControlledPTT.ToolStripNumberControl();
            this.gbExperiment.SuspendLayout();
            this.gbStopCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThermalDose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudExpTime)).BeginInit();
            this.gbLaser.SuspendLayout();
            this.gbPID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiffGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPropGain)).BeginInit();
            this.gbSensor.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.gbCalibration.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtExpDir
            // 
            this.txtExpDir.Location = new System.Drawing.Point(72, 72);
            this.txtExpDir.Name = "txtExpDir";
            this.txtExpDir.ReadOnly = true;
            this.txtExpDir.Size = new System.Drawing.Size(320, 20);
            this.txtExpDir.TabIndex = 16;
            // 
            // btnSelectExpDir
            // 
            this.btnSelectExpDir.Location = new System.Drawing.Point(398, 70);
            this.btnSelectExpDir.Name = "btnSelectExpDir";
            this.btnSelectExpDir.Size = new System.Drawing.Size(106, 23);
            this.btnSelectExpDir.TabIndex = 18;
            this.btnSelectExpDir.Text = "Select Directory";
            this.btnSelectExpDir.UseVisualStyleBackColor = true;
            this.btnSelectExpDir.Click += new System.EventHandler(this.btnSelectExpDir_Click);
            // 
            // txtExpFileName
            // 
            this.txtExpFileName.Location = new System.Drawing.Point(72, 46);
            this.txtExpFileName.Name = "txtExpFileName";
            this.txtExpFileName.Size = new System.Drawing.Size(432, 20);
            this.txtExpFileName.TabIndex = 19;
            // 
            // pltTemperature
            // 
            this.pltTemperature.Location = new System.Drawing.Point(0, 557);
            this.pltTemperature.Name = "pltTemperature";
            this.pltTemperature.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.pltTemperature.Size = new System.Drawing.Size(534, 260);
            this.pltTemperature.TabIndex = 43;
            this.pltTemperature.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.pltTemperature.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pltTemperature.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // gbExperiment
            // 
            this.gbExperiment.Controls.Add(this.txtGainedThermalDose);
            this.gbExperiment.Controls.Add(this.lblGainedThermalDose);
            this.gbExperiment.Controls.Add(this.gbStopCondition);
            this.gbExperiment.Controls.Add(this.txtElapsedTime);
            this.gbExperiment.Controls.Add(this.cbSaveHeader);
            this.gbExperiment.Controls.Add(this.gbLaser);
            this.gbExperiment.Controls.Add(this.txtOperator);
            this.gbExperiment.Controls.Add(this.lblOperator);
            this.gbExperiment.Controls.Add(this.cbSaveData);
            this.gbExperiment.Controls.Add(this.txtDescription);
            this.gbExperiment.Controls.Add(this.lblDescription);
            this.gbExperiment.Controls.Add(this.lblFileName);
            this.gbExperiment.Controls.Add(this.lblFileDir);
            this.gbExperiment.Controls.Add(this.txtExpFileName);
            this.gbExperiment.Controls.Add(this.cmbExperimentType);
            this.gbExperiment.Controls.Add(this.btnSelectExpDir);
            this.gbExperiment.Controls.Add(this.txtExperimentStarted);
            this.gbExperiment.Controls.Add(this.txtExpDir);
            this.gbExperiment.Controls.Add(this.gbPID);
            this.gbExperiment.Controls.Add(this.btnStartExperiment);
            this.gbExperiment.Controls.Add(this.lblElapsedTime);
            this.gbExperiment.Location = new System.Drawing.Point(12, 174);
            this.gbExperiment.Name = "gbExperiment";
            this.gbExperiment.Size = new System.Drawing.Size(510, 387);
            this.gbExperiment.TabIndex = 47;
            this.gbExperiment.TabStop = false;
            this.gbExperiment.Text = "Experiment";
            // 
            // txtGainedThermalDose
            // 
            this.txtGainedThermalDose.Location = new System.Drawing.Point(398, 361);
            this.txtGainedThermalDose.Name = "txtGainedThermalDose";
            this.txtGainedThermalDose.ReadOnly = true;
            this.txtGainedThermalDose.Size = new System.Drawing.Size(106, 20);
            this.txtGainedThermalDose.TabIndex = 88;
            this.txtGainedThermalDose.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblGainedThermalDose
            // 
            this.lblGainedThermalDose.AutoSize = true;
            this.lblGainedThermalDose.Location = new System.Drawing.Point(264, 364);
            this.lblGainedThermalDose.Name = "lblGainedThermalDose";
            this.lblGainedThermalDose.Size = new System.Drawing.Size(110, 13);
            this.lblGainedThermalDose.TabIndex = 89;
            this.lblGainedThermalDose.Text = "Gained Thermal Dose";
            // 
            // gbStopCondition
            // 
            this.gbStopCondition.Controls.Add(this.lblThermalDose);
            this.gbStopCondition.Controls.Add(this.nudThermalDose);
            this.gbStopCondition.Controls.Add(this.cmbStopCondition);
            this.gbStopCondition.Controls.Add(this.lblExpTime);
            this.gbStopCondition.Controls.Add(this.nudExpTime);
            this.gbStopCondition.Location = new System.Drawing.Point(6, 283);
            this.gbStopCondition.Name = "gbStopCondition";
            this.gbStopCondition.Size = new System.Drawing.Size(498, 46);
            this.gbStopCondition.TabIndex = 87;
            this.gbStopCondition.TabStop = false;
            this.gbStopCondition.Text = "Stop Condition";
            // 
            // lblThermalDose
            // 
            this.lblThermalDose.AutoSize = true;
            this.lblThermalDose.Location = new System.Drawing.Point(389, 1);
            this.lblThermalDose.Name = "lblThermalDose";
            this.lblThermalDose.Size = new System.Drawing.Size(98, 13);
            this.lblThermalDose.TabIndex = 90;
            this.lblThermalDose.Text = "Thremal Dose [min]";
            // 
            // nudThermalDose
            // 
            this.nudThermalDose.DecimalPlaces = 1;
            this.nudThermalDose.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudThermalDose.Location = new System.Drawing.Point(392, 20);
            this.nudThermalDose.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudThermalDose.Name = "nudThermalDose";
            this.nudThermalDose.Size = new System.Drawing.Size(100, 20);
            this.nudThermalDose.TabIndex = 80;
            this.nudThermalDose.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudThermalDose.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // cmbStopCondition
            // 
            this.cmbStopCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStopCondition.FormattingEnabled = true;
            this.cmbStopCondition.Location = new System.Drawing.Point(6, 19);
            this.cmbStopCondition.Name = "cmbStopCondition";
            this.cmbStopCondition.Size = new System.Drawing.Size(243, 21);
            this.cmbStopCondition.TabIndex = 64;
            this.cmbStopCondition.SelectedIndexChanged += new System.EventHandler(this.cmbStopCondition_SelectedIndexChanged);
            // 
            // lblExpTime
            // 
            this.lblExpTime.AutoSize = true;
            this.lblExpTime.Location = new System.Drawing.Point(258, 1);
            this.lblExpTime.Name = "lblExpTime";
            this.lblExpTime.Size = new System.Drawing.Size(55, 13);
            this.lblExpTime.TabIndex = 82;
            this.lblExpTime.Text = "Time [min]";
            // 
            // nudExpTime
            // 
            this.nudExpTime.DecimalPlaces = 1;
            this.nudExpTime.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudExpTime.Location = new System.Drawing.Point(261, 20);
            this.nudExpTime.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudExpTime.Name = "nudExpTime";
            this.nudExpTime.Size = new System.Drawing.Size(100, 20);
            this.nudExpTime.TabIndex = 79;
            this.nudExpTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudExpTime.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // txtElapsedTime
            // 
            this.txtElapsedTime.Location = new System.Drawing.Point(398, 335);
            this.txtElapsedTime.Name = "txtElapsedTime";
            this.txtElapsedTime.ReadOnly = true;
            this.txtElapsedTime.Size = new System.Drawing.Size(106, 20);
            this.txtElapsedTime.TabIndex = 80;
            this.txtElapsedTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbSaveHeader
            // 
            this.cbSaveHeader.AutoSize = true;
            this.cbSaveHeader.Checked = true;
            this.cbSaveHeader.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSaveHeader.Location = new System.Drawing.Point(329, 126);
            this.cbSaveHeader.Name = "cbSaveHeader";
            this.cbSaveHeader.Size = new System.Drawing.Size(89, 17);
            this.cbSaveHeader.TabIndex = 86;
            this.cbSaveHeader.Text = "Save Header";
            this.ttSaveHeader.SetToolTip(this.cbSaveHeader, "Save the information about the experiment at the beginning of the file.");
            this.cbSaveHeader.UseVisualStyleBackColor = true;
            this.cbSaveHeader.CheckedChanged += new System.EventHandler(this.cbSaveHeader_CheckedChanged);
            // 
            // gbLaser
            // 
            this.gbLaser.Controls.Add(this.btnRemoveLaser);
            this.gbLaser.Controls.Add(this.btnStartLaser);
            this.gbLaser.Controls.Add(this.btnLoadLaser);
            this.gbLaser.Controls.Add(this.cmbLasers);
            this.gbLaser.Location = new System.Drawing.Point(6, 147);
            this.gbLaser.Name = "gbLaser";
            this.gbLaser.Size = new System.Drawing.Size(498, 42);
            this.gbLaser.TabIndex = 86;
            this.gbLaser.TabStop = false;
            this.gbLaser.Text = "Laser";
            // 
            // btnRemoveLaser
            // 
            this.btnRemoveLaser.Location = new System.Drawing.Point(342, 14);
            this.btnRemoveLaser.Name = "btnRemoveLaser";
            this.btnRemoveLaser.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveLaser.TabIndex = 64;
            this.btnRemoveLaser.Text = "Remove";
            this.btnRemoveLaser.UseVisualStyleBackColor = true;
            this.btnRemoveLaser.Click += new System.EventHandler(this.btnRemoveLaser_Click);
            // 
            // btnStartLaser
            // 
            this.btnStartLaser.Location = new System.Drawing.Point(423, 14);
            this.btnStartLaser.Name = "btnStartLaser";
            this.btnStartLaser.Size = new System.Drawing.Size(69, 23);
            this.btnStartLaser.TabIndex = 63;
            this.btnStartLaser.Text = "Start";
            this.btnStartLaser.UseVisualStyleBackColor = true;
            this.btnStartLaser.Click += new System.EventHandler(this.btnStartLaser_Click);
            // 
            // btnLoadLaser
            // 
            this.btnLoadLaser.Location = new System.Drawing.Point(261, 14);
            this.btnLoadLaser.Name = "btnLoadLaser";
            this.btnLoadLaser.Size = new System.Drawing.Size(75, 23);
            this.btnLoadLaser.TabIndex = 63;
            this.btnLoadLaser.Text = "Load";
            this.btnLoadLaser.UseVisualStyleBackColor = true;
            this.btnLoadLaser.Click += new System.EventHandler(this.btnLoadLaser_Click);
            // 
            // cmbLasers
            // 
            this.cmbLasers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLasers.FormattingEnabled = true;
            this.cmbLasers.Location = new System.Drawing.Point(6, 15);
            this.cmbLasers.Name = "cmbLasers";
            this.cmbLasers.Size = new System.Drawing.Size(243, 21);
            this.cmbLasers.TabIndex = 63;
            this.cmbLasers.SelectedIndexChanged += new System.EventHandler(this.cmbLasers_SelectedIndexChanged);
            // 
            // txtOperator
            // 
            this.txtOperator.Location = new System.Drawing.Point(72, 124);
            this.txtOperator.Name = "txtOperator";
            this.txtOperator.Size = new System.Drawing.Size(251, 20);
            this.txtOperator.TabIndex = 64;
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.Location = new System.Drawing.Point(6, 129);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(48, 13);
            this.lblOperator.TabIndex = 85;
            this.lblOperator.Text = "Operator";
            // 
            // cbSaveData
            // 
            this.cbSaveData.AutoSize = true;
            this.cbSaveData.Checked = true;
            this.cbSaveData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSaveData.Location = new System.Drawing.Point(427, 126);
            this.cbSaveData.Name = "cbSaveData";
            this.cbSaveData.Size = new System.Drawing.Size(77, 17);
            this.cbSaveData.TabIndex = 85;
            this.cbSaveData.Text = "Save Data";
            this.ttSaveHeader.SetToolTip(this.cbSaveData, "If not checked, nothing is saved.");
            this.cbSaveData.UseVisualStyleBackColor = true;
            this.cbSaveData.CheckedChanged += new System.EventHandler(this.cbSaveData_CheckedChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(72, 98);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(432, 20);
            this.txtDescription.TabIndex = 63;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(6, 101);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 84;
            this.lblDescription.Text = "Description";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(6, 49);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(54, 13);
            this.lblFileName.TabIndex = 84;
            this.lblFileName.Text = "File Name";
            // 
            // lblFileDir
            // 
            this.lblFileDir.AutoSize = true;
            this.lblFileDir.Location = new System.Drawing.Point(6, 75);
            this.lblFileDir.Name = "lblFileDir";
            this.lblFileDir.Size = new System.Drawing.Size(49, 13);
            this.lblFileDir.TabIndex = 83;
            this.lblFileDir.Text = "Directory";
            // 
            // cmbExperimentType
            // 
            this.cmbExperimentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExperimentType.FormattingEnabled = true;
            this.cmbExperimentType.Items.AddRange(new object[] {
            "No Laser, Only Record Temperature",
            "Full Power PTT",
            "PID Controlled PTT"});
            this.cmbExperimentType.Location = new System.Drawing.Point(6, 19);
            this.cmbExperimentType.Name = "cmbExperimentType";
            this.cmbExperimentType.Size = new System.Drawing.Size(498, 21);
            this.cmbExperimentType.TabIndex = 79;
            this.cmbExperimentType.SelectedIndexChanged += new System.EventHandler(this.cmbExperimentType_SelectedIndexChanged);
            // 
            // txtExperimentStarted
            // 
            this.txtExperimentStarted.BackColor = System.Drawing.Color.Red;
            this.txtExperimentStarted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExperimentStarted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtExperimentStarted.Location = new System.Drawing.Point(6, 361);
            this.txtExperimentStarted.Name = "txtExperimentStarted";
            this.txtExperimentStarted.ReadOnly = true;
            this.txtExperimentStarted.Size = new System.Drawing.Size(249, 20);
            this.txtExperimentStarted.TabIndex = 76;
            this.txtExperimentStarted.Text = "Experiment Not Started";
            this.txtExperimentStarted.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbPID
            // 
            this.gbPID.Controls.Add(this.lblTargetTemp);
            this.gbPID.Controls.Add(this.nudTargetTemp);
            this.gbPID.Controls.Add(this.nudDiffGain);
            this.gbPID.Controls.Add(this.lblPropGain);
            this.gbPID.Controls.Add(this.lblRelativePower);
            this.gbPID.Controls.Add(this.txtRelativePower);
            this.gbPID.Controls.Add(this.nudIntGain);
            this.gbPID.Controls.Add(this.lblDiffGain);
            this.gbPID.Controls.Add(this.lblIntGain);
            this.gbPID.Controls.Add(this.nudPropGain);
            this.gbPID.Location = new System.Drawing.Point(6, 191);
            this.gbPID.Name = "gbPID";
            this.gbPID.Size = new System.Drawing.Size(498, 90);
            this.gbPID.TabIndex = 73;
            this.gbPID.TabStop = false;
            this.gbPID.Text = "PID control";
            this.gbPID.Visible = false;
            // 
            // lblTargetTemp
            // 
            this.lblTargetTemp.AutoSize = true;
            this.lblTargetTemp.Location = new System.Drawing.Point(6, 41);
            this.lblTargetTemp.Name = "lblTargetTemp";
            this.lblTargetTemp.Size = new System.Drawing.Size(121, 13);
            this.lblTargetTemp.TabIndex = 84;
            this.lblTargetTemp.Text = "Target Temperature [°C]";
            // 
            // nudTargetTemp
            // 
            this.nudTargetTemp.DecimalPlaces = 1;
            this.nudTargetTemp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudTargetTemp.Location = new System.Drawing.Point(151, 39);
            this.nudTargetTemp.Name = "nudTargetTemp";
            this.nudTargetTemp.Size = new System.Drawing.Size(98, 20);
            this.nudTargetTemp.TabIndex = 83;
            this.nudTargetTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudTargetTemp.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // nudDiffGain
            // 
            this.nudDiffGain.Location = new System.Drawing.Point(392, 65);
            this.nudDiffGain.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDiffGain.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudDiffGain.Name = "nudDiffGain";
            this.nudDiffGain.Size = new System.Drawing.Size(100, 20);
            this.nudDiffGain.TabIndex = 26;
            this.nudDiffGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudDiffGain.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudDiffGain.ValueChanged += new System.EventHandler(this.nudDiffGain_ValueChanged);
            // 
            // lblPropGain
            // 
            this.lblPropGain.AutoSize = true;
            this.lblPropGain.Location = new System.Drawing.Point(259, 15);
            this.lblPropGain.Name = "lblPropGain";
            this.lblPropGain.Size = new System.Drawing.Size(88, 13);
            this.lblPropGain.TabIndex = 22;
            this.lblPropGain.Text = "Proportional Gain";
            // 
            // lblRelativePower
            // 
            this.lblRelativePower.AutoSize = true;
            this.lblRelativePower.Location = new System.Drawing.Point(6, 68);
            this.lblRelativePower.Name = "lblRelativePower";
            this.lblRelativePower.Size = new System.Drawing.Size(79, 13);
            this.lblRelativePower.TabIndex = 28;
            this.lblRelativePower.Text = "Relative Power";
            // 
            // txtRelativePower
            // 
            this.txtRelativePower.Location = new System.Drawing.Point(151, 64);
            this.txtRelativePower.Name = "txtRelativePower";
            this.txtRelativePower.ReadOnly = true;
            this.txtRelativePower.Size = new System.Drawing.Size(98, 20);
            this.txtRelativePower.TabIndex = 21;
            this.txtRelativePower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudIntGain
            // 
            this.nudIntGain.Location = new System.Drawing.Point(392, 39);
            this.nudIntGain.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudIntGain.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudIntGain.Name = "nudIntGain";
            this.nudIntGain.Size = new System.Drawing.Size(100, 20);
            this.nudIntGain.TabIndex = 24;
            this.nudIntGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudIntGain.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudIntGain.ValueChanged += new System.EventHandler(this.nudIntGain_ValueChanged);
            // 
            // lblDiffGain
            // 
            this.lblDiffGain.AutoSize = true;
            this.lblDiffGain.Location = new System.Drawing.Point(258, 67);
            this.lblDiffGain.Name = "lblDiffGain";
            this.lblDiffGain.Size = new System.Drawing.Size(82, 13);
            this.lblDiffGain.TabIndex = 27;
            this.lblDiffGain.Text = "Differential Gain";
            // 
            // lblIntGain
            // 
            this.lblIntGain.AutoSize = true;
            this.lblIntGain.Location = new System.Drawing.Point(259, 41);
            this.lblIntGain.Name = "lblIntGain";
            this.lblIntGain.Size = new System.Drawing.Size(67, 13);
            this.lblIntGain.TabIndex = 25;
            this.lblIntGain.Text = "Integral Gain";
            // 
            // nudPropGain
            // 
            this.nudPropGain.Location = new System.Drawing.Point(392, 13);
            this.nudPropGain.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPropGain.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudPropGain.Name = "nudPropGain";
            this.nudPropGain.Size = new System.Drawing.Size(100, 20);
            this.nudPropGain.TabIndex = 23;
            this.nudPropGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPropGain.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudPropGain.ValueChanged += new System.EventHandler(this.nudPropGain_ValueChanged);
            // 
            // btnStartExperiment
            // 
            this.btnStartExperiment.Location = new System.Drawing.Point(6, 333);
            this.btnStartExperiment.Name = "btnStartExperiment";
            this.btnStartExperiment.Size = new System.Drawing.Size(249, 23);
            this.btnStartExperiment.TabIndex = 77;
            this.btnStartExperiment.Text = "Start Experiment";
            this.btnStartExperiment.UseVisualStyleBackColor = true;
            this.btnStartExperiment.Click += new System.EventHandler(this.btnStartExperiment_Click);
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.AutoSize = true;
            this.lblElapsedTime.Location = new System.Drawing.Point(265, 338);
            this.lblElapsedTime.Name = "lblElapsedTime";
            this.lblElapsedTime.Size = new System.Drawing.Size(71, 13);
            this.lblElapsedTime.TabIndex = 81;
            this.lblElapsedTime.Text = "Elapsed Time";
            // 
            // lblCalibratedTemperature
            // 
            this.lblCalibratedTemperature.AutoSize = true;
            this.lblCalibratedTemperature.Location = new System.Drawing.Point(265, 77);
            this.lblCalibratedTemperature.Name = "lblCalibratedTemperature";
            this.lblCalibratedTemperature.Size = new System.Drawing.Size(137, 13);
            this.lblCalibratedTemperature.TabIndex = 83;
            this.lblCalibratedTemperature.Text = "Calibrated Temperature [°C]";
            // 
            // lblSensorTemp
            // 
            this.lblSensorTemp.AutoSize = true;
            this.lblSensorTemp.Location = new System.Drawing.Point(265, 51);
            this.lblSensorTemp.Name = "lblSensorTemp";
            this.lblSensorTemp.Size = new System.Drawing.Size(70, 13);
            this.lblSensorTemp.TabIndex = 82;
            this.lblSensorTemp.Text = "Sensor Value";
            // 
            // txtCalibratedTemp
            // 
            this.txtCalibratedTemp.Location = new System.Drawing.Point(404, 74);
            this.txtCalibratedTemp.Name = "txtCalibratedTemp";
            this.txtCalibratedTemp.ReadOnly = true;
            this.txtCalibratedTemp.Size = new System.Drawing.Size(100, 20);
            this.txtCalibratedTemp.TabIndex = 81;
            this.txtCalibratedTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSensorTemp
            // 
            this.txtSensorTemp.Location = new System.Drawing.Point(404, 48);
            this.txtSensorTemp.Name = "txtSensorTemp";
            this.txtSensorTemp.ReadOnly = true;
            this.txtSensorTemp.Size = new System.Drawing.Size(100, 20);
            this.txtSensorTemp.TabIndex = 80;
            this.txtSensorTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbSensor
            // 
            this.gbSensor.Controls.Add(this.btnRemoveSensor);
            this.gbSensor.Controls.Add(this.btnStartSensor);
            this.gbSensor.Controls.Add(this.btnLoadSensor);
            this.gbSensor.Controls.Add(this.cmbSensors);
            this.gbSensor.Location = new System.Drawing.Point(12, 23);
            this.gbSensor.Name = "gbSensor";
            this.gbSensor.Size = new System.Drawing.Size(510, 47);
            this.gbSensor.TabIndex = 60;
            this.gbSensor.TabStop = false;
            this.gbSensor.Text = "Sensor";
            // 
            // btnRemoveSensor
            // 
            this.btnRemoveSensor.Location = new System.Drawing.Point(348, 18);
            this.btnRemoveSensor.Name = "btnRemoveSensor";
            this.btnRemoveSensor.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveSensor.TabIndex = 63;
            this.btnRemoveSensor.Text = "Remove";
            this.btnRemoveSensor.UseVisualStyleBackColor = true;
            this.btnRemoveSensor.Click += new System.EventHandler(this.btnRemoveSensor_Click);
            // 
            // btnStartSensor
            // 
            this.btnStartSensor.Location = new System.Drawing.Point(429, 18);
            this.btnStartSensor.Name = "btnStartSensor";
            this.btnStartSensor.Size = new System.Drawing.Size(75, 23);
            this.btnStartSensor.TabIndex = 62;
            this.btnStartSensor.Text = "Start";
            this.btnStartSensor.UseVisualStyleBackColor = true;
            this.btnStartSensor.Click += new System.EventHandler(this.btnStartSensor_Click);
            // 
            // btnLoadSensor
            // 
            this.btnLoadSensor.Location = new System.Drawing.Point(267, 18);
            this.btnLoadSensor.Name = "btnLoadSensor";
            this.btnLoadSensor.Size = new System.Drawing.Size(75, 23);
            this.btnLoadSensor.TabIndex = 60;
            this.btnLoadSensor.Text = "Load";
            this.btnLoadSensor.UseVisualStyleBackColor = true;
            this.btnLoadSensor.Click += new System.EventHandler(this.btnLoadSensor_Click);
            // 
            // cmbSensors
            // 
            this.cmbSensors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSensors.FormattingEnabled = true;
            this.cmbSensors.Location = new System.Drawing.Point(6, 19);
            this.cmbSensors.Name = "cmbSensors";
            this.cmbSensors.Size = new System.Drawing.Size(249, 21);
            this.cmbSensors.TabIndex = 57;
            this.cmbSensors.SelectedIndexChanged += new System.EventHandler(this.cmbSensors_SelectedIndexChanged);
            // 
            // cbUseCalibration
            // 
            this.cbUseCalibration.AutoSize = true;
            this.cbUseCalibration.Checked = true;
            this.cbUseCalibration.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUseCalibration.Location = new System.Drawing.Point(107, 0);
            this.cbUseCalibration.Name = "cbUseCalibration";
            this.cbUseCalibration.Size = new System.Drawing.Size(97, 17);
            this.cbUseCalibration.TabIndex = 54;
            this.cbUseCalibration.Text = "Use Calibration";
            this.cbUseCalibration.UseVisualStyleBackColor = true;
            this.cbUseCalibration.CheckedChanged += new System.EventHandler(this.cbUseCalibration_CheckedChanged);
            // 
            // pltLaserCurrent
            // 
            this.pltLaserCurrent.Location = new System.Drawing.Point(0, 0);
            this.pltLaserCurrent.Name = "pltLaserCurrent";
            this.pltLaserCurrent.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.pltLaserCurrent.Size = new System.Drawing.Size(0, 0);
            this.pltLaserCurrent.TabIndex = 1;
            this.pltLaserCurrent.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.pltLaserCurrent.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pltLaserCurrent.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // pltAmbTemp
            // 
            this.pltAmbTemp.Location = new System.Drawing.Point(0, 0);
            this.pltAmbTemp.Name = "pltAmbTemp";
            this.pltAmbTemp.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.pltAmbTemp.Size = new System.Drawing.Size(0, 0);
            this.pltAmbTemp.TabIndex = 0;
            this.pltAmbTemp.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.pltAmbTemp.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pltAmbTemp.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appSettingsToolStripMenuItem,
            this.experimentSettingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(534, 24);
            this.menuMain.TabIndex = 51;
            this.menuMain.Text = "menuStrip1";
            // 
            // appSettingsToolStripMenuItem
            // 
            this.appSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCurrentConfig,
            this.saveConfigToolStripMenuItem,
            this.saveConfigAsToolStripMenuItem,
            this.loadConfigToolStripMenuItem,
            this.saveCurrentConfigWhenClosingToolStripMenuItem,
            this.loadSensorAndLaserPartsOnStartupToolStripMenuItem});
            this.appSettingsToolStripMenuItem.Name = "appSettingsToolStripMenuItem";
            this.appSettingsToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.appSettingsToolStripMenuItem.Text = "App Configuration";
            // 
            // toolStripCurrentConfig
            // 
            this.toolStripCurrentConfig.Name = "toolStripCurrentConfig";
            this.toolStripCurrentConfig.Size = new System.Drawing.Size(301, 22);
            // 
            // saveConfigToolStripMenuItem
            // 
            this.saveConfigToolStripMenuItem.Name = "saveConfigToolStripMenuItem";
            this.saveConfigToolStripMenuItem.Size = new System.Drawing.Size(301, 22);
            this.saveConfigToolStripMenuItem.Text = "Save Configuration";
            this.saveConfigToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveConfigAsToolStripMenuItem
            // 
            this.saveConfigAsToolStripMenuItem.Name = "saveConfigAsToolStripMenuItem";
            this.saveConfigAsToolStripMenuItem.Size = new System.Drawing.Size(301, 22);
            this.saveConfigAsToolStripMenuItem.Text = "Save Configuration As";
            this.saveConfigAsToolStripMenuItem.Click += new System.EventHandler(this.saveConfigAsToolStripMenuItem_Click);
            // 
            // loadConfigToolStripMenuItem
            // 
            this.loadConfigToolStripMenuItem.Name = "loadConfigToolStripMenuItem";
            this.loadConfigToolStripMenuItem.Size = new System.Drawing.Size(301, 22);
            this.loadConfigToolStripMenuItem.Text = "Load Configuration";
            this.loadConfigToolStripMenuItem.Click += new System.EventHandler(this.loadConfigToolStripMenuItem_Click);
            // 
            // saveCurrentConfigWhenClosingToolStripMenuItem
            // 
            this.saveCurrentConfigWhenClosingToolStripMenuItem.Checked = true;
            this.saveCurrentConfigWhenClosingToolStripMenuItem.CheckOnClick = true;
            this.saveCurrentConfigWhenClosingToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveCurrentConfigWhenClosingToolStripMenuItem.Name = "saveCurrentConfigWhenClosingToolStripMenuItem";
            this.saveCurrentConfigWhenClosingToolStripMenuItem.Size = new System.Drawing.Size(301, 22);
            this.saveCurrentConfigWhenClosingToolStripMenuItem.Text = "Save Current Configuration When Closing";
            // 
            // loadSensorAndLaserPartsOnStartupToolStripMenuItem
            // 
            this.loadSensorAndLaserPartsOnStartupToolStripMenuItem.Checked = true;
            this.loadSensorAndLaserPartsOnStartupToolStripMenuItem.CheckOnClick = true;
            this.loadSensorAndLaserPartsOnStartupToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.loadSensorAndLaserPartsOnStartupToolStripMenuItem.Name = "loadSensorAndLaserPartsOnStartupToolStripMenuItem";
            this.loadSensorAndLaserPartsOnStartupToolStripMenuItem.Size = new System.Drawing.Size(301, 22);
            this.loadSensorAndLaserPartsOnStartupToolStripMenuItem.Text = "Start Sensor and Laser Parts on App Startup";
            // 
            // experimentSettingsToolStripMenuItem
            // 
            this.experimentSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.discrettizationTimemsToolStripMenuItem,
            this.nudDiscretizationTimeToolStripMenuItem,
            this.createDirectoryWithCurrentDateToolStripMenuItem,
            this.createFileWithCurrentTimeToolStripMenuItem});
            this.experimentSettingsToolStripMenuItem.Name = "experimentSettingsToolStripMenuItem";
            this.experimentSettingsToolStripMenuItem.Size = new System.Drawing.Size(124, 20);
            this.experimentSettingsToolStripMenuItem.Text = "Experiment Settings";
            // 
            // discrettizationTimemsToolStripMenuItem
            // 
            this.discrettizationTimemsToolStripMenuItem.Name = "discrettizationTimemsToolStripMenuItem";
            this.discrettizationTimemsToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.discrettizationTimemsToolStripMenuItem.Text = "Discretization Time Interval (ms)";
            // 
            // createDirectoryWithCurrentDateToolStripMenuItem
            // 
            this.createDirectoryWithCurrentDateToolStripMenuItem.Checked = true;
            this.createDirectoryWithCurrentDateToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.createDirectoryWithCurrentDateToolStripMenuItem.Name = "createDirectoryWithCurrentDateToolStripMenuItem";
            this.createDirectoryWithCurrentDateToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.createDirectoryWithCurrentDateToolStripMenuItem.Text = "Create Directory with Current Date";
            // 
            // createFileWithCurrentTimeToolStripMenuItem
            // 
            this.createFileWithCurrentTimeToolStripMenuItem.Checked = true;
            this.createFileWithCurrentTimeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.createFileWithCurrentTimeToolStripMenuItem.Name = "createFileWithCurrentTimeToolStripMenuItem";
            this.createFileWithCurrentTimeToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.createFileWithCurrentTimeToolStripMenuItem.Text = "Create Experiment File with Current Time";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentationToolStripMenuItem,
            this.aboutControlledPTTToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.documentationToolStripMenuItem.Text = "Documentation";
            this.documentationToolStripMenuItem.Click += new System.EventHandler(this.documentationToolStripMenuItem_Click);
            // 
            // aboutControlledPTTToolStripMenuItem
            // 
            this.aboutControlledPTTToolStripMenuItem.Name = "aboutControlledPTTToolStripMenuItem";
            this.aboutControlledPTTToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.aboutControlledPTTToolStripMenuItem.Text = "About Controlled PTT 2";
            this.aboutControlledPTTToolStripMenuItem.Click += new System.EventHandler(this.aboutControlledPTTToolStripMenuItem_Click);
            // 
            // gbCalibration
            // 
            this.gbCalibration.Controls.Add(this.txtIntercept);
            this.gbCalibration.Controls.Add(this.txtSlope);
            this.gbCalibration.Controls.Add(this.lblIntercept);
            this.gbCalibration.Controls.Add(this.lblSlope);
            this.gbCalibration.Controls.Add(this.btnModifyCalibration);
            this.gbCalibration.Controls.Add(this.lblCalibratedTemperature);
            this.gbCalibration.Controls.Add(this.btnNewCalibration);
            this.gbCalibration.Controls.Add(this.lblSensorTemp);
            this.gbCalibration.Controls.Add(this.btnLoadCalibration);
            this.gbCalibration.Controls.Add(this.txtCalibratedTemp);
            this.gbCalibration.Controls.Add(this.txtSensorTemp);
            this.gbCalibration.Controls.Add(this.txtCalibration);
            this.gbCalibration.Controls.Add(this.cbUseCalibration);
            this.gbCalibration.Location = new System.Drawing.Point(12, 72);
            this.gbCalibration.Name = "gbCalibration";
            this.gbCalibration.Size = new System.Drawing.Size(510, 100);
            this.gbCalibration.TabIndex = 61;
            this.gbCalibration.TabStop = false;
            this.gbCalibration.Text = "Sensor Calibration";
            // 
            // txtIntercept
            // 
            this.txtIntercept.Location = new System.Drawing.Point(157, 74);
            this.txtIntercept.Name = "txtIntercept";
            this.txtIntercept.ReadOnly = true;
            this.txtIntercept.Size = new System.Drawing.Size(98, 20);
            this.txtIntercept.TabIndex = 87;
            this.txtIntercept.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSlope
            // 
            this.txtSlope.Location = new System.Drawing.Point(157, 48);
            this.txtSlope.Name = "txtSlope";
            this.txtSlope.ReadOnly = true;
            this.txtSlope.Size = new System.Drawing.Size(98, 20);
            this.txtSlope.TabIndex = 86;
            this.txtSlope.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblIntercept
            // 
            this.lblIntercept.AutoSize = true;
            this.lblIntercept.Location = new System.Drawing.Point(6, 77);
            this.lblIntercept.Name = "lblIntercept";
            this.lblIntercept.Size = new System.Drawing.Size(101, 13);
            this.lblIntercept.TabIndex = 85;
            this.lblIntercept.Text = "Calibration Intercept";
            // 
            // lblSlope
            // 
            this.lblSlope.AutoSize = true;
            this.lblSlope.Location = new System.Drawing.Point(6, 51);
            this.lblSlope.Name = "lblSlope";
            this.lblSlope.Size = new System.Drawing.Size(86, 13);
            this.lblSlope.TabIndex = 84;
            this.lblSlope.Text = "Calibration Slope";
            // 
            // btnModifyCalibration
            // 
            this.btnModifyCalibration.Location = new System.Drawing.Point(348, 19);
            this.btnModifyCalibration.Name = "btnModifyCalibration";
            this.btnModifyCalibration.Size = new System.Drawing.Size(75, 23);
            this.btnModifyCalibration.TabIndex = 64;
            this.btnModifyCalibration.Text = "Modify";
            this.btnModifyCalibration.UseVisualStyleBackColor = true;
            this.btnModifyCalibration.Click += new System.EventHandler(this.btnModifyCalibration_Click);
            // 
            // btnNewCalibration
            // 
            this.btnNewCalibration.Location = new System.Drawing.Point(429, 19);
            this.btnNewCalibration.Name = "btnNewCalibration";
            this.btnNewCalibration.Size = new System.Drawing.Size(75, 23);
            this.btnNewCalibration.TabIndex = 63;
            this.btnNewCalibration.Text = "New";
            this.btnNewCalibration.UseVisualStyleBackColor = true;
            this.btnNewCalibration.Click += new System.EventHandler(this.btnNewCalibration_Click);
            // 
            // btnLoadCalibration
            // 
            this.btnLoadCalibration.Location = new System.Drawing.Point(267, 19);
            this.btnLoadCalibration.Name = "btnLoadCalibration";
            this.btnLoadCalibration.Size = new System.Drawing.Size(75, 23);
            this.btnLoadCalibration.TabIndex = 62;
            this.btnLoadCalibration.Text = "Load";
            this.btnLoadCalibration.UseVisualStyleBackColor = true;
            this.btnLoadCalibration.Click += new System.EventHandler(this.btnLoadCalibration_Click);
            // 
            // txtCalibration
            // 
            this.txtCalibration.Location = new System.Drawing.Point(6, 21);
            this.txtCalibration.Name = "txtCalibration";
            this.txtCalibration.ReadOnly = true;
            this.txtCalibration.Size = new System.Drawing.Size(249, 20);
            this.txtCalibration.TabIndex = 0;
            // 
            // ofdSelectSensor
            // 
            this.ofdSelectSensor.DefaultExt = "exe";
            this.ofdSelectSensor.Filter = "Executables (*.exe)|*.exe";
            this.ofdSelectSensor.Title = "Select Sensor Executable";
            // 
            // sfdSaveConfigAs
            // 
            this.sfdSaveConfigAs.DefaultExt = "json";
            this.sfdSaveConfigAs.Filter = "JSON files (*.json)|*.json";
            this.sfdSaveConfigAs.Title = "Save Configuration As";
            // 
            // ofdSelectLaser
            // 
            this.ofdSelectLaser.DefaultExt = "exe";
            this.ofdSelectLaser.Filter = "Executables (*.exe)|*.exe";
            this.ofdSelectLaser.Title = "Select Laser Executable";
            // 
            // ofdLoadCalibration
            // 
            this.ofdLoadCalibration.DefaultExt = "exe";
            this.ofdLoadCalibration.Filter = "JSON files (*.json)|*json";
            this.ofdLoadCalibration.Title = "Select Laser Executable";
            // 
            // ofdLoadConfig
            // 
            this.ofdLoadConfig.DefaultExt = "json";
            this.ofdLoadConfig.Filter = "JSON files (*.json)|*json";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(410, 794);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 23);
            this.btnExit.TabIndex = 64;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // nudDiscretizationTimeToolStripMenuItem
            // 
            this.nudDiscretizationTimeToolStripMenuItem.Name = "nudDiscretizationTimeToolStripMenuItem";
            this.nudDiscretizationTimeToolStripMenuItem.Size = new System.Drawing.Size(41, 23);
            this.nudDiscretizationTimeToolStripMenuItem.Text = "100";
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 821);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.gbCalibration);
            this.Controls.Add(this.pltAmbTemp);
            this.Controls.Add(this.pltLaserCurrent);
            this.Controls.Add(this.gbExperiment);
            this.Controls.Add(this.pltTemperature);
            this.Controls.Add(this.menuMain);
            this.Controls.Add(this.gbSensor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMain;
            this.MinimumSize = new System.Drawing.Size(550, 860);
            this.Name = "App";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Controlled Photothermal Therapy 2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.App_FormClosing);
            this.Load += new System.EventHandler(this.App_Load);
            this.gbExperiment.ResumeLayout(false);
            this.gbExperiment.PerformLayout();
            this.gbStopCondition.ResumeLayout(false);
            this.gbStopCondition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThermalDose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudExpTime)).EndInit();
            this.gbLaser.ResumeLayout(false);
            this.gbPID.ResumeLayout(false);
            this.gbPID.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiffGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPropGain)).EndInit();
            this.gbSensor.ResumeLayout(false);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.gbCalibration.ResumeLayout(false);
            this.gbCalibration.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtExpDir;
        private System.Windows.Forms.Button btnSelectExpDir;
        private System.Windows.Forms.TextBox txtExpFileName;
        private OxyPlot.WindowsForms.PlotView pltTemperature;
        private System.Windows.Forms.GroupBox gbExperiment;
        private System.Windows.Forms.CheckBox cbUseCalibration;
        private System.Windows.Forms.ComboBox cmbSensors;
        private System.Windows.Forms.GroupBox gbSensor;
        private OxyPlot.WindowsForms.PlotView pltLaserCurrent;
        private OxyPlot.WindowsForms.PlotView pltAmbTemp;
        private System.Windows.Forms.GroupBox gbPID;
        private System.Windows.Forms.Label lblRelativePower;
        private System.Windows.Forms.TextBox txtRelativePower;
        private System.Windows.Forms.NumericUpDown nudDiffGain;
        private System.Windows.Forms.Label lblPropGain;
        private System.Windows.Forms.Label lblDiffGain;
        private System.Windows.Forms.NumericUpDown nudPropGain;
        private System.Windows.Forms.NumericUpDown nudIntGain;
        private System.Windows.Forms.Label lblIntGain;
        private System.Windows.Forms.Label lblExpTime;
        private System.Windows.Forms.NumericUpDown nudExpTime;
        private System.Windows.Forms.Label lblElapsedTime;
        private System.Windows.Forms.TextBox txtElapsedTime;
        private System.Windows.Forms.TextBox txtExperimentStarted;
        private System.Windows.Forms.Button btnStartExperiment;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem appSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveConfigAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentConfigWhenClosingToolStripMenuItem;
        private System.Windows.Forms.Button btnLoadSensor;
        private System.Windows.Forms.GroupBox gbCalibration;
        private System.Windows.Forms.TextBox txtCalibration;
        private System.Windows.Forms.Button btnNewCalibration;
        private System.Windows.Forms.Button btnLoadCalibration;
        private System.Windows.Forms.Button btnStartSensor;
        private System.Windows.Forms.OpenFileDialog ofdSelectSensor;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutControlledPTTToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbExperimentType;
        private System.Windows.Forms.TextBox txtCalibratedTemp;
        private System.Windows.Forms.TextBox txtSensorTemp;
        private System.Windows.Forms.Label lblCalibratedTemperature;
        private System.Windows.Forms.Label lblSensorTemp;
        private System.Windows.Forms.Label lblTargetTemp;
        private System.Windows.Forms.NumericUpDown nudTargetTemp;
        private System.Windows.Forms.Label lblFileDir;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.FolderBrowserDialog fbdSelectDir;
        private System.Windows.Forms.Button btnModifyCalibration;
        private System.Windows.Forms.SaveFileDialog sfdSaveConfigAs;
        private ToolStripNumberControl nudDiscretizationTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem experimentSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createDirectoryWithCurrentDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createFileWithCurrentTimeToolStripMenuItem;
        private System.Windows.Forms.TextBox txtIntercept;
        private System.Windows.Forms.TextBox txtSlope;
        private System.Windows.Forms.Label lblIntercept;
        private System.Windows.Forms.Label lblSlope;
        private System.Windows.Forms.CheckBox cbSaveData;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtOperator;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.GroupBox gbLaser;
        private System.Windows.Forms.Button btnStartLaser;
        private System.Windows.Forms.Button btnLoadLaser;
        private System.Windows.Forms.ComboBox cmbLasers;
        private System.Windows.Forms.CheckBox cbSaveHeader;
        private System.Windows.Forms.ToolTip ttSaveHeader;
        private System.Windows.Forms.OpenFileDialog ofdSelectLaser;
        private System.Windows.Forms.Button btnRemoveSensor;
        private System.Windows.Forms.Button btnRemoveLaser;
        private System.Windows.Forms.OpenFileDialog ofdLoadCalibration;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.TextBox txtGainedThermalDose;
        private System.Windows.Forms.Label lblGainedThermalDose;
        private System.Windows.Forms.GroupBox gbStopCondition;
        private System.Windows.Forms.ComboBox cmbStopCondition;
        private System.Windows.Forms.Label lblThermalDose;
        private System.Windows.Forms.NumericUpDown nudThermalDose;
        private System.Windows.Forms.OpenFileDialog ofdLoadConfig;
        private System.Windows.Forms.ToolStripMenuItem toolStripCurrentConfig;
        private System.Windows.Forms.ToolStripMenuItem loadSensorAndLaserPartsOnStartupToolStripMenuItem;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ToolStripMenuItem discrettizationTimemsToolStripMenuItem;
    }
}

