using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using Messages.std_msgs;
using RosSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace CNCAppPlatform.Controls
{
    public partial class deviceInfoView_V2 : UserControl
    {
        [Description("設備ID。"), Category("自訂值")]
        public string ID { set; get; } = "";

        ChartValues<double> chart_x_values = new ChartValues<double>();       // 稼動率歷史數據，更新此內容，稼動率圖表將自動更新
        List<string> x_labels = new List<string>();     // 稼動率圖表 X 軸標籤，更新此內容，稼動率圖表將自動更新

        //public List<string> param_labels { get; set; }
        //public List<int> param_data {get;set;}

        public deviceInfoView_V2()
        {
            InitializeComponent();

            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView2.BorderStyle = BorderStyle.None;

            /*
            param_labels = new List<string>(){"繁體中文字測試", "label2", "label3", "label4", "label5", "label6", "label7", "label8", "label9", "label10", "label11", "label12",
                                        "label13", "label14", "label15", "label16", "label17", "label18", "label19", "label20", "label21", "label22", "label23", "label24"};
            param_data = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                           0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            */

            // 設定欄位數量
            for (int i = 0; i < 12; i++)
            {
                //string[] row = new string[] { param_labels[i], param_data[i].ToString() };
                //dataGridView1.Rows.Add(row);
                dataGridView1.Rows.Add();
            }
            for (int i = 12; i < 24; i++)
            {
                //string[] row = new string[] { param_labels[i], param_data[i].ToString() };
                //dataGridView2.Rows.Add(row);
                dataGridView2.Rows.Add();
            }

            SizeChanged += deviceInfoView_V2_SizeChanged;

            // 測試圖表功能
            Chart_design();

            Load += DeviceInfoView_V2_Load;
        }

        private void DeviceInfoView_V2_Load(object sender, EventArgs e)
        {
            Setting_Timer();
        }

        /// <summary>
        /// 更新稼動率基礎資料
        /// </summary>
        public void Update_availability(List<string> s_values, List<string> lables)
        {
            // 使用 Select 轉換為 List<double>
            List<double> d_values = s_values
                .Select(s => double.TryParse(s, out double result) ? result : 0.0) // 將字串轉換為 double，若無法轉換則使用 0.0
                .ToList();

            chart_x_values = new ChartValues<double>(d_values);       // 稼動率歷史數據，更新此內容，稼動率圖表將自動更新
            x_labels = lables;     // 稼動率圖表 X 軸標籤，更新此內容，稼動率圖表將自動更新
        }

        public void Setting_Timer()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 3600000; // 設置計時器間隔為 3000 毫秒 (3 秒)
            timer.Elapsed += Active_Timer_Elapsed;
            timer.Start();
        }

        private void Active_Timer_Elapsed(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(delegate
            {
                // 新增一個數據點
                //chart_x_values.Add(new Random().Next(70, 90));  // 加入數字 9 到折線圖
                chart_x_values.Add(speedBar1.NowPercentage);
                
                // 儲存 csv
                DataGridView dataGridView1 = new DataGridView();
                dataGridView1.ColumnCount = 3;
                dataGridView1.Columns[0].Name = "availability";
                dataGridView1.Columns[1].Name = "log_time";
                dataGridView1.Columns[2].Name = "station";

                string[] row1 = new string[] { speedBar1.NowPercentage.ToString(), DateTime.Now.ToString(@"hh\:mm"), ID };
                dataGridView1.Rows.Add(row1);
                SaveCsv.SaveDataGridViewToCSV(dataGridView1, "availability_history.csv", message:false);

                // 強制觸發自動更新功能，以限制顯示範圍
                auto_switch.Checked = auto_switch.Checked;

                // 加入 x 軸標籤
                //_time = _time.Add(new TimeSpan(1, 0, 0));
                x_labels.Add(DateTime.Now.ToString(@"hh\:mm"));
            }));
        }

        void Chart_design()
        {
            // 設定數據形式
            SeriesCollection series = new SeriesCollection()
            {
                new LineSeries
                {
                    Values = chart_x_values,
                    // Fill = new SolidColorBrush(Colors.IndianRed),
                }
            };
            cartesianChart1.Series = series;

            // 設定 X 軸標籤
            cartesianChart1.AxisX.Add(new Axis
            {
                Labels = x_labels,
                Separator = new LiveCharts.Wpf.Separator
                {
                    Step = 1,        // 每個標籤都顯示
                    //IsEnabled = false  // 如果不想顯示刻度線，可設置為 false
                },

                // 限制顯示範圍
                //MinValue = chart_values.Count - 6,
                //MaxValue = chart_values.Count - 1
            });

            // 設定 Y 軸標籤
            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                // 限制顯示範圍
                MinValue = 0,  // 設定 Y 軸最小值
                MaxValue = 100  // 設定 Y 軸最大值
            });

            // 強制觸發自動更新功能，以限制顯示範圍
            auto_switch.Checked = auto_switch.Checked;
        }

        /// <summary>
        /// 更新顯示數據
        /// </summary>
        /// <param name="sequence_index">生產次序編號</param>
        /// <param name="current_activation">當前稼動率</param>
        /// <param name="param_data">設備參數數據</param>
        public void Update_data(int sequence_index, int current_activation, short[] param_data)
        {
            Invoke(new MethodInvoker(delegate
            {
                ucStep1.StepIndex = sequence_index;
                speedBar1.NowPercentage = current_activation;

                for (int i = 0; i < 12; i++)
                {
                    dataGridView1.Rows[i].Cells[1].Value = param_data[i];
                }
                for (int i = 12; i < 24; i++)
                {
                    dataGridView2.Rows[i - 12].Cells[1].Value = param_data[i];
                }
            }));
        }

        public void Import_Param_Data(string device_name, Image device_img, string[] param_labels, string[] sequence_list)
        {
            label1.Text = device_name;
            pictureBox1.Image = device_img;

            for (int i = 0; i < 12; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = param_labels[i];
            }
            for (int i = 12; i < 24; i++)
            {
                dataGridView2.Rows[i-12].Cells[0].Value = param_labels[i];
            }

            ucStep1.Steps = sequence_list;
            Refresh();
        }

        private void deviceInfoView_V2_SizeChanged(object sender, EventArgs e)
        {
            // 固定版面寬高比
            Width = Height * 43 / 50;

            // dataGridView 寬度跟隨版面寬度
            int paraWidth = (int)(Width * 0.58);
            dataGridView1.Width = paraWidth / 2;
            dataGridView2.Width = paraWidth / 2;

            // label 字體大小跟隨版面高度
            label1.Font = label2.Font = label3.Font = label4.Font = label5.Font = new Font(label1.Font.FontFamily, Height / 50);
            label2.Height = label3.Height = label4.Height = label5.Height = Height / 23;

            dataGridView1.DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font.FontFamily, dataGridView1.Height/40);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = dataGridView1.Height / 12;
            }

            dataGridView2.DefaultCellStyle.Font = new Font(dataGridView2.DefaultCellStyle.Font.FontFamily, dataGridView2.Height / 40);
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.Height = dataGridView2.Height / 12;
            }

            ucStep1.StepWidth = ucStep1.Height * 2 / 5;
        }

        TimeSpan _time = new TimeSpan(10, 0, 0);
        private void button1_Click(object sender, EventArgs e)
        {
            // 新增一個數據點
            chart_x_values.Add(new Random().Next(70, 90));  // 加入數字 9 到折線圖

            // 強制觸發自動更新功能，以限制顯示範圍
            auto_switch.Checked = auto_switch.Checked;

            // 加入 x 軸標籤
            _time = _time.Add(new TimeSpan(1, 0, 0));
            x_labels.Add(_time.ToString(@"hh\:mm"));
        }

        /// <summary>
        /// 圖表自動更新按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void auto_switch_CheckedChanged(object sender, EventArgs e)
        {
            // 當按下後，自動更新，圖表範圍鎖定最新 12 筆
            if (auto_switch.Checked)
            {
                cartesianChart1.Zoom = ZoomingOptions.None;

                // 不足 12 筆前，顯示前 12 筆
                if (chart_x_values.Count <= 12)
                {
                    cartesianChart1.AxisX[0].MinValue = 0;
                    cartesianChart1.AxisX[0].MaxValue = 12;
                }
                else
                {
                    cartesianChart1.AxisX[0].MinValue = chart_x_values.Count - 13;
                    cartesianChart1.AxisX[0].MaxValue = chart_x_values.Count - 1;
                }
                
            }
            // 反之，圖表 X 軸可被拖曳
            else
            {
                cartesianChart1.Zoom = ZoomingOptions.X;
            }
        }
    }
}
