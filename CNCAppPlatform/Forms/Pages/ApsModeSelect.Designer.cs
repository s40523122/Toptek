namespace CNCAppPlatform.Forms.Pages
{
    partial class ApsModeSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApsModeSelect));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.myPanel1 = new CNCAppPlatform.myPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.myPanel2 = new CNCAppPlatform.myPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.myPanel3 = new CNCAppPlatform.myPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.myPanel4 = new CNCAppPlatform.myPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.myPanel1.SuspendLayout();
            this.myPanel2.SuspendLayout();
            this.myPanel3.SuspendLayout();
            this.myPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(642, 43);
            this.panel1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClose.Location = new System.Drawing.Point(591, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(47, 43);
            this.btnClose.TabIndex = 5;
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.CheckedChanged += new System.EventHandler(this.btnClose_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "選擇排程模式";
            // 
            // myPanel1
            // 
            this.myPanel1.BackColor = System.Drawing.Color.FloralWhite;
            this.myPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.myPanel1.Controls.Add(this.label2);
            this.myPanel1.Controls.Add(this.richTextBox1);
            this.myPanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myPanel1.Location = new System.Drawing.Point(31, 64);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.Radius = 10;
            this.myPanel1.Size = new System.Drawing.Size(278, 240);
            this.myPanel1.TabIndex = 2;
            this.myPanel1.Tag = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(15, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 48);
            this.label2.TabIndex = 0;
            this.label2.Text = "最小化工單延遲\r\n(Minimize Job Delay)";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FloralWhite;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.richTextBox1.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Gray;
            this.richTextBox1.Location = new System.Drawing.Point(11, 85);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(251, 140);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "●邏輯描述： 計算工單交期剩餘時間，優先分配即將到期的工單，目標是確保交期能按時完成，避免工單延遲。\n\n●適用場景： 有多個不同交期的工單時，這種邏輯有助於最大化" +
    "滿足交期需求。";
            // 
            // myPanel2
            // 
            this.myPanel2.BackColor = System.Drawing.Color.FloralWhite;
            this.myPanel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.myPanel2.Controls.Add(this.label3);
            this.myPanel2.Controls.Add(this.richTextBox2);
            this.myPanel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myPanel2.Location = new System.Drawing.Point(335, 64);
            this.myPanel2.Name = "myPanel2";
            this.myPanel2.Radius = 10;
            this.myPanel2.Size = new System.Drawing.Size(278, 240);
            this.myPanel2.TabIndex = 2;
            this.myPanel2.Tag = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 48);
            this.label3.TabIndex = 0;
            this.label3.Text = "機台能耗最佳化\r\n(Optimal Load)";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.FloralWhite;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.richTextBox2.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.richTextBox2.ForeColor = System.Drawing.Color.Gray;
            this.richTextBox2.Location = new System.Drawing.Point(11, 85);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(251, 140);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "●邏輯描述： 基於機台工作負載分配工單，目標是讓最少機器工作，降低過剩產能。\n\n●適用場景： 當產線中有多台機台可用，並且需要確保產能最小化時，訂單能在交期內完成" +
    "。";
            // 
            // myPanel3
            // 
            this.myPanel3.BackColor = System.Drawing.Color.FloralWhite;
            this.myPanel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.myPanel3.Controls.Add(this.label4);
            this.myPanel3.Controls.Add(this.richTextBox3);
            this.myPanel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myPanel3.Location = new System.Drawing.Point(31, 328);
            this.myPanel3.Name = "myPanel3";
            this.myPanel3.Radius = 10;
            this.myPanel3.Size = new System.Drawing.Size(278, 240);
            this.myPanel3.TabIndex = 2;
            this.myPanel3.Tag = "2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 48);
            this.label4.TabIndex = 0;
            this.label4.Text = "最短處理時間 \r\n(Shortest Time First)";
            // 
            // richTextBox3
            // 
            this.richTextBox3.BackColor = System.Drawing.Color.FloralWhite;
            this.richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.richTextBox3.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.richTextBox3.ForeColor = System.Drawing.Color.Gray;
            this.richTextBox3.Location = new System.Drawing.Point(11, 85);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.Size = new System.Drawing.Size(251, 140);
            this.richTextBox3.TabIndex = 0;
            this.richTextBox3.Text = "●邏輯描述： 優先處理所需加工時間最短的工單，可以快速清空產能，提高整體的生產效率。\n\n●適用場景： 需要快速清空生產隊列或增加工單的流動性時，能有效減少平均等待" +
    "時間。";
            // 
            // myPanel4
            // 
            this.myPanel4.BackColor = System.Drawing.Color.FloralWhite;
            this.myPanel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.myPanel4.Controls.Add(this.label5);
            this.myPanel4.Controls.Add(this.richTextBox4);
            this.myPanel4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myPanel4.Location = new System.Drawing.Point(335, 328);
            this.myPanel4.Name = "myPanel4";
            this.myPanel4.Radius = 10;
            this.myPanel4.Size = new System.Drawing.Size(278, 240);
            this.myPanel4.TabIndex = 2;
            this.myPanel4.Tag = "3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 48);
            this.label5.TabIndex = 0;
            this.label5.Text = "優先級處理\r\n(Priority-Based)";
            // 
            // richTextBox4
            // 
            this.richTextBox4.BackColor = System.Drawing.Color.FloralWhite;
            this.richTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.richTextBox4.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.richTextBox4.ForeColor = System.Drawing.Color.Gray;
            this.richTextBox4.Location = new System.Drawing.Point(11, 85);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.ReadOnly = true;
            this.richTextBox4.Size = new System.Drawing.Size(251, 140);
            this.richTextBox4.TabIndex = 0;
            this.richTextBox4.Text = "●邏輯描述： 根據重要性、緊急程度或客戶優先順序設定優先級，優先級高的工單將會先被分配到可用機台。\n\n●適用場景： 適合應對多種類型的工單、VIP客戶或特殊需求時" +
    "，確保優先處理高優先級的訂單。";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(27, 598);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "目前模式:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(124, 598);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(334, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "最小化工單延遲 (Minimize Job Delay)";
            // 
            // ApsModeSelect
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(642, 652);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.myPanel4);
            this.Controls.Add(this.myPanel3);
            this.Controls.Add(this.myPanel2);
            this.Controls.Add(this.myPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "ApsModeSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ApsModeSelect";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.myPanel1.ResumeLayout(false);
            this.myPanel1.PerformLayout();
            this.myPanel2.ResumeLayout(false);
            this.myPanel2.PerformLayout();
            this.myPanel3.ResumeLayout(false);
            this.myPanel3.PerformLayout();
            this.myPanel4.ResumeLayout(false);
            this.myPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private myPanel myPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private myPanel myPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private myPanel myPanel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private myPanel myPanel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}