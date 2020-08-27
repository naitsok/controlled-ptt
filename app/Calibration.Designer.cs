namespace MainApp
{
    partial class CalibrationForm
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
            this.gbCalibration = new System.Windows.Forms.GroupBox();
            this.gbAmbientTemp = new System.Windows.Forms.GroupBox();
            this.cbNoAmbCalibration = new System.Windows.Forms.CheckBox();
            this.label29 = new System.Windows.Forms.Label();
            this.nudRealAmbTemp = new System.Windows.Forms.NumericUpDown();
            this.label28 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.rtbAmbTemp = new System.Windows.Forms.TextBox();
            this.rtbCalAmbTemp = new System.Windows.Forms.TextBox();
            this.gbObjectTemp = new System.Windows.Forms.GroupBox();
            this.nudSensorCalB = new System.Windows.Forms.NumericUpDown();
            this.label32 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.cbNoObjCalibration = new System.Windows.Forms.CheckBox();
            this.label27 = new System.Windows.Forms.Label();
            this.rtbCalObjTemp = new System.Windows.Forms.TextBox();
            this.nudSensorCalA = new System.Windows.Forms.NumericUpDown();
            this.rtbObjTemp = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgCalibration = new System.Windows.Forms.DataGridView();
            this.TempSensor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RealTemp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.pltCalibration = new OxyPlot.WindowsForms.PlotView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbCalibration.SuspendLayout();
            this.gbAmbientTemp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRealAmbTemp)).BeginInit();
            this.gbObjectTemp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSensorCalB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSensorCalA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCalibration)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCalibration
            // 
            this.gbCalibration.Controls.Add(this.gbAmbientTemp);
            this.gbCalibration.Controls.Add(this.gbObjectTemp);
            this.gbCalibration.Location = new System.Drawing.Point(12, 12);
            this.gbCalibration.Name = "gbCalibration";
            this.gbCalibration.Size = new System.Drawing.Size(232, 268);
            this.gbCalibration.TabIndex = 35;
            this.gbCalibration.TabStop = false;
            this.gbCalibration.Text = "Temperature Calibration";
            // 
            // gbAmbientTemp
            // 
            this.gbAmbientTemp.Controls.Add(this.cbNoAmbCalibration);
            this.gbAmbientTemp.Controls.Add(this.label29);
            this.gbAmbientTemp.Controls.Add(this.nudRealAmbTemp);
            this.gbAmbientTemp.Controls.Add(this.label28);
            this.gbAmbientTemp.Controls.Add(this.label20);
            this.gbAmbientTemp.Controls.Add(this.rtbAmbTemp);
            this.gbAmbientTemp.Controls.Add(this.rtbCalAmbTemp);
            this.gbAmbientTemp.Location = new System.Drawing.Point(6, 19);
            this.gbAmbientTemp.Name = "gbAmbientTemp";
            this.gbAmbientTemp.Size = new System.Drawing.Size(215, 118);
            this.gbAmbientTemp.TabIndex = 29;
            this.gbAmbientTemp.TabStop = false;
            this.gbAmbientTemp.Text = "Ambient Temperature";
            // 
            // cbNoAmbCalibration
            // 
            this.cbNoAmbCalibration.AutoSize = true;
            this.cbNoAmbCalibration.Checked = true;
            this.cbNoAmbCalibration.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNoAmbCalibration.Location = new System.Drawing.Point(6, 19);
            this.cbNoAmbCalibration.Name = "cbNoAmbCalibration";
            this.cbNoAmbCalibration.Size = new System.Drawing.Size(92, 17);
            this.cbNoAmbCalibration.TabIndex = 32;
            this.cbNoAmbCalibration.Text = "No Calibration";
            this.cbNoAmbCalibration.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(6, 95);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(54, 13);
            this.label29.TabIndex = 31;
            this.label29.Text = "Calibrated";
            // 
            // nudRealAmbTemp
            // 
            this.nudRealAmbTemp.DecimalPlaces = 6;
            this.nudRealAmbTemp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudRealAmbTemp.Location = new System.Drawing.Point(73, 66);
            this.nudRealAmbTemp.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudRealAmbTemp.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudRealAmbTemp.Name = "nudRealAmbTemp";
            this.nudRealAmbTemp.Size = new System.Drawing.Size(136, 20);
            this.nudRealAmbTemp.TabIndex = 31;
            this.nudRealAmbTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(6, 66);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(29, 13);
            this.label28.TabIndex = 31;
            this.label28.Text = "Real";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 42);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(40, 13);
            this.label20.TabIndex = 31;
            this.label20.Text = "Sensor";
            // 
            // rtbAmbTemp
            // 
            this.rtbAmbTemp.Location = new System.Drawing.Point(73, 39);
            this.rtbAmbTemp.Name = "rtbAmbTemp";
            this.rtbAmbTemp.ReadOnly = true;
            this.rtbAmbTemp.Size = new System.Drawing.Size(136, 20);
            this.rtbAmbTemp.TabIndex = 21;
            this.rtbAmbTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rtbCalAmbTemp
            // 
            this.rtbCalAmbTemp.Location = new System.Drawing.Point(73, 92);
            this.rtbCalAmbTemp.Name = "rtbCalAmbTemp";
            this.rtbCalAmbTemp.ReadOnly = true;
            this.rtbCalAmbTemp.Size = new System.Drawing.Size(136, 20);
            this.rtbCalAmbTemp.TabIndex = 26;
            this.rtbCalAmbTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbObjectTemp
            // 
            this.gbObjectTemp.Controls.Add(this.nudSensorCalB);
            this.gbObjectTemp.Controls.Add(this.label32);
            this.gbObjectTemp.Controls.Add(this.label23);
            this.gbObjectTemp.Controls.Add(this.cbNoObjCalibration);
            this.gbObjectTemp.Controls.Add(this.label27);
            this.gbObjectTemp.Controls.Add(this.rtbCalObjTemp);
            this.gbObjectTemp.Controls.Add(this.nudSensorCalA);
            this.gbObjectTemp.Controls.Add(this.rtbObjTemp);
            this.gbObjectTemp.Controls.Add(this.label22);
            this.gbObjectTemp.Location = new System.Drawing.Point(6, 143);
            this.gbObjectTemp.Name = "gbObjectTemp";
            this.gbObjectTemp.Size = new System.Drawing.Size(215, 118);
            this.gbObjectTemp.TabIndex = 28;
            this.gbObjectTemp.TabStop = false;
            this.gbObjectTemp.Text = "Object Temperature";
            // 
            // nudSensorCalB
            // 
            this.nudSensorCalB.DecimalPlaces = 2;
            this.nudSensorCalB.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudSensorCalB.Location = new System.Drawing.Point(144, 67);
            this.nudSensorCalB.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudSensorCalB.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudSensorCalB.Name = "nudSensorCalB";
            this.nudSensorCalB.Size = new System.Drawing.Size(64, 20);
            this.nudSensorCalB.TabIndex = 36;
            this.nudSensorCalB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudSensorCalB.ValueChanged += new System.EventHandler(this.NudSensorCalB_ValueChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(108, 70);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(33, 13);
            this.label32.TabIndex = 35;
            this.label32.Text = "* X + ";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(10, 69);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(26, 13);
            this.label23.TabIndex = 34;
            this.label23.Text = "Y = ";
            // 
            // cbNoObjCalibration
            // 
            this.cbNoObjCalibration.AutoSize = true;
            this.cbNoObjCalibration.Location = new System.Drawing.Point(7, 19);
            this.cbNoObjCalibration.Name = "cbNoObjCalibration";
            this.cbNoObjCalibration.Size = new System.Drawing.Size(92, 17);
            this.cbNoObjCalibration.TabIndex = 33;
            this.cbNoObjCalibration.Text = "No Calibration";
            this.cbNoObjCalibration.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(10, 95);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(54, 13);
            this.label27.TabIndex = 30;
            this.label27.Text = "Calibrated";
            // 
            // rtbCalObjTemp
            // 
            this.rtbCalObjTemp.Location = new System.Drawing.Point(73, 92);
            this.rtbCalObjTemp.Name = "rtbCalObjTemp";
            this.rtbCalObjTemp.ReadOnly = true;
            this.rtbCalObjTemp.Size = new System.Drawing.Size(136, 20);
            this.rtbCalObjTemp.TabIndex = 25;
            this.rtbCalObjTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudSensorCalA
            // 
            this.nudSensorCalA.DecimalPlaces = 2;
            this.nudSensorCalA.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudSensorCalA.Location = new System.Drawing.Point(39, 66);
            this.nudSensorCalA.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudSensorCalA.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudSensorCalA.Name = "nudSensorCalA";
            this.nudSensorCalA.Size = new System.Drawing.Size(64, 20);
            this.nudSensorCalA.TabIndex = 20;
            this.nudSensorCalA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudSensorCalA.ValueChanged += new System.EventHandler(this.NudSensorCalA_ValueChanged);
            // 
            // rtbObjTemp
            // 
            this.rtbObjTemp.Location = new System.Drawing.Point(73, 39);
            this.rtbObjTemp.Name = "rtbObjTemp";
            this.rtbObjTemp.ReadOnly = true;
            this.rtbObjTemp.Size = new System.Drawing.Size(136, 20);
            this.rtbObjTemp.TabIndex = 20;
            this.rtbObjTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(10, 42);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(40, 13);
            this.label22.TabIndex = 28;
            this.label22.Text = "Sensor";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(73, 287);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 31);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "Save as";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(192, 287);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(52, 31);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // dgCalibration
            // 
            this.dgCalibration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCalibration.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TempSensor,
            this.RealTemp});
            this.dgCalibration.Location = new System.Drawing.Point(261, 21);
            this.dgCalibration.MultiSelect = false;
            this.dgCalibration.Name = "dgCalibration";
            this.dgCalibration.Size = new System.Drawing.Size(344, 259);
            this.dgCalibration.TabIndex = 38;
            this.dgCalibration.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgCalibration_CellEnter);
            // 
            // TempSensor
            // 
            this.TempSensor.Frozen = true;
            this.TempSensor.HeaderText = "Temperature from sensor";
            this.TempSensor.Name = "TempSensor";
            this.TempSensor.ReadOnly = true;
            this.TempSensor.Width = 150;
            // 
            // RealTemp
            // 
            this.RealTemp.HeaderText = "Real temperature";
            this.RealTemp.Name = "RealTemp";
            this.RealTemp.Width = 150;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(261, 287);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(140, 31);
            this.btnCalculate.TabIndex = 39;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.BtnCalculate_Click);
            // 
            // pltCalibration
            // 
            this.pltCalibration.Location = new System.Drawing.Point(611, 12);
            this.pltCalibration.Name = "pltCalibration";
            this.pltCalibration.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.pltCalibration.Size = new System.Drawing.Size(534, 305);
            this.pltCalibration.TabIndex = 44;
            this.pltCalibration.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.pltCalibration.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pltCalibration.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(134, 287);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(52, 31);
            this.btnLoad.TabIndex = 45;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 287);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(55, 31);
            this.btnOK.TabIndex = 46;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // CalibrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 330);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.pltCalibration);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.dgCalibration);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbCalibration);
            this.MaximumSize = new System.Drawing.Size(1173, 369);
            this.MinimumSize = new System.Drawing.Size(1173, 369);
            this.Name = "CalibrationForm";
            this.Text = "Calibration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Calibration_FormClosing);
            this.Load += new System.EventHandler(this.Calibration_Load);
            this.gbCalibration.ResumeLayout(false);
            this.gbAmbientTemp.ResumeLayout(false);
            this.gbAmbientTemp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRealAmbTemp)).EndInit();
            this.gbObjectTemp.ResumeLayout(false);
            this.gbObjectTemp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSensorCalB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSensorCalA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCalibration)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCalibration;
        private System.Windows.Forms.GroupBox gbAmbientTemp;
        private System.Windows.Forms.CheckBox cbNoAmbCalibration;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.NumericUpDown nudRealAmbTemp;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox rtbAmbTemp;
        private System.Windows.Forms.TextBox rtbCalAmbTemp;
        private System.Windows.Forms.GroupBox gbObjectTemp;
        private System.Windows.Forms.NumericUpDown nudSensorCalB;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox rtbCalObjTemp;
        private System.Windows.Forms.NumericUpDown nudSensorCalA;
        private System.Windows.Forms.TextBox rtbObjTemp;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgCalibration;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TempSensor;
        private System.Windows.Forms.DataGridViewTextBoxColumn RealTemp;
        private OxyPlot.WindowsForms.PlotView pltCalibration;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.CheckBox cbNoObjCalibration;
        private System.Windows.Forms.Button btnOK;
    }
}