using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNCAppPlatform.Controls
{
    public partial class deviceInfoConstrict : UserControl
    {
        [Description("設備圖片。"), Category("自訂值")]
        public Image DeviceImg { get; set; } = null;

        public deviceInfoConstrict()
        {
            InitializeComponent();
            InitializeDataGridView();


            if (DeviceImg == null) DeviceImg = pictureBox1.Image;
            //Height = button1.Height;

            SizeChanged += DeviceInfoConstrict_SizeChanged;
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
            string buttonText = "Your Text";
            Font font = new Font(button.Font.FontFamily, imageHeight / 5);
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

            

            // 綁定 CellClick 事件
            dataGridView1.CellClick += DataGridView1_CellClick;
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
