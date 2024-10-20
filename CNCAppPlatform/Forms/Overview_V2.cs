using CNCAppPlatform.Controls;
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
        int Num_of_Devices = 6;

        List<Control> page_dot = new List<Control>();
        System.Timers.Timer timer = new System.Timers.Timer();

        string IniPath = Path.Combine(Form1.path, "Configurations/devices.ini");
        string ImgPath = Path.Combine(Form1.path, "Images/Devices/");

        public Overview_V2()
        {
            InitializeComponent();
            
            // 增加 buffer
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            // 加入設備
            for (int i = 3; i <= Num_of_Devices; i++)
            {
                deviceInfoView_V2 deviceInfoView = new deviceInfoView_V2() { ID = $"device{i}"};
                flowLayoutPanel1.Controls.Add(deviceInfoView);
            }

            // 設定分頁圖示
            int max_pages = (int) Math.Round(((double)Num_of_Devices / 2.0), 0, MidpointRounding.AwayFromZero);
            for (int i = 0; i < max_pages; i++)
            {
                page_dot.Add(new myPanel() { Size = new Size(20, 20), Radius = 8, BackColor = Color.DarkGray});
            }
            page_dots.Controls.AddRange(page_dot.ToArray());
            page_dots.Controls.Add(pause_btn);
            page_dots.Width = 26 * (page_dot.Count + 1);

            Import_config();

            // 啟動輪播
            ChangePage();

            SizeChanged += Overview_V2_SizeChanged;

            ActiveStateRead();      // 讀取 PLC
        }

        #region 計時器
        /// <summary>
        /// PLC 計時器
        /// </summary>
        public void ActiveStateRead()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 3000; // 設置計時器間隔為 3000 毫秒 (3 秒)
            timer.Elapsed += Active_Timer_Elapsed;
            timer.Start();
        }

        private void Active_Timer_Elapsed(object sender, EventArgs e)
        {
            // 匯入資料
            foreach (deviceInfoView_V2 device in flowLayoutPanel1.Controls)
            {
                // 取得設定檔資料
                Dictionary<string, string> import_config = INiReader.ReadSection(IniPath, device.ID);

                try
                {
                    string _ = import_config["device_name"];
                }
                catch
                {
                    return;
                }

                // 讀取暫存器位置
                string reg_seq = import_config["reg_sequence"];         // 次序指定暫存器
                string reg_ava = import_config["reg_availability"];     // 稼動率指定暫存器
                string reg_param = "D" + import_config["param_start_reg"];    // 設備參數開始暫存器

                int seq_value = Plc_Read(reg_seq, 1)[0];
                int ava_value = Plc_Read(reg_ava, 1)[0];
                short[] param_values = Plc_Read(reg_param, 24);

                // 更新數據
                device.Update_data(seq_value, ava_value, param_values);
            }
        }

        short[] Plc_Read(string start_reg, int reg_count)
        {
            short[] arraydata = new short[reg_count];

            _ = Form1.axActUtlType.ReadDeviceBlock2(start_reg, reg_count, out arraydata[0]);

            //Invoke(new MethodInvoker(delegate
            //{
            //    plateNo1.Text = arraydata[0].ToString();
            //    plateNo2.Text = arraydata[1].ToString();
            //    plateNo3.Text = arraydata[2].ToString();
            //    plateNo4.Text = arraydata[3].ToString();
            //}));
            return arraydata;
        }
        #endregion
        public void Import_config()
        {
            // 匯入資料
            foreach (deviceInfoView_V2 device in flowLayoutPanel1.Controls)
            {
                // 取得設定檔資料
                Dictionary<string, string> import_config = INiReader.ReadSection(IniPath, device.ID);

                try
                {
                    string _ = import_config["device_name"];
                }
                catch
                {
                    return;
                }

                // 設備名稱
                string device_name = import_config["device_name"];
                
                // 圖片來源
                //Image device_img = Image.FromFile(Path.Combine(ImgPath, import_config["device_img"]));
                FileStream fs = File.OpenRead(Path.Combine(ImgPath, import_config["device_img"]));
                int filelength = 0;
                filelength = (int)fs.Length; //獲得檔長度
                Byte[] image = new Byte[filelength]; //建立一個位元組陣列
                fs.Read(image, 0, filelength); //按位元組流讀取
                Image result = Image.FromStream(fs);
                fs.Close();

                // 參數標籤
                string[] labels = INiReader.ReadINIFile(IniPath, device.ID, "param_labels").Split(';');

                // 生產次序標籤
                string[] seq_list = INiReader.ReadINIFile(IniPath, device.ID, "sequence_list").Split(';');

                // 匯入設定檔
                device.Import_Param_Data(device_name, result, labels, seq_list);
            }
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
            if (Num_of_Devices == 2) return;

            // 計算總頁數
            int max_page = (int)Math.Round(((double)Num_of_Devices / 2.0), 0, MidpointRounding.AwayFromZero);

            // 當目前頁數為最後頁時，回到第一頁
            int next_page = page_index < max_page ? 1 : -max_page+1;

            // 計算翻頁距離
            int between = deviceInfoView_V22.Left - deviceInfoView_V21.Left;
            int step = 12;      // 細分為 12 步
            int one_step = between * next_page * 2 / step;

            // 翻頁動畫，每 10ms 移動一次
            for (int i = 1; i <= step; i++)
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
