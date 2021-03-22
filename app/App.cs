using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.WindowsForms;
using OxyPlot.Series;
using System.IO;
using Serilog;
using Newtonsoft.Json.Linq;
using ControlledPTT.Lasers;


namespace ControlledPTT
{
    public partial class App : Form
    {
        // Base directory where executable is located
        private static string BASE_DIR = Directory.GetCurrentDirectory();
        // Config path to be loaded from settings
        private string _configPath = "";
        private JObject _config = null;

        // Calibration
        private Calibration _calibration = null;

        // Experiment
        private int _discretizationTime = 1000; // ms, discretization time of timers
        private string _expBaseDir = "";
        private string _expDir = "";
        private string _expFileName = "";
        private string _expFilePath = "";
        private double _calibratedTemperature = 0;
        // PID
        private PID _pid = null;
        private double _targetTemperature = 50;
        // Timer for experiment.
        private Timer _expTimer = new Timer() { Interval = 1000 };
        // string with the format to save data depending on the experiment type
        private string _saveDataLineHeader = "Time (ms)\tRaw Sensor Data\tCalibrated Temperature";
        private string _saveDataLineFormat = "{0}\t{1:F2}\t{2:F2}";
        // StreamWriter to save data
        private StreamWriter _expWriter = null;
        // Variables to keep track of experiment
        private bool _expGoing = false;
        private int _elapsedMilliseconds = 0;
        // Indicates if the message box with error is already open when sensor is not sending temperature
        private bool _errNotSendingTemperatureShown = false;

        /// <summary>
        /// Removes all graph data by creating a new PlotModel for the graph
        /// </summary>
        private void ResetGraphData()
        {
            PlotModel pm = new PlotModel()
            {
                Title = "Object Temperature",
                PlotAreaBackground = OxyColors.White,
                DefaultColors = new List<OxyColor>
                {
                    OxyColors.Red,
                    OxyColors.Green,
                    OxyColors.Blue
                },
                TitleFontSize = 12,
                TitleFontWeight = 400,
                LegendFontWeight = 500,
                LegendFontSize = 12,
                LegendTextColor = OxyColors.Black,
                LegendPosition = LegendPosition.RightTop,
            };
            pm.Axes.Add(new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                Minimum = 0,
                Maximum = 120,
                Title = "Elapsed Time (s)"
            });
            pm.Axes.Add(new LinearAxis()
            {
                Position = AxisPosition.Left,
                Minimum = 17,
                Maximum = 23,
                Title = "Temperature (Celcius)"
            });
            // object temperature plot series
            pm.Series.Add(new LineSeries()
            {
                Title = "Raw data",
                TextColor = OxyColors.Red,
                IsVisible = false // Raw data is only shown when the calibration is on
            });
            //series for calibrated temperature
            pm.Series.Add(new LineSeries()
            {
                Title = "Calibrated",
                TextColor = OxyColors.Green,
                IsVisible = true
            });
            // series for target temperature in PID controller
            pm.Series.Add(new LineSeries()
            {
                Title = "Target",
                TextColor = OxyColors.Blue,
                IsVisible = false
            });
            pltTemperature.Model = pm;
            cmbExperimentType_SelectedIndexChanged(cmbExperimentType, new EventArgs());
        }

        /// <summary>
        /// Sets the graph values and scales the axis during the experiment.
        /// </summary>
        private void SetGraphData()
        {
            double[] tempData = new double[] { _receivedTemperature, _calibratedTemperature, _targetTemperature };
            List<double> visibleData = new List<double>();
            double elapsedSeconds = (double)_elapsedMilliseconds / 1000;
            Axis xAxis = pltTemperature.Model.Axes[0];
            Axis yAxis = pltTemperature.Model.Axes[1];

            for (int i = 0; i < pltTemperature.Model.Series.Count; i++)
            {
                LineSeries series = pltTemperature.Model.Series[i] as LineSeries;
                if (series.IsVisible)
                {
                    visibleData.Add(tempData[i]);
                }
                series.Points.Add(new DataPoint(elapsedSeconds, tempData[i]));
            }
            // Scale X axis
            if (elapsedSeconds > xAxis.Maximum - 30)
            {
                xAxis.Maximum += 50;
                xAxis.Minimum += 50;
            }

            // Scale Y axis
            double yMax = visibleData.Max();
            if (yAxis.Maximum - 1 < yMax)
                yAxis.Maximum += 1;
            if (yAxis.Maximum - 3 > yMax)
                yAxis.Maximum -= 1;
            double yMin = visibleData.Min();
            if (yAxis.Minimum + 1 > yMin)
                yAxis.Minimum -= 1;
            if (yAxis.Minimum + 3 < yMin)
                yAxis.Minimum += 1;

            pltTemperature.Model.InvalidatePlot(false);
        }

