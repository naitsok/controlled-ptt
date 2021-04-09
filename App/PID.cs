using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlledPTT
{
    class PID
    {
        #region Fields

        //Running Values
        private DateTime _lastUpdate;
        private double _lastInput;
        private double _errSum;

        #endregion

        #region Properties

        // Gains
        public double PropGain { get; set; }
        public double IntGain { get; set; }
        public double DiffGain { get; set; }

        // Max/Min Calculation
        public double InputMin { get; set; }
        public double InputMax { get; set; }
        public double OutputMin { get; set; }
        public double OutputMax { get; set; }

        #endregion

        #region Construction / Deconstruction

        public PID(double pG, double iG, double dG,
            double pMax, double pMin, double oMax, double oMin)
        {
            PropGain = pG;
            IntGain = iG;
            DiffGain = dG;
            InputMax = pMax;
            InputMin = pMin;
            OutputMax = oMax;
            OutputMin = oMin;
        }

        #endregion

        #region Public Methods

        public void Reset()
        {
            _errSum = 0.0f;
            _lastUpdate = DateTime.Now;
        }

        public double Compute(double currentValue, double targetValue)
        {
            //We need to scale the pv to +/- 100%, but first clamp it
            currentValue = Clamp(currentValue, InputMin, InputMax);
            currentValue = ScaleValue(currentValue, InputMin, InputMax, -1.0f, 1.0f);

            //We also need to scale the setpoint
            targetValue = Clamp(targetValue, InputMin, InputMax);
            targetValue = ScaleValue(targetValue, InputMin, InputMax, -1.0f, 1.0f);

            //Now the error is in percent...
            double err = targetValue - currentValue;

            double pTerm = err * PropGain;
            double iTerm = 0.0f;
            double dTerm = 0.0f;

            double partialSum = 0.0f;
            DateTime nowTime = DateTime.Now;

            if (_lastUpdate != null)
            {
                double dT = (nowTime - _lastUpdate).TotalSeconds;

                //Compute the integral if we have to...
                if (currentValue >= InputMin && currentValue <= InputMax)
                {
                    partialSum = _errSum + dT * err;
                    iTerm = IntGain * partialSum;
                }

                if (dT != 0.0f)
                    dTerm = DiffGain * (currentValue - _lastInput) / dT;
            }

            _lastUpdate = nowTime;
            _errSum = partialSum;
            _lastInput = currentValue;

            //Now we have to scale the output value to match the requested scale
            double outReal = pTerm + iTerm + dTerm;

            outReal = Clamp(outReal, -1.0f, 1.0f);
            outReal = ScaleValue(outReal, -1.0f, 1.0f, OutputMin, OutputMax);

            //Write it out to the world
            return outReal;
        }

        #endregion

        #region Private Methods

        private double ScaleValue(double value, double valueMin, double valueMax, double scaleMin, double scaleMax)
        {
            double vPerc = (value - valueMin) / (valueMax - valueMin);
            double bigSpan = vPerc * (scaleMax - scaleMin);

            double retVal = scaleMin + bigSpan;

            return retVal;
        }

        private double Clamp(double value, double min, double max)
        {
            if (value > max)
                return max;
            if (value < min)
                return min;
            return value;
        }

        #endregion

    }
}
