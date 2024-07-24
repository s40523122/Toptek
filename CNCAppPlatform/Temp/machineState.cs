using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using LiveCharts;
using LiveCharts.Wpf;
using SqlAccessMaicl;
using iniRW;
using System.Reflection;

namespace CNCAppPlatform
{
    public partial class machineState : UserControl
    {
        bool alarmSignal_RBA = false, alarmSignal_AGV = false, alarmSignal_CNC = false;
        string Server, DB, USER, PW;

        sqlAccessClass iCAP;

        //LineNotify hachunGroup;

        public machineState()
        {
            InitializeComponent();

            string path = Application.StartupPath;
            iniRWtool ini = new iniRWtool(path + "\\DB.ini");

            sqlLink.server = ini.IniReadValue("Server", "Name");
            sqlLink.db = ini.IniReadValue("DB", "Name");
            sqlLink.user = ini.IniReadValue("USER", "Name");
            sqlLink.pw = ini.IniReadValue("PW", "PW");

            //iCAP = new sqlAccessClass(sqlLink.server, sqlLink.db, sqlLink.user, sqlLink.pw);
            iCAP = new sqlAccessClass(sqlLink.server, sqlLink.db, sqlLink.user, sqlLink.pw);

            lbFreq.Text = timer1.Interval.ToString();
            //hachunGroup = new LineNotify("ZZkOh8kZn3QLj9hGmy8lfWygcTCekFl1wBbPlavR2LX");

            //timer1.Enabled = true;


            try
            {
                SqlConnection sqlCon = new SqlConnection("Data Source=" + sqlLink.server + ";Initial Catalog=" + sqlLink.db + ";Persist Security Info=True;User ID=" + sqlLink.user + ";Password=" + sqlLink.pw);
                sqlCon.Open();
                string getStkStatus = "SELECT EQUIPID, EQTYPE FROM EQUIPMENT ORDER BY EQUIPID";

                SqlCommand cmdRead = new SqlCommand(getStkStatus, sqlCon);
                SqlDataReader dr = cmdRead.ExecuteReader();
                while (dr.Read())
                {
                    if (!dr[0].Equals(DBNull.Value))
                    {
                        equipStateIndicator equipStateIndicator = new equipStateIndicator();
                        equipStateIndicator.Name = dr["EQUIPID"].ToString();
                        equipStateIndicator.title = dr["EQUIPID"].ToString();
                        equipStateIndicator.Margin = new Padding(30, 0, 30, 0);
                        if (dr["EQUIPID"].ToString().Contains("VMC"))
                        {
                            equipStateIndicator.icon = Properties.Resources.lg500;
                            equipStateIndicator.ButtonClick += new EventHandler(equip_Click);
                        }
                        else if (dr["EQUIPID"].ToString().Contains("AGV"))
                        {
                            equipStateIndicator.icon = Properties.Resources.AGV;
                            equipStateIndicator.subidVisible = false;
                            equipStateIndicator.moidVisible = false;
                            equipStateIndicator.opidVisible = false;
                        }
                        else if (dr["EQUIPID"].ToString().Contains("RBA"))
                        {
                            if (dr["EQTYPE"].ToString() == "DualArm")
                                equipStateIndicator.icon = Properties.Resources.dualarm;
                            else if (dr["EQTYPE"].ToString() == "6Axis")
                                equipStateIndicator.icon = Properties.Resources._6axis;
                            else if (dr["EQTYPE"].ToString() == "Scara")
                                equipStateIndicator.icon = Properties.Resources._1;
                            else
                                equipStateIndicator.icon = Properties.Resources.PMCRobot;
                            equipStateIndicator.subidVisible = false;
                            equipStateIndicator.moidVisible = false;
                            equipStateIndicator.opidVisible = false;
                        }
                        equipFlowLayout.Controls.Add(equipStateIndicator);
                    }
                }
                dr.Close();
                sqlCon.Close();
            }
            catch (SqlException ex)
            {
                Console.Write("loadStockStatus SqlException：");
                Console.WriteLine(ex.Number);
            }
        }


        //update status
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection("Data Source=" + sqlLink.server + ";Initial Catalog=" + sqlLink.db + ";Persist Security Info=True;User ID=" + sqlLink.user + ";Password=" + sqlLink.pw);
                sqlCon.Open();
                string getStkStatus = "SELECT EQUIPID FROM EQUIPMENT ORDER BY EQUIPID";

