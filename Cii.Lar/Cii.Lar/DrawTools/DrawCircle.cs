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
            OutterCircleSize = new Size(30, 30);
            InnerCircleSize = new Size(28, 28);
        }

        public DrawCircle(ZWPictureBox pictureBox, PointF centerPoint) : this()
        {
            this.pictureBox = pictureBox;
            CenterPoint = centerPoint;
            this.GraphicsProperties.GraphicsPropertiesChangedHandler += GraphicsPropertiesChangedHandler;
        }

        private void GraphicsPropertiesChangedHandler(DrawObject drawObject, GraphicsProperties graphicsProperties)
        {
            OutterCircleSize = new Size((30 + this.GraphicsProperties.ExclusionSize) * this.GraphicsProperties.TargetSize, 
                (30 + this.GraphicsProperties.ExclusionSize) * this.GraphicsProperties.TargetSize);
            InnerCircleSize = new Size(27 * this.GraphicsProperties.TargetSize, 27 * this.GraphicsProperties.TargetSize);
            OutterCircle = new Circle(CenterPoint, OutterCircleSize);
            InnerCircle = new Circle(CenterPoint, InnerCircleSize);
            pictureBox.GraphicsPropertiesChangedHandler(drawObject, graphicsProperties);
        }

        private void InitializeGraphicsProperties()
        {
            this.GraphicsProperties = GraphicsPropertiesManager.GetPropertiesByName("Circle");
            this.GraphicsProperties.Color = Color.Yellow;
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
                    return new RectangleF(CenterPoint.X - DrawAreaSize.Width / 2f, CenterPoint.Y - DrawAreaSize.Width / 2f, DrawAreaSize.Width, DrawAreaSize.Height);
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
