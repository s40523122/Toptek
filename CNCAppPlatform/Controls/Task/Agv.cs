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
    public partial class Agv : UserControl
    {
        string reg_Agv = "D0";

        public string[] D_registers
        {
            set
            {
                string[] D_reg = value as string[];
                reg_Agv = D_reg[0];
            }
        }

        public Agv()
        {
            InitializeComponent();
            AgvStateRead();
        }

        private void AgvStateRead()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000; // 設置計時器間隔為 1000 毫秒 (1 秒)
            timer.Elapsed += Agv_Timer_Elapsed;
            timer.Start();
        }

        private void Agv_Timer_Elapsed(object sender, EventArgs e)
        {
            int no = 6;
            short[] arraydata;
            arraydata = new short[no];

            _ = Form1.axActUtlType.ReadDeviceBlock2(reg_Agv, no, out arraydata[0]);

            Control[] controls = new Control[] { orderID1, orderID2, orderID31, orderID32, orderID41, orderID42 };
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
