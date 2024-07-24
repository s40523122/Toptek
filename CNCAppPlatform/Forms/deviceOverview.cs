using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNCAppPlatform
{
    public partial class deviceOverview : Form
    {
        private bool allowEdit = false;
        private Form1 _parentForm;
        public static string IniPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configurations/devices.ini");
        public static string ImgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/Devices/");

        public deviceOverview(Form1 form = null)
        {
            if (form != null) _parentForm = form;

            InitializeComponent();

            DeviceRecord(deviceInfoView1);
            DeviceRecord(deviceInfoView2);
            DeviceRecord(deviceInfoView3);
            DeviceRecord(deviceInfoView4);
            DeviceRecord(deviceInfoView5);
            DeviceRecord(deviceInfoView6);

            deviceInfoView1.TaskControl(new TS0082_1() { D_registers = new string[] { "D1000", "D1001", "D1002" } });
            deviceInfoView2.TaskControl(new TS0082_2() { D_registers = new string[] { "D1050", "D1051" } });
            deviceInfoView3.TaskControl(new TS0082_3() { D_registers = new string[] { "D1200", "D1201", "D1202", "D1203" } });
            deviceInfoView4.TaskControl(new TR1844() { D_registers = new string[] { "D1250" } });
            deviceInfoView5.TaskControl(new TS0131()
            {
                D_registers = new string[] { "D1300", "D1301", "D1302", "D1303", "D1325", "D1326" },
                Dwh_registers = new string[] { "D1313", "D1314", "D1315", "D1316", "D1317", "D1318", "D1319", "D1320", "D1321", "D1322", "D1323", "D1324" }
            });
            deviceInfoView6.TaskControl(new Agv() { D_registers = new string[] { "D1360" } });

            deviceInfoView1.BaseIOs = new string[2] { "D1010", "D1011" };
            deviceInfoView2.BaseIOs = new string[2] { "D1060", "D1061" };
            deviceInfoView3.BaseIOs = new string[2] { "D1210", "D1211" };
            deviceInfoView4.BaseIOs = new string[2] { "D1260", "D1261" };
            deviceInfoView5.BaseIOs = new string[2] { "D1310", "D1311" };
            deviceInfoView6.BaseIOs = new string[2] { "D1367", "D1368" };

            //deviceInfoView6.IntervalMin = 0;        // AGV 不發警報


        }

        private void DeviceRecord(deviceInfoView infoView)
        {
            string strflows = INiReader.ReadINIFile(IniPath, (string)infoView.Tag, "Flows").Replace("\\n", "\n"); ;
            string[] flows = strflows.Split(';');
            string imgPath = INiReader.ReadINIFile(IniPath, (string)infoView.Tag, "ImagePath");
            string deviceName = INiReader.ReadINIFile(IniPath, (string)infoView.Tag, "Name");
            int speedR = int.Parse(INiReader.ReadINIFile(IniPath, (string)infoView.Tag, "SpeedBarR"));
            int speedY = int.Parse(INiReader.ReadINIFile(IniPath, (string)infoView.Tag, "SpeedBarY"));
            infoView.LoadData(flows, imgPath, deviceName, speedR, speedY);
            infoView.moveFlowDot(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            deviceInfoView1.moveFlowDot(int.Parse((sender as Button).Text));
        }
    }
}
