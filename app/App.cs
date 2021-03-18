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
        private string _expBaseDir = "";
        private string _expDir = "";
        private string _expFileName = "";
        private string _expFilePath = "";
        private double _calibratedTemperature = 0;
        // PID
        private PID _pid = null;
        private double _targetTemperature = 50;
        // Timer for experiment.
        private Timer _experimentTimer = new Timer() { Interval = 1000 };
        // string with the format to save data depending on the experiment type
        private string _saveDataLineHeader = "Time (sec)\tRaw Sensor Data\tCalibrated Temperature";
        private string _saveDataLineFormat = "{0}\t{1:F2}\t{2:F2}";
        // StreamWriter to save data
        private StreamWriter _expWriter = null;
        // Variables to keep track of experiment
        private bool _expGoing = false;
        private int _elapsedSeconds = 0;

        private double _time = 0;

        private string _tempSavePath = AppDomain.CurrentDomain.BaseDirectory;

        

        private bool _isTempRecording = false;

        private CultureInfo _culInfo = CultureInfo.InvariantCulture;

        private int _secondsTillEnd = 0;

        // Plot models.
        private PlotModel _objTemperaturePM = new PlotModel()
        {
            Title = "Object Temperature",
            PlotAreaBackground = OxyColors.White,
            DefaultColors = new List<OxyColor>
            {
                OxyColors.Red,
                OxyColors.Green,
                OxyColors.Blue
            },
            TitleFontSize = 10,
            TitleFontWeight = 400,
            LegendFontWeight = 500,
            LegendFontSize = 14,
            LegendTextColor = OxyColors.Black,
            LegendPosition = LegendPosition.RightTop,
        };

        // Scaling and setting the Graph.
        private void SetGraphData(PlotView pw, double x, double[] ys, bool isLaserGraph)
        {
            var xAxis = pw.Model.Axes[0];
            var yAxis = pw.Model.Axes[1];

            double minY = ys.Min();
            double maxY = ys.Max();

            // Scale X axis.
            if (x > xAxis.Maximum - 30)
            {
                xAxis.Maximum += 50;
                xAxis.Minimum += 50;
            }

            // Scale Y axis.
            if (isLaserGraph)
            {
                if (yAxis.Maximum - 0.1 < maxY)
                    yAxis.Maximum += 0.1;
                if (yAxis.Maximum - 0.3 > maxY)
                    yAxis.Maximum -= 0.1;
                if (yAxis.Minimum + 0.1 > minY)
                    yAxis.Minimum -= 0.1;
                if (yAxis.Minimum + 0.3 < minY)
                    yAxis.Minimum += 0.1;
            }
            else
            {
                if (yAxis.Maximum - 1 < maxY)
                    yAxis.Maximum += 1;
                if (yAxis.Maximum - 3 > maxY)
                    yAxis.Maximum -= 1;
                if (yAxis.Minimum + 1 > minY)
                    yAxis.Minimum -= 1;
                if (yAxis.Minimum + 3 < minY)
                    yAxis.Minimum += 1;
            }

            // Set data.
            for (int i = 0; i < ys.Length; i++)
            {
                (pw.Model.Series[i] as LineSeries).Points.Add(new DataPoint(x, ys[i]));
            }
            pw.InvalidatePlot(false);
        }

        // Info methods
        private void AddInfo(string txt)
        {
            AppendText(rtbInfo, txt + "\n", Color.Black);
        }

        private void AddError(string txt)
        {
            AppendText(rtbInfo, txt + "\n", Color.Red);
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

            // Load settings
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


            // get information about experiment and set values
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
            nudPropGain.Value = (decimal)_pid.PGain;
            nudIntGain.Value = (decimal)_pid.IGain;
            nudDiffGain.Value = (decimal)_pid.DGain;

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

            // To log information.
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("logfile.json", shared: true)
                .CreateLogger();

            _experimentTimer.Tick += new EventHandler(this.experimentTimer_Tick);

            // object temperature plot axes
            _objTemperaturePM.Axes.Add(new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                Minimum = 0,
                Maximum = 120,
                IsAxisVisible = false
            });
            _objTemperaturePM.Axes.Add(new LinearAxis()
            {
                Position = AxisPosition.Left,
                Minimum = 17,
                Maximum = 23
            });
            // object temperature plot series
            _objTemperaturePM.Series.Add(new LineSeries()
            {
                Title = "Sensor",
                TextColor = OxyColors.Red
            });
            //series for calibrated temperature
            _objTemperaturePM.Series.Add(new LineSeries()
            {
                Title = "Calibrated",
                TextColor = OxyColors.Green,
                IsVisible = true
            });
            // series for target temperature in PID controller
            _objTemperaturePM.Series.Add(new LineSeries()
            {
                Title = "Target",
                TextColor = OxyColors.Blue,
                IsVisible = true
            });
            pltTemperature.Model = _objTemperaturePM;
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
            _calibration.ShowDialog();
            DisplayCalibration();
        }

        private void btnNewCalibration_Click(object sender, EventArgs e)
        {
            Calibration newCalibration = new Calibration();
            DialogResult result = newCalibration.ShowDialog();
            if (result == DialogResult.OK)
                _calibration = newCalibration;
            DisplayCalibration();
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

            // TODO: Check laser connection!
            // TODO: Laser API and laser base class to be developed!

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

            if (File.Exists(_expFileName))
            {
                DialogResult result = MessageBox.Show("File with the selected name already exists. Do you want to overwrite it?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                    return false;
            }

            // Generate the tempalte string for saving the data depending on the selected experimental parameters
            _saveDataLineHeader = "Time (sec)\tRaw Sensor Data\tCalibrated Temperature";
            _saveDataLineFormat = "{0}\t{1:F2}\t{2:F2}";
            if (cmbExperimentType.SelectedIndex > 0)
            {
                // Laser will be used in the experiment
                _saveDataLineHeader = _saveDataLineHeader + "\tLaser Power";
                _saveDataLineFormat = _saveDataLineFormat + "\t{3:F2}";
            }

            return true;
        }

        /// <summary>
        /// Disables and changes controls when experiment is running
        /// </summary>
        private void DisableControlsExperimentStarted()
        {
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
            gbLaser.Enabled = true;
            nudTargetTemp.Enabled = true;
        }

        private void btnStartExperiment_Click(object sender, EventArgs e)
        {
            if (_expGoing)
            {
                EnableControlsExperimentFinished();

                _expGoing = false;
                _experimentTimer.Stop();
            }
            else
            {
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
                            if (cmbExperimentType.SelectedIndex > 0)
                                laser = cmbLasers.SelectedText;
                            if (cmbExperimentType.SelectedIndex == 2)
                            {
                                // PID Controlled PTT selected
                                pidParams = "proportional = " + nudPropGain.Value.ToString("F2") + "; integral = " +
                                    nudIntGain.Value.ToString("F2") + "; differential = " + nudDiffGain.Value.ToString("F2");
                            }
                            string header =
                                "File Name: " + _expFileName + Environment.NewLine +
                                "File Directory: " + _expDir + Environment.NewLine +
                                "Experiment: " + cmbExperimentType.SelectedText + Environment.NewLine +
                                "Description: " + txtDescription.Text + Environment.NewLine +
                                "Operator: " + txtOperator.Text + Environment.NewLine +
                                "Settings: " + _configPath + Environment.NewLine +
                                "Sensor: " + cmbSensors.SelectedText + Environment.NewLine +
                                "Calibration: " + _calibration.CalibrationFile + Environment.NewLine +
                                "PID parameters: " + pidParams + Environment.NewLine +
                                "Laser: " + laser + Environment.NewLine +
                                "Experiment time: " + nudExpTime.Value.ToString("F2") + " min";
                            _expWriter.WriteLine(header);
                        }

                        // Save first lines
                        _expWriter.WriteLine(_saveDataLineHeader);
                        _expWriter.WriteLine(string.Format(_saveDataLineFormat, 0, _receivedTemperature, _calibratedTemperature /* , _laser.GetLaserPower() */));

                        
                    }

                    DisableControlsExperimentStarted();

                    // TODO: switch on laser (possibly disable laser controls as well, but maybe not needed)
                    

                    _elapsedSeconds = 0;
                    txtElapsedTime.Text = TimeSpan.FromSeconds(_elapsedSeconds).ToString("HH:mm:ss");

                    _expGoing = true;
                    _experimentTimer.Start();
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
            if (_expGoing)
            {
                if (_elapsedSeconds > (int)(nudExpTime.Value * 60))
                {
                    // Stop the experiment when the time is over. Write all the data if specified.
                    if (cbSaveData.Checked)
                    {
                        _expWriter.Flush();
                        _expWriter.Close();
                    }

                    EnableControlsExperimentFinished();

                    // TODO: Laser off
                    _expGoing = false;
                    _experimentTimer.Stop();
                }
                else
                {
                    // Experiment is going
                    _elapsedSeconds += 1;
                    txtElapsedTime.Text = TimeSpan.FromSeconds(_elapsedSeconds).ToString("HH:mm:ss");

                    if (cmbExperimentType.SelectedIndex == 2)
                    {
                        // PID Controled PTT is on
                        // TODO: uncomment
                        // _laser.SetPower(_pid.Compute(_calibratedTemperature, _targetTemperature));
                    }

                    if (cbSaveData.Checked)
                        _expWriter.WriteLine(string.Format(_saveDataLineFormat, _elapsedSeconds, _receivedTemperature, _calibratedTemperature /* , _laser.GetLaserPower() */));
                }
            }
            else
            {
                // Experiment is stopped manually by clicking the button
                if (cbSaveData.Checked)
                {
                    _expWriter.Flush();
                    _expWriter.Close();
                }

                EnableControlsExperimentFinished();

                // TODO: Laser off
                _expGoing = false;
                _experimentTimer.Stop();
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
                _config["pid"]["proportional"] = _pid.PGain;
                _config["pid"]["integral"] = _pid.IGain;
                _config["pid"]["differential"] = _pid.DGain;

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
            _pid.PGain = (double)nudPropGain.Value;
            _pid.Reset();
        }

        private void nudIntGain_ValueChanged(object sender, EventArgs e)
        {
            _pid.IGain = (double)nudIntGain.Value;
            _pid.Reset();
        }

        private void nudDiffGain_ValueChanged(object sender, EventArgs e)
        {
            _pid.DGain = (double)nudDiffGain.Value;
            _pid.Reset();
        }
    }
}
