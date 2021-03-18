namespace ControlledPTT.Lasers
{
    partial class DummyLaser
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
            this.btnInitialize = new System.Windows.Forms.Button();
            this.txtInitStatus = new System.Windows.Forms.TextBox();
            this.nudMinPower = new System.Windows.Forms.NumericUpDown();
            this.lblMinPower = new System.Windows.Forms.Label();
            this.lblMaxPower = new System.Windows.Forms.Label();
            this.nudMaxPower = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nudPower = new System.Windows.Forms.NumericUpDown();
            this.txtLaserSwitch = new System.Windows.Forms.TextBox();
            this.btnSwitchLaser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPower)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInitialize
            // 
            this.btnInitialize.Location = new System.Drawing.Point(12, 12);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(96, 23);
            this.btnInitialize.TabIndex = 0;
            this.btnInitialize.Text = "Initialize Laser";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // txtInitStatus
            // 
            this.txtInitStatus.BackColor = System.Drawing.Color.Red;
            this.txtInitStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtInitStatus.Location = new System.Drawing.Point(114, 14);
            this.txtInitStatus.Name = "txtInitStatus";
            this.txtInitStatus.ReadOnly = true;
            this.txtInitStatus.Size = new System.Drawing.Size(158, 20);
            this.txtInitStatus.TabIndex = 1;
            this.txtInitStatus.Text = "Laser Not Initialized";
            this.txtInitStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudMinPower
            // 
            this.nudMinPower.DecimalPlaces = 2;
            this.nudMinPower.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudMinPower.Location = new System.Drawing.Point(114, 40);
            this.nudMinPower.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudMinPower.Name = "nudMinPower";
            this.nudMinPower.Size = new System.Drawing.Size(158, 20);
            this.nudMinPower.TabIndex = 2;
            this.nudMinPower.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudMinPower.ValueChanged += new System.EventHandler(this.nudMinPower_ValueChanged);
            // 
            // lblMinPower
            // 
            this.lblMinPower.AutoSize = true;
            this.lblMinPower.Location = new System.Drawing.Point(12, 42);
            this.lblMinPower.Name = "lblMinPower";
            this.lblMinPower.Size = new System.Drawing.Size(57, 13);
            this.lblMinPower.TabIndex = 3;
            this.lblMinPower.Text = "Min Power";
            // 
            // lblMaxPower
            // 
            this.lblMaxPower.AutoSize = true;
            this.lblMaxPower.Location = new System.Drawing.Point(12, 68);
            this.lblMaxPower.Name = "lblMaxPower";
            this.lblMaxPower.Size = new System.Drawing.Size(60, 13);
            this.lblMaxPower.TabIndex = 5;
            this.lblMaxPower.Text = "Max Power";
            // 
            // nudMaxPower
            // 
            this.nudMaxPower.DecimalPlaces = 2;
            this.nudMaxPower.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudMaxPower.Location = new System.Drawing.Point(114, 66);
            this.nudMaxPower.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudMaxPower.Name = "nudMaxPower";
            this.nudMaxPower.Size = new System.Drawing.Size(158, 20);
            this.nudMaxPower.TabIndex = 4;
            this.nudMaxPower.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudMaxPower.ValueChanged += new System.EventHandler(this.nudMaxPower_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Set Power";
            // 
            // nudPower
            // 
            this.nudPower.DecimalPlaces = 2;
            this.nudPower.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudPower.Location = new System.Drawing.Point(114, 92);
            this.nudPower.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudPower.Name = "nudPower";
            this.nudPower.Size = new System.Drawing.Size(158, 20);
            this.nudPower.TabIndex = 6;
            this.nudPower.ValueChanged += new System.EventHandler(this.nudPower_ValueChanged);
            // 
            // txtLaserSwitch
            // 
            this.txtLaserSwitch.BackColor = System.Drawing.Color.Red;
            this.txtLaserSwitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtLaserSwitch.Location = new System.Drawing.Point(114, 329);
            this.txtLaserSwitch.Name = "txtLaserSwitch";
            this.txtLaserSwitch.ReadOnly = true;
            this.txtLaserSwitch.Size = new System.Drawing.Size(158, 20);
            this.txtLaserSwitch.TabIndex = 9;
            this.txtLaserSwitch.Text = "Laser Off";
            this.txtLaserSwitch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSwitchLaser
            // 
            this.btnSwitchLaser.Location = new System.Drawing.Point(12, 327);
            this.btnSwitchLaser.Name = "btnSwitchLaser";
            this.btnSwitchLaser.Size = new System.Drawing.Size(96, 23);
            this.btnSwitchLaser.TabIndex = 8;
            this.btnSwitchLaser.Text = "Switch Laser On";
            this.btnSwitchLaser.UseVisualStyleBackColor = true;
            this.btnSwitchLaser.Click += new System.EventHandler(this.btnSwitchLaser_Click);
            // 
            // DummyLaserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.txtLaserSwitch);
            this.Controls.Add(this.btnSwitchLaser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudPower);
            this.Controls.Add(this.lblMaxPower);
            this.Controls.Add(this.nudMaxPower);
            this.Controls.Add(this.lblMinPower);
            this.Controls.Add(this.nudMinPower);
            this.Controls.Add(this.txtInitStatus);
            this.Controls.Add(this.btnInitialize);
            this.Name = "DummyLaserForm";
            this.Text = "Dummy Laser";
            ((System.ComponentModel.ISupportInitialize)(this.nudMinPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPower)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.TextBox txtInitStatus;
        private System.Windows.Forms.NumericUpDown nudMinPower;
        private System.Windows.Forms.Label lblMinPower;
        private System.Windows.Forms.Label lblMaxPower;
        private System.Windows.Forms.NumericUpDown nudMaxPower;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudPower;
        private System.Windows.Forms.TextBox txtLaserSwitch;
        private System.Windows.Forms.Button btnSwitchLaser;
    }
}

