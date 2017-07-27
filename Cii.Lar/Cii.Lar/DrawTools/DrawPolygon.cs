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
                    Point des = point;
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
    }
}
