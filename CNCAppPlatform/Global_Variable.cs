using CNCAppPlatform.APS;
using CNCAppPlatform.Controls;
using LiveCharts;
using Messages.rock_publisher;
using Renci.SshNet.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNCAppPlatform
{
    internal class Global_Variable
    {
        public static List<Job> raw_jobs {  get; set; } = new List<Job>();

        public static List<iDevice> Devices { get; set; } = new List<iDevice> { };

        public static string IniPath = Path.Combine(Form1.path, "Configurations/devices.ini");
        public static string ImgPath = Path.Combine(Form1.path, "Images\\Devices\\");

    }

    public class iDevice
    {
        private string _device_name;
        private string _reg_sequence;
        private string _reg_availability;
        private string _enable_line_notify;
        private int _update_rate;
        private Image _device_image;
        private List<string> _sequence_list;
        private string _reg_param_start;
        private string[] _param_labels;


        // Ini 資料
        public string IniSection {  get; set; }

        // 設備名稱
        public string DeviceName
        {
            get => _device_name;
            set
            {
                if (_device_name == value) return;
                _device_name = value;

                INiReader.WriteINIFile(Global_Variable.IniPath, IniSection, "device_name", value);

                foreach (Control ctrl in BindControls)
                {
                    switch (ctrl)
                    {
                        case deviceInfoConstrict dic:
                            dic.UpdateInfo(DeviceName, DeviceImage);
                            break;
                        case deviceInfoView_V2 div2:
                            div2.Import_Param_Data(DeviceName, DeviceImage, ParamLabels, SequenceList.ToArray());
                            break;
                    }
                }
            }
        }

        // 加工次序讀取 D 值
        public string RegSequence
        {
            get => _reg_sequence;
            set
            {
                if (_reg_sequence == value) return;
                _reg_sequence = value;

                INiReader.WriteINIFile(Global_Variable.IniPath, IniSection, "reg_sequence", value);
            }
        }

        // 設備可用性狀態
        public string RegAvailability
        {
            get => _reg_availability;
            set
            {
                if (_reg_availability == value) return;
                _reg_availability = value;

                INiReader.WriteINIFile(Global_Variable.IniPath, IniSection, "reg_availability", value);
            }
        }

        // 是否啟用 Line Notify 通知
        public string EnableLineNotify
        {
            get => _enable_line_notify;
            set
            {
                if (_enable_line_notify == value) return;
                _enable_line_notify = value;

                INiReader.WriteINIFile(Global_Variable.IniPath, IniSection, "enable_line_notify", value);
            }
        }

        // 更新頻率（單位：毫秒）
        public int UpdateRate
        {
            get => _update_rate;
            set
            {
                if (_update_rate == value) return;
                _update_rate = value;

                INiReader.WriteINIFile(Global_Variable.IniPath, IniSection, "update_rate", value.ToString());
            }
        }

        // 設備對應的圖片
        public Image DeviceImage
        {
            get => _device_image;
            set
            {
                _device_image = value;

                // 將圖片儲存到指定的資料夾中
                string savePath = Path.Combine(Global_Variable.ImgPath, $"{IniSection}.png");

                // 將圖片轉換為 Bitmap，這有時可以解決 GDI+ 錯誤
                Bitmap bitmap = new Bitmap(value);

                // 儲存圖片，這裡以 PNG 格式為例
                bitmap.Save(savePath, System.Drawing.Imaging.ImageFormat.Png);

                INiReader.WriteINIFile(Global_Variable.IniPath, IniSection, "device_img", $"{IniSection}.png");

                foreach (Control ctrl in BindControls)
                {
                    switch (ctrl)
                    {
                        case deviceInfoConstrict dic:
                            dic.UpdateInfo(DeviceName, DeviceImage);
                            break;
                        case deviceInfoView_V2 div2:
                            div2.Import_Param_Data(DeviceName, DeviceImage, ParamLabels, SequenceList.ToArray());
                            break;
                    }
                }
            }
        }

        // 參數序列清單
        public List<string> SequenceList
        {
            get => _sequence_list;
            set
            {
                if (_sequence_list == value) return;
                _sequence_list = value;

                INiReader.WriteINIFile(Global_Variable.IniPath, IniSection, "sequence_list", String.Join(";", value));
            }
        }

        // 註冊參數起始位址
        public string RegParamStart
        {
            get => _reg_param_start;
            set
            {
                if (_reg_param_start == value) return;
                _reg_param_start = value;

                INiReader.WriteINIFile(Global_Variable.IniPath, IniSection, "param_start_reg", value);
            }
        }

        // 參數標籤陣列
        public string[] ParamLabels
        {
            get => _param_labels;
            set
            {
                if (_param_labels == value) return;
                _param_labels = value;

                INiReader.WriteINIFile(Global_Variable.IniPath, IniSection, "param_labels", String.Join(";", value));
            }
        }



        // 動態
        public List<Control> BindControls { get; set; } = new List<Control> ();
        public int Availability { get; set; } = 0;
        public int[] ParamValues { get; set; } = new int[24];

        public iDevice(string device_section)
        {
            IniSection = device_section;

            Dictionary<string, string> ini_data = INiReader.ReadSection(Global_Variable.IniPath, device_section);
            DeviceName = ini_data["device_name"];
            Image img = GetFormFile(ini_data["device_img"]);
            DeviceImage = img;
            RegSequence = ini_data["reg_sequence"];
            RegAvailability = ini_data["reg_availability"];
            EnableLineNotify = ini_data["enable_line_notify"];
            UpdateRate = int.Parse(ini_data["update_rate"]);
            SequenceList = ini_data["sequence_list"].Split(';').ToList();
            RegParamStart = ini_data["param_start_reg"];
            ParamLabels = ini_data["param_labels"].Split(';');
        }

        public void AddControl(Control ctrl)
        {
            BindControls.Add(ctrl);
            UpdateControls();       // 更新綁定控制項
        }

        private Image GetFormFile(string file_path)
        {
            //// 解決圖片占用問題
            //FileStream fs = File.OpenRead(Path.Combine(Global_Variable.ImgPath, file_path));
            //int filelength = (int)fs.Length; // 獲得檔長度
            //byte[] image = new byte[filelength]; // 建立位元組陣列
            //fs.Read(image, 0, filelength); // 按位元組流讀取

            //// 重設 FileStream 游標到檔案開頭
            //fs.Seek(0, SeekOrigin.Begin);

            //// 從 FileStream 創建 Image 物件
            //Image result = Image.FromStream(fs);

            //fs.Close();
            //return result;

            string filePath = Path.Combine(Global_Variable.ImgPath, file_path);
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                Image image = Image.FromStream(fs);
                return image;
            }
        }

        private void UpdateControls()
        {
            foreach(Control ctrl in BindControls)
            {
                switch (ctrl.GetType().Name)
                {
                    case "deviceInfoConstrict":
                        (ctrl as deviceInfoConstrict).Config_input(this);
                        (ctrl as deviceInfoConstrict).UpdateInfo(DeviceName, DeviceImage);
                        break;
                    case "deviceInfoView_V2":
                        (ctrl as deviceInfoView_V2).Import_Param_Data(DeviceName, DeviceImage, ParamLabels, SequenceList.ToArray());
                        break;
                }

                Console.WriteLine(nameof(ctrl));
            }
        }

    }
   

}
