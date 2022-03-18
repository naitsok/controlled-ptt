using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace ControlledPTT.Sensors

{
    public partial class TwoMLXSensors : BaseSensor
    {
        // COM port connection.
        private SerialPort _comPort = null;

        // Variable indicating if connection is open.
        private bool _comConnected = false; 

        private string _receivedData = string.Empty;

        private List<double> _objectTemperatures = new List<double>();

        private List<double> _ambientTemperatures = new List<double>();

        // Methods to be overridden from BaseSensor
        public override string Title { get { return "Two MLX Sensors"; } }

        protected override double GetTemperature() 
        {
            if (_objectTemperatures.Count == 0) return 0;
            return _objectTemperatures.Sum() / _objectTemperatures.Count; 
        }

        public TwoMLXSensors()
        {
            InitializeComponent();

            GetComPorts();
            if (Properties.Settings.Default.ComPortIndex < cbPorts.Items.Count)
                cbPorts.SelectedIndex = Properties.Settings.Default.ComPortIndex;
            cbBaudRate.SelectedIndex = Properties.Settings.Default.BaudRateIndex;
        }

        private void btnGetComPorts_Click(object sender, EventArgs e)
        {
            GetComPorts();
        }

        void GetComPorts()
        {
            cbPorts.Items.Clear();
            string[] comPortNames = SerialPort.GetPortNames();
            if (comPortNames.Length > 0)
            {
                cbPorts.Items.AddRange(comPortNames);
                cbPorts.SelectedIndex = 0;
            }
        }

        private void btnConnToBoard_Click(object sender, EventArgs e)
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

                btnConnToBoard.Text = "Disconnect";
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
                btnConnToBoard.Text = "Connect";
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

            double objectTemperature = double.NaN;
            double ambientTemperature = double.NaN;

            try
            {
                // Calculate average temperature from two sensors.
                objectTemperature = 0.5 * (double.Parse(temperatures[0]) + double.Parse(temperatures[2]));
                ambientTemperature = 0.5 * (double.Parse(temperatures[1]) + double.Parse(temperatures[3]));
            }
            catch { /* ignore parsing errors */ }

            if (TemperatureJustSent)
            {
                _objectTemperatures = new List<double>();
                _ambientTemperatures = new List<double>();
            }
            _objectTemperatures.Add(objectTemperature);
            _ambientTemperatures.Add(ambientTemperature);
            // TemperatureJustSent is set to true in the BaseSensor class when the temperature 
            // data is sent to App.
            TemperatureJustSent = false;
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
            Properties.Settings.Default.ComPortIndex = cbPorts.SelectedIndex;
            Properties.Settings.Default.BaudRateIndex = cbBaudRate.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
