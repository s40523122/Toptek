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
    public partial class TR1844 : UserControl
    {
        string reg_count = "D0";

        public string[] D_registers
        {
            set
            {
                string[] D_reg = value as string[];
                reg_count = D_reg[0];
            }
        }

        public TR1844()
        {
            InitializeComponent();

            CountStateRead();
        }

        private void CountStateRead()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000; // 設置計時器間隔為 1000 毫秒 (1 秒)
            timer.Elapsed += Count_Timer_Elapsed;
            timer.Start();
        }

        private void Count_Timer_Elapsed(object sender, EventArgs e)
        {
            int no = 1;
            short[] arraydata;
            arraydata = new short[no];

            _ = Form1.axActUtlType.ReadDeviceBlock2(reg_count, no, out arraydata[0]);

            Invoke(new MethodInvoker(delegate
            {
                count.Text = arraydata[0].ToString();
            }));
        }
    }
}
