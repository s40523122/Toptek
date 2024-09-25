namespace CNCAppPlatform
{
    partial class OrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderForm));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new CNCAppPlatform.myPanel();
            this.btnAppend = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnApsMode = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.btnAppend);
            this.flowLayoutPanel1.Controls.Add(this.btnLog);
            this.flowLayoutPanel1.Controls.Add(this.btnApsMode);
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.Controls.Add(this.button4);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(786, 43);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(281, 468);
            this.flowLayoutPanel1.TabIndex = 3;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(47, 43);
            this.panel1.Name = "panel1";
            this.panel1.Radius = 10;
            this.panel1.Size = new System.Drawing.Size(739, 468);
            this.panel1.TabIndex = 4;
            // 
            // btnAppend
            // 
            this.btnAppend.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAppend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAppend.FlatAppearance.BorderSize = 0;
            this.btnAppend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAppend.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAppend.ForeColor = System.Drawing.Color.Black;
            this.btnAppend.Image = ((System.Drawing.Image)(resources.GetObject("btnAppend.Image")));
            this.btnAppend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAppend.Location = new System.Drawing.Point(24, 4);
            this.btnAppend.Margin = new System.Windows.Forms.Padding(4);
            this.btnAppend.Name = "btnAppend";
            this.btnAppend.Size = new System.Drawing.Size(230, 73);
            this.btnAppend.TabIndex = 1;
            this.btnAppend.Text = "新增工單";
            this.btnAppend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAppend.UseVisualStyleBackColor = false;
            // 
            // btnLog
            // 
            this.btnLog.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLog.FlatAppearance.BorderSize = 0;
            this.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLog.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnLog.ForeColor = System.Drawing.Color.Black;
            this.btnLog.Image = ((System.Drawing.Image)(resources.GetObject("btnLog.Image")));
            this.btnLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLog.Location = new System.Drawing.Point(24, 85);
            this.btnLog.Margin = new System.Windows.Forms.Padding(4);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(230, 73);
            this.btnLog.TabIndex = 3;
            this.btnLog.Text = "查看工單清單";
            this.btnLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLog.UseVisualStyleBackColor = false;
            // 
            // btnApsMode
            // 
            this.btnApsMode.BackColor = System.Drawing.Color.Plum;
            this.btnApsMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApsMode.FlatAppearance.BorderSize = 0;
            this.btnApsMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApsMode.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnApsMode.ForeColor = System.Drawing.Color.Black;
            this.btnApsMode.Image = ((System.Drawing.Image)(resources.GetObject("btnApsMode.Image")));
            this.btnApsMode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApsMode.Location = new System.Drawing.Point(24, 166);
            this.btnApsMode.Margin = new System.Windows.Forms.Padding(4);
            this.btnApsMode.Name = "btnApsMode";
            this.btnApsMode.Size = new System.Drawing.Size(230, 73);
            this.btnApsMode.TabIndex = 1;
            this.btnApsMode.Text = "選擇排程模式";
            this.btnApsMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnApsMode.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Salmon;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(24, 247);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(230, 73);
            this.button3.TabIndex = 1;
            this.button3.Text = "匯出為 csv";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.RosyBrown;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(24, 328);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(230, 73);
            this.button4.TabIndex = 1;
            this.button4.Text = "匯出為 xml";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OrderForm";
            this.Padding = new System.Windows.Forms.Padding(47, 43, 0, 43);
            this.Text = "OrderLog";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAppend;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnApsMode;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnLog;
        private myPanel panel1;
    }
}