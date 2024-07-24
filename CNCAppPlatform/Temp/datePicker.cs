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
    public partial class datePicker : Form
    {
        public datePicker()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            globalVar.startDate = dtpStartDate.Value.Date.ToString("yyyy-MM-dd");
            globalVar.endDate = dtpEndDate.Value.AddDays(1).ToString("yyyy-MM-dd");
            globalVar.endDateReal = dtpEndDate.Value.Date.ToString("yyyy-MM-dd");
            this.Close();
        }
    }
}
