using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNCAppPlatform
{
    public partial class SequenceList : Form
    {
        public string ID { set; get; } = "";
        string IniPath = Path.Combine(Form1.path, "Configurations/devices.ini");

        public SequenceList()
        {
            InitializeComponent();

            // 設置值欄為唯讀
            dataGridView1.Columns["index"].ReadOnly = true;

            FormClosed += Paramreg_setting_FormClosed;
            Load += Paramreg_setting_Load;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int total_count = dataGridView1.Rows.Count - 1;
            dataGridView1.Rows[total_count-1].Cells[0].Value = (total_count - 1).ToString();
        }

        private void Paramreg_setting_Load(object sender, EventArgs e)
        {
            // 填入設定檔

            // textBox1.Text = INiReader.ReadINIFile(IniPath, ID, "param_start_reg");
            // start_reg = Int32.Parse(textBox1.Text);

            //string[] Labels = new string[] { "Step 1", "Step 2" };
            string[] Labels = INiReader.ReadINIFile(IniPath, ID, "sequence_list").Split(';');
            for (int i = 0; i < Labels.Length; i++)
            {

                string[] row = new string[] { i.ToString(),  Labels[i] };
                dataGridView1.Rows.Add(row);
            }

            //textBox1.TextChanged += textBox1_TextChanged;
        }

        private void Paramreg_setting_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 關閉視窗時，儲存資料
            string lists = dataGridView1.Rows[0].Cells[1].Value.ToString();
            for (int i = 1; i < dataGridView1.Rows.Count-1; i++)
            {
                lists += ";" + dataGridView1.Rows[i].Cells[1].Value;
            }

            if (ID == "")
            {
                MessageBox.Show(lists);
            }
            else
            {
                INiReader.WriteINIFile(IniPath, ID, "sequence_list", lists);
            }

        }
    }
}
