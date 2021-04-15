using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.IO;
using Newtonsoft.Json.Linq;


namespace ControlledPTT
{
    public enum ExperimentType
    {
        [Description("No Laser, Only Temperature Recording")]
        NoLaser = 0,

        [Description("Full Power PTT")]
        FullPower = 1,

        [Description("Temperature Controlled PTT")]
        ControlledPTT = 2
    }

    public enum StopCondition
    {
        [Description("Time")]
        Time = 0,

        [Description("Thermal Dose")]
        ThermalDose = 1,

        [Description("Time or Thermal Dose")]
        TimeOrThermalDose = 2
    }

    public partial class App : Form
    {
        #region Fields

        // Base directory where executable is located
        private static readonly string BASE_DIR = Directory.GetCurrentDirectory();
        // Config path to be loaded from settings
        private string _configPath = "";
        private JObject _config = null;

        // Experiment
        private int _discretizationTime = 1000; // ms, discretization time of timers
        private string _expBaseDir = "";
        private string _expDir = "";
        private string _expFileName = "";
        private string _expFilePath = "";
        private double _calibratedTemperature = 0;
        private double _thermalDose = 0;
        private double _discretizationTimeMin = 1 / 60; // min, for thermal dose calculation
        private double _previousCalibratedTemperature = 0; // needed to calculate thermal dose
        // PID
        private PID _pid = null;
        private double _targetTemperature = 50;
        // Timer for experiment.
        private Timer _expTimer = new Timer() { Interval = 1000 };
        // string with the format to save data depending on the experiment type
        private string _saveDataLineHeader = "Time (ms)\tRaw Sensor Data\tCalibrated Temperature (°C)\tThermal dose (min)";
        private string _saveDataLineFormat = "{0}\t{1:F2}\t{2:F2}\t{3:F2}";
        // StreamWriter to save data
        private StreamWriter _expWriter = null;
        // Variables to keep track of experiment
        private bool _expGoing = false;
        private int _elapsedMilliseconds = 0;
        // Indicates if the message box with error is already open when sensor is not sending temperature
        private bool _errNotSendingTemperatureShown = false;

        // Graph
        // Constants indicate how much to scale axes
        private static readonly double X_TIME_SCALE_CHANGE = 50;
        private static readonly double Y_TEMPERATURE_SCALE_CHANGE = 1;
        private static readonly double Y_THERMAL_DOSE_SCALE_CHANGE = 25;

        // About box
        private AboutBox _aboutBox = new AboutBox();

        #endregion

        #region Graph Helpers

