using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlledPTT.Lasers
{
    public partial class BaseLaser : Form
    {
        public BaseLaser()
        {
            InitializeComponent();
        }

        private void BaseLaser_FormClosing(object sender, FormClosingEventArgs e)
        {
            SwitchOff();
            DisconnectLaser();
        }

        /// <summary>
        /// Gets the title of the laser to be displayed in the App's 
        /// dropdown list for selection.
        /// </summary>
        public virtual string Title { get { throw new NotImplementedException(); } }

        /// <summary>
        /// Sets the maximum power that can be directed to laser. 
        /// The value depends on the particular laser control implementation.
        /// It can be current for example.
        /// </summary>
        public virtual double MinPower 
        { 
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Sets the maximum power that can be directed to laser. 
        /// The value depends on the particular laser control implementation.
        /// It can be current for example.
        /// </summary>
        public virtual double MaxPower 
        { 
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Initializes a connection to Laser hardware.
        /// </summary>
        /// <returns>False if initalizetion failed</returns>
        public virtual bool InitializeLaser() { throw new NotImplementedException(); }

        /// <summary>
        /// Checks if a conntection to Laser hardware was initialized.
        /// </summary>
        /// <returns></returns>
        public virtual bool IsLaserInitialized() { throw new NotImplementedException(); }

        /// <summary>
        /// Sets the power of the laser. It can be value for current for power
        /// supply for example.
        /// </summary>
        /// <param name="power">Must be in [0, 1]</param>
        public virtual void SetPower(double power) { throw new NotImplementedException(); }

        /// <summary>
        /// Gets the current laser power in the range [MinPower, MaxPower]
        /// </summary>
        /// <returns></returns>
        public virtual double GetPower() { throw new NotImplementedException(); }

        /// <summary>
        /// Switches laser beam on.
        /// </summary>
        /// <returns>False if switching on failed.</returns>
        public virtual bool SwitchOn() { throw new NotImplementedException(); }

        /// <summary>
        /// Switches laser beam off.
        /// </summary>
        /// <returns>False if switching off failed.</returns>
        public virtual bool SwitchOff() { throw new NotImplementedException(); }

        /// <summary>
        /// Releases the connection to laser hardware, which was established in InitializeLaser method.
        /// </summary>
        public virtual void DisconnectLaser() { throw new NotImplementedException(); }
    }
}
