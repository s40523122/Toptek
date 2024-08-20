using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CNCAppPlatform.Controls;

namespace CNCAppPlatform
{
    public partial class Carousel_8_box : UserControl
    {
        string reg_wh1 = "D0";

        public string Dwh_registers
        {
            set
            {
                reg_wh1 = value;
            }
        }

        public string[] Set_tag
        {
            set
            {
                string[] tags = value;
                List<Label> Taglabels = new List<Label> {label1, label2, label3, label4, label5, label6, label7, label8,
                                                     label9, label10, label11, label12, label13, label14, label15, label16,
                                                     label17, label18, label19, label20, label21, label22, label23, label24};

                for (int i = 0; i < tags.Length; i++)
                {
                    Taglabels[i].Text = tags[i];
                }
            }
        }

        int pageIndex = 0;
        private Panel[] panels;

        public Carousel_8_box()
        {
            InitializeComponent();

            // 重合所有 panel，並將 panel1 至於頂部
            panel3.Left = 23;
            panel2.Left = 23;
            panel1.BringToFront();

            panels = new Panel[] { panel1, panel2, panel3 };

            go_right.Click += Go_Right_Click;
            go_left.Click += Go_Left_Click;

            WhStateRead();      // 設定定時讀取
            ChangePage();
        }

        private void Go_Left_Click(object sender, EventArgs e)
        {
            pageIndex--;
            panels[pageIndex].BringToFront();

            if (pageIndex == 0) go_left.Visible = false;
            go_right.Visible = true;

        }

        private void Go_Right_Click(object sender, EventArgs e)
        {
            pageIndex++;
            panels[pageIndex].BringToFront();

            go_left.Visible = true;
            if (pageIndex == panels.Length-1) go_right.Visible = false;
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

        private void Page_Elapsed(object sender, EventArgs e)
        {
            pageIndex++;
            if (pageIndex >= panels.Length) pageIndex = 0;

            Invoke(new MethodInvoker(delegate
            {
                panels[pageIndex].BringToFront();
            }));
        }

        /// <summary>
        /// 每隔 1 秒，讀取 PLC 狀態
        /// </summary>
        private void WhStateRead()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000; // 設置計時器間隔為 1000 毫秒 (1 秒)
            timer.Elapsed += Wh_Timer_Elapsed;
            timer.Start();
        }

        private void Wh_Timer_Elapsed(object sender, EventArgs e)
        {
            int no = 24;
            short[] arraydata = new short[no];

            _ = Form1.axActUtlType.ReadDeviceBlock2(reg_wh1, no, out arraydata[0]);
            Control[] controls = new Control[] {value1, value2, value3, value4, value5, value6, value7, value8,
                                                value9, value10, value11, value12, value13, value14, value15, value16,
                                                value17, value18, value19, value20, value21, value22, value23, value24,};
            int countNo = 0;
            Invoke(new MethodInvoker(delegate
            {

                foreach (short id in arraydata)
                {
                    try
                    {
                        controls[countNo].Text = arraydata[countNo].ToString();
                    }
                    catch (Exception ex)
                    {
                        controls[countNo].Text = $"NotFound {arraydata[countNo]}";
                    }
                    countNo ++;
                }
                
            }));
        }

        private void Carousel_8_box_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            setform setting = new setform();
            //setting.ShowDialog();
        }
    }
}
