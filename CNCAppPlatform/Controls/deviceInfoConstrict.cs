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
        [Description("設備ID。"), Category("自訂值")]
        public string IniSection { set; get; } = "";
        private string _deviceName = "";

        public deviceInfoConstrict()
        {
            InitializeComponent();
            InitializeDataGridView();

            SizeChanged += DeviceInfoConstrict_SizeChanged;

            button1.Paint += button1_Paint;
        }

        public void UpdateInfo(string name, Image img)
        {
            pictureBox1.Image = img;
            _deviceName = name;

            button1.Refresh();
        }

        private void DeviceInfoConstrict_SizeChanged(object sender, EventArgs e)
        {
            if (!doubleImg1.Change) button1.Height = Height;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            doubleImg1.Change = !doubleImg1.Change;
            if (doubleImg1.Change) Height *= 5;
            else Height /= 5;
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;

            // 加載圖片
            Image imgLeft = pictureBox1.Image; // 左邊的圖片
            Image imgRight = doubleImg1.Image; // 右邊的圖片

            // 設置圖片位置
            int imageHeight = (int)(button1.Height * 0.8); // 假設圖片寬度為16像素
            
            //int imageHeight = 16; // 假設圖片高度為16像素
            int padding = 5; // 圖片與文字之間的間距

            Rectangle imgLeftRect = new Rectangle(padding*5, (button.Height - imageHeight) / 2, imageHeight, imageHeight);
            Rectangle imgRightRect = new Rectangle(button.Width - imageHeight/3 - padding*3, (button.Height - imageHeight/3) / 2, imageHeight/3, imageHeight/3);

            // 複製 zoom 後的圖片
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bitmap, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));

            // 繪製左邊的圖片
            e.Graphics.DrawImage(bitmap, imgLeftRect);

            // 繪製右邊的圖片
            e.Graphics.DrawImage(imgRight, imgRightRect);

            // 繪製文字
            string buttonText = _deviceName;
            Font font = new Font(button.Font.FontFamily, imageHeight / 4);
            SizeF textSize = e.Graphics.MeasureString(buttonText, font);
            PointF textLocation = new PointF(imageHeight + padding * 7, (button.Height - textSize.Height) / 2);

            e.Graphics.DrawString(buttonText, font, Brushes.Black, textLocation);
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

        }

        public void Config_input(iDevice device)
        {

            cell_config device_name = new cell_config() {config_name = "device_name", display_text = "設備名稱", value = device.DeviceName, cell_mode = "text" };
            cell_config device_img = new cell_config() { config_name = "device_img", display_text = "設備圖片", value = "設定", cell_mode = "button" };
            cell_config order_sequence = new cell_config() { config_name = "sequence_list", display_text = "生產次序內容", value = "設定", cell_mode = "button" };
            cell_config reg_sequence = new cell_config() { config_name = "reg_sequence", display_text = "指定生產次序暫存器", value = device.RegSequence, cell_mode = "text" };
            cell_config device_param = new cell_config() { config_name = "device_param", display_text = "設備參數內容", value = "設定", cell_mode = "button" };
            cell_config reg_availability = new cell_config() { config_name = "reg_availability", display_text = "指定稼動率暫存器", value = device.RegAvailability, cell_mode = "text" };
            cell_config update_rate = new cell_config() { config_name = "update_rate", display_text = "更新頻率(s)", value = device.UpdateRate.ToString(), cell_mode = "text" };
            cell_config enable_line_notify = new cell_config() { config_name = "enable_line_notify", display_text = "是否開啟 Line Notify 追蹤", value = device.EnableLineNotify, cell_mode = "bool" };

            List<cell_config> config_list = new List<cell_config>() { device_name, device_img, order_sequence, reg_sequence, device_param, reg_availability, update_rate, enable_line_notify };

            // 加入設定內容格式
            foreach (cell_config config in config_list)
            {                
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

            // 綁定 CellClick 事件
            dataGridView1.CellClick += DataGridView1_CellClick;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string _name = dataGridView1.Rows[e.RowIndex].Tag as string;
            string _value = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            iDevice device_model = Global_Variable.Devices.Where(x => x.IniSection == IniSection).FirstOrDefault();
            switch (_name)
            {
                case "device_name":
                    device_model.DeviceName = _value;
                    break;
                case "update_rate":
                    if (!Int32.TryParse(_value, out int num))
                    {
                        MessageBox.Show("請輸入整數數值");
                        return;
                    };
                    break;
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            // 標題欄與描述格不可選
            if (e.RowIndex <= 0 || e.ColumnIndex == 0) return;
            string _name = dataGridView1.Rows[e.RowIndex].Tag as string;

            string description = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            iDevice device_model = Global_Variable.Devices.Where(x => x.IniSection == IniSection).FirstOrDefault();

            switch (_name)
            {
                case "device_img":
                    // 打開圖片選擇對話框
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                            device_model.DeviceImage = Image.FromFile(openFileDialog.FileName);
                    }
                    break;

                case "device_param":
                    // 打開新視窗進行參數設定
                    using (ParamRegSetting parameterForm = new ParamRegSetting())
                    {
                        //parameterForm.ID = ID;
                        parameterForm.Text = "Parameter Settings";
                        //parameterForm.Width = 300;
                        //parameterForm.Height = 200;
                        parameterForm.StartPosition = FormStartPosition.CenterParent;
                        parameterForm.ShowIcon = false;
                        parameterForm.ShowDialog();
                    }
                    break;

                case "sequence_list":
                    // 打開新視窗進行參數設定
                    using (SequenceList parameterForm = new SequenceList())
                    {
                        //parameterForm.ID = ID;
                        parameterForm.Text = "Parameter Settings";
                        //parameterForm.Width = 300;
                        //parameterForm.Height = 200;
                        parameterForm.StartPosition = FormStartPosition.CenterParent;
                        parameterForm.ShowIcon = false;
                        parameterForm.ShowDialog();
                    }
                    break;
            }
            
        }
    }
}
