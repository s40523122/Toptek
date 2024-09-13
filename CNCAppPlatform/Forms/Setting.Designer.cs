using RosSharp;
using System.Drawing;

namespace CNCAppPlatform
{
    partial class Setting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.deviceInfoConstrict3 = new CNCAppPlatform.Controls.deviceInfoConstrict();
            this.deviceInfoConstrict2 = new CNCAppPlatform.Controls.deviceInfoConstrict();
            this.deviceInfoConstrict1 = new CNCAppPlatform.Controls.deviceInfoConstrict();
            this.deviceInfoConstrict4 = new CNCAppPlatform.Controls.deviceInfoConstrict();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.HotTrack = true;
            this.tabControl1.ItemSize = new System.Drawing.Size(20, 180);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1067, 554);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.TabControl1_DrawItem);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(184, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(80, 80, 80, 0);
            this.tabPage1.Size = new System.Drawing.Size(879, 546);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "設備";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.deviceInfoConstrict3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.deviceInfoConstrict2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.deviceInfoConstrict1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.deviceInfoConstrict4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(80, 80);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(719, 466);
            this.panel1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Location = new System.Drawing.Point(184, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(879, 546);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Location = new System.Drawing.Point(184, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(879, 546);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(280, 201);
            // 
            // deviceInfoConstrict3
            // 
            this.deviceInfoConstrict3.BackColor = System.Drawing.Color.White;
            this.deviceInfoConstrict3.DeviceImg = ((System.Drawing.Image)(resources.GetObject("deviceInfoConstrict3.DeviceImg")));
            this.deviceInfoConstrict3.DeviceName = "Device A";
            this.deviceInfoConstrict3.Dock = System.Windows.Forms.DockStyle.Top;
            this.deviceInfoConstrict3.ID = "constrict4";
            this.deviceInfoConstrict3.Location = new System.Drawing.Point(3, 273);
            this.deviceInfoConstrict3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deviceInfoConstrict3.Name = "deviceInfoConstrict3";
            this.deviceInfoConstrict3.Size = new System.Drawing.Size(713, 80);
            this.deviceInfoConstrict3.TabIndex = 13;
            // 
            // deviceInfoConstrict2
            // 
            this.deviceInfoConstrict2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.deviceInfoConstrict2.DeviceImg = ((System.Drawing.Image)(resources.GetObject("deviceInfoConstrict2.DeviceImg")));
            this.deviceInfoConstrict2.DeviceName = "Device A";
            this.deviceInfoConstrict2.Dock = System.Windows.Forms.DockStyle.Top;
            this.deviceInfoConstrict2.ID = "constrict3";
            this.deviceInfoConstrict2.Location = new System.Drawing.Point(3, 183);
            this.deviceInfoConstrict2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.deviceInfoConstrict2.Name = "deviceInfoConstrict2";
            this.deviceInfoConstrict2.Size = new System.Drawing.Size(713, 80);
            this.deviceInfoConstrict2.TabIndex = 11;
            // 
            // deviceInfoConstrict1
            // 
            this.deviceInfoConstrict1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.deviceInfoConstrict1.DeviceImg = ((System.Drawing.Image)(resources.GetObject("deviceInfoConstrict1.DeviceImg")));
            this.deviceInfoConstrict1.DeviceName = "Device A";
            this.deviceInfoConstrict1.Dock = System.Windows.Forms.DockStyle.Top;
            this.deviceInfoConstrict1.ID = "constrict2";
            this.deviceInfoConstrict1.Location = new System.Drawing.Point(3, 93);
            this.deviceInfoConstrict1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.deviceInfoConstrict1.Name = "deviceInfoConstrict1";
            this.deviceInfoConstrict1.Size = new System.Drawing.Size(713, 80);
            this.deviceInfoConstrict1.TabIndex = 9;
            // 
            // deviceInfoConstrict4
            // 
            this.deviceInfoConstrict4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.deviceInfoConstrict4.DeviceImg = ((System.Drawing.Image)(resources.GetObject("deviceInfoConstrict4.DeviceImg")));
            this.deviceInfoConstrict4.DeviceName = "Device A";
            this.deviceInfoConstrict4.Dock = System.Windows.Forms.DockStyle.Top;
            this.deviceInfoConstrict4.ID = "constrict1";
            this.deviceInfoConstrict4.Location = new System.Drawing.Point(3, 3);
            this.deviceInfoConstrict4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deviceInfoConstrict4.Name = "deviceInfoConstrict4";
            this.deviceInfoConstrict4.Size = new System.Drawing.Size(713, 80);
            this.deviceInfoConstrict4.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 173);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(713, 10);
            this.panel2.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 83);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(713, 10);
            this.panel3.TabIndex = 15;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 263);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(713, 10);
            this.panel4.TabIndex = 16;
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Setting";
            this.Text = "Setting";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.Panel panel1;
        private Controls.deviceInfoConstrict deviceInfoConstrict4;
        private Controls.deviceInfoConstrict deviceInfoConstrict2;
        private Controls.deviceInfoConstrict deviceInfoConstrict1;
        private Controls.deviceInfoConstrict deviceInfoConstrict3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}