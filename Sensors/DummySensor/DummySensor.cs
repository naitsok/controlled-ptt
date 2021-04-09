using System;

namespace ControlledPTT.Sensors
{
    public partial class DummySensor : BaseSensor
    {
        // Generates random temperature
        private double _temperature = 0;
        private bool _genRunning = false;
        private Random rand = new Random(DateTime.Now.Millisecond);

        // Must override from BaseSensor
        public override string Title { get { return "Dummy Sensor"; } }

        protected override double GetTemperature() { return _temperature; }

        public DummySensor()
        {
            InitializeComponent();
        }

        private void tmGenTemp_Tick(object sender, EventArgs e)
        {
            // Temperature to be sent by BaseSensor
            _temperature = rand.Next(0, 100);
            txtTemperature.Text = _temperature.ToString();
        }

        private void btnGenTemp_Click(object sender, EventArgs e)
        {
            if(_genRunning)
            {
                tmGenTemp.Stop();
                btnGenTemp.Text = "Generate Temperature";
                _genRunning = false;
            }
            else
            {
                tmGenTemp.Start();
                btnGenTemp.Text = "Stop Generating";
                _genRunning = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
