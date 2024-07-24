namespace CNCAppPlatform
{
    partial class PlcConn
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.addItemButton1 = new CNCAppPlatform.AddItemButton();
            this.plcConnectionBox1 = new CNCAppPlatform.PlcConnectionBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(30, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(954, 1);
            this.panel3.TabIndex = 38;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.addItemButton1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.plcConnectionBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(30, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 269F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 269F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(954, 538);
            this.tableLayoutPanel1.TabIndex = 41;
            // 
            // addItemButton1
            // 
            this.addItemButton1.BackColor = System.Drawing.SystemColors.Control;
            this.addItemButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addItemButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addItemButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addItemButton1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.addItemButton1.Location = new System.Drawing.Point(18, 286);
            this.addItemButton1.Margin = new System.Windows.Forms.Padding(18, 17, 18, 17);
            this.addItemButton1.Name = "addItemButton1";
            this.addItemButton1.Padding = new System.Windows.Forms.Padding(50, 10, 50, 10);
            this.addItemButton1.Size = new System.Drawing.Size(918, 235);
            this.addItemButton1.TabIndex = 39;
            this.addItemButton1.Click += new System.EventHandler(this.addItemButton1_Click);
            // 
            // plcConnectionBox1
            // 
            this.plcConnectionBox1.CheckStatus = false;
            this.plcConnectionBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plcConnectionBox1.IpAddress = "192.168.32.20";
            this.plcConnectionBox1.IsDefaultGroup = true;
            this.plcConnectionBox1.Location = new System.Drawing.Point(3, 3);
            this.plcConnectionBox1.LogicalStationNumber = 1;
            this.plcConnectionBox1.Name = "plcConnectionBox1";
            this.plcConnectionBox1.Size = new System.Drawing.Size(948, 263);
            this.plcConnectionBox1.TabIndex = 40;
            // 
            // PlcConn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1014, 611);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel3);
            this.Name = "PlcConn";
            this.Padding = new System.Windows.Forms.Padding(30);
            this.Text = "PlcConn";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private AddItemButton addItemButton1;
        private PlcConnectionBox plcConnectionBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}