namespace ControlledPTT
{
    partial class Calibration
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCalibFile = new System.Windows.Forms.Label();
            this.txtCalibFile = new System.Windows.Forms.TextBox();
            this.nudIntercept = new System.Windows.Forms.NumericUpDown();
            this.label32 = new System.Windows.Forms.Label();
            this.txtCalibratedTemp = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtSensorTemp = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.nudSlope = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgCalibration = new System.Windows.Forms.DataGridView();
            this.colTempSensor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RealTemp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.pltCalibration = new OxyPlot.WindowsForms.PlotView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.ofdLoadCalibration = new System.Windows.Forms.OpenFileDialog();
            this.sfdSaveCalibration = new System.Windows.Forms.SaveFileDialog();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntercept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSlope)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCalibration)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCalibFile
            // 
            this.lblCalibFile.AutoSize = true;
            this.lblCalibFile.Location = new System.Drawing.Point(12, 9);
            this.lblCalibFile.Name = "lblCalibFile";
            this.lblCalibFile.Size = new System.Drawing.Size(23, 13);
            this.lblCalibFile.TabIndex = 47;
            this.lblCalibFile.Text = "File";
            // 
            // txtCalibFile
            // 
            this.txtCalibFile.Location = new System.Drawing.Point(12, 25);
            this.txtCalibFile.Name = "txtCalibFile";
            this.txtCalibFile.ReadOnly = true;
            this.txtCalibFile.Size = new System.Drawing.Size(243, 20);
            this.txtCalibFile.TabIndex = 47;
            // 
            // nudIntercept
            // 
            this.nudIntercept.DecimalPlaces = 3;
            this.nudIntercept.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudIntercept.Location = new System.Drawing.Point(165, 77);
            this.nudIntercept.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudIntercept.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.nudIntercept.Name = "nudIntercept";
            this.nudIntercept.Size = new System.Drawing.Size(90, 20);
            this.nudIntercept.TabIndex = 36;
            this.nudIntercept.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudIntercept.ValueChanged += new System.EventHandler(this.NudIntercept_ValueChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(130, 80);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(33, 13);
            this.label32.TabIndex = 35;
            this.label32.Text = "* X + ";
            // 
            // txtCalibratedTemp
            // 
            this.txtCalibratedTemp.Location = new System.Drawing.Point(145, 103);
            this.txtCalibratedTemp.Name = "txtCalibratedTemp";
            this.txtCalibratedTemp.ReadOnly = true;
            this.txtCalibratedTemp.Size = new System.Drawing.Size(110, 20);
            this.txtCalibratedTemp.TabIndex = 25;
            this.txtCalibratedTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(12, 79);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(26, 13);
            this.label23.TabIndex = 34;
            this.label23.Text = "Y = ";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(12, 54);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(103, 13);
            this.label22.TabIndex = 28;
            this.label22.Text = "Sensor Temperature";
            // 
            // txtSensorTemp
            // 
            this.txtSensorTemp.Location = new System.Drawing.Point(145, 51);
            this.txtSensorTemp.Name = "txtSensorTemp";
            this.txtSensorTemp.ReadOnly = true;
            this.txtSensorTemp.Size = new System.Drawing.Size(110, 20);
            this.txtSensorTemp.TabIndex = 20;
            this.txtSensorTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(12, 106);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(117, 13);
            this.label27.TabIndex = 30;
            this.label27.Text = "Calibrated Temperature";
            // 
            // nudSlope
            // 
            this.nudSlope.DecimalPlaces = 3;
            this.nudSlope.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudSlope.Location = new System.Drawing.Point(38, 77);
            this.nudSlope.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudSlope.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.nudSlope.Name = "nudSlope";
            this.nudSlope.Size = new System.Drawing.Size(90, 20);
            this.nudSlope.TabIndex = 20;
            this.nudSlope.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudSlope.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSlope.ValueChanged += new System.EventHandler(this.NudSlope_ValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(75, 286);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 23);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "Save As";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // dgCalibration
            // 
            dataGridViewCellStyle3.NullValue = null;
            this.dgCalibration.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgCalibration.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgCalibration.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgCalibration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCalibration.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTempSensor,
            this.RealTemp});
            this.dgCalibration.Location = new System.Drawing.Point(261, 9);
            this.dgCalibration.MultiSelect = false;
            this.dgCalibration.Name = "dgCalibration";
            this.dgCalibration.Size = new System.Drawing.Size(270, 272);
            this.dgCalibration.TabIndex = 38;
            this.dgCalibration.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCalibration_CellLeave);
            // 
            // colTempSensor
            // 
            this.colTempSensor.Frozen = true;
            this.colTempSensor.HeaderText = "Temperature from Sensor";
            this.colTempSensor.Name = "colTempSensor";
            this.colTempSensor.Width = 108;
            // 
            // RealTemp
            // 
            this.RealTemp.HeaderText = "Correct Temperature";
            this.RealTemp.Name = "RealTemp";
            this.RealTemp.Width = 118;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(261, 286);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(270, 23);
            this.btnCalculate.TabIndex = 39;
            this.btnCalculate.Text = "Calculate Coefficients";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.BtnCalculate_Click);
            // 
            // pltCalibration
            // 
            this.pltCalibration.Location = new System.Drawing.Point(537, 9);
            this.pltCalibration.Name = "pltCalibration";
            this.pltCalibration.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.pltCalibration.Size = new System.Drawing.Size(534, 301);
            this.pltCalibration.TabIndex = 44;
            this.pltCalibration.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.pltCalibration.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pltCalibration.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(137, 286);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(56, 23);
            this.btnLoad.TabIndex = 45;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 286);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(56, 23);
            this.btnOK.TabIndex = 46;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // ofdLoadCalibration
            // 
            this.ofdLoadCalibration.DefaultExt = "json";
            this.ofdLoadCalibration.Filter = "JSON files (*.json)|*json";
            this.ofdLoadCalibration.RestoreDirectory = true;
            // 
            // sfdSaveCalibration
            // 
            this.sfdSaveCalibration.DefaultExt = "json";
            this.sfdSaveCalibration.Filter = "JSON files (*.json)|*.json";
            this.sfdSaveCalibration.RestoreDirectory = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(199, 286);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 23);
            this.btnCancel.TabIndex = 48;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Calibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 321);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblCalibFile);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtCalibFile);
            this.Controls.Add(this.nudIntercept);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.pltCalibration);
            this.Controls.Add(this.txtCalibratedTemp);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.dgCalibration);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtSensorTemp);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.nudSlope);
            this.MinimumSize = new System.Drawing.Size(1100, 360);
            this.Name = "Calibration";
            this.Text = "Sensor Calibration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Calibration_FormClosing);
            this.Load += new System.EventHandler(this.Calibration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudIntercept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSlope)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCalibration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown nudIntercept;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtCalibratedTemp;
        private System.Windows.Forms.NumericUpDown nudSlope;
        private System.Windows.Forms.TextBox txtSensorTemp;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgCalibration;
        private System.Windows.Forms.Button btnCalculate;
        private OxyPlot.WindowsForms.PlotView pltCalibration;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTempSensor;
        private System.Windows.Forms.DataGridViewTextBoxColumn RealTemp;
        private System.Windows.Forms.Label lblCalibFile;
        private System.Windows.Forms.TextBox txtCalibFile;
        private System.Windows.Forms.OpenFileDialog ofdLoadCalibration;
        private System.Windows.Forms.SaveFileDialog sfdSaveCalibration;
        private System.Windows.Forms.Button btnCancel;
    }
}