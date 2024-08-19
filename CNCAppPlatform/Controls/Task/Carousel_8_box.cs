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
    public partial class Carousel_8_box : UserControl
    {
        string reg_plateNo1 = "D0";
        string reg_plateNo2 = "D0";
        string reg_plateNo3 = "D0";
        string reg_plateNo4 = "D0";
        string reg_orderID1 = "D0";
        string reg_orderID2 = "D0";

        string reg_wh1 = "D0";
        string reg_wh2 = "D0";
        string reg_wh3 = "D0";
        string reg_wh4 = "D0";
        string reg_wh5 = "D0";
        string reg_wh6 = "D0";
        string reg_wh7 = "D0";
        string reg_wh8 = "D0";
        string reg_wh9 = "D0";
        string reg_wh10 = "D0";
        string reg_wh11 = "D0";
        string reg_wh12 = "D0";

        public string[] D_registers
        {
            set
            {
                string[] D_reg = value as string[];
                reg_plateNo1 = D_reg[0];
                reg_plateNo2 = D_reg[1];
                reg_plateNo3 = D_reg[2];
                reg_plateNo4 = D_reg[3];
                reg_orderID1 = D_reg[4];
                reg_orderID2 = D_reg[5];
            }
        }

        public string[] Dwh_registers
        {
            set
            {
                string[] Dwh_reg = value as string[];
                reg_wh1 = Dwh_reg[0];
                reg_wh2 = Dwh_reg[1];
                reg_wh3 = Dwh_reg[2];
                reg_wh4 = Dwh_reg[3];
                reg_wh5 = Dwh_reg[4];
                reg_wh6 = Dwh_reg[5];
                reg_wh7 = Dwh_reg[6];
                reg_wh8 = Dwh_reg[7];
                reg_wh9 = Dwh_reg[8];
                reg_wh10 = Dwh_reg[9];
                reg_wh11 = Dwh_reg[10];
                reg_wh12 = Dwh_reg[11];
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
    }
}
