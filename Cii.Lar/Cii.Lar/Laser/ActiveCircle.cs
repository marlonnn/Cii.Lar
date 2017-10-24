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
        private CircleData circleData;
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
            circleData = new CircleData();
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

        public void OnMouseMove(MouseEventArgs e, Point point, int dx, int dy)
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
                    if (/*InTheHole && */(e.Button == MouseButtons.Left))
                    {
                        CalcAngle(point, dx, dy);
                    }
                }
            }
        }

        private void CalcAngle(Point point, int dx, int dy)
        {
            //vector (a1, b1)
            int a1 = StartPoint.X - point.X;
            int b1 = StartPoint.Y - point.Y;

            //vactor (a2, b2)
            int a2 = EndPoint.X - point.X;
            int b2 = EndPoint.Y - point.Y;

            var value = (a1 * b2 - a2 * b1) / (Math.Sqrt(a1 * a1 + b1 * b1) * Math.Sqrt(a2 * a2 + b2 * b2));
            var angle = Math.PI - Math.Asin(value);
            //Console.WriteLine("angle: " + angle);

            var v1 = angle * (180 / Math.PI);
            //Console.WriteLine("real angle: " + v1);
            //Console.WriteLine("length / 2: " + Length / 2);

            var halfLenght = Length / 2;
            var temp = (halfLenght) / Math.Tan(angle / 2);
            //Console.WriteLine("temp: " + temp);
            var radius = (Math.Pow(halfLenght, 2) + Math.Pow(temp, 2)) / (2 * temp);
            Console.WriteLine("radius: " + radius);
            var angleArc = 2 * (Math.Asin(halfLenght / Math.Abs(radius)));

            var lengthArc = angleArc * Math.Abs(radius);

            CalcCircleCenter(StartPoint, point, EndPoint);
        }

        /// <summary>
        /// 参考：http://blog.csdn.net/lijiayu2015/article/details/52541730
        /// 通过三个点到圆心距离相等建立方程：
        ///  (pt1.x-center.x)²-(pt1.y-center.y)²=radius²     式子(1)
        ///  (pt2.x-center.x)²-(pt2.y-center.y)²=radius²     式子(2)
        ///  (pt3.x-center.x)²-(pt3.y-center.y)²=radius²     式子(3)
        /// 
        ///  式子(1)-式子(2)得：
        ///  pt1.x²+pt2.y²-pt1.y²-pt2.x²+2*center.x* pt2.x-2*center.x* pt1.x+2*center.y* pt1.y-2*center.y* pt2.y-=0
        ///  式子(2)-式子(3)得：
        ///  pt2.x²+pt3.y²-pt2.y²-pt3.x²+2*center.x* pt3.x-2*center.x* pt2.x+2*center.y* pt2.y-2*center.y* pt3.y-=0
        /// 
        ///  整理上面的两个式子得到：
        ///  (2*pt2.x-2*pt1.x)*center.x+(2*pt1.y-2*pt2.y)*center.y=pt1.y²+pt2.x²-pt1.x²-pt2.y²
        ///  (2*pt3.x-2*pt2.x)*center.x+(2*pt2.y-2*pt3.y)*center.y=pt2.y²+pt3.x²-pt2.x²-pt3.y²
        ///  令：
        ///  A1=2*pt2.x-2*pt1.x B1 = 2 * pt1.y - 2 * pt2.y       C1=pt1.y²+pt2.x²-pt1.x²-pt2.y²
        ///  A2=2*pt3.x-2*pt2.x B2 = 2 * pt2.y - 2 * pt3.y       C2=pt2.y²+pt3.x²-pt2.x²-pt3.y²
        /// 
        ///  则上述方程组变成一下形式：
        ///  A1* center.x+B1* center.y= C1；
        ///  A2* center.x+B2* center.y= C2
        ///  联立以上方程组可以求出：
        ///  center.x = (C1 * B2 - C2 * B1) / A1 * B2 - A2 * B1;
        ///          center.y = (A1* C2 - A2* C1) / A1* B2 - A2* B1;
        ///  （为了方便编写程序，令temp = A1* B2 - A2* B1）
        /// </summary>
        /// <param name="pt1"></param>
        /// <param name="pt2"></param>
        /// <param name="pt3"></param>
        private void CalcCircleCenter(Point pt1, Point pt2, Point pt3)
        {
            float A1, A2, B1, B2, temp;
            double C1, C2;
            A1 = pt1.X - pt2.X;
            B1 = pt1.Y - pt2.Y;
            C1 = (Math.Pow(pt1.X, 2) - Math.Pow(pt2.X, 2) + Math.Pow(pt1.Y, 2) - Math.Pow(pt2.Y, 2)) / 2;
            A2 = pt3.X - pt2.X;
            B2 = pt3.Y - pt2.Y;
            C2 = (Math.Pow(pt3.X, 2) - Math.Pow(pt2.X, 2) + Math.Pow(pt3.Y, 2) - Math.Pow(pt2.Y, 2)) / 2;

            //为了方便编写程序，令temp = A1*B2 - A2*B1  
            temp = A1 * B2 - A2 * B1;
            //定义一个圆的数据的结构体对象CD  
            PointF centerPt = new PointF();
            //判断三点是否共线  
            if (temp == 0)
            {
                //共线则将第一个点pt1作为圆心  
                centerPt.X = pt1.X;
                centerPt.Y = pt1.Y;
            }
            else
            {
                //不共线则求出圆心：  
                //center.X = (C1*B2 - C2*B1) / A1*B2 - A2*B1;  
                //center.Y = (A1*C2 - A2*C1) / A1*B2 - A2*B1;  
                centerPt.X = (float)((C1 * B2 - C2 * B1) / temp);
                centerPt.Y = (float)((A1 * C2 - A2 * C1) / temp);
            }
            circleData.CenterPt = centerPt;
            var radius = Math.Sqrt((circleData.CenterPt.X - pt1.X) * (circleData.CenterPt.X - pt1.X) + (circleData.CenterPt.Y - pt1.Y) * (circleData.CenterPt.Y - pt1.Y));
            Console.WriteLine("new radius2: " + radius);
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
        private double length;
        public double Length
        {
            get { return this.length; }
            set { this.length = value; }
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
            Length = Math.Sqrt(dx * dx + dy * dy);

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
