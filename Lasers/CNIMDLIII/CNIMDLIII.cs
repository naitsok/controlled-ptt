using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ControlledPTT.Lasers
{
    /// <summary>
    /// Operates CNI Laser PSU-III-LED laser or similar. Uses the calibrations for correctly setting the power 
    /// depending on the used collimator.
    /// </summary>
    public partial class CNIMDLIII : BaseLaser
    {
        // Internal calibration that converts power in mW to current in A, when the power value
        // is sent to the laser controller
        // current [A] = internalIntercept + internalSlope * power [mW]
        private double _internalIntercept = 0.28916859; // [A]
        private double _internalSlope = 0.00105531; // [A]/[mW]

        private double InternalPowerCurrent(double power)
        {
            return _internalIntercept + _internalSlope * power;
        }

        private double InternalCurrentToPower(double current)
        {
            double power = (current - _internalIntercept) / _internalSlope;
            if (power < MinPower) 
                power = MinPower;
            if (power > MaxPower)
                power = MaxPower;
            return power;
        }

        // Vars to keep the real calibration loaded from the laser_calibrations.json file
        // the data in calibration is represented by intercept, slope and data from which they were calculated
        // the only values used is, however, intercept and slope, while the calibration data is for checking only
        // calibration is: power [mW] = intercept + slope * current [A]
        private static readonly string BASE_DIR = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        // private JObject _laserCalibrationsJSON = null;
        private List<LaserCalibration> _laserCalibrations = null;
        private double _calibIntercept = -273.86922; // [mW] from default internal calibration
        private double _calibSlope = 947.49306; // [mW]/[A] from default internal calibration

        private double CurrentToPower(double current)
        {
            double power = _calibIntercept + _calibSlope * current;
            if (power < MinPower)
                power = MinPower;
            if (power > MaxPower)
                power = MaxPower;
            return power;
        }

        private double PowerToCurrent(double power)
        {
            return (power - _calibIntercept) / _calibSlope;
        }

        /// <summary>
        /// Overridden from BaseLaser
        /// </summary>
        public override string Title { get { return "CNI MDL-III Laser"; } }

        private double _minPower = 0; // [mW]
        /// <summary>
        /// Property to keep minimum power that can be set to laser.
        /// </summary>
        public override double MinPower
        {
            get { return _minPower; }
            set
            {
                _minPower = value;

                double minCurrent = InternalPowerCurrent(_minPower);
                nudMinPower.Value = (decimal)_minPower;
                nudMinCurrent.Value = (decimal)minCurrent;

                nudOutputPower.Minimum = (decimal)_minPower;
                nudOutputCurrent.Minimum = (decimal)minCurrent;
            }
        }

        private double _maxPower = 2300; // [mW]
        /// <summary>
        /// Property to keep maximum power that can be set to laser.
        /// </summary>
        public override double MaxPower
        {
            get { return _maxPower; }
            set
            {
                _maxPower = value;

                double maxCurrent = InternalPowerCurrent(_maxPower);
                nudMaxPower.Value = (decimal)_maxPower;
                nudMaxCurrent.Value = (decimal)maxCurrent;

                nudOutputPower.Maximum = (decimal)_maxPower;
                nudOutputCurrent.Maximum = (decimal)maxCurrent;
            }
        }

        // Keeps laser initialization status
        private bool _initialized = false;
        // Keeps laser com port connection
        private SerialPort _laserComPort = null;
        // Keeps the received bytes
        private byte[] _receivedBytes = null;
        // Keeps time of received bytes to combine them
        private int _receivedSecond = -1;
        private int _prevReceivedSecond = -1;

        /// <summary>
        /// Handles the possible received data from the com port.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            while (_laserComPort.BytesToRead > 0)  // Reads all available serial input.
                                                   // Without this there will be a lag displaying the data.
            {
                try
                {
                    _receivedBytes = new byte[_laserComPort.BytesToRead];
                    _laserComPort.Read(_receivedBytes, 0, _laserComPort.BytesToRead);
                    _receivedSecond = DateTime.Now.Second;
                    Invoke(new EventHandler(ProcessData));
                }
                catch
                {
                    // Something happened during data receive - ignore.
                }
            }
        }

        private void ProcessData(object sender, EventArgs e)
        {
            if (_prevReceivedSecond != _receivedSecond)
            {
                txtAllReceivedData.AppendText(System.Environment.NewLine + "[" + DateTime.Now.ToString("T", DateTimeFormatInfo.InvariantInfo) + "] ");
                txtAllReceivedData.ScrollToCaret();
                _prevReceivedSecond = _receivedSecond;
            }
            txtAllReceivedData.AppendText(BitConverter.ToString(_receivedBytes).Replace("-", string.Empty));
            txtAllReceivedData.ScrollToCaret();
        }

        /// <summary>
        /// Laser initialization. In this case it is COM port connection to CNI MDL-III laser.
        /// </summary>
        /// <returns></returns>
        public override bool InitializeLaser()
        {
            if (!_initialized)
            {
                if (_laserComPort == null)
                {
                    var portName = cbPorts.SelectedItem.ToString();
                    try
                    {
                        _laserComPort = new SerialPort(portName, Convert.ToInt32(cbBaudRate.SelectedItem));
                        _laserComPort.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
                        _laserComPort.Open();
                    }
                    catch
                    {
                        MessageBox.Show("Could not connect to CNI MDL-III com port. Check if it connected via USB and switched on.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    _initialized = true;
                }

                // Check if it CNI MDL-III laser is indeed initialized.
                if (IsLaserInitialized())
                {
                    btnInitLaser.Text = "Disconnect Laser";
                    txtInitStatus.Text = "Laser Initialized";
                    txtInitStatus.BackColor = Color.Green;
                }
            }

            return _initialized;
        }

        /// <summary>
        /// Checks laser initialization.
        /// </summary>
        /// <returns></returns>
        public override bool IsLaserInitialized()
        {
            if (_laserComPort == null)
                _initialized = false;

            if(_initialized)
            {
                // Check com port connection
                if (!_laserComPort.IsOpen)
                {
                    // Something happened to the com port connection
                    MessageBox.Show("Could not connect to CNI MDL-III com port. Check if it connected via USB and switched on.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _laserComPort.Close();
                    _laserComPort = null;
                    _initialized = false;
                }
            }

            return _initialized;
        }

        private double _power = 0; // from 0 to 1
        /// <summary>
        /// Sets the power in relative units from 0 to 1. In case of CNI MDL-III laser, this value is recalculated to power in [mW].
        /// Finally the power in [mW] is convered to [A] using the laser calibration and sent as byte data to the laser
        /// controller unit.
        /// </summary>
        /// <param name="power">Must be in [0, 1] according to BaseLaser.</param>
        public override void SetPower(double power)
        {
            if (power > 1.0)
                power = 1.0;
            if (power < 0.0)
                power = 0.0;
            _power = MinPower + (MaxPower - MinPower) * power;
            nudOutputPower.Value = (decimal)_power;
            if (_currentOn)
                txtLaserOutput.Text = "Output On";
        }

        /// <summary>
        /// Sends the power in [mW] to the laser
        /// </summary>
        /// <param name="power"></param>
        public void SendPowerToLaser()
        {
            if (IsLaserInitialized())
            {
                // We need to convert the user set power to the internal calibration power of the laser to 
                // set the correct current for the selected calibration
                double internalPower = InternalCurrentToPower(PowerToCurrent(_power));

                byte[] powerBytes = BitConverter.GetBytes((int)internalPower);
                // Since the are only two bytes needed to set up the power for the laser
                // the only used bytes are [0] and [1] out of total 4 that are used for int
                int checkSum = 0x05 + 0x03 + powerBytes[0] + powerBytes[1];
                // the last byte of the command is the lowest byte of checkSum
                byte[] checkBytes = BitConverter.GetBytes(checkSum);
                _laserComPort.Write(new byte[] { 0x55, 0xAA, 0x05, 0x03, powerBytes[1], powerBytes[0], checkBytes[0] }, 0, 7);
            }
        }

        /// <summary>
        /// Returns the power that is set to laser.
        /// </summary>
        /// <returns></returns>
        public override double GetPower()
        {
            if (_currentOn)
            {
                return _power;
            }
            return 0;
        }

        // Keeps the status of output of Agilent.
        private bool _currentOn = false;
        /// <summary>
        /// Switches laser beam on with the set power.
        /// </summary>
        /// <returns>False if laser is not initalized or something went wrong.</returns>
        public override bool SwitchOn()
        {
            if (IsLaserInitialized())
            {
                _laserComPort.Write(new byte[] { 0x55, 0xAA, 0x03, 0x01, 0x04 }, 0, 5);
                // The sleep is needed in order for the laser to process the switch on command
                // Without sleep the set power command will not do anything
                Thread.Sleep(10);
                SendPowerToLaser();
                _currentOn = true;
                txtLaserOutput.Text = "Output On";
                txtLaserOutput.BackColor = Color.Green;
                btnSwitchLaser.Text = "Switch Output Off";
            }
            return _currentOn;
        }

        /// <summary>
        /// Switches laser off if it was switched on.
        /// </summary>
        /// <returns></returns>
        public override bool SwitchOff()
        {
            if (_currentOn)
            {
                _laserComPort.Write(new byte[] { 0x55, 0xAA, 0x03, 0x00, 0x03 }, 0, 5);
                _currentOn = false;
                txtLaserOutput.Text = "Output Off";
                txtLaserOutput.BackColor = Color.Red;
                btnSwitchLaser.Text = "Switch Output On";
                return true;
            }
            return false;
        }

        /// <summary>
        /// Disconnects for Agilent.
        /// </summary>
        public override void DisconnectLaser()
        {
            if (IsLaserInitialized())
            {
                SwitchOff();
                _laserComPort.Close();
                _laserComPort = null;
                _initialized = false;
                txtInitStatus.Text = "Not Initialized";
                txtInitStatus.BackColor = Color.Red;
                btnInitLaser.Text = "Initialize Laser";
            }
        }

        public CNIMDLIII()
        {
            InitializeComponent();

            // Load com ports
            GetComPorts();
            if (Properties.Settings.Default.LaserComPortIndex < cbPorts.Items.Count)
                cbPorts.SelectedIndex = Properties.Settings.Default.LaserComPortIndex;
            cbBaudRate.SelectedIndex = Properties.Settings.Default.LaserComBaudRateIndex;

            // Load calibrations
            string calibPath = Properties.Settings.Default.LaserCalibrationsPath;
            if (!Path.IsPathRooted(calibPath))
                calibPath = Path.GetFullPath(Path.Combine(BASE_DIR, calibPath));

            // Load settings either saved by user or default ones
            if (File.Exists(calibPath))
            {
                JObject laserCalibs = JObject.Parse(File.ReadAllText(calibPath));
                _laserCalibrations = JsonConvert.DeserializeObject<List<LaserCalibration>>(laserCalibs["laser_calibrations"].ToString());

                // fill the controls
                cbLaserCalibration.Items.AddRange(_laserCalibrations.Select(c => c.name).ToArray());
                // This will also set the slope and intercept for the selected calibration
                if (Properties.Settings.Default.LaserCalibrationIndex < cbLaserCalibration.Items.Count)
                    cbLaserCalibration.SelectedIndex = Properties.Settings.Default.LaserCalibrationIndex;
                // Set the max and min powers
                MaxPower = _laserCalibrations[cbLaserCalibration.SelectedIndex].max_power_mW;
                MinPower = _laserCalibrations[cbLaserCalibration.SelectedIndex].min_power_mW;
            }
            else
            {
                // no calibrations found, the factory ones will be used
                cbLaserCalibration.Items.Add("Nothing found. Factory one will be used.");
            }
            // Set the value of power stored in settings after the calibration was loaded
            nudOutputPower.Value = Properties.Settings.Default.LaserPower;

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

        private void btnGetComPorts_Click(object sender, EventArgs e)
        {
            GetComPorts();
        }

        private void btnInitLaser_Click(object sender, EventArgs e)
        {
            if (IsLaserInitialized())
                DisconnectLaser();
            else
                InitializeLaser();
        }

        private void btnSwitchLaser_Click(object sender, EventArgs e)
        {
            if (_currentOn)
                SwitchOff();
            else
                SwitchOn();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nudOutputPower_ValueChanged(object sender, EventArgs e)
        {
            _power = (double)nudOutputPower.Value;
            if (_power < MinPower)
                _power = MinPower;
            if (_power > MaxPower)
                _power = MaxPower;
            nudOutputPower.Value = (decimal)_power;

            SendPowerToLaser();
        }

        private void nudMaxPower_ValueChanged(object sender, EventArgs e)
        {
            MaxPower = (double)nudMaxPower.Value;
        }

        private void nudMinPower_ValueChanged(object sender, EventArgs e)
        {
            MinPower = (double)nudMinPower.Value;
        }

        private void nudMaxCurrent_ValueChanged(object sender, EventArgs e)
        {
            MaxPower = InternalCurrentToPower((double)nudMaxCurrent.Value);
        }

        private void nudMinCurrent_ValueChanged(object sender, EventArgs e)
        {
            MinPower = InternalCurrentToPower((double)nudMinCurrent.Value);
        }

        private void nudOutputCurrent_ValueChanged(object sender, EventArgs e)
        {
            nudOutputPower.Value = (decimal)InternalCurrentToPower((double)nudOutputCurrent.Value);
        }

        private void cbLaserCalibration_SelectedIndexChanged(object sender, EventArgs e)
        {
            _calibIntercept = _laserCalibrations[cbLaserCalibration.SelectedIndex].intercept;
            _calibSlope = _laserCalibrations[cbLaserCalibration.SelectedIndex].slope;
            MaxPower = _laserCalibrations[cbLaserCalibration.SelectedIndex].max_power_mW;
            MinPower = _laserCalibrations[cbLaserCalibration.SelectedIndex].min_power_mW;
            SendPowerToLaser();
        }

        private void CNIMDLIII_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save the selected settings
            Properties.Settings.Default.LaserCalibrationIndex = cbLaserCalibration.SelectedIndex;
            Properties.Settings.Default.LaserComBaudRateIndex = cbBaudRate.SelectedIndex;
            Properties.Settings.Default.LaserComPortIndex = cbPorts.SelectedIndex;
            Properties.Settings.Default.LaserPower = (decimal)_power;
            Properties.Settings.Default.Save();
        }
    }

    /// <summary>
    /// Stores the calibration data for each type of collimator after loading from JSON file.
    /// </summary>
    public class LaserCalibration
    {
        public string name;
        public double intercept;
        public double slope;
        public double min_power_mW;
        public double max_power_mW;
        public double[] current_A;
        public double[] power_mW;
    }
}
