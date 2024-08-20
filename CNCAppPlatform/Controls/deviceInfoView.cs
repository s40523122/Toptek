using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;

namespace CNCAppPlatform
{
    public partial class deviceInfoView : UserControl
    {
        [Description("Line Notify 發布間隔分鐘數。(可為小數，若值為 0 則不發布)"), Category("自訂值")]
        public double IntervalMin { get; set; } = Debugger.IsAttached? 1000 : 10;

        string activation_D_register = "D0";
        public string[] BaseIOs     // 啟動狀態, 料台動作狀態
        {
            set
            {
                flowView1.D_register = (value as string[])[1];
                activation_D_register = (value as string[])[0];
            }       
        }

        public deviceInfoView()
        {
            InitializeComponent();

            deviceImg.Click += DeviceImg_Click;
            DeviceNamelabel.Click += DeviceName_Click;
            LabelFlow.Click += LabelFlow_Click;
            panelFlow.Click += LabelFlow_Click;
            speedBar1.Click += SpeedBar1_Click;

            SizeChanged += DeviceInfoView_SizeChanged;
        }

        private DateTime _lineNotifyrecordTime = DateTime.Now;
        // 設定 Line Notify 通知
        public void setLineNotify()
        {
            if (IntervalMin == 0) return;

            // 如果目前百分比低於警告值，且離上一次警報超過指定時間(intervalMin)，觸發 Line Notify 傳送通知。
            if (speedBar1.NowPercentage >= speedBar1.PercentageWarn) return;
            if ((DateTime.Now - _lineNotifyrecordTime).TotalMinutes <= IntervalMin) return;
            _lineNotifyrecordTime = DateTime.Now;
            JinToolkit.Services.LineNotify.send2LineNotify($"{DeviceNamelabel.Text} : 稼動率低於設定警告值 ({speedBar1.PercentageWarn} %)");            
        }

        public void TaskControl(Control control)
        {
            panelTask.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }

        private void SpeedBar1_Click(object sender, EventArgs e)
        {
            if (labelR.Visible)
            {
                labelR.Visible = labelY.Visible = false;
                textBoxR.Visible = textBoxY.Visible = false;
                speedBar1.PercentageSafe = int.Parse(textBoxR.Text);
                speedBar1.PercentageWarn = int.Parse(textBoxY.Text);
                INiReader.WriteINIFile(deviceOverview.IniPath, (string)Tag, "SpeedBarR", textBoxR.Text);
                INiReader.WriteINIFile(deviceOverview.IniPath, (string)Tag, "SpeedBarY", textBoxY.Text);
            }
            else
            {
                labelR.Visible = labelY.Visible = true;
                textBoxR.Visible = textBoxY.Visible = true;
                textBoxR.Text = INiReader.ReadINIFile(deviceOverview.IniPath, (string)Tag, "SpeedBarR");
                textBoxY.Text = INiReader.ReadINIFile(deviceOverview.IniPath, (string)Tag, "SpeedBarY");
            }
        }

