using Cii.Lar.DrawTools;
using Cii.Lar.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cii.Lar.Laser
{
    public class ActiveCircle
    {
        /// <summary>
        /// GraphicsPropertiesManager: include all the draw object graphics properties
        /// </summary>
        private GraphicsPropertiesManager graphicsPropertiesManager = GraphicsPropertiesManager.GraphicsManagerSingleInstance();
        public GraphicsPropertiesManager GraphicsPropertiesManager
        {
            get
            {
                return graphicsPropertiesManager;
            }
            set
            {
                graphicsPropertiesManager = value;
            }
        }

        /// <summary>
        /// GraphicsProperties of this draw object 
        /// </summary>
        private GraphicsProperties graphicsProperties;
        public GraphicsProperties GraphicsProperties
        {
            get
            {
                return graphicsProperties;
            }
            set
            {
                graphicsProperties = value;
            }
        }

        private Point startPoint;
        public Point StartPoint
        {
            get { return startPoint; }
            set
            {
                if (value != Point.Empty)
                {
                    if (clickCount % 2 == 1)
                    {
                        startPoint = value;
                        StartCircle = new Circle(value, InnerCircleSize);
                    }
                }
            }
        }

        private Point endPoint;
        public Point EndPoint
        {
            get { return this.endPoint; }
            set
            {
                if (value != Point.Empty && clickCount % 2 != 0)
                {
                    endPoint = value;
                    EndCircle = new Circle(value, InnerCircleSize);
                }
            }
        }

        private Circle startCircle;

        public Circle StartCircle
        {
            get { return this.startCircle; }
            set { this.startCircle = value; }
        }

        private Circle endCircle;

        public Circle EndCircle
        {
            get { return this.endCircle; }
            set { this.endCircle = value; }
        }

        public Size InnerCircleSize { get; set; }
        public Size OutterCircleSize { get; set; }

        private ZWPictureBox pictureBox;

        private int clickCount;

        private List<Circle> innerCircles;
        private List<Circle> outterCircles;

        private List<Circle> realInnerCircles;
        private List<Circle> realOutterCircles;

        private int minHoleNum = 0;
        public int MinHoleNum
        {
            get { return this.minHoleNum; }
            set
            {
                this.minHoleNum = value;
            }
        }

        private int maxHoleNum = 0;
        public int MaxHoleNum
        {
            get { return this.maxHoleNum; }
            set
            {
                this.maxHoleNum = value;
            }
        }

        private int holeNum = 0;
        public int HoleNum
        {
            get { return this.holeNum; }
            set
            {
                this.holeNum = value;
            }
        }

        private bool isMouseUp;
        public bool IsMouseUp
        {
            get { return this.isMouseUp; }
            set
            {
                if (value != this.isMouseUp)
                {
                    this.isMouseUp = value;
                }
            }
        }

        private bool inTheHole;
        public bool InTheHole
        {
            get { return this.inTheHole; }
            set
            {
                if (value != this.inTheHole)
                {
                    this.inTheHole = value;
                }
            }
        }

        private PointF centerPoint;
        public PointF CenterPoint
        {
            get { return this.centerPoint; }
            set { this.centerPoint = value; }
        }

        public ActiveCircle(ZWPictureBox pictureBox)
        {
            IsMouseUp = false;
            InTheHole = false;
            this.pictureBox = pictureBox;
            InitializeGraphicsProperties();
            InnerCircleSize = new Size(38, 38);
            OutterCircleSize = new Size(48, 48);
            clickCount = 0;
            innerCircles = new List<Circle>();
            outterCircles = new List<Circle>();

            realInnerCircles = new List<Circle>();
            realOutterCircles = new List<Circle>();

        }

        private void InitializeGraphicsProperties()
        {
            this.GraphicsProperties = GraphicsPropertiesManager.GetPropertiesByName("Circle");
            this.GraphicsProperties.Color = Color.Yellow;
        }

        public void OnMouseDown(Point point)
        {
            if (!InTheHole)
            {
                IsMouseUp = false;
                clickCount++;
                StartPoint = point;
                EndPoint = point;
            }
        }

        public void OnMouseMove(Point point, int dx, int dy)
        {
            if (!IsMouseUp)
            {
                EndPoint = point;
                CalculateContinuousCircle(dx, dy);
            }
            else
            {
                if (!CenterPoint.IsEmpty)
                {
                    RectangleF rect = new RectangleF(CenterPoint, OutterCircleSize);
                    InTheHole = rect.Contains(point);
                    if (InTheHole)
                    {
                        MoveToArc();
                    }
                }
            }
        }

        public void OnMouseUp()
        {
            if (clickCount % 2 == 0)
            {
                if (!InTheHole)
                {
                    IsMouseUp = true;
                }
            }
        }

        private void MoveToArc()
        {

        }

        /// <summary>
        /// L/D + 1 < N < 2L/D + 2
        /// L:Line length
        /// D:Circle diameter
        /// N:Number of holes
        /// holeNum: all the active number of circle
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        private void CalculateContinuousCircle(int dx, int dy)
        {
            if (startCircle == null || endCircle == null)
            {
                return;
            }
            var length = Math.Sqrt(dx * dx + dy * dy);


            minHoleNum = (int) (length / InnerCircleSize.Width) + 1;
            maxHoleNum = (int)(2 * length / InnerCircleSize.Width) + 2;
            realInnerCircles.Clear();
            realOutterCircles.Clear();

            if (minHoleNum == 1)
            {
                realInnerCircles.Add(startCircle);
                realOutterCircles.Add(new Circle(startPoint, OutterCircleSize));
                realInnerCircles.Add(endCircle);
                realOutterCircles.Add(new Circle(endPoint, OutterCircleSize));
                return;
            }
            else
            {
                holeNum = maxHoleNum;
                var gap = length / holeNum;
                innerCircles.Clear();
                outterCircles.Clear();
                if (dx == 0)
                {
                    if (dy > 0)
                    {
                        for (int i= 0; i < holeNum; i ++)
                        {
                            innerCircles.Add(new Circle(new PointF(StartCircle.CenterPoint.X, (float)(StartCircle.CenterPoint.Y + gap * i)), InnerCircleSize));
                            outterCircles.Add(new Circle(new PointF(StartCircle.CenterPoint.X, (float)(StartCircle.CenterPoint.Y + gap * i)), OutterCircleSize));
                        }
                        CenterPoint = new PointF(StartCircle.CenterPoint.X, StartCircle.CenterPoint.Y + dy / 2);
                    }
                    else if (dy < 0)
                    {
                        for (int i = 0; i < holeNum; i++)
                        {
                            innerCircles.Add(new Circle(new PointF(StartCircle.CenterPoint.X, (float)(StartCircle.CenterPoint.Y - gap * i)), InnerCircleSize));
                            outterCircles.Add(new Circle(new PointF(StartCircle.CenterPoint.X, (float)(StartCircle.CenterPoint.Y - gap * i)), OutterCircleSize));
                        }
                        CenterPoint = new PointF(StartCircle.CenterPoint.X, StartCircle.CenterPoint.Y - dy / 2);
                    }
                }
                else if (dy == 0)
                {
                    if (dx > 0)
                    {
                        for (int i = 0; i < holeNum; i++)
                        {
                            innerCircles.Add(new Circle(new PointF((int)(StartCircle.CenterPoint.X + gap * i), StartCircle.CenterPoint.Y), InnerCircleSize));
                            outterCircles.Add(new Circle(new PointF((int)(StartCircle.CenterPoint.X + gap * i), StartCircle.CenterPoint.Y), OutterCircleSize));
                        }
                        CenterPoint = new PointF(StartCircle.CenterPoint.X + dx / 2, StartCircle.CenterPoint.Y);
                    }
                    else if (dx < 0)
                    {
                        for (int i = 0; i < holeNum; i++)
                        {
                            innerCircles.Add(new Circle(new PointF((int)(StartCircle.CenterPoint.X - gap * i), StartCircle.CenterPoint.Y), InnerCircleSize));
                            outterCircles.Add(new Circle(new PointF((int)(StartCircle.CenterPoint.X - gap * i), StartCircle.CenterPoint.Y), OutterCircleSize));
                        }
                        CenterPoint = new PointF(StartCircle.CenterPoint.X - dx / 2, StartCircle.CenterPoint.Y);
                    }
                }
                else
                {
                    var k = dy / dx;
                    var xGap = (endCircle.CenterPoint.X - startCircle.CenterPoint.X) / holeNum;
                    var yGap = (endCircle.CenterPoint.Y - startCircle.CenterPoint.Y) / holeNum;
                    for (int i = 0; i < holeNum; i++)
                    {
                        var x = (float)(StartCircle.CenterPoint.X + i * xGap);
                        var y = (float)(StartCircle.CenterPoint.Y + i * yGap);
                        innerCircles.Add(new Circle(new PointF(x, y), InnerCircleSize));
                        outterCircles.Add(new Circle(new PointF(x, y), OutterCircleSize));
                    }
                    CenterPoint = new PointF(StartCircle.CenterPoint.X + dx / 2, StartCircle.CenterPoint.Y + dy / 2);
                }
                for (int i=0; i < holeNum + 2; i++)
                {
                    if (i == 0)
                    {
                        realInnerCircles.Add(startCircle);
                        realOutterCircles.Add(new Circle(startPoint, OutterCircleSize));
                    }
                    else if (i == holeNum + 1)
                    {
                        realInnerCircles.Add(endCircle);
                        realOutterCircles.Add(new Circle(endPoint, OutterCircleSize));
                    }
                    else
                    {
                        realInnerCircles.Add(innerCircles[i - 1]);
                        realOutterCircles.Add(outterCircles[i - 1]);
                    }
                }
            }
        }

        public void OnPaint(Graphics g)
        {
            if (startCircle.CenterPoint.IsEmpty || endCircle.CenterPoint.IsEmpty)
            {
                return;
            }

            DrawCross(g);
        }

        private void DrawCross(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 1f);
            //draw start point cross
            g.DrawLine(pen, startCircle.CenterPoint.X, startCircle.CenterPoint.Y - startCircle.Rectangle.Width / 2,
            startCircle.CenterPoint.X, startCircle.CenterPoint.Y + startCircle.Rectangle.Width / 2);
            g.DrawLine(pen, startCircle.CenterPoint.X - startCircle.Rectangle.Width / 2, startCircle.CenterPoint.Y,
                startCircle.CenterPoint.X + startCircle.Rectangle.Width / 2, startCircle.CenterPoint.Y);

            //draw connect Line
            g.DrawLine(pen, startCircle.CenterPoint, endCircle.CenterPoint);

            //draw center cross point
            if (!CenterPoint.IsEmpty && InTheHole)
            {
                using (Pen centerPen = new Pen(Color.Red, 1f))
                {
                    g.DrawLine(centerPen, CenterPoint.X, CenterPoint.Y - startCircle.Rectangle.Width / 2,
                        CenterPoint.X, CenterPoint.Y + startCircle.Rectangle.Width / 2);
                    g.DrawLine(centerPen, CenterPoint.X - startCircle.Rectangle.Width / 2, CenterPoint.Y,
                        CenterPoint.X + startCircle.Rectangle.Width / 2, CenterPoint.Y);
                }
            }

            //draw multiple circles
            SolidBrush brush = new SolidBrush(this.GraphicsProperties.Color);
            GraphicsPath path1 = new GraphicsPath();
            GraphicsPath path2 = new GraphicsPath();
            Region region1 = new Region();
            Region region2 = new Region();
            for (int i = 0; i < realInnerCircles.Count; i++)
            {
                path1.AddEllipse(realOutterCircles[i].Rectangle.X, realOutterCircles[i].Rectangle.Y,
                    realOutterCircles[i].Rectangle.Width, realOutterCircles[i].Rectangle.Height);

                path2.AddEllipse(realInnerCircles[i].Rectangle.X, realInnerCircles[i].Rectangle.Y,
                    realInnerCircles[i].Rectangle.Width, realInnerCircles[i].Rectangle.Height);
                if (i == 0)
                {
                    region1 = new Region(path1);
                    region2 = new Region(path2);
                }
                region1.Union(new Region(path1));
                region2.Union(new Region(path2));
            }
            region1.Exclude(region2);
            g.FillRegion(brush, region1);

            //draw end point cross
            g.DrawLine(pen, EndCircle.CenterPoint.X, EndCircle.CenterPoint.Y - EndCircle.Rectangle.Width / 2,
                EndCircle.CenterPoint.X, EndCircle.CenterPoint.Y + EndCircle.Rectangle.Width / 2);
            g.DrawLine(pen, EndCircle.CenterPoint.X - EndCircle.Rectangle.Width / 2, EndCircle.CenterPoint.Y,
                EndCircle.CenterPoint.X + EndCircle.Rectangle.Width / 2, EndCircle.CenterPoint.Y);

            pen.Dispose();
            brush.Dispose();
            path1.Dispose();
            path2.Dispose();
            region1.Dispose();
        }


    }
}
