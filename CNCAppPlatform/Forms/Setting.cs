using LiveCharts;
using LiveCharts.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RosSharp;
using System.Threading;
using Renci.SshNet;
using System.IO;

namespace CNCAppPlatform
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
            
        }

        private void TabControl1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            Graphics g = e.Graphics;

            // 檢查是否為選取的頁籤
            if (e.Index == tabControl.SelectedIndex)
            {
                // 當前選取的頁籤背景
                e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
            }
            else
            {
                // 未選取的頁籤背景
                e.Graphics.FillRectangle(Brushes.Transparent, e.Bounds);
            }

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            // 取得目前 TabPage 的標籤範圍
            Rectangle tabBounds = tabControl.GetTabRect(e.Index);

            // 旋轉文本角度
            g.TranslateTransform(tabBounds.Left + (tabBounds.Width / 2), tabBounds.Top + (tabBounds.Height / 2));
            g.RotateTransform(0); // 旋轉文本 90 度
            g.DrawString(tabControl.TabPages[e.Index].Text, tabControl.Font, Brushes.Black, 0, 0, sf);
            g.ResetTransform();
        }

    }
}
