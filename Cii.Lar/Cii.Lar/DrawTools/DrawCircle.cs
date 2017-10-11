using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Cii.Lar.UI;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Cii.Lar.DrawTools
{
    /// <summary>
    /// Draw hollow donut graphic
    /// Author:Zhong Wen 2017/07/27
    /// </summary>
    public class DrawCircle : DrawObject
    {
        private Timer timer;

        private int index = 1;
        private int seperatorAngle = 5;

        private int numberOfArcs;
        public int NumberOfArcs
        {
            get { return numberOfArcs; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Value must be greater than zero");
                }
                if ((360 % value) != 0)
                {
                    throw new ArgumentException("360 should be divisible by NumberOfArcs property. 360 is not divisible by " + 
                        value.ToString());
                }
                if (value != this.numberOfArcs)
                {
                    this.numberOfArcs = value;
                }
            }
        }

        private int ringThickness;
        public int RingThickness
        {
            get { return ringThickness; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Value must be greater than zero");
                }
                // Value cannot be bigger than the rectanle.
                int limit = Math.Min((int)this.OutterCircle.Rectangle.Width, (int)this.OutterCircle.Rectangle.Height) / 2;
                if (value >= limit)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Value must be smaller than {0} for this size, {1}", 
                        limit, this.OutterCircle.Rectangle.ToString()));
                }

                if (value != ringThickness)
                {
                    this.ringThickness = value;
                }
            }
        }

        private Color ringColor;
        public Color RingColor
        {
            get
            {
                if (ringColor == Color.Empty)
                {
                    return Color.White;
                }
                return ringColor;
            }
            set
            {
                ringColor = value;
            }
        }

        private Color foreColor;
        public Color ForeColor
        {
            get
            {
                if (foreColor == Color.Empty)
                {
                    return Color.White;
                }
                return foreColor;
            }
            set
            {
                foreColor = value;
            }
        }

        private int numberOfTail;
        public int NumberOfTail
        {
            get { return numberOfTail; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Value can not be zero");
                }
                if (value != numberOfTail)
                {
                    numberOfTail = value;
                }
            }
        }

        public int Interval
        {
            get
            {
                return this.timer.Interval;
            }
            set
            {
                this.timer.Interval = value;
            }
        }

        private int PieAngle
        {
            get
            {
                // value is the pie that will be drawn and the seperator angle
                int angleOfPieWithSeperator = 360 / this.NumberOfArcs;

                // This is the pie that will be drawn to the client
                int pieAngle = angleOfPieWithSeperator - this.seperatorAngle;

                return pieAngle;
            }
        }

        private Circle outterCircle = null;
        public Circle OutterCircle
        {
            get { return outterCircle; }
            private set
            {
                if (value != outterCircle)
                {
                    outterCircle = value;
                }
            }
        }

        private Circle innerCircle = null;
        public Circle InnerCircle
        {
            get { return innerCircle; }
            private set
            {
                if (value != innerCircle)
                {
                    innerCircle = value;
                }
            }
        }
        public PointF CenterPoint
        {
            get;
            set;
        }

        public Size OutterCircleSize { get; set; }

        public Size InnerCircleSize { get; set; }
        public DrawCircle()
        {
            InitializeGraphicsProperties();
            InitializeArcs();
            //InitializeTimer();
            OutterCircleSize = new Size(60, 60);
            InnerCircleSize = new Size(38, 38);
        }

        public DrawCircle(ZWPictureBox pictureBox, PointF centerPoint) : this()
        {
            this.pictureBox = pictureBox;
            CenterPoint = centerPoint;
            this.GraphicsProperties.GraphicsPropertiesChangedHandler += GraphicsPropertiesChangedHandler;
        }

        private void GraphicsPropertiesChangedHandler(DrawObject drawObject, GraphicsProperties graphicsProperties)
        {
            OutterCircleSize = new Size((60 + this.GraphicsProperties.ExclusionSize) * this.GraphicsProperties.TargetSize, 
                (60 + this.GraphicsProperties.ExclusionSize) * this.GraphicsProperties.TargetSize);
            InnerCircleSize = new Size(38 * this.GraphicsProperties.TargetSize, 38 * this.GraphicsProperties.TargetSize);
            OutterCircle = new Circle(CenterPoint, OutterCircleSize);
            InnerCircle = new Circle(CenterPoint, InnerCircleSize);
            pictureBox.GraphicsPropertiesChangedHandler(drawObject, graphicsProperties);
        }

        private void InitializeGraphicsProperties()
        {
            this.GraphicsProperties = GraphicsPropertiesManager.GetPropertiesByName("Circle");
            this.GraphicsProperties.Color = Color.Yellow;
        }

        private void InitializeArcs()
        {
            this.index = 1;
            this.numberOfArcs = 8;
            this.ringThickness = 10;
            this.foreColor = Color.Gold;
            this.ringColor = Color.White;
            this.numberOfTail = 4;
        }

        private void InitializeTimer()
        {
            this.timer = new Timer();
            this.timer.Interval = 150; // Each 150 miliseconds, the progress circle will be drawn again
            this.timer.Tick += new EventHandler(timer_Tick);
            this.timer.Enabled = true;
        }

        /// <summary>
        /// This method draws the static, non-animation part.
        /// </summary>
        /// <param name="grp"></param>
        private void FillEmptyArcs(Graphics grp)
        {
            int startAngle = 0;

            for (int i = 0; i < this.NumberOfArcs; i++)
            {
                this.DrawFilledArc(grp, this.RingColor, startAngle);

                startAngle += this.PieAngle + this.seperatorAngle;
            }
        }

        private void DrawFilledArc(Graphics grp, Color color, int startAngle)
        {
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            RectangleF main = this.OutterCircle.Rectangle;

            // If there is no region to be drawn, then this method terminates itself
            if (main.Width - (2 * this.ringThickness) < 1 || main.Height - (2 * this.ringThickness) <= 1)
                return;

            // Calculates the region that will be filled
            GraphicsPath outerPath = new GraphicsPath();
            outerPath.AddPie(OutterCircle.Rectangle.X, OutterCircle.Rectangle.Y,
                    OutterCircle.Rectangle.Width, OutterCircle.Rectangle.Height, startAngle, this.PieAngle);

            //RectangleF sub = new RectangleF(main.X + this.ringThickness, main.Y + this.ringThickness, main.Width - (2 * this.ringThickness), main.Height - (2 * this.ringThickness));
            GraphicsPath innerPath = new GraphicsPath();
            innerPath.AddPie(OutterCircle.Rectangle.X + this.ringThickness, OutterCircle.Rectangle.Y + this.ringThickness,
                    OutterCircle.Rectangle.Width - (2 * this.ringThickness), OutterCircle.Rectangle.Height - (2 * this.ringThickness), startAngle - 1, this.PieAngle + 2);

            Region mainRegion = new Region(outerPath);
            Region subRegion = new Region(innerPath);
            mainRegion.Exclude(subRegion);

            // Fill that region
            grp.FillRegion(new SolidBrush(color), mainRegion);
        }

        /// <summary>
        /// Draws the animation part
        /// </summary>
        private void FillPieAndTail()
        {
            Color color = this.ForeColor;

            for (int i = 0; i <= this.NumberOfTail; i++)
            {
                this.FillPieAccordingToTheIndex(this.index - i, color);

                // If there is tail, then the tail color is the lighter of the ForeColor
                color = ControlPaint.Light(color);
            }

            // Background Pie
            this.FillPieAccordingToTheIndex(this.index - (this.NumberOfTail + 1), this.RingColor);
        }

        private void FillPieAccordingToTheIndex(int index, Color color)
        {
            int count = index % this.NumberOfArcs;
            int angle = count * (this.PieAngle + this.seperatorAngle);

            using (Graphics grp = this.pictureBox.CreateGraphics())
            {
                grp.SmoothingMode = SmoothingMode.HighQuality;
                this.DrawFilledArc(grp, color, angle);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.ChangeIndex();
        }
        private void ChangeIndex()
        {
            // Fills the animation part
            this.FillPieAndTail();

            // After the invocation of this method, index is changed. So at another invocation of this method, next pie will be drawn
            this.index = (this.index + 1) % this.NumberOfArcs;
        }

        public override void Draw(Graphics g, ZWPictureBox pictureBox)
        {
            if (OutterCircle == null)
            {
                OutterCircle = new Circle(CenterPoint, OutterCircleSize);
            }
            if (InnerCircle == null)
            {
                InnerCircle = new Circle(CenterPoint, InnerCircleSize);
            }
            //path for the outer and inner circles
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath path = new GraphicsPath())
            using (SolidBrush brush = new SolidBrush(this.GraphicsProperties.Color))
            {
                path.AddEllipse(OutterCircle.Rectangle.X, OutterCircle.Rectangle.Y,
                    OutterCircle.Rectangle.Width, OutterCircle.Rectangle.Height);
                path.AddEllipse(InnerCircle.Rectangle.X, InnerCircle.Rectangle.Y,
                    InnerCircle.Rectangle.Width, InnerCircle.Rectangle.Height);
                g.FillPath(brush, path);
            }

            //// Fill static ring part
            //this.FillEmptyArcs(g);

            //// Fill animation part
            //this.FillPieAndTail();
        }


        /// <summary>
        /// Get handle point by 1-based number
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public override Point GetHandle(ZWPictureBox pictureBox, int handleNumber)
        {
            float x = 0, y = 0, xCenter, yCenter;

            RectangleF rect = outterCircle.Rectangle;
            xCenter = rect.X + rect.Width / 2;
            yCenter = rect.Y + rect.Height / 2;

            switch (handleNumber)
            {
                case 1:
                    x = rect.X;
                    y = yCenter;
                    break;
                case 2:
                    x = xCenter;
                    y = rect.Y;
                    break;
                case 3:
                    x = rect.Right;
                    y = yCenter;
                    break;
                case 4:
                    x = xCenter;
                    y = rect.Bottom;
                    break;
            }

            PointF[] pts = new PointF[1];
            pts[0] = new PointF(x, y);

            return Point.Round(pts[0]);
        }

        public override bool HitTest(int nIndex, PointF dataPoint)
        {
            throw new NotImplementedException();
        }

        public override HitTestResult HitTestForSelection(ZWPictureBox pictureBox, Point point)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get number of handles
        /// </summary>
        public override int HandleCount
        {
            get
            {
                return 4;
            }
        }
    }
}
