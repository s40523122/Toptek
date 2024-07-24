namespace CNCAppPlatform
{
    partial class PlcControl
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.plcRW_Test1 = new CNCAppPlatform.PlcRW_Test();
            this.plcRW_Test2 = new CNCAppPlatform.PlcRW_Test();
            this.addItemButton1 = new CNCAppPlatform.AddItemButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(30, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1139, 1);
            this.panel2.TabIndex = 36;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.plcRW_Test1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.plcRW_Test2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.addItemButton1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(30, 29);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1139, 217);
            this.tableLayoutPanel1.TabIndex = 39;
            // 
            // plcRW_Test1
            // 
            this.plcRW_Test1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.plcRW_Test1.BackColor = System.Drawing.Color.White;
            this.plcRW_Test1.Location = new System.Drawing.Point(3, 3);
            this.plcRW_Test1.Name = "plcRW_Test1";
            this.plcRW_Test1.Padding = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.plcRW_Test1.Size = new System.Drawing.Size(224, 210);
            this.plcRW_Test1.TabIndex = 37;
            // 
            // plcRW_Test2
            // 
            this.plcRW_Test2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.plcRW_Test2.BackColor = System.Drawing.Color.White;
            this.plcRW_Test2.Location = new System.Drawing.Point(233, 3);
            this.plcRW_Test2.Name = "plcRW_Test2";
            this.plcRW_Test2.Padding = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.plcRW_Test2.Size = new System.Drawing.Size(224, 210);
            this.plcRW_Test2.TabIndex = 37;
            // 
            // addItemButton1
            // 
            this.addItemButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addItemButton1.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.addItemButton1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.addItemButton1.Location = new System.Drawing.Point(464, 4);
            this.addItemButton1.Margin = new System.Windows.Forms.Padding(4);
            this.addItemButton1.Name = "addItemButton1";
            this.addItemButton1.Padding = new System.Windows.Forms.Padding(15, 14, 15, 14);
            this.addItemButton1.Size = new System.Drawing.Size(224, 209);
            this.addItemButton1.TabIndex = 38;
            // 
            // PlcControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1199, 913);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Name = "PlcControl";
            this.Padding = new System.Windows.Forms.Padding(30, 28, 30, 28);
            this.Text = "PlcControl";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private PlcRW_Test plcRW_Test1;
        private PlcRW_Test plcRW_Test2;
        private AddItemButton addItemButton1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}