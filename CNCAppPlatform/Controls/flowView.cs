using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Windows.Shapes;


namespace CNCAppPlatform
{
    public partial class flowView : UserControl
    {
        public string D_register = "D0";

        private FlowDot initDot = new FlowDot(Color.DimGray) { DotID = 1 };
        private FlowDescribe initDescribe = new FlowDescribe(){ Text = "--" };
        private List<FlowDot> flowDots = new List<FlowDot>();
        private List<Panel> lines = new List<Panel>() { new Panel() };
        private int parentHeight;

        public flowView()
        {
            InitializeComponent();

            flowDots.Add(initDot);
            Controls.Add(initDot);
            Controls.Add(initDescribe);

            SizeChanged += FlowView_SizeChanged;
            //MouseMove += FlowView_MouseMove;

            PlcRead();
        }

        private void PlcRead()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 200; // 設置計時器間隔為 1000 毫秒 (1 秒)
            timer.Elapsed += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            int no = 1;
            short[] arraydata;
            String[] arrdata;
            arraydata = new short[no];

            _ = Form1.axActUtlType.ReadDeviceBlock2(D_register, no, out arraydata[0]);

            // 這裡一定要 Invoke !!! by正暉(聖貿都沒講)
            Invoke(new MethodInvoker(delegate
            {
                moveDot(arraydata[0]);
            }));
            
            //MessageBox.Show(arraydata[0].ToString());
        }

        Point mousePoint;
        private void FlowView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!mousePoint.IsEmpty)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        this.Left += e.X - mousePoint.X;
                    }
                }
                else
                {
                    this.mousePoint.X = e.X;
                }
            }
            //mousePoint = new Point();
        }

        public void moveDot(int id)
        {
            id ++;
            var dotsAndlines = flowDots.Zip(lines, (f, l) => new { FlowDot = f, Line = l });
            Color color = Color.ForestGreen;
            foreach (var dl in dotsAndlines)
            {
                dl.FlowDot.BackColor = color;
                dl.Line.BackColor = color;

                if (dl.FlowDot.DotID == id)
                {
                    color = Color.Orange;
                    dl.FlowDot.BackColor = color;
                    dl.Line.BackColor = color;
                    Location = new Point((Parent as Panel).Width / 2 - dl.FlowDot.CenterPoint.X, parentHeight);
                    color = Color.DimGray;
                }
            }
        }

        public void AddRange(string[] flows)
        {
            Controls.Clear();
            flowDots.Clear();
            lines.Clear();
            flowDots.Add(initDot);
            Controls.Add(initDot);
            Controls.Add(initDescribe);
            int flowCount = flows.Length;
            int myWidth = (int)(flowCount * (Height * 2.5));

            initDot.CenterPoint = new Point(myWidth / 2 - (int)(Height * 0.4), initDot.CenterPoint.Y);
            //initDot.CenterPoint = new Point(50, initDot.CenterPoint.Y);
            initDescribe.CenterPoint = new Point(initDot.CenterPoint.X, initDot.Bottom);
            initDot.BackColor = Color.Orange;
            initDescribe.Text = flows[0];

            Width = myWidth;

            FlowDot prevDot = initDot;

            for (int i=2; i<= flowCount; i++)
            {
                FlowDot nextDot = new FlowDot(Color.Orange)
                {
                    DotID = i,
                    Size = new Size((int)(Height * 0.3), (int)(Height * 0.3)),
                    CenterPoint = new Point(prevDot.CenterPoint.X + (int)(Height * 1.2), prevDot.CenterPoint.Y),
                    //BorderStyle = BorderStyle.FixedSingle
            };
                flowDots.Add(nextDot);
                Controls.Add(nextDot);

                Panel line = new Panel()
                {
                    Location = new Point(prevDot.Right + 6, prevDot.CenterPoint.Y-3),
                    Width = (int)(Height * 0.7),
                    Height = 6,
                    BackColor = nextDot.BackColor,
                    //BorderStyle = BorderStyle.FixedSingle
                };
                lines.Add(line);
                Controls.Add(line);

                FlowDescribe describe = new FlowDescribe()
                {
                    Width = (int)(Height * 1.2),
                    Height = (int)(Height * 0.6),
                    Text = flows[i - 1],
                    CenterPoint = new Point(nextDot.CenterPoint.X, nextDot.Bottom),
                    //BorderStyle = BorderStyle.FixedSingle
                };
                Controls.Add(describe);

                prevDot = nextDot;
            };
            lines.Add(new Panel());
        }

        bool first = true;
        private void FlowView_SizeChanged(object sender, EventArgs e)
        {
            
            initDot.Size = new Size((int)(Height * 0.3), (int)(Height * 0.3));
            initDot.CenterPoint = new Point(Width/2, Height/5);

            if (first)
            {
                first = false;
                parentHeight = Location.Y;
                
            }
            else
            {
                Location = new Point((Parent as Panel).Width / 2 - initDot.CenterPoint.X, parentHeight);
            }
            initDescribe.Size = new Size((int)(Height * 1.2), (int)(Height));
            initDescribe.CenterPoint = new Point(initDot.CenterPoint.X, initDot.Bottom);
        }
    }

    public partial class FlowDescribe : Label
    {
        public Point CenterPoint
        {
            get { return new Point(Location.X + Width / 2, Location.Y + 0); }
            set
            {
                Point input = (Point)value;
                Location = new Point(input.X - Width/2, input.Y - 0);
            }
        }

        public FlowDescribe()
        {
            AutoSize = false;
            TextAlign = ContentAlignment.TopCenter;
             
            //BorderStyle = BorderStyle.FixedSingle;
            Font = new Font("Microsoft JhengHei", Height/2, FontStyle.Regular);
        }
    }

    public partial class FlowDot : Panel
    {
        int radius; // 圓形的半徑

        public int DotID;   // 流程編號

        public Point CenterPoint
        {
            get { return new Point(Location.X + radius, Location.Y + radius); }
            set
            {
                Point input = (Point)value;
                Location = new Point(input.X - radius, input.Y - radius);
            }
        }

        public FlowDot(Color color)
        {
            BackColor = color;

            SizeChanged += ProgressDot_SizeChanged;
            Paint += ProgressDot_Paint;
        }

        private void ProgressDot_SizeChanged(object sender, EventArgs e)
        {
            radius = Math.Min(Width, Height) / 2; // 圓形的半徑
        }

        private void ProgressDot_Paint(object sender, PaintEventArgs e)
        {
            // 在 Panel 中心位置繪製圓形
            int centerX = Width / 2;
            int centerY = Height / 2;
            

            // 創建 GraphicsPath 並添加圓形
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(ClientRectangle);

            // 將 GraphicsPath 設置為 Panel 的 Region
            Region = new Region(path);

            // 釋放資源
            path.Dispose();
        }

    }
}
