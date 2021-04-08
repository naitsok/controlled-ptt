namespace ControlledPTT.Sensors
{
    partial class DummySensor
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
            this.btnGenTemp = new System.Windows.Forms.Button();
            this.txtTemperature = new System.Windows.Forms.TextBox();
            this.tmGenTemp = new System.Windows.Forms.Timer(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenTemp
            // 
            this.btnGenTemp.Location = new System.Drawing.Point(12, 12);
            this.btnGenTemp.Name = "btnGenTemp";
            this.btnGenTemp.Size = new System.Drawing.Size(150, 23);
            this.btnGenTemp.TabIndex = 0;
            this.btnGenTemp.Text = "Generate Temperature";
            this.btnGenTemp.UseVisualStyleBackColor = true;
            this.btnGenTemp.Click += new System.EventHandler(this.btnGenTemp_Click);
            // 
            // txtTemperature
            // 
            this.txtTemperature.Location = new System.Drawing.Point(168, 14);
            this.txtTemperature.Name = "txtTemperature";
            this.txtTemperature.ReadOnly = true;
            this.txtTemperature.Size = new System.Drawing.Size(100, 20);
            this.txtTemperature.TabIndex = 1;
            // 
            // tmGenTemp
            // 
            this.tmGenTemp.Interval = 1000;
            this.tmGenTemp.Tick += new System.EventHandler(this.tmGenTemp_Tick);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 326);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DummySensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtTemperature);
            this.Controls.Add(this.btnGenTemp);
            this.Name = "DummySensor";
            this.Text = "Dummy Sensor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenTemp;
        private System.Windows.Forms.TextBox txtTemperature;
        private System.Windows.Forms.Timer tmGenTemp;
        private System.Windows.Forms.Button btnClose;
    }
}

