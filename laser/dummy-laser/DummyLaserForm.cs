using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseLaser;

namespace DummyLaser
{
    public partial class DummyLaserForm : Form, ILaser
    {
        private bool _initialized = false;
        private bool _laserOn = false;
        private double _power = 0;

        private double _minPower = 0.5;
        /// <summary>
        /// Property to keep minimum power that can be set to laser.
        /// </summary>
        public double MinPower
        {
            get { return _minPower; }
            set
            {
                _minPower = value;
                nudMinPower.Value = (decimal)_minPower;
            }
        }

        private double _maxPower = 3;
        /// <summary>
        /// Property to keep maximum power that can be set to laser.
        /// </summary>
        public double MaxPower
        {
            get { return _maxPower; }
            set
            {
                _maxPower = value;
                nudMaxPower.Value = (decimal)_maxPower;
            }
        }

        /// <summary>
        /// Laser initialization
        /// </summary>
        /// <returns></returns>
        public bool Initialize()
        {
            if (_initialized)
            {
                _initialized = false;
                txtInitStatus.BackColor = Color.Red;
                txtInitStatus.Text = "Laser Not Initialized";
                btnInitialize.Text = "Initialize Laser";
            }
            else
            {
                _initialized = true;
                txtInitStatus.BackColor = Color.Green;
                txtInitStatus.Text = "Laser Initialized";
                btnInitialize.Text = "Disconnect";
            }
            return _initialized;
        }

        /// <summary>
        /// Sets the power in relative units. 
        /// </summary>
        /// <param name="power">Must be in [0, 1] according to ILaser.</param>
        public void SetPower(double power)
        {
            if (power > 1.0)
                power = 1.0;
            if (power < 0.0)
                power = 0.0;
            _power = MinPower + (MaxPower - MinPower) * power;
        }

        /// <summary>
        /// Returns the power that is set to laser.
        /// </summary>
        /// <returns></returns>
        public double GetPower()
        {
            return _power;
        }

        /// <summary>
        /// Switches laser beam on with the set power.
        /// </summary>
        /// <returns>False if laser is not initalized or something went wrong.</returns>
        public bool SwitchOn()
        {
            if (_initialized)
            {
                _laserOn = true;
                txtLaserSwitch.Text = "On with power: " + GetPower().ToString("F2");
                txtLaserSwitch.BackColor = Color.Green;
                btnSwitchLaser.Text = "Switch Laser Off";
                return true;
            }
            return false;
        }

        /// <summary>
        /// Switches laser off if it was switched on.
        /// </summary>
        /// <returns></returns>
        public bool SwitchOff()
        {
            if (_laserOn)
            {
                _laserOn = false;
                txtLaserSwitch.Text = "Laser Off";
                txtLaserSwitch.BackColor = Color.Red;
                btnSwitchLaser.Text = "Switch Laser On";
                return true;
            }
            return false;
        }

        public DummyLaserForm()
        {
            InitializeComponent();
        }

        private void nudMinPower_ValueChanged(object sender, EventArgs e)
        {
            MinPower = (double)nudMinPower.Value;
        }

        private void nudMaxPower_ValueChanged(object sender, EventArgs e)
        {
            MaxPower = (double)nudMaxPower.Value;
        }

        private void nudPower_ValueChanged(object sender, EventArgs e)
        {
            if (nudPower.Value < (decimal)MinPower)
                nudPower.Value = (decimal)MinPower;
            if (nudPower.Value > (decimal)MaxPower)
                nudPower.Value = (decimal)MaxPower;
            // Directly set power as this is not relative
            _power = (double)nudPower.Value;
            if (_laserOn)
                txtLaserSwitch.Text = "On with power: " + GetPower().ToString("F2");
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            Initialize();
        }

        private void btnSwitchLaser_Click(object sender, EventArgs e)
        {
            if (_laserOn)
            {
                SwitchOff();
            }
            else
            {
                SwitchOn();
            }
        }
    }
}
