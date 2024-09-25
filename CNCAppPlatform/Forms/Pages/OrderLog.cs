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
        Form backForm;

        public OrderLog()
        {
            InitializeComponent();

            InitialzeDataGridView();

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

        private void InitialzeDataGridView()
        {
            dataGridView1.Columns.Add("ID", "ID");
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
