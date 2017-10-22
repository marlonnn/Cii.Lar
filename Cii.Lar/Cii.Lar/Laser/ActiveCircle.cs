using Cii.Lar.DrawTools;
using Cii.Lar.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cii.Lar.Laser
{
    public class ActiveCircle
    {
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

        public ActiveCircle(ZWPictureBox pictureBox)
        {
            isMouseUp = false;
            this.pictureBox = pictureBox;
            InnerCircleSize = new Size(38, 38);
            OutterCircleSize = new Size(48, 48);
            clickCount = 0;
            innerCircles = new List<Circle>();
            outterCircles = new List<Circle>();
        }

        public void OnMouseDown(Point point)
        {
            isMouseUp = false;
            clickCount++;
            StartPoint = point;
            EndPoint = point;
        }

        public void OnMouseMove(Point point, int dx, int dy)
        {
            if (!isMouseUp)
            {
                EndPoint = point;
                CalculateContinuousCircle(dx, dy);
            }
        }

        public void OnMouseUp()
        {
            if (clickCount % 2 == 0)
            {
                isMouseUp = true;
            }
        }

        private void GenerateInnerCircles()
        {

        }

        private List<Circle> innerCircles;
        private List<Circle> outterCircles;

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
            if (minHoleNum == 1)
            {
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
                    }
                    else if (dy < 0)
                    {
                        for (int i = 0; i < holeNum; i++)
                        {
                            innerCircles.Add(new Circle(new PointF(StartCircle.CenterPoint.X, (float)(StartCircle.CenterPoint.Y - gap * i)), InnerCircleSize));
                            outterCircles.Add(new Circle(new PointF(StartCircle.CenterPoint.X, (float)(StartCircle.CenterPoint.Y - gap * i)), OutterCircleSize));
                        }
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
                    }
                    else if (dx < 0)
                    {
                        for (int i = 0; i < holeNum; i++)
                        {
                            innerCircles.Add(new Circle(new PointF((int)(StartCircle.CenterPoint.X - gap * i), StartCircle.CenterPoint.Y), InnerCircleSize));
                            outterCircles.Add(new Circle(new PointF((int)(StartCircle.CenterPoint.X - gap * i), StartCircle.CenterPoint.Y), OutterCircleSize));
                        }
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
            using (Pen circlePen = new Pen(Color.Yellow, 2f))
            using (Pen pen = new Pen(Color.Black, 1f))
            {
                //draw start circle
                g.DrawEllipse(circlePen, startCircle.Rectangle);
                g.DrawEllipse(circlePen, (new Circle(startPoint, OutterCircleSize)).Rectangle);
                //draw start point cross
                g.DrawLine(pen, startCircle.CenterPoint.X, startCircle.CenterPoint.Y - startCircle.Rectangle.Width / 2,
                startCircle.CenterPoint.X, startCircle.CenterPoint.Y + startCircle.Rectangle.Width / 2);
                g.DrawLine(pen, startCircle.CenterPoint.X - startCircle.Rectangle.Width / 2, startCircle.CenterPoint.Y,
                    startCircle.CenterPoint.X + startCircle.Rectangle.Width / 2, startCircle.CenterPoint.Y);
                //draw end point cross
                g.DrawLine(pen, EndCircle.CenterPoint.X, EndCircle.CenterPoint.Y - EndCircle.Rectangle.Width / 2,
                    EndCircle.CenterPoint.X, EndCircle.CenterPoint.Y + EndCircle.Rectangle.Width / 2);
                g.DrawLine(pen, EndCircle.CenterPoint.X - EndCircle.Rectangle.Width / 2, EndCircle.CenterPoint.Y,
                    EndCircle.CenterPoint.X + EndCircle.Rectangle.Width / 2, EndCircle.CenterPoint.Y);

                //draw connect Line
                g.DrawLine(pen, startCircle.CenterPoint, endCircle.CenterPoint);

                if (innerCircles != null && innerCircles.Count > 0)
                {
                    for (int i=0; i<innerCircles.Count; i++)
                    {
                        g.DrawEllipse(circlePen, innerCircles[i].Rectangle);
                        g.DrawEllipse(circlePen, outterCircles[i].Rectangle);
                    }
                }
                //draw end circle
                g.DrawEllipse(circlePen, EndCircle.Rectangle);
                g.DrawEllipse(circlePen, (new Circle(endPoint, OutterCircleSize)).Rectangle);
            }
        }


    }
}
