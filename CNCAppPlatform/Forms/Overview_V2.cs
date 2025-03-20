using CNCAppPlatform.Controls;
using CNCAppPlatform.Managers;
using Renci.SshNet.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNCAppPlatform
{
    public partial class Overview_V2 : Form
    {
        // 設定加入設備數量
        readonly int Num_of_Devices = 6;

        // 目前分頁數
        int current_page_index = 1;     

        private List<Control> dot_list = new List<Control>();
        private System.Timers.Timer timer = new System.Timers.Timer();

        //string IniPath = Path.Combine(Form1.path, "Configurations/devices.ini");
        //string ImgPath = Path.Combine(Form1.path, "Images/Devices/");

        // 稼動率是否已更新
        bool init = false;

        public Overview_V2()
        {
            InitializeComponent();
            
            // 增加 buffer
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            Global_Variable.Devices[0].AddControl(deviceInfoView_V21);
            Global_Variable.Devices[1].AddControl(deviceInfoView_V22);

            // 加入設備
            for (int i = 3; i <= Num_of_Devices; i++)
            {
                deviceInfoView_V2 deviceInfoView = new deviceInfoView_V2() { ID = $"device{i}"};
                flowLayoutPanel1.Controls.Add(deviceInfoView);

                Global_Variable.Devices[i-1].AddControl(deviceInfoView);
            }

            // 設定分頁圖示
            int max_pages = (int) Math.Round(((double)Num_of_Devices / 2.0), 0, MidpointRounding.AwayFromZero);
            for (int i = 0; i < max_pages; i++)
            {
                // 用 TabIndex 作為分頁頁碼
                myPanel dot = new myPanel() { TabIndex = i, Size = new Size(20, 20), Radius = 8, BackColor = Color.DarkGray, Cursor = Cursors.Hand };
                dot_list.Add(dot);
                dot.Click += Dot_Click;
            }
            page_dot_layout.Controls.AddRange(dot_list.ToArray());
            page_dot_layout.Controls.Add(pause_btn);
            page_dot_layout.Width = 26 * (dot_list.Count + 1);
            Import_config();

            // 啟動輪播
            ChangePage();

            SizeChanged += Overview_V2_SizeChanged;
            Load += Overview_V2_Load;
        }

        private void Dot_Click(object sender, EventArgs e)
        {
            // 手動切換分頁時，暫停輪播功能
            pause_btn.Change = true;
            
            // 計算並切換分頁
            myPanel dot = sender as myPanel;
            Turn_Page(dot.TabIndex - current_page_index + 1);
        }

        private void Overview_V2_Load(object sender, EventArgs e)
        {
            ActiveStateRead();      // 讀取 PLC
        }

        #region 計時器
        /// <summary>
        /// PLC 計時器
        /// </summary>
        public void ActiveStateRead()
        {
            System.Timers.Timer timer = new System.Timers.Timer
            {
                Interval = 3000 // 設置計時器間隔為 3000 毫秒 (3 秒)
            };
            timer.Elapsed += Active_Timer_Elapsed;
            timer.Start();
        }

        private void Active_Timer_Elapsed(object sender, EventArgs e)
        {
            // 匯入資料
            foreach (deviceInfoView_V2 device in flowLayoutPanel1.Controls)
            {
                // 取得設定檔資料
                //Dictionary<string, string> import_config = INiReader.ReadSection(IniPath, device.ID);

                iDevice iDevice = Global_Variable.Devices.Where(d => d.IniSection == device.ID).FirstOrDefault();

                // 讀取暫存器位置
                string reg_seq = iDevice.RegSequence;         // 次序指定暫存器
                string reg_ava = iDevice.RegAvailability;     // 稼動率指定暫存器
                string reg_param = "D" + iDevice.RegParamStart;    // 設備參數開始暫存器

                int seq_value = MXConnect.Plc_Read(reg_seq, 1)[0];
                int ava_value = MXConnect.Plc_Read(reg_ava, 1)[0];
                short[] param_values = MXConnect.Plc_Read(reg_param, 24);

                // 更新數據
                device.Update_data(seq_value, ava_value, param_values);
            }
        }


        #endregion
        public void Import_config()
        {
            // 稼動率資料
            List<string[]> _availability_history = SaveCsv.LoadCSVToString("availability_history.csv");

            // 匯入資料
            foreach (deviceInfoView_V2 device in flowLayoutPanel1.Controls)
            {

                if (init == false)
                {
                    List<string> availability_values = _availability_history
                    .Where(arr => arr.Length > 2 && arr[2] == device.ID) // 篩選第 3 個元素符合指定值的項目
                    .Select(arr => arr[0])
                    .ToList();

                    List<string> availability_lables = _availability_history
                        .Where(arr => arr.Length > 2 && arr[2] == device.ID) // 篩選第 3 個元素符合指定值的項目
                        .Select(arr => arr[1])
                        .ToList();

                    device.Update_availability(availability_values, availability_lables);
                }
            }

            init = true;
        }

        private void Overview_V2_SizeChanged(object sender, EventArgs e)
        {
            timer.Stop();
            flowLayoutPanel1.Height = Height * 9 / 10;

            // 將 deviceInfoView_V2 自適應畫面
            foreach (Control _deviceInfoView_V2 in flowLayoutPanel1.Controls) _deviceInfoView_V2.Height = flowLayoutPanel1.Height;

            // 自適應 flowLayoutPanel 並回到初始位置
            flowLayoutPanel1.Width = (deviceInfoView_V21.Width + 5) * Num_of_Devices;
            flowLayoutPanel1.Left = 20;
            current_page_index = 1;

            // 置中分頁預覽點
            page_dot_layout.Left = (Width - page_dot_layout.Width) / 2;
            foreach (Control control in dot_list) { control.BackColor = Color.DarkGray; }
            dot_list[0].BackColor = Color.Green;

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

        private void Page_Elapsed(object sender, EventArgs e)
        {
            // 判定是否輪播
            if (pause_btn.Change) return;
            if (Num_of_Devices == 2) return;

            // 計算總頁數
            // int max_page = (int)Math.Round(((double)Num_of_Devices / 2.0), 0, MidpointRounding.AwayFromZero);
            int max_page = page_dot_layout.Controls.Count - 1;

            // 當目前頁數為最後頁時，回到第一頁
            int next_page = current_page_index < max_page ? 1 : -max_page + 1;

            Turn_Page(next_page);
        }

        /// <summary>
        /// 翻頁動作
        /// </summary>
        /// <param name="turn_num">需求頁數</param>
        private void Turn_Page(int turn_num)
        {
            // 計算翻頁距離
            int between = deviceInfoView_V22.Left - deviceInfoView_V21.Left;
            int step = 12;      // 細分為 12 步
            int one_step = between * turn_num * 2 / step;

            // 翻頁動畫，每 10ms 移動一次
            for (int i = 1; i <= step; i++)
            {
                flowLayoutPanel1.Invoke((MethodInvoker)delegate
                {
                    flowLayoutPanel1.Left -= one_step;
                    Thread.Sleep(10);

                    // 更新頁面，使動畫流暢移動
                    Invalidate();
                    Update();

                    // 補回因整數計算產生的遺失步
                    if (i == step - 1) flowLayoutPanel1.Left -= (between * turn_num * 2 - one_step * step);
                });
            }

            // 更新目前分頁數
            current_page_index += turn_num;

            // 渲染分頁預覽點
            foreach (Control control in dot_list) { control.BackColor = Color.DarkGray; }
            dot_list[current_page_index - 1].BackColor = Color.Green;
        }

    }
}
