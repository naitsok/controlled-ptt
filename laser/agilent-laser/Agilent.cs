using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Agilent.CommandExpert.ScpiNet.AgN5700_A_04_00;
using Keysight.CommandExpert.InstrumentAbstraction;

namespace ControlledPTT.Lasers
{
    /// <summary>
    /// Agilent power supply is connected to laser. The control of power is through
    /// control of the current given to laser. Tested with Agilent AgN5768A power supply.
    /// </summary>
    public partial class Agilent : BaseLaser
    {
        string _agilentConnString = "USB0::0x0957::0x0807::US08M3130G::0::INSTR";

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
                _initialized = true;
                txtInitStatus.BackColor = Color.Green;
                txtInitStatus.Text = "Agilent Initialized";
                btnInitialize.Text = "Disconnect";
            }
            return _initialized;
        }

        /// <summary>
        /// Checks laser initialization.
        /// </summary>
        /// <returns></returns>
        public override bool IsLaserInitialized()
        {
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
            if (_currentOn)
                txtAgilentSwitch.Text = "On with current: " + GetPower().ToString("F2") + " A";
        }

        /// <summary>
        /// Returns the power that is set to laser.
        /// </summary>
        /// <returns></returns>
        public override double GetPower()
        {
            if (_currentOn)
                return _current;
            else
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
            if (_initialized)
            {
                _currentOn = true;
                txtAgilentSwitch.Text = "On with current: " + GetPower().ToString("F2") + " A";
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
                _currentOn = false;
                txtAgilentSwitch.Text = "Output Off";
                txtAgilentSwitch.BackColor = Color.Red;
                btnSwitchAgilent.Text = "Switch Output On";
                return true;
            }
            return false;
        }

        public override void DisconnectLaser()
        {
            if (_initialized)
            {
                _initialized = false;
                SwitchOff();
                txtInitStatus.Text = "Laser Not Initialized";
                txtInitStatus.BackColor = Color.Red;
                btnInitialize.Text = "Initialize";
            }
        }

        public Agilent()
        {
            InitializeComponent();
        }
    }
}
