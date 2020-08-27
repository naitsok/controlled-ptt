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
using Newtonsoft.Json;
using System.Reflection;

namespace MainApp
{
    public partial class MainApp : Form
    {
        // configuration from appsettings.json
        private static string CONFIG_PATH = @".\appsettings.json";
        private JObject _config = null;

        // sensors
        private List<string> _sensorPaths = new List<string>();
        private int _selectedSensorIndex = 0;
        private BaseSensorForm _sensorForm = null;
        private double _receivedTemperature = 0;

        // Timer for experiment.
        private Timer _experimentTimer = new Timer()
        {
            Interval = 1000
        };

        // Timer for calibration.
        private Timer _calibrationTimer = new Timer()
        {
            Interval = 1000
        };

        private bool _expGoing = false;

        private double _time = 0;

        private string _tempSavePath = AppDomain.CurrentDomain.BaseDirectory;

        private StreamWriter _tempWriter = null;

        private bool _isTempRecording = false;

        private CultureInfo _culInfo = CultureInfo.InvariantCulture;

        private int _secondsTillEnd = 0;

        //Instances of forms.
        private CalibrationForm calibration = new CalibrationForm();


        // Plot models.
        private PlotModel _objTempPlotModel = new PlotModel()
        {
            Title = "Object Temperature",
            PlotAreaBackground = OxyColors.Black,
            DefaultColors = new List<OxyColor>
            {
                OxyColors.Red,
                OxyColors.Green,
                OxyColors.Blue
            },
            TitleFontSize = 10,
            TitleFontWeight = 400,
            LegendFontWeight = 500,
            LegendFontSize = 16,
            LegendTextColor = OxyColors.White
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
        public MainApp()
        {
            InitializeComponent();

            // Load configuration from appsettings.json
            _config = JObject.Parse(File.ReadAllText(CONFIG_PATH));

            saveCurrentSettingsWhenClosingToolStripMenuItem.Checked = (bool)_config["save_settings_on_closing"];

            // get dev_path if necessary
            string dev_path = (string)_config["dev_path"];

            // get information about sensors and selected the indicated one
            _selectedSensorIndex = (int)_config["selected_sensor_index"] - 1;
            foreach (JToken token in _config["sensors"])
            {
                cmbSensors.Items.Add(token["title"]);
                _sensorPaths.Add(Path.GetFullPath(Path.Combine(dev_path, (string)token["path"])));
            }
            if (_selectedSensorIndex >= 0 && _selectedSensorIndex < cmbSensors.Items.Count)
            {
                cmbSensors.SelectedIndex = _selectedSensorIndex;
            }
            

            // To log information.
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("logfile.json", shared: true)
                .CreateLogger();

            _experimentTimer.Tick += new EventHandler(this.experimentTimer_Tick);
            _calibrationTimer.Tick += new EventHandler(this.calibrationTimer_Tick);

            tbTempFilePath.Text = _tempSavePath;
            txtTempFileName.Text = "Record_" + DateTime.Now.ToString("dd-MM-yy-hh-mm-ss") + ".txt";

            // object temperature plot axes
            _objTempPlotModel.Axes.Add(new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                Minimum = 0,
                Maximum = 120,
                IsAxisVisible = false
            });
            _objTempPlotModel.Axes.Add(new LinearAxis()
            {
                Position = AxisPosition.Left,
                Minimum = 17,
                Maximum = 23
            });
            // object temperature plot series
            _objTempPlotModel.Series.Add(new LineSeries()
            {
                Title = "Sensor",
                TextColor = OxyColors.Red
            });
            //series for calibrated temperature
            _objTempPlotModel.Series.Add(new LineSeries()
            {
                Title = "Calibrated",
                TextColor = OxyColors.Green,
                IsVisible = true
            });
            // series for target temperature in PID controller
            _objTempPlotModel.Series.Add(new LineSeries()
            {
                Title = "Target",
                TextColor = OxyColors.Blue,
                IsVisible = true
            });
            this.pltObjTemp.Model = _objTempPlotModel;
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
            btnStartSensor.Enabled = false;
            btnLoadSensor.Enabled = false;
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
            btnStartSensor.Enabled = true;
            btnLoadSensor.Enabled = true;
        }

