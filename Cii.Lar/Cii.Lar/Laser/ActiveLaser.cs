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
    public class ActiveLaser : BaseLaser
    {
        private Point mouseDownPoint;
        private Point endPoint;

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

        private List<Circle> outterCircles = null;
        public List<Circle> OutterCircles
        {
            get { return outterCircles; }
            set
            {
                if (value != outterCircles)
                {
                    outterCircles = value;
                }
            }
        }

        private List<Circle> innerCircles = null;
        public List<Circle> InnerCircles
        {
            get { return innerCircles; }
            set
            {
                if (value != innerCircles)
                {
                    innerCircles = value;
                }
            }
        }

        public ActiveLaser(ZWPictureBox pictureBox) : base()
        {
            this.pictureBox = pictureBox;
            OutterCircleSize = new Size(60, 60);
            InnerCircleSize = new Size(38, 38);

            InnerCircles = new List<Circle>();
            OutterCircles = new List<Circle>();
            this.GraphicsProperties.GraphicsPropertiesChangedHandler += GraphicsPropertiesChangedHandler;
        }
        private void GraphicsPropertiesChangedHandler(DrawObject drawObject, GraphicsProperties graphicsProperties)
        {
            OutterCircleSize = new Size((60 + this.GraphicsProperties.ExclusionSize) * this.GraphicsProperties.TargetSize,
                (60 + this.GraphicsProperties.ExclusionSize) * this.GraphicsProperties.TargetSize);
            InnerCircleSize = new Size(38 * this.GraphicsProperties.TargetSize, 38 * this.GraphicsProperties.TargetSize);
            OutterCircle = new Circle(CenterPoint, OutterCircleSize);
            InnerCircle = new Circle(CenterPoint, InnerCircleSize);
            this.pictureBox.Invalidate();
        }

        public override void OnMouseDown(ZWPictureBox pictureBox, MouseEventArgs e)
        {

            mouseDownPoint = e.Location;

            Point point = new Point((int)(e.X / pictureBox.Zoom - pictureBox.OffsetX), 
                (int)(e.Y / pictureBox.Zoom - pictureBox.OffsetY));
            CenterPoint = new PointF(point.X, point.Y);

            OutterCircle = new Circle(CenterPoint, OutterCircleSize);
            InnerCircle = new Circle(CenterPoint, InnerCircleSize);

            if (InnerCircles.Count == 0)
            {
                InnerCircles.Add(InnerCircle);
            }
            if (OutterCircles.Count == 0)
            {
                OutterCircles.Add(OutterCircle);
            }

            if (InnerCircles.Count == 1)
            {
                InnerCircles[0].CenterPoint = CenterPoint;
            }
            if (OutterCircles.Count == 1)
            {
                OutterCircles[0].CenterPoint = CenterPoint;
            }
            this.pictureBox.Invalidate();
        }

        public override void OnMouseMove(ZWPictureBox pictureBox, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            {
                Point point = new Point((int)(e.X / pictureBox.Zoom - pictureBox.OffsetX),
                    (int)(e.Y / pictureBox.Zoom - pictureBox.OffsetY));

                Point mousePosNow = e.Location;

                endPoint = point;

                int dx = mousePosNow.X - mouseDownPoint.X;
                int dy = mousePosNow.Y - mouseDownPoint.Y;
                var length = Math.Sqrt(dx * dx + dy * dy);
                //Console.WriteLine("delt length : " + length);

                int num = (int)(length / this.InnerCircleSize.Width);
                //Console.WriteLine("num : " + num);

                if (dx == 0)
                {

                }
                //if (length > num * this.InnerCircleSize.Width && length <= (num + 1) * this.InnerCircleSize.Width)
                //{
                //    if (InnerCircles.Count == num + 1)
                //    {
                //        InnerCircles.Add(new Circle(new PointF(point.X, point.Y), InnerCircleSize));
                //    }
                //    if (InnerCircles.Count == num + 2)
                //    {
                //        InnerCircles[num + 1].CenterPoint = new PointF(point.X, point.Y);
                //    }
                //    if (OutterCircles.Count == num + 1)
                //    {
                //        OutterCircles.Add(new Circle(new PointF(point.X, point.Y), OutterCircleSize));
                //    }
                //    if (OutterCircles.Count == num + 2)
                //    {
                //        OutterCircles[num + 1].CenterPoint = new PointF(point.X, point.Y);
                //    }
                //}
                this.pictureBox.Invalidate();
            }
        }

        public override void OnMouseUp(ZWPictureBox pictureBox, MouseEventArgs e)
        {
            base.OnMouseUp(pictureBox, e);
        }

        public override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            SolidBrush brush = new SolidBrush(this.GraphicsProperties.Color);

            GraphicsPath path1 = new GraphicsPath();
            GraphicsPath path2 = new GraphicsPath();
            Region region1 = new Region();
            Region region2 = new Region();
            for (int i = 0; i < this.OutterCircles.Count; i++)
            {
                path1.AddEllipse(OutterCircles[i].Rectangle.X, OutterCircles[i].Rectangle.Y,
                    OutterCircles[i].Rectangle.Width, OutterCircles[i].Rectangle.Height);

                path2.AddEllipse(InnerCircles[i].Rectangle.X, InnerCircles[i].Rectangle.Y,
                    InnerCircles[i].Rectangle.Width, InnerCircles[i].Rectangle.Height);
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
            DrawLine(g);
            brush.Dispose();
            path1.Dispose();
            path2.Dispose();
            region1.Dispose();
        }

        private void DrawCross(Graphics g)
        {
            g.DrawLine(new Pen(Color.Black, 1f),
                InnerCircle.CenterPoint.X, InnerCircle.CenterPoint.Y - InnerCircle.Rectangle.Width / 2,
                InnerCircle.CenterPoint.X, InnerCircle.CenterPoint.Y + InnerCircle.Rectangle.Width / 2);

            g.DrawLine(new Pen(Color.Black, 1f),
                InnerCircle.CenterPoint.X - InnerCircle.Rectangle.Width / 2, InnerCircle.CenterPoint.Y,
                InnerCircle.CenterPoint.X + InnerCircle.Rectangle.Width / 2, InnerCircle.CenterPoint.Y);
        }

        private void DrawLine(Graphics g)
        {
            if (CenterPoint.IsEmpty || endPoint.IsEmpty)
            {
                return;
            }
            g.DrawLine(new Pen(Color.Black, 1f), CenterPoint, endPoint);
        }
    }
}
