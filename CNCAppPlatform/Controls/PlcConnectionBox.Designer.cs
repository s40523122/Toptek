namespace CNCAppPlatform
{
    partial class PlcConnectionBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlcConnectionBox));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.editFinBtn = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.CheckBox();
            this.btnConnRS232 = new System.Windows.Forms.CheckBox();
            this.btnCpu5u = new System.Windows.Forms.CheckBox();
            this.btnConnEthernet = new System.Windows.Forms.CheckBox();
            this.btnCpu3u = new System.Windows.Forms.CheckBox();
            this.disconnBtn = new System.Windows.Forms.Button();
            this.connectBtn = new System.Windows.Forms.Button();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.labelLED1 = new CNCAppPlatform.LabelLED();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.panel1.Size = new System.Drawing.Size(1074, 279);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.editFinBtn);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Controls.Add(this.btnConnRS232);
            this.panel2.Controls.Add(this.btnCpu5u);
            this.panel2.Controls.Add(this.btnConnEthernet);
            this.panel2.Controls.Add(this.btnCpu3u);
            this.panel2.Controls.Add(this.labelLED1);
            this.panel2.Controls.Add(this.disconnBtn);
            this.panel2.Controls.Add(this.connectBtn);
            this.panel2.Controls.Add(this.tbIP);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.title);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1070, 272);
            this.panel2.TabIndex = 0;
            // 
            // editFinBtn
            // 
            this.editFinBtn.BackColor = System.Drawing.Color.SandyBrown;
            this.editFinBtn.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editFinBtn.Location = new System.Drawing.Point(612, 176);
            this.editFinBtn.Name = "editFinBtn";
            this.editFinBtn.Size = new System.Drawing.Size(147, 54);
            this.editFinBtn.TabIndex = 8;
            this.editFinBtn.Text = "修改完成";
            this.editFinBtn.UseVisualStyleBackColor = false;
            this.editFinBtn.Visible = false;
            this.editFinBtn.Click += new System.EventHandler(this.editFinBtn_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.BackgroundImage")));
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(970, 19);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(47, 47);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.CheckedChanged += new System.EventHandler(this.btnCheck_CheckedChanged);
            // 
            // btnConnRS232
            // 
            this.btnConnRS232.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnConnRS232.AutoCheck = false;
            this.btnConnRS232.BackColor = System.Drawing.SystemColors.Control;
            this.btnConnRS232.FlatAppearance.CheckedBackColor = System.Drawing.Color.SkyBlue;
            this.btnConnRS232.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnRS232.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnRS232.Location = new System.Drawing.Point(310, 138);
            this.btnConnRS232.Name = "btnConnRS232";
            this.btnConnRS232.Size = new System.Drawing.Size(99, 36);
            this.btnConnRS232.TabIndex = 5;
            this.btnConnRS232.Text = "RS232";
            this.btnConnRS232.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnConnRS232.UseVisualStyleBackColor = false;
            // 
            // btnCpu5u
            // 
            this.btnCpu5u.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnCpu5u.AutoCheck = false;
            this.btnCpu5u.BackColor = System.Drawing.SystemColors.Control;
            this.btnCpu5u.FlatAppearance.CheckedBackColor = System.Drawing.Color.SkyBlue;
            this.btnCpu5u.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCpu5u.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCpu5u.Location = new System.Drawing.Point(310, 83);
            this.btnCpu5u.Name = "btnCpu5u";
            this.btnCpu5u.Size = new System.Drawing.Size(99, 36);
            this.btnCpu5u.TabIndex = 5;
            this.btnCpu5u.Text = "FX5U";
            this.btnCpu5u.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCpu5u.UseVisualStyleBackColor = false;
            // 
            // btnConnEthernet
            // 
            this.btnConnEthernet.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnConnEthernet.AutoCheck = false;
            this.btnConnEthernet.BackColor = System.Drawing.SystemColors.Control;
            this.btnConnEthernet.FlatAppearance.CheckedBackColor = System.Drawing.Color.SkyBlue;
            this.btnConnEthernet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnEthernet.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnEthernet.Location = new System.Drawing.Point(195, 138);
            this.btnConnEthernet.Name = "btnConnEthernet";
            this.btnConnEthernet.Size = new System.Drawing.Size(99, 36);
            this.btnConnEthernet.TabIndex = 5;
            this.btnConnEthernet.Text = "Ethernet";
            this.btnConnEthernet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnConnEthernet.UseVisualStyleBackColor = false;
            // 
            // btnCpu3u
            // 
            this.btnCpu3u.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnCpu3u.AutoCheck = false;
            this.btnCpu3u.BackColor = System.Drawing.SystemColors.Control;
            this.btnCpu3u.FlatAppearance.CheckedBackColor = System.Drawing.Color.SkyBlue;
            this.btnCpu3u.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCpu3u.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCpu3u.Location = new System.Drawing.Point(195, 83);
            this.btnCpu3u.Name = "btnCpu3u";
            this.btnCpu3u.Size = new System.Drawing.Size(99, 36);
            this.btnCpu3u.TabIndex = 5;
            this.btnCpu3u.Text = "FX3U";
            this.btnCpu3u.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCpu3u.UseVisualStyleBackColor = false;
            // 
            // disconnBtn
            // 
            this.disconnBtn.BackColor = System.Drawing.Color.Salmon;
            this.disconnBtn.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disconnBtn.Location = new System.Drawing.Point(699, 176);
            this.disconnBtn.Name = "disconnBtn";
            this.disconnBtn.Size = new System.Drawing.Size(147, 54);
            this.disconnBtn.TabIndex = 3;
            this.disconnBtn.Text = "中斷連線";
            this.disconnBtn.UseVisualStyleBackColor = false;
            // 
            // connectBtn
            // 
            this.connectBtn.BackColor = System.Drawing.Color.LightGreen;
            this.connectBtn.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectBtn.Location = new System.Drawing.Point(522, 176);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(147, 54);
            this.connectBtn.TabIndex = 3;
            this.connectBtn.Text = "連線";
            this.connectBtn.UseVisualStyleBackColor = false;
            // 
            // tbIP
            // 
            this.tbIP.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIP.Location = new System.Drawing.Point(195, 194);
            this.tbIP.Name = "tbIP";
            this.tbIP.ReadOnly = true;
            this.tbIP.Size = new System.Drawing.Size(197, 35);
            this.tbIP.TabIndex = 2;
            this.tbIP.TabStop = false;
            this.tbIP.Text = "192.168.0.1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(43, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 27);
            this.label4.TabIndex = 0;
            this.label4.Text = "IP Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(43, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "連線方式";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(43, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "CPU Type";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(28, 24);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(48, 35);
            this.title.TabIndex = 0;
            this.title.Text = "#1";
            // 
            // labelLED1
            // 
            this.labelLED1.BackColor = System.Drawing.Color.DarkGray;
            this.labelLED1.IsLight = false;
            this.labelLED1.Location = new System.Drawing.Point(224, 14);
            this.labelLED1.Name = "labelLED1";
            this.labelLED1.Size = new System.Drawing.Size(106, 52);
            this.labelLED1.TabIndex = 4;
            // 
            // PlcConnectionBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "PlcConnectionBox";
            this.Size = new System.Drawing.Size(1074, 279);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox btnConnRS232;
        private System.Windows.Forms.CheckBox btnCpu5u;
        private System.Windows.Forms.CheckBox btnConnEthernet;
        private System.Windows.Forms.CheckBox btnCpu3u;
        private LabelLED labelLED1;
        private System.Windows.Forms.Button disconnBtn;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.CheckBox btnEdit;
        private System.Windows.Forms.Button editFinBtn;
    }
}
