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

        private ZWPictureBox pictureBox;

        private int clickCount;

        public ActiveCircle(ZWPictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            InnerCircleSize = new Size(38, 38);
            clickCount = 0;
            innerCircles = new List<Circle>();
        }

        public void OnMouseDown(Point point)
        {
            clickCount++;
            StartPoint = point;
            EndPoint = point;
        }

        public void OnMouseMove(Point point, int dx, int dy)
        {
            EndPoint = point;
            CalculateContinuousCircle(dx, dy);
        }

        private void GenerateInnerCircles()
        {

        }

        private List<Circle> innerCircles;

        private int minHoleNum = 0;
        private int maxHoleNum = 0;
        private int holeNum = 0;

        /// <summary>
        /// L/D + 1 < N < 2L/D + 2
        /// L:Line length
        /// D:Circle diameter
        /// N:Number of holes
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        private void CalculateContinuousCircle(int dx, int dy)
        {
            var length = Math.Sqrt(dx * dx + dy * dy);
            var num = length / InnerCircleSize.Width;

            Console.WriteLine("num: " + num);
            if (dx == 0)
            {
                if (length >  (int)num * this.InnerCircleSize.Width && length <= ((int)num + 1) * this.InnerCircleSize.Width)
                {
                    if (dy > 0)
                    {
                        if (num > 1)
                        {
                            innerCircles.Clear();
                            int innerCircleNum = (int)num;
                            //var gap = length / (innerCircleNum + 1);
                            //for (int i=0; i<innerCircleNum; i++)
                            //{
                            //    Circle c = new Circle(new PointF(startCircle.CenterPoint.X, (float)(startCircle.CenterPoint.Y + i * gap)),
                            //        InnerCircleSize);
                            //    innerCircles.Add(c);
                            //}
                        }
                    }
                    else
                    {
                        if (num > 1)
                        {
                            innerCircles.Clear();
                            int innerCircleNum = (int)num + 1;
                            //var gap = length / innerCircleNum;
                            //for (int i = 0; i < innerCircleNum; i++)
                            //{
                            //    Circle c = new Circle(new PointF(startCircle.CenterPoint.X, (float)(startCircle.CenterPoint.Y - i * gap)),
                            //        InnerCircleSize);
                            //    innerCircles.Add(c);
                            //}
                        }
                    }
                }
            }
            else if (dy == 0)
            {

            }
            else
            {
                var k = dy / dx;
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
                    }
                }
                //draw end circle
                g.DrawEllipse(circlePen, EndCircle.Rectangle);
            }
        }


    }
}
