namespace CNCAppPlatform
{
    partial class TS0082_2
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
            this.myPanel2 = new CNCAppPlatform.myPanel();
            this.orderID1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.myPanel1 = new CNCAppPlatform.myPanel();
            this.plateNo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.myPanel2.SuspendLayout();
            this.myPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // myPanel2
            // 
            this.myPanel2.BackColor = System.Drawing.Color.White;
            this.myPanel2.Controls.Add(this.orderID1);
            this.myPanel2.Controls.Add(this.label3);
            this.myPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myPanel2.Location = new System.Drawing.Point(10, 0);
            this.myPanel2.Name = "myPanel2";
            this.myPanel2.Padding = new System.Windows.Forms.Padding(10);
            this.myPanel2.Radius = 10;
            this.myPanel2.Size = new System.Drawing.Size(157, 209);
            this.myPanel2.TabIndex = 0;
            // 
            // orderID1
            // 
            this.orderID1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderID1.Font = new System.Drawing.Font("微軟正黑體", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.orderID1.ForeColor = System.Drawing.Color.Green;
            this.orderID1.Location = new System.Drawing.Point(10, 33);
            this.orderID1.Name = "orderID1";
            this.orderID1.Size = new System.Drawing.Size(137, 166);
            this.orderID1.TabIndex = 2;
            this.orderID1.Text = "FX003200112";
            this.orderID1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(10, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "工單ID";
            // 
            // myPanel1
            // 
            this.myPanel1.BackColor = System.Drawing.Color.White;
            this.myPanel1.Controls.Add(this.plateNo);
            this.myPanel1.Controls.Add(this.label1);
            this.myPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.myPanel1.Location = new System.Drawing.Point(0, 0);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.myPanel1.Radius = 10;
            this.myPanel1.Size = new System.Drawing.Size(116, 209);
            this.myPanel1.TabIndex = 2;
            // 
            // plateNo
            // 
            this.plateNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plateNo.Font = new System.Drawing.Font("微軟正黑體", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.plateNo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.plateNo.Location = new System.Drawing.Point(10, 33);
            this.plateNo.Name = "plateNo";
            this.plateNo.Size = new System.Drawing.Size(96, 166);
            this.plateNo.TabIndex = 0;
            this.plateNo.Text = "1";
            this.plateNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "當前料盤";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.myPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(116, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panel1.Size = new System.Drawing.Size(167, 209);
            this.panel1.TabIndex = 3;
            // 
            // TS0082_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.myPanel1);
            this.Name = "TS0082_2";
            this.Size = new System.Drawing.Size(283, 209);
            this.myPanel2.ResumeLayout(false);
            this.myPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private myPanel myPanel2;
        private System.Windows.Forms.Label orderID1;
        private System.Windows.Forms.Label label3;
        private myPanel myPanel1;
        private System.Windows.Forms.Label plateNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}
