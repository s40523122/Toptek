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
    public partial class PlcControl : Form
    {
        int tableCol = 0;
        public PlcControl()
        {
            InitializeComponent();

            tableCol = (int)(Width / plcRW_Test1.Width);
            tableLayoutPanel1.ColumnCount = tableCol;
            //tableLayoutPanel1 = true;

            addItemButton1.Click += AddItemButton1_Click; 
        }

        private void AddItemButton1_Click(object sender, EventArgs e)
        {

            tableLayoutPanel1.Controls.Add(new PlcRW_Test());
            TableLayoutPanelCellPosition buttonPosition = tableLayoutPanel1.GetCellPosition(sender as AddItemButton);
            if(buttonPosition.Column > tableCol-1)
            {
                buttonPosition.Column = 0;
                buttonPosition.Row += 1;
            }
            tableLayoutPanel1.SetCellPosition(sender as AddItemButton, new TableLayoutPanelCellPosition(buttonPosition.Column+1, buttonPosition.Row));

        }

    }
}
