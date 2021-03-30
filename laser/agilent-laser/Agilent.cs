using Agilent.CommandExpert.ScpiNet.AgN5700_A_04_00;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ControlledPTT.Lasers
{
    /// <summary>
    /// Agilent power supply is connected to laser. The control of power is through
    /// control of the current given to laser. Tested with Agilent AgN5768A power supply.
    /// NOTE: not fully tested with a real equipment.
    /// </summary>
    public partial class Agilent : BaseLaser
    {
        // Connection to Agilent power supply
        private string _agilentConnString = "USB0::0x0957::0x0807::US08M3130G::0::INSTR";

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
                    _agilent = new AgN5700(_agilentConnString);
                }

                try
                {
                    _agilent.Connect();
                }
                catch
                {
                    MessageBox.Show("Could not connect to Agilent. Check if it connected via USB and switched on.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                _initialized = true;

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

        private double _current = 0; // [A]
        /// <summary>
        /// Sets the power in relative units. In case of Agilent, it is current in [A] which is set.
        /// </summary>
        /// <param name="power">Must be in [0, 1] according to ILaser.</param>
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

                    txtCurrentNow.Text = currentNow.Split(' ')[1];
                    txtVoltageNow.Text = voltageNow.Split(' ')[1];
                }
                catch 
                { 
                    // Ignore errors to continue experiment
                }
                return Convert.ToDouble(currentNow);
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

        public Agilent()
        {
            InitializeComponent();
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

        
    }
}
