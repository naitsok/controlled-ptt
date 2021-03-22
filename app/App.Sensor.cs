using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ControlledPTT.Sensors;
using Newtonsoft.Json.Linq;

namespace ControlledPTT
{
    /// <summary>
    /// This part of App class contains methods related to sensors
    /// </summary>
    partial class App
    {
        // Sensors
        private List<string> _sensorPaths = new List<string>();
        private int _selectedSensorIndex = 0;
        // number of sensors installed in the default location 
        // needed to keep track of sensors added manually by user
        private int _numInstalledSensors = 0;
        private BaseSensor _sensor = null;
        private double _receivedTemperature = 0;
        private static int NUM_LAST_TEMPS = 10;
        private List<double> _checkTemperatureChanging = Enumerable.Repeat(0.0, NUM_LAST_TEMPS).ToList();
        private bool _isSensorSendingTemperature = false;

        /// <summary>
        /// Enables or disables sensor removal button is the sensors is added by
        /// user or installed in the default folder.
        /// </summary>
        private void EnableSensorRemoval()
        {
            if (cmbSensors.SelectedIndex >= _numInstalledSensors)
                btnRemoveSensor.Enabled = true;
            else
                btnRemoveSensor.Enabled = false;
        }

        /// <summary>
        /// Finds sensor executables and populates the dropdown list
        /// </summary>
        /// <param name="sensorsPath">Path to sensor executables</param>
        /// <param name="selectedIndex">Selected index for dropdownlist</param>
        private void FindSensors(string sensorsPath, JArray userSensors, int selectedIndex)
        {
            // First load the sensor executables that are in the sensors folder
            if (!Path.IsPathRooted(sensorsPath))
            {
                sensorsPath = Path.GetFullPath(Path.Combine(BASE_DIR, sensorsPath));
            }

            string[] allSensorExes = Directory.GetFiles(sensorsPath, "*.exe", SearchOption.AllDirectories);
            List<string> sensorTitles = new List<string>();
            foreach (string partExe in allSensorExes)
            {
                if (!partExe.Contains("ref"))
                {
                    _sensorPaths.Add(partExe);
                    Assembly partAssembly = Assembly.LoadFrom(partExe);
                    Type[] types = partAssembly.GetExportedTypes();
                    BaseSensor sensor = Activator.CreateInstance(types[0]) as BaseSensor;
                    sensorTitles.Add(sensor.Title);
                }
            }
            cmbSensors.Items.AddRange(sensorTitles.ToArray());
            _numInstalledSensors = sensorTitles.Count;

            // Finally load the sensors added by user
            foreach (JToken sensor in userSensors)
            {
                cmbSensors.Items.Add(sensor["title"]);
                _sensorPaths.Add(Path.GetFullPath((string)sensor["path"]));
            }

            if (selectedIndex < cmbSensors.Items.Count)
                cmbSensors.SelectedIndex = selectedIndex;

            EnableSensorRemoval();
        }

        /// <summary>
        /// Opens dialog to select sensor executable manually.
        /// Gets the filename of selected executable and adds it to the list of sensors to be loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadSensor_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdSelectSensor.ShowDialog();
            if (result == DialogResult.OK)
            {
                // get sensor executable title and add it to list
                Assembly sensorAssembly = Assembly.LoadFrom(ofdSelectSensor.FileName);
                Type[] types = sensorAssembly.GetExportedTypes();
                BaseSensor sensor = Activator.CreateInstance(types[0]) as BaseSensor;
                string sensorTitle = sensor.Title;
                if (cmbSensors.Items.Contains(sensorTitle))
                {
                    int i = 1;
                    sensorTitle = sensorTitle + " (" + i.ToString() + ")";
                    while (true)
                    {
                        if (!cmbSensors.Items.Contains(sensorTitle))
                            break;
                    }
                }

                cmbSensors.Items.Add(sensorTitle);
                _sensorPaths.Add(ofdSelectSensor.FileName);
                cmbSensors.SelectedIndex = cmbSensors.Items.Count - 1;
                EnableSensorRemoval();
            }
        }

