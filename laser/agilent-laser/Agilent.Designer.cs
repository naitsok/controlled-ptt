
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
            this.txtAgilentConnAddress = new System.Windows.Forms.TextBox();
            this.lblAgilentConnAddress = new System.Windows.Forms.Label();
            this.lblMinCurrent = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMaxVoltage = new System.Windows.Forms.Label();
            this.lblMinVoltage = new System.Windows.Forms.Label();
            this.nudMaxVoltage = new System.Windows.Forms.NumericUpDown();
            this.nudMinVoltage = new System.Windows.Forms.NumericUpDown();
            this.gbLimits = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInitStatus = new System.Windows.Forms.TextBox();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.txtAgilentSwitch = new System.Windows.Forms.TextBox();
            this.btnSwitchAgilent = new System.Windows.Forms.Button();
            this.gbOutput = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxVoltage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinVoltage)).BeginInit();
            this.gbLimits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.gbOutput.SuspendLayout();
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
            this.nudMinCurrent.Size = new System.Drawing.Size(120, 20);
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
            this.nudMaxCurrent.Size = new System.Drawing.Size(120, 20);
            this.nudMaxCurrent.TabIndex = 1;
            this.nudMaxCurrent.Value = new decimal(new int[] {
            12,
            0,
            0,
            65536});
            // 
            // txtAgilentConnAddress
            // 
            this.txtAgilentConnAddress.Location = new System.Drawing.Point(12, 25);
            this.txtAgilentConnAddress.Name = "txtAgilentConnAddress";
            this.txtAgilentConnAddress.Size = new System.Drawing.Size(306, 20);
            this.txtAgilentConnAddress.TabIndex = 11;
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
            this.nudMaxVoltage.Size = new System.Drawing.Size(120, 20);
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
            this.nudMinVoltage.Size = new System.Drawing.Size(120, 20);
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
            this.gbLimits.Location = new System.Drawing.Point(12, 96);
            this.gbLimits.Name = "gbLimits";
            this.gbLimits.Size = new System.Drawing.Size(306, 136);
            this.gbLimits.TabIndex = 20;
            this.gbLimits.TabStop = false;
            this.gbLimits.Text = "Limits for Current and Voltage";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown1.Location = new System.Drawing.Point(180, 18);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            65536});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Output Current [A]";
            // 
            // txtInitStatus
            // 
            this.txtInitStatus.BackColor = System.Drawing.Color.Red;
            this.txtInitStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtInitStatus.Location = new System.Drawing.Point(155, 53);
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
            this.btnInitialize.Size = new System.Drawing.Size(137, 23);
            this.btnInitialize.TabIndex = 24;
            this.btnInitialize.Text = "Initialize Agilent";
            this.btnInitialize.UseVisualStyleBackColor = true;
            // 
            // txtAgilentSwitch
            // 
            this.txtAgilentSwitch.BackColor = System.Drawing.Color.Red;
            this.txtAgilentSwitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtAgilentSwitch.Location = new System.Drawing.Point(143, 44);
            this.txtAgilentSwitch.Name = "txtAgilentSwitch";
            this.txtAgilentSwitch.ReadOnly = true;
            this.txtAgilentSwitch.Size = new System.Drawing.Size(157, 20);
            this.txtAgilentSwitch.TabIndex = 26;
            this.txtAgilentSwitch.Text = "Output Off";
            this.txtAgilentSwitch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSwitchAgilent
            // 
            this.btnSwitchAgilent.Location = new System.Drawing.Point(6, 42);
            this.btnSwitchAgilent.Name = "btnSwitchAgilent";
            this.btnSwitchAgilent.Size = new System.Drawing.Size(131, 23);
            this.btnSwitchAgilent.TabIndex = 25;
            this.btnSwitchAgilent.Text = "Switch Agilent On";
            this.btnSwitchAgilent.UseVisualStyleBackColor = true;
            // 
            // gbOutput
            // 
            this.gbOutput.Controls.Add(this.btnSwitchAgilent);
            this.gbOutput.Controls.Add(this.txtAgilentSwitch);
            this.gbOutput.Controls.Add(this.numericUpDown1);
            this.gbOutput.Controls.Add(this.label2);
            this.gbOutput.Location = new System.Drawing.Point(12, 238);
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.Size = new System.Drawing.Size(306, 72);
            this.gbOutput.TabIndex = 27;
            this.gbOutput.TabStop = false;
            this.gbOutput.Text = "Output";
            // 
            // Agilent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 450);
            this.Controls.Add(this.gbOutput);
            this.Controls.Add(this.btnInitialize);
            this.Controls.Add(this.txtInitStatus);
            this.Controls.Add(this.gbLimits);
            this.Controls.Add(this.txtAgilentConnAddress);
            this.Controls.Add(this.lblAgilentConnAddress);
            this.Name = "Agilent";
            this.Text = "Laser Connected to Agilent Power Supply";
            ((System.ComponentModel.ISupportInitialize)(this.nudMinCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxVoltage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinVoltage)).EndInit();
            this.gbLimits.ResumeLayout(false);
            this.gbLimits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.gbOutput.ResumeLayout(false);
            this.gbOutput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudMinCurrent;
        private System.Windows.Forms.NumericUpDown nudMaxCurrent;
        private System.Windows.Forms.TextBox txtAgilentConnAddress;
        private System.Windows.Forms.Label lblAgilentConnAddress;
        private System.Windows.Forms.Label lblMinCurrent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMaxVoltage;
        private System.Windows.Forms.Label lblMinVoltage;
        private System.Windows.Forms.NumericUpDown nudMaxVoltage;
        private System.Windows.Forms.NumericUpDown nudMinVoltage;
        private System.Windows.Forms.GroupBox gbLimits;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInitStatus;
        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.TextBox txtAgilentSwitch;
        private System.Windows.Forms.Button btnSwitchAgilent;
        private System.Windows.Forms.GroupBox gbOutput;
    }
}

