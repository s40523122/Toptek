﻿using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CNCAppPlatform
{
    public partial class ToggleSwitch : CheckBox
    {
        public ToggleSwitch()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            Padding = new Padding(6);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            this.OnPaintBackground(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = new GraphicsPath())
            {
                var d = Padding.All;
                var r = this.Height - 2 * d;
                path.AddArc(d, d, r, r, 90, 180);
                path.AddArc(this.Width - r - d, d, r, r, -90, 180);
                path.CloseFigure();
                e.Graphics.FillPath(Checked ? Brushes.DarkGray : Brushes.LightGray, path);
                r = Height - 1;
                var rect = Checked ? new Rectangle(Width - r - 1, 0, r, r)
                                   : new Rectangle(0, 0, r, r);

                SolidBrush myBrushOn = new SolidBrush(Color.FromArgb(44, 62, 80));
                SolidBrush myBrushOff = new SolidBrush(Color.FromArgb(117, 117, 117));

                e.Graphics.FillEllipse(Checked ? myBrushOn : myBrushOff, rect);
            }
        }
    }
}
