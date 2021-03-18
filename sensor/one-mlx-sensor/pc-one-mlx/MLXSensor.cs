using System;
using System.Drawing;
using System.IO.Ports;
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

        private double _objectTemperature = 0.0;

        private double _ambientTemperature = 0.0;

        // Methods to be overriden from BaseSensor
        public override string Title { get { return "One MLX Sensor"; } }

        protected override double GetTemperature() { return _objectTemperature; }

        public MLXSensor()
        {
            InitializeComponent();

            cbBaudRate.SelectedIndex = 6;
            getComPorts();
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            while (_comPort.BytesToRead > 0)  // Reads all available serial input.
                                              // Without this there will be a lag displaying the data.
            {
                try
                {
                    string _recievedData = _comPort.ReadLine(); // ReadExisting();
                                                                // One line must contain "object_temperature ambient_temperature" in Celcius.
                    Invoke(new EventHandler(processData)); // Process recieved temperatures.
                }
                catch
                {
                    // Somethign happened during data receive - ignore.
                }
            }                     
        }

        private void btnGetComPorts_Click(object sender, EventArgs e)
        {
            getComPorts();
        }

        private void getComPorts()
        {
            cbPorts.Items.Clear();
            var comPortNames = SerialPort.GetPortNames();
            if (comPortNames.Length > 0)
            {
                cbPorts.Items.AddRange(comPortNames);
                cbPorts.SelectedIndex = 0;
            }
        }

        private void btnConnRedBoard_Click(object sender, EventArgs e)
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
                btnConnBoard.Text = "Disconnect";
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

        private void processData(object sender, EventArgs e)
        {

            txtAllRecievedData.AppendText(_receivedData);
            txtAllRecievedData.ScrollToCaret();

            var temperatures = _receivedData.Split(' ');
            txtObjTemp.Text = temperatures[0];
            txtAmbTemp.Text = temperatures[1];

            _objectTemperature = double.Parse(temperatures[0]);
            _ambientTemperature = double.Parse(temperatures[1]);

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
        }
    }
}
