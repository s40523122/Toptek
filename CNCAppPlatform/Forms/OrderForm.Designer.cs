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
            this.btnAppend = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnApsMode = new System.Windows.Forms.Button();
            this.btnCsv = new System.Windows.Forms.Button();
            this.btnXml = new System.Windows.Forms.Button();
            this.panel1 = new CNCAppPlatform.myPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.btnAppend);
            this.flowLayoutPanel1.Controls.Add(this.btnLog);
            this.flowLayoutPanel1.Controls.Add(this.btnApsMode);
            this.flowLayoutPanel1.Controls.Add(this.btnCsv);
            this.flowLayoutPanel1.Controls.Add(this.btnXml);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(589, 35);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(211, 380);
            this.flowLayoutPanel1.TabIndex = 3;
            this.flowLayoutPanel1.WrapContents = false;
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
            this.btnAppend.Location = new System.Drawing.Point(18, 3);
            this.btnAppend.Name = "btnAppend";
            this.btnAppend.Size = new System.Drawing.Size(172, 59);
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
            this.btnLog.Location = new System.Drawing.Point(18, 68);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(172, 59);
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
            this.btnApsMode.Location = new System.Drawing.Point(18, 133);
            this.btnApsMode.Name = "btnApsMode";
            this.btnApsMode.Size = new System.Drawing.Size(172, 59);
            this.btnApsMode.TabIndex = 1;
            this.btnApsMode.Text = "選擇排程模式";
            this.btnApsMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnApsMode.UseVisualStyleBackColor = false;
            // 
            // btnCsv
            // 
            this.btnCsv.BackColor = System.Drawing.Color.Salmon;
            this.btnCsv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCsv.FlatAppearance.BorderSize = 0;
            this.btnCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCsv.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCsv.ForeColor = System.Drawing.Color.Black;
            this.btnCsv.Image = ((System.Drawing.Image)(resources.GetObject("btnCsv.Image")));
            this.btnCsv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCsv.Location = new System.Drawing.Point(18, 198);
            this.btnCsv.Name = "btnCsv";
            this.btnCsv.Size = new System.Drawing.Size(172, 59);
            this.btnCsv.TabIndex = 1;
            this.btnCsv.Text = "匯出為 csv";
            this.btnCsv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCsv.UseVisualStyleBackColor = false;
            // 
            // btnXml
            // 
            this.btnXml.BackColor = System.Drawing.Color.RosyBrown;
            this.btnXml.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXml.FlatAppearance.BorderSize = 0;
            this.btnXml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXml.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnXml.ForeColor = System.Drawing.Color.Black;
            this.btnXml.Image = ((System.Drawing.Image)(resources.GetObject("btnXml.Image")));
            this.btnXml.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXml.Location = new System.Drawing.Point(18, 263);
            this.btnXml.Name = "btnXml";
            this.btnXml.Size = new System.Drawing.Size(172, 59);
            this.btnXml.TabIndex = 1;
            this.btnXml.Text = "匯出為 xml";
            this.btnXml.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXml.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(35, 35);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Radius = 10;
            this.panel1.Size = new System.Drawing.Size(554, 380);
            this.panel1.TabIndex = 4;
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "OrderForm";
            this.Padding = new System.Windows.Forms.Padding(35, 35, 0, 35);
            this.Text = "OrderLog";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAppend;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnApsMode;
        private System.Windows.Forms.Button btnCsv;
        private System.Windows.Forms.Button btnXml;
        private System.Windows.Forms.Button btnLog;
        private myPanel panel1;
    }
}