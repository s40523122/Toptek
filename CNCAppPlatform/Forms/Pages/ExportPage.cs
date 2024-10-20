using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNCAppPlatform.Forms.Pages
{
    public partial class ExportPage : Form
    {
        public bool xml_mode = false;
        
        int station = 0;
        int mode = 0;
        
        Form backForm;
        public ExportPage()
        {
            InitializeComponent();

            // 建立黑背景
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
            if (!System.Diagnostics.Debugger.IsAttached) backForm.Show();       // Dubug 模式不顯示
        }

        private void btnClose_CheckedChanged(object sender, EventArgs e)
        {
            Close();
            backForm.Hide();
        }

        private void btnAppend_Click(object sender, EventArgs e)
        {
            switch (mode)
            {
                case 1:
                    SaveCsv.FilterCsv("work_order.csv", "station", station.ToString(), is_xml:xml_mode);
                    break;
                case 2:
                    SaveCsv.FilterCsv("availability_history.csv", "station", "device" + station.ToString(), is_xml:xml_mode);
                    break;
                case 3:
                    break;
            }
            
        }

        private void Station_Click(object sender, EventArgs e)
        {
            foreach(CheckBox box in groupBox1.Controls) { box.Checked = false; }
            (sender as CheckBox).Checked = true;
            station = Int32.Parse((sender as CheckBox).Tag.ToString());
        }

        private void Mode_Click(object sender, EventArgs e)
        {
            foreach (CheckBox box in groupBox2.Controls) { box.Checked = false; }
            (sender as CheckBox).Checked = true;
            mode = Int32.Parse((sender as CheckBox).Tag.ToString());
        }
    }
}
