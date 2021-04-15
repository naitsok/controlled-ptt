
namespace ControlledPTT.Lasers
{
    partial class Agilent
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
            this.nudMinCurrent = new System.Windows.Forms.NumericUpDown();
            this.nudMaxCurrent = new System.Windows.Forms.NumericUpDown();
            this.lblAgilentConnAddress = new System.Windows.Forms.Label();
            this.lblMinCurrent = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMaxVoltage = new System.Windows.Forms.Label();
            this.lblMinVoltage = new System.Windows.Forms.Label();
            this.nudMaxVoltage = new System.Windows.Forms.NumericUpDown();
            this.nudMinVoltage = new System.Windows.Forms.NumericUpDown();
            this.gbLimits = new System.Windows.Forms.GroupBox();
            this.nudOutputCurrent = new System.Windows.Forms.NumericUpDown();
            this.lblOutputCurrent = new System.Windows.Forms.Label();
            this.txtInitStatus = new System.Windows.Forms.TextBox();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.txtAgilentSwitch = new System.Windows.Forms.TextBox();
            this.btnSwitchAgilent = new System.Windows.Forms.Button();
            this.gbOutput = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.nudOutputVoltage = new System.Windows.Forms.NumericUpDown();
            this.lblOutpuVoltage = new System.Windows.Forms.Label();
            this.txtVoltageNow = new System.Windows.Forms.TextBox();
            this.txtCurrentNow = new System.Windows.Forms.TextBox();
            this.lblVoltageNow = new System.Windows.Forms.Label();
            this.lblCurrentNow = new System.Windows.Forms.Label();
            this.cmbAgilentConnAddress = new System.Windows.Forms.ComboBox();
            this.btnRemoveAddress = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxVoltage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinVoltage)).BeginInit();
            this.gbLimits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutputCurrent)).BeginInit();
            this.gbOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutputVoltage)).BeginInit();
            this.SuspendLayout();
            // 
            // nudMinCurrent
            // 
            this.nudMinCurrent.DecimalPlaces = 2;
            this.nudMinCurrent.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudMinCurrent.Location = new System.Drawing.Point(180, 22);
            this.nudMinCurrent.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            65536});
            this.nudMinCurrent.Name = "nudMinCurrent";
            this.nudMinCurrent.Size = new System.Drawing.Size(156, 20);
            this.nudMinCurrent.TabIndex = 0;
            // 
            // nudMaxCurrent
            // 
            this.nudMaxCurrent.DecimalPlaces = 2;
            this.nudMaxCurrent.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudMaxCurrent.Location = new System.Drawing.Point(180, 50);
            this.nudMaxCurrent.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            65536});
            this.nudMaxCurrent.Name = "nudMaxCurrent";
            this.nudMaxCurrent.Size = new System.Drawing.Size(156, 20);
            this.nudMaxCurrent.TabIndex = 1;
            this.nudMaxCurrent.Value = new decimal(new int[] {
            12,
            0,
            0,
            65536});
            // 
            // lblAgilentConnAddress
            // 
            this.lblAgilentConnAddress.AutoSize = true;
            this.lblAgilentConnAddress.Location = new System.Drawing.Point(12, 9);
            this.lblAgilentConnAddress.Name = "lblAgilentConnAddress";
            this.lblAgilentConnAddress.Size = new System.Drawing.Size(137, 13);
            this.lblAgilentConnAddress.TabIndex = 12;
            this.lblAgilentConnAddress.Text = "Agilent Connection Address";
            // 
            // lblMinCurrent
            // 
            this.lblMinCurrent.AutoSize = true;
            this.lblMinCurrent.Location = new System.Drawing.Point(6, 27);
            this.lblMinCurrent.Name = "lblMinCurrent";
            this.lblMinCurrent.Size = new System.Drawing.Size(101, 13);
            this.lblMinCurrent.TabIndex = 14;
            this.lblMinCurrent.Text = "Minimum Current [A]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Maximum Current [A]";
            // 
            // lblMaxVoltage
            // 
            this.lblMaxVoltage.AutoSize = true;
            this.lblMaxVoltage.Location = new System.Drawing.Point(6, 113);
            this.lblMaxVoltage.Name = "lblMaxVoltage";
            this.lblMaxVoltage.Size = new System.Drawing.Size(106, 13);
            this.lblMaxVoltage.TabIndex = 19;
            this.lblMaxVoltage.Text = "Maximum Voltage [V]";
            // 
            // lblMinVoltage
            // 
            this.lblMinVoltage.AutoSize = true;
            this.lblMinVoltage.Location = new System.Drawing.Point(6, 85);
            this.lblMinVoltage.Name = "lblMinVoltage";
            this.lblMinVoltage.Size = new System.Drawing.Size(103, 13);
            this.lblMinVoltage.TabIndex = 18;
            this.lblMinVoltage.Text = "Minimum Voltage [V]";
            // 
            // nudMaxVoltage
            // 
            this.nudMaxVoltage.DecimalPlaces = 1;
            this.nudMaxVoltage.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudMaxVoltage.Location = new System.Drawing.Point(180, 108);
            this.nudMaxVoltage.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudMaxVoltage.Name = "nudMaxVoltage";
            this.nudMaxVoltage.Size = new System.Drawing.Size(156, 20);
            this.nudMaxVoltage.TabIndex = 17;
            this.nudMaxVoltage.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // nudMinVoltage
            // 
            this.nudMinVoltage.DecimalPlaces = 1;
            this.nudMinVoltage.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudMinVoltage.Location = new System.Drawing.Point(180, 80);
            this.nudMinVoltage.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudMinVoltage.Name = "nudMinVoltage";
            this.nudMinVoltage.Size = new System.Drawing.Size(156, 20);
            this.nudMinVoltage.TabIndex = 16;
            // 
            // gbLimits
            // 
            this.gbLimits.Controls.Add(this.nudMinVoltage);
            this.gbLimits.Controls.Add(this.lblMaxVoltage);
            this.gbLimits.Controls.Add(this.nudMinCurrent);
            this.gbLimits.Controls.Add(this.lblMinVoltage);
            this.gbLimits.Controls.Add(this.nudMaxCurrent);
            this.gbLimits.Controls.Add(this.nudMaxVoltage);
            this.gbLimits.Controls.Add(this.lblMinCurrent);
            this.gbLimits.Controls.Add(this.label1);
            this.gbLimits.Location = new System.Drawing.Point(12, 90);
            this.gbLimits.Name = "gbLimits";
            this.gbLimits.Size = new System.Drawing.Size(342, 136);
            this.gbLimits.TabIndex = 20;
            this.gbLimits.TabStop = false;
            this.gbLimits.Text = "Limits for Current and Voltage";
            // 
            // nudOutputCurrent
            // 
            this.nudOutputCurrent.DecimalPlaces = 2;
            this.nudOutputCurrent.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudOutputCurrent.Location = new System.Drawing.Point(180, 18);
            this.nudOutputCurrent.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            65536});
            this.nudOutputCurrent.Name = "nudOutputCurrent";
            this.nudOutputCurrent.Size = new System.Drawing.Size(156, 20);
            this.nudOutputCurrent.TabIndex = 21;
            this.nudOutputCurrent.ValueChanged += new System.EventHandler(this.nudOutputCurrent_ValueChanged);
            // 
            // lblOutputCurrent
            // 
            this.lblOutputCurrent.AutoSize = true;
            this.lblOutputCurrent.Location = new System.Drawing.Point(6, 22);
            this.lblOutputCurrent.Name = "lblOutputCurrent";
            this.lblOutputCurrent.Size = new System.Drawing.Size(92, 13);
            this.lblOutputCurrent.TabIndex = 22;
            this.lblOutputCurrent.Text = "Output Current [A]";
            // 
            // txtInitStatus
            // 
            this.txtInitStatus.BackColor = System.Drawing.Color.Red;
            this.txtInitStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtInitStatus.Location = new System.Drawing.Point(189, 54);
            this.txtInitStatus.Name = "txtInitStatus";
            this.txtInitStatus.ReadOnly = true;
            this.txtInitStatus.Size = new System.Drawing.Size(163, 20);
            this.txtInitStatus.TabIndex = 23;
            this.txtInitStatus.Text = "Agilent Not Initialized";
            this.txtInitStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnInitialize
            // 
            this.btnInitialize.Location = new System.Drawing.Point(12, 52);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(171, 23);
            this.btnInitialize.TabIndex = 24;
            this.btnInitialize.Text = "Initialize Agilent";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // txtAgilentSwitch
            // 
            this.txtAgilentSwitch.BackColor = System.Drawing.Color.Red;
            this.txtAgilentSwitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtAgilentSwitch.Location = new System.Drawing.Point(177, 122);
            this.txtAgilentSwitch.Name = "txtAgilentSwitch";
            this.txtAgilentSwitch.ReadOnly = true;
            this.txtAgilentSwitch.Size = new System.Drawing.Size(159, 20);
            this.txtAgilentSwitch.TabIndex = 26;
            this.txtAgilentSwitch.Text = "Output Off";
            this.txtAgilentSwitch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSwitchAgilent
            // 
            this.btnSwitchAgilent.Location = new System.Drawing.Point(6, 120);
            this.btnSwitchAgilent.Name = "btnSwitchAgilent";
            this.btnSwitchAgilent.Size = new System.Drawing.Size(165, 23);
            this.btnSwitchAgilent.TabIndex = 25;
            this.btnSwitchAgilent.Text = "Switch Agilent On";
            this.btnSwitchAgilent.UseVisualStyleBackColor = true;
            this.btnSwitchAgilent.Click += new System.EventHandler(this.btnSwitchAgilent_Click);
            // 
            // gbOutput
            // 
            this.gbOutput.Controls.Add(this.btnClose);
            this.gbOutput.Controls.Add(this.nudOutputVoltage);
            this.gbOutput.Controls.Add(this.lblOutpuVoltage);
            this.gbOutput.Controls.Add(this.txtVoltageNow);
            this.gbOutput.Controls.Add(this.txtCurrentNow);
            this.gbOutput.Controls.Add(this.lblVoltageNow);
            this.gbOutput.Controls.Add(this.lblCurrentNow);
            this.gbOutput.Controls.Add(this.btnSwitchAgilent);
            this.gbOutput.Controls.Add(this.txtAgilentSwitch);
            this.gbOutput.Controls.Add(this.nudOutputCurrent);
            this.gbOutput.Controls.Add(this.lblOutputCurrent);
            this.gbOutput.Location = new System.Drawing.Point(12, 232);
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.Size = new System.Drawing.Size(342, 176);
            this.gbOutput.TabIndex = 27;
            this.gbOutput.TabStop = false;
            this.gbOutput.Text = "Output";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(177, 148);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(159, 23);
            this.btnClose.TabIndex = 31;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // nudOutputVoltage
            // 
            this.nudOutputVoltage.DecimalPlaces = 1;
            this.nudOutputVoltage.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudOutputVoltage.Location = new System.Drawing.Point(180, 44);
            this.nudOutputVoltage.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudOutputVoltage.Name = "nudOutputVoltage";
            this.nudOutputVoltage.Size = new System.Drawing.Size(156, 20);
            this.nudOutputVoltage.TabIndex = 29;
            this.nudOutputVoltage.ValueChanged += new System.EventHandler(this.nudOutputVoltage_ValueChanged);
            // 
            // lblOutpuVoltage
            // 
            this.lblOutpuVoltage.AutoSize = true;
            this.lblOutpuVoltage.Location = new System.Drawing.Point(6, 48);
            this.lblOutpuVoltage.Name = "lblOutpuVoltage";
            this.lblOutpuVoltage.Size = new System.Drawing.Size(94, 13);
            this.lblOutpuVoltage.TabIndex = 30;
            this.lblOutpuVoltage.Text = "Output Voltage [V]";
            // 
            // txtVoltageNow
            // 
            this.txtVoltageNow.Location = new System.Drawing.Point(180, 96);
            this.txtVoltageNow.Name = "txtVoltageNow";
            this.txtVoltageNow.ReadOnly = true;
            this.txtVoltageNow.Size = new System.Drawing.Size(156, 20);
            this.txtVoltageNow.TabIndex = 30;
            // 
            // txtCurrentNow
            // 
            this.txtCurrentNow.Location = new System.Drawing.Point(180, 70);
            this.txtCurrentNow.Name = "txtCurrentNow";
            this.txtCurrentNow.ReadOnly = true;
            this.txtCurrentNow.Size = new System.Drawing.Size(156, 20);
            this.txtCurrentNow.TabIndex = 29;
            // 
            // lblVoltageNow
            // 
            this.lblVoltageNow.AutoSize = true;
            this.lblVoltageNow.Location = new System.Drawing.Point(6, 99);
            this.lblVoltageNow.Name = "lblVoltageNow";
            this.lblVoltageNow.Size = new System.Drawing.Size(84, 13);
            this.lblVoltageNow.TabIndex = 30;
            this.lblVoltageNow.Text = "Voltage Now [V]";
            // 
            // lblCurrentNow
            // 
            this.lblCurrentNow.AutoSize = true;
            this.lblCurrentNow.Location = new System.Drawing.Point(6, 73);
            this.lblCurrentNow.Name = "lblCurrentNow";
            this.lblCurrentNow.Size = new System.Drawing.Size(82, 13);
            this.lblCurrentNow.TabIndex = 29;
            this.lblCurrentNow.Text = "Current Now [A]";
            // 
            // cmbAgilentConnAddress
            // 
            this.cmbAgilentConnAddress.AllowDrop = true;
            this.cmbAgilentConnAddress.FormattingEnabled = true;
            this.cmbAgilentConnAddress.Location = new System.Drawing.Point(12, 25);
            this.cmbAgilentConnAddress.Name = "cmbAgilentConnAddress";
            this.cmbAgilentConnAddress.Size = new System.Drawing.Size(270, 21);
            this.cmbAgilentConnAddress.TabIndex = 28;
            this.cmbAgilentConnAddress.Text = "USB0::0x0957::0x0807::US08M3130G::0::INSTR";
            this.cmbAgilentConnAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbAgilentConnAddress_KeyPress);
            this.cmbAgilentConnAddress.Leave += new System.EventHandler(this.cmbAgilentConnAddress_Leave);
            // 
            // btnRemoveAddress
            // 
            this.btnRemoveAddress.Location = new System.Drawing.Point(288, 24);
            this.btnRemoveAddress.Name = "btnRemoveAddress";
            this.btnRemoveAddress.Size = new System.Drawing.Size(66, 23);
            this.btnRemoveAddress.TabIndex = 29;
            this.btnRemoveAddress.Text = "Remove";
            this.btnRemoveAddress.UseVisualStyleBackColor = true;
            this.btnRemoveAddress.Click += new System.EventHandler(this.btnRemoveAddress_Click);
            // 
            // Agilent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 415);
            this.Controls.Add(this.btnRemoveAddress);
            this.Controls.Add(this.cmbAgilentConnAddress);
            this.Controls.Add(this.gbOutput);
            this.Controls.Add(this.btnInitialize);
            this.Controls.Add(this.txtInitStatus);
            this.Controls.Add(this.gbLimits);
            this.Controls.Add(this.lblAgilentConnAddress);
            this.Name = "Agilent";
            this.Text = "Laser Connected to Agilent Power Supply";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Agilent_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudMinCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxVoltage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinVoltage)).EndInit();
            this.gbLimits.ResumeLayout(false);
            this.gbLimits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutputCurrent)).EndInit();
            this.gbOutput.ResumeLayout(false);
            this.gbOutput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutputVoltage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudMinCurrent;
        private System.Windows.Forms.NumericUpDown nudMaxCurrent;
        private System.Windows.Forms.Label lblAgilentConnAddress;
        private System.Windows.Forms.Label lblMinCurrent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMaxVoltage;
        private System.Windows.Forms.Label lblMinVoltage;
        private System.Windows.Forms.NumericUpDown nudMaxVoltage;
        private System.Windows.Forms.NumericUpDown nudMinVoltage;
        private System.Windows.Forms.GroupBox gbLimits;
        private System.Windows.Forms.NumericUpDown nudOutputCurrent;
        private System.Windows.Forms.Label lblOutputCurrent;
        private System.Windows.Forms.TextBox txtInitStatus;
        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.TextBox txtAgilentSwitch;
        private System.Windows.Forms.Button btnSwitchAgilent;
        private System.Windows.Forms.GroupBox gbOutput;
        private System.Windows.Forms.ComboBox cmbAgilentConnAddress;
        private System.Windows.Forms.Label lblVoltageNow;
        private System.Windows.Forms.Label lblCurrentNow;
        private System.Windows.Forms.TextBox txtVoltageNow;
        private System.Windows.Forms.TextBox txtCurrentNow;
        private System.Windows.Forms.NumericUpDown nudOutputVoltage;
        private System.Windows.Forms.Label lblOutpuVoltage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRemoveAddress;
    }
}

