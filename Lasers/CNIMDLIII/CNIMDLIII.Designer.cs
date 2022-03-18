
namespace ControlledPTT.Lasers
{
    partial class CNIMDLIII
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
            this.gbLaserConn = new System.Windows.Forms.GroupBox();
            this.btnLaserCalibration = new System.Windows.Forms.Button();
            this.cbLaserCalibration = new System.Windows.Forms.ComboBox();
            this.btnClearData = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAllReceivedData = new System.Windows.Forms.RichTextBox();
            this.txtInitStatus = new System.Windows.Forms.TextBox();
            this.btnBaudRate = new System.Windows.Forms.Button();
            this.btnGetComPorts = new System.Windows.Forms.Button();
            this.cbPorts = new System.Windows.Forms.ComboBox();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.btnInitLaser = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbLimits = new System.Windows.Forms.GroupBox();
            this.nudMaxCurrent = new System.Windows.Forms.NumericUpDown();
            this.nudMinCurrent = new System.Windows.Forms.NumericUpDown();
            this.lblMaxCurrent = new System.Windows.Forms.Label();
            this.lblMinCurrent = new System.Windows.Forms.Label();
            this.nudMinPower = new System.Windows.Forms.NumericUpDown();
            this.nudMaxPower = new System.Windows.Forms.NumericUpDown();
            this.lblMinPower = new System.Windows.Forms.Label();
            this.lblMaxPower = new System.Windows.Forms.Label();
            this.gbOutput = new System.Windows.Forms.GroupBox();
            this.nudOutputCurrent = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSwitchLaser = new System.Windows.Forms.Button();
            this.txtLaserOutput = new System.Windows.Forms.TextBox();
            this.nudOutputPower = new System.Windows.Forms.NumericUpDown();
            this.lblOutputPower = new System.Windows.Forms.Label();
            this.gbLaserConn.SuspendLayout();
            this.gbLimits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPower)).BeginInit();
            this.gbOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutputCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutputPower)).BeginInit();
            this.SuspendLayout();
            // 
            // gbLaserConn
            // 
            this.gbLaserConn.Controls.Add(this.btnLaserCalibration);
            this.gbLaserConn.Controls.Add(this.cbLaserCalibration);
            this.gbLaserConn.Controls.Add(this.btnClearData);
            this.gbLaserConn.Controls.Add(this.label3);
            this.gbLaserConn.Controls.Add(this.txtAllReceivedData);
            this.gbLaserConn.Controls.Add(this.txtInitStatus);
            this.gbLaserConn.Controls.Add(this.btnBaudRate);
            this.gbLaserConn.Controls.Add(this.btnGetComPorts);
            this.gbLaserConn.Controls.Add(this.cbPorts);
            this.gbLaserConn.Controls.Add(this.cbBaudRate);
            this.gbLaserConn.Controls.Add(this.btnInitLaser);
            this.gbLaserConn.Location = new System.Drawing.Point(12, 12);
            this.gbLaserConn.Name = "gbLaserConn";
            this.gbLaserConn.Size = new System.Drawing.Size(360, 238);
            this.gbLaserConn.TabIndex = 35;
            this.gbLaserConn.TabStop = false;
            this.gbLaserConn.Text = "Laser controller connection";
            // 
            // btnLaserCalibration
            // 
            this.btnLaserCalibration.Location = new System.Drawing.Point(6, 78);
            this.btnLaserCalibration.Name = "btnLaserCalibration";
            this.btnLaserCalibration.Size = new System.Drawing.Size(115, 23);
            this.btnLaserCalibration.TabIndex = 24;
            this.btnLaserCalibration.Text = "Laser Calibration";
            this.btnLaserCalibration.UseVisualStyleBackColor = true;
            // 
            // cbLaserCalibration
            // 
            this.cbLaserCalibration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLaserCalibration.FormattingEnabled = true;
            this.cbLaserCalibration.Location = new System.Drawing.Point(127, 80);
            this.cbLaserCalibration.Name = "cbLaserCalibration";
            this.cbLaserCalibration.Size = new System.Drawing.Size(227, 21);
            this.cbLaserCalibration.TabIndex = 23;
            this.cbLaserCalibration.SelectedIndexChanged += new System.EventHandler(this.cbLaserCalibration_SelectedIndexChanged);
            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(313, 148);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(41, 84);
            this.btnClearData.TabIndex = 22;
            this.btnClearData.Text = "C\r\nl\r\ne\r\na\r\nr";
            this.btnClearData.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Data Received from Laser";
            // 
            // txtAllReceivedData
            // 
            this.txtAllReceivedData.Location = new System.Drawing.Point(6, 148);
            this.txtAllReceivedData.Name = "txtAllReceivedData";
            this.txtAllReceivedData.Size = new System.Drawing.Size(301, 84);
            this.txtAllReceivedData.TabIndex = 20;
            this.txtAllReceivedData.Text = "";
            // 
            // txtInitStatus
            // 
            this.txtInitStatus.BackColor = System.Drawing.Color.Red;
            this.txtInitStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInitStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtInitStatus.Location = new System.Drawing.Point(127, 107);
            this.txtInitStatus.Name = "txtInitStatus";
            this.txtInitStatus.ReadOnly = true;
            this.txtInitStatus.Size = new System.Drawing.Size(227, 20);
            this.txtInitStatus.TabIndex = 15;
            this.txtInitStatus.Text = "Not Initalized";
            this.txtInitStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnBaudRate
            // 
            this.btnBaudRate.Location = new System.Drawing.Point(6, 51);
            this.btnBaudRate.Name = "btnBaudRate";
            this.btnBaudRate.Size = new System.Drawing.Size(115, 23);
            this.btnBaudRate.TabIndex = 14;
            this.btnBaudRate.Text = "Baud Rate";
            this.btnBaudRate.UseVisualStyleBackColor = true;
            // 
            // btnGetComPorts
            // 
            this.btnGetComPorts.Location = new System.Drawing.Point(6, 22);
            this.btnGetComPorts.Name = "btnGetComPorts";
            this.btnGetComPorts.Size = new System.Drawing.Size(115, 23);
            this.btnGetComPorts.TabIndex = 0;
            this.btnGetComPorts.Text = "Get COM ports";
            this.btnGetComPorts.UseVisualStyleBackColor = true;
            this.btnGetComPorts.Click += new System.EventHandler(this.btnGetComPorts_Click);
            // 
            // cbPorts
            // 
            this.cbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPorts.FormattingEnabled = true;
            this.cbPorts.Location = new System.Drawing.Point(127, 22);
            this.cbPorts.Name = "cbPorts";
            this.cbPorts.Size = new System.Drawing.Size(227, 21);
            this.cbPorts.TabIndex = 2;
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Items.AddRange(new object[] {
            "110",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "56000",
            "57600",
            "115200 "});
            this.cbBaudRate.Location = new System.Drawing.Point(127, 53);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(227, 21);
            this.cbBaudRate.TabIndex = 13;
            // 
            // btnInitLaser
            // 
            this.btnInitLaser.Location = new System.Drawing.Point(6, 105);
            this.btnInitLaser.Name = "btnInitLaser";
            this.btnInitLaser.Size = new System.Drawing.Size(115, 23);
            this.btnInitLaser.TabIndex = 3;
            this.btnInitLaser.Text = "Initialize Laser";
            this.btnInitLaser.UseVisualStyleBackColor = true;
            this.btnInitLaser.Click += new System.EventHandler(this.btnInitLaser_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(18, 500);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 23);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbLimits
            // 
            this.gbLimits.Controls.Add(this.nudMaxCurrent);
            this.gbLimits.Controls.Add(this.nudMinCurrent);
            this.gbLimits.Controls.Add(this.lblMaxCurrent);
            this.gbLimits.Controls.Add(this.lblMinCurrent);
            this.gbLimits.Controls.Add(this.nudMinPower);
            this.gbLimits.Controls.Add(this.nudMaxPower);
            this.gbLimits.Controls.Add(this.lblMinPower);
            this.gbLimits.Controls.Add(this.lblMaxPower);
            this.gbLimits.Location = new System.Drawing.Point(12, 256);
            this.gbLimits.Name = "gbLimits";
            this.gbLimits.Size = new System.Drawing.Size(360, 135);
            this.gbLimits.TabIndex = 36;
            this.gbLimits.TabStop = false;
            this.gbLimits.Text = "Laser Power and Current Limits";
            // 
            // nudMaxCurrent
            // 
            this.nudMaxCurrent.DecimalPlaces = 2;
            this.nudMaxCurrent.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudMaxCurrent.Location = new System.Drawing.Point(127, 45);
            this.nudMaxCurrent.Maximum = new decimal(new int[] {
            274,
            0,
            0,
            131072});
            this.nudMaxCurrent.Name = "nudMaxCurrent";
            this.nudMaxCurrent.Size = new System.Drawing.Size(227, 20);
            this.nudMaxCurrent.TabIndex = 40;
            this.nudMaxCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMaxCurrent.ValueChanged += new System.EventHandler(this.nudMaxCurrent_ValueChanged);
            // 
            // nudMinCurrent
            // 
            this.nudMinCurrent.DecimalPlaces = 2;
            this.nudMinCurrent.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudMinCurrent.Location = new System.Drawing.Point(127, 19);
            this.nudMinCurrent.Maximum = new decimal(new int[] {
            274,
            0,
            0,
            131072});
            this.nudMinCurrent.Name = "nudMinCurrent";
            this.nudMinCurrent.Size = new System.Drawing.Size(227, 20);
            this.nudMinCurrent.TabIndex = 38;
            this.nudMinCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMinCurrent.ValueChanged += new System.EventHandler(this.nudMinCurrent_ValueChanged);
            // 
            // lblMaxCurrent
            // 
            this.lblMaxCurrent.AutoSize = true;
            this.lblMaxCurrent.Location = new System.Drawing.Point(6, 48);
            this.lblMaxCurrent.Name = "lblMaxCurrent";
            this.lblMaxCurrent.Size = new System.Drawing.Size(104, 13);
            this.lblMaxCurrent.TabIndex = 41;
            this.lblMaxCurrent.Text = "Maximum Current [A]";
            // 
            // lblMinCurrent
            // 
            this.lblMinCurrent.AutoSize = true;
            this.lblMinCurrent.Location = new System.Drawing.Point(6, 22);
            this.lblMinCurrent.Name = "lblMinCurrent";
            this.lblMinCurrent.Size = new System.Drawing.Size(101, 13);
            this.lblMinCurrent.TabIndex = 39;
            this.lblMinCurrent.Text = "Minimum Current [A]";
            // 
            // nudMinPower
            // 
            this.nudMinPower.Location = new System.Drawing.Point(127, 83);
            this.nudMinPower.Maximum = new decimal(new int[] {
            2300,
            0,
            0,
            0});
            this.nudMinPower.Name = "nudMinPower";
            this.nudMinPower.Size = new System.Drawing.Size(227, 20);
            this.nudMinPower.TabIndex = 16;
            this.nudMinPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMinPower.ValueChanged += new System.EventHandler(this.nudMinPower_ValueChanged);
            // 
            // nudMaxPower
            // 
            this.nudMaxPower.Location = new System.Drawing.Point(127, 109);
            this.nudMaxPower.Maximum = new decimal(new int[] {
            2600,
            0,
            0,
            0});
            this.nudMaxPower.Name = "nudMaxPower";
            this.nudMaxPower.Size = new System.Drawing.Size(227, 20);
            this.nudMaxPower.TabIndex = 17;
            this.nudMaxPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMaxPower.Value = new decimal(new int[] {
            2300,
            0,
            0,
            0});
            this.nudMaxPower.ValueChanged += new System.EventHandler(this.nudMaxPower_ValueChanged);
            // 
            // lblMinPower
            // 
            this.lblMinPower.AutoSize = true;
            this.lblMinPower.Location = new System.Drawing.Point(6, 86);
            this.lblMinPower.Name = "lblMinPower";
            this.lblMinPower.Size = new System.Drawing.Size(109, 13);
            this.lblMinPower.TabIndex = 18;
            this.lblMinPower.Text = "Minimum Power [mW]";
            // 
            // lblMaxPower
            // 
            this.lblMaxPower.AutoSize = true;
            this.lblMaxPower.Location = new System.Drawing.Point(6, 112);
            this.lblMaxPower.Name = "lblMaxPower";
            this.lblMaxPower.Size = new System.Drawing.Size(112, 13);
            this.lblMaxPower.TabIndex = 19;
            this.lblMaxPower.Text = "Maximum Power [mW]";
            // 
            // gbOutput
            // 
            this.gbOutput.Controls.Add(this.nudOutputCurrent);
            this.gbOutput.Controls.Add(this.label1);
            this.gbOutput.Controls.Add(this.btnSwitchLaser);
            this.gbOutput.Controls.Add(this.txtLaserOutput);
            this.gbOutput.Controls.Add(this.nudOutputPower);
            this.gbOutput.Controls.Add(this.lblOutputPower);
            this.gbOutput.Location = new System.Drawing.Point(12, 397);
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.Size = new System.Drawing.Size(360, 97);
            this.gbOutput.TabIndex = 37;
            this.gbOutput.TabStop = false;
            this.gbOutput.Text = "Output";
            // 
            // nudOutputCurrent
            // 
            this.nudOutputCurrent.DecimalPlaces = 2;
            this.nudOutputCurrent.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudOutputCurrent.Location = new System.Drawing.Point(127, 19);
            this.nudOutputCurrent.Maximum = new decimal(new int[] {
            274,
            0,
            0,
            131072});
            this.nudOutputCurrent.Name = "nudOutputCurrent";
            this.nudOutputCurrent.Size = new System.Drawing.Size(227, 20);
            this.nudOutputCurrent.TabIndex = 42;
            this.nudOutputCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudOutputCurrent.ValueChanged += new System.EventHandler(this.nudOutputCurrent_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Output Current [A]";
            // 
            // btnSwitchLaser
            // 
            this.btnSwitchLaser.Location = new System.Drawing.Point(6, 69);
            this.btnSwitchLaser.Name = "btnSwitchLaser";
            this.btnSwitchLaser.Size = new System.Drawing.Size(115, 23);
            this.btnSwitchLaser.TabIndex = 27;
            this.btnSwitchLaser.Text = "Switch Laser On";
            this.btnSwitchLaser.UseVisualStyleBackColor = true;
            this.btnSwitchLaser.Click += new System.EventHandler(this.btnSwitchLaser_Click);
            // 
            // txtLaserOutput
            // 
            this.txtLaserOutput.BackColor = System.Drawing.Color.Red;
            this.txtLaserOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLaserOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtLaserOutput.Location = new System.Drawing.Point(127, 71);
            this.txtLaserOutput.Name = "txtLaserOutput";
            this.txtLaserOutput.ReadOnly = true;
            this.txtLaserOutput.Size = new System.Drawing.Size(227, 20);
            this.txtLaserOutput.TabIndex = 28;
            this.txtLaserOutput.Text = "Output Off";
            this.txtLaserOutput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudOutputPower
            // 
            this.nudOutputPower.Location = new System.Drawing.Point(127, 45);
            this.nudOutputPower.Maximum = new decimal(new int[] {
            2300,
            0,
            0,
            0});
            this.nudOutputPower.Name = "nudOutputPower";
            this.nudOutputPower.Size = new System.Drawing.Size(227, 20);
            this.nudOutputPower.TabIndex = 16;
            this.nudOutputPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudOutputPower.ValueChanged += new System.EventHandler(this.nudOutputPower_ValueChanged);
            // 
            // lblOutputPower
            // 
            this.lblOutputPower.AutoSize = true;
            this.lblOutputPower.Location = new System.Drawing.Point(6, 48);
            this.lblOutputPower.Name = "lblOutputPower";
            this.lblOutputPower.Size = new System.Drawing.Size(100, 13);
            this.lblOutputPower.TabIndex = 18;
            this.lblOutputPower.Text = "Output Power [mW]";
            // 
            // CNIMDLIII
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 531);
            this.Controls.Add(this.gbOutput);
            this.Controls.Add(this.gbLimits);
            this.Controls.Add(this.gbLaserConn);
            this.Controls.Add(this.btnClose);
            this.MinimumSize = new System.Drawing.Size(400, 570);
            this.Name = "CNIMDLIII";
            this.Text = "CNI MDL-III Laser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CNIMDLIII_FormClosing);
            this.gbLaserConn.ResumeLayout(false);
            this.gbLaserConn.PerformLayout();
            this.gbLimits.ResumeLayout(false);
            this.gbLimits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPower)).EndInit();
            this.gbOutput.ResumeLayout(false);
            this.gbOutput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutputCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutputPower)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLaserConn;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClearData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtAllReceivedData;
        private System.Windows.Forms.TextBox txtInitStatus;
        private System.Windows.Forms.Button btnBaudRate;
        private System.Windows.Forms.Button btnGetComPorts;
        private System.Windows.Forms.ComboBox cbPorts;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.Button btnInitLaser;
        private System.Windows.Forms.GroupBox gbLimits;
        private System.Windows.Forms.NumericUpDown nudMinPower;
        private System.Windows.Forms.NumericUpDown nudMaxPower;
        private System.Windows.Forms.Label lblMinPower;
        private System.Windows.Forms.Label lblMaxPower;
        private System.Windows.Forms.GroupBox gbOutput;
        private System.Windows.Forms.NumericUpDown nudOutputPower;
        private System.Windows.Forms.Label lblOutputPower;
        private System.Windows.Forms.Button btnSwitchLaser;
        private System.Windows.Forms.TextBox txtLaserOutput;
        private System.Windows.Forms.NumericUpDown nudMaxCurrent;
        private System.Windows.Forms.Label lblMaxCurrent;
        private System.Windows.Forms.NumericUpDown nudMinCurrent;
        private System.Windows.Forms.Label lblMinCurrent;
        private System.Windows.Forms.NumericUpDown nudOutputCurrent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLaserCalibration;
        private System.Windows.Forms.ComboBox cbLaserCalibration;
    }
}