        /// <summary>
        /// Removes all graph data by creating a new PlotModel for the graph
        /// </summary>
        private void ResetGraphData()
        {
            PlotModel pm = new PlotModel()
            {
                Title = "Object Temperature and Thermal Dose",
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
            // X axis - elapsed experiment time
            pm.Axes.Add(new LinearAxis()
            {
                Key = "XElapsedTime",
                Position = AxisPosition.Bottom,
                Minimum = 0,
                Maximum = 120,
                Title = "Elapsed Time (s)"
            });
            // Y left axis - raw sensor data, calibrated and target temperatures
            pm.Axes.Add(new LinearAxis()
            {
                Key = "YTemperatures",
                Position = AxisPosition.Left,
                Minimum = 17,
                Maximum = 23,
                Title = "Temperature (°C)"
            });
            // Y right axis - thermal dose
            pm.Axes.Add(new LinearAxis()
            {
                Key = "YThermalDose",
                Position = AxisPosition.Right,
                Minimum = -5,
                Maximum = 50,
                Title = "Thermal dose (min)",
            });
            // object temperature plot series
            pm.Series.Add(new LineSeries()
            {
                XAxisKey = "XElapsedTime",
                YAxisKey = "YTemperatures",
                Title = "Raw T data",
                TextColor = OxyColors.Red,
                // Raw data is only shown when the calibration is on
                IsVisible = false
            });
            // series for calibrated temperature
            pm.Series.Add(new LineSeries()
            {
                XAxisKey = "XElapsedTime",
                YAxisKey = "YTemperatures",
                Title = "Calibrated T",
                TextColor = OxyColors.Green,
                IsVisible = true
            });
            // series for target temperature in PID controller
            pm.Series.Add(new LineSeries()
            {
                XAxisKey = "XElapsedTime",
                YAxisKey = "YTemperatures",
                Title = "Target T",
                TextColor = OxyColors.Blue,
                IsVisible = false
            });
            // series for thermal dose
            pm.Series.Add(new LineSeries()
            {
                XAxisKey = "XElapsedTime",
                YAxisKey = "YThermalDose",
                Title = "Thermal dose",
                TextColor = OxyColors.Magenta,
                IsVisible = true
            });
            pltTemperature.Model = pm;
            cmbExperimentType_SelectedIndexChanged(cmbExperimentType, new EventArgs());
        }

        /// <summary>
        /// Sets the graph values and scales the axis during the experiment.
        /// Does it for temperature and thermal dose.
        /// </summary>
        private void SetGraphData()
        {
            // First scale X axis
            double elapsedSeconds = (double)_elapsedMilliseconds / 1000;
            Axis xTime = pltTemperature.Model.Axes[0];
            if (elapsedSeconds > xTime.Maximum - X_TIME_SCALE_CHANGE)
            {
                xTime.Maximum += 2 * X_TIME_SCALE_CHANGE;
                xTime.Minimum += 2 * X_TIME_SCALE_CHANGE;
            }

            // Then deal with temperature
            double[] tempData = new double[] { _receivedTemperature, _calibratedTemperature, _targetTemperature };
            List<double> visibleData = new List<double>();
           
            Axis yTemperature = pltTemperature.Model.Axes[1];
            

            // this is to set temperatures only, so only Series related to temperatures are in action
            for (int i = 0; i < tempData.Length; i++)
            {
                LineSeries series = pltTemperature.Model.Series[i] as LineSeries;
                if (series.IsVisible)
                {
                    visibleData.Add(tempData[i]);
                }
                series.Points.Add(new DataPoint(elapsedSeconds, tempData[i]));
            }
            
            // Scale Y temperature axis
            double yMax = visibleData.Max();
            double yMin = visibleData.Min();

            if ((pltTemperature.Model.Series[0] as LineSeries).Points.Count == 1)
            {
                // Scale to first point in the graph
                yTemperature.Maximum = yMax + 3 * Y_TEMPERATURE_SCALE_CHANGE;
                yTemperature.Minimum = yMin - 3 * Y_TEMPERATURE_SCALE_CHANGE;
            }

            if (yTemperature.Maximum - Y_TEMPERATURE_SCALE_CHANGE < yMax)
                yTemperature.Maximum += Y_TEMPERATURE_SCALE_CHANGE;
            if (yTemperature.Maximum - 3 * Y_TEMPERATURE_SCALE_CHANGE > yMax)
                yTemperature.Maximum -= Y_TEMPERATURE_SCALE_CHANGE;
            if (yTemperature.Minimum + Y_TEMPERATURE_SCALE_CHANGE > yMin)
                yTemperature.Minimum -= Y_TEMPERATURE_SCALE_CHANGE;
            if (yTemperature.Minimum + 3 * Y_TEMPERATURE_SCALE_CHANGE < yMin)
                yTemperature.Minimum += Y_TEMPERATURE_SCALE_CHANGE;

            // Finally deal with thermal dose
            (pltTemperature.Model.Series[3] as LineSeries).Points.Add(new DataPoint(elapsedSeconds, _thermalDose));
            Axis yThermalDose = pltTemperature.Model.Axes[2];
            if (yThermalDose.Maximum - Y_THERMAL_DOSE_SCALE_CHANGE < _thermalDose)
                yThermalDose.Maximum += Y_THERMAL_DOSE_SCALE_CHANGE;
            if (yThermalDose.Maximum - 3 * Y_THERMAL_DOSE_SCALE_CHANGE > _thermalDose)
                yThermalDose.Maximum -= Y_THERMAL_DOSE_SCALE_CHANGE;
            if (yThermalDose.Minimum + Y_THERMAL_DOSE_SCALE_CHANGE > _thermalDose)
                yThermalDose.Minimum -= Y_THERMAL_DOSE_SCALE_CHANGE;
            if (yThermalDose.Minimum + 3 * Y_THERMAL_DOSE_SCALE_CHANGE < _thermalDose)
                yThermalDose.Minimum += Y_THERMAL_DOSE_SCALE_CHANGE;

            pltTemperature.Model.InvalidatePlot(false);
        }

        #endregion

        #region Configuration Helpers

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

                // Save expriment stop condition
                _config["selected_stop_condition_index"] = cmbStopCondition.SelectedIndex + 1;

                // Save PID values
                _config["pid"]["proportional"] = _pid.PropGain;
                _config["pid"]["integral"] = _pid.IntGain;
                _config["pid"]["differential"] = _pid.DiffGain;

                // Save experiment dir
                _config["experiment_path"] = _expBaseDir;

                // Save experiment settings
                _config["save_header_data"] = cbSaveHeader.Checked;
                _config["save_experiment_data"] = cbSaveData.Checked;
                _config["create_experiment_folder_with_current_date"] = createDirectoryWithCurrentDateToolStripMenuItem.Checked;
                _config["create_experiment_file_with_current_time"] = createFileWithCurrentTimeToolStripMenuItem.Checked;
                _config["operator"] = txtOperator.Text;
                _config["experiment_time_min"] = nudExpTime.Value;
                _config["experiment_thermal_dose"] = nudThermalDose.Value;

            }
            // Saves main settings file
            File.WriteAllText(_configPath, _config.ToString());