        /// <summary>
        /// Receive temperature from the sensor form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sensorForm_TemperatureSent(object sender, TemperatureSentEventArgs e)
        {
            _receivedTemperature = e.Temperature;
        }

        private void btnLoadSensor_Click(object sender, EventArgs e)
        {
            selectSensorDialog.ShowDialog();
        }

        private void selectSensorDialog_FileOk(object sender, CancelEventArgs e)
        {
            // get sensor executable name and add it to list
            string fileName = Path.GetFileNameWithoutExtension(selectSensorDialog.FileName);
            if (!cmbSensors.Items.Contains(fileName))
            {
                cmbSensors.Items.Add(fileName);
                _sensorPaths.Add(selectSensorDialog.FileName);
                cmbSensors.SelectedIndex = cmbSensors.Items.Count - 1;
            }
        }

        private void BtnSelectSensor_Click(object sender, EventArgs e)
        {
          //if (cmbSensors.SelectedIndex == 0)
          //  {
          //      Log.Information("MLX90621 Infrared (IR) sensor array selected.");
          //      array = new ArraySensor();
          //      array.Show();
          //      btnSelectSensor.Enabled = false;
          //  }
          //else if (cmbSensors.SelectedIndex == 1)
          //  {
          //      Log.Information("MLX90614 Infrared Thermometer selected.");
          //      oneMlxSensor = new OneMLXForm();
          //      oneMlxSensor.Show();
          //      btnSelectSensor.Enabled = false;
          //  }
          //else if (cmbSensors.SelectedIndex == 2)
          //  {
          //      Log.Information("Two MLX90614 Infrared Thermometers selected.");
          //      twoMlxSensors = new TwoMLXForm();
          //      twoMlxSensors.Show();
          //      btnSelectSensor.Enabled = false;
          //  }
          //else
          //  {
          //      AddError("No sensor selected.");
          //  }         
        }

        private void BtnStartExperiment_Click(object sender, EventArgs e)
        {          
            //if (!_expGoing)
            //{
            //    Log.Information("Experiment started. Timer set to {0} minutes.", nudExpTime.Value);
            //    if (btnSelectSensor.Enabled == false) // To see if sensor has been selected.
            //    {
            //        // To see if send button is enabled on sensor's interface.
            //        if (array.AvgTemperature != null || oneMlxSensor.ObjectTemperature != null || twoMlxSensors.AvgObjTemperature != null)  
            //        {
            //            _expGoing = true;
            //            btnStartExperiment.Text = "Stop Experiment";
            //            txtExperimentStarted.Text = "Experiment Going";
            //            txtExperimentStarted.BackColor = Color.Green;
            //            _experimentTimer.Start();
            //            _secondsTillEnd = (int)(nudExpTime.Value * 60);
            //            txtExpTime.Visible = true;
            //            nudExpTime.Visible = false;
            //            txtExpTime.Text = TimeSpan.FromSeconds(_secondsTillEnd).ToString();
            //            if (cbSaveData.Checked)
            //            {
            //                _isTempRecording = true;
            //                string fileName = txtTempFileName.Text;
            //                if (string.IsNullOrWhiteSpace(fileName) || fileName.StartsWith("Record_"))
            //                {
            //                    fileName = "Record_" + DateTime.Now.ToString("dd-MM-yy-hh-mm-ss") + ".txt";
            //                }
            //                if (!fileName.ToUpper().EndsWith(".TXT"))
            //                    fileName = fileName + ".txt";
            //                txtTempFileName.Text = fileName;
            //                string filePath = Path.Combine(tbTempFilePath.Text, fileName);
            //                _tempWriter = new StreamWriter(filePath);
            //                _tempWriter.WriteLine("Time (s)\tObject temperature \t Calibrated object temperature");
                            
            //            }
            //        }
            //        else
            //        {
            //            AddError("No data received. Please, verify that sending is enabled on the sensor's interface.");
            //        }
            //    }
            //    else
            //    {
            //        AddError("No sensor selected.");
            //    }
            //}
            //else
            //{
            //    Log.Information("Experiment has ended.");
            //    _expGoing = false;
            //    btnStartExperiment.Text = "Start Experiment";
            //    txtExperimentStarted.Text = "Experiment Not Going";
            //    txtExperimentStarted.BackColor = Color.Red;
            //    _experimentTimer.Stop();
            //    array.AvgTemperature = null;
            //    oneMlxSensor.ObjectTemperature = null;
            //    twoMlxSensors.AvgObjTemperature = null;
            //    txtExpTime.Visible = false;
            //    nudExpTime.Visible = true;
            //    if (_isTempRecording)
            //    {
            //        _tempWriter.Flush();
            //        _tempWriter.Close();
            //        _isTempRecording = false;
            //    }
            //}
        }

