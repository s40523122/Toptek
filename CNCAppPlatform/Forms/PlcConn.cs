using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ActUtlTypeLib;

namespace CNCAppPlatform
{
    public partial class PlcConn : Form
    {

        public PlcConn()
        {
            InitializeComponent();
        }

        private void addItemButton1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.RowCount++;
            TableLayoutPanelCellPosition buttonPosition = tableLayoutPanel1.GetCellPosition(sender as AddItemButton);
            buttonPosition.Row ++;

            tableLayoutPanel1.Controls.Add(new PlcConnectionBox()
            {
                Dock = DockStyle.Fill,
                Height = 263,
                CheckStatus = true,
                LogicalStationNumber = tableLayoutPanel1.RowCount - 1
            });
            
            

            tableLayoutPanel1.SetCellPosition(sender as AddItemButton, new TableLayoutPanelCellPosition(buttonPosition.Column + 1, buttonPosition.Row));

        }
    }
}