            // Saves base settings file
            Properties.Settings.Default.AppConfiguration = _configPath;
            Properties.Settings.Default.Save();

            // Display current config
            toolStripCurrentConfig.Text = "Current Configuration: " + Path.GetFileName(_configPath);
        }

        private void LoadAppConfiguration()
        {
            // Load configuration
            // First get the settings file to load
            _configPath = Properties.Settings.Default.AppConfiguration;
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

            // Display current config
            toolStripCurrentConfig.Text = "Current Configuration: " + Path.GetFileName(_configPath);

            // Set dialogs
            ofdLoadConfig.InitialDirectory = Path.GetDirectoryName(_configPath);
            sfdSaveConfigAs.InitialDirectory = ofdLoadConfig.InitialDirectory;

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
                ofdLoadCalibration.InitialDirectory = Path.GetDirectoryName(calibrationFile);
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
            cmbStopCondition.SelectedIndex = (int)_config["selected_stop_condition_index"] - 1;
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
            _expBaseDir = Path.GetFullPath((string)_config["experiment_path"]);
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

            txtOperator.Text = (string)_config["operator"];

            // time and thermal dose
            nudExpTime.Value = (decimal)_config["experiment_time_min"];
            nudThermalDose.Value = (decimal)_config["experiment_thermal_dose"];

            // get information about experiment and set values
            _discretizationTime = (int)_config["discretization_ms"];
            _discretizationTimeMin = (double)_discretizationTime / (1000 * 60);
            _expTimer.Interval = _discretizationTime;
            _expTimer.Tick += new EventHandler(this.experimentTimer_Tick);
        }

        #endregion

        #region Experiment Helpers

        /// <summary>
        /// Calulates thermal dose for a time step between temperature measurements.
        /// Temperature must be in Celsius.
        /// </summary>
        /// <param name="discretizationTime">Time in min between the temperature measurements.</param>
        /// <param name="previousTemperature">Termperature at the beginning of the time span.</param>
        /// <param name="currentTemperature">Termperature at the end of the time span.</param>
        /// <returns></returns>
        private double CalculateThermalDose(double discretizationTime, double previousTemperature, double currentTemperature)
        {
            double averageTemperature = 0.5 * (previousTemperature + currentTemperature);
            if (averageTemperature < 43)
            {
                return discretizationTime * Math.Pow(0.25, 43 - averageTemperature);
            }
            else
            {
                return discretizationTime * Math.Pow(0.5, 43 - averageTemperature);
            }
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

            if (cmbExperimentType.SelectedIndex > (int)ExperimentType.NoLaser)
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
            _saveDataLineHeader = "Time (ms)\tRaw Sensor Data\tCalibrated Temperature (°C)\tThermal dose (min)";
            _saveDataLineFormat = "{0}\t{1:F2}\t{2:F2}\t{3:F2}";
            if (cmbExperimentType.SelectedIndex > 0)
            {
                // Laser will be used in the experiment
                _saveDataLineHeader = _saveDataLineHeader + "\tLaser Power";
                _saveDataLineFormat = _saveDataLineFormat + "\t{4:F2}";
            }

            _elapsedMilliseconds = 0;
            _thermalDose = 0;
            txtElapsedTime.Text = TimeSpan.Zero.ToString(@"hh\:mm\:ss\.fff");

            ResetGraphData();

            return true;
        }