        private void AppendText(RichTextBox box, string txt, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(txt);
            box.SelectionColor = box.ForeColor;
            box.ScrollToCaret();
        }

        public App()
        {
            InitializeComponent();
            // Initialize graph
            ResetGraphData();

            // Load configuration
            // First get the settings file to load
            _configPath = Properties.Settings.Default.AppSettings;
            if (!Path.IsPathRooted(_configPath))
                _configPath = Path.GetFullPath(Path.Combine(BASE_DIR, _configPath));
            // Load settings either saved by user or default ones
            if (File.Exists(_configPath))
                _config = JObject.Parse(File.ReadAllText(_configPath));
            else
            {
                // config file was not found - load default one
                _configPath = Path.GetFullPath(Path.Combine(BASE_DIR, (string)Properties.Settings.Default.Properties["AppSettings"].DefaultValue));
                _config = JObject.Parse(File.ReadAllText(_configPath));
            }

            saveCurrentConfigWhenClosingToolStripMenuItem.Checked = (bool)_config["save_settings_on_closing"];            

            // get information about sensors and select the indicated one
            _selectedSensorIndex = (int)_config["selected_sensor_index"] - 1;
            FindSensors((string)_config["sensors_path"], (JArray)_config["user_added_sensors"], _selectedSensorIndex);

            // get information about lasers and select the indicated one
            _selectedLaserIndex = (int)_config["selected_laser_index"] - 1;
            FindLasers((string)_config["lasers_path"], (JArray)_config["user_added_lasers"], _selectedLaserIndex);

            // calibration
            string calibrationFile = (string)_config["calibration"];
            try
            {
                calibrationFile = Path.GetFullPath(calibrationFile);
                _calibration = new Calibration(calibrationFile);
            }
            catch (ArgumentException)
            {
                // file does not exist of path is in the wrong format
                _calibration = new Calibration();
            }
            cbUseCalibration.Checked = (bool)_config["use_calibration"];
            DisplayCalibration();
            cbUseCalibration_CheckedChanged(cbUseCalibration, new EventArgs());

            nudTargetTemp.Minimum = (decimal)_config["min_target_temperature"];
            nudTargetTemp.Maximum = (decimal)_config["max_target_temperature"];
            cmbExperimentType.SelectedIndex = (int)_config["experiment_type_index"] - 1;
            _pid = new PID(
                (double)_config["pid"]["proportional"],
                (double)_config["pid"]["integral"],
                (double)_config["pid"]["differential"],
                (double)nudTargetTemp.Maximum, // Max temperature that can be set and achieved
                (double)nudTargetTemp.Minimum, // Min temperature that can be set and achieved
                1.0, // PID gives output in the [0, 1] interval of relative laser power
                0); // The final laser power to be calculated by the laser part
            nudPropGain.Value = (decimal)_pid.PropGain;
            nudIntGain.Value = (decimal)_pid.IntGain;
            nudDiffGain.Value = (decimal)_pid.DiffGain;

            // Initialization for Experiment
            // directory to save files of the experiment
            _expBaseDir = Path.GetFullPath((string)_config["experiment_dir"]);
            if ((bool)_config["create_experiment_folder_with_current_date"])
                _expDir = Path.Combine(_expBaseDir, DateTime.Now.ToString("yyyy-MM-dd"));
            else
                _expDir = _expBaseDir;
            txtExpDir.Text = _expDir;
            txtExpDir.SelectionStart = txtExpDir.Text.Length;
            txtExpDir.ScrollToCaret();

            // if header needs to be saved
            cbSaveHeader.Checked = (bool)_config["save_header_data"];

            // if data needs to be saved
            cbSaveData.Checked = (bool)_config["save_experiment_data"];
            txtExpFileName.Enabled = cbSaveData.Checked;
            txtExpDir.Enabled = cbSaveData.Checked;
            btnSelectExpDir.Enabled = cbSaveData.Checked;
            txtDescription.Enabled = cbSaveData.Checked;
            txtOperator.Enabled = cbSaveData.Checked;
            cbSaveHeader.Enabled = cbSaveData.Checked;
            txtExpFileName.Text = _expFileName;

            // generate file name
            if ((bool)_config["create_experiment_file_with_current_time"])
                _expFileName = "Record_" + DateTime.Now.ToString("hh-mm-ss") + ".txt";
            else
                _expFileName = "";
            txtExpFileName.Text = _expFileName;

            // get information about experiment and set values
            _discretizationTime = (int)_config["discretization_ms"];
            _expTimer.Interval = _discretizationTime;
            _expTimer.Tick += new EventHandler(this.experimentTimer_Tick);
        }

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

