using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNCAppPlatform
{
    public partial class PlcRW_Test : UserControl
    {
        Timer timer = new Timer();
        int rate = 200;

        public PlcRW_Test()
        {
            InitializeComponent();

            isRead.CheckedChanged += IsRead_CheckedChanged;

            timer.Interval = rate; // 設置計時器間隔為 1000 毫秒 (1 秒)
            timer.Tick += Timer_Tick;

            writeBtn.Click += WriteBtn_Click;
        }

        private void WriteBtn_Click(object sender, EventArgs e)
        {
            string d = "";
            int no = 1;
            int[] arraydata;
            String[] arrdata;

            arraydata = new int[1] { (int)Convert.ToInt32(dataMsg.Text) };

            d = dName.Text;
            _ = Form1.axActUtlType.WriteDeviceBlock(d, no, ref arraydata[0]);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            string d = "";
            int no = 1;
            int[] arraydata;
            String[] arrdata;
            arraydata = new int[no];

            d = dName.Text;
            _ = Form1.axActUtlType.ReadDeviceBlock(d, no, out arraydata[0]);

            dataMsg.Text = arraydata[0].ToString();
            //MessageBox.Show(arraydata[0].ToString());
        }

        private void IsRead_CheckedChanged(object sender, EventArgs e)
        {
            dataMsg.Enabled = writeBtn.Enabled = !isRead.Checked;
            if (isRead.Checked)
            {
                rateLabel.Text = $"{rate} ms";
                timer.Start();
            }
            else
            {
                rateLabel.Text = "-- ms";
                timer.Stop();
            }

        }
    }
}
