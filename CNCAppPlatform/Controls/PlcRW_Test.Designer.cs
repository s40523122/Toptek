namespace CNCAppPlatform
{
    partial class PlcRW_Test
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
            this.isRead = new System.Windows.Forms.CheckBox();
            this.rateLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.writeBtn = new System.Windows.Forms.Button();
            this.dataMsg = new System.Windows.Forms.TextBox();
            this.dName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // isRead
            // 
            this.isRead.AutoSize = true;
            this.isRead.Location = new System.Drawing.Point(13, 13);
            this.isRead.Name = "isRead";
            this.isRead.Size = new System.Drawing.Size(52, 17);
            this.isRead.TabIndex = 12;
            this.isRead.Text = "Read";
            this.isRead.UseVisualStyleBackColor = true;
            // 
            // rateLabel
            // 
            this.rateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rateLabel.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rateLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rateLabel.Location = new System.Drawing.Point(156, 15);
            this.rateLabel.Name = "rateLabel";
            this.rateLabel.Size = new System.Drawing.Size(46, 15);
            this.rateLabel.TabIndex = 10;
            this.rateLabel.Text = "-- ms";
            this.rateLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(102, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "更新頻率";
            // 
            // writeBtn
            // 
            this.writeBtn.AutoSize = true;
            this.writeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.writeBtn.Location = new System.Drawing.Point(67, 174);
            this.writeBtn.Name = "writeBtn";
            this.writeBtn.Size = new System.Drawing.Size(75, 30);
            this.writeBtn.TabIndex = 9;
            this.writeBtn.Text = "Write";
            this.writeBtn.UseVisualStyleBackColor = true;
            // 
            // dataMsg
            // 
            this.dataMsg.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataMsg.Location = new System.Drawing.Point(115, 105);
            this.dataMsg.Name = "dataMsg";
            this.dataMsg.Size = new System.Drawing.Size(82, 35);
            this.dataMsg.TabIndex = 7;
            this.dataMsg.Text = "0";
            // 
            // dName
            // 
            this.dName.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dName.Location = new System.Drawing.Point(96, 45);
            this.dName.Name = "dName";
            this.dName.Size = new System.Drawing.Size(82, 35);
            this.dName.TabIndex = 8;
            this.dName.Text = "D0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(13, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 27);
            this.label2.TabIndex = 5;
            this.label2.Text = "資料內容";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(13, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "暫存器";
            // 
            // PlcRW_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.isRead);
            this.Controls.Add(this.rateLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.writeBtn);
            this.Controls.Add(this.dataMsg);
            this.Controls.Add(this.dName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PlcRW_Test";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(224, 228);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox isRead;
        private System.Windows.Forms.Label rateLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button writeBtn;
        private System.Windows.Forms.TextBox dataMsg;
        private System.Windows.Forms.TextBox dName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