        private void LabelFlow_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Visible == false)
            {
                richTextBox1.Visible = true;
                richTextBox1.Text = INiReader.ReadINIFile(deviceOverview.IniPath, (string)Tag, "Flows");
            }
            else
            {
                richTextBox1.Visible = false;
                string[] flows = richTextBox1.Text.Replace("\\n", "\n").Split(';');
                flowView1.AddRange(flows);
                flowView1.moveDot(1);
                INiReader.WriteINIFile(deviceOverview.IniPath, (string)Tag, "Flows", richTextBox1.Text);
            }
        }

        public void flowAddRange(string[] flows)
        {
            flowView1.AddRange(flows);
            string originalString = string.Join(";", flows);
            string replacedString = originalString.Replace("\n", "\\n");
            INiReader.WriteINIFile(deviceOverview.IniPath, (string)Tag, "Flows", replacedString);
        }

        public void moveFlowDot(int dotID)
        {
            flowView1.moveDot(dotID);
        }

        public void LoadData(string[] flows, string imagePath, string name, int speedR, int speedY)
        {
            try { deviceImg.BackgroundImage = Image.FromFile(imagePath); }
            catch { }
            flowView1.AddRange(flows);
            DeviceNamelabel.Text = name;
            speedBar1.PercentageSafe = speedR;
            speedBar1.PercentageWarn = speedY;
        }

        private void DeviceName_Click(object sender, EventArgs e)
        {
            if (tBoxDeviceName.Visible == false)
            {
                tBoxDeviceName.Visible = true;
                tBoxDeviceName.Text = INiReader.ReadINIFile(deviceOverview.IniPath, (string)Tag, "Name");
            }
            else
            {
                tBoxDeviceName.Visible = false;
                DeviceNamelabel.Text = tBoxDeviceName.Text;
                INiReader.WriteINIFile(deviceOverview.IniPath, (string)Tag, "Name", tBoxDeviceName.Text);
            }
            
        }

        private void DeviceInfoView_SizeChanged(object sender, EventArgs e)
        {
            // 計算字體高度為 Label 高度的 80%
            float fontHeight = DeviceNamelabel.Height * 0.3f;

            // 創建新的字體對象，將字體高度設置為計算出的值
            Font newFont = new Font(DeviceNamelabel.Font.FontFamily, fontHeight, DeviceNamelabel.Font.Style);

            // 設置 Label 的字體為新的字體
            DeviceNamelabel.Font = newFont;
            tBoxDeviceName.Font = newFont;
        }

        private void DeviceImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog1.Title = "選擇一張圖片";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 讀取所選圖片
                    Image selectedImage = Image.FromFile(openFileDialog1.FileName);
                    deviceImg.BackgroundImage.Dispose();
                    // 設置為 Panel 的背景圖片
                    deviceImg.BackgroundImage = selectedImage;

                    // 取得所選檔案的檔名
                    string fileName = Path.GetFileName(openFileDialog1.FileName);

                    // 將圖片儲存到指定的資料夾中
                    string savePath = Path.Combine(deviceOverview.ImgPath, (string)Tag + ".png");

                    selectedImage.Save(savePath);

                    INiReader.WriteINIFile(deviceOverview.IniPath, (string)Tag, "ImagePath", savePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("錯誤：無法載入圖片。" + ex.Message);
                }
            }
        }

        private DateTime? startTime = null;
        private DateTime? lastStatusChangeTime = null; // 記錄上一次狀態變化的時間
        private TimeSpan totalRunningTime = TimeSpan.Zero; // 累積運行時間
        private bool isRunning = false; // 機台當前是否在運行

        public int operationRateFn(int status)
        {
            if (status != 0 && status != 1)
            {
                Console.WriteLine("無效值");
            }

            DateTime currentTime = DateTime.Now;
            if (startTime == null)
            {
                startTime = currentTime; // 第一次更新狀態時設置啟動時間
            }

            if (lastStatusChangeTime != null && isRunning)
            {
                // 如果之前處於運行狀態，更新累積運行時間
                totalRunningTime += currentTime - lastStatusChangeTime.Value;
            }

            // 更新最後狀態變化時間和運行狀態
            lastStatusChangeTime = currentTime;
            isRunning = (status == 1);

            //GetOperationRate();
            //label1.Text = GetOperationRate().ToString();

            if (startTime == null)
            {
                return 0; // 如果機台從未啟動過，稼動率為0
            }

            TimeSpan possibleRunningTime = DateTime.Now - startTime.Value;
            if (isRunning)
            {
                // 如果機台目前仍在運行，需要將當前運行段也計算在內
                possibleRunningTime += DateTime.Now - lastStatusChangeTime.Value;
            }

            double operationRate = (totalRunningTime.TotalSeconds / possibleRunningTime.TotalSeconds) * 100;

            return (int)operationRate < 0 ? 0 : (int)operationRate;
        }

        public void ActiveStateRead()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000; // 設置計時器間隔為 1000 毫秒 (1 秒)
            timer.Elapsed += Active_Timer_Elapsed;
            timer.Start();
        }
         
        private void Active_Timer_Elapsed(object sender, EventArgs e)
        {
            int no = 1;
            short[] arraydata;
            arraydata = new short[no];

            flowView1.PlcRead();

            _ = Form1.axActUtlType.ReadDeviceBlock2(activation_D_register, no, out arraydata[0]);

            Invoke(new MethodInvoker(delegate
            {
                speedBar1.NowPercentage = operationRateFn(arraydata[0]);
                setLineNotify();
            }));
        }
    }
}
