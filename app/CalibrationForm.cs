using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using Serilog;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.WindowsForms;
using OxyPlot.Series;
using CenterSpace.NMath.Core;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace MainApp
{
    public delegate void ShowFrm();

    /// <summary>
    /// Performs caliblration for sensor. Can save and load previous calibrations in json format.
    /// </summary>
    public partial class CalibrationForm : Form
    {
        public string CalibrationFile { get; set; } = "";
        private JObject _calibration = null;

        public double Slope { get; set; } = 1;
        public double Intercept { get; set; } = 0;

        private List<double> _sensorTemps = null;
        private List<double> _correctTemps = null;

        // Timer for calibration
        private Timer _calTimer = new Timer()
        {
            Interval = 1000
        };

        public double _objTemp { get; set; }

        private double _slope = 0;

        private double _intercept = 0;

        public double _sensorCalA { get; set; }

        public double _sensorCalB { get; set; }

        private StreamWriter _tempWriter = null;

        // Calibration plot.
        private PlotModel _calibrationPlotModel = new PlotModel()
        {
            Title = "Calibration",
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
            LegendFontSize = 10,
            LegendPosition = LegendPosition.LeftTop,
            LegendTextColor = OxyColors.White,
        };

        // Scaling and setting the Graph
        private void SetGraphData(PlotView pw, List<double> sensorTemps, List<double> correctTemps)
        {

            var xAxis = pw.Model.Axes[0];
            var yAxis = pw.Model.Axes[1];

            // Scaling the axes
            xAxis.Maximum = x + 10;
            xAxis.Minimum = sensorTemps + sensorTemps
            yAxis.Maximum = y + 10;

            (pw.Model.Series[0] as ScatterSeries).Points.Add(new ScatterPoint(x, y, 3, 1));
            (pw.Model.Series[1] as ScatterSeries).Points.Add(new DataPoint(xAxis.Minimum, _intercept));
            (pw.Model.Series[2] as LineSeries).Points.Add(new DataPoint(xAxis.Maximum, _slope*xAxis.Maximum + _intercept));
            pw.InvalidatePlot(false);
        }
        
        // Function to make linear least squares estimation.
        private void LeastSquares()
        {
            // Arrays for datagrid's values. Makes matrix and vector creating easier.
            double[] realtempArray = new double[dgCalibration.Rows.Count];
            double[] sensorTempArray = new double[dgCalibration.Rows.Count];

            for (int i = 0; i < dgCalibration.Rows.Count; i++)
            {
                if (dgCalibration.Rows[i].Cells[1].Value != null)   // Includes only values that has been set by user.
                {
                    double sensorTemp = Convert.ToDouble(dgCalibration.Rows[i].Cells[0].Value);
                    double realTemp = Convert.ToDouble(dgCalibration.Rows[i].Cells[1].Value);
                    realtempArray[i] = realTemp;
                    sensorTempArray[i] = sensorTemp;
                }
            }

            // Fitting a straight on Data Points with LS-method.
            DoubleVector y = new DoubleVector(realtempArray);
            DoubleMatrix m = new DoubleMatrix(dgCalibration.Rows.Count, 1, sensorTempArray, StorageType.ColumnMajor);
            var lsq = new DoubleLeastSquares(m, y, true);

            _intercept = lsq.X[0];
            _slope = lsq.X[1];

            nudSensorCalA.Value = (decimal)lsq.X[1];
            nudSensorCalB.Value = (decimal)lsq.X[0];
            
        }

        public CalibrationForm(string calibrationFile = "")
        {
            InitializeComponent();

            CalibrationFile = Path.GetFullPath(calibrationFile);
            LoadCalibration();

            _calTimer.Tick += new EventHandler(this.CalibrationTimer_Tick);
          
            // To log information.
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("C:/Users/mikke/controlledptt-sensor/MainApp/bin/Debug/logfile.json", shared: true)
                .CreateLogger();

            // Calibration plot.
            _calibrationPlotModel.Axes.Add(new LinearAxis()
            {
                Title = "Sensor Temperature",
                Position = AxisPosition.Bottom,
                // Minimum = 0,
                // Maximum = 50,
                
            }) ;
            _calibrationPlotModel.Axes.Add(new LinearAxis()
            {
                Title = "Real Temperature",
                Position = AxisPosition.Left,
                // Minimum = 0,
                // Maximum = 50
            });
            //// Series for sensor temperature.
            _calibrationPlotModel.Series.Add(new ScatterSeries()
            {
                Title = "Data Points",
                MarkerType = MarkerType.Circle,
                TextColor = OxyColors.Red

            });
            _calibrationPlotModel.Series.Add(new LineSeries()
            {              
                Title = "Fitted Line",
                TextColor = OxyColors.Green,
            });

            this.pltCalibration.Model = _calibrationPlotModel;

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


        }

        private void NudSensorCalA_ValueChanged(object sender, EventArgs e)
        {
            _sensorCalA = (double)nudSensorCalA.Value;
        }

        private void NudSensorCalB_ValueChanged(object sender, EventArgs e)
        {
            _sensorCalB = (double)nudSensorCalB.Value;
        }

        private void CalibrationTimer_Tick(object sender, EventArgs e)
        {       
            txtSensorTemp.Text = _objTemp.ToString();
            txtCalibratedTemp.Text = (_sensorCalA * _objTemp + _sensorCalB).ToString();

            // Sets the measured temperature from sensor to DataGrid's selected row's first index. 
            if (dgCalibration.CurrentCell != null)
            {
                string address = dgCalibration.CurrentCellAddress.Y.ToString();     //To see which row is selected.
                dgCalibration.Rows[Convert.ToInt32(address)].Cells[0].Value = _objTemp.ToString();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Log.Information("Calibration cancelled.");
            _calTimer.Stop();
            this.Hide();
            // _evtForm();
            if (_tempWriter != null)
            {
                _tempWriter.Flush();
                _tempWriter.Close();
            }
            _sensorCalA = 0;
            _sensorCalB = 0;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Log.Information("Calibration saved.");

            // Saving the coefficients to file.
            Stream myStream;
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "json files (*.json)|*.json";
                sfd.FilterIndex = 2;
                sfd.RestoreDirectory = true;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = sfd.OpenFile()) != null)
                    {                     
                        myStream.Close();
                    }              
                }
                try
                {
                    List<double> coefficients = new List<double>
                    {
                        _slope,
                        _intercept
                    };
                    string json = JsonConvert.SerializeObject(coefficients.ToArray(), Formatting.Indented);
                    File.WriteAllText(sfd.FileName, json);
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                }
            }     
        }
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            Log.Information("Calibration coefficiets loaded.");

            //Loads previously saved coefficients. 
            using (var ofd = new OpenFileDialog())
            {
                DialogResult result = ofd.ShowDialog();
                try
                {
                    string json = File.ReadAllText(ofd.FileName);
                    List<double> coefficients = JsonConvert.DeserializeObject<List<double>>(json);
                    _slope = Convert.ToDouble(coefficients[0]);
                    _intercept = Convert.ToDouble(coefficients[1]);
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                }                                     
            }
       
            nudSensorCalA.Value = (decimal)_slope;
            nudSensorCalB.Value = (decimal)_intercept;

        }

        private void Calibration_Load(object sender, EventArgs e)
        {
            _calTimer.Start();
        }

        private void Calibration_FormClosing(object sender, FormClosingEventArgs e)
        {
            _calTimer.Stop();
            // _evtForm();
        }

        // Value in cell cannot be changed when value has been set.
        private void DgCalibration_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgCalibration.CurrentCell.Value != null)
            {
                dgCalibration.CurrentCell.ReadOnly = true;
            }
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            LeastSquares();
            for (int i = 0; i < dgCalibration.Rows.Count; i++)
            {
                if (dgCalibration.Rows[i].Cells[1].Value != null)   
                {
                    double sensorTemp = Convert.ToDouble(dgCalibration.Rows[i].Cells[0].Value);
                    double realTemp = Convert.ToDouble(dgCalibration.Rows[i].Cells[1].Value);
                    SetGraphData(pltCalibration, sensorTemp, realTemp);
                }
            }
        }
        private void BtnOK_Click(object sender, EventArgs e)
        {
            Log.Information("Calibration performed.");
            _calTimer.Stop();
            this.Hide();
            // _evtForm();
        }
    }
}
