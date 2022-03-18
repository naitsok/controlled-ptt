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

        /// <summary>
        /// Design mode prevents the errors related to throwing the NotImplementedException when designing inherited forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseLaser_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
        }

        /// <summary>
        /// On closing the form for the laser, switch it off and disconnect it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseLaser_FormClosing(object sender, FormClosingEventArgs e)
        {
            SwitchOff();
            DisconnectLaser();
        }

        /// <summary>
        /// Gets the title of the laser to be displayed in the App's 
        /// dropdown list for selection.
        /// </summary>
        public virtual string Title { 
            get 
            {
                if (DesignMode) return "Base Laser";
                throw new NotImplementedException(); 
            } 
        }

        /// <summary>
        /// Sets the maximum power that can be directed to laser. 
        /// The value depends on the particular laser control implementation.
        /// It can be current for example.
        /// </summary>
        public virtual double MinPower 
        { 
            get 
            {
                if (DesignMode) return 0;
                throw new NotImplementedException(); 
            }
            set 
            {
                if (DesignMode) { _ = 0; return; }
                throw new NotImplementedException(); 
            }
        }

        /// <summary>
        /// Sets the maximum power that can be directed to laser. 
        /// The value depends on the particular laser control implementation.
        /// It can be current for example.
        /// </summary>
        public virtual double MaxPower 
        {
            get
            {
                if (DesignMode) return 0;
                throw new NotImplementedException();
            }
            set
            {
                if (DesignMode) { _ = 0; return; }
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Initializes a connection to Laser hardware.
        /// </summary>
        /// <returns>False if initalizetion failed</returns>
        public virtual bool InitializeLaser()
        {
            if (DesignMode) return false;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if a conntection to Laser hardware was initialized.
        /// </summary>
        /// <returns></returns>
        public virtual bool IsLaserInitialized()
        {
            if (DesignMode) return false;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the power of the laser. It can be value for current for power
        /// supply for example.
        /// </summary>
        /// <param name="power">Must be in [0, 1]</param>
        public virtual void SetPower(double power)
        {
            if (DesignMode) return;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the current laser power in the range [MinPower, MaxPower]
        /// </summary>
        /// <returns></returns>
        public virtual double GetPower()
        {
            if (DesignMode) return 0;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Switches laser beam on.
        /// </summary>
        /// <returns>False if switching on failed.</returns>
        public virtual bool SwitchOn()
        {
            if (DesignMode) return false;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Switches laser beam off.
        /// </summary>
        /// <returns>False if switching off failed.</returns>
        public virtual bool SwitchOff() 
        {
            if (DesignMode) return false;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Releases the connection to laser hardware, which was established in InitializeLaser method.
        /// </summary>
        public virtual void DisconnectLaser()
        {
            if (DesignMode) return;
            throw new NotImplementedException();
        }
    }
}