        /// <summary>
        /// Show PID control panel when PID controlled experiment is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbExperimentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            (pltTemperature.Model.Series[2] as LineSeries).IsVisible = false;
            switch (cmbExperimentType.SelectedIndex)
            {
                case 0:
                    gbLaser.Visible = false;
                    gbPID.Visible = false;
                    break;
                case 1:
                    gbLaser.Visible = true;
                    gbPID.Visible = false;
                    break;
                case 2:
                    gbLaser.Visible = true;
                    gbPID.Visible = true;
                    (pltTemperature.Model.Series[2] as LineSeries).IsVisible = true;
                    break;
            }
            pltTemperature.Model.InvalidatePlot(false);
        }

        /// <summary>
        /// User can select path where to save experiment data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectExpDir_Click(object sender, EventArgs e)
        {
            fbdSelectDir.SelectedPath = _expBaseDir;
            DialogResult result = fbdSelectDir.ShowDialog();
            if (result == DialogResult.OK)
            {
                _expDir = fbdSelectDir.SelectedPath;
                _expBaseDir = _expDir;
                txtExpDir.Text = _expDir;
                txtExpDir.SelectionStart = txtExpDir.Text.Length;
                txtExpDir.ScrollToCaret();
            }
        }

        private void cbSaveData_CheckedChanged(object sender, EventArgs e)
        {
            txtExpFileName.Enabled = cbSaveData.Checked;
            txtExpDir.Enabled = cbSaveData.Checked;
            btnSelectExpDir.Enabled = cbSaveData.Checked;
            txtDescription.Enabled = cbSaveData.Checked;
            txtOperator.Enabled = cbSaveData.Checked;
            cbSaveHeader.Enabled = cbSaveData.Checked;
        }

        /// <summary>
        /// Checks everything before the experiment. If everything is ok, returns true.
        /// </summary>
        private bool PrepareExperiment()
        {
            // Sensor is not sending temperature
            if (!_isSensorSendingTemperature)
            {
                MessageBox.Show("The sensor is not sending temperature. Check if it is connected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbExperimentType.SelectedIndex > 0)
            {
                // Experiment type selected requires the connection to laser. Check the connection
                if (_laser == null)
                {
                    MessageBox.Show("No laser is started. Select the laser to proceed with the chosen experiment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (!_laser.IsLaserInitialized())
                {
                    MessageBox.Show("The laser hardware was not properly initialized. Check if laser is connected and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            
            // Prepare PID
            _targetTemperature = (double)nudTargetTemp.Value;
            _pid.Reset();

            // Experiment directory
            if (!Directory.Exists(_expDir))
            {
                Directory.CreateDirectory(_expDir);
            }
            // Experiment file
            _expFileName = txtExpFileName.Text;
            // Check filename contains correct characters
            Regex checkFileName = new Regex("[" + Regex.Escape(new string(Path.GetInvalidFileNameChars())) + "]");
            if (checkFileName.IsMatch(_expFileName))
            {
                MessageBox.Show("File name contains invalid characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            _expFilePath = Path.Combine(_expDir, _expFileName);
            if (!Path.HasExtension(_expFilePath))
                _expFilePath = _expFilePath + ".txt";

            if (File.Exists(_expFilePath))
            {
                DialogResult result = MessageBox.Show("File with the selected name already exists. Do you want to overwrite it?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                    return false;
            }

            // Generate the tempalte string for saving the data depending on the selected experimental parameters
            _saveDataLineHeader = "Time (ms)\tRaw Sensor Data\tCalibrated Temperature";
            _saveDataLineFormat = "{0}\t{1:F2}\t{2:F2}";
            if (cmbExperimentType.SelectedIndex > 0)
            {
                // Laser will be used in the experiment
                _saveDataLineHeader = _saveDataLineHeader + "\tLaser Power";
                _saveDataLineFormat = _saveDataLineFormat + "\t{3:F2}";
            }

            ResetGraphData();

            return true;
        }

        /// <summary>
        /// Disables and changes controls when experiment is running
        /// </summary>
        private void DisableControlsExperimentStarted()
        {
            cmbExperimentType.Enabled = false;
            btnStartExperiment.Text = "Stop Experiment";
            txtExperimentStarted.Text = "Experiment Going";
            txtExperimentStarted.BackColor = Color.Green;
            nudExpTime.ReadOnly = true;
            cbSaveData.Enabled = false;
            txtExpFileName.Enabled = false;
            btnSelectExpDir.Enabled = false;
            txtDescription.Enabled = false;
            txtOperator.Enabled = false;
            cbSaveHeader.Enabled = false;
            gbLaser.Enabled = false;
            nudTargetTemp.Enabled = false;
        }

        /// <summary>
        /// Enables and changes controls so that a new experiment can be started
        /// </summary>
        private void EnableControlsExperimentFinished()
        {
            cmbExperimentType.Enabled = true;
            btnStartExperiment.Text = "Start Experiment";
            txtExperimentStarted.Text = "Experiment Not Going";
            txtExperimentStarted.BackColor = Color.Red;
            nudExpTime.ReadOnly = false;
            cbSaveData.Enabled = true;
            txtExpFileName.Enabled = true;
            btnSelectExpDir.Enabled = true;
            txtDescription.Enabled = true;
            txtOperator.Enabled = true;
            cbSaveHeader.Enabled = true;
            nudTargetTemp.Enabled = true;
            if (_laser == null)
                gbLaser.Enabled = true;
        }

        /// <summary>
        /// Finishes the experiment either on time expiration, termination by user or App closing. 
        /// </summary>
        private void FinishExperiment()
        {
            _laser?.SwitchOff();

            _expGoing = false;
            _expTimer.Stop();

            if (cbSaveData.Checked)
            {
                _expWriter.Flush();
                _expWriter.Close();
            }

            EnableControlsExperimentFinished();
        }

        private void btnStartExperiment_Click(object sender, EventArgs e)
        {
            if (_expGoing)
            {
                // Experiment was stopped by user
                FinishExperiment();
            }
            else
            {
                // Start of experiment was initiated by user
                if (PrepareExperiment())
                {
                    if (cbSaveData.Checked)
                    {
                        _expWriter = new StreamWriter(_expFilePath);
                        if (cbSaveHeader.Checked)
                        {
                            // Save header data
                            string laser = "No Laser";
                            string pidParams = "No PID control";
                            string targetTemp = pidParams;
                            if (cmbExperimentType.SelectedIndex > 0)
                                laser = cmbLasers.SelectedItem.ToString();
                            if (cmbExperimentType.SelectedIndex == 2)
                            {
                                // PID Controlled PTT selected
                                pidParams = "proportional = " + nudPropGain.Value.ToString("F2") + "; integral = " +
                                    nudIntGain.Value.ToString("F2") + "; differential = " + nudDiffGain.Value.ToString("F2");
                                targetTemp = _targetTemperature.ToString("F2");
                                double startPower = _pid.Compute(_calibratedTemperature, _targetTemperature);
                                _laser?.SetPower(startPower);
                            }
                            string header =
                                "File Name: " + _expFileName + Environment.NewLine +
                                "File Directory: " + _expDir + Environment.NewLine +
                                "Experiment: " + cmbExperimentType.SelectedItem.ToString() + Environment.NewLine +
                                "Description: " + txtDescription.Text + Environment.NewLine +
                                "Operator: " + txtOperator.Text + Environment.NewLine +
                                "Settings: " + _configPath + Environment.NewLine +
                                "Sensor: " + cmbSensors.SelectedItem.ToString() + Environment.NewLine +
                                "Calibration: " + _calibration.CalibrationFile + Environment.NewLine +
                                "PID Parameters: " + pidParams + Environment.NewLine +
                                "Laser: " + laser + Environment.NewLine +
                                "Target Temperature: " + targetTemp + Environment.NewLine +
                                "Experiment Time: " + nudExpTime.Value.ToString("F2") + " min";
                            _expWriter.WriteLine(header + Environment.NewLine);
                        }

                        // Save header line for the experiment
                        _expWriter.WriteLine(_saveDataLineHeader);
                        _expWriter.WriteLine(string.Format(_saveDataLineFormat, 0, _receivedTemperature, _calibratedTemperature, _laser?.GetPower()));
                    }

                    DisableControlsExperimentStarted();
                    SetGraphData();

                    if (cmbExperimentType.SelectedIndex > 0)
                        _laser?.SwitchOn();

                    _elapsedMilliseconds = 0;
                    txtElapsedTime.Text = TimeSpan.Zero.ToString(@"hh\:mm\:ss\.fff");

                    _expGoing = true;
                    _expTimer.Start();
                }
            }
        }

        /// <summary>
        /// Main method to perform the measurement, control the laser and write the data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void experimentTimer_Tick(object sender, EventArgs e)
        {
            if (_elapsedMilliseconds >= (int)(nudExpTime.Value * 60 * 1000))
            {
                // Stop the experiment when the time is over. Write all the data if specified.
                FinishExperiment();
            }
            else
            {
                // Experiment is going
                _elapsedMilliseconds += _expTimer.Interval;
                txtElapsedTime.Text = TimeSpan.FromMilliseconds(_elapsedMilliseconds).ToString(@"hh\:mm\:ss\.fff");

                // Sensor is not sending temperature
                if (!_isSensorSendingTemperature && !_errNotSendingTemperatureShown)
                {
                    _errNotSendingTemperatureShown = true;
                    MessageBox.Show("The sensor is not sending temperature. Check if it is connected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (cmbExperimentType.SelectedIndex == 2)
                {
                    // PID Controled PTT is on
                    double relativePower = _pid.Compute(_calibratedTemperature, _targetTemperature);
                    _laser?.SetPower(relativePower);
                    txtRelativePower.Text = relativePower.ToString("F3");
                }

                if (cbSaveData.Checked)
                    _expWriter.WriteLine(string.Format(_saveDataLineFormat, _elapsedMilliseconds, _receivedTemperature, _calibratedTemperature, _laser?.GetPower()));

                SetGraphData();
            }                    
        }

        private void SaveAppConfiguration()
        {
            // Settings from menu should be always saved
            _config["save_settings_on_closing"] = saveCurrentConfigWhenClosingToolStripMenuItem.Checked;

            if (saveCurrentConfigWhenClosingToolStripMenuItem.Checked)
            {
                // Check new sensors were added by user
                JArray sensors = new JArray();
                for (int i = _numInstalledSensors; i < cmbSensors.Items.Count; i++)
                    sensors.Add(new JObject(
                        new JProperty("title", cmbSensors.Items[i].ToString()),
                        new JProperty("path", _sensorPaths[i])
                        ));
                _config["user_added_sensors"] = sensors;
                // Save sensor selected index
                _config["selected_sensor_index"] = cmbSensors.SelectedIndex + 1;

                // Check new lasers were added by user
                JArray lasers = new JArray();
                for (int i = _numInstalledLasers; i < cmbLasers.Items.Count; i++)
                    lasers.Add(new JObject(
                        new JProperty("title", cmbLasers.Items[i].ToString()),
                        new JProperty("path", _laserPaths[i])
                        ));
                _config["user_added_lasers"] = lasers;
                // Save sensor selected index
                _config["selected_laser_index"] = cmbLasers.SelectedIndex + 1;

                // Save calibration
                _config["calibration"] = txtCalibration.Text;               
                _config["use_calibration"] = cbUseCalibration.Checked;

                // Save experiment type
                _config["experiment_type_index"] = cmbExperimentType.SelectedIndex + 1;

                // Save PID values
                _config["pid"]["proportional"] = _pid.PropGain;
                _config["pid"]["integral"] = _pid.IntGain;
                _config["pid"]["differential"] = _pid.DiffGain;

                // Save experiment dir
                _config["experiment_dir"] = _expBaseDir;

                // Save experiment settings
                _config["save_header_data"] = cbSaveHeader.Checked;
                _config["save_experiment_data"] = cbSaveData.Checked;
                _config["create_experiment_folder_with_current_date"] = createDirectoryWithCurrentDateToolStripMenuItem.Checked;
                _config["create_experiment_file_with_current_time"] = createFileWithCurrentTimeToolStripMenuItem.Checked;

            }
            // Saves main settings file
            File.WriteAllText(_configPath, _config.ToString());

            // Saves base settings file
            Properties.Settings.Default.AppSettings = _configPath;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Save settings upon closing if necessary.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_expGoing)
                FinishExperiment();
            
            SaveAppConfiguration();

            _calibration.Dispose();
            // Log.CloseAndFlush();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAppConfiguration();
        }

        private void nudPropGain_ValueChanged(object sender, EventArgs e)
        {
            _pid.PropGain = (double)nudPropGain.Value;
            _pid.Reset();
        }

        private void nudIntGain_ValueChanged(object sender, EventArgs e)
        {
            _pid.IntGain = (double)nudIntGain.Value;
            _pid.Reset();
        }

        private void nudDiffGain_ValueChanged(object sender, EventArgs e)
        {
            _pid.DiffGain = (double)nudDiffGain.Value;
            _pid.Reset();
        }
    }
}
