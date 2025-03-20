using CNCAppPlatform.Managers;
using HZH_Controls;
using HZH_Controls.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNCAppPlatform
{
    public partial class OrderInputFrame : Form
    {
        Form backForm;

        string ID;       // 工單流水號
        private string checkStation;

        FlowLayoutPanel[] station_hours_panel;
        CheckBox[] station_checks;
        TextBox[] station_hours;

        public OrderInputFrame()
        {
            InitializeComponent();

            Init_datagridview();

            ID = (SaveCsv.DataRowCount("work_order.csv") + 1).ToString();       // 下一行 + 1

            TopMost = true;
            backForm = new Form()
            {
                StartPosition = FormStartPosition.Manual,
                FormBorderStyle = FormBorderStyle.None,
                Opacity = .50d,
                BackColor = Color.Black,
                WindowState = FormWindowState.Maximized,
                TopMost = true,
                Location = this.Location,
                ShowInTaskbar = false
            };
            if (!System.Diagnostics.Debugger.IsAttached) backForm.Show();

            station_hours_panel = new FlowLayoutPanel[] { station1_hour, station2_hour, station3_hour, station4_hour };
            station_hours = new TextBox[] {hour_1, hour_2, hour_3, hour_4};
            station_checks = new CheckBox[] { station1, station2, station3, station4 };

            // 將站別依序加入視窗中，這種作法 scroll bar 會比較自然
            station_hour_list.Controls.AddRange(station_hours_panel);

            Load += OrderInputFrame_Load;

            Size = new Size(800, 512);

            // 創建ToolTip物件
            ToolTip toolTip1 = new ToolTip();

            // 設定 ToolTip 的屬性
            toolTip1.AutoPopDelay = 360000;   // 當顯示時持續的時間 (毫秒)
            toolTip1.InitialDelay = 100;   // 滑鼠停留在控件上時等待的時間 (毫秒)
            toolTip1.ReshowDelay = 500;     // 當滑鼠再次懸停時重新顯示的延遲時間 (毫秒)
            toolTip1.ShowAlways = true;     // 即使窗體不活動也顯示 ToolTip

            // 將 ToolTip 關聯到控件
            toolTip1.SetToolTip(info, "這是一個按鈕\n有第二行嗎");
        }

        private void Init_datagridview()
        {
            // 設定 DataGridView 的欄位標題
            dataGridView1.ColumnCount = 9;
            dataGridView1.Columns[0].Name = "id";
            dataGridView1.Columns[1].Name = "order_no";
            dataGridView1.Columns[2].Name = "priority";
            dataGridView1.Columns[3].Name = "material";
            dataGridView1.Columns[4].Name = "qty";
            dataGridView1.Columns[5].Name = "due_date";
            dataGridView1.Columns[6].Name = "station";
            dataGridView1.Columns[7].Name = "station_hour";
            dataGridView1.Columns[8].Name = "remark";
        }

        private void OrderInputFrame_Load(object sender, EventArgs e)
        {
            station2_hour.Visible = false;
            station3_hour.Visible = false;
            station4_hour.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //Tag = null;
            backForm.Hide();
            Close();
            
        }

        private void station_Click(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            int station_index = Int32.Parse((string)checkBox.Tag);

            if(checkBox.Checked) checkStation = station_index.ToString();
            station_hours_panel[station_index - 1].Visible = station_checks[station_index - 1].Checked;

        }

        private void btnAppend_MouseClick(object sender, MouseEventArgs e)
        {
            // 第一站，若沒有返回 null
            string first_station = station_checks.FirstOrDefault(cb => cb.Checked)?.Tag.ToString();

            // 檢查所有格位
            if (input_order_no.Text == "")
            {
                MessageBox.Show("請填寫工單編號 !");
                return;
            }
            else if (first_station == null)
            {
                MessageBox.Show("請至少選擇一站別 !");
                return;
            }
            else if (input_material.Text == "")
            {
                MessageBox.Show("請填寫材料 !");
                return;
            }

            // 取得資料
            foreach (var station in station_checks)
            {
                if (station.Checked)
                {
                    int index = Int32.Parse(station.Tag.ToString());   

                    string[] row1 = new string[] { ID, input_order_no.Text, input_priority.Num.ToString(), input_material.Text, 
                                                   input_qty.Num.ToString(), input_due_datetime.Value.ToString("yyyy/MM/dd HH:mm"), station.Text, station_hours[index-1].Text, remark_msg.Text};
                    dataGridView1.Rows.Add(row1);
                }
            }
            SaveCsv.SaveDataGridViewToCSV(dataGridView1, "work_order.csv");

            //Tag = $"{OrderName1.Text};{checkStation};{material1.Text};{count1.Num};{DateTime.Now};{remark.Text}";
            PlcWrite("D1350", ID);      // 工單
            PlcWrite("D1351", checkStation);        // 站別

            int number = Decimal.ToInt32(input_qty.Num);
            // 將數字分割成兩個8位的部分
            int highShort = (int)(number >> 16); // 右移8位，得到高8位
            int lowShort = (int)(number & 0xFFFF); // 用0xFF（二進位表示為11111111）進行AND運算，得到低8位

            // 寫入Register1
            MXConnect.axActUtlType.SetDevice("D1353", highShort);
            // 寫入Register2
            MXConnect.axActUtlType.SetDevice("D1352", lowShort);

            PlcWrite("D1354", "1");     // 傳送確認

            PlcRead();
            
        }

        private void PlcWrite(string d, string value)
        {
            int no = 1;
            short[] arraydata;

            arraydata = new short[1] { (short)Convert.ToInt32(value) };
            MXConnect.axActUtlType.WriteDeviceBlock2(d, no, ref arraydata[0]);
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
            MXConnect.axActUtlType.ReadDeviceBlock2(d, no, out arraydata[0]);
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
    }

    class Order_Model
    {
        public string Order_no {  get; set; }
        public int Priority { get; set; }
        public string Material { get; set; }
        public int Qty { get; set; }
        public DateTime Due_date { get; set; }
        public string Process {  get; set; }
        public decimal Process_hour {  get; set; }

        public Order_Model(string order_no, decimal priority, string material, decimal qty, DateTime due_date, string process, decimal process_hour)
        {
            this.Order_no = order_no;
            this.Priority = Decimal.ToInt32(priority);
            this.Material = material;
            this.Qty = Decimal.ToInt32(qty);
            this.Due_date = due_date;
            this.Process = process;
            this.Process_hour = process_hour;
        }
    }
}
