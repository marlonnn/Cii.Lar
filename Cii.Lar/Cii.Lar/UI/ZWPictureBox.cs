using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Cii.Lar.UI
{
    /// <summary>
    ///  My Custom picture box
    ///  Author: Zhong Wen 2017/08/31
    /// </summary>
    public partial class ZWPictureBox : PictureBox
    {
        private Point mouseDownPoint;

        //current offset of image
        private int offsetX;
        public int OffsetX
        {
            get
            {
                return offsetX;
            }
            set
            {
                offsetX = value;
            }
        }
        private int offsetY;

        private float zoom = 1;

        public ZWPictureBox()
        {
            this.Image = Image.FromFile(string.Format("{0}\\Archive\\20170829211049.png", System.Environment.CurrentDirectory));
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.Enabled = true;
            this.Focus();
            base.OnMouseEnter(e);
        }

        /// <summary>
        /// Handles the MouseDown event.
        /// </summary>
        protected override void OnMouseDown(MouseEventArgs e)
        {

            base.OnMouseDown(e);
        }
        /// <summary>
        /// Handles the MouseUp event.
        /// </summary>
        protected override void OnMouseUp(MouseEventArgs e)
        {

            base.OnMouseUp(e);
        }
        /// <summary>
        /// Handles the MouseMove event.
        /// </summary>
        protected override void OnMouseMove(MouseEventArgs e)
        {

            base.OnMouseMove(e);
        }

        /// <summary>
        /// Handles the MouseWheel event.
        /// </summary>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            float oldzoom = zoom;

            if (e.Delta > 0)
            {
                zoom += 0.1F;
            }
            else if (e.Delta < 0)
            {
                zoom = Math.Max(zoom - 0.1F, 0.01F);
            }

            Point mousePosNow = e.Location;

            // Where location of the mouse in the pictureframe
            int x = mousePosNow.X - this.Location.X;
            int y = mousePosNow.Y - this.Location.Y;

            // Where in the IMAGE is it now
            int oldimagex = (int)(x / oldzoom); 
            int oldimagey = (int)(y / oldzoom);

            // Where in the IMAGE will it be when the new zoom i made
            int newimagex = (int)(x / zoom); 
            int newimagey = (int)(y / zoom);

            offsetX = newimagex - oldimagex + offsetX;  // Where to move image to keep focus on one point
            offsetY = newimagey - oldimagey + offsetY;

            this.Refresh();
        }

        /// <summary>
        /// Handles the Paint event
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.Image != null)
            {
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.ScaleTransform(zoom, zoom);
                e.Graphics.DrawImage(this.Image, offsetX, offsetY);
            }
        }
    }
}