        private void experimentTimer_Tick(object sender, EventArgs e)
        {
            //if (_secondsTillEnd <= 0)   // If the time selected for the experiment has elapsed.
            //{
            //    Log.Information("Experiment has ended.");
            //    _expGoing = false;
            //    btnStartExperiment.Text = "Start Experiment";
            //    txtExperimentStarted.Text = "Experiment Not Going";
            //    txtExperimentStarted.BackColor = Color.Red;
            //    txtExpTime.Visible = false;
            //    nudExpTime.Visible = true;
            //    _experimentTimer.Stop();
            //    if (_isTempRecording)
            //    {
            //        _tempWriter.Flush();
            //        _tempWriter.Close();
            //        _isTempRecording = false;
            //    }
            //}
            //else    // Else plots and records temperature every timer tick.
            //{
            //    _time += 1;
            //    if (cmbSensors.SelectedIndex == 0)
            //    {
            //        try
            //        {                      
            //            double objTemp = Convert.ToDouble(array.AvgTemperature);
            //            double calObjTemp = objTemp * calibration._sensorCalA + calibration._sensorCalB;
            //            if (!cbNoCalibration.Checked) 
            //            {
            //                SetGraphData(pltObjTemp, _time, new double[] { objTemp, calObjTemp }, false);
            //                if (_isTempRecording)
            //                {
            //                    _tempWriter.WriteLine(_time.ToString(_culInfo) + "\t" + "\t" + "\t" + objTemp.ToString(_culInfo) + "\t" + "\t" + "\t" + "\t" + calObjTemp.ToString("F"));
            //                }
            //            }
            //            else
            //            {
            //                SetGraphData(pltObjTemp, _time, new double[] { objTemp }, false);
            //                if (_isTempRecording)
            //                {
            //                    _tempWriter.WriteLine(_time.ToString(_culInfo) + "\t" + "\t" + "\t" + objTemp.ToString(_culInfo));
            //                }
            //            }
            //        }
            //        catch (FormatException ex) { Log.Error(ex.ToString()); }
            //    }
            //    else if (cmbSensors.SelectedIndex == 1)
            //    {
            //        try
            //        {
            //            double objTemp = Convert.ToDouble(oneMlxSensor.ObjectTemperature, CultureInfo.InvariantCulture);
            //            double ambTemp = Convert.ToDouble(oneMlxSensor.AmbientTemperature, CultureInfo.InvariantCulture);
            //            double calObjTemp = objTemp * calibration._sensorCalA + calibration._sensorCalB;
            //            SetGraphData(pltAmbTemp, _time, new double[] { ambTemp }, false);
            //            if (!cbNoCalibration.Checked)
            //            {
            //                SetGraphData(pltObjTemp, _time, new double[] { objTemp, calObjTemp }, false);      
            //                if (_isTempRecording)
            //                {
            //                    _tempWriter.WriteLine(_time.ToString(_culInfo) + "\t" + "\t" + "\t" + objTemp.ToString(_culInfo) + "\t" + "\t" + "\t" + "\t" + calObjTemp.ToString("F"));
            //                }
            //            }
            //            else
            //            {
            //                SetGraphData(pltObjTemp, _time, new double[] { objTemp }, false);
            //                if (_isTempRecording)
            //                {
            //                    _tempWriter.WriteLine(_time.ToString(_culInfo) + "\t" + "\t" + "\t" + objTemp.ToString(_culInfo));
            //                }
            //            }
            //        }
            //        catch (FormatException ex) { Log.Error(ex.ToString()); }
            //    }
            //    else if (cmbSensors.SelectedIndex == 2)
            //    {
            //        try
            //        {
            //            double objTemp = Convert.ToDouble(twoMlxSensors.AvgObjTemperature);
            //            double ambTemp = Convert.ToDouble(twoMlxSensors.AvgAmbTemperature);
            //            double calObjTemp = objTemp * calibration._sensorCalA + calibration._sensorCalB;
            //            SetGraphData(pltAmbTemp, _time, new double[] { ambTemp }, false);
            //            if (!cbNoCalibration.Checked)
            //            {
            //                SetGraphData(pltObjTemp, _time, new double[] { objTemp, calObjTemp }, false);
                            
            //                if (_isTempRecording)
            //                {
            //                    _tempWriter.WriteLine(_time.ToString(_culInfo) + "\t" + "\t" + "\t" + objTemp.ToString(_culInfo) + "\t" + "\t" + "\t" + "\t" + calObjTemp.ToString("F"));
            //                }
            //            }
            //            else
            //            {
            //                SetGraphData(pltObjTemp, _time, new double[] { objTemp }, false);

            //                if (_isTempRecording)
            //                {
            //                    _tempWriter.WriteLine(_time.ToString(_culInfo) + "\t" + "\t" + "\t" + objTemp.ToString(_culInfo));
            //                }
            //            }
            //        }
            //        catch (FormatException ex) { Log.Error(ex.ToString()); }
            //    }
            //    txtExpTime.Text = TimeSpan.FromSeconds(_secondsTillEnd).ToString();
            //    _secondsTillEnd -= 1;
            //}                                   
        }

