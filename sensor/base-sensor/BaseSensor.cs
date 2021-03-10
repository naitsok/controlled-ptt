using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlledPTT.Sensors
{
    public partial class BaseSensor : Form
    {
        /// <summary>
        /// Retunrs the title of the sensor to be placed as text in the sensor selector of the MainApp
        /// </summary>
        public virtual string Title { get { throw new NotImplementedException(); } }

        /// <summary>
        /// Gets the tempreature to be sent to the MainApp
        /// </summary>
        /// <returns></returns>
        protected virtual double GetTemperature()
        {
            throw new NotImplementedException();
        }

        // To send the temperature to the MainApp
        public delegate void TemperatureSendHandler(object sender, TemperatureSentEventArgs e);
        public event TemperatureSendHandler OnTemperatureSent;

        // Temperature to be sent by timer
        private Timer _sendTempTimer = new Timer() { Interval = 1000 };

        public BaseSensor()
        {
            InitializeComponent();
            _sendTempTimer.Tick += new EventHandler(sendDataTimer_Tick);
            _sendTempTimer.Start();
        }

        private void sendDataTimer_Tick(object sender, EventArgs e)
        {
            SendTemperature();
        }

        protected void SendTemperature()
        {
            if (OnTemperatureSent == null) return;

            TemperatureSentEventArgs e = new TemperatureSentEventArgs(GetTemperature());
            OnTemperatureSent(this, e);
        }

        private void BaseSensorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sendTempTimer.Stop();
        }
    }

    public class TemperatureSentEventArgs : EventArgs
    {
        public double Temperature { get; private set; } = 0;

        public TemperatureSentEventArgs(double temperature)
        {
            Temperature = temperature;
        }
    }
}