        /// <summary>
        /// Checks if experiment must stop if the selected stop condition is satisfied.
        /// </summary>
        /// <returns></returns>
        private bool CheckExperimentStops()
        {
            switch (cmbStopCondition.SelectedValue)
            {
                case StopCondition.Time:
                    return _elapsedMilliseconds >= (int)(nudExpTime.Value * 60 * 1000);
                case StopCondition.ThermalDose:
                    return _thermalDose >= (double)nudThermalDose.Value;
                case StopCondition.TimeOrThermalDose:
                    return (_elapsedMilliseconds >= (int)(nudExpTime.Value * 60 * 1000)) ||
                        (_thermalDose >= (double)nudThermalDose.Value);
                default:
                    return false;
            }
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
            gbStopCondition.Enabled = false;
            txtExpDir.Enabled = false;
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
            gbStopCondition.Enabled = true;
            txtExpDir.Enabled = true;
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
            MessageBox.Show("Experiment finished!", "Experiment finished!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        public App()
        {
            InitializeComponent();

            // Initialize graph
            ResetGraphData();

            // Initialize experiment type
            cmbExperimentType.DataSource = Enum.GetValues(typeof(ExperimentType))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .ToList();
            cmbExperimentType.DisplayMember = "Description";
            cmbExperimentType.ValueMember = "value";

            // Initialize stop condition
            cmbStopCondition.DataSource = Enum.GetValues(typeof(StopCondition))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .ToList();
            cmbStopCondition.DisplayMember = "Description";
            cmbStopCondition.ValueMember = "value";

            LoadAppConfiguration();
        }

        #region Event Handlers

        /// <summary>
        /// Show PID control panel when PID controlled experiment is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbExperimentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            (pltTemperature.Model.Series[(int)ExperimentType.ControlledPTT] as LineSeries).IsVisible = false;
            switch (cmbExperimentType.SelectedValue)
            {
                case ExperimentType.NoLaser:
                    gbLaser.Visible = false;
                    gbPID.Visible = false;
                    break;
                case ExperimentType.FullPower:
                    gbLaser.Visible = true;
                    gbPID.Visible = false;
                    break;
                case ExperimentType.ControlledPTT:
                    gbLaser.Visible = true;
                    gbPID.Visible = true;
                    (pltTemperature.Model.Series[(int)ExperimentType.ControlledPTT] as LineSeries).IsVisible = true;
                    break;
                default:
                    gbLaser.Visible = false;
                    gbPID.Visible = false;
                    break;
            }
            pltTemperature.Model.InvalidatePlot(false);
        }

        private void cmbStopCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbStopCondition.SelectedValue)
            {
                case StopCondition.Time:
                    lblExpTime.Enabled = true;
                    nudExpTime.Enabled = true;
                    lblThermalDose.Enabled = false;
                    nudThermalDose.Enabled = false;
                    break;
                case StopCondition.ThermalDose:
                    lblExpTime.Enabled = false;
                    nudExpTime.Enabled = false;
                    lblThermalDose.Enabled = true;
                    nudThermalDose.Enabled = true;
                    break;
                case StopCondition.TimeOrThermalDose:
                    lblExpTime.Enabled = true;
                    nudExpTime.Enabled = true;
                    lblThermalDose.Enabled = true;
                    nudThermalDose.Enabled = true;
                    break;
                default:
                    lblExpTime.Enabled = true;
                    nudExpTime.Enabled = true;
                    lblThermalDose.Enabled = false;
                    nudThermalDose.Enabled = false;
                    break;
            }
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

