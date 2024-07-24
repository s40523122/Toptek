using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CNCAppPlatform
{
    public partial class AddItemButton : UserControl
    {
        public AddItemButton()
        {
            InitializeComponent();
            label1.Paint += Label1_Paint;
            label1.MouseEnter += Label1_MouseEnter;
            label1.MouseLeave += Label1_MouseLeave;

            // 將 Panel 的點擊事件處理方法設置為 UserControl 的點擊事件
            label1.Click += (sender, e) => OnClick(e);
        }

        private void Label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = SystemColors.Control;    
        }

        private void Label1_MouseEnter(object sender, EventArgs e)
        {
            label1.BackColor = SystemColors.ControlLight;
        }

        private void Label1_Paint(object sender, PaintEventArgs e)
        {
            // 建立一個 Pen 物件，設置其顏色和虛線樣式
            Pen dashedPen = new Pen(ForeColor, 10);
            dashedPen.DashStyle = DashStyle.Dash;

            // 定義方形的尺寸和圓角半徑
            int x = 0;
            int y = 0;
            int width = label1.Width;
            int height = label1.Height;
            int radius = 20;

            // 建立 GraphicsPath 物件，定義帶圓角的方形
            GraphicsPath path = new GraphicsPath();
            path.AddLine(x + radius, y, x + width - radius * 2, y); // 上邊緣
            path.AddArc(x + width - radius * 2, y, radius * 2, radius * 2, 270, 90); // 右上角
            path.AddLine(x + width, y + radius, x + width, y + height - radius * 2); // 右邊緣
            path.AddArc(x + width - radius * 2, y + height - radius * 2, radius * 2, radius * 2, 0, 90); // 右下角
            path.AddLine(x + width - radius * 2, y + height, x + radius, y + height); // 下邊緣
            path.AddArc(x, y + height - radius * 2, radius * 2, radius * 2, 90, 90); // 左下角
            path.AddLine(x, y + height - radius * 2, x, y + radius); // 左邊緣
            path.AddArc(x, y, radius * 2, radius * 2, 180, 90); // 左上角
            path.CloseFigure(); // 關閉圖形

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            // 在表單上繪製虛線
            e.Graphics.DrawPath(dashedPen, path);

            label1.Region = new Region(path);

            // 釋放 Pen 物件的資源
            dashedPen.Dispose();
        }
    }
}
