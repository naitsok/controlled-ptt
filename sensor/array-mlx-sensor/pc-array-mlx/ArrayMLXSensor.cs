using System;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;

namespace ControlledPTT.Sensors
{
    public partial class ArrayMLXSensor : BaseSensor
    {
        // COM port connection.
        private SerialPort _comPort = null;

        // String to keep received data.
        private string _receivedData = string.Empty;

        // Variable indicating if connection is open.
        private bool _comConnected = false;

        // Keeps average temperature calculated by averagin temperatures from the selected cells
        private double _temperature = 0.0;

        // Dimensions of the infrared array sensor;
        private static int SENSOR_ROWS = 4;
        private static int SENSOR_COLS = 16;

        // Array keeps temperatures received from the board. It updates as soon as new data
        // is receieved, i.e. each second.
        private double[,] _temperatures = new double[SENSOR_ROWS, SENSOR_COLS];
        private HashSet<(int, int)> _selectedTemperatures = new HashSet<(int, int)>();

        // Parameters for temperature visualization.
        private static int LEFT_X = 10;
        private static int LEFT_Y = 25; //coordinates for the left corner of the first sensor cell.

        private static int WIDTH = 45;
        private static int HEIGHT = 24; // cell dimensions.

        private static int SPACE_X = 8;
        private static int SPACE_Y = 8; // Space between cells

        private static int TEXT_LEFT_X = 13;
        private static int TEXT_LEFT_Y = 29; // coordinates for the text in the first cell.

        private static Pen NotSelectedCellBorder = new Pen(Color.Black, 3);
        private static Pen SelectedCellBorder = new Pen(Color.White, 3); // Pens to draw cell borders.

        private static double MinTemperatureColor = 20;
        private static double MaxTemperatureColor = 50; // Min and max values to draw color for a cell.

        private static Font TemperatureFont = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
        private static Brush TemperatureFontColor = new SolidBrush(Color.White);

        // keep the selected cells
        private static string SELECTED_CELLS = @".\ArrayMLX_selected_cells.txt";

        /// <summary>
        /// Override from BaseSensor to return title of the sensor
        /// </summary>
        public override string Title { get { return "Array MLX Sensor"; } }

        /// <summary>
        /// Override from BaseSensor to get the temperature to be sent to MainApp
        /// </summary>
        /// <returns>Temperature to be sent to MainApp by BaseSensor</returns>
        protected override double GetTemperature() { return _temperature; }

        public ArrayMLXSensor()
        {
            InitializeComponent();

            cbBaudRate.SelectedIndex = 8;
            // _sendTimer.Tick += new EventHandler(this.sendDataTimer_Tick);
            GetComPorts();

            // load previously selected cells
            bool[] selectedCellsBools = null;
            if (File.Exists(Path.GetFullPath(SELECTED_CELLS)))
            {
                string selectedCells = File.ReadAllText(Path.GetFullPath(SELECTED_CELLS));
                selectedCellsBools = selectedCells.Split(' ').Select(bool.Parse).ToArray();
            }
            else
                selectedCellsBools = Enumerable.Repeat(false, SENSOR_ROWS * SENSOR_COLS).ToArray();

            for (int i = 0; i < SENSOR_ROWS; i++)
            {
                for (int j = 0; j < SENSOR_COLS; j++)
                {
                    if (selectedCellsBools[j + SENSOR_COLS * i] == true)
                        _selectedTemperatures.Add((i, j));
                }
            }
        }

        private void GetComPorts()
        {
            cbPorts.Items.Clear();
            var comPortNames = SerialPort.GetPortNames();
            if (comPortNames.Length > 0)
            {
                cbPorts.Items.AddRange(comPortNames);
                cbPorts.SelectedIndex = 0;
            }
        }

        private void btnGetComPorts_Click(object sender, EventArgs e)
        {
            GetComPorts();
        }

