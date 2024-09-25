using CNCAppPlatform.APS;
using Messages.sensor_msgs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNCAppPlatform.Controls
{
    public partial class GanttChartForm : Form
    {
        private List<Machine> machines; // 用於儲存機台的排程
        private DateTime selectedDate = DateTime.Today; // 選定的日期
        private enum TimeUnit { Day, Week, Month, Season, Year }; // 新增「季」和「年」選項
        private TimeUnit currentUnit = TimeUnit.Day; // 預設為日單位
        //private MonthCalendar monthCalendar; // 月曆元件
        private ToolTip toolTip1;
        private List<Control> schedule_bars = new List<Control>();

        public GanttChartForm(List<Machine> machines)
        {
            InitializeComponent();
            this.machines = machines;

            
            // 創建ToolTip物件
            toolTip1 = new ToolTip();

            // 設定 ToolTip 的屬性
            toolTip1.AutoPopDelay = 360000;   // 當顯示時持續的時間 (毫秒)
            toolTip1.InitialDelay = 100;   // 滑鼠停留在控件上時等待的時間 (毫秒)
            toolTip1.ReshowDelay = 500;     // 當滑鼠再次懸停時重新顯示的延遲時間 (毫秒)
            toolTip1.ShowAlways = true;     // 即使窗體不活動也顯示 ToolTip

            // 將 ToolTip 關聯到控件
            //toolTip1.SetToolTip(this.panel1, "這是一個按鈕\n有第二行嗎");
            //toolTip1.SetToolTip(this.textBox1, "這是一個文字框");


            // 添加 DateTimePicker 元件
            DateTimePicker dateTimePicker = new DateTimePicker() { Margin = new Padding(3, 20, 3, 3) };
            dateTimePicker.Format = DateTimePickerFormat.Short;  // 設置日期格式為短格式 (MM/DD/YYYY)
            dateTimePicker.Location = new Point(20, 400);
            dateTimePicker.ValueChanged += DateTimePicker_ValueChanged;  // 綁定日期變更事件
            

            // 添加按鈕
            Button dayButton = new Button() { Text = "日", Location = new Point(20, 350), Size = new Size(55, 55) };
            Button weekButton = new Button() { Text = "周", Location = new Point(100, 350), Size = new Size(55, 55) };
            Button monthButton = new Button() { Text = "月", Location = new Point(180, 350), Size = new Size(55, 55) };
            Button quarterButton = new Button() { Text = "季", Location = new Point(260, 350), Size = new Size(55, 55) };
            Button yearButton = new Button() { Text = "年", Location = new Point(340, 350), Size = new Size(55, 55) };

            dayButton.Click += (sender, e) => { currentUnit = TimeUnit.Day; panel1.Invalidate(); };
            weekButton.Click += (sender, e) => { currentUnit = TimeUnit.Week; panel1.Invalidate(); };
            monthButton.Click += (sender, e) => { currentUnit = TimeUnit.Month; panel1.Invalidate(); };
            quarterButton.Click += (sender, e) => { currentUnit = TimeUnit.Season; panel1.Invalidate(); };
            yearButton.Click += (sender, e) => { currentUnit = TimeUnit.Year; panel1.Invalidate(); };

            flowLayoutPanel1.Controls.Add(dayButton);
            flowLayoutPanel1.Controls.Add(weekButton);
            flowLayoutPanel1.Controls.Add(monthButton);
            flowLayoutPanel1.Controls.Add(quarterButton);
            flowLayoutPanel1.Controls.Add(yearButton);
            flowLayoutPanel1.Controls.Add(dateTimePicker);

            panel1.Paint += new PaintEventHandler(GanttChart_Paint);
        }


        // 月曆元件選擇日期事件
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker picker = sender as DateTimePicker;
            selectedDate = picker.Value; // 更新選定日期
            panel1.Invalidate(); // 重新繪製甘特圖
        }

        private DateTime GetChartStartTime()
        {
            switch (currentUnit)
            {
                case TimeUnit.Day:
                    return selectedDate.Date; // 當天凌晨 0 點
                case TimeUnit.Week:
                    return selectedDate.AddDays(-(int)selectedDate.DayOfWeek).Date; // 這周的星期日
                case TimeUnit.Month:
                    return new DateTime(selectedDate.Year, selectedDate.Month, 1); // 當月1號
                case TimeUnit.Season:
                    int quarterStartMonth = ((selectedDate.Month - 1) / 3) * 3 + 1;
                    return new DateTime(selectedDate.Year, quarterStartMonth, 1); // 所在季的1號
                case TimeUnit.Year:
                    return new DateTime(selectedDate.Year, 1, 1); // 當年1月1日
                default:
                    return selectedDate.Date; // 默認當天凌晨 0 點
            }
        }

        // 定義一組顏色
        private readonly Color[] colors = new Color[]
        {
        Color.Pink, Color.LightSkyBlue, Color.Green, Color.Brown, Color.Purple,
        Color.Orange, Color.Cyan, Color.Magenta, Color.Lime
        };

        private void GanttChart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int machineHeight = 40;
            int startX = 100;
            int startY = 20;

            // 根據當前選定的時間單位來確定顯示範圍和時間軸分隔
            DateTime chartStartTime = GetChartStartTime();
            TimeSpan unitDuration = TimeSpan.FromHours(4); // 預設為「日」單位4小時一格

            // 設定每個單位的範圍與格數
            int totalSegments = 6; // 預設為6格（24小時內分6格，每格4小時）
            switch (currentUnit)
            {
                case TimeUnit.Day:
                    unitDuration = TimeSpan.FromHours(4);
                    totalSegments = 6; // 24小時分6格，每格4小時
                    break;
                case TimeUnit.Week:
                    unitDuration = TimeSpan.FromDays(1);
                    totalSegments = 7; // 7天，每天一格
                    break;
                case TimeUnit.Month:
                    unitDuration = TimeSpan.FromDays(7);
                    totalSegments = 5; // 30天分5格，每格1周
                    break;
                case TimeUnit.Season:
                    unitDuration = TimeSpan.FromDays(30);
                    totalSegments = 3; // 3個月，每個月一格
                    break;
                case TimeUnit.Year:
                    unitDuration = TimeSpan.FromDays(90); // 每格一季
                    totalSegments = 4; // 4個季度
                    break;
            }

            // 計算每個格的寬度，並自適應視窗大小
            int chartWidth = this.ClientSize.Width - startX - 20;
            double segmentWidth = (double)chartWidth / totalSegments;

            // 繪製時間軸
            for (int i = 0; i < totalSegments; i++)
            {
                int xPosition = startX + (int)(i * segmentWidth);
                g.DrawLine(Pens.Black, xPosition, startY, xPosition, startY + machines.Count * machineHeight);

                // 根據當前單位顯示不同的時間標籤
                string timeLabel = "";
                if (currentUnit == TimeUnit.Day)
                {
                    timeLabel = chartStartTime.AddHours(i * 4).ToString("HH:mm"); // 每格4小時
                }
                else if (currentUnit == TimeUnit.Week)
                {
                    timeLabel = chartStartTime.AddDays(i).ToString("MM/dd"); // 每天
                }
                else if (currentUnit == TimeUnit.Month)
                {
                    timeLabel = chartStartTime.AddDays(i * 7).ToString("MM/dd"); // 每周
                }
                else if (currentUnit == TimeUnit.Season)
                {
                    timeLabel = chartStartTime.AddMonths(i).ToString("MMM"); // 每月顯示月份
                }
                else if (currentUnit == TimeUnit.Year)
                {
                    timeLabel = $"Q{i + 1}"; // 每季度顯示 Q1, Q2...
                }

                g.DrawString(timeLabel, this.Font, Brushes.Black, xPosition, startY - 20);
            }

            schedule_bars.Clear();

            // 繪製機台排程
            foreach (var machine in machines)
            {
                g.DrawString(machine.machine_id.ToString(), this.Font, Brushes.Black, 10, startY + machines.IndexOf(machine) * machineHeight);

                Dictionary<int, Brush> jobColors = new Dictionary<int, Brush>();

                foreach (var schedule in machine.schedule)
                {
                    Job job = schedule.job;
                    int processIndex = schedule.processIndex;
                    Process process = job.processes[processIndex];

                    TimeSpan processDuration = (TimeSpan)(process.end_time - process.start_time);

                    // 將時間轉換為當前單位的長度
                    int barStartX = startX + (int)((process.start_time.Value - chartStartTime).TotalHours / unitDuration.TotalHours * segmentWidth);
                    int barWidth = (int)((processDuration.TotalHours / unitDuration.TotalHours) * segmentWidth);

                    if (int.TryParse(job.order_no, out int iorder_no))
                    {
                        if (!jobColors.ContainsKey(iorder_no))
                        {
                            jobColors[iorder_no] = new SolidBrush(colors[iorder_no % colors.Length]);
                        }

                        //g.FillRectangle(jobColors[iorder_no], barStartX, startY + machines.IndexOf(machine) * machineHeight + 10, barWidth, 20);
                        //g.DrawRectangle(Pens.Black, barStartX, startY + machines.IndexOf(machine) * machineHeight + 10, barWidth, 20);

                        

                        DateTime dueTime = job.due_date;
                        if (process.end_time > dueTime)
                        {
                            // 若開始時間晚於交期，起點設為開始時間
                            dueTime = process.start_time > dueTime ? (DateTime)process.start_time : dueTime;
                            
                            // 當超過交期時間，將交期後的部分顯示為紅色斜線
                            TimeSpan timeOverdue = (TimeSpan)(process.end_time - dueTime);

                            int dueTimeX = startX + (int)(((DateTime)dueTime - chartStartTime).TotalHours / unitDuration.TotalHours * segmentWidth);
                            int overdueBarWidth = (int)((timeOverdue.TotalHours / unitDuration.TotalHours) * segmentWidth);
                            int onTimeBarWidth = barWidth - overdueBarWidth;

                            //g.FillRectangle(Brushes.Red, dueTimeX+2, startY + machines.IndexOf(machine) * machineHeight + 23, overdueBarWidth-2, 6); // 超過交期的紅色進度條
                        }
                        //g.DrawString($"Job {job.order_no} (P{process.process_id})", this.Font, Brushes.White, barStartX + 5, startY + machines.IndexOf(machine) * machineHeight + 10);

                        ProcessBar process_bar = new ProcessBar(barWidth, job, processIndex) { BackColor = colors[iorder_no], Location = new Point(barStartX, startY + machines.IndexOf(machine) * machineHeight + 15) };
                        schedule_bars.Add(process_bar);
                    }
                }
            }

            // 繪製當前時間的垂直紅線
            DateTime now = DateTime.Now;
            if (now >= chartStartTime)
            {
                double elapsedHours = (now - chartStartTime).TotalHours;
                int currentTimeX = startX + (int)((elapsedHours / unitDuration.TotalHours) * segmentWidth);
                g.DrawLine(new Pen(Color.Red, 2), currentTimeX, startY, currentTimeX, startY + machines.Count * machineHeight);
            }

            // 新增流程條
            ShowScheduleBar();
        }

        public void ShowScheduleBar()
        {
            //　清空時程表
            panel1.Controls.Clear();

            panel1.Update();

            panel1.Controls.AddRange(schedule_bars.ToArray());
            foreach (ProcessBar processBar in schedule_bars)
            {
                toolTip1.SetToolTip(processBar, processBar.Describe);
            }
            
        }

    }

    public partial class ProcessBar : Panel
    {
        public bool IsLight
        {
            set
            {
                //_isLight = value;
            }
        }

        private string _describe = "";
        public string Describe { get { return _describe; } private set { _describe = value; } }

        public ProcessBar(int _width, Job job, int process_index)
        {
            Width = _width;
            Height = 20;
            Process _process = job.processes[process_index];
            this.Describe = $"工單編號: {job.order_no}\n" +
                            $"製程編號: {_process.process_id}\n" +
                            $"製程開始日期: {_process.start_time}\n" +
                            $"製程結束日期: {_process.end_time}\n" +
                            $"交期: {job.due_date}";

            //SizeChanged += LabelLED_SizeChanged;
            Paint += (sender, e) => { ProcessBar_Paint(e, job, _process); };
        }

        private void ProcessBar_Paint(PaintEventArgs e, Job job, Process process)
        {
            Graphics g = e.Graphics;
            DateTime dueTime = job.due_date;

            // 可視化逾期狀態條
            if (process.end_time > dueTime)
            {
                double total_hours = (process.end_time.Value - process.start_time.Value).TotalHours;        // 製程所需時數
                double ontime_hours = (job.due_date - process.start_time.Value).TotalHours;     // 未逾期時數
                ontime_hours = Math.Max(ontime_hours, 0);       // 若交期在開始製程前，未逾期時間為負值，須歸零

                // 將逾期的部分顯示為紅色底線
                g.FillRectangle(Brushes.Red, (float)(Width * ontime_hours / total_hours), (float)(Height*0.7), Width, (float)(Height * 0.3));

            }
            // 顯示基本資訊
            g.DrawString($"Job {job.order_no} (P{process.process_id})", this.Font, Brushes.White, 5, 0);
        }

        private void LabelLED_SizeChanged(object sender, EventArgs e)
        {
            //label1.Font = new Font(label1.Font.FontFamily, Height * 36 / 123, label1.Font.Style); ;
        }
    }
}
