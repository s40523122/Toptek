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
    public partial class TS0082_1 : UserControl
    {
        string reg_plateNo = "D0";
        string reg_orderID1 = "D0";
        string reg_orderID2 = "D0";

        public string[] D_registers
        {
            set
            {
                string[] D_reg = value as string[];
                reg_plateNo = D_reg[0];
                reg_orderID1 = D_reg[1];
                reg_orderID2 = D_reg[2];

            }
        }

        public TS0082_1()
        {
            InitializeComponent();
            PlateStateRead();
            Order1StateRead();
        }

        private void PlateStateRead()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000; // 設置計時器間隔為 1000 毫秒 (1 秒)
            timer.Elapsed += PlateNo_Timer_Elapsed;
            timer.Start();
        }

        private void PlateNo_Timer_Elapsed(object sender, EventArgs e)
        {
            int no = 1;
            short[] arraydata;
            arraydata = new short[no];

            _ = Form1.axActUtlType.ReadDeviceBlock2(reg_plateNo, no, out arraydata[0]);

            Invoke(new MethodInvoker(delegate
            {
                plateNo.Text = arraydata[0].ToString();
            }));
        }

        private void Order1StateRead()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000; // 設置計時器間隔為 1000 毫秒 (1 秒)
            timer.Elapsed += Order1_Timer_Elapsed;
            timer.Start();
        }

        private void Order1_Timer_Elapsed(object sender, EventArgs e)
        {
            int no = 2;
            short[] arraydata;
            arraydata = new short[no];

            _ = Form1.axActUtlType.ReadDeviceBlock2(reg_orderID1, no, out arraydata[0]);

            Control[] controls = new Control[] { orderID1, orderID2};
            int countNo = 0;
            Invoke(new MethodInvoker(delegate
            {

                foreach (short id in arraydata)
                {
                    try
                    {
                        controls[countNo].Text = OrderLog.IdName[arraydata[countNo]];
                    }
                    catch (Exception ex)
                    {
                        controls[countNo].Text = $"NotFound {arraydata[countNo]}";
                    }
                    countNo++;
                }

            }));
        }

        
    }
}
