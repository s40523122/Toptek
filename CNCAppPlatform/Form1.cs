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
using System.Diagnostics;
using ActUtlTypeLib;

namespace CNCAppPlatform
{ 
   
    public partial class Form1 : Form
    {
        //private const int CS_DropShadow = 0x00020000;

        public static ActUtlType axActUtlType = new ActUtlType();       // PLC
        public static string path = Application.StartupPath;

        /// <summary>
        /// 連線狀態文字
        /// </summary>
        public string ConnectStatus
        {
            get { return connStatusLabel.Text; }
            set { connStatusLabel.Text = value; }
        }

        public Form1()
        {
            InitializeComponent();

            // 返回主頁
            btnHome.Click += btnHome_Click;

            // 設定 Line Notify
            JinToolkit.Services.LineNotify.connectToken = "4cNqk5otAwItnPkpeNvJKNsRylhrsndmFfAIiztJ4QU";

            // Debug 模式下，開放視窗縮放功能。反之，視窗為全螢幕。
            if (Debugger.IsAttached)
            {
                btnFormControl.Visible = true;
                btnFormControl.Click += BtnFormControl_Click;
            }
            else WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// 視窗縮放 (點擊事件)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFormControl_Click(object sender, EventArgs e)
        {
            if (btnFormControl.Change) WindowState = FormWindowState.Normal;
            else WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// 關閉程式 (點擊事件)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btPower_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region Navibar
        private const int SW_NORMAL = 1;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr handle);

        private IntPtr handle;

        /// <summary>
        /// 返回主頁 (點擊事件)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHome_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            Process[] processName = Process.GetProcessesByName("iCAPS");
            var p = System.Diagnostics.Process.GetProcessesByName("iCAPS").FirstOrDefault();
            ShowWindow(p.MainWindowHandle, SW_NORMAL);
            handle = processName[0].MainWindowHandle;
            SetForegroundWindow(handle);
        }

        /// <summary>
        /// 工單歷程 (點擊事件)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOrderLog_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            btnColor(button);
            if (!(button.Tag is Form))
            {
                OrderLog frame = new OrderLog()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false,
                    Parent = panel1,
                    FormBorderStyle = FormBorderStyle.None
                };

                button.Tag = frame;
            }

            Tag = button.Tag;

            (button.Tag as Form).Show();

            moduleTitle.Text = button.Text.Trim();
        }

        /// <summary>
        /// 設備總覽 (點擊事件)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeviceOverall_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            btnColor(button);
            if (!(button.Tag is Form))
            {
                Overview_V2 frame = new Overview_V2()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false,
                    Parent = panel1,
                    FormBorderStyle = FormBorderStyle.None
                };

                button.Tag = frame;
            }

            Tag = button.Tag;
            (button.Tag as Form).Show();
            (button.Tag as Overview_V2).Import_config();

            moduleTitle.Text = button.Text.Trim();
        }

        /// <summary>
        /// PLC 連線設定 (點擊事件)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlcSetting_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            btnColor(button);
            if (!(button.Tag is Form))
            {
                PlcConn plcConn = new PlcConn()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false,
                    Parent = panel1,
                    FormBorderStyle = FormBorderStyle.None
                };

                button.Tag = plcConn;
            }

            Tag = button.Tag;
            (button.Tag as Form).Show();

            moduleTitle.Text = button.Text.Trim();
        }

        /// <summary>
        /// PLC 讀寫測試 (點擊事件)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlcTest_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            btnColor(button);
            if (!(button.Tag is Form))
            {
                PlcControl plcControl = new PlcControl()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false,
                    Parent = panel1,
                    FormBorderStyle = FormBorderStyle.None
                };

                button.Tag = plcControl;
            }

            Tag = button.Tag;
            (button.Tag as Form).Show();

            moduleTitle.Text = button.Text.Trim();
        }

        /// <summary>
        /// 設定 (點擊事件)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetting_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            btnColor(button);
            if (!(button.Tag is Form))
            {
                Setting plcControl = new Setting()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false,
                    Parent = panel1,
                    FormBorderStyle = FormBorderStyle.None
                };

                button.Tag = plcControl;
            }

            Tag = button.Tag;
            (button.Tag as Form).Show();

            moduleTitle.Text = button.Text.Trim();
        }

        /// <summary>
        /// 按鈕選中後渲染
        /// </summary>
        /// <param name="btn"></param>
        private void btnColor(Button btn)
        {
            Button[] tbtn = new Button[] { btnPlcSetting, btnOrderLog, btnDeviceOverView, btnSetting, btnPlcTest };
            btn.BackColor = Color.DodgerBlue;
            slidePanel.Top = btn.Top + 114;
            slidePanel.Visible = true;
            foreach (var item in tbtn)
            {
                if (item.Name == btn.Name) continue;
                item.BackColor = Color.SteelBlue;
            }
            if (Tag is Form) (Tag as Form).Hide();
        }
        #endregion

        private void info_Click(object sender, EventArgs e)
        {
            //LineNotify hachunGroup = new LineNotify("ZZkOh8kZn3QLj9hGmy8lfWygcTCekFl1wBbPlavR2LX");
            //hachunGroup.pushNotify("Test", "");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //machineState1.timer1.Enabled = true;
        }
    }

}
