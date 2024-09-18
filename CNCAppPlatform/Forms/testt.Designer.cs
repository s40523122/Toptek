namespace CNCAppPlatform
{
    partial class testt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(testt));
            this.pause_btn = new ART_plus.DoubleImg();
            this.page_dots = new System.Windows.Forms.FlowLayoutPanel();
            this.page_bottom = new System.Windows.Forms.Splitter();
            this.deviceInfoView_V21 = new CNCAppPlatform.Controls.deviceInfoView_V2();
            ((System.ComponentModel.ISupportInitialize)(this.pause_btn)).BeginInit();
            this.SuspendLayout();
            // 
            // pause_btn
            // 
            this.pause_btn.Change = false;
            this.pause_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pause_btn.Image = ((System.Drawing.Image)(resources.GetObject("pause_btn.Image")));
            this.pause_btn.Location = new System.Drawing.Point(728, 630);
            this.pause_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pause_btn.Name = "pause_btn";
            this.pause_btn.SetSquare = true;
            this.pause_btn.Size = new System.Drawing.Size(27, 27);
            this.pause_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pause_btn.SubImg = ((System.Drawing.Image)(resources.GetObject("pause_btn.SubImg")));
            this.pause_btn.TabIndex = 9;
            this.pause_btn.TabStop = false;
            this.pause_btn.Tag = ((object)(resources.GetObject("pause_btn.Tag")));
            // 
            // page_dots
            // 
            this.page_dots.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.page_dots.Location = new System.Drawing.Point(578, 630);
            this.page_dots.Margin = new System.Windows.Forms.Padding(0);
            this.page_dots.Name = "page_dots";
            this.page_dots.Size = new System.Drawing.Size(131, 30);
            this.page_dots.TabIndex = 8;
            // 
            // page_bottom
            // 
            this.page_bottom.Cursor = System.Windows.Forms.Cursors.Default;
            this.page_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.page_bottom.Location = new System.Drawing.Point(0, 641);
            this.page_bottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.page_bottom.Name = "page_bottom";
            this.page_bottom.Size = new System.Drawing.Size(1169, 37);
            this.page_bottom.TabIndex = 7;
            this.page_bottom.TabStop = false;
            // 
            // deviceInfoView_V21
            // 
            this.deviceInfoView_V21.ID = "";
            this.deviceInfoView_V21.Labels = null;
            this.deviceInfoView_V21.Location = new System.Drawing.Point(191, 57);
            this.deviceInfoView_V21.Name = "deviceInfoView_V21";
            this.deviceInfoView_V21.Paramrters = null;
            this.deviceInfoView_V21.Size = new System.Drawing.Size(309, 421);
            this.deviceInfoView_V21.TabIndex = 10;
            // 
            // testt
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1169, 678);
            this.Controls.Add(this.deviceInfoView_V21);
            this.Controls.Add(this.pause_btn);
            this.Controls.Add(this.page_dots);
            this.Controls.Add(this.page_bottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "testt";
            this.Text = "testt";
            ((System.ComponentModel.ISupportInitialize)(this.pause_btn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ART_plus.DoubleImg pause_btn;
        private System.Windows.Forms.FlowLayoutPanel page_dots;
        private System.Windows.Forms.Splitter page_bottom;
        private Controls.deviceInfoView_V2 deviceInfoView_V21;
    }
}