using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseSensor;

namespace OneMlxSensor
{
    public partial class OneMLXForm : BaseSensorForm
    {
        private SerialPort _comPort = null; // Com port connection.

        private string _receivedData = string.Empty; // String to keep recieved data.

        private bool _comConnected = false; // Variable indicating if connection is open.

        private double _objectTemperature = 0.0;

        private double _ambientTemperature = 0.0;

        private Timer _sendTimer = new Timer()
        {
            Interval = 1000
        };

        public OneMLXForm()
        {
            InitializeComponent();

            cbBaudRate.SelectedIndex = 6;
            getComPorts();
            _sendTimer.Tick += new EventHandler(this.sendDataTimer_Tick);
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
                _sendTimer.Start();
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
                _sendTimer.Stop();
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
        private void sendDataTimer_Tick(object sender, EventArgs e)
        {
            SendTemperature(_objectTemperature);
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
