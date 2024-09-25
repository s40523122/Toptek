using CNCAppPlatform.APS;
using CNCAppPlatform.Controls;
using CNCAppPlatform.Forms.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNCAppPlatform
{
    public partial class OrderForm : Form
    {
        public static Dictionary<int, string> IdName = new Dictionary<int, string>() { {0, "N/A" } };
        public OrderForm()
        {
            InitializeComponent();

            Gantt_Show();

            btnAppend.Click += BtnAppend_Click;
            btnLog.Click += BtnLog_Click;
            btnApsMode.Click += BtnApsMode_Click;
        }

        private void BtnApsMode_Click(object sender, EventArgs e)
        {
            ApsModeSelect orderLogFrame = new ApsModeSelect() { FormBorderStyle = FormBorderStyle.None };
            orderLogFrame.ShowDialog();
        }

        private void BtnLog_Click(object sender, EventArgs e)
        {
            OrderLog orderLogFrame = new OrderLog() { FormBorderStyle = FormBorderStyle.None};
            orderLogFrame.ShowDialog();
        }

        int idCount = 1;
        private void BtnAppend_Click(object sender, EventArgs e)
        {
            OrderInputFrame orderInputFrame = new OrderInputFrame() { FormBorderStyle = FormBorderStyle.None, ID = idCount.ToString() };
            orderInputFrame.ShowDialog();

            if (orderInputFrame.Tag == null) return;

            string[] data = (orderInputFrame.Tag as string).Split(';');

            // 加入 datagridview
            // dataGridView1.Rows.Add(idCount, data[0], data[1], data[2], data[3], data[4], data[5]);
            IdName.Add(idCount, data[0]);
            idCount++;
        }

        

        private void Gantt_Show()
        {
            // 建立機台
            var machine1 = new Machine(1, new List<int> { 1, 2 });
            var machine2 = new Machine(2, new List<int> { 3 });
            var machine3 = new Machine(3, new List<int> { 2 });

            // 建立工單
            var job1 = new Job("001", DateTime.Now.AddDays(3), 1, new List<Process>
            {
                new Process(1, 52.5), // 製程序號 1，時間 1.5 小時
                new Process(2, 12.0)  // 製程序號 2，時間 2.0 小時
            }, "MaterialA", 100);

            var job2 = new Job("002", DateTime.Now.AddDays(4), 2, new List<Process>
            {
                new Process(2, 32.0), // 製程序號 2，時間 2.0 小時
                new Process(3, 3.4)  // 製程序號 3，時間 1.5 小時
            }, "MaterialB", 150);

            var job3 = new Job("003", DateTime.Now.AddDays(1), 2, new List<Process>
            {
                new Process(2, 10.6), // 製程序號 2，時間 2.0 小時
                new Process(3, 22.8)  // 製程序號 3，時間 1.5 小時
            }, "MaterialB", 150);

            var job4 = new Job("004", DateTime.Now.AddDays(2), 2, new List<Process>
            {
                new Process(1, 46.3), // 製程序號 2，時間 2.0 小時
                new Process(3, 10.5)  // 製程序號 3，時間 1.5 小時
            }, "MaterialB", 150);

            var job5 = new Job("005", DateTime.Now.AddDays(3), 2, new List<Process>
            {
                new Process(2, 18.9), // 製程序號 2，時間 2.0 小時
            }, "MaterialB", 150);

            // 建立派工器
            var dispatcher = new MinimizeJobDelay(new List<Job> { job1, job2, job3, job4, job5 }, new List<Machine> { machine1, machine2, machine3 });

            // 開始派工
            dispatcher.Dispatching();

            // 顯示每台機台的時程表
            machine1.DisplaySchedule();
            machine2.DisplaySchedule();
            machine3.DisplaySchedule();

            List<Machine> machines = new List<Machine>() { machine1, machine2 , machine3 }; // 取得包含排程的機台列表
            
            GanttChartForm frame = new GanttChartForm(machines)
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                Parent = panel1,
                FormBorderStyle = FormBorderStyle.None
            };

            frame.Show();
        }


    }
}
