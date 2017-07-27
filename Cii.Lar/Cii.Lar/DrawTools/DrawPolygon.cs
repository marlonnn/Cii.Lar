using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;

namespace Cii.Lar.DrawTools
{
    using PointFList = List<PointF>;
    using PointFEnumerator = IEnumerator<PointF>;
    using UI;
    using System.Drawing.Drawing2D;

    /// <summary>
    /// Polygon graphic object
    /// Author:Zhong Wen 2017/07/26
    /// </summary>
    public class DrawPolygon : DrawLine
    {
        protected PointFList pointArray;
        private PointFList pointArrayProportion;

        private Rectangle drawRectangle = Rectangle.Empty;
        private Size drawAreaSize; // store draw area size for data point hit test

        public int PointCount
        {
            get
            {
                return pointArray.Count;
            }
        }

        public DrawPolygon()
        {
            pointArray = new PointFList();
            pointArrayProportion = new PointFList();
            drawAreaSize = DefaultDrawAreaSize;

            this.Color = Color.AliceBlue;
        }

        public DrawPolygon(CursorPictureBox pictureBox, List<PointF> dataPoints) : this()
        {
            pointArray = new PointFList(dataPoints);
            pointArrayProportion = new PointFList();

        }

        public DrawPolygon(CursorPictureBox pictureBox, int x1, int y1, int x2, int y2) : this()
        {
            pointArray = new PointFList();
            pointArrayProportion = new PointFList();

            AddPoint(pictureBox, new Point(x1, y1), false);
            AddPoint(pictureBox, new Point(x2, y2), false);
        }
        
        /// <summary>
        /// draw object
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pictureBox"></param>
        public override void Draw(Graphics g, CursorPictureBox pictureBox)
        {
            Point p1 = Point.Empty; // previous point
            Point p2 = Point.Empty; // current point

            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(this.Color, PenWidth))
            {
                PointFEnumerator enumerator = pointArray.GetEnumerator();
                if (enumerator.MoveNext())
                {
                    p1 = Point.Ceiling(enumerator.Current);
                    p1.Offset(MovingOffset);
                }
                while (enumerator.MoveNext())
                {
                    p2 = Point.Ceiling(enumerator.Current);
                    p2.Offset(MovingOffset);
                    g.DrawLine(pen, p1, p2);
                    p1 = p2;
                }
                enumerator.Reset();
                if (enumerator.MoveNext())
                {
                    p2 = Point.Ceiling(enumerator.Current);
                    p2.Offset(MovingOffset);
                    g.DrawLine(pen, p1, p2);
                }
            }
        }

        public void AddPoint(CursorPictureBox pictureBox, Point point, bool checkClose)
        {
            bool addPoint = true;
            if (checkClose)
            {
                for (int i = 0; i < PointCount - 1; i++)   // does not check for last point
                {
                    Point des = Point.Ceiling(pointArray[i]);
                    if (CloseToPoint(point, des))
                    {
                        addPoint = false;
                    }
                }
            }
            if (addPoint)
            {
                pointArray.Add(point);
            }
        }

        public bool CloseToPoint(Point src, Point des)
        {
            return Math.Abs(src.X - des.X) <= 3 && Math.Abs(src.Y - des.Y) <= 3;
        }

        public override void DrawTracker(Graphics g, CursorPictureBox pictureBox)
        {
            if (!Selected)
            {
                return;
            }

            SolidBrush brush = new SolidBrush(Color.White);
            Pen pen = new Pen(Color.Black, PenWidth);

            for (int i = 1; i <= HandleCount; i++)
            {
                Rectangle r = GetHandleRectangle(pictureBox, i);
                if (i <= PointCount)
                {
                    r.Offset(MovingOffset);
                }
                else
                {
                    brush.Color = Color.DarkGray;
                }

                try
                {
                    g.DrawRectangle(pen, r);
                    g.FillRectangle(brush, r);
                }
                catch (System.Exception ex)
                {
                    Selected = false;
                }
            }
            pen.Dispose();
            brush.Dispose();
        }

        public void MoveLastHandleTo(CursorPictureBox pictureBox, Point point)
        {
            if (PointCount == 0) return;

            if (PointCount > 3 && CloseToFirstPoint(pictureBox, point))
            {
                pointArray[PointCount - 1] = pointArray[0];
            }
            else
            {
                pointArray[PointCount - 1] = point;
            }
        }

        public bool CloseToFirstPoint(CursorPictureBox pictureBox, Point point)
        {
            if (PointCount <= 0) return false;

            Point first = Point.Ceiling(pointArray[0]);

            return CloseToPoint(first, point);
        }

        /// <summary>
        /// Get handle rectangle by 1-based number
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public override Rectangle GetHandleRectangle(CursorPictureBox pictureBox, int handleNumber)
        {
            Point point = GetHandle(pictureBox, handleNumber);

            return new Rectangle(point.X - 3, point.Y - 3, 6, 6);
        }

        /// <summary>
        /// Get handle point by 1-based number
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public override Point GetHandle(CursorPictureBox pictureBox, int handleNumber)
        {
            if (handleNumber < 1)
            {
                handleNumber = 1;
            }
            if (handleNumber <= PointCount)
            {
                return Point.Ceiling(pointArray[handleNumber - 1]);
            }
            else
            {
                int x, y, xCenter, yCenter;
                Rectangle rectangle = drawRectangle;

                if (rectangle == Rectangle.Empty)
                {
                    return Point.Empty;
                }

                xCenter = rectangle.X + rectangle.Width / 2;
                yCenter = rectangle.Y + rectangle.Height / 2;
                x = rectangle.X;
                y = rectangle.Y;

                handleNumber -= PointCount;
                switch (handleNumber)
                {
                    case 1:
                        x = rectangle.X;
                        y = rectangle.Y;
                        break;
                    case 2:
                        x = xCenter;
                        y = rectangle.Y;
                        break;
                    case 3:
                        x = rectangle.Right;
                        y = rectangle.Y;
                        break;
                    case 4:
                        x = rectangle.Right;
                        y = yCenter;
                        break;
                    case 5:
                        x = rectangle.Right;
                        y = rectangle.Bottom;
                        break;
                    case 6:
                        x = xCenter;
                        y = rectangle.Bottom;
                        break;
                    case 7:
                        x = rectangle.X;
                        y = rectangle.Bottom;
                        break;
                    case 8:
                        x = rectangle.X;
                        y = yCenter;
                        break;
                }
                return new Point(x, y);
            }
        }

        /// <summary>
        /// get handle point count
        /// </summary>
        public override int HandleCount
        {
            get
            {
                return pointArray.Count + 8;
            }
        }
    }
}
