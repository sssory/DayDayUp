using Communicate;
using System;
using System.Timers;
using System.Windows.Forms;

namespace DayDayWinForm.Pages.SerialPort
{
    public partial class ModbusRTU : UserControl
    {
        private Modbus RTU = new Modbus();
        public ModbusRTU()
        {
            InitializeComponent();
        }

        private void ModbusRTU_Load(object sender, EventArgs e)
        {
            RTU.Connect(new SerialInfo());

            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            byte[] result = RTU.ReadOutputRegister(1, 0, 1);

            if (result != null && result.Length == 2)
            {
                string res = (result[0] * 256 + result[1]).ToString();
                DayDayWinForm.Tools.App.LogMessage(res);
            }
        }
    }
}
