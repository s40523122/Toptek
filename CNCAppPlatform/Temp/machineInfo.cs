using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlAccessMaicl;
using iniRW;
using System.Data.SqlClient;

namespace CNCAppPlatform
{
    public partial class machineInfo : Form
    {
        sqlAccessClass maicl;

        public machineInfo()
        {
            InitializeComponent();
            maicl = new sqlAccessClass(sqlLink.server, sqlLink.db, sqlLink.user, sqlLink.pw);
        }

        private void machineInfo_Load(object sender, EventArgs e)
        {
            tbSUBID.Text = maicl.readData("EQUIPMENT", "SUBID", "EQUIPID", globalVar.activeEquipment);
            tbOPID.Text = maicl.readData("EQUIPMENT", "OPID", "EQUIPID", globalVar.activeEquipment);
            lbEquipID.Text = globalVar.activeEquipment;
            lbIP.Text = maicl.readData("EQUIPMENT", "DEVIP", "EQUIPID", globalVar.activeEquipment);

            string result = maicl.readData("EQUIPMENT", "LINKSTATUS", "EQUIPID", globalVar.activeEquipment);
            if (result == "1")
                tsLinkStatus.Checked = true;
            else if (result == "0")
                tsLinkStatus.Checked = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btUpdateSubID_Click(object sender, EventArgs e)
        {
            if (tsChangeToolset.Checked == false)
            {
                MsgBox msgBox = new MsgBox();
                msgBox.StartPosition = FormStartPosition.CenterParent;
                msgBox.lbMsg.Text = "請先解鎖，再更新參數";
                msgBox.ShowDialog(this);
            }
            else
            {
                int result = maicl.update("EQUIPMENT", "EQUIPID", globalVar.activeEquipment, "SUBID", tbSUBID.Text, "OPID", tbOPID.Text);

                if(result == 1)
                {
                    MsgBox msgBox = new MsgBox();
                    msgBox.StartPosition = FormStartPosition.CenterParent;
                    msgBox.lbMsg.Text = "資訊更新完成";
                    msgBox.ShowDialog(this);

                    tbSUBID.Text = maicl.readData("EQUIPMENT", "SUBID", "EQUIPID", globalVar.activeEquipment);
                    tbOPID.Text = maicl.readData("EQUIPMENT", "OPID", "EQUIPID", globalVar.activeEquipment);
                }

                else
                {
                    MsgBox msgBox = new MsgBox();
                    msgBox.StartPosition = FormStartPosition.CenterParent;
                    msgBox.lbMsg.Text = "資訊更新失敗，請檢查SQL連線";
                    msgBox.ShowDialog(this);
                }
            }
        }

        private void tsChangeToolset_CheckedChanged(object sender, EventArgs e)
        {
            if(tsChangeToolset.Checked==true)
            {
                tbSUBID.ReadOnly = false;
                tbOPID.ReadOnly = false;
            }
            else
            {
                tbSUBID.ReadOnly = true;
                tbOPID.ReadOnly = true;
            }
        }

        private void tsLinkStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (tsLinkStatus.Checked == true)
            {
                maicl.update("EQUIPMENT", "EQUIPID", globalVar.activeEquipment, "LINKSTATUS", "1");
                tsChangeToolset.Checked = false;
            }
            else
                maicl.update("EQUIPMENT", "EQUIPID", globalVar.activeEquipment, "LINKSTATUS", "0");
        }

        private void tsChangeToolset_Click(object sender, EventArgs e)
        {
            if (tsLinkStatus.Checked == true)
            {
                tsChangeToolset.Checked = false;
                MsgBox msgBox = new MsgBox();
                msgBox.StartPosition = FormStartPosition.CenterParent;
                msgBox.lbMsg.Text = "請先將設備離線";
                msgBox.ShowDialog(this);
            }
        }
    }
}
