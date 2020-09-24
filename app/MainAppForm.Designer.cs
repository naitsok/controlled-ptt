namespace MainApp
{
    partial class MainAppForm
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
            this.txtExpDir = new System.Windows.Forms.TextBox();
            this.btnSelectDir = new System.Windows.Forms.Button();
            this.txtTempFileName = new System.Windows.Forms.TextBox();
            this.pltObjTemp = new OxyPlot.WindowsForms.PlotView();
            this.gbExperiment = new System.Windows.Forms.GroupBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblFileDir = new System.Windows.Forms.Label();
            this.cmbExperimentType = new System.Windows.Forms.ComboBox();
            this.lblExpTime = new System.Windows.Forms.Label();
            this.txtExperimentStarted = new System.Windows.Forms.TextBox();
            this.nudExpTime = new System.Windows.Forms.NumericUpDown();
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
            this.txtExpTime = new System.Windows.Forms.TextBox();
            this.lblCalibratedTemperature = new System.Windows.Forms.Label();
            this.lblSensorTemp = new System.Windows.Forms.Label();
            this.txtCalibratedTemp = new System.Windows.Forms.TextBox();
            this.txtSensorTemp = new System.Windows.Forms.TextBox();
            this.gbSensor = new System.Windows.Forms.GroupBox();
            this.btnStartSensor = new System.Windows.Forms.Button();
            this.btnLoadSensor = new System.Windows.Forms.Button();
            this.cmbSensors = new System.Windows.Forms.ComboBox();
            this.cbNoCalibration = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbInfo = new System.Windows.Forms.RichTextBox();
            this.pltLaserCurrent = new OxyPlot.WindowsForms.PlotView();
            this.pltAmbTemp = new OxyPlot.WindowsForms.PlotView();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.appSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurrentSettingsWhenClosingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectLogsDirectoryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.selectCalibrationsDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutControlledPTTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbCalibration = new System.Windows.Forms.GroupBox();
            this.btnViewCalibration = new System.Windows.Forms.Button();
            this.btnCalibrate = new System.Windows.Forms.Button();
            this.btnLoadCalibration = new System.Windows.Forms.Button();
            this.txtCalibration = new System.Windows.Forms.TextBox();
            this.ofdSelectSensor = new System.Windows.Forms.OpenFileDialog();
            this.fbdSelectDir = new System.Windows.Forms.FolderBrowserDialog();
            this.gbExperiment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExpTime)).BeginInit();
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
            this.txtExpDir.Location = new System.Drawing.Point(60, 46);
            this.txtExpDir.Name = "txtExpDir";
            this.txtExpDir.Size = new System.Drawing.Size(246, 20);
            this.txtExpDir.TabIndex = 16;
            // 
            // btnSelectDir
            // 
            this.btnSelectDir.Location = new System.Drawing.Point(312, 44);
            this.btnSelectDir.Name = "btnSelectDir";
            this.btnSelectDir.Size = new System.Drawing.Size(100, 23);
            this.btnSelectDir.TabIndex = 18;
            this.btnSelectDir.Text = "Select Directory";
            this.btnSelectDir.UseVisualStyleBackColor = true;
            this.btnSelectDir.Click += new System.EventHandler(this.BtnSelectTempPath_Click);
            // 
            // txtTempFileName
            // 
            this.txtTempFileName.Location = new System.Drawing.Point(60, 73);
            this.txtTempFileName.Name = "txtTempFileName";
            this.txtTempFileName.Size = new System.Drawing.Size(246, 20);
            this.txtTempFileName.TabIndex = 19;
            // 
            // pltObjTemp
            // 
            this.pltObjTemp.Location = new System.Drawing.Point(436, 27);
            this.pltObjTemp.Name = "pltObjTemp";
            this.pltObjTemp.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.pltObjTemp.Size = new System.Drawing.Size(433, 240);
            this.pltObjTemp.TabIndex = 43;
            this.pltObjTemp.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.pltObjTemp.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pltObjTemp.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // gbExperiment
            // 
            this.gbExperiment.Controls.Add(this.lblFileName);
            this.gbExperiment.Controls.Add(this.lblFileDir);
            this.gbExperiment.Controls.Add(this.txtTempFileName);
            this.gbExperiment.Controls.Add(this.btnSelectDir);
            this.gbExperiment.Controls.Add(this.cmbExperimentType);
            this.gbExperiment.Controls.Add(this.txtExpDir);
            this.gbExperiment.Controls.Add(this.lblExpTime);
            this.gbExperiment.Controls.Add(this.txtExperimentStarted);
            this.gbExperiment.Controls.Add(this.nudExpTime);
            this.gbExperiment.Controls.Add(this.gbPID);
            this.gbExperiment.Controls.Add(this.btnStartExperiment);
            this.gbExperiment.Controls.Add(this.lblElapsedTime);
            this.gbExperiment.Controls.Add(this.txtExpTime);
            this.gbExperiment.Location = new System.Drawing.Point(12, 190);
            this.gbExperiment.Name = "gbExperiment";
            this.gbExperiment.Size = new System.Drawing.Size(418, 249);
            this.gbExperiment.TabIndex = 47;
            this.gbExperiment.TabStop = false;
            this.gbExperiment.Text = "Experiment";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(6, 76);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(54, 13);
            this.lblFileName.TabIndex = 84;
            this.lblFileName.Text = "File Name";
            // 
            // lblFileDir
            // 
            this.lblFileDir.AutoSize = true;
            this.lblFileDir.Location = new System.Drawing.Point(6, 49);
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
            "Full Power PTT",
            "PID Controlled PTT"});
            this.cmbExperimentType.Location = new System.Drawing.Point(6, 19);
            this.cmbExperimentType.Name = "cmbExperimentType";
            this.cmbExperimentType.Size = new System.Drawing.Size(406, 21);
            this.cmbExperimentType.TabIndex = 79;
            this.cmbExperimentType.SelectedIndexChanged += new System.EventHandler(this.cmbExperimentType_SelectedIndexChanged);
            // 
            // lblExpTime
            // 
            this.lblExpTime.AutoSize = true;
            this.lblExpTime.Location = new System.Drawing.Point(8, 103);
            this.lblExpTime.Name = "lblExpTime";
            this.lblExpTime.Size = new System.Drawing.Size(52, 13);
            this.lblExpTime.TabIndex = 82;
            this.lblExpTime.Text = "Time, min";
            // 
            // txtExperimentStarted
            // 
            this.txtExperimentStarted.BackColor = System.Drawing.Color.Red;
            this.txtExperimentStarted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExperimentStarted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtExperimentStarted.Location = new System.Drawing.Point(221, 224);
            this.txtExperimentStarted.Name = "txtExperimentStarted";
            this.txtExperimentStarted.ReadOnly = true;
            this.txtExperimentStarted.Size = new System.Drawing.Size(191, 20);
            this.txtExperimentStarted.TabIndex = 76;
            this.txtExperimentStarted.Text = "Experiment Not Started";
            this.txtExperimentStarted.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudExpTime
            // 
            this.nudExpTime.Location = new System.Drawing.Point(106, 99);
            this.nudExpTime.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudExpTime.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudExpTime.Name = "nudExpTime";
            this.nudExpTime.Size = new System.Drawing.Size(94, 20);
            this.nudExpTime.TabIndex = 79;
            this.nudExpTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudExpTime.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
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
            this.gbPID.Location = new System.Drawing.Point(6, 125);
            this.gbPID.Name = "gbPID";
            this.gbPID.Size = new System.Drawing.Size(406, 90);
            this.gbPID.TabIndex = 73;
            this.gbPID.TabStop = false;
            this.gbPID.Text = "PID control";
            this.gbPID.Visible = false;
            // 
            // lblTargetTemp
            // 
            this.lblTargetTemp.AutoSize = true;
            this.lblTargetTemp.Location = new System.Drawing.Point(6, 35);
            this.lblTargetTemp.Name = "lblTargetTemp";
            this.lblTargetTemp.Size = new System.Drawing.Size(67, 26);
            this.lblTargetTemp.TabIndex = 84;
            this.lblTargetTemp.Text = "Target\nTemperature";
            // 
            // nudTargetTemp
            // 
            this.nudTargetTemp.Location = new System.Drawing.Point(100, 39);
            this.nudTargetTemp.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudTargetTemp.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudTargetTemp.Name = "nudTargetTemp";
            this.nudTargetTemp.Size = new System.Drawing.Size(94, 20);
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
            this.nudDiffGain.Location = new System.Drawing.Point(306, 65);
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
            this.nudDiffGain.Size = new System.Drawing.Size(94, 20);
            this.nudDiffGain.TabIndex = 26;
            this.nudDiffGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudDiffGain.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // lblPropGain
            // 
            this.lblPropGain.AutoSize = true;
            this.lblPropGain.Location = new System.Drawing.Point(212, 16);
            this.lblPropGain.Name = "lblPropGain";
            this.lblPropGain.Size = new System.Drawing.Size(88, 13);
            this.lblPropGain.TabIndex = 22;
            this.lblPropGain.Text = "Proportional Gain";
            // 
            // lblRelativePower
            // 
            this.lblRelativePower.AutoSize = true;
            this.lblRelativePower.Location = new System.Drawing.Point(6, 67);
            this.lblRelativePower.Name = "lblRelativePower";
            this.lblRelativePower.Size = new System.Drawing.Size(79, 13);
            this.lblRelativePower.TabIndex = 28;
            this.lblRelativePower.Text = "Relative Power";
            // 
            // txtRelativePower
            // 
            this.txtRelativePower.Location = new System.Drawing.Point(100, 64);
            this.txtRelativePower.Name = "txtRelativePower";
            this.txtRelativePower.ReadOnly = true;
            this.txtRelativePower.Size = new System.Drawing.Size(94, 20);
            this.txtRelativePower.TabIndex = 21;
            this.txtRelativePower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudIntGain
            // 
            this.nudIntGain.Location = new System.Drawing.Point(306, 39);
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
            this.nudIntGain.Size = new System.Drawing.Size(94, 20);
            this.nudIntGain.TabIndex = 24;
            this.nudIntGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudIntGain.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // lblDiffGain
            // 
            this.lblDiffGain.AutoSize = true;
            this.lblDiffGain.Location = new System.Drawing.Point(212, 67);
            this.lblDiffGain.Name = "lblDiffGain";
            this.lblDiffGain.Size = new System.Drawing.Size(82, 13);
            this.lblDiffGain.TabIndex = 27;
            this.lblDiffGain.Text = "Differential Gain";
            // 
            // lblIntGain
            // 
            this.lblIntGain.AutoSize = true;
            this.lblIntGain.Location = new System.Drawing.Point(212, 41);
            this.lblIntGain.Name = "lblIntGain";
            this.lblIntGain.Size = new System.Drawing.Size(67, 13);
            this.lblIntGain.TabIndex = 25;
            this.lblIntGain.Text = "Integral Gain";
            // 
            // nudPropGain
            // 
            this.nudPropGain.Location = new System.Drawing.Point(306, 13);
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
            this.nudPropGain.Size = new System.Drawing.Size(94, 20);
            this.nudPropGain.TabIndex = 23;
            this.nudPropGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPropGain.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // btnStartExperiment
            // 
            this.btnStartExperiment.Location = new System.Drawing.Point(6, 221);
            this.btnStartExperiment.Name = "btnStartExperiment";
            this.btnStartExperiment.Size = new System.Drawing.Size(194, 23);
            this.btnStartExperiment.TabIndex = 77;
            this.btnStartExperiment.Text = "Start Experiment";
            this.btnStartExperiment.UseVisualStyleBackColor = true;
            this.btnStartExperiment.Click += new System.EventHandler(this.BtnStartExperiment_Click);
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.AutoSize = true;
            this.lblElapsedTime.Location = new System.Drawing.Point(218, 102);
            this.lblElapsedTime.Name = "lblElapsedTime";
            this.lblElapsedTime.Size = new System.Drawing.Size(71, 13);
            this.lblElapsedTime.TabIndex = 81;
            this.lblElapsedTime.Text = "Elapsed Time";
            // 
            // txtExpTime
            // 
            this.txtExpTime.Location = new System.Drawing.Point(312, 99);
            this.txtExpTime.Name = "txtExpTime";
            this.txtExpTime.ReadOnly = true;
            this.txtExpTime.Size = new System.Drawing.Size(94, 20);
            this.txtExpTime.TabIndex = 80;
            this.txtExpTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExpTime.Visible = false;
            // 
            // lblCalibratedTemperature
            // 
            this.lblCalibratedTemperature.AutoSize = true;
            this.lblCalibratedTemperature.Location = new System.Drawing.Point(206, 72);
            this.lblCalibratedTemperature.Name = "lblCalibratedTemperature";
            this.lblCalibratedTemperature.Size = new System.Drawing.Size(67, 26);
            this.lblCalibratedTemperature.TabIndex = 83;
            this.lblCalibratedTemperature.Text = "Calibrated\nTemperature";
            // 
            // lblSensorTemp
            // 
            this.lblSensorTemp.AutoSize = true;
            this.lblSensorTemp.Location = new System.Drawing.Point(6, 72);
            this.lblSensorTemp.Name = "lblSensorTemp";
            this.lblSensorTemp.Size = new System.Drawing.Size(67, 26);
            this.lblSensorTemp.TabIndex = 82;
            this.lblSensorTemp.Text = "Sensor\nTemperature";
            // 
            // txtCalibratedTemp
            // 
            this.txtCalibratedTemp.Location = new System.Drawing.Point(312, 75);
            this.txtCalibratedTemp.Name = "txtCalibratedTemp";
            this.txtCalibratedTemp.ReadOnly = true;
            this.txtCalibratedTemp.Size = new System.Drawing.Size(100, 20);
            this.txtCalibratedTemp.TabIndex = 81;
            this.txtCalibratedTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSensorTemp
            // 
            this.txtSensorTemp.Location = new System.Drawing.Point(106, 75);
            this.txtSensorTemp.Name = "txtSensorTemp";
            this.txtSensorTemp.ReadOnly = true;
            this.txtSensorTemp.Size = new System.Drawing.Size(94, 20);
            this.txtSensorTemp.TabIndex = 80;
            this.txtSensorTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbSensor
            // 
            this.gbSensor.Controls.Add(this.btnStartSensor);
            this.gbSensor.Controls.Add(this.btnLoadSensor);
            this.gbSensor.Controls.Add(this.cmbSensors);
            this.gbSensor.Location = new System.Drawing.Point(12, 27);
            this.gbSensor.Name = "gbSensor";
            this.gbSensor.Size = new System.Drawing.Size(418, 47);
            this.gbSensor.TabIndex = 60;
            this.gbSensor.TabStop = false;
            this.gbSensor.Text = "Sensor Selection";
            // 
            // btnStartSensor
            // 
            this.btnStartSensor.Location = new System.Drawing.Point(312, 18);
            this.btnStartSensor.Name = "btnStartSensor";
            this.btnStartSensor.Size = new System.Drawing.Size(100, 23);
            this.btnStartSensor.TabIndex = 62;
            this.btnStartSensor.Text = "Start Sensor";
            this.btnStartSensor.UseVisualStyleBackColor = true;
            this.btnStartSensor.Click += new System.EventHandler(this.btnStartSensor_Click);
            // 
            // btnLoadSensor
            // 
            this.btnLoadSensor.Location = new System.Drawing.Point(206, 18);
            this.btnLoadSensor.Name = "btnLoadSensor";
            this.btnLoadSensor.Size = new System.Drawing.Size(100, 23);
            this.btnLoadSensor.TabIndex = 60;
            this.btnLoadSensor.Text = "Load from file";
            this.btnLoadSensor.UseVisualStyleBackColor = true;
            this.btnLoadSensor.Click += new System.EventHandler(this.btnLoadSensor_Click);
            // 
            // cmbSensors
            // 
            this.cmbSensors.FormattingEnabled = true;
            this.cmbSensors.Location = new System.Drawing.Point(6, 19);
            this.cmbSensors.Name = "cmbSensors";
            this.cmbSensors.Size = new System.Drawing.Size(194, 21);
            this.cmbSensors.TabIndex = 57;
            // 
            // cbNoCalibration
            // 
            this.cbNoCalibration.AutoSize = true;
            this.cbNoCalibration.Location = new System.Drawing.Point(6, 19);
            this.cbNoCalibration.Name = "cbNoCalibration";
            this.cbNoCalibration.Size = new System.Drawing.Size(129, 17);
            this.cbNoCalibration.TabIndex = 54;
            this.cbNoCalibration.Text = "Do not use calibration";
            this.cbNoCalibration.UseVisualStyleBackColor = true;
            this.cbNoCalibration.CheckedChanged += new System.EventHandler(this.cbNoCalibration_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 775);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Info";
            // 
            // rtbInfo
            // 
            this.rtbInfo.Location = new System.Drawing.Point(207, 791);
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.Size = new System.Drawing.Size(725, 65);
            this.rtbInfo.TabIndex = 48;
            this.rtbInfo.Text = "";
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
            this.helpToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(879, 24);
            this.menuMain.TabIndex = 51;
            this.menuMain.Text = "menuStrip1";
            // 
            // appSettingsToolStripMenuItem
            // 
            this.appSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveCurrentSettingsWhenClosingToolStripMenuItem,
            this.selectLogsDirectoryToolStripMenuItem1,
            this.selectCalibrationsDirectoryToolStripMenuItem});
            this.appSettingsToolStripMenuItem.Name = "appSettingsToolStripMenuItem";
            this.appSettingsToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.appSettingsToolStripMenuItem.Text = "App Settings";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.saveToolStripMenuItem.Text = "Save Settings";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.saveAsToolStripMenuItem.Text = "Save Settings As";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.loadToolStripMenuItem.Text = "Load Settings";
            // 
            // saveCurrentSettingsWhenClosingToolStripMenuItem
            // 
            this.saveCurrentSettingsWhenClosingToolStripMenuItem.Checked = true;
            this.saveCurrentSettingsWhenClosingToolStripMenuItem.CheckOnClick = true;
            this.saveCurrentSettingsWhenClosingToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveCurrentSettingsWhenClosingToolStripMenuItem.Name = "saveCurrentSettingsWhenClosingToolStripMenuItem";
            this.saveCurrentSettingsWhenClosingToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.saveCurrentSettingsWhenClosingToolStripMenuItem.Text = "Save current settings when closing";
            // 
            // selectLogsDirectoryToolStripMenuItem1
            // 
            this.selectLogsDirectoryToolStripMenuItem1.Name = "selectLogsDirectoryToolStripMenuItem1";
            this.selectLogsDirectoryToolStripMenuItem1.Size = new System.Drawing.Size(256, 22);
            this.selectLogsDirectoryToolStripMenuItem1.Text = "Select Logs Directory";
            // 
            // selectCalibrationsDirectoryToolStripMenuItem
            // 
            this.selectCalibrationsDirectoryToolStripMenuItem.Name = "selectCalibrationsDirectoryToolStripMenuItem";
            this.selectCalibrationsDirectoryToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.selectCalibrationsDirectoryToolStripMenuItem.Text = "Select Calibrations Directory";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutControlledPTTToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutControlledPTTToolStripMenuItem
            // 
            this.aboutControlledPTTToolStripMenuItem.Name = "aboutControlledPTTToolStripMenuItem";
            this.aboutControlledPTTToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.aboutControlledPTTToolStripMenuItem.Text = "About Controlled PTT";
            // 
            // gbCalibration
            // 
            this.gbCalibration.Controls.Add(this.btnViewCalibration);
            this.gbCalibration.Controls.Add(this.lblCalibratedTemperature);
            this.gbCalibration.Controls.Add(this.btnCalibrate);
            this.gbCalibration.Controls.Add(this.lblSensorTemp);
            this.gbCalibration.Controls.Add(this.btnLoadCalibration);
            this.gbCalibration.Controls.Add(this.txtCalibratedTemp);
            this.gbCalibration.Controls.Add(this.txtSensorTemp);
            this.gbCalibration.Controls.Add(this.txtCalibration);
            this.gbCalibration.Controls.Add(this.cbNoCalibration);
            this.gbCalibration.Location = new System.Drawing.Point(12, 80);
            this.gbCalibration.Name = "gbCalibration";
            this.gbCalibration.Size = new System.Drawing.Size(418, 104);
            this.gbCalibration.TabIndex = 61;
            this.gbCalibration.TabStop = false;
            this.gbCalibration.Text = "Sensor Calibration";
            // 
            // btnViewCalibration
            // 
            this.btnViewCalibration.Location = new System.Drawing.Point(312, 40);
            this.btnViewCalibration.Name = "btnViewCalibration";
            this.btnViewCalibration.Size = new System.Drawing.Size(47, 23);
            this.btnViewCalibration.TabIndex = 64;
            this.btnViewCalibration.Text = "View";
            this.btnViewCalibration.UseVisualStyleBackColor = true;
            this.btnViewCalibration.Click += new System.EventHandler(this.btnViewCalibration_Click);
            // 
            // btnCalibrate
            // 
            this.btnCalibrate.Location = new System.Drawing.Point(365, 40);
            this.btnCalibrate.Name = "btnCalibrate";
            this.btnCalibrate.Size = new System.Drawing.Size(47, 23);
            this.btnCalibrate.TabIndex = 63;
            this.btnCalibrate.Text = "New";
            this.btnCalibrate.UseVisualStyleBackColor = true;
            // 
            // btnLoadCalibration
            // 
            this.btnLoadCalibration.Location = new System.Drawing.Point(206, 40);
            this.btnLoadCalibration.Name = "btnLoadCalibration";
            this.btnLoadCalibration.Size = new System.Drawing.Size(100, 23);
            this.btnLoadCalibration.TabIndex = 62;
            this.btnLoadCalibration.Text = "Load from file";
            this.btnLoadCalibration.UseVisualStyleBackColor = true;
            // 
            // txtCalibration
            // 
            this.txtCalibration.Location = new System.Drawing.Point(6, 42);
            this.txtCalibration.Name = "txtCalibration";
            this.txtCalibration.Size = new System.Drawing.Size(194, 20);
            this.txtCalibration.TabIndex = 0;
            // 
            // ofdSelectSensor
            // 
            this.ofdSelectSensor.DefaultExt = "exe";
            this.ofdSelectSensor.Title = "Select Sensor Executable";
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 868);
            this.Controls.Add(this.gbCalibration);
            this.Controls.Add(this.pltAmbTemp);
            this.Controls.Add(this.pltLaserCurrent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtbInfo);
            this.Controls.Add(this.gbExperiment);
            this.Controls.Add(this.pltObjTemp);
            this.Controls.Add(this.menuMain);
            this.Controls.Add(this.gbSensor);
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainApp";
            this.Text = "Controlled Photothermal Therapy 2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainApp_FormClosing);
            this.gbExperiment.ResumeLayout(false);
            this.gbExperiment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExpTime)).EndInit();
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
        private System.Windows.Forms.Button btnSelectDir;
        private System.Windows.Forms.TextBox txtTempFileName;
        private OxyPlot.WindowsForms.PlotView pltObjTemp;
        private System.Windows.Forms.GroupBox gbExperiment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbInfo;
        private System.Windows.Forms.CheckBox cbNoCalibration;
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
        private System.Windows.Forms.TextBox txtExpTime;
        private System.Windows.Forms.TextBox txtExperimentStarted;
        private System.Windows.Forms.Button btnStartExperiment;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem appSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentSettingsWhenClosingToolStripMenuItem;
        private System.Windows.Forms.Button btnLoadSensor;
        private System.Windows.Forms.GroupBox gbCalibration;
        private System.Windows.Forms.TextBox txtCalibration;
        private System.Windows.Forms.Button btnCalibrate;
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
        private System.Windows.Forms.ToolStripMenuItem selectLogsDirectoryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem selectCalibrationsDirectoryToolStripMenuItem;
        private System.Windows.Forms.Button btnViewCalibration;
    }
}

