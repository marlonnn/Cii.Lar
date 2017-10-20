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

        private ActiveCircle activeCircle;
        public ActiveLaser(ZWPictureBox pictureBox) : base()
        {
            this.pictureBox = pictureBox;
            activeCircle = new ActiveCircle(pictureBox);
        }

        public override void OnMouseDown(ZWPictureBox pictureBox, MouseEventArgs e)
        {
            mouseDownPoint = e.Location;

            Point point = new Point((int)(e.X / pictureBox.Zoom - pictureBox.OffsetX), 
                (int)(e.Y / pictureBox.Zoom - pictureBox.OffsetY));

            activeCircle.OnMouseDown(point);
            this.pictureBox.Invalidate();
        }

        public override void OnMouseMove(ZWPictureBox pictureBox, MouseEventArgs e)
        {
            Point point = new Point((int)(e.X / pictureBox.Zoom - pictureBox.OffsetX),
                (int)(e.Y / pictureBox.Zoom - pictureBox.OffsetY));

            Point mousePosNow = e.Location;

            endPoint = point;

            int dx = mousePosNow.X - mouseDownPoint.X;
            int dy = mousePosNow.Y - mouseDownPoint.Y;
            var length = Math.Sqrt(dx * dx + dy * dy);
            activeCircle.OnMouseMove(point, dx, dy);
            this.pictureBox.Invalidate();
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

            activeCircle.OnPaint(g);
        }

    }
}
