﻿using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using BaseSensor;
using System.Globalization;

namespace TwoMlxSensors

{
    public partial class TwoMlxSensorsForm : BaseSensorForm
    {
        private SerialPort _comPort = null; // COM port connection.

        private bool _comConnected = false; // Variable indicating if connection is open.

        private string _receivedData = string.Empty;

        private double _objectTemperature = 0.0;

        private double _ambientTemperature = 0.0;

        public TwoMlxSensorsForm()
        {
            InitializeComponent();

            cbBaudRate.SelectedIndex = 6;
            GetComPorts();
        }

        private void btnGetComPorts_Click(object sender, EventArgs e)
        {
            GetComPorts();
        }

        void GetComPorts()
        {
            cbPorts.Items.Clear();
            var comPortNames = SerialPort.GetPortNames();
            if (comPortNames.Length > 0)
            {
                cbPorts.Items.AddRange(comPortNames);
                cbPorts.SelectedIndex = 0;
            }
        }

        private void btnConnBoard_Click(object sender, EventArgs e)
        {
            if (!_comConnected)
            {
                // Try to connect to board on the selected COM port.
                if (cbPorts.Items.Count == 0)
                    return;

                var portName = cbPorts.SelectedItem.ToString();

                try
                {
                    _comPort = new SerialPort(portName, Convert.ToInt32(cbBaudRate.SelectedItem));
                    _comPort.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                    _comPort.Open();
                }
                catch (System.IO.IOException ex)
                {
                    MessageBox.Show(ex.Message,
                        "Something went wrong. Check no other app is connected to " + portName + ".",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                btnConnBoard.Text = "Disconnect";
                txtConnectedStatus.Text = "Connected";
                txtConnectedStatus.BackColor = Color.Green;
                _comConnected = true;
            }
            else
            {
                // Disconnect from open COM port.
                if (!_comPort.IsOpen)
                {
                    throw new ArgumentException("The Com Port is not open!");
                }
                _comPort.Close();
                _comPort = null;
                btnConnBoard.Text = "Connect";
                txtConnectedStatus.Text = "Not Connected";
                txtConnectedStatus.BackColor = Color.Red;
                _comConnected = false;
            }
        }

        private void btnClearData_Click(object sender, EventArgs e)
        {
            txtAllRecievedData.Clear();
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            while (_comPort.BytesToRead > 0) // Reads all available serial input.
                                             // Without this there will be a lag displaying the data.
            {
                try
                {
                    _receivedData = _comPort.ReadLine(); // One line must contain all the temperatures measured in Celcius.

                    Invoke(new EventHandler(ProcessData)); // Process received temperatures.
                }
                catch
                {
                    // Some error happened while receiving data - ignore.
                }
            }
        }

        private void ProcessData(object sender, EventArgs e)
        {
            txtAllRecievedData.AppendText(_receivedData);
            txtAllRecievedData.ScrollToCaret();

            var temperatures = _receivedData.Split(' ');
            txtObj1Temp.Text = temperatures[0];
            txtAmb1Temp.Text = temperatures[1];
            txtObj2Temp.Text = temperatures[2];
            txtAmb2Temp.Text = temperatures[3];

            // Calculate average temperature from two sensors.
            _objectTemperature = 0.5 * (double.Parse(temperatures[0]) + double.Parse(temperatures[2]));
            _ambientTemperature = 0.5 * (double.Parse(temperatures[1]) + double.Parse(temperatures[3]));

            // Temperature to be sent by BaseSensor
            _temperature = _objectTemperature;
        }

        private void TwoMlxSensorsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_comPort != null)
            {
                if (_comPort.IsOpen)
                {
                    _comPort.Close();
                    _comPort = null;
                }
            }
        }
    }
}
