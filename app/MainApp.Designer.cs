namespace MainApp
{
    partial class MainApp
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tbTempFilePath = new System.Windows.Forms.TextBox();
            this.btnSelectTempPath = new System.Windows.Forms.Button();
            this.txtTempFileName = new System.Windows.Forms.TextBox();
            this.pltObjTemp = new OxyPlot.WindowsForms.PlotView();
            this.gbExperiment = new System.Windows.Forms.GroupBox();
            this.gbPID = new System.Windows.Forms.GroupBox();
            this.gmPIDParams = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCalcCurrent = new System.Windows.Forms.TextBox();
            this.nudDGain = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.nudPGain = new System.Windows.Forms.NumericUpDown();
            this.nudIGain = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.txtbPIDTime = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.gbTargetTemp = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cbUseCalObjTemp = new System.Windows.Forms.CheckBox();
            this.nudTargetT = new System.Windows.Forms.NumericUpDown();
            this.txtPIDStatus = new System.Windows.Forms.TextBox();
            this.bPIDStart = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.nudExpTime = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.txtExpTime = new System.Windows.Forms.TextBox();
            this.rbOnlySaveTemp = new System.Windows.Forms.RadioButton();
            this.txtExperimentStarted = new System.Windows.Forms.TextBox();
            this.btnStartExperiment = new System.Windows.Forms.Button();
            this.cbSaveData = new System.Windows.Forms.CheckBox();
            this.rbPIDControl = new System.Windows.Forms.RadioButton();
            this.rbNoPIDControl = new System.Windows.Forms.RadioButton();
            this.gbSensor = new System.Windows.Forms.GroupBox();
            this.btnStartSensor = new System.Windows.Forms.Button();
            this.btnLoadSensor = new System.Windows.Forms.Button();
            this.cmbSensors = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbNoCalibration = new System.Windows.Forms.CheckBox();
            this.btnCalibration = new System.Windows.Forms.Button();
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
            this.gbCalibration = new System.Windows.Forms.GroupBox();
            this.btnCalibrate = new System.Windows.Forms.Button();
            this.btnLoadCalibration = new System.Windows.Forms.Button();
            this.txtCalibration = new System.Windows.Forms.TextBox();
            this.selectSensorDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.gbExperiment.SuspendLayout();
            this.gbPID.SuspendLayout();
            this.gmPIDParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIGain)).BeginInit();
            this.gbTargetTemp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudExpTime)).BeginInit();
            this.gbSensor.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.gbCalibration.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.tbTempFilePath);
            this.groupBox1.Controls.Add(this.btnSelectTempPath);
            this.groupBox1.Controls.Add(this.txtTempFileName);
            this.groupBox1.Location = new System.Drawing.Point(148, 527);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 78);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save Temperature Data";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "File Name";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tbTempFilePath
            // 
            this.tbTempFilePath.Location = new System.Drawing.Point(127, 19);
            this.tbTempFilePath.Name = "tbTempFilePath";
            this.tbTempFilePath.Size = new System.Drawing.Size(352, 20);
            this.tbTempFilePath.TabIndex = 16;
            // 
            // btnSelectTempPath
            // 
            this.btnSelectTempPath.Location = new System.Drawing.Point(6, 17);
            this.btnSelectTempPath.Name = "btnSelectTempPath";
            this.btnSelectTempPath.Size = new System.Drawing.Size(115, 23);
            this.btnSelectTempPath.TabIndex = 18;
            this.btnSelectTempPath.Text = "Select Path";
            this.btnSelectTempPath.UseVisualStyleBackColor = true;
            this.btnSelectTempPath.Click += new System.EventHandler(this.BtnSelectTempPath_Click);
            // 
            // txtTempFileName
            // 
            this.txtTempFileName.Location = new System.Drawing.Point(127, 48);
            this.txtTempFileName.Name = "txtTempFileName";
            this.txtTempFileName.Size = new System.Drawing.Size(352, 20);
            this.txtTempFileName.TabIndex = 19;
            // 
            // pltObjTemp
            // 
            this.pltObjTemp.Location = new System.Drawing.Point(504, 12);
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
            this.gbExperiment.Controls.Add(this.gbPID);
            this.gbExperiment.Controls.Add(this.label26);
            this.gbExperiment.Controls.Add(this.nudExpTime);
            this.gbExperiment.Controls.Add(this.label25);
            this.gbExperiment.Controls.Add(this.txtExpTime);
            this.gbExperiment.Controls.Add(this.rbOnlySaveTemp);
            this.gbExperiment.Controls.Add(this.txtExperimentStarted);
            this.gbExperiment.Controls.Add(this.btnStartExperiment);
            this.gbExperiment.Controls.Add(this.cbSaveData);
            this.gbExperiment.Controls.Add(this.rbPIDControl);
            this.gbExperiment.Controls.Add(this.rbNoPIDControl);
            this.gbExperiment.Location = new System.Drawing.Point(148, 160);
            this.gbExperiment.Name = "gbExperiment";
            this.gbExperiment.Size = new System.Drawing.Size(486, 381);
            this.gbExperiment.TabIndex = 47;
            this.gbExperiment.TabStop = false;
            this.gbExperiment.Text = "Experiment";
            // 
            // gbPID
            // 
            this.gbPID.Controls.Add(this.gmPIDParams);
            this.gbPID.Controls.Add(this.txtbPIDTime);
            this.gbPID.Controls.Add(this.label31);
            this.gbPID.Controls.Add(this.gbTargetTemp);
            this.gbPID.Controls.Add(this.txtPIDStatus);
            this.gbPID.Controls.Add(this.bPIDStart);
            this.gbPID.Location = new System.Drawing.Point(12, 19);
            this.gbPID.Name = "gbPID";
            this.gbPID.Size = new System.Drawing.Size(474, 224);
            this.gbPID.TabIndex = 73;
            this.gbPID.TabStop = false;
            this.gbPID.Text = "PID control";
            this.gbPID.Visible = false;
            // 
            // gmPIDParams
            // 
            this.gmPIDParams.Controls.Add(this.label24);
            this.gmPIDParams.Controls.Add(this.label21);
            this.gmPIDParams.Controls.Add(this.txtCalcCurrent);
            this.gmPIDParams.Controls.Add(this.nudDGain);
            this.gmPIDParams.Controls.Add(this.label16);
            this.gmPIDParams.Controls.Add(this.label18);
            this.gmPIDParams.Controls.Add(this.nudPGain);
            this.gmPIDParams.Controls.Add(this.nudIGain);
            this.gmPIDParams.Controls.Add(this.label17);
            this.gmPIDParams.Location = new System.Drawing.Point(6, 111);
            this.gmPIDParams.Name = "gmPIDParams";
            this.gmPIDParams.Size = new System.Drawing.Size(462, 107);
            this.gmPIDParams.TabIndex = 29;
            this.gmPIDParams.TabStop = false;
            this.gmPIDParams.Text = "PID parameters";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(436, 79);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(14, 13);
            this.label24.TabIndex = 22;
            this.label24.Text = "A";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(237, 79);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(94, 13);
            this.label21.TabIndex = 28;
            this.label21.Text = "Calculated Current";
            // 
            // txtCalcCurrent
            // 
            this.txtCalcCurrent.Location = new System.Drawing.Point(335, 76);
            this.txtCalcCurrent.Name = "txtCalcCurrent";
            this.txtCalcCurrent.ReadOnly = true;
            this.txtCalcCurrent.Size = new System.Drawing.Size(101, 20);
            this.txtCalcCurrent.TabIndex = 21;
            this.txtCalcCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudDGain
            // 
            this.nudDGain.Location = new System.Drawing.Point(105, 75);
            this.nudDGain.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDGain.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudDGain.Name = "nudDGain";
            this.nudDGain.Size = new System.Drawing.Size(118, 20);
            this.nudDGain.TabIndex = 26;
            this.nudDGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudDGain.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 26);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 13);
            this.label16.TabIndex = 22;
            this.label16.Text = "Proportional Gain";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 79);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 13);
            this.label18.TabIndex = 27;
            this.label18.Text = "Differential Gain";
            // 
            // nudPGain
            // 
            this.nudPGain.Location = new System.Drawing.Point(105, 23);
            this.nudPGain.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPGain.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudPGain.Name = "nudPGain";
            this.nudPGain.Size = new System.Drawing.Size(118, 20);
            this.nudPGain.TabIndex = 23;
            this.nudPGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPGain.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // nudIGain
            // 
            this.nudIGain.Location = new System.Drawing.Point(105, 49);
            this.nudIGain.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudIGain.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudIGain.Name = "nudIGain";
            this.nudIGain.Size = new System.Drawing.Size(118, 20);
            this.nudIGain.TabIndex = 24;
            this.nudIGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudIGain.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 53);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 13);
            this.label17.TabIndex = 25;
            this.label17.Text = "Integral Gain";
            // 
            // txtbPIDTime
            // 
            this.txtbPIDTime.Location = new System.Drawing.Point(114, 84);
            this.txtbPIDTime.Name = "txtbPIDTime";
            this.txtbPIDTime.ReadOnly = true;
            this.txtbPIDTime.Size = new System.Drawing.Size(118, 20);
            this.txtbPIDTime.TabIndex = 24;
            this.txtbPIDTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(13, 87);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(73, 13);
            this.label31.TabIndex = 23;
            this.label31.Text = "Running Time";
            // 
            // gbTargetTemp
            // 
            this.gbTargetTemp.Controls.Add(this.label19);
            this.gbTargetTemp.Controls.Add(this.cbUseCalObjTemp);
            this.gbTargetTemp.Controls.Add(this.nudTargetT);
            this.gbTargetTemp.Location = new System.Drawing.Point(237, 23);
            this.gbTargetTemp.Name = "gbTargetTemp";
            this.gbTargetTemp.Size = new System.Drawing.Size(231, 82);
            this.gbTargetTemp.TabIndex = 28;
            this.gbTargetTemp.TabStop = false;
            this.gbTargetTemp.Text = "Target Temperature";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 48);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 13);
            this.label19.TabIndex = 29;
            this.label19.Text = "Temperature";
            // 
            // cbUseCalObjTemp
            // 
            this.cbUseCalObjTemp.AutoSize = true;
            this.cbUseCalObjTemp.Checked = true;
            this.cbUseCalObjTemp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUseCalObjTemp.Location = new System.Drawing.Point(6, 21);
            this.cbUseCalObjTemp.Name = "cbUseCalObjTemp";
            this.cbUseCalObjTemp.Size = new System.Drawing.Size(192, 17);
            this.cbUseCalObjTemp.TabIndex = 30;
            this.cbUseCalObjTemp.Text = "Use Calibrated Object Temperature";
            this.cbUseCalObjTemp.UseVisualStyleBackColor = true;
            // 
            // nudTargetT
            // 
            this.nudTargetT.DecimalPlaces = 1;
            this.nudTargetT.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudTargetT.Location = new System.Drawing.Point(107, 44);
            this.nudTargetT.Name = "nudTargetT";
            this.nudTargetT.Size = new System.Drawing.Size(118, 20);
            this.nudTargetT.TabIndex = 28;
            this.nudTargetT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPIDStatus
            // 
            this.txtPIDStatus.BackColor = System.Drawing.Color.Red;
            this.txtPIDStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPIDStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPIDStatus.Location = new System.Drawing.Point(13, 57);
            this.txtPIDStatus.Name = "txtPIDStatus";
            this.txtPIDStatus.ReadOnly = true;
            this.txtPIDStatus.Size = new System.Drawing.Size(219, 20);
            this.txtPIDStatus.TabIndex = 21;
            this.txtPIDStatus.Text = "PID Control Off";
            this.txtPIDStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bPIDStart
            // 
            this.bPIDStart.Location = new System.Drawing.Point(13, 23);
            this.bPIDStart.Name = "bPIDStart";
            this.bPIDStart.Size = new System.Drawing.Size(219, 28);
            this.bPIDStart.TabIndex = 0;
            this.bPIDStart.Text = "Start PID Control";
            this.bPIDStart.UseVisualStyleBackColor = true;
            this.bPIDStart.Click += new System.EventHandler(this.BtnPIDStart_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(317, 261);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(30, 13);
            this.label26.TabIndex = 82;
            this.label26.Text = "Time";
            // 
            // nudExpTime
            // 
            this.nudExpTime.Location = new System.Drawing.Point(353, 257);
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
            this.nudExpTime.Size = new System.Drawing.Size(98, 20);
            this.nudExpTime.TabIndex = 79;
            this.nudExpTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudExpTime.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(457, 261);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(24, 13);
            this.label25.TabIndex = 81;
            this.label25.Text = "Min";
            // 
            // txtExpTime
            // 
            this.txtExpTime.Location = new System.Drawing.Point(353, 257);
            this.txtExpTime.Name = "txtExpTime";
            this.txtExpTime.ReadOnly = true;
            this.txtExpTime.Size = new System.Drawing.Size(98, 20);
            this.txtExpTime.TabIndex = 80;
            this.txtExpTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExpTime.Visible = false;
            // 
            // rbOnlySaveTemp
            // 
            this.rbOnlySaveTemp.AutoSize = true;
            this.rbOnlySaveTemp.Checked = true;
            this.rbOnlySaveTemp.Location = new System.Drawing.Point(136, 252);
            this.rbOnlySaveTemp.Name = "rbOnlySaveTemp";
            this.rbOnlySaveTemp.Size = new System.Drawing.Size(137, 17);
            this.rbOnlySaveTemp.TabIndex = 78;
            this.rbOnlySaveTemp.TabStop = true;
            this.rbOnlySaveTemp.Text = "Only Save Temperature";
            this.rbOnlySaveTemp.UseVisualStyleBackColor = true;
            // 
            // txtExperimentStarted
            // 
            this.txtExperimentStarted.BackColor = System.Drawing.Color.Red;
            this.txtExperimentStarted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExperimentStarted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtExperimentStarted.Location = new System.Drawing.Point(255, 355);
            this.txtExperimentStarted.Name = "txtExperimentStarted";
            this.txtExperimentStarted.ReadOnly = true;
            this.txtExperimentStarted.Size = new System.Drawing.Size(219, 20);
            this.txtExperimentStarted.TabIndex = 76;
            this.txtExperimentStarted.Text = "Experiment Not Started";
            this.txtExperimentStarted.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnStartExperiment
            // 
            this.btnStartExperiment.Location = new System.Drawing.Point(255, 322);
            this.btnStartExperiment.Name = "btnStartExperiment";
            this.btnStartExperiment.Size = new System.Drawing.Size(219, 28);
            this.btnStartExperiment.TabIndex = 77;
            this.btnStartExperiment.Text = "Start Experiment";
            this.btnStartExperiment.UseVisualStyleBackColor = true;
            this.btnStartExperiment.Click += new System.EventHandler(this.BtnStartExperiment_Click);
            // 
            // cbSaveData
            // 
            this.cbSaveData.AutoSize = true;
            this.cbSaveData.Checked = true;
            this.cbSaveData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSaveData.Location = new System.Drawing.Point(313, 283);
            this.cbSaveData.Name = "cbSaveData";
            this.cbSaveData.Size = new System.Drawing.Size(108, 17);
            this.cbSaveData.TabIndex = 73;
            this.cbSaveData.Text = "Save Data to File";
            this.cbSaveData.UseVisualStyleBackColor = true;
            // 
            // rbPIDControl
            // 
            this.rbPIDControl.AutoSize = true;
            this.rbPIDControl.Location = new System.Drawing.Point(24, 281);
            this.rbPIDControl.Name = "rbPIDControl";
            this.rbPIDControl.Size = new System.Drawing.Size(79, 17);
            this.rbPIDControl.TabIndex = 75;
            this.rbPIDControl.Text = "PID Control";
            this.rbPIDControl.UseVisualStyleBackColor = true;
            this.rbPIDControl.CheckedChanged += new System.EventHandler(this.RbPIDControl_CheckedChanged);
            // 
            // rbNoPIDControl
            // 
            this.rbNoPIDControl.AutoSize = true;
            this.rbNoPIDControl.Location = new System.Drawing.Point(24, 252);
            this.rbNoPIDControl.Name = "rbNoPIDControl";
            this.rbNoPIDControl.Size = new System.Drawing.Size(96, 17);
            this.rbNoPIDControl.TabIndex = 74;
            this.rbNoPIDControl.Text = "Simple Heating";
            this.rbNoPIDControl.UseVisualStyleBackColor = true;
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
            this.btnStartSensor.Location = new System.Drawing.Point(206, 18);
            this.btnStartSensor.Name = "btnStartSensor";
            this.btnStartSensor.Size = new System.Drawing.Size(100, 23);
            this.btnStartSensor.TabIndex = 62;
            this.btnStartSensor.Text = "Start Sensor";
            this.btnStartSensor.UseVisualStyleBackColor = true;
            this.btnStartSensor.Click += new System.EventHandler(this.btnStartSensor_Click);
            // 
            // btnLoadSensor
            // 
            this.btnLoadSensor.Location = new System.Drawing.Point(312, 18);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(690, 384);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Select Sensor:";
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
            // 
            // btnCalibration
            // 
            this.btnCalibration.Location = new System.Drawing.Point(666, 508);
            this.btnCalibration.Name = "btnCalibration";
            this.btnCalibration.Size = new System.Drawing.Size(219, 30);
            this.btnCalibration.TabIndex = 51;
            this.btnCalibration.Text = "Calibration";
            this.btnCalibration.UseVisualStyleBackColor = true;
            this.btnCalibration.Click += new System.EventHandler(this.BtnCalibration_Click);
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
            this.appSettingsToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(945, 24);
            this.menuMain.TabIndex = 51;
            this.menuMain.Text = "menuStrip1";
            // 
            // appSettingsToolStripMenuItem
            // 
            this.appSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveCurrentSettingsWhenClosingToolStripMenuItem});
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
            // gbCalibration
            // 
            this.gbCalibration.Controls.Add(this.btnCalibrate);
            this.gbCalibration.Controls.Add(this.btnLoadCalibration);
            this.gbCalibration.Controls.Add(this.txtCalibration);
            this.gbCalibration.Controls.Add(this.cbNoCalibration);
            this.gbCalibration.Location = new System.Drawing.Point(12, 80);
            this.gbCalibration.Name = "gbCalibration";
            this.gbCalibration.Size = new System.Drawing.Size(418, 74);
            this.gbCalibration.TabIndex = 61;
            this.gbCalibration.TabStop = false;
            this.gbCalibration.Text = "Sensor Calibration";
            // 
            // btnCalibrate
            // 
            this.btnCalibrate.Location = new System.Drawing.Point(312, 40);
            this.btnCalibrate.Name = "btnCalibrate";
            this.btnCalibrate.Size = new System.Drawing.Size(100, 23);
            this.btnCalibrate.TabIndex = 63;
            this.btnCalibrate.Text = "New Calibration";
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
            // selectSensorDialog
            // 
            this.selectSensorDialog.DefaultExt = "exe";
            this.selectSensorDialog.Title = "Select Sensor Executable";
            this.selectSensorDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.selectSensorDialog_FileOk);
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 868);
            this.Controls.Add(this.gbCalibration);
            this.Controls.Add(this.pltAmbTemp);
            this.Controls.Add(this.pltLaserCurrent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCalibration);
            this.Controls.Add(this.rtbInfo);
            this.Controls.Add(this.gbExperiment);
            this.Controls.Add(this.pltObjTemp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuMain);
            this.Controls.Add(this.gbSensor);
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainApp";
            this.Text = "Controlled Photothermal Therapy 2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainApp_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbExperiment.ResumeLayout(false);
            this.gbExperiment.PerformLayout();
            this.gbPID.ResumeLayout(false);
            this.gbPID.PerformLayout();
            this.gmPIDParams.ResumeLayout(false);
            this.gmPIDParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIGain)).EndInit();
            this.gbTargetTemp.ResumeLayout(false);
            this.gbTargetTemp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudExpTime)).EndInit();
            this.gbSensor.ResumeLayout(false);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.gbCalibration.ResumeLayout(false);
            this.gbCalibration.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbTempFilePath;
        private System.Windows.Forms.Button btnSelectTempPath;
        private System.Windows.Forms.TextBox txtTempFileName;
        private OxyPlot.WindowsForms.PlotView pltObjTemp;
        private System.Windows.Forms.GroupBox gbExperiment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbInfo;
        private System.Windows.Forms.CheckBox cbNoCalibration;
        private System.Windows.Forms.Button btnCalibration;
        private System.Windows.Forms.ComboBox cmbSensors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbSensor;
        private OxyPlot.WindowsForms.PlotView pltLaserCurrent;
        private OxyPlot.WindowsForms.PlotView pltAmbTemp;
        private System.Windows.Forms.GroupBox gbPID;
        private System.Windows.Forms.GroupBox gmPIDParams;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtCalcCurrent;
        private System.Windows.Forms.NumericUpDown nudDGain;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown nudPGain;
        private System.Windows.Forms.NumericUpDown nudIGain;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtbPIDTime;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.GroupBox gbTargetTemp;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox cbUseCalObjTemp;
        private System.Windows.Forms.NumericUpDown nudTargetT;
        private System.Windows.Forms.TextBox txtPIDStatus;
        private System.Windows.Forms.Button bPIDStart;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.NumericUpDown nudExpTime;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtExpTime;
        private System.Windows.Forms.RadioButton rbOnlySaveTemp;
        private System.Windows.Forms.TextBox txtExperimentStarted;
        private System.Windows.Forms.Button btnStartExperiment;
        private System.Windows.Forms.CheckBox cbSaveData;
        private System.Windows.Forms.RadioButton rbPIDControl;
        private System.Windows.Forms.RadioButton rbNoPIDControl;
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
        private System.Windows.Forms.OpenFileDialog selectSensorDialog;
    }
}

