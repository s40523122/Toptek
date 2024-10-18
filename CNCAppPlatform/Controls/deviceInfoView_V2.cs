using LiveCharts;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace CNCAppPlatform.Controls
{
    public partial class deviceInfoView_V2 : UserControl
    {
        [Description("設備ID。"), Category("自訂值")]
        public string ID { set; get; } = "";

        public List<string> Labels { get; set; }
        public List<int> Paramrters {get;set;}

        public deviceInfoView_V2()
        {
            InitializeComponent();

            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView2.BorderStyle = BorderStyle.None;

            Labels = new List<string>(){"繁體中文字測試", "label2", "label3", "label4", "label5", "label6", "label7", "label8", "label9", "label10", "label11", "label12",
                                        "label13", "label14", "label15", "label16", "label17", "label18", "label19", "label20", "label21", "label22", "label23", "label24"};
            Paramrters = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                           0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};


            for (int i = 0; i < 12; i++)
            {
                string[] row = new string[] { Labels[i], Paramrters[i].ToString() };
                dataGridView1.Rows.Add(row);
            }
            for (int i = 12; i < 24; i++)
            {
                string[] row = new string[] { Labels[i], Paramrters[i].ToString() };
                dataGridView2.Rows.Add(row);
            }

            SizeChanged += deviceInfoView_V2_SizeChanged;

            // 測試圖表功能
            Chart_design();
        }

        void Chart_design()
        {
            

            SeriesCollection series = new SeriesCollection()
            {
                new LineSeries
                {
                    Values = new ChartValues<double> {70,72.5,71,75,66,73, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80 },

                    //Fill=new SolidColorBrush(Colors.IndianRed),
                },

            };
            cartesianChart1.Series = series;


            cartesianChart1.AxisX.Add(new Axis
            {

                Labels = new[] { "7/2", "7/3", "7/4", "7/5", "7/6" },
                MaxRange = 10,
                MinRange = 10
            });

            cartesianChart1.Zoom = ZoomingOptions.X;

        }

        public void ImportData(string device_name, Image device_img, string[] param_labels, string[] sequence_list)
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
    }
}
