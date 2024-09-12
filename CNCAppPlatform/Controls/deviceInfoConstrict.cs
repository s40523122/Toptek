using Messages.dynamic_reconfigure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNCAppPlatform.Controls
{
    public partial class deviceInfoConstrict : UserControl
    {
        
        public Image DeviceImg
        {
            get
            {
                return pictureBox1.Image;
            }
            set
            {
                pictureBox1.Image = value;
                Refresh();
            }
        }



        private string _deviceName = "";
        public string DeviceName
        {
            get
            {
                return _deviceName;
            }
            set
            {
                _deviceName = value;
                Refresh();
            }
        }

        [Description("設備圖片。"), Category("自訂值")]
        public string ID { set; get; }

        string IniPath = Path.Combine(Form1.path, "Configurations/devices.ini");
        string ImgPath = Path.Combine(Form1.path, "Images/Devices/");

        public deviceInfoConstrict()
        {
            InitializeComponent();
            InitializeDataGridView();


            if (DeviceImg == null) DeviceImg = pictureBox1.Image;
            //Height = button1.Height;

            SizeChanged += DeviceInfoConstrict_SizeChanged;
            Load += DeviceInfoConstrict_Load;
        }

        private void DeviceInfoConstrict_Load(object sender, EventArgs e)
        {
            Config_input();
        }

        private void DeviceInfoConstrict_SizeChanged(object sender, EventArgs e)
        {
            if (!doubleImg1.Change) button1.Height = Height;
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;

            // 加載圖片
            Image imgLeft = DeviceImg; // 左邊的圖片
            Image imgRight = doubleImg1.Image; // 右邊的圖片

            // 設置圖片位置
            int imageHeight = (int)(button1.Height * 0.8); // 假設圖片寬度為16像素
            
            //int imageHeight = 16; // 假設圖片高度為16像素
            int padding = 5; // 圖片與文字之間的間距

            Rectangle imgLeftRect = new Rectangle(padding*5, (button.Height - imageHeight) / 2, imageHeight, imageHeight);
            Rectangle imgRightRect = new Rectangle(button.Width - imageHeight/3 - padding*3, (button.Height - imageHeight/3) / 2, imageHeight/3, imageHeight/3);

            // 繪製左邊的圖片
            e.Graphics.DrawImage(imgLeft, imgLeftRect);

            // 繪製右邊的圖片
            e.Graphics.DrawImage(imgRight, imgRightRect);

            // 繪製文字
            string buttonText = DeviceName;
            Font font = new Font(button.Font.FontFamily, imageHeight / 4);
            SizeF textSize = e.Graphics.MeasureString(buttonText, font);
            PointF textLocation = new PointF(imageHeight + padding * 7, (button.Height - textSize.Height) / 2);

            e.Graphics.DrawString(buttonText, font, Brushes.Black, textLocation);
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            doubleImg1.Change = !doubleImg1.Change;
            if (doubleImg1.Change) Height *= 5;
            else Height /= 5;
        }

        class cell_config
        {
            public string config_name { get; set; }
            public string display_text { get; set; }
            public string value { get; set; }
            public string cell_mode { get; set; }
        }

        private void InitializeDataGridView()
        {
            // 設置 DataGridView 的基本屬性
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = true;

            // 確保樣式更改被應用
            dataGridView1.Refresh();

            // 將所有行的高度設置為 30 像素
            dataGridView1.RowTemplate.Height = 30;

            // 添加描述列和值列
            dataGridView1.Columns.Add("Description", "描述");

            // 添加按鈕列
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "Value";
            buttonColumn.HeaderText = "值";
            buttonColumn.Text = "Click";
            buttonColumn.UseColumnTextForButtonValue = false;  // 不使用固定文字
            dataGridView1.Columns.Add(buttonColumn);

            // 設置描述列為唯讀
            dataGridView1.Columns["Description"].ReadOnly = true;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[0].FillWeight = 6;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].FillWeight = 4;

            // 綁定 CellClick 事件
            dataGridView1.CellClick += DataGridView1_CellClick;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
        }

        private void Config_input()
        {
            cell_config device_name = new cell_config() {config_name = "device_name", display_text = "設備名稱", cell_mode = "text" };
            cell_config device_img = new cell_config() { config_name = "device_img", display_text = "設備圖片", value = "設定", cell_mode = "button" };
            cell_config order_sequence = new cell_config() { config_name = "order_sequence", display_text = "生產次序內容", value = "設定", cell_mode = "button" };
            cell_config reg_sequence = new cell_config() { config_name = "reg_sequence", display_text = "指定生產次序暫存器", cell_mode = "text" };
            cell_config device_param = new cell_config() { config_name = "device_param", display_text = "設備參數內容", value = "設定", cell_mode = "button" };
            cell_config reg_availability = new cell_config() { config_name = "reg_availability", display_text = "指定稼動率暫存器", cell_mode = "text" };
            cell_config update_rate = new cell_config() { config_name = "update_rate", display_text = "更新頻率(s)", cell_mode = "text" };
            cell_config enable_line_notify = new cell_config() { config_name = "enable_line_notify", display_text = "是否開啟 Line Notify 追蹤", cell_mode = "bool" };

            List<cell_config> config_list = new List<cell_config>() { device_name, device_img, order_sequence, reg_sequence, device_param, reg_availability, update_rate, enable_line_notify };
            Dictionary<string, string> import_config = INiReader.ReadSection(IniPath, ID);
            
            foreach (cell_config config in config_list)
            {                
                string _name = config.config_name;
                try
                {
                    config.value = import_config[_name];
                }
                catch
                {
                }
                int _index = dataGridView1.Rows.Add(config.display_text, config.value);
                

                switch (config.cell_mode)
                {
                    case "text":
                        dataGridView1.Rows[_index].Cells[1] = new DataGridViewTextBoxCell();
                        break;
                    case "bool":
                        var comboBoxCell = new DataGridViewComboBoxCell();
                        comboBoxCell.Items.AddRange("Enable", "Disable");
                        dataGridView1.Rows[_index].Cells[1] = comboBoxCell;
                        break;
                    default:
                        dataGridView1.Rows[_index].Cells[1] = new DataGridViewButtonCell();
                        break;
                }

                dataGridView1.Rows[_index].Tag = config.config_name;
                dataGridView1.Rows[_index].Cells[1].Value = config.value;
                
            }

            
            
            /*
            // 添加行：設備名稱，並在值列中添加文本框
            int deviceRowIndex = dataGridView1.Rows.Add("設備名稱", "Device 1");
            dataGridView1.Rows[deviceRowIndex].Cells[1] = new DataGridViewTextBoxCell();
            dataGridView1.Rows[deviceRowIndex].Cells[1].Value = "Device 1";

            // 添加行：圖片名稱，並在值列中添加按鈕
            int imageRowIndex = dataGridView1.Rows.Add("圖片", "Browse Image");
            dataGridView1.Rows[imageRowIndex].Cells[1] = new DataGridViewButtonCell();
            dataGridView1.Rows[imageRowIndex].Cells[1].Value = "設定";

            // 添加行：參數設定，並在值列中添加按鈕
            int proRowIndex = dataGridView1.Rows.Add("生產次序內容", "Set Parameters");
            dataGridView1.Rows[proRowIndex].Cells[1] = new DataGridViewButtonCell();
            dataGridView1.Rows[proRowIndex].Cells[1].Value = "設定";

            // 添加行：暫存器設定，並在值列中添加文本框
            int regRowIndex = dataGridView1.Rows.Add("指定生產次序暫存器", "Set Parameters");
            dataGridView1.Rows[regRowIndex].Cells[1] = new DataGridViewTextBoxCell();
            dataGridView1.Rows[regRowIndex].Cells[1].Value = "D100";

            // 添加行：參數設定，並在值列中添加按鈕
            int paramRowIndex = dataGridView1.Rows.Add("參數內容", "Set Parameters");
            dataGridView1.Rows[paramRowIndex].Cells[1] = new DataGridViewButtonCell();
            dataGridView1.Rows[paramRowIndex].Cells[1].Value = "設定";

            // 添加行：暫存器設定，並在值列中添加文本框
            int reg2RowIndex = dataGridView1.Rows.Add("指定稼動率暫存器", "Set Parameters");
            dataGridView1.Rows[reg2RowIndex].Cells[1] = new DataGridViewTextBoxCell();
            dataGridView1.Rows[reg2RowIndex].Cells[1].Value = "D101";

            // 添加行：更新頻率，並在值列中添加文本框
            int rateRowIndex = dataGridView1.Rows.Add("更新頻率(s)", "Device 1");
            dataGridView1.Rows[rateRowIndex].Cells[1] = new DataGridViewTextBoxCell();
            dataGridView1.Rows[rateRowIndex].Cells[1].Value = "3";

            // 添加行：狀態選項，並在值列中添加下拉式選單
            int statusRowIndex = dataGridView1.Rows.Add("是否開啟 Line Notify 追蹤", "Enable");
            var comboBoxCell = new DataGridViewComboBoxCell();
            comboBoxCell.Items.AddRange("Enable", "Disable");
            comboBoxCell.Value = "Enable"; // 預設值
            dataGridView1.Rows[statusRowIndex].Cells[1] = comboBoxCell;
            */

            
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string _name = dataGridView1.Rows[e.RowIndex].Tag as string;
            string _value = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Dictionary<string, string> import_config = INiReader.ReadSection(IniPath, ID);
            try
            {
                string _val = import_config[_name];
            }
            catch
            {
                return;
            }

            switch (_name)
            {
                case "device_name":
                    DeviceName = _value;
                    break;
                case "update_rate":
                    if (!Int32.TryParse(_value, out int num))
                    {
                        MessageBox.Show("請輸入整數數值");
                        return;
                    };
                    break;
            }

            INiReader.WriteINIFile(IniPath, ID, _name, _value);
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 檢查點擊的是不是按鈕
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                string description = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                if (description == "Image Name")
                {
                    // 打開圖片選擇對話框
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            MessageBox.Show($"Selected Image: {openFileDialog.FileName}");
                        }
                    }
                }
                else if (description == "Parameter Settings")
                {
                    // 打開新視窗進行參數設定
                    using (Form parameterForm = new Form())
                    {
                        parameterForm.Text = "Parameter Settings";
                        parameterForm.Width = 300;
                        parameterForm.Height = 200;
                        parameterForm.ShowDialog();
                    }
                }
            }
        }
    }
}
