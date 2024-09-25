using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Media;

namespace CNCAppPlatform.Forms.Pages
{
    public partial class ApsModeSelect : Form
    {
        Form backForm;

        /// <summary>
        /// 選擇模式
        /// </summary>
        /// <remarks>
        /// 宣告為靜態物件，為所有 APS 模式的來源。
        /// </remarks>
        public static int Selected { get; set; } = 0;
        
        /// <summary>
        /// 已建立的模式
        /// </summary>
        private myPanel[] modes;
        
        /// <summary>
        /// 已建立的模式名稱
        /// </summary>
        Label[] mode_labels;

        public ApsModeSelect()
        {
            InitializeComponent();

            // 加入模式內容
            modes = new myPanel[] { myPanel1, myPanel2, myPanel3, myPanel4 };
            mode_labels = new Label[] { label2, label3, label4, label5 };
            
            // 指定選定的模式
            modes[Selected].BackColor = Color.Wheat;
            label7.Text = mode_labels[Selected].Text.Replace("\r\n", " ");

            // 建立黑背景
            TopMost = true;
            backForm = new Form()
            {
                StartPosition = FormStartPosition.Manual,
                FormBorderStyle = FormBorderStyle.None,
                Opacity = .50d,
                BackColor = Color.Black,
                WindowState = FormWindowState.Maximized,
                TopMost = true,
                Location = this.Location,
                ShowInTaskbar = false,
            };
            if (!System.Diagnostics.Debugger.IsAttached) backForm.Show();       // Dubug 模式不顯示

            // 模式區塊渲染&點擊事件
            foreach (myPanel mode in new myPanel[]{ myPanel1, myPanel2, myPanel3, myPanel4})
            {
                mode.Paint += ApsModeSelect_Paint;
                mode.MouseClick += MyPanel1_MouseClick;
            }
        }

        private void MyPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (myPanel mode in modes)
            {
                mode.BackColor = Color.FloralWhite;
            }
            (sender as myPanel).BackColor = Color.Wheat;
            Selected = Int32.Parse((string)(sender as myPanel).Tag);
            
            label7.Text = mode_labels[Selected].Text.Replace("\r\n", " ");
        }

        private void ApsModeSelect_Paint(object sender, PaintEventArgs e)
        {
            // 獲取 graphics 對象
            Graphics g = e.Graphics;

            // 設定抗鋸齒和光滑模式
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit; // 清晰的字體渲染
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; // 開啟抗鋸齒


            foreach (Control ctrl in (sender as myPanel).Controls)
            {
                ctrl.Visible = false;

                if (ctrl is Label)
                {
                    Label myLabel = ctrl as Label;
                    // 擷取 label 內容
                    string text = myLabel.Text;
                    Font font = myLabel.Font;
                    Brush brush = new SolidBrush(myLabel.ForeColor);
                    PointF point = new PointF(myLabel.Location.X, myLabel.Location.Y);

                    // 繪製文本
                    g.DrawString(text, font, brush, point);
                }
                else if (ctrl is RichTextBox)
                {
                    RichTextBox richTextBox = ctrl as RichTextBox;
                    // 擷取 RichTextBox 的位置、字型和內容
                    Point richTextBoxLocation = richTextBox.Location;
                    Font richTextBoxFont = richTextBox.Font;
                    string richTextBoxText = richTextBox.Text;
                    Color richTextBoxColor = richTextBox.ForeColor;

                    // 設定繪製範圍，確保文本內容在 RichTextBox 的寬度內自動換行
                    RectangleF textArea = new RectangleF(richTextBoxLocation, richTextBox.Size);

                    // 設定文本格式，啟用自動換行
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.FormatFlags = StringFormatFlags.LineLimit;  // 限制文本在範圍內顯示，超出會換行
                    stringFormat.Trimming = StringTrimming.Word;             // 根據單詞換行

                    // 在指定範圍內繪製文本並保持自動換行
                    g.DrawString(richTextBoxText, richTextBoxFont, new SolidBrush(richTextBoxColor), textArea, stringFormat);
                }
            }
        }

        void ff()
        {
            richTextBox1.Update(); // Ensure RTB fully painted
            Bitmap bmp = new Bitmap(richTextBox1.Width, richTextBox1.Height);
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                gr.CopyFromScreen(richTextBox1.PointToScreen(Point.Empty), Point.Empty, richTextBox1.Size);
            }
            //pictureBox1.Image = bmp;
        }

        // 將控件繪製到 Bitmap 中
        private void DrawControlToBitmap(Control control, Graphics g)
        {
            // 創建與控件尺寸相同的 Bitmap
            Bitmap ctrlBitmap = new Bitmap(control.Width, control.Height);

            // 將控件繪製到 Bitmap
            control.DrawToBitmap(ctrlBitmap, new Rectangle(0, 0, control.Width, control.Height));

            // 將該控件的 Bitmap 繪製到 Panel 的 Bitmap 中
            g.DrawImage(ctrlBitmap, control.Location);
        }

        private void btnClose_CheckedChanged(object sender, EventArgs e)
        {
            Close();
            backForm.Hide();
        }
    }
}
