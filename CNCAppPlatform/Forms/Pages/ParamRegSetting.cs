using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNCAppPlatform
{
    public partial class ParamRegSetting : Form
    {
        int start_reg { get; set; } = 0;

        public string ID { set; get; } = "";

        string IniPath = Path.Combine(Form1.path, "Configurations/devices.ini");

        public ParamRegSetting()
        {
            InitializeComponent();

            textBox1.Text = start_reg.ToString();

            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView2.BorderStyle = BorderStyle.None;

            // 設置值欄為唯讀
            dataGridView1.Columns["value"].ReadOnly = true;

            FormClosed += Paramreg_setting_FormClosed;
            Load += Paramreg_setting_Load;
        }

        private void Paramreg_setting_Load(object sender, EventArgs e)
        {
            // 填入設定檔
            // List<string> Labels = new List<string>(){"繁體中文字測試", "label2", "label3", "label4", "label5", "label6", "label7", "label8", "label9", "label10", "label11", "label12",
            //                             "label13", "label14", "label15", "label16", "label17", "label18", "label19", "label20", "label21", "label22", "label23", "label24"};
            textBox1.Text = INiReader.ReadINIFile(IniPath, ID, "param_start_reg");
            start_reg = Int32.Parse(textBox1.Text);

            List<string> Labels = INiReader.ReadINIFile(IniPath, ID, "param_labels").Split(';').ToList();
            for (int i = 0; i < 12; i++)
            {

                string[] row = new string[] { Labels[i], $"D{start_reg++}" };
                dataGridView1.Rows.Add(row);

            }
            for (int i = 12; i < 24; i++)
            {
                string[] row = new string[] { Labels[i], $"D{start_reg++}" };
                dataGridView2.Rows.Add(row);
            }

            textBox1.TextChanged += textBox1_TextChanged;
        }

        private void Paramreg_setting_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 關閉視窗時，儲存資料
            string label_config = dataGridView1.Rows[0].Cells[0].Value.ToString();
            for (int i = 1; i < 12; i++)
            {
                label_config += ";" + dataGridView1.Rows[i].Cells[0].Value;
            }
            for (int i = 0; i < 12; i++)
            {
                label_config += ";" + dataGridView2.Rows[i].Cells[0].Value;
            }

            if (ID == "")
            {
                MessageBox.Show(label_config);
            }
            else
            {
                INiReader.WriteINIFile(IniPath, ID, "param_start_reg", textBox1.Text);
                INiReader.WriteINIFile(IniPath, ID, "param_labels", label_config);
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Int32.TryParse(textBox1.Text, out int val);
            start_reg = val;

            for (int i = 0; i < 12; i++)
            {

                dataGridView1.Rows[i].Cells[1].Value = $"D{start_reg++}";

            }
            for (int i = 0; i < 12; i++)
            {
                dataGridView2.Rows[i].Cells[1].Value = $"D{start_reg++}";
            }
        }
    }
}
