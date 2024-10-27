using CNCAppPlatform.APS;
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

        public void Input_order_histroy(string title_name)
        {
            flowLayoutPanel1.Visible = false;
            label1.Text = title_name;

            SaveCsv.LoadCSVToDataGridView(dataGridView1, "order_history.csv");
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 70;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 70;
            dataGridView1.Columns[5].Width = 150;
            dataGridView1.Columns[6].Width = 150;
        }

        public void Input_order_log()
        {
            //dataGridView1.Columns.Add("ID", "ID");
            //dataGridView1.Columns.Add("OrderName", "工單編號\nOrder Name");
            //dataGridView1.Columns.Add("Station", "站別\nStation");
            //dataGridView1.Columns.Add("Material", "材料\nMaterial");
            //dataGridView1.Columns.Add("Count", "數量 \nCount");
            //dataGridView1.Columns.Add("Log_Time", "紀錄日期\nLog Time");
            //dataGridView1.Columns.Add("Remark", "備註\nRemark");

            //// 設定欄的寬度
            //dataGridView1.Columns["ID"].Width = 40;
            //dataGridView1.Columns["OrderName"].Width = 200;
            //dataGridView1.Columns["Station"].Width = 150;
            //dataGridView1.Columns["Material"].Width = 200;
            //dataGridView1.Columns["Count"].Width = 120;
            //dataGridView1.Columns["Log_Time"].Width = 275;
            //dataGridView1.Columns["Remark"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SaveCsv.LoadCSVToDataGridView(dataGridView1, "work_order.csv");
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 70;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 70;
            dataGridView1.Columns[5].Width = 150;
            dataGridView1.Columns[6].Width = 80;
            dataGridView1.Columns[7].Width = 100;


            // 第一欄前新增一欄形式為 checkbox
            DataGridViewColumn colCheck = new DataGridViewCheckBoxColumn() { Width = 45 };
            dataGridView1.Columns.Insert(0, colCheck);
            
            dataGridView1.CellClick += dgvRet_CellClick;

            // 把第一欄的標題修改為 checkbox
            Size checkbox_column_size = dataGridView1.Rows[0].Cells[0].Size;

            CheckBox checkboxHeader = new CheckBox()
            {
                Size = new Size(checkbox_column_size.Width - 2, checkbox_column_size.Height),
                CheckAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.White
            };
            checkboxHeader.Left++;
            dataGridView1.Controls.Add(checkboxHeader);

            checkboxHeader.Click += CheckboxHeader_Click; ;
        }

        private void CheckboxHeader_Click(object sender, EventArgs e)
        {
            CheckBox checkboxHeader = (CheckBox)sender;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // 修改第一欄的值（假設是 CheckBox 或者 TextBox）
                row.Cells[0].Value = checkboxHeader.Checked;
            }
        }

        private void dgvRet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 點擊第一欄的動作
            if (dataGridView1.CurrentCell.ColumnIndex == 0)
            {
                // 取得 DataGridView 中 CheckBox 的 Cell
                DataGridViewCheckBoxCell dgvCheck = (DataGridViewCheckBoxCell)(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0]);

                // 根據點擊時，Cell 的值作為判斷勾選與否。EditedFormattedValue 和 Value 均可以
                dgvCheck.Value = !Convert.ToBoolean(dgvCheck.Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = "";

            Global_Variable.raw_jobs.Clear();

            // 遍歷 DataGridView 的所有行
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // 確保這不是「新增」行
                if (row.IsNewRow) continue;

                // 檢查第一欄是否為 true
                if (Convert.ToBoolean(row.Cells[0].Value) != true) continue;
                //{
                //    // 將第二欄的值加入清單
                //    string secondColumnValue = row.Cells[2].Value.ToString();
                //    msg += (secondColumnValue) + "\n";
                //}

                
                if (Global_Variable.raw_jobs.Count != 0)
                {
                    if (row.Cells[2].Value.ToString() == Global_Variable.raw_jobs.Last().order_no)
                    {
                        // 相同製程
                        Global_Variable.raw_jobs.Last().processes.Add(new Process(row.Cells[7].Value.ToString(), row.Cells[8].Value.ToString()));
                        continue;
                    }
                }
                

                List<Process> processes = new List<Process> { new Process(row.Cells[7].Value.ToString(), row.Cells[8].Value.ToString()) };

                Job _job = new Job(row.Cells[2].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[3].Value.ToString(), processes, row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString());

                Global_Variable.raw_jobs.Add(_job);

            }

            //MessageBox.Show(msg);
        }
    }
}
