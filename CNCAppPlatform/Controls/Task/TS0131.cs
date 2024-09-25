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
    public partial class TS0131 : UserControl
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

        public TS0131()
        {
            InitializeComponent();
            pageRight.Location = pageLeft.Location;
            pageMiddle.Location = pageLeft.Location;
            pageRight.Location = pageLeft.Location;

            pageLeft.BringToFront();

            panels = new Panel[] { pageLeft, pageMiddle, pageRight };

            btnL2M.Click += Btn2Right_Click;
            btnM2R.Click += Btn2Right_Click;
            
            btnM2L.Click += Btn2Left_Click;
            btnR2M.Click += Btn2Left_Click;

            PlateStateRead();
            OrderStateRead();
            WhStateRead();
        }

        private void Btn2Left_Click(object sender, EventArgs e)
        {
            pageIndex--;
            panels[pageIndex].BringToFront();
        }

        private void Btn2Right_Click(object sender, EventArgs e)
        {
            pageIndex++;
            panels[pageIndex].BringToFront();
        }

        private void PlateStateRead()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000; // 設置計時器間隔為 1000 毫秒 (1 秒)
            timer.Elapsed += Plate_Timer_Elapsed;
            timer.Start();
        }

        private void Plate_Timer_Elapsed(object sender, EventArgs e)
        {
            int no = 4;
            short[] arraydata = new short[no];

            _ = Form1.axActUtlType.ReadDeviceBlock2(reg_plateNo1, no, out arraydata[0]);

            Invoke(new MethodInvoker(delegate
            {
                plateNo1.Text = arraydata[0].ToString();
                plateNo2.Text = arraydata[1].ToString();
                plateNo3.Text = arraydata[2].ToString();
                plateNo4.Text = arraydata[3].ToString();
            }));
        }

        private void OrderStateRead()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000; // 設置計時器間隔為 1000 毫秒 (1 秒)
            timer.Elapsed += Order_Timer_Elapsed;
            timer.Start();
        }

        private void Order_Timer_Elapsed(object sender, EventArgs e)
        {
            int no = 2;
            short[] arraydata = new short[no];

            _ = Form1.axActUtlType.ReadDeviceBlock2(reg_orderID1, no, out arraydata[0]);

            Invoke(new MethodInvoker(delegate
            {
                try
                {
                    orderID1.Text = OrderForm.IdName[arraydata[0]];
                }
                catch (Exception ex)
                {
                    orderID1.Text = $"NotFound {arraydata[0]}";
                }

                try
                {
                    orderID2.Text = OrderForm.IdName[arraydata[1]];
                }
                catch (Exception ex)
                {
                    orderID2.Text = $"NotFound {arraydata[1]}";
                }
            }));
        }

        private void WhStateRead()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000; // 設置計時器間隔為 1000 毫秒 (1 秒)
            timer.Elapsed += Wh_Timer_Elapsed;
            timer.Start();
        }

        private void Wh_Timer_Elapsed(object sender, EventArgs e)
        {
            int no = 12;
            short[] arraydata = new short[no];

            _ = Form1.axActUtlType.ReadDeviceBlock2(reg_wh1, no, out arraydata[0]);
            Control[] controls = new Control[] {wh1, wh2, wh3, wh4, wh5, wh6, wh7, wh8, wh9, wh10, wh11, wh12 };
            int countNo = 0;
            Invoke(new MethodInvoker(delegate
            {

                foreach (short id in arraydata)
                {
                    try
                    {
                        controls[countNo].Text = OrderForm.IdName[arraydata[countNo]];
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
