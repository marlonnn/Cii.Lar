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
    /// Draw hollow donut graphic
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
            InitializeGraphicsProperties();
            DrawAreaSize = new Size(30, 30);
        }

        public DrawCircle(ZWPictureBox pictureBox, PointF centerPoint) : this()
        {
            CenterPoint = centerPoint;
            this.GraphicsProperties.GraphicsPropertiesChangedHandler += pictureBox.GraphicsPropertiesChangedHandler;
        }

        private void InitializeGraphicsProperties()
        {
            this.GraphicsProperties = GraphicsPropertiesManager.GetPropertiesByName("Circle");
            this.GraphicsProperties.Color = Color.Yellow;
        }

        public override void Draw(Graphics g, ZWPictureBox pictureBox)
        {
            if (circleForDraw == null)
            {
                circleForDraw = new Circle(CenterPoint, DrawAreaSize);
            }
            //path for the outer and inner circles
            //using (GraphicsPath path = new GraphicsPath())
            //using (SolidBrush brush = new SolidBrush(this.Color))
            using (Pen pen = new Pen(this.GraphicsProperties.Color, this.GraphicsProperties.PenWidth))
            {
                g.DrawEllipse(pen, circleForDraw.Rectangle.X, circleForDraw.Rectangle.Y,
                    circleForDraw.Rectangle.Width, circleForDraw.Rectangle.Height);
                //path.AddEllipse(circleForDraw.Rectangle.X, circleForDraw.Rectangle.Y,
                //    circleForDraw.Rectangle.Width, circleForDraw.Rectangle.Height);
                //path.AddEllipse(circleForDraw.Rectangle.X - circleForDraw.Rectangle.Width / 4, circleForDraw.Rectangle.Y - circleForDraw.Rectangle.Width / 4,
                //        circleForDraw.Rectangle.Width / 2, circleForDraw.Rectangle.Height / 2);
                //g.FillPath(brush, path);
            }
            //GraphicsPath path1 = new GraphicsPath();
            //GraphicsPath path2 = new GraphicsPath();
            //SolidBrush brush = new SolidBrush(this.Color);
            //path1.AddEllipse(circleForDraw.Rectangle.X, circleForDraw.Rectangle.Y,
            //    circleForDraw.Rectangle.Width, circleForDraw.Rectangle.Height);
            //path2.AddEllipse(circleForDraw.Rectangle.X - circleForDraw.Rectangle.Width / 4, circleForDraw.Rectangle.Y - circleForDraw.Rectangle.Width / 4,
            //    circleForDraw.Rectangle.Width / 4, circleForDraw.Rectangle.Height / 4);
            //// Create a region from the Outer circle.
            //Region region = new Region(path1);

            //// Exclude the Inner circle from the region
            //region.Exclude(path2);

            //// Draw the region to your Graphics object
            //g.FillRegion(brush, region);

            //brush.Dispose();
            //path1.Dispose();
            //path2.Dispose();
            //region.Dispose();
        }


        /// <summary>
        /// Get handle point by 1-based number
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public override Point GetHandle(ZWPictureBox pictureBox, int handleNumber)
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
