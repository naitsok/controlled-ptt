using System;
using System.Windows.Forms;
using OxyPlot.Series;

namespace ControlledPTT
{
    /// <summary>
    /// This part of App class contains methods related to use of calibration. 
    /// The calibration itself is handled through dedicated Calibration class.
    /// </summary>
    partial class App
    {
        // Keeps the calibration
        private Calibration _calibration = null;

        /// <summary>
        /// Get the calibration parameters, such as Slope and Intersept, and displays them
        /// on the controls.
        /// </summary>
        private void DisplayCalibration()
        {
            txtCalibration.Text = _calibration.CalibrationFile;
            txtCalibration.SelectionStart = txtCalibration.Text.Length;
            txtCalibration.ScrollToCaret();
            txtSlope.Text = _calibration.Slope.ToString("F3");
            txtIntercept.Text = _calibration.Intercept.ToString("F3");
        }

        private void btnLoadCalibration_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdLoadCalibration.ShowDialog();
            if (result == DialogResult.OK)
                _calibration = new Calibration(ofdLoadCalibration.FileName);
            DisplayCalibration();
        }

        private void btnModifyCalibration_Click(object sender, EventArgs e)
        {
            // Show the raw data series
            (pltTemperature.Model.Series[0] as LineSeries).IsVisible = true;
            pltTemperature.Model.InvalidatePlot(false);

            _calibration.ShowDialog();
            DisplayCalibration();

            // Hide the raw data series
            (pltTemperature.Model.Series[0] as LineSeries).IsVisible = false;
            pltTemperature.Model.InvalidatePlot(false);
        }

        private void btnNewCalibration_Click(object sender, EventArgs e)
        {
            // Show the raw data series
            (pltTemperature.Model.Series[0] as LineSeries).IsVisible = true;
            pltTemperature.Model.InvalidatePlot(false);

            Calibration newCalibration = new Calibration();
            DialogResult result = newCalibration.ShowDialog();
            if (result == DialogResult.OK)
                _calibration = newCalibration;
            DisplayCalibration();

            // Hide the raw data series
            (pltTemperature.Model.Series[0] as LineSeries).IsVisible = false;
            pltTemperature.Model.InvalidatePlot(false);
        }

        /// <summary>
        /// Disable and enable controls when no calibration checkbox state changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbUseCalibration_CheckedChanged(object sender, EventArgs e)
        {
            txtCalibration.Enabled = cbUseCalibration.Checked;
            btnNewCalibration.Enabled = cbUseCalibration.Checked;
            btnLoadCalibration.Enabled = cbUseCalibration.Checked;
            btnModifyCalibration.Enabled = cbUseCalibration.Checked;

            if (cbUseCalibration.Checked)
            {
                _calibration = new Calibration(txtCalibration.Text);
            }
            else
            {
                _calibration = new Calibration();
            }
            txtSlope.Text = _calibration.Slope.ToString("F3");
            txtIntercept.Text = _calibration.Intercept.ToString("F3");
        }
    }
}
