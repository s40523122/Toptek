namespace CNCAppPlatform
{
    partial class machineState
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label16 = new System.Windows.Forms.Label();
            this.lbFreq = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.equipFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1450, 1);
            this.panel1.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(20, 22, 20, 22);
            this.label1.Size = new System.Drawing.Size(249, 84);
            this.label1.TabIndex = 34;
            this.label1.Text = "設備狀態顯示";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(1146, 30);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(158, 40);
            this.label16.TabIndex = 53;
            this.label16.Text = "資料更新週期：";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbFreq
            // 
            this.lbFreq.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbFreq.Location = new System.Drawing.Point(1264, 30);
            this.lbFreq.Name = "lbFreq";
            this.lbFreq.Size = new System.Drawing.Size(69, 40);
            this.lbFreq.TabIndex = 53;
            this.lbFreq.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label18.Location = new System.Drawing.Point(1333, 30);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 40);
            this.label18.TabIndex = 53;
            this.label18.Text = "毫秒";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // equipFlowLayout
            // 
            this.equipFlowLayout.AutoScroll = true;
            this.equipFlowLayout.Location = new System.Drawing.Point(22, 94);
            this.equipFlowLayout.Name = "equipFlowLayout";
            this.equipFlowLayout.Size = new System.Drawing.Size(1398, 810);
            this.equipFlowLayout.TabIndex = 74;
            this.equipFlowLayout.WrapContents = false;
            // 
            // machineState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.equipFlowLayout);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lbFreq);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "machineState";
            this.Size = new System.Drawing.Size(1450, 930);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lbFreq;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.FlowLayoutPanel equipFlowLayout;
    }
}
