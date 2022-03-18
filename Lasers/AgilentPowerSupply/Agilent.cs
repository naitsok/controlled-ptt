using Agilent.CommandExpert.ScpiNet.AgN5700_A_04_00;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ControlledPTT.Lasers
{
    /// <summary>
    /// Agilent power supply is connected to laser. The control of power is through
    /// control of the current given to laser. Tested with Agilent AgN5768A power supply.
    /// NOTE: Not fully tested with a real equipment. Only tested with Agilent N5768A supply.
    /// That the it connects, initalizes. No laser was connected to Agilent.
    /// </summary>
    public partial class Agilent : BaseLaser
    {
        private AgN5700 _agilent = null;

        /// <summary>
        /// Overridden from BaseLaser
        /// </summary>
        public override string Title { get { return "Laser Connected to Agilent"; } }

        // With Agilent the laser power is controlled trough current in [A].
        private double _minCurrent = 0; // [A]
        /// <summary>
        /// Property to keep minimum power that can be set to laser.
        /// </summary>
        public override double MinPower
        {
            get { return _minCurrent; }
            set
            {
                _minCurrent = value;
                nudMinCurrent.Value = (decimal)_minCurrent;
            }
        }

        // With Agilent the laser power is controlled trough current in [A].
        private double _maxCurrent = 1.2; // [A]
        /// <summary>
        /// Property to keep maximum power that can be set to laser.
        /// </summary>
        public override double MaxPower
        {
            get { return _maxCurrent; }
            set
            {
                _maxCurrent = value;
                nudMaxCurrent.Value = (decimal)_maxCurrent;
            }
        }

        // Keeps Agilent initialization
        private bool _initialized = false;
        /// <summary>
        /// Laser initialization. In this case it is Agilent power supply initialize.
        /// </summary>
        /// <returns></returns>
        public override bool InitializeLaser()
        {
            if (!_initialized)
            {
                if (_agilent == null)
                {
                    try
                    {
                        _agilent = new AgN5700(cmbAgilentConnAddress.SelectedItem.ToString());
                        _agilent.Connect();
                    }
                    catch
                    {
                        MessageBox.Show("Could not connect to Agilent. Check if it connected via USB and switched on.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    _initialized = true;
                }

                // Check if it Agilent is indeed initialized.
                if (IsLaserInitialized())
                {
                    btnInitialize.Text = "Disconnect from Agilent";
                    txtInitStatus.Text = "Connected to Agilent";
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
            if (_agilent == null)
                _initialized = false;

            if (_initialized)
            {
                // send a query to Agilent
                string agResponse = "";
                try
                {
                    _agilent.SCPI.IDN.Query(out agResponse);
                }
                catch
                {
                    _initialized = false;
                }
                if (!string.IsNullOrWhiteSpace(agResponse))
                    _initialized = true;
                else
                    _initialized = false;

                if (!_initialized)
                {
                    // Something happened. Try to switch current off and disconnect.
                    try
                    {
                        _agilent.SCPI.OUT.Command(0);
                        _agilent.Disconnect();
                    }
                    catch { }
                    _currentOn = false;
                    MessageBox.Show("An error occured while sending command to Agilent. Please check if it is connected and initialize the Agilent again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAgilentSwitch.Text = "Output Off";
                    txtAgilentSwitch.BackColor = Color.Red;
                    btnSwitchAgilent.Text = "Switch Output On";
                    txtInitStatus.Text = "Laser Not Initialized";
                    txtInitStatus.BackColor = Color.Red;
                    btnInitialize.Text = "Initialize";
                }
            }

            return _initialized;
        }

        private double _current = 0; // 0 to 1
        /// <summary>
        /// Sets the power in relative units from 0 to 1. In case of Agilent, 
        /// this value is converted to current in [A] which is set by the power supply in the indicated MinPower and MaxPower limits.
        /// </summary>
        /// <param name="power">Must be in [0, 1] according to BaseLaser.</param>
        public override void SetPower(double power)
        {
            if (power > 1.0)
                power = 1.0;
            if (power < 0.0)
                power = 0.0;
            _current = MinPower + (MaxPower - MinPower) * power;
            nudOutputCurrent.Value = (decimal)_current;
            if (IsLaserInitialized())
            {
                SetAgilentLimits();
            }
            if (_currentOn)
                txtAgilentSwitch.Text = "Output On";
        }

        /// <summary>
        /// Returns the power that is set to laser.
        /// </summary>
        /// <returns></returns>
        public override double GetPower()
        {
            if (_currentOn)
            {
                string voltageNow = "0";
                string currentNow = "0";
                try
                {
                    _agilent.SCPI.VOUT.Query(out voltageNow);
                    _agilent.SCPI.IOUT.Query(out currentNow);

                    currentNow = currentNow.Split(' ')[1];
                    voltageNow = voltageNow.Split(' ')[1];

                    txtCurrentNow.Text = currentNow;
                    txtVoltageNow.Text = voltageNow;
                }
                catch 
                { 
                    // Ignore errors to continue experiment
                }
                return Convert.ToDouble(currentNow, CultureInfo.InvariantCulture);
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
            if (SetAgilentLimits())
            {
                try
                {
                    _agilent.SCPI.OUT.Command(1);
                }
                catch
                {
                    MessageBox.Show("An error occured while sending command to Agilent to swith output on. Please try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                _currentOn = true;
                txtAgilentSwitch.Text = "Output On";
                txtAgilentSwitch.BackColor = Color.Green;
                btnSwitchAgilent.Text = "Switch Output Off";
                return true;
            }
            return false;
        }

        /// <summary>
        /// Switches laser off if it was switched on.
        /// </summary>
        /// <returns></returns>
        public override bool SwitchOff()
        {
            if (_currentOn)
            {
                try
                {
                    _agilent.SCPI.OUT.Command(0);
                }
                catch { }
                finally
                {
                    // try switch on once again
                    try
                    {
                        _agilent.SCPI.OUT.Command(0);
                    }
                    catch
                    {
                        MessageBox.Show("An error occured while sending command to Agilent to swith output off. Please try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                _currentOn = false;
                txtAgilentSwitch.Text = "Output Off";
                txtAgilentSwitch.BackColor = Color.Red;
                btnSwitchAgilent.Text = "Switch Output On";
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
                try
                {
                    _agilent.Disconnect();
                }
                catch
                {
                    MessageBox.Show("An error occured while sending command to Agilent to diconnect. Please try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                _initialized = false;
                txtInitStatus.Text = "Laser Not Initialized";
                txtInitStatus.BackColor = Color.Red;
                btnInitialize.Text = "Initialize";
            }
        }

        /// <summary>
        /// Sets the current and voltage limits for Agilent.
        /// </summary>
        private bool SetAgilentLimits()
        {
            if (IsLaserInitialized())
            {
                try
                {
                    _agilent.SCPI.VMAX.Command(Convert.ToDouble(nudMaxVoltage.Value));
                    _agilent.SCPI.IMAX.Command(Convert.ToDouble(nudMaxCurrent.Value));
                    _agilent.SCPI.VSET.Command(Convert.ToDouble(nudOutputVoltage.Value));
                    _agilent.SCPI.ISET.Command(Convert.ToDouble(nudOutputCurrent.Value));
                    return true;
                }
                catch
                {
                    // Ignore error message if the current is on to continue with experiment
                    if (!_currentOn)
                        MessageBox.Show("Something happened during sending limits to Agilent. Please try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return false;
        }

        public Agilent()
        {
            InitializeComponent();
            cmbAgilentConnAddress.Items.AddRange(Properties.Settings.Default.AgilentConnectionAddresses);
            cmbAgilentConnAddress.SelectedIndex = Properties.Settings.Default.AgilentConnectionAddressIndex;
        }

        private void cmbAgilentConnAddress_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(cmbAgilentConnAddress.Text))
                return;

            bool isInAddresses = false;
            foreach (object item in cmbAgilentConnAddress.Items)
            {
                if (item.ToString() == cmbAgilentConnAddress.Text)
                {
                    isInAddresses = true;
                    break;
                }
            }

            if (!isInAddresses)
            {
                cmbAgilentConnAddress.Items.Add(cmbAgilentConnAddress.Text);
                cmbAgilentConnAddress.SelectedIndex = cmbAgilentConnAddress.Items.Count - 1;
            } 

        }

        private void cmbAgilentConnAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                // User pressed "Enter". Add new address.
                cmbAgilentConnAddress_Leave(sender, e);
            }
        }

        private void btnRemoveAddress_Click(object sender, EventArgs e)
        {
            int selectedIndex = cmbAgilentConnAddress.SelectedIndex;
            cmbAgilentConnAddress.Items.RemoveAt(selectedIndex);
            cmbAgilentConnAddress.SelectedIndex = selectedIndex - 1;
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            if (_initialized)
                DisconnectLaser();
            else
                InitializeLaser();
        }

        private void btnSwitchAgilent_Click(object sender, EventArgs e)
        {
            if (_currentOn)
                SwitchOff();
            else
                SwitchOn();
        }

        private void nudOutputCurrent_ValueChanged(object sender, EventArgs e)
        {
            SetAgilentLimits();
        }

        private void nudOutputVoltage_ValueChanged(object sender, EventArgs e)
        {
            SetAgilentLimits();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            
            Close();
        }

        private void Agilent_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.AgilentConnectionAddressIndex = cmbAgilentConnAddress.SelectedIndex;
            List<string> addresses = new List<string>();
            foreach (object item in cmbAgilentConnAddress.Items)
                addresses.Add(item.ToString());
            Properties.Settings.Default.AgilentConnectionAddresses = addresses.ToArray();
            Properties.Settings.Default.Save();

            DisconnectLaser();
        }
    }
}
