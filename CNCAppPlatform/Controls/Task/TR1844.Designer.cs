namespace CNCAppPlatform
{
    partial class TR1844
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.myPanel1 = new CNCAppPlatform.myPanel();
            this.count = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.myPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // myPanel1
            // 
            this.myPanel1.BackColor = System.Drawing.Color.White;
            this.myPanel1.Controls.Add(this.count);
            this.myPanel1.Controls.Add(this.label1);
            this.myPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myPanel1.Location = new System.Drawing.Point(0, 0);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.myPanel1.Radius = 10;
            this.myPanel1.Size = new System.Drawing.Size(283, 209);
            this.myPanel1.TabIndex = 5;
            // 
            // count
            // 
            this.count.Dock = System.Windows.Forms.DockStyle.Fill;
            this.count.Font = new System.Drawing.Font("微軟正黑體", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.count.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.count.Location = new System.Drawing.Point(10, 33);
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(263, 166);
            this.count.TabIndex = 0;
            this.count.Text = "1";
            this.count.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "在途生產工件計數";
            // 
            // TR1844
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myPanel1);
            this.Name = "TR1844";
            this.Size = new System.Drawing.Size(283, 209);
            this.myPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private myPanel myPanel1;
        private System.Windows.Forms.Label count;
        private System.Windows.Forms.Label label1;
    }
}
