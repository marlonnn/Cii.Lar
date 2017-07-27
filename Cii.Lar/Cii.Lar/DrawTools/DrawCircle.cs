using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Cii.Lar.UI;
using System.Drawing.Drawing2D;

namespace Cii.Lar.DrawTools
{
    /// <summary>
    /// Draw circle graphic
    /// Author:Zhong Wen 2017/07/27
    /// </summary>
    public class DrawCircle : DrawObject
    {
        private Circle circleForDraw = null;

        public PointF CenterPoint
        {
            get;
            set;
        }

        public Size DrawAreaSize
        {
            get;
            set;
        }

        public DrawCircle()
        {
            this.Color = Color.OrangeRed;
            DrawAreaSize = new Size(30, 30);
        }

        public DrawCircle(PointF centerPoint) : this()
        {
            CenterPoint = centerPoint;
        }

        public override void Draw(Graphics g, CursorPictureBox pictureBox)
        {
            if (circleForDraw == null)
            {
                circleForDraw = new Circle(CenterPoint, DrawAreaSize);
            }
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(this.Color, PenWidth))
            {
                g.DrawEllipse(pen, circleForDraw.Rectangle.X, circleForDraw.Rectangle.Y, 
                    circleForDraw.Rectangle.Width, circleForDraw.Rectangle.Height);
            }
        }

        /// <summary>
        /// Get handle point by 1-based number
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public override Point GetHandle(CursorPictureBox pictureBox, int handleNumber)
        {
            float x = 0, y = 0, xCenter, yCenter;

            RectangleF rect = circleForDraw.Rectangle;
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

        public class Circle
        {
            public PointF CenterPoint
            {
                get;
                set;
            }

            public Size DrawAreaSize
            {
                get;
                set;
            }

            public RectangleF Rectangle
            {
                get
                {
                    return new RectangleF(CenterPoint.X - DrawAreaSize.Width / 2, CenterPoint.Y - DrawAreaSize.Width / 2, DrawAreaSize.Width, DrawAreaSize.Height);
                }
            }

            public Circle(PointF centerPoint, Size drawAreaSize)
            {
                CenterPoint = centerPoint;
                DrawAreaSize = drawAreaSize;
            }
        }
    }
}
