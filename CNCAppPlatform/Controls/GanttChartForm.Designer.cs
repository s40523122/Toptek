namespace CNCAppPlatform.Controls
{
    partial class GanttChartForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.focus_label = new System.Windows.Forms.Label();
            this.aps_start_label = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 295);
            this.panel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.flowLayoutPanel1.Controls.Add(this.focus_label);
            this.flowLayoutPanel1.Controls.Add(this.aps_start_label);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 88);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // focus_label
            // 
            this.focus_label.AutoSize = true;
            this.focus_label.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.focus_label.Location = new System.Drawing.Point(13, 20);
            this.focus_label.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.focus_label.Name = "focus_label";
            this.focus_label.Size = new System.Drawing.Size(86, 17);
            this.focus_label.TabIndex = 0;
            this.focus_label.Text = "選擇聚焦日期";
            // 
            // aps_start_label
            // 
            this.aps_start_label.AutoSize = true;
            this.aps_start_label.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.aps_start_label.Location = new System.Drawing.Point(13, 47);
            this.aps_start_label.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.aps_start_label.Name = "aps_start_label";
            this.aps_start_label.Size = new System.Drawing.Size(99, 17);
            this.aps_start_label.TabIndex = 0;
            this.aps_start_label.Text = "選擇排程開始日";
            // 
            // GanttChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 383);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "GanttChartForm";
            this.Text = "GanttChartForm";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label focus_label;
        private System.Windows.Forms.Label aps_start_label;
    }
}