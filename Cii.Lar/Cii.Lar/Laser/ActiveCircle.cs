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

        private void CalculateContinuousCircle(int dx, int dy)
        {
            var length = Math.Sqrt(dx * dx + dy * dy);
            int num = (int)(length / InnerCircleSize.Width);
            if (dx == 0)
            {
                if (length > num * this.InnerCircleSize.Width && length <= (num + 1) * this.InnerCircleSize.Width)
                {
                    if (dy > 0)
                    {
                        var count = (int)(2 * length / InnerCircleSize.Width);
                    }
                    else
                    {

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

                //draw end circle
                g.DrawEllipse(circlePen, EndCircle.Rectangle);
            }
        }


    }
}
