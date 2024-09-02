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
    public partial class newOverview : Form
    {
        private bool allowEdit = false;
        private Form1 _parentForm;
        public static string IniPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configurations/devices.ini");
        public static string ImgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/Devices/");

        public newOverview(Form1 form = null)
        {
            if (form != null) _parentForm = form;

            InitializeComponent();

            DeviceRecord(deviceInfoView1);
            DeviceRecord(deviceInfoView2);
            DeviceRecord(deviceInfoView3);
            DeviceRecord(deviceInfoView4);
            //DeviceRecord(deviceInfoView5);
            DeviceRecord(deviceInfoView6);

            deviceInfoView1.TaskControl(new Carousel_8_box() { Dwh_registers = "D1313" });
            deviceInfoView2.TaskControl(new Carousel_8_box() { Dwh_registers = "D1313" });
            deviceInfoView3.TaskControl(new Carousel_8_box() { Dwh_registers = "D1313" });
            deviceInfoView4.TaskControl(new Carousel_8_box() { Dwh_registers = "D1313" });
            //deviceInfoView5.TaskControl(new Carousel_8_box() { Dwh_registers = "D1313" });
            deviceInfoView6.TaskControl(new Carousel_8_box() { Dwh_registers = "D1313" });

            deviceInfoView1.BaseIOs = new string[2] { "D1010", "D1011" };
            deviceInfoView2.BaseIOs = new string[2] { "D1060", "D1061" };
            deviceInfoView3.BaseIOs = new string[2] { "D1210", "D1211" };
            deviceInfoView4.BaseIOs = new string[2] { "D1260", "D1261" };
            //deviceInfoView5.BaseIOs = new string[2] { "D1310", "D1311" };
            deviceInfoView6.BaseIOs = new string[2] { "D1367", "D1368" };

            //deviceInfoView6.IntervalMin = 0;        // AGV 不發警報


        }

        /// <summary>
        /// 回復紀錄資訊
        /// </summary>
        /// <param name="infoView"></param>
        private void DeviceRecord(deviceInfoView infoView)
        {
            string strflows = INiReader.ReadINIFile(IniPath, (string)infoView.Tag, "Flows").Replace("\\n", "\n"); ;
            string[] flows = strflows.Split(';');
            string imgPath = INiReader.ReadINIFile(IniPath, (string)infoView.Tag, "ImagePath");
            string deviceName = INiReader.ReadINIFile(IniPath, (string)infoView.Tag, "Name");
            int speedR = int.Parse(INiReader.ReadINIFile(IniPath, (string)infoView.Tag, "SpeedBarR"));
            int speedY = int.Parse(INiReader.ReadINIFile(IniPath, (string)infoView.Tag, "SpeedBarY"));
            string strtags = INiReader.ReadINIFile(IniPath, (string)infoView.Tag, "tags").Replace("\\n", "\n"); ;
            string[] tags = strtags.Split(',');
            string start_d = INiReader.ReadINIFile(IniPath, (string)infoView.Tag, "start_reg").Replace("\\n", "\n"); ;

            infoView.LoadData(flows, imgPath, deviceName, speedR, speedY);

            infoView.TaskControl(new Carousel_8_box() { Dwh_registers = start_d, Set_tag = tags });
            infoView.moveFlowDot(1);
            infoView.ActiveStateRead();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            deviceInfoView1.moveFlowDot(int.Parse((sender as Button).Text));
        }
    }
}
