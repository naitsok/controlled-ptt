using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseSensor;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.WindowsForms;
using OxyPlot.Series;
using System.IO;
using Serilog;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MainApp
{
    public partial class MainAppForm : Form
    {
        // Base directory where executable is located
        private static string BASE_DIR = Directory.GetCurrentDirectory();
        // Configuration from base_settings.json located in the same directory as the executable
        // base_settings.json contains path for settings saved by user
        private static string BASE_CONFIG_PATH = Path.Combine(BASE_DIR, "base_settings.json");
        private JObject _baseConfig = null;
        // If settings saved by user are not found - load default ones.
        private static string DEFAULT_CONFIG_PATH = Path.Combine(BASE_DIR, "default_settings.json");
        // Config path to be loaded from base_settings.json
        private string _configPath = "";
        private JObject _config = null;

        // Sensors
        private List<string> _sensorPaths = new List<string>();
        private int _selectedSensorIndex = 0;
        private BaseSensorForm _sensorForm = null;
        private double _receivedTemperature = 0;
        private  static int NUM_LAST_TEMPS = 10;
        private List<double> _checkTemperatureChanging = Enumerable.Repeat(0.0, NUM_LAST_TEMPS).ToList();
        private bool _isSensorSendingTemperature = false;

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
        private Timer _experimentTimer = new Timer()
        {
            Interval = 1000
        };
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

        /// <summary>
        /// Finds through Sensor ot Laser parts that can be connected to the MainApp
        /// </summary>
        /// <param name="partsPath"></param>
        private void FindSesnsorLaserParts(string partsPath)
        {
            if (!Path.IsPathRooted(partsPath))
            {
                partsPath = Path.GetFullPath(Path.Combine(BASE_DIR, partsPath));
            }

            string debugRelease = @"bin\Release";
#if DEBUG
            debugRelease = @"bin\Debug";
#endif

            string[] allPartExes = Directory.GetFiles(partsPath, "*.exe", SearchOption.AllDirectories);
            List<string> partExecs = new List<string>();
            foreach (string partExe in allPartExes)
            {
                if (partExe.Contains(debugRelease) && !partExe.Contains("ref"))
                {
                    partExecs.Add(partExe);
                }
            }
            // string[] subDirs = Directory.GetDirectories(partsPath, "*", SearchOption.AllDirectories);

            
        }

        public MainAppForm()
        {
            InitializeComponent();

            // Load settings
            // First load path to settings from base_settings.json which is in the same folder as .exe
            _baseConfig = JObject.Parse(File.ReadAllText(Path.GetFullPath(BASE_CONFIG_PATH)));
            _configPath = (string)_baseConfig["appsettings"];
            if (!Path.IsPathRooted(_configPath))
                _configPath = Path.GetFullPath(Path.Combine(BASE_DIR, _configPath));
            // Load settings either saved by user or default ones
            if (File.Exists(_configPath))
                _config = JObject.Parse(File.ReadAllText(_configPath));
            else
            {
                _config = JObject.Parse(File.ReadAllText(Path.GetFullPath(DEFAULT_CONFIG_PATH)));
                _configPath = DEFAULT_CONFIG_PATH;
            }

            saveCurrentSettingsWhenClosingToolStripMenuItem.Checked = (bool)_config["save_settings_on_closing"];

            // get base_sensor_path if necessary
            string base_sensor_path = (string)_config["base_sensor_path"];

            // get information about sensors and selected the indicated one
            _selectedSensorIndex = (int)_config["selected_sensor_index"] - 1;
            foreach (JToken token in _config["sensors"])
            {
                cmbSensors.Items.Add(token["title"]);
                FindSesnsorLaserParts(base_sensor_path);
                _sensorPaths.Add(Path.GetFullPath(Path.Combine(base_sensor_path, (string)token["path"])));
            }
            if (_selectedSensorIndex >= 0 && _selectedSensorIndex < cmbSensors.Items.Count)
            {
                cmbSensors.SelectedIndex = _selectedSensorIndex;
            }

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
            displayCalibration();
            cbUseCalibration.Checked = (bool)_config["use_calibration"];
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
            this.pltTemperature.Model = _objTemperaturePM;
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
                // get sensor executable name and add it to list
                string fileName = Path.GetFileNameWithoutExtension(ofdSelectSensor.FileName);
                if (!cmbSensors.Items.Contains(fileName))
                {
                    cmbSensors.Items.Add(fileName);
                    _sensorPaths.Add(ofdSelectSensor.FileName);
                    cmbSensors.SelectedIndex = cmbSensors.Items.Count - 1;
                }
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
                    ". Check the settings file or load the part manually using \"Load from file\" button.",
                    "Sensor part not found.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // load the sensor part
            Assembly sensorAssembly = Assembly.LoadFrom(_sensorPaths[cmbSensors.SelectedIndex]);
            var types = sensorAssembly.GetExportedTypes();
            _sensorForm = Activator.CreateInstance(types[0]) as BaseSensorForm;
            _sensorForm.FormClosed += sensorForm_FormClosed;
            _sensorForm.OnTemperatureSent += sensorForm_TemperatureSent;
            _sensorForm.Show();

            // Organize windows
            _sensorForm.Location = new Point(5, 10);
            this.Location = new Point(10 + _sensorForm.Size.Width, 10);

            // Disable controls
            gbSensor.Enabled = false;
        }

        /// <summary>
        /// When sensor form is closed, the resources must be released.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sensorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _sensorForm.FormClosed -= sensorForm_FormClosed;
            _sensorForm.OnTemperatureSent -= sensorForm_TemperatureSent;
            gbSensor.Enabled = true;
            _isSensorSendingTemperature = false;
        }

        /// <summary>
        /// Get the calibration parameters, such as Slope and Intersept, and displays them
        /// on the controls.
        /// </summary>
        private void displayCalibration()
        {
            txtCalibration.Text = _calibration.CalibrationFile;
            txtCalibration.SelectionStart = txtCalibration.Text.Length;
            txtCalibration.ScrollToCaret();
            txtSlope.Text = _calibration.Slope.ToString("F3");
            txtIntercept.Text = _calibration.Intercept.ToString("F3");
        }

        private void btnModifyCalibration_Click(object sender, EventArgs e)
        {
            _calibration.ShowDialog();
            displayCalibration();
        }

        private void btnNewCalibration_Click(object sender, EventArgs e)
        {
            _calibration = new Calibration();
            _calibration.ShowDialog();
            displayCalibration();
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
                return true;
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

        private void SaveSettings()
        {
            // Settings from menu should be always saved
            _config["save_settings_on_closing"] = saveCurrentSettingsWhenClosingToolStripMenuItem.Checked;

            if (saveCurrentSettingsWhenClosingToolStripMenuItem.Checked)
            {
                // Check new sensors were added
                if (_config["sensors"].Count() < cmbSensors.Items.Count)
                {
                    JArray sensors = (JArray)_config["sensors"];
                    for (int i = sensors.Count(); i < cmbSensors.Items.Count; i++)
                        sensors.Add(new JObject(
                            new JProperty("title", cmbSensors.Items[i].ToString()),
                            new JProperty("path", _sensorPaths[i])
                            ));
                }
                // Save sensor selected index
                _config["selected_sensor_index"] = cmbSensors.SelectedIndex + 1;

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
            _baseConfig["appsettings"] = _configPath;
            File.WriteAllText(BASE_CONFIG_PATH, _baseConfig.ToString());
        }

        /// <summary>
        /// Save settings upon closing if necessary.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();

            _calibration.Dispose();
            // Log.CloseAndFlush();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveSettings();
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