        // Disposes all the forms when closing the main form. (Not sure if necessary).
        private void MainApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Settings from menu should be always saved
            _config["save_settings_on_closing"] = saveAsToolStripMenuItem.Checked;

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
            }
            File.WriteAllText(CONFIG_PATH, _config.ToString());

            calibration.Dispose();
            Log.CloseAndFlush();
        }

        // User can select path where to save experiment data.
        private void BtnSelectTempPath_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    _tempSavePath = fbd.SelectedPath;
                    tbTempFilePath.Text = fbd.SelectedPath;
                }
            }
        }
        private void BtnCalibration_Click(object sender, EventArgs e)
        {
      
            //if (btnSelectSensor.Enabled == false)
            //{             
            //    btnCalibration.Enabled = false;
            //    Log.Information("Calibration has started.");
            //    calibration = new CalibrationForm();
            //    _calibrationTimer.Start();
            //    calibration._evtForm += new ShowFrm(CalibrationHelper);  // Method for enabling Calibration button from calibration form.            
            //    calibration.Show();
            //}
            //else
            //    AddError("No Sensor Selected.");           
        }

        // Calibration timer needed for sending varying temperature value to the calibration form each second.
        private void calibrationTimer_Tick(object sender, EventArgs e)
        {
            //if (cmbSensors.SelectedIndex == 0)
            //{
            //    try
            //    {
            //        calibration._objTemp = Convert.ToDouble(array.AvgTemperature);
            //    }
            //    catch { calibration._objTemp = 0; }
            //}
            //else if (cmbSensors.SelectedIndex == 1)
            //{
            //    try
            //    {
            //        calibration._objTemp = Convert.ToDouble(oneMlxSensor.ObjectTemperature, CultureInfo.InvariantCulture);
            //    }
            //    catch { calibration._objTemp = 0; }
            //}
            //else if (cmbSensors.SelectedIndex == 2)
            //{
            //    try
            //    {
            //        calibration._objTemp = Convert.ToDouble(twoMlxSensors.AvgObjTemperature);
            //    }
            //    catch { calibration._objTemp = 0; }
            //}
            
        }

        // To enable button from calibration form and stopping the timer.
        private void CalibrationHelper()
        {
            btnCalibration.Enabled = true;
            _calibrationTimer.Stop();
        }
    }
}
