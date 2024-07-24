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
    public partial class OrderLog : Form
    {
        public static Dictionary<int, string> IdName = new Dictionary<int, string>() { {0, "N/A" } };
        public OrderLog()
        {
            InitializeComponent();
            InitialzeDataGridView();

            btnAppend.Click += BtnAppend_Click;
        }

        int idCount = 1;
        private void BtnAppend_Click(object sender, EventArgs e)
        {
            OrderInputFrame orderInputFrame = new OrderInputFrame() { FormBorderStyle = FormBorderStyle.None, ID = idCount.ToString() };
            orderInputFrame.ShowDialog();

            if (orderInputFrame.Tag == null) return;

            string[] data = (orderInputFrame.Tag as string).Split(';');

            dataGridView1.Rows.Add(idCount, data[0], data[1], data[2], data[3], data[4], data[5]);
            IdName.Add(idCount, data[0]);
            idCount++;
        }

        private void InitialzeDataGridView()
        {
            dataGridView1.Columns.Add("ID","ID");
            dataGridView1.Columns.Add("OrderName", "工單編號\nOrder Name");
            dataGridView1.Columns.Add("Station", "站別\nStation");
            dataGridView1.Columns.Add("Material", "材料\nMaterial");
            dataGridView1.Columns.Add("Count", "數量 \nCount");
            dataGridView1.Columns.Add("Log_Time", "紀錄日期\nLog Time");
            dataGridView1.Columns.Add("Remark", "備註\nRemark");

            // 設定欄的寬度
            dataGridView1.Columns["ID"].Width = 40;
            dataGridView1.Columns["OrderName"].Width = 200;
            dataGridView1.Columns["Station"].Width = 150;
            dataGridView1.Columns["Material"].Width = 200;
            dataGridView1.Columns["Count"].Width = 120;
            dataGridView1.Columns["Log_Time"].Width = 275;
            dataGridView1.Columns["Remark"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
