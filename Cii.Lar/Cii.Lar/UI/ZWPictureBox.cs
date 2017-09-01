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
    public enum PanDirection
    {
        None,
        Left,
        Right,
        Up,
        Down
    }
    /// <summary>
    ///  My Custom picture box
    ///  Author: Zhong Wen 2017/08/31
    /// </summary>
    public partial class ZWPictureBox : PictureBox
    {
        private Point mouseDownPoint;
        private bool mousePressed;
        private int startX;
        private int startY;

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
        public int OffsetY
        {
            get
            {
                return offsetY;
            }
            set
            {
                offsetY = value;
            }
        }

        private float zoom = 1;

        public ZWPictureBox()
        {
        }

        public void LoadImage()
        {
            this.Image = Image.FromFile(string.Format("{0}\\Resources\\1.bmp", System.Environment.CurrentDirectory));
            this.OffsetX = (this.Width - this.Image.Width) / 2;
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
            if (e.Button == MouseButtons.Left)
            {
                if (!mousePressed)
                {
                    mousePressed = true;
                    mouseDownPoint = e.Location;
                    startX = OffsetX;
                    startY = OffsetY;
                }
            }
        }
        /// <summary>
        /// Handles the MouseUp event.
        /// </summary>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            mousePressed = false;
        }
        /// <summary>
        /// Handles the MouseMove event.
        /// </summary>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePosNow = e.Location;

                int deltaX = mousePosNow.X - mouseDownPoint.X;
                int deltaY = mousePosNow.Y - mouseDownPoint.Y;

                OffsetX = (int)(startX + deltaX / zoom);
                OffsetY = (int)(startY + deltaY / zoom);

                this.Invalidate();
            }
        }

        public void ZoomFit()
        {
            this.OffsetX = (this.Width - this.Image.Width) / 2;
            this.OffsetY = 0;
            this.zoom = 0;
        }

        /// <summary>
        /// Handles the MouseWheel event.
        /// </summary>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            float oldzoom = zoom;

            if (e.Delta > 0)
            {
                if (IsCtrlKeyPressed)
                {
                    PanAllDrirection(oldzoom, PanDirection.Left);
                }
                else if (IsShiftKeyPressed)
                {
                    PanAllDrirection(oldzoom, PanDirection.Up);
                }
                else
                {
                    zoom += 1F;
                    ZoomOnMouseCenter(e, oldzoom);
                }
            }
            else if (e.Delta < 0)
            {
                if (IsCtrlKeyPressed)
                {
                    PanAllDrirection(oldzoom, PanDirection.Right);
                }
                else if (IsShiftKeyPressed)
                {
                    PanAllDrirection(oldzoom, PanDirection.Down);
                }
                else
                {
                    if (zoom > 1)
                    {
                        zoom = Math.Max(zoom - 1F, 0.01F);
                        ZoomOnMouseCenter(e, oldzoom);
                    }
                }
            }

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

        private void PanAllDrirection(float zoom, PanDirection panDirection)
        {
            switch (panDirection)
            {
                case PanDirection.Left:
                    this.OffsetX += (int)(this.Width * 0.1f / zoom);
                    break;
                case PanDirection.Up:
                    this.OffsetY += (int)(this.Height * 0.1f / zoom);
                    break;
                case PanDirection.Right:
                    this.OffsetX -= (int)(this.Width * 0.1f / zoom);
                    break;
                case PanDirection.Down:
                    this.OffsetY -= (int)(this.Height * 0.1f / zoom);
                    break;
                default:
                    break;
            }
        }

        private void ZoomOnMouseCenter(MouseEventArgs e, float oldzoom)
        {
            Point mousePosNow = e.Location;

            // Where location of the mouse in the pictureframe
            int x = mousePosNow.X - this.Location.X;
            int y = mousePosNow.Y - this.Location.Y;

            // Where in the IMAGE is it now
            int oldImageX = (int)(x / oldzoom);
            int oldImageY = (int)(y / oldzoom);

            // Where in the IMAGE will it be when the new zoom i made
            int newImageX = (int)(x / zoom);
            int newImageY = (int)(y / zoom);

            // Where to move image to keep focus on one point
            offsetX = newImageX - oldImageX + offsetX;
            offsetY = newImageY - oldImageY + offsetY;
        }

        #region "Check key pressed"

        /// <summary>
        /// returns true if the shift key is pressed
        /// </summary>
        public static bool IsShiftKeyPressed
        {
            get { return (Control.ModifierKeys & Keys.Shift) != 0; }
        }
        public static bool IsAltKeyPressed
        {
            get { return (Control.ModifierKeys & Keys.Alt) != 0; }
        }
        public static bool IsCtrlKeyPressed
        {
            get { return (Control.ModifierKeys & Keys.Control) != 0; }
        }
        #endregion
    }
}