        private void btnConnRedBoard_Click(object sender, EventArgs e)
        {
            if (!_comConnected)
            {
                if (cbPorts.Items.Count == 0)
                    return;

                var portName = cbPorts.SelectedItem.ToString();

                try
                {
                    _comPort = new SerialPort(portName, Convert.ToInt32(cbBaudRate.SelectedItem));
                    _comPort.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                    _comPort.Open();
                }
                catch (System.IO.IOException ex)
                {
                    MessageBox.Show(ex.Message,
                        "Something went wrong. Check no other app is connected to " + portName + ".",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                btnConnRedBoard.Text = "Disconnect";
                txtConnectedStatus.Text = "Connected";
                txtConnectedStatus.BackColor = Color.Green;
                _comConnected = true;
                // _sendTimer.Start();

            }
            else
            {
                if (!_comPort.IsOpen)
                {
                    throw new ArgumentException("The Com Port is not open!");
                }
                _comPort.Close();
                _comPort = null;
                btnConnRedBoard.Text = "Connect";
                txtConnectedStatus.Text = "Not Connected";
                txtConnectedStatus.BackColor = Color.Red;
                _comConnected = false;
                // _sendTimer.Stop();
            }
        }
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            while (_comPort.BytesToRead > 0) // Reads all available serial input.
                                             // Without this there will be a lag displaying the data.
            {
                try
                {
                    _receivedData = _comPort.ReadLine(); // One line must contain all the temperatures measured in Celcius.

                    Invoke(new EventHandler(ProcessData)); // Process the reseived data.
                }
                catch
                {
                    // Something has happened during data receiving - ignore.
                }
            }
        }

        private void btnClearData_Click(object sender, EventArgs e)
        {
            txtAllReceivedData.Clear();
            txtAvgTemperature.Clear();
            txtAvgTemperature.Text = "0.00";
        }

        private void ProcessData(object sender, EventArgs e)
        {
            txtAllReceivedData.AppendText(_receivedData);
            txtAllReceivedData.ScrollToCaret();

            // Get the received data into array the same way it was packed on the controller side.
            var splittedData = _receivedData.Split('\t');
            Graphics g = gbTemperatures.CreateGraphics();
            for (int i = 0; i < SENSOR_ROWS; i++)
            {
                for (int j = 0; j < SENSOR_COLS; j++)
                {
                    double temperature = double.Parse(splittedData[j + SENSOR_COLS * i], NumberStyles.Any, CultureInfo.InvariantCulture);
                    _temperatures[i, j] = temperature;

                    // Visualize temperatures.
                    Rectangle cell = new Rectangle(
                        LEFT_X + i * (WIDTH + SPACE_X), 
                        LEFT_Y + j * (HEIGHT + SPACE_Y), 
                        WIDTH, 
                        HEIGHT);
                    
                    g.FillRectangle(getCellColor(temperature), cell);
                    if (_selectedTemperatures.Contains((i, j)))
                        g.DrawRectangle(SelectedCellBorder, cell);
                    else
                        g.DrawRectangle(NotSelectedCellBorder, cell);

                    g.DrawString(
                        temperature.ToString("0.##"),
                        TemperatureFont,
                        TemperatureFontColor,
                        (float)(TEXT_LEFT_X + i * (WIDTH + SPACE_X)),
                        (float)(TEXT_LEFT_Y + j * (HEIGHT + SPACE_Y))
                        );
                }
            }
            g.Dispose();

            // Calculate temperature to store it in the variable of BaseSensorForm
            _temperature = CalculateAvgTemperature();
            txtAvgTemperature.Text = _temperature.ToString("0.##");
        }

        private void gbTemperatures_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(NotSelectedCellBorder.Color),
                new Rectangle(
                    LEFT_X - SPACE_X, 
                    LEFT_Y - SPACE_Y, 
                    SENSOR_ROWS * (WIDTH + SPACE_X) + SPACE_X, 
                    SENSOR_COLS * (HEIGHT + SPACE_Y) + SPACE_Y));
        }

