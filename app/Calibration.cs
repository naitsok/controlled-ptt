using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using Serilog;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.WindowsForms;
using OxyPlot.Series;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace MainApp
{
    public delegate void ShowFrm();

    /// <summary>
    /// Performs caliblration for sensor. Can save and load previous calibrations in json format.
    /// </summary>
    public partial class Calibration : Form
    {
        public string CalibrationFile { get; set; } = "";
        private JObject _calibration = null;

        public double Slope { get; set; } = 1;
        public double Intercept { get; set; } = 0;

        private List<double> _sensorTemps = new List<double>();
        private List<double> _correctTemps = new List<double>();

        // helpers
        private bool _cancelClicked = false;

        // Keeps the value of current sensor temperature
        // Value is set in the MainAppForm when recieved from sensor
        public double SensorTemperature { get; set; }

        // Timer for calibration
        // On each tick reads temperature from SensorTemperature variable
        // and updated dgCalibration as well as the sensor
        // and calibrated temperature cotrols
        private Timer _calTimer = new Timer()
        {
            Interval = 1000
        };

        public double _sensorCalA { get; set; }

        public double _sensorCalB { get; set; }

        private StreamWriter _tempWriter = null;

        // Calibration plot.
        private PlotModel _calibrationPM = new PlotModel()
        {
            Title = "Calibration",
            PlotAreaBackground = OxyColors.White,
            DefaultColors = new List<OxyColor>
            {
                OxyColors.Blue,
                OxyColors.Red,
            },
            TitleFontSize = 12,
            TitleFontWeight = 400,
            LegendFontWeight = 500,
            LegendFontSize = 12,
            LegendPosition = LegendPosition.LeftTop,
            LegendTextColor = OxyColors.Black,
        };

        // Function to make linear least squares estimation.
        private void LeastSquares()
        {
            // check there is data to do calculation
            if (_sensorTemps.Count == 0 || _correctTemps.Count == 0)
            {
                MessageBox.Show("There is not enough data to calculate least squares. Check the data table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_sensorTemps.Count != _correctTemps.Count)
            {
                MessageBox.Show("There is not enough data to calculate least squares. Check the data table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Caluclate least squares
            int numPoints = _sensorTemps.Count;
            double sumX = 0;
            double sumY = 0;
            double sumXsquared = 0;
            double sumXY = 0;
            for (int i = 0; i < numPoints; i++)
            {
                sumX += _sensorTemps[i];
                sumY += _correctTemps[i];
                sumXsquared += _sensorTemps[i] * _sensorTemps[i];
                sumXY += _sensorTemps[i] * _correctTemps[i];
            }

            Slope = (sumXY * numPoints - sumX * sumY) / (sumXsquared * numPoints - sumX * sumX);
            Intercept = (sumXY * sumX - sumXsquared * sumY) / (sumX * sumX - numPoints * sumXsquared);
        }

        public Calibration()
        {
            InitializeComponent();

            _calTimer.Tick += new EventHandler(this.CalibrationTimer_Tick);

            // Calibration plot.
            _calibrationPM.Axes.Add(new LinearAxis()
            {
                Title = "Sensor Temperature",
                Position = AxisPosition.Bottom,
                Minimum = 0,
                Maximum = 50,

            });
            _calibrationPM.Axes.Add(new LinearAxis()
            {
                Title = "Correct Temperature",
                Position = AxisPosition.Left,
                Minimum = 0,
                Maximum = 50
            });
            // Series for sensor temperature.
            _calibrationPM.Series.Add(new ScatterSeries()
            {
                Title = "Data Points",
                MarkerType = MarkerType.Cross,
                MarkerSize = 5,
                MarkerStrokeThickness = 3,
                MarkerStroke = OxyColors.Blue,
            });
            _calibrationPM.Series.Add(new LineSeries()
            {
                Title = "Fitted Line",
                TextColor = OxyColors.Red,
            });
            this.pltCalibration.Model = _calibrationPM;
        }

        public Calibration(string calibrationFile = "") : this()
        {
            // Load the calibration if file is set
            if (!string.IsNullOrEmpty(calibrationFile))
            {
                CalibrationFile = Path.GetFullPath(calibrationFile);
                txtCalibFile.Text = CalibrationFile;
                txtCalibFile.SelectionStart = txtCalibFile.Text.Length;
                txtCalibFile.ScrollToCaret();
            }
            LoadCalibration();
        }

        /// <summary>
        /// Sets the graph data.
        /// </summary>
        /// <param name="pw"></param>
        /// <param name="sensorTemps"></param>
        /// <param name="correctTemps"></param>
        /// <param name="drawFit"></param>
        private void SetGraph()
        {
            PlotView pw = pltCalibration;
            var xAxis = pw.Model.Axes[0];
            var yAxis = pw.Model.Axes[1];

            // Get and clear plot series
            ScatterSeries tempsSeries = pw.Model.Series[0] as ScatterSeries;
            tempsSeries.Points.Clear();
            LineSeries calibSeries = pw.Model.Series[1] as LineSeries;
            calibSeries.Points.Clear();

            // check there is something to plot
            if (_sensorTemps.Count == 0 || _correctTemps.Count == 0)
            {
                pw.InvalidatePlot(true);
                return;
            }

            // Scaling the axes
            xAxis.Maximum = _sensorTemps.Max() + 2;
            xAxis.Minimum = _sensorTemps.Min() - 2;
            yAxis.Maximum = _correctTemps.Max() + 2;
            yAxis.Minimum = _correctTemps.Min() - 2;

            // Add new points
            for (int i = 0; i < _sensorTemps.Count; i++)
            {
                tempsSeries.Points.Add(new ScatterPoint(_sensorTemps[i], _correctTemps[i]));
            }

            // Add fitted line
            calibSeries.Points.Add(new DataPoint(xAxis.Minimum, this.Slope * xAxis.Minimum + this.Intercept));
            calibSeries.Points.Add(new DataPoint(xAxis.Maximum, this.Slope * xAxis.Maximum + this.Intercept));

            pw.InvalidatePlot(true);
        }

        private void LoadCalibration()
        {
            if (string.IsNullOrEmpty(this.CalibrationFile))
                return;

            _calibration = JObject.Parse(File.ReadAllText(this.CalibrationFile));
            this.Slope = (double)_calibration["slope"];
            this.Intercept = (double)_calibration["intercept"];
            _sensorTemps = _calibration["sensor_temperatures"].ToObject<List<double>>();
            _correctTemps = _calibration["correct_temperatures"].ToObject<List<double>>();

            // Set up the controls
            SetGraph();
            nudSlope.Value = (decimal)Slope;
            nudIntercept.Value = (decimal)Intercept;
            dgCalibration.Rows.Clear();
            for (int i = 0; i < _sensorTemps.Count; i++)
            {
                dgCalibration.Rows.Add(new string[] { _sensorTemps[i].ToString("F2"), _correctTemps[i].ToString("F2") });
            }
        }

        private void NudSlope_ValueChanged(object sender, EventArgs e)
        {
            Slope = (double)nudSlope.Value;
            SetGraph();
        }

        private void NudIntercept_ValueChanged(object sender, EventArgs e)
        {
            Intercept = (double)nudIntercept.Value;
            SetGraph();
        }

        private void CalibrationTimer_Tick(object sender, EventArgs e)
        {       
            txtSensorTemp.Text = SensorTemperature.ToString("#.##");
            txtCalibratedTemp.Text = (Slope * SensorTemperature + Intercept).ToString("#.##");

            dgCalibration.Rows[dgCalibration.Rows.Count - 1].Cells[0].Value = this.SensorTemperature.ToString("#.##");
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = sfdSaveCalibration.ShowDialog();
            if (result == DialogResult.OK)
            {
                SaveCalibration();
            }  
        }

        /// <summary>
        /// Saves current calibaration to the selected file.s
        /// </summary>
        private void SaveCalibration()
        {
            _calibration["slope"] = this.Slope;
            _calibration["intercept"] = this.Intercept;
            _calibration["sensor_temperatures"] = new JArray(_sensorTemps.ToArray());
            _calibration["correct_temperatures"] = new JArray(_correctTemps.ToArray());

            CalibrationFile = sfdSaveCalibration.FileName;
            txtCalibFile.Text = CalibrationFile;
            txtCalibFile.SelectionStart = txtCalibFile.Text.Length;
            txtCalibFile.ScrollToCaret();

            File.WriteAllText(CalibrationFile, _calibration.ToString());
        }

        /// <summary>
        /// Loads calibration file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdLoadCalibration.ShowDialog();
            if (result == DialogResult.OK)
            {
                CalibrationFile = ofdLoadCalibration.FileName;
                txtCalibFile.Text = CalibrationFile;
                txtCalibFile.SelectionStart = txtCalibFile.Text.Length;
                txtCalibFile.ScrollToCaret();
                LoadCalibration();
            }
        }

        private void Calibration_Load(object sender, EventArgs e)
        {
            _calTimer.Start();
        }

        private void Calibration_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cancelClicked)
            {
                _cancelClicked = false;
                _calTimer.Stop();
                return;
            }

            DialogResult result = MessageBox.Show("All unsaved changes will be lost when exiting the Main App. Would you like to save changes to calibration?",
                "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                result = sfdSaveCalibration.ShowDialog();
                if (result == DialogResult.OK)
                    SaveCalibration();
            }
            else
                _calTimer.Stop();
        }

        /// <summary>
        /// Updates _sensorTemps and _correctTemps if the last row contains data in both columns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgCalibration_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dgCalibration.EndEdit();

            _sensorTemps.Clear();
            _correctTemps.Clear();

            // update arrays with temperatures and graph
            // check that data is in number format
            for (int i = 0; i < dgCalibration.Rows.Count - 1; i++)
            {
                try
                {
                    if (dgCalibration.Rows[i].Cells[0].Value == null)
                        _sensorTemps.Add(0);
                    else
                        _sensorTemps.Add(Convert.ToDouble(dgCalibration.Rows[i].Cells[0].Value.ToString()));

                    if (dgCalibration.Rows[i].Cells[1].Value == null)
                        _correctTemps.Add(0);
                    else
                        _correctTemps.Add(Convert.ToDouble(dgCalibration.Rows[i].Cells[1].Value.ToString()));
                }
                catch (FormatException)
                {
                    MessageBox.Show("The value entered in the cell is not a number. Check '.' and ',' when entering number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _sensorTemps.Clear();
                    _correctTemps.Clear();
                    break;
                }
            }
            SetGraph();
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            LeastSquares();
            nudSlope.Value = (decimal)Slope;
            nudIntercept.Value = (decimal)Intercept;
            SetGraph();
        }
        private void BtnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadCalibration();
            _cancelClicked = true;
            Close();
        }
    }
}
