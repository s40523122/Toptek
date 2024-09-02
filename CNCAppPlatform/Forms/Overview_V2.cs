using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNCAppPlatform
{
    public partial class Overview_V2 : Form
    {
        List<Control> page_dot = new List<Control>();

        public Overview_V2()
        {
            InitializeComponent();

            SizeChanged += Overview_V2_SizeChanged;

            ChangePage();

            
            for (int i = 0; i <= (int)Math.Round((double)(flowLayoutPanel1.Controls.Count / 2), 0); i++)
            {
                page_dot.Add(new myPanel() { Size = new Size(20, 20), Radius = 8, BackColor = Color.DarkGray});
            }
            flowLayoutPanel2.Controls.AddRange(page_dot.ToArray());
            flowLayoutPanel2.Width = 26 * page_dot.Count;
        }

        private void Overview_V2_SizeChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Height = Height * 9 / 10;
            deviceInfoView_V21.Height = flowLayoutPanel1.Height;
            deviceInfoView_V22.Height = flowLayoutPanel1.Height;
            deviceInfoView_V23.Height = flowLayoutPanel1.Height;
            flowLayoutPanel1.Width = (deviceInfoView_V21.Width + 5) * flowLayoutPanel1.Controls.Count;
            flowLayoutPanel2.Left = (Width - flowLayoutPanel2.Width)/2;

            flowLayoutPanel1.Left = 50;
            page_index = 1;
        }

        /// <summary>
        /// 每隔 3 秒，換頁
        /// </summary>
        private void ChangePage()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 3000; // 設置計時器間隔為 1000 毫秒 (1 秒)
            timer.Elapsed += Page_Elapsed;
            timer.Start();
        }

        int page_index = 1;
        int reverse = 1;
        private void Page_Elapsed(object sender, EventArgs e)
        {
            reverse = page_index == 1 ? (int)Math.Round((double)(flowLayoutPanel1.Controls.Count / 2),0) : -1; 

            for (int i = 0; i < 10; i++)
            {
                flowLayoutPanel1.Invoke((MethodInvoker) async delegate
                {
                    int between = deviceInfoView_V22.Left - deviceInfoView_V21.Left +2 ;
                    flowLayoutPanel1.Left -= between * reverse * 2 / 10;
                    await Task.Delay(50);
                });
            }
            page_index += reverse;
            foreach (Control control in page_dot) { control.BackColor = Color.DarkGray; }
            page_dot[page_index - 1].BackColor = Color.Green;
        }

        
    }
}
