using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace ControlledPTT.Sensors
{
    public partial class MLXSensor : BaseSensor
    {
        // Com port connection.
        private SerialPort _comPort = null;

        // String to keep recieved data.
        private string _receivedData = string.Empty;

        // Variable indicating if connection is open.
        private bool _comConnected = false; 

        private List<double> _objectTemperatures = new List<double>();

        private List<double> _ambientTemperatures = new List<double>();

        // Methods to be overriden from BaseSensor
        public override string Title { get { return "One MLX Sensor"; } }

        protected override double GetTemperature() 
        {
            if (_objectTemperatures.Count == 0) return 0;
            return _objectTemperatures.Sum() / _objectTemperatures.Count; 
        }

        public MLXSensor()
        {
            InitializeComponent();

            GetComPorts();
            if (Properties.Settings.Default.ComPortIndex < cbPorts.Items.Count)
                cbPorts.SelectedIndex = Properties.Settings.Default.ComPortIndex;
            cbBaudRate.SelectedIndex = Properties.Settings.Default.BaudRateIndex;
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            while (_comPort.BytesToRead > 0)  // Reads all available serial input.
                                              // Without this there will be a lag displaying the data.
            {
                try
                {
                    _receivedData = _comPort.ReadLine(); // ReadExisting();
                                                                // One line must contain "object_temperature ambient_temperature" in Celcius.
                    Invoke(new EventHandler(processData)); // Process recieved temperatures.
                }
                catch
                {
                    // Something happened during data receive - ignore.
                }
            }                     
        }

        private void btnGetComPorts_Click(object sender, EventArgs e)
        {
            GetComPorts();
        }

        private void GetComPorts()
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
                if (cbPorts.Items.Count == 0)
                    return;

                var portName = cbPorts.SelectedItem.ToString();

                try
                {
                    _comPort = new SerialPort(portName, Convert.ToInt32(cbBaudRate.SelectedItem));
                    _comPort.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
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

        private void processData(object sender, EventArgs e)
        {

            txtAllRecievedData.AppendText(_receivedData);
            txtAllRecievedData.ScrollToCaret();

            var temperatures = _receivedData.Split(' ');
            txtObjTemp.Text = temperatures[0];
            txtAmbTemp.Text = temperatures[1];

            double objectTemperature = double.NaN;
            double ambientTemperature = double.NaN;

            try
            {
                objectTemperature = double.Parse(temperatures[0], NumberStyles.Any, CultureInfo.InvariantCulture);
                ambientTemperature = double.Parse(temperatures[1], NumberStyles.Any, CultureInfo.InvariantCulture);
            }
            catch { /* Ignore parsing errors */ }

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

        private void OneMLXForm_FormClosing(object sender, FormClosingEventArgs e)
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
