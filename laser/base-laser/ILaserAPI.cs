using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLaser
{
    [ContractClass(typeof(ILaserAPIContract))]
    public interface ILaserAPI
    {
        /// <summary>
        /// Sets the maximum power that can be directed to laser. 
        /// The value depends on the particular laser control implementation.
        /// It can be current for example.
        /// </summary>
        double MinPower { get; set; }

        /// <summary>
        /// Sets the maximum power that can be directed to laser. 
        /// The value depends on the particular laser control implementation.
        /// It can be current for example.
        /// </summary>
        double MaxPower { get; set; }

        /// <summary>
        /// Initializes a connected laser.
        /// </summary>
        /// <returns>False if initalizetion failed</returns>
        bool Initialize();

        /// <summary>
        /// Sets the power of the laser. It can be value for current for power
        /// supply for example.
        /// </summary>
        /// <param name="power">Must be in [0, 1]</param>
        void SetPower(double power);

        /// <summary>
        /// Gets the current laser power in the range [MinPower, MaxPower]
        /// </summary>
        /// <returns></returns>
        double GetPower();

        /// <summary>
        /// Switches laser beam on.
        /// </summary>
        /// <returns>False if switching on failed.</returns>
        bool SwitchOn();

        /// <summary>
        /// Switches laser beam off.
        /// </summary>
        /// <returns>False if switching off failed.</returns>
        bool SwitchOff();

    }

    /// <summary>
    /// ILaserAPIContract class implements constraints for the ILaserAPI interface.
    /// </summary>
    [ContractClassFor(typeof(ILaserAPI))]
    internal abstract class ILaserAPIContract : ILaserAPI
    {
        double ILaserAPI.MinPower
        {
            get { return default(double); }
            set
            {
                Contract.Requires(value >= 0.0);
            }
        }

        double ILaserAPI.MaxPower
        {
            get { return default(double); }
            set
            {
                Contract.Requires(value > 0.0);
            }
        }

        bool ILaserAPI.Initialize() { return default(bool); }

        void ILaserAPI.SetPower(double power)
        {
            Contract.Requires(power >= 0.0 && power <= 1.0);
        }

        double ILaserAPI.GetPower() { return default(double); }

        bool ILaserAPI.SwitchOn() { return default(bool); }

        bool ILaserAPI.SwitchOff() { return default(bool); }
    }
}
