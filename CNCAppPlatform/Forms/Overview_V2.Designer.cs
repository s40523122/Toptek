namespace CNCAppPlatform
{
    partial class Overview_V2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Overview_V2));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.deviceInfoView_V21 = new CNCAppPlatform.Controls.deviceInfoView_V2();
            this.deviceInfoView_V22 = new CNCAppPlatform.Controls.deviceInfoView_V2();
            this.page_bottom = new System.Windows.Forms.Splitter();
            this.page_dots = new System.Windows.Forms.FlowLayoutPanel();
            this.pause_btn = new ART_plus.DoubleImg();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pause_btn)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanel1.Controls.Add(this.deviceInfoView_V21);
            this.flowLayoutPanel1.Controls.Add(this.deviceInfoView_V22);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(21, 23);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1245, 612);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // deviceInfoView_V21
            // 
            this.deviceInfoView_V21.ID = "device1";
            this.deviceInfoView_V21.Location = new System.Drawing.Point(3, 2);
            this.deviceInfoView_V21.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deviceInfoView_V21.Name = "deviceInfoView_V21";
            this.deviceInfoView_V21.Size = new System.Drawing.Size(516, 601);
            this.deviceInfoView_V21.TabIndex = 0;
            // 
            // deviceInfoView_V22
            // 
            this.deviceInfoView_V22.ID = "device2";
            this.deviceInfoView_V22.Location = new System.Drawing.Point(525, 2);
            this.deviceInfoView_V22.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deviceInfoView_V22.Name = "deviceInfoView_V22";
            this.deviceInfoView_V22.Size = new System.Drawing.Size(516, 601);
            this.deviceInfoView_V22.TabIndex = 0;
            // 
            // page_bottom
            // 
            this.page_bottom.Cursor = System.Windows.Forms.Cursors.Default;
            this.page_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.page_bottom.Location = new System.Drawing.Point(0, 639);
            this.page_bottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.page_bottom.Name = "page_bottom";
            this.page_bottom.Size = new System.Drawing.Size(1075, 37);
            this.page_bottom.TabIndex = 3;
            this.page_bottom.TabStop = false;
            // 
            // page_dots
            // 
            this.page_dots.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.page_dots.Location = new System.Drawing.Point(587, 642);
            this.page_dots.Margin = new System.Windows.Forms.Padding(0);
            this.page_dots.Name = "page_dots";
            this.page_dots.Size = new System.Drawing.Size(131, 30);
            this.page_dots.TabIndex = 4;
            // 
            // pause_btn
            // 
            this.pause_btn.Change = false;
            this.pause_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pause_btn.Image = ((System.Drawing.Image)(resources.GetObject("pause_btn.Image")));
            this.pause_btn.Location = new System.Drawing.Point(737, 642);
            this.pause_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pause_btn.Name = "pause_btn";
            this.pause_btn.SetSquare = true;
            this.pause_btn.Size = new System.Drawing.Size(27, 27);
            this.pause_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pause_btn.SubImg = ((System.Drawing.Image)(resources.GetObject("pause_btn.SubImg")));
            this.pause_btn.TabIndex = 5;
            this.pause_btn.TabStop = false;
            this.pause_btn.Tag = ((object)(resources.GetObject("pause_btn.Tag")));
            // 
            // Overview_V2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 676);
            this.Controls.Add(this.pause_btn);
            this.Controls.Add(this.page_dots);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.page_bottom);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Overview_V2";
            this.Text = "Overview_V2";
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pause_btn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.deviceInfoView_V2 deviceInfoView_V21;
        private Controls.deviceInfoView_V2 deviceInfoView_V22;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Splitter page_bottom;
        private System.Windows.Forms.FlowLayoutPanel page_dots;
        private ART_plus.DoubleImg pause_btn;
    }
}