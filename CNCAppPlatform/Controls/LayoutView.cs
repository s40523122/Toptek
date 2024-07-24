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
    public partial class LayoutView : Form
    {
        public LayoutView()
        {
            InitializeComponent();

            btnEditOrder.Click += BtnEditOrder_Click;
        }

        private void BtnEditOrder_Click(object sender, EventArgs e)
        {
            OrderInputFrame orderInputFrame = new OrderInputFrame() { FormBorderStyle = FormBorderStyle.None};
            orderInputFrame.ShowDialog();
        }
    }
}
