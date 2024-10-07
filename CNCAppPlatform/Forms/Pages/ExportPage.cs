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
    }
}
