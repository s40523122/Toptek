using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ActUtlTypeLib;

namespace CNCAppPlatform
{
    public partial class PlcConnectionBox : UserControl
    {
        [Description("連接到 MX COMPONENT 的 Logical Station Number"), Category("自訂值")]
        public int LogicalStationNumber
        {
            get { return _LogicalStationNumber; }
            set
            {
                _LogicalStationNumber = value;
                title.Text = $"#{_LogicalStationNumber}";
            }
        }
        private int _LogicalStationNumber = 1;

        [Description("IP"), Category("自訂值")]
        public string IpAddress
        {
            get { return tbIP.Text; }
            set
            {
                tbIP.Text = value;
            }
        }

        [Description("是否預設群組"), Category("自訂值")]
        public bool IsDefaultGroup
        {
            get { return _isDefaultGroup; }
            set
            {
                _isDefaultGroup = value;
                btnCpu5u.Checked = _isDefaultGroup;
                btnConnEthernet.Checked = _isDefaultGroup;
            }
        }
        private bool _isDefaultGroup;


        public bool CheckStatus
        {
            get { return btnEdit.Checked; }
            set
            {
                btnEdit.Checked = value;
            }
        }

        CheckBox[] btnCpus;
        CheckBox[] btnConns;

        public PlcConnectionBox()
        {
            InitializeComponent();

            btnCpus = new CheckBox[] { btnCpu3u, btnCpu5u };
            btnConns = new CheckBox[] { btnConnEthernet, btnConnRS232 };

            try
            {
                Form1.axActUtlType = new ActUtlType();

                connectBtn.Click += ConnectBtn_Click;
                disconnBtn.Click += DisconnBtn_Click;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "連線錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            btnCpu3u.Click += BtnCpu_Click;
            btnCpu5u.Click += BtnCpu_Click;
            btnConnEthernet.Click += BtnConn_Click;
            btnConnRS232.Click += BtnConn_Click;

        }

        private void BtnConn_Click(object sender, EventArgs e)
        {
            if (btnEdit.Checked != true) return;
            foreach (CheckBox checkBox in btnConns)
            {
                if (checkBox == sender as CheckBox) checkBox.Checked = true;
                else checkBox.Checked = false;
            }
        }

        private void BtnCpu_Click(object sender, EventArgs e)
        {
            if (btnEdit.Checked != true) return;
            foreach (CheckBox checkBox in btnCpus)
            {
                if (checkBox == sender as CheckBox) checkBox.Checked = true;
                else checkBox.Checked = false;
            }
        }

        private void DisconnBtn_Click(object sender, EventArgs e)
        {
            Form1.axActUtlType.Close();
            labelLED1.IsLight = false;
            (ParentForm.ParentForm as Form1).ConnectStatus = "連接狀態：未連接";
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            int returncode;
            try
            {
                Form1.axActUtlType.ActLogicalStationNumber = LogicalStationNumber;
                returncode = Form1.axActUtlType.Open();
                if (returncode == 0)
                {
                    //MessageBox.Show("connect");
                    labelLED1.IsLight = true;
                    (ParentForm.ParentForm as Form1).ConnectStatus = $"連接狀態：已連接至 #{LogicalStationNumber}";

                }
                else MessageBox.Show("unconnect");
            }
            catch
            {
                MessageBox.Show("unconnect");
            }
        }

        private void btnCheck_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CheckBox checkBox in btnCpus)
            {
                checkBox.AutoCheck = btnEdit.Checked;
            }

            foreach (CheckBox checkBox in btnConns)
            {
                checkBox.AutoCheck = btnEdit.Checked;
            }

            tbIP.ReadOnly = !btnEdit.Checked;

            connectBtn.Visible = !btnEdit.Checked;
            disconnBtn.Visible = !btnEdit.Checked;
            editFinBtn.Visible = btnEdit.Checked;
        }

        private void editFinBtn_Click(object sender, EventArgs e)
        {
            btnEdit.Checked = !btnEdit.Checked;
        }
    }
}
