namespace ControlledPTT.Sensors
{
    partial class MLXSensor
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClearData = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAllRecievedData = new System.Windows.Forms.RichTextBox();
            this.btnAmbTemp = new System.Windows.Forms.Button();
            this.txtAmbTemp = new System.Windows.Forms.TextBox();
            this.btnObjTemp = new System.Windows.Forms.Button();
            this.txtObjTemp = new System.Windows.Forms.TextBox();
            this.txtConnectedStatus = new System.Windows.Forms.TextBox();
            this.btnBaudRate = new System.Windows.Forms.Button();
            this.btnGetComPorts = new System.Windows.Forms.Button();
            this.cbPorts = new System.Windows.Forms.ComboBox();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.btnConnToBoard = new System.Windows.Forms.Button();
            this.gbArduino.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbArduino
            // 
            this.gbArduino.Controls.Add(this.btnClearData);
            this.gbArduino.Controls.Add(this.label3);
            this.gbArduino.Controls.Add(this.txtAllRecievedData);
            this.gbArduino.Controls.Add(this.btnAmbTemp);
            this.gbArduino.Controls.Add(this.txtAmbTemp);
            this.gbArduino.Controls.Add(this.btnObjTemp);
            this.gbArduino.Controls.Add(this.txtObjTemp);
            this.gbArduino.Controls.Add(this.txtConnectedStatus);
            this.gbArduino.Controls.Add(this.btnBaudRate);
            this.gbArduino.Controls.Add(this.btnGetComPorts);
            this.gbArduino.Controls.Add(this.cbPorts);
            this.gbArduino.Controls.Add(this.cbBaudRate);
            this.gbArduino.Controls.Add(this.btnConnToBoard);
            this.gbArduino.Location = new System.Drawing.Point(12, 12);
            this.gbArduino.Name = "gbArduino";
            this.gbArduino.Size = new System.Drawing.Size(260, 269);
            this.gbArduino.TabIndex = 34;
            this.gbArduino.TabStop = false;
            this.gbArduino.Text = "Sensor controller connection";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(18, 287);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 23);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(213, 122);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(41, 84);
            this.btnClearData.TabIndex = 22;
            this.btnClearData.Text = "C\r\nl\r\ne\r\na\r\nr";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "All Received Data";
            // 
            // txtAllRecievedData
            // 
            this.txtAllRecievedData.Location = new System.Drawing.Point(6, 122);
            this.txtAllRecievedData.Name = "txtAllRecievedData";
            this.txtAllRecievedData.Size = new System.Drawing.Size(201, 84);
            this.txtAllRecievedData.TabIndex = 20;
            this.txtAllRecievedData.Text = "";
            // 
            // btnAmbTemp
            // 
            this.btnAmbTemp.Location = new System.Drawing.Point(6, 241);
            this.btnAmbTemp.Name = "btnAmbTemp";
            this.btnAmbTemp.Size = new System.Drawing.Size(112, 23);
            this.btnAmbTemp.TabIndex = 19;
            this.btnAmbTemp.Text = "Ambient Temperature";
            this.btnAmbTemp.UseVisualStyleBackColor = true;
            // 
            // txtAmbTemp
            // 
            this.txtAmbTemp.Location = new System.Drawing.Point(124, 243);
            this.txtAmbTemp.Name = "txtAmbTemp";
            this.txtAmbTemp.ReadOnly = true;
            this.txtAmbTemp.Size = new System.Drawing.Size(130, 20);
            this.txtAmbTemp.TabIndex = 18;
            // 
            // btnObjTemp
            // 
            this.btnObjTemp.Location = new System.Drawing.Point(6, 212);
            this.btnObjTemp.Name = "btnObjTemp";
            this.btnObjTemp.Size = new System.Drawing.Size(112, 23);
            this.btnObjTemp.TabIndex = 17;
            this.btnObjTemp.Text = "Object Temperature";
            this.btnObjTemp.UseVisualStyleBackColor = true;
            // 
            // txtObjTemp
            // 
            this.txtObjTemp.Location = new System.Drawing.Point(124, 214);
            this.txtObjTemp.Name = "txtObjTemp";
            this.txtObjTemp.ReadOnly = true;
            this.txtObjTemp.Size = new System.Drawing.Size(130, 20);
            this.txtObjTemp.TabIndex = 16;
            // 
            // txtConnectedStatus
            // 
            this.txtConnectedStatus.BackColor = System.Drawing.Color.Red;
            this.txtConnectedStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConnectedStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtConnectedStatus.Location = new System.Drawing.Point(127, 82);
            this.txtConnectedStatus.Name = "txtConnectedStatus";
            this.txtConnectedStatus.ReadOnly = true;
            this.txtConnectedStatus.Size = new System.Drawing.Size(127, 20);
            this.txtConnectedStatus.TabIndex = 15;
            this.txtConnectedStatus.Text = "Not Connected";
            this.txtConnectedStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.cbPorts.Size = new System.Drawing.Size(127, 21);
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
            this.cbBaudRate.Size = new System.Drawing.Size(127, 21);
            this.cbBaudRate.TabIndex = 13;
            // 
            // btnConnToBoard
            // 
            this.btnConnToBoard.Location = new System.Drawing.Point(6, 80);
            this.btnConnToBoard.Name = "btnConnToBoard";
            this.btnConnToBoard.Size = new System.Drawing.Size(115, 23);
            this.btnConnToBoard.TabIndex = 3;
            this.btnConnToBoard.Text = "Connect to Board";
            this.btnConnToBoard.UseVisualStyleBackColor = true;
            this.btnConnToBoard.Click += new System.EventHandler(this.btnConnToBoard_Click);
            // 
            // MLXSensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 320);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbArduino);
            this.MinimumSize = new System.Drawing.Size(300, 359);
            this.Name = "MLXSensor";
            this.Text = "One MLX Sensor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OneMLXForm_FormClosing);
            this.gbArduino.ResumeLayout(false);
            this.gbArduino.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbArduino;
        private System.Windows.Forms.TextBox txtConnectedStatus;
        private System.Windows.Forms.Button btnBaudRate;
        private System.Windows.Forms.Button btnGetComPorts;
        private System.Windows.Forms.ComboBox cbPorts;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.Button btnConnToBoard;
        private System.Windows.Forms.Button btnObjTemp;
        private System.Windows.Forms.TextBox txtObjTemp;
        private System.Windows.Forms.Button btnAmbTemp;
        private System.Windows.Forms.TextBox txtAmbTemp;
        private System.Windows.Forms.Button btnClearData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtAllRecievedData;
        private System.Windows.Forms.Button btnClose;
    }
}

