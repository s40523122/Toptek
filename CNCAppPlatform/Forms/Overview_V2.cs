using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNCAppPlatform
{
    public partial class Overview_V2 : Form
    {
        List<Control> page_dot = new List<Control>();
        System.Timers.Timer timer = new System.Timers.Timer();

        public Overview_V2()
        {
            InitializeComponent();
            
            // 增加 buffer
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            SizeChanged += Overview_V2_SizeChanged;

            // 啟動輪播
            ChangePage();

            
            for (int i = 0; i <= (int)Math.Round((double)(flowLayoutPanel1.Controls.Count / 2), 0); i++)
            {
                page_dot.Add(new myPanel() { Size = new Size(20, 20), Radius = 8, BackColor = Color.DarkGray});
            }
            page_dots.Controls.AddRange(page_dot.ToArray());
            page_dots.Controls.Add(pause_btn);
            page_dots.Width = 26 * (page_dot.Count + 1);
        }

        private void Overview_V2_SizeChanged(object sender, EventArgs e)
        {
            timer.Stop();
            flowLayoutPanel1.Height = Height * 9 / 10;

            // 將 deviceInfoView_V2 自適應畫面
            foreach (Control _deviceInfoView_V2 in flowLayoutPanel1.Controls) _deviceInfoView_V2.Height = flowLayoutPanel1.Height;

            // 自適應 flowLayoutPanel 並回到初始位置
            flowLayoutPanel1.Width = (deviceInfoView_V21.Width + 5) * flowLayoutPanel1.Controls.Count;
            flowLayoutPanel1.Left = 20;
            page_index = 1;

            // 置中分頁預覽點
            page_dots.Left = (Width - page_dots.Width) / 2;
            foreach (Control control in page_dot) { control.BackColor = Color.DarkGray; }
            page_dot[0].BackColor = Color.Green;

            timer.Start();
        }

        /// <summary>
        /// 每隔 3 秒，換頁
        /// </summary>
        private void ChangePage()
        {
            
            timer.Interval = 3000; // 設置計時器間隔為 1000 毫秒 (1 秒)
            timer.Elapsed += Page_Elapsed;
            timer.Start();
        }

        int page_index = 1;     // 目前分頁數
        //int next_page = 1;      // 下一頁需求數量
        private void Page_Elapsed(object sender, EventArgs e)
        {
            // 判定是否輪播
            if (pause_btn.Change) return;

            // 計算總頁數
            int max_page = (int)Math.Round((double)(flowLayoutPanel1.Controls.Count / 2), 0);
            
            // 當目前頁數為最後頁時，回到第一頁
            int next_page = page_index <= max_page ? 1 : -max_page;

            // 計算翻頁距離
            int between = deviceInfoView_V22.Left - deviceInfoView_V21.Left;
            int step = 12;      // 細分為 12 步
            int one_step = between * next_page * 2 / step;

            // 翻頁動畫，每 10ms 移動一次
            for (int i = 0; i < step; i++)
            {
                flowLayoutPanel1.Invoke((MethodInvoker) delegate
                {
                    flowLayoutPanel1.Left -= one_step;
                    Thread.Sleep(10);

                    // 更新頁面，使動畫流暢移動
                    Invalidate();
                    Update();

                    // 補回因整數計算產生的遺失步
                    if (i == step - 1 ) flowLayoutPanel1.Left -= (between * next_page * 2 - one_step * step);
                });
            }

            // 更新目前分頁數
            page_index += next_page;

            // 渲染分頁預覽點
            foreach (Control control in page_dot) { control.BackColor = Color.DarkGray; }
            page_dot[page_index - 1].BackColor = Color.Green;
        }

    }
}