        /// <summary>
        /// Checks if the selected sensor is added by user. Then this sensor can be deleted.
        /// Sensors installed in their default location cannot be removed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSensors_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableSensorRemoval();
        }

        /// <summary>
        /// Removes the sensor from the list. Only removes sensor added by user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveSensor_Click(object sender, EventArgs e)
        {
            if (cmbSensors.SelectedIndex >= _numInstalledSensors)
            {
                _sensorPaths.RemoveAt(cmbSensors.SelectedIndex);
                cmbSensors.Items.RemoveAt(cmbSensors.SelectedIndex);
                cmbSensors.SelectedIndex = 0;
                EnableSensorRemoval();
            }
        }

        /// <summary>
        /// Starts the sensor part.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartSensor_Click(object sender, EventArgs e)
        {
            // check the sensor part to exists
            if (!File.Exists(_sensorPaths[cmbSensors.SelectedIndex]))
            {
                MessageBox.Show("The sensor part is not found on path " +
                    _sensorPaths[cmbSensors.SelectedIndex] +
                    ". Check the config file or load the part manually using \"Load\" button.",
                    "Sensor part not found.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // load the sensor part
            Assembly sensorAssembly = Assembly.LoadFrom(_sensorPaths[cmbSensors.SelectedIndex]);
            Type[] types = sensorAssembly.GetExportedTypes();
            _sensor = Activator.CreateInstance(types[0]) as BaseSensor;
            _sensor.SetTimerInterval(_discretizationTime);
            _sensor.FormClosed += sensor_FormClosed;
            _sensor.OnTemperatureSent += sensorForm_TemperatureSent;
            _sensor.Show();

            // Organize windows
            _sensor.Location = new Point(5, 10);
            Location = new Point(10 + _sensor.Size.Width, 10);
            if (_laser != null)
                _laser.Location = new Point(Location.X + Size.Width + 10, 10);

            // Disable controls
            gbSensor.Enabled = false;
        }

        /// <summary>
        /// When sensor form is closed, the resources must be released.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sensor_FormClosed(object sender, FormClosedEventArgs e)
        {
            _sensor.FormClosed -= sensor_FormClosed;
            _sensor.OnTemperatureSent -= sensorForm_TemperatureSent;
            _sensor.Dispose();
            _sensor = null;
            gbSensor.Enabled = true;
            _isSensorSendingTemperature = false;
        }

        /// <summary>
        /// Receives temperature from the sensor form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sensorForm_TemperatureSent(object sender, TemperatureSentEventArgs e)
        {
            // receive temperature from sensor, send it to calibration, update controls in MainApp
            _receivedTemperature = e.Temperature;
            _calibration.SensorTemperature = _receivedTemperature;
            txtSensorTemp.Text = _receivedTemperature.ToString("F2");
            if (cbUseCalibration.Checked)
            {
                _calibratedTemperature = _receivedTemperature * _calibration.Slope + _calibration.Intercept;
                txtCalibratedTemp.Text = _calibratedTemperature.ToString("F2");
            }
            else
            {
                _calibratedTemperature = _receivedTemperature;
                txtCalibratedTemp.Text = txtSensorTemp.Text;
            }

            // check if temperature from sensor is changing
            // if it is not changing - something is wrong
            // for example sensor is not connected to the board
            _isSensorSendingTemperature = CheckSensorIsSendingTemperature(_receivedTemperature);
        }

        /// <summary>
        /// Check is sensor is sending temperature. If last ten readings from the sensor
        /// provide the same temperature, then something is wrong. Experiment should be aborted
        /// and error should be logged.
        /// </summary>
        /// <param name="temperature"></param>
        /// <returns></returns>
        private bool CheckSensorIsSendingTemperature(double temperature)
        {
            _checkTemperatureChanging.Add(temperature);
            if (_checkTemperatureChanging.Count > NUM_LAST_TEMPS)
                _checkTemperatureChanging.RemoveAt(0);

            // one distinct value means that all the values are the same
            if (_checkTemperatureChanging.Distinct().Count() == 1)
                return false;
            else
            {
                // Temperature is back and sending. The error message box can be shown again if problem occurs.
                _errNotSendingTemperatureShown = false;
                return true;
            }
        }
    }
}
