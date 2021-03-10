namespace ControlledPTT.Sensors
{
    partial class ArrayMLX
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
            this.gbArduino = new System.Windows.Forms.GroupBox();
            this.btnDeselectAll = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAvgTemperature = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.txtAvgTemperature = new System.Windows.Forms.TextBox();
            this.txtAllReceivedData = new System.Windows.Forms.TextBox();
            this.btnClearData = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConnectedStatus = new System.Windows.Forms.TextBox();
            this.btnBaudRate = new System.Windows.Forms.Button();
            this.btnGetComPorts = new System.Windows.Forms.Button();
            this.cbPorts = new System.Windows.Forms.ComboBox();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.btnConnRedBoard = new System.Windows.Forms.Button();
            this.gbTemperatures = new System.Windows.Forms.GroupBox();
            this.gbArduino.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbArduino
            // 
            this.gbArduino.Controls.Add(this.btnDeselectAll);
            this.gbArduino.Controls.Add(this.label2);
            this.gbArduino.Controls.Add(this.btnAvgTemperature);
            this.gbArduino.Controls.Add(this.btnSelectAll);
            this.gbArduino.Controls.Add(this.txtAvgTemperature);
            this.gbArduino.Controls.Add(this.txtAllReceivedData);
            this.gbArduino.Controls.Add(this.btnClearData);
            this.gbArduino.Controls.Add(this.label3);
            this.gbArduino.Controls.Add(this.txtConnectedStatus);
            this.gbArduino.Controls.Add(this.btnBaudRate);
            this.gbArduino.Controls.Add(this.btnGetComPorts);
            this.gbArduino.Controls.Add(this.cbPorts);
            this.gbArduino.Controls.Add(this.cbBaudRate);
            this.gbArduino.Controls.Add(this.btnConnRedBoard);
            this.gbArduino.Location = new System.Drawing.Point(13, 12);
            this.gbArduino.Name = "gbArduino";
            this.gbArduino.Size = new System.Drawing.Size(295, 540);
            this.gbArduino.TabIndex = 36;
            this.gbArduino.TabStop = false;
            this.gbArduino.Text = "Sensor controller connection";
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.Location = new System.Drawing.Point(6, 377);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(130, 23);
            this.btnDeselectAll.TabIndex = 39;
            this.btnDeselectAll.Text = "Deselect All";
            this.btnDeselectAll.UseVisualStyleBackColor = true;
            this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 39);
            this.label2.TabIndex = 38;
            this.label2.Text = "Select or deselect cells for calculation of average \r\ntemperature by clicking on " +
    "them. \r\nOr use \"Select All\" or \"Deselect All\" buttons.";
            // 
            // btnAvgTemperature
            // 
            this.btnAvgTemperature.Location = new System.Drawing.Point(6, 319);
            this.btnAvgTemperature.Name = "btnAvgTemperature";
            this.btnAvgTemperature.Size = new System.Drawing.Size(130, 23);
            this.btnAvgTemperature.TabIndex = 32;
            this.btnAvgTemperature.Text = "Average Temperature";
            this.btnAvgTemperature.UseVisualStyleBackColor = true;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(6, 348);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(130, 23);
            this.btnSelectAll.TabIndex = 30;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // txtAvgTemperature
            // 
            this.txtAvgTemperature.Location = new System.Drawing.Point(142, 321);
            this.txtAvgTemperature.Name = "txtAvgTemperature";
            this.txtAvgTemperature.Size = new System.Drawing.Size(145, 20);
            this.txtAvgTemperature.TabIndex = 29;
            this.txtAvgTemperature.Text = "0.00";
            this.txtAvgTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAllReceivedData
            // 
            this.txtAllReceivedData.Location = new System.Drawing.Point(6, 132);
            this.txtAllReceivedData.Multiline = true;
            this.txtAllReceivedData.Name = "txtAllReceivedData";
            this.txtAllReceivedData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAllReceivedData.Size = new System.Drawing.Size(237, 130);
            this.txtAllReceivedData.TabIndex = 26;
            // 
            // btnClearData
            // 
            this.btnClearData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnClearData.Location = new System.Drawing.Point(249, 132);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(37, 130);
            this.btnClearData.TabIndex = 22;
            this.btnClearData.Text = "C\r\nl\r\ne\r\na\r\nr";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "All Received Data";
            // 
            // txtConnectedStatus
            // 
            this.txtConnectedStatus.BackColor = System.Drawing.Color.Red;
            this.txtConnectedStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtConnectedStatus.Location = new System.Drawing.Point(142, 81);
            this.txtConnectedStatus.Name = "txtConnectedStatus";
            this.txtConnectedStatus.ReadOnly = true;
            this.txtConnectedStatus.Size = new System.Drawing.Size(145, 20);
            this.txtConnectedStatus.TabIndex = 15;
            this.txtConnectedStatus.Text = "Not Connected";
            this.txtConnectedStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnBaudRate
            // 
            this.btnBaudRate.Location = new System.Drawing.Point(6, 51);
            this.btnBaudRate.Name = "btnBaudRate";
            this.btnBaudRate.Size = new System.Drawing.Size(130, 23);
            this.btnBaudRate.TabIndex = 14;
            this.btnBaudRate.Text = "Baud Rate";
            this.btnBaudRate.UseVisualStyleBackColor = true;
            // 
            // btnGetComPorts
            // 
            this.btnGetComPorts.Location = new System.Drawing.Point(6, 22);
            this.btnGetComPorts.Name = "btnGetComPorts";
            this.btnGetComPorts.Size = new System.Drawing.Size(130, 23);
            this.btnGetComPorts.TabIndex = 0;
            this.btnGetComPorts.Text = "Get COM ports";
            this.btnGetComPorts.UseVisualStyleBackColor = true;
            this.btnGetComPorts.Click += new System.EventHandler(this.btnGetComPorts_Click);
            // 
            // cbPorts
            // 
            this.cbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPorts.FormattingEnabled = true;
            this.cbPorts.Location = new System.Drawing.Point(142, 22);
            this.cbPorts.Name = "cbPorts";
            this.cbPorts.Size = new System.Drawing.Size(145, 21);
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
            this.cbBaudRate.Location = new System.Drawing.Point(142, 51);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(145, 21);
            this.cbBaudRate.TabIndex = 13;
            // 
            // btnConnRedBoard
            // 
            this.btnConnRedBoard.Location = new System.Drawing.Point(6, 80);
            this.btnConnRedBoard.Name = "btnConnRedBoard";
            this.btnConnRedBoard.Size = new System.Drawing.Size(130, 23);
            this.btnConnRedBoard.TabIndex = 3;
            this.btnConnRedBoard.Text = "Connect to Board";
            this.btnConnRedBoard.UseVisualStyleBackColor = true;
            this.btnConnRedBoard.Click += new System.EventHandler(this.btnConnRedBoard_Click);
            // 
            // gbTemperatures
            // 
            this.gbTemperatures.Location = new System.Drawing.Point(314, 12);
            this.gbTemperatures.Name = "gbTemperatures";
            this.gbTemperatures.Size = new System.Drawing.Size(225, 540);
            this.gbTemperatures.TabIndex = 37;
            this.gbTemperatures.TabStop = false;
            this.gbTemperatures.Text = "Temperature Visualization";
            this.gbTemperatures.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gbTemperatures_MouseClick);
            this.gbTemperatures.Paint += new System.Windows.Forms.PaintEventHandler(this.gbTemperatures_Paint);
            // 
            // ArrayMLX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 561);
            this.Controls.Add(this.gbTemperatures);
            this.Controls.Add(this.gbArduino);
            this.MinimumSize = new System.Drawing.Size(565, 600);
            this.Name = "ArrayMLX";
            this.Text = "Array MLX Sensor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ArraySensor_FormClosing);
            this.gbArduino.ResumeLayout(false);
            this.gbArduino.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbArduino;
        private System.Windows.Forms.Button btnClearData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConnectedStatus;
        private System.Windows.Forms.Button btnBaudRate;
        private System.Windows.Forms.Button btnGetComPorts;
        private System.Windows.Forms.ComboBox cbPorts;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.Button btnConnRedBoard;
        private System.Windows.Forms.TextBox txtAllReceivedData;
        private System.Windows.Forms.TextBox txtAvgTemperature;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.GroupBox gbTemperatures;
        private System.Windows.Forms.Button btnDeselectAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAvgTemperature;
    }
}

