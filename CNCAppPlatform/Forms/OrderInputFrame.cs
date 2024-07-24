using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNCAppPlatform
{
    public partial class OrderInputFrame : Form
    {
        Form backForm;

        public string ID;
        private string checkStation = "";

        public OrderInputFrame()
        {
            InitializeComponent();

            backForm = new Form()
            {
                StartPosition = FormStartPosition.Manual,
                FormBorderStyle = FormBorderStyle.None,
                Opacity = .50d,
                BackColor = Color.Black,
                WindowState = FormWindowState.Maximized,
                TopMost = true,
                Location = this.Location,
                ShowInTaskbar = false,
            };
            if (!System.Diagnostics.Debugger.IsAttached) backForm.Show();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //Tag = null;
            Close();
            backForm.Hide();
        }

        private void btnAppend_MouseClick(object sender, MouseEventArgs e)
        {
            if (OrderName.Text == "") MessageBox.Show("請填寫工單編號 !");
            else if (checkStation == "") MessageBox.Show("請勾選站別 !");
            else if (material.Text == "") MessageBox.Show("請填寫材料 !");
            else if (count.Text == "") MessageBox.Show("請填寫數量 !");
            else if (!int.TryParse(count.Text, out _)) MessageBox.Show("數量欄位請填寫數字 !");
            else
            {
                Tag = $"{OrderName.Text};{checkStation};{material.Text};{count.Text};{DateTime.Now};{remark.Text}";
                PlcWrite("D1350", ID);      // 工單
                PlcWrite("D1351", checkStation);        // 站別

                int number = int.Parse(count.Text);
                // 將數字分割成兩個8位的部分
                int highShort = (int)(number >> 16); // 右移8位，得到高8位
                int lowShort = (int)(number & 0xFFFF); // 用0xFF（二進位表示為11111111）進行AND運算，得到低8位

                // 寫入Register1
                Form1.axActUtlType.SetDevice("D1353", highShort);
                // 寫入Register2
                Form1.axActUtlType.SetDevice("D1352", lowShort);

                PlcWrite("D1354", "1");     // 傳送確認

                PlcRead();
            }
        }

        private void PlcWrite(string d, string value)
        {
            int no = 1;
            short[] arraydata;

            arraydata = new short[1] { (short)Convert.ToInt32(value) };
            _ = Form1.axActUtlType.WriteDeviceBlock2(d, no, ref arraydata[0]);
        }

        System.Timers.Timer timer = new System.Timers.Timer();
        private void PlcRead()
        {
            timer.Interval = 200; // 設置計時器間隔為 1000 毫秒 (1 秒)
            timer.Elapsed += Timer_Tick;
            timer.Start();
        }

        MsgBox msgBox = new MsgBox() { Visible = false, StartPosition = FormStartPosition.CenterScreen, TopMost = true};
        bool isShow = false;

        private void Timer_Tick(object sender, EventArgs e)
        {
            string d = "";
            int no = 1;
            short[] arraydata;
            arraydata = new short[no];

            d = "D1355";
            _ = Form1.axActUtlType.ReadDeviceBlock2(d, no, out arraydata[0]);
            if (arraydata[0] == 1 || Debugger.IsAttached)
            {
                //MessageBox.Show("確認PLC接收工單", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                Invoke(new MethodInvoker(delegate
                {
                    label7.Text = "PLC已接收工單";
                    label7.Visible = true;
                    
                    msgBox.lbMsg.Text = "PLC已接收工單";
                    if (!isShow)
                    {
                        msgBox.Show();
                        PlcWrite("D1354", "0");     // 清除確認
                        isShow = true;
                        Close();
                        backForm.Hide();
                    }
                }));

                timer.Stop();
                timer.Dispose();
            }
        }


        private void checkBox1_Click(object sender, EventArgs e)
        {
            CheckBox selecting = sender as CheckBox;
            checkStation = selecting.Text;
            foreach (CheckBox checkBox in tlpStation.Controls)
            {
                if (checkBox == selecting)checkBox.Checked = true;
                else checkBox.Checked = false;
            }
        }
    }
}