        private void cbSaveHeader_CheckedChanged(object sender, EventArgs e)
        {
            txtDescription.Enabled = cbSaveData.Checked && cbSaveHeader.Checked;
            txtOperator.Enabled = cbSaveData.Checked && cbSaveHeader.Checked;
        }

        private void cbSaveData_CheckedChanged(object sender, EventArgs e)
        {
            txtExpFileName.Enabled = cbSaveData.Checked;
            txtExpDir.Enabled = cbSaveData.Checked;
            btnSelectExpDir.Enabled = cbSaveData.Checked;
            txtDescription.Enabled = cbSaveData.Checked && cbSaveHeader.Checked;
            txtOperator.Enabled = cbSaveData.Checked && cbSaveHeader.Checked;
            cbSaveHeader.Enabled = cbSaveData.Checked;
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
                            if (cmbExperimentType.SelectedIndex > (int)ExperimentType.NoLaser)
                                laser = cmbLasers.SelectedItem.ToString();
                            if (cmbExperimentType.SelectedIndex == (int)ExperimentType.ControlledPTT)
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
                        _expWriter.WriteLine(string.Format(_saveDataLineFormat, 0, _receivedTemperature, _calibratedTemperature, _thermalDose, _laser?.GetPower()));
                    }

                    DisableControlsExperimentStarted();
                    SetGraphData();

                    if (cmbExperimentType.SelectedIndex > (int)ExperimentType.NoLaser)
                    {
                        if (!(_laser?.SwitchOn() ?? false))
                        {
                            FinishExperiment();
                        }
                    }

                    _expGoing = true;
                    _previousCalibratedTemperature = _calibratedTemperature;
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
            if (CheckExperimentStops())
            {
                // Stop the experiment when the time is over. Write all the data if specified.
                FinishExperiment();
            }
            else
            {
                // Experiment is going
                // Update elapsed time
                _elapsedMilliseconds += _expTimer.Interval;
                txtElapsedTime.Text = TimeSpan.FromMilliseconds(_elapsedMilliseconds).ToString(@"hh\:mm\:ss\.fff");

                // Update thermal dose and temperature to calculate thermal dose
                _thermalDose += CalculateThermalDose(_discretizationTimeMin, _previousCalibratedTemperature, _calibratedTemperature);
                txtGainedThermalDose.Text = _thermalDose.ToString("F2");
                _previousCalibratedTemperature = _calibratedTemperature;

                // Sensor is not sending temperature
                if (!_isSensorSendingTemperature && !_errNotSendingTemperatureShown)
                {
                    _errNotSendingTemperatureShown = true;
                    MessageBox.Show("The sensor is not sending temperature. Check if it is connected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (cmbExperimentType.SelectedIndex == (int)ExperimentType.ControlledPTT)
                {
                    // PID Controled PTT is on
                    double relativePower = _pid.Compute(_calibratedTemperature, _targetTemperature);
                    _laser?.SetPower(relativePower);
                    txtRelativePower.Text = relativePower.ToString("F3");
                }

                if (cbSaveData.Checked)
                    _expWriter.WriteLine(string.Format(_saveDataLineFormat, _elapsedMilliseconds, _receivedTemperature, _calibratedTemperature, _thermalDose, _laser?.GetPower()));

                SetGraphData();
            }                    
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

        private void saveConfigAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdSaveConfigAs.ShowDialog() == DialogResult.OK)
            {
                _configPath = sfdSaveConfigAs.FileName;
                SaveAppConfiguration();
            }
        }

        private void loadConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofdLoadConfig.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.AppConfiguration = ofdLoadConfig.FileName;
                Properties.Settings.Default.Save();
                LoadAppConfiguration();
            }
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

        private void documentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/naitsok/controlled-ptt");
        }

        private void aboutControlledPTTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _aboutBox.ShowDialog();
        }

        #endregion
    }
}
