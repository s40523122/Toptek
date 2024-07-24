namespace CNCAppPlatform
{
    partial class deviceInfoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(deviceInfoView));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelTask = new System.Windows.Forms.Panel();
            this.panel4 = new CNCAppPlatform.myPanel();
            this.labelY = new System.Windows.Forms.Label();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.labelR = new System.Windows.Forms.Label();
            this.textBoxR = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.speedBar1 = new CNCAppPlatform.SpeedBar();
            this.deviceName = new CNCAppPlatform.myPanel();
            this.tBoxDeviceName = new System.Windows.Forms.TextBox();
            this.DeviceNamelabel = new System.Windows.Forms.Label();
            this.deviceImg = new CNCAppPlatform.myPanel();
            this.panelFlow = new CNCAppPlatform.myPanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.LabelFlow = new System.Windows.Forms.Label();
            this.flowView1 = new CNCAppPlatform.flowView();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.deviceName.SuspendLayout();
            this.panelFlow.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelTask, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.deviceName, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.deviceImg, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelFlow, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 131F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 179F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 211F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(295, 759);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelTask
            // 
            this.panelTask.BackColor = System.Drawing.SystemColors.Control;
            this.panelTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTask.Location = new System.Drawing.Point(8, 383);
            this.panelTask.Name = "panelTask";
            this.panelTask.Size = new System.Drawing.Size(279, 205);
            this.panelTask.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.labelY);
            this.panel4.Controls.Add(this.textBoxY);
            this.panel4.Controls.Add(this.labelR);
            this.panel4.Controls.Add(this.textBoxR);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.speedBar1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(8, 594);
            this.panel4.Name = "panel4";
            this.panel4.Radius = 10;
            this.panel4.Size = new System.Drawing.Size(279, 159);
            this.panel4.TabIndex = 3;
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelY.Location = new System.Drawing.Point(3, 90);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(25, 26);
            this.labelY.TabIndex = 3;
            this.labelY.Text = "Y";
            this.labelY.Visible = false;
            // 
            // textBoxY
            // 
            this.textBoxY.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxY.Location = new System.Drawing.Point(29, 90);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(38, 27);
            this.textBoxY.TabIndex = 2;
            this.textBoxY.Text = "30";
            this.textBoxY.Visible = false;
            // 
            // labelR
            // 
            this.labelR.AutoSize = true;
            this.labelR.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelR.Location = new System.Drawing.Point(3, 57);
            this.labelR.Name = "labelR";
            this.labelR.Size = new System.Drawing.Size(26, 26);
            this.labelR.TabIndex = 3;
            this.labelR.Text = "R";
            this.labelR.Visible = false;
            // 
            // textBoxR
            // 
            this.textBoxR.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxR.Location = new System.Drawing.Point(29, 57);
            this.textBoxR.Name = "textBoxR";
            this.textBoxR.Size = new System.Drawing.Size(38, 27);
            this.textBoxR.TabIndex = 2;
            this.textBoxR.Text = "30";
            this.textBoxR.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "設備稼動率";
            this.label1.Visible = false;
            // 
            // speedBar1
            // 
            this.speedBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.speedBar1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.speedBar1.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.speedBar1.IsAdjustment = false;
            this.speedBar1.Location = new System.Drawing.Point(56, 14);
            this.speedBar1.Name = "speedBar1";
            this.speedBar1.NowPercentage = 0;
            this.speedBar1.PercentageSafe = 20;
            this.speedBar1.PercentageWarn = 60;
            this.speedBar1.RatioInnerCircle = 23;
            this.speedBar1.RatioLabelHeight = 22;
            this.speedBar1.RatioPinLength = 28;
            this.speedBar1.Reverse = true;
            this.speedBar1.RingColor = System.Drawing.Color.DarkGray;
            this.speedBar1.Size = new System.Drawing.Size(148, 148);
            this.speedBar1.TabIndex = 0;
            // 
            // deviceName
            // 
            this.deviceName.BackColor = System.Drawing.Color.White;
            this.deviceName.Controls.Add(this.tBoxDeviceName);
            this.deviceName.Controls.Add(this.DeviceNamelabel);
            this.deviceName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deviceName.Location = new System.Drawing.Point(8, 318);
            this.deviceName.Name = "deviceName";
            this.deviceName.Radius = 10;
            this.deviceName.Size = new System.Drawing.Size(279, 59);
            this.deviceName.TabIndex = 1;
            // 
            // tBoxDeviceName
            // 
            this.tBoxDeviceName.Location = new System.Drawing.Point(24, 3);
            this.tBoxDeviceName.Name = "tBoxDeviceName";
            this.tBoxDeviceName.Size = new System.Drawing.Size(106, 20);
            this.tBoxDeviceName.TabIndex = 1;
            this.tBoxDeviceName.Visible = false;
            // 
            // DeviceNamelabel
            // 
            this.DeviceNamelabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceNamelabel.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DeviceNamelabel.Location = new System.Drawing.Point(0, 0);
            this.DeviceNamelabel.Name = "DeviceNamelabel";
            this.DeviceNamelabel.Size = new System.Drawing.Size(279, 59);
            this.DeviceNamelabel.TabIndex = 0;
            this.DeviceNamelabel.Text = "label1";
            this.DeviceNamelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deviceImg
            // 
            this.deviceImg.BackColor = System.Drawing.Color.White;
            this.deviceImg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deviceImg.BackgroundImage")));
            this.deviceImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.deviceImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deviceImg.Location = new System.Drawing.Point(8, 139);
            this.deviceImg.Name = "deviceImg";
            this.deviceImg.Radius = 10;
            this.deviceImg.Size = new System.Drawing.Size(279, 173);
            this.deviceImg.TabIndex = 0;
            // 
            // panelFlow
            // 
            this.panelFlow.BackColor = System.Drawing.Color.White;
            this.panelFlow.Controls.Add(this.richTextBox1);
            this.panelFlow.Controls.Add(this.LabelFlow);
            this.panelFlow.Controls.Add(this.flowView1);
            this.panelFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFlow.Location = new System.Drawing.Point(8, 8);
            this.panelFlow.Name = "panelFlow";
            this.panelFlow.Radius = 10;
            this.panelFlow.Size = new System.Drawing.Size(279, 125);
            this.panelFlow.TabIndex = 5;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(11, 21);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(81, 81);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // LabelFlow
            // 
            this.LabelFlow.AutoSize = true;
            this.LabelFlow.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LabelFlow.Location = new System.Drawing.Point(7, 7);
            this.LabelFlow.Name = "LabelFlow";
            this.LabelFlow.Size = new System.Drawing.Size(86, 24);
            this.LabelFlow.TabIndex = 1;
            this.LabelFlow.Text = "生產次序";
            this.LabelFlow.Visible = false;
            // 
            // flowView1
            // 
            this.flowView1.Location = new System.Drawing.Point(81, 37);
            this.flowView1.Margin = new System.Windows.Forms.Padding(4);
            this.flowView1.Name = "flowView1";
            this.flowView1.Size = new System.Drawing.Size(117, 76);
            this.flowView1.TabIndex = 0;
            // 
            // deviceInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "deviceInfoView";
            this.Size = new System.Drawing.Size(295, 759);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.deviceName.ResumeLayout(false);
            this.deviceName.PerformLayout();
            this.panelFlow.ResumeLayout(false);
            this.panelFlow.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelTask;
        private System.Windows.Forms.TextBox tBoxDeviceName;
        private System.Windows.Forms.Label DeviceNamelabel;
        private SpeedBar speedBar1;
        private flowView flowView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LabelFlow;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.Label labelR;
        private System.Windows.Forms.TextBox textBoxR;
        private myPanel panel4;
        private myPanel deviceImg;
        private myPanel deviceName;
        private myPanel panelFlow;
    }
}
