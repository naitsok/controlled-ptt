using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseSensor;

namespace DummySensor
{
    public partial class DummySensorForm : BaseSensorForm
    {
        // Generates random temperature
        private int _generatedTemp = 0;
        private bool _genRunning = false;
        private Random rand = new Random(DateTime.Now.Millisecond);

        public DummySensorForm()
        {
            InitializeComponent();
        }

        private void tmGenTemp_Tick(object sender, EventArgs e)
        {
            _generatedTemp = rand.Next(0, 100);
            txtTemperature.Text = _generatedTemp.ToString();
            SendTemperature(Convert.ToDouble(_generatedTemp));
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
    }
}