                SqlCommand cmdRead = new SqlCommand(getStkStatus, sqlCon);
                SqlDataReader dr = cmdRead.ExecuteReader();
                while (dr.Read())
                {
                    if (!dr[0].Equals(DBNull.Value))
                    {
                        if (dr["EQUIPID"].ToString().Contains("VMC"))
                        {
                            string[] eqInfo = new string[4];
                            iCAP.getEqWorkInfo(ref eqInfo, dr["EQUIPID"].ToString());
                            (equipFlowLayout.Controls[dr["EQUIPID"].ToString()] as equipStateIndicator).subid = eqInfo[0];
                            (equipFlowLayout.Controls[dr["EQUIPID"].ToString()] as equipStateIndicator).opid = eqInfo[1];
                            (equipFlowLayout.Controls[dr["EQUIPID"].ToString()] as equipStateIndicator).moid = eqInfo[2];
                            (equipFlowLayout.Controls[dr["EQUIPID"].ToString()] as equipStateIndicator).palletNo = eqInfo[3];

                            updateStatus(dr["EQUIPID"].ToString());

                            //VMC00001
                            if (iCAP.getEquipStatus(dr["EQUIPID"].ToString()) == 0)
                            {
                                (equipFlowLayout.Controls[dr["EQUIPID"].ToString()] as equipStateIndicator).statusColor = Color.FromArgb(0, 191, 165);
                                (equipFlowLayout.Controls[dr["EQUIPID"].ToString()] as equipStateIndicator).status = "IDEL";

                                if (alarmSignal_CNC)
                                {
                                    alarmSignal_CNC = false;
                                }
                            }
                            else if (iCAP.getEquipStatus(dr["EQUIPID"].ToString()) == 1)
                            {
                                (equipFlowLayout.Controls[dr["EQUIPID"].ToString()] as equipStateIndicator).statusColor = Color.FromArgb(249, 168, 37);
                                (equipFlowLayout.Controls[dr["EQUIPID"].ToString()] as equipStateIndicator).status = "BUSY";
                            }
                            else
                            {
                                (equipFlowLayout.Controls[dr["EQUIPID"].ToString()] as equipStateIndicator).statusColor = Color.FromArgb(198, 40, 40);
                                (equipFlowLayout.Controls[dr["EQUIPID"].ToString()] as equipStateIndicator).status = "ALARM";

                                if (!alarmSignal_CNC)
                                {
                                    alarmSignal_CNC = true;
                                    //hachunGroup.pushNotify("CNC Alarm", "");
                                }
                            }
                        }

                        else if (dr["EQUIPID"].ToString().Contains("AGV"))
                        {
                            updateStatusAGV(dr["EQUIPID"].ToString());
                            updateWorkingInfo(dr["EQUIPID"].ToString(), ref alarmSignal_AGV);
                        }

                        else if (dr["EQUIPID"].ToString().Contains("RBA"))
                        {
                            updateStatus(dr["EQUIPID"].ToString());
                            updateWorkingInfo(dr["EQUIPID"].ToString(), ref alarmSignal_RBA);
                        }
                    }
                }
                dr.Close();
                sqlCon.Close();
            }
            catch (SqlException ex)
            {
                Console.Write("loadStockStatus SqlException：");
                Console.WriteLine(ex.Number);
            }
        }

        private void updateStatus(string eqid)
        {
            string[] eqInfoList = new string[2];
            iCAP.getEqInfo(ref eqInfoList, eqid, "MODE", "LINKSTATUS");

            switch (eqInfoList[0])
            {
                case "0":
                    (equipFlowLayout.Controls[eqid.ToString()] as equipStateIndicator).mode = "remote";
                    (equipFlowLayout.Controls[eqid.ToString()] as equipStateIndicator).modeColor = System.Drawing.Color.LimeGreen;
                    break;

                case "1":
                    (equipFlowLayout.Controls[eqid.ToString()] as equipStateIndicator).mode = "manual";
                    (equipFlowLayout.Controls[eqid.ToString()] as equipStateIndicator).modeColor = System.Drawing.Color.Salmon;
                    break;
            }

            switch (eqInfoList[1])
            {
                case "0":
                    (equipFlowLayout.Controls[eqid.ToString()] as equipStateIndicator).linkStatus = "offline";
                    (equipFlowLayout.Controls[eqid.ToString()] as equipStateIndicator).linkStatusColor = System.Drawing.Color.Brown;
                    break;

                case "1":
                    (equipFlowLayout.Controls[eqid.ToString()] as equipStateIndicator).linkStatus = "online";
                    (equipFlowLayout.Controls[eqid.ToString()] as equipStateIndicator).linkStatusColor = System.Drawing.Color.SeaGreen;
                    break;
            }
        }

        private void updateStatusAGV(string eqid)
        {
            string[] eqInfoList = new string[4];
            iCAP.getEqInfo(ref eqInfoList, eqid, "MODE", "LINKSTATUS");

            (equipFlowLayout.Controls[eqid.ToString()] as equipStateIndicator).mode = "位置："+ eqInfoList[0];
            (equipFlowLayout.Controls[eqid.ToString()] as equipStateIndicator).modeColor = System.Drawing.Color.LimeGreen;

            switch (eqInfoList[1])
            {
                case "0":
                    (equipFlowLayout.Controls[eqid.ToString()] as equipStateIndicator).linkStatus = "offline";
                    (equipFlowLayout.Controls[eqid.ToString()] as equipStateIndicator).linkStatusColor = System.Drawing.Color.Brown;
                    break;

                case "1":
                    (equipFlowLayout.Controls[eqid.ToString()] as equipStateIndicator).linkStatus = "online";
                    (equipFlowLayout.Controls[eqid.ToString()] as equipStateIndicator).linkStatusColor = System.Drawing.Color.SeaGreen;
                    break;
            }

            //(this.Controls["mission" + eqid.ToString()] as Label).Text = eqInfoList[2];
            //(this.Controls["pn" + eqid.ToString()] as Label).Text = eqInfoList[3];

        }

        private void updateWorkingInfo(string eqid, ref bool alarmSignal)
        {
            if (iCAP.getEquipStatus(eqid) == 0)
            {
                (equipFlowLayout.Controls[eqid.ToString()] as equipStateIndicator).status = "IDLE";
                (equipFlowLayout.Controls[eqid.ToString()] as equipStateIndicator).statusColor = Color.FromArgb(0, 191, 165);
                (equipFlowLayout.Controls[eqid.ToString()] as equipStateIndicator).mission = "";
                (equipFlowLayout.Controls[eqid.ToString()] as equipStateIndicator).palletNo = "";

                if (alarmSignal)
                {
                    alarmSignal = false;
                }
            }
            else if (iCAP.getEquipStatus(eqid) == 1)
            {
                (equipFlowLayout.Controls[eqid.ToString()] as equipStateIndicator).status = "Busy";
                (equipFlowLayout.Controls[eqid.ToString()] as equipStateIndicator).statusColor = Color.FromArgb(249, 168, 37);

                string[] InfoList = new string[3];
                iCAP.getEqInfo(ref InfoList, eqid, "PALLETNO", "MISSION");

                (equipFlowLayout.Controls[eqid.ToString()] as equipStateIndicator).palletNo = InfoList[0];
                (equipFlowLayout.Controls[eqid.ToString()] as equipStateIndicator).mission = InfoList[1];
            }
            else
            {
                (equipFlowLayout.Controls[eqid.ToString()] as equipStateIndicator).status = "ALARM";
                (equipFlowLayout.Controls[eqid.ToString()] as equipStateIndicator).statusColor = Color.FromArgb(198, 40, 40);

                if (!alarmSignal)
                {
                    alarmSignal = true;
                    //hachunGroup.pushNotify(eqid + "Alarm", "");
                }
            }
        }

        private void eq_click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            globalVar.activeEquipment = pb.Name.Substring(2);

            machineInfo machineInfo = new machineInfo();
            machineInfo.StartPosition = FormStartPosition.CenterParent;
            machineInfo.ShowDialog(this);
        }

        protected void equip_Click(object sender, EventArgs e)
        {
            equipStateIndicator pb = (equipStateIndicator)sender;
            globalVar.activeEquipment = pb.Name;

            machineInfo machineInfo = new machineInfo();
            machineInfo.StartPosition = FormStartPosition.CenterParent;
            machineInfo.ShowDialog(this);
        }
    }
}
