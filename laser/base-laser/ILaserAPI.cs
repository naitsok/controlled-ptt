using System;

namespace BaseLaser
{
    public interface ILaser
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
}