        /// <summary>
        /// Gets the color of cell depending on the temperature.
        /// </summary>
        /// <param name="temperature"></param>
        /// <returns></returns>
        private SolidBrush getCellColor(double temperature)
        {
            // Check temperature is outside limits.
            if (temperature < MinTemperatureColor)
                temperature = MinTemperatureColor;
            if (temperature > MaxTemperatureColor)
                temperature = MaxTemperatureColor;

            // calculate ration for color interpolation.
            double ratio = (temperature - MinTemperatureColor) / (MaxTemperatureColor - MinTemperatureColor);

            SolidBrush brush = new SolidBrush(
                Color.FromArgb(
                    (byte)(Color.Blue.R * (1 - ratio) + Color.Red.R * ratio),
                    (byte)(Color.Blue.G * (1 - ratio) + Color.Red.G * ratio),
                    (byte)(Color.Blue.B * (1 - ratio) + Color.Red.B * ratio)
                    )
                );

            return brush;
        }

        private void gbTemperatures_MouseClick(object sender, MouseEventArgs e)
        {
            (int i, int j) = getCellIndices(e.X, e.Y);

            Rectangle cell = new Rectangle(
                LEFT_X + i * (WIDTH + SPACE_X),
                LEFT_Y + j * (HEIGHT + SPACE_Y),
                WIDTH,
                HEIGHT);
            Graphics g = gbTemperatures.CreateGraphics();

            if (_selectedTemperatures.Contains((i, j)))
            {
                _selectedTemperatures.Remove((i, j));
                g.DrawRectangle(NotSelectedCellBorder, cell);
            }
            else
            {
                _selectedTemperatures.Add((i, j));
                g.DrawRectangle(SelectedCellBorder, cell);
            }
            g.Dispose();
        }

        private (int i, int j) getCellIndices(Rectangle cell)
        {
            int j = (int)((cell.Y - LEFT_Y) / (HEIGHT + SPACE_Y));
            int i = (int)((cell.X - LEFT_X) / (WIDTH + SPACE_X));

            return (i, j);
        }

        private (int i, int j) getCellIndices(int x, int y)
        {
            int j = (int)((y - LEFT_Y) / (HEIGHT + SPACE_Y));
            int i = (int)((x - LEFT_X) / (WIDTH + SPACE_X));
            return (i, j);
        }

        private double CalculateAvgTemperature()
        {
            if (_selectedTemperatures.Count == 0)
                return 0;

            double avgTemperature = 0;
            foreach ((int, int) indices in _selectedTemperatures)
            {
                avgTemperature += _temperatures[indices.Item1, indices.Item2];
            }
            return avgTemperature / _selectedTemperatures.Count;
        }

        //private void sendDataTimer_Tick(object sender, EventArgs e)
        //{
        //    _averageTemperature = calculateAvgTemperature();
        //    txtAvgTemperature.Text = _averageTemperature.ToString("0.##");
        //    SendTemperature(_averageTemperature);
        //}
        private void ArraySensor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_comPort != null)
            {
                if (_comPort.IsOpen)
                {
                    _comPort.Close();
                    _comPort = null;
                }
            }

            // Save indices of selected cells
            string[] selectedCells = Enumerable.Repeat(false.ToString(), SENSOR_ROWS * SENSOR_COLS).ToArray();
            foreach ((int, int) cells in _selectedTemperatures)
            {
                selectedCells[cells.Item1 * SENSOR_COLS + cells.Item2] = true.ToString();
            }
            File.WriteAllText(Path.GetFullPath(SELECTED_CELLS), string.Join(" ", selectedCells));
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < SENSOR_ROWS; i++)
            {
                for (int j = 0; j < SENSOR_COLS; j++)
                    _selectedTemperatures.Add((i, j));
            }
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            _selectedTemperatures.Clear();
        }
    }
}
