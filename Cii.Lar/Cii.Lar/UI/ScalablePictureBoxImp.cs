using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// This is public domain software - that is, you can do whatever you want
/// with it, and include it software that is licensed under the GNU or the
/// BSD license, or whatever other licence you choose, including proprietary
/// closed source licenses. 
/// https://www.codeproject.com/Articles/15373/A-scrollable-zoomable-and-scalable-picture-box
/// </summary>
namespace Cii.Lar.UI
{
    /// <summary>
    /// A scrollable, zoomable and scalable picture box.
    /// It is data aware, and creates zoom rate context menu dynamically.
    /// However, clients of this control should use this control indirectly by using PictureBoxMediator
    /// So we declare this control as internal class
    /// </summary>
    public partial class ScalablePictureBoxImp : UserControl
    {
        /// <summary>
        /// Maximum scale percent(100%)
        /// </summary>
        public const int MAX_SCALE_PERCENT = 100;

        /// <summary>
        /// Scale percentage of picture box in zoom mode
        /// </summary>
        private int currentScalePercent = MAX_SCALE_PERCENT;

        /// <summary>
        /// Picture size mode
        /// </summary>
        private PictureBoxSizeMode pictureBoxSizeMode = PictureBoxSizeMode.Zoom;

        /// <summary>
        /// delegate of zoom rate changed handler
        /// </summary>
        /// <param name="zoomRate">current zoom rate</param>
        /// <param name="isFullPictureShown">true if the whole picture is shown</param>
        public delegate void ZoomRateChangedEventHandler(int zoomRate, bool isFullPictureShown);

        /// <summary>
        /// zoom rate changed event
        /// </summary>
        public event ZoomRateChangedEventHandler ZoomRateChangedEvent;

        /// <summary>
        /// delegate of PictureBox painted event handler
        /// </summary>
        /// <param name="visibleAreaRect">currently visible area of picture</param>
        /// <param name="pictureBoxRect">picture box area</param>
        public delegate void PictureBoxPaintedEventHandler(Rectangle visibleAreaRect, Rectangle pictureBoxRect);

        /// <summary>
        /// PictureBox painted event
        /// </summary>
        public event PictureBoxPaintedEventHandler PictureBoxPaintedEvent;

        /// <summary>
        /// Get picture box control
        /// </summary>
        [Bindable(false)]
        public PictureBox PictureBox
        {
            get
            {
                return this.pictureBox;
            }
        }

        /// <summary>
        /// Need dispose image when new image is set
        /// </summary>
        private bool needDisposeImage = true;

        /// <summary>
        /// Need dispose image when new image is set
        /// </summary>
        [Bindable(true), DefaultValue(true)]
        public bool NeedDisposeImage
        {
            get { return this.needDisposeImage; }
            set { this.needDisposeImage = value; }
        }

        public ScalablePictureBoxImp()
        {
            InitializeComponent();

            // set size mode of picture box to zoom mode
            this.pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            // Enable auto scroll of this control
            this.AutoScroll = true;
            _zoom = 1;
        }

        /// <summary>
        /// Image in picture box
        /// </summary>
        [Bindable(true)]
        public Image Picture
        {
            get
            {
                return this.pictureBox.Image;
            }
            set
            {
                if (this.pictureBox.Image != null && this.needDisposeImage)
                {
                    this.pictureBox.Image.Dispose();
                }
                this.pictureBox.Image = value;
                ScalePictureBoxToFit();
            }
        }

        /// <summary>
        /// Image size mode
        /// </summary>
        [Bindable(true), DefaultValue(PictureBoxSizeMode.Zoom)]
        public PictureBoxSizeMode ImageSizeMode
        {
            get
            {
                return this.pictureBoxSizeMode;
            }
            set
            {
                this.pictureBoxSizeMode = value;
                ScalePictureBoxToFit();
            }
        }

        /// <summary>
        /// scroll picture programmatically by the event from PictureTracker
        /// </summary>
        /// <param name="xMovementRate">horizontal scroll movement rate which may be nagtive value</param>
        /// <param name="yMovementRate">vertical scroll movement rate which may be nagtive value</param>
        public void OnScrollPictureEvent(float xMovementRate, float yMovementRate)
        {
            // NOTICE : usage of Math.Abs(this.AutoScrollPosition.X) and Math.Abs(this.AutoScrollPosition.Y)
            // The get method of the Panel.AutoScrollPosition.X property and
            // the get method of the Panel.AutoScrollPosition.Y property return negative values.
            // However, positive values are required.
            // You can use the Math.Abs function to obtain a positive value from the Panel.AutoScrollPosition.X property and
            // the Panel.AutoScrollPosition.Y property
            int X = (int)(Math.Abs(this.AutoScrollPosition.X) + this.pictureBox.ClientRectangle.Width * xMovementRate);
            int Y = (int)(Math.Abs(this.AutoScrollPosition.Y) + this.pictureBox.ClientRectangle.Height * yMovementRate);
            this.AutoScrollPosition = new Point(X, Y);
        }

        /// <summary>
        /// Scale percentage for the picture box
        /// </summary>
        public int CurrentScalePercent
        {
            get
            {
                return this.currentScalePercent;
            }
            set
            {
                this.currentScalePercent = value;
            }
        }

        private void ScalePictureBoxToFit()
        {
            if (this.Picture == null)
            {
                this.pictureBox.Width = this.ClientSize.Width;
                this.pictureBox.Height = this.ClientSize.Height;
                this.pictureBox.Left = 0;
                this.pictureBox.Top = 0;
                this.AutoScroll = false;
                this.CurrentScalePercent = GetMinScalePercent();
                this.pictureBoxSizeMode = PictureBoxSizeMode.Zoom;
            }
            else if (this.pictureBoxSizeMode == PictureBoxSizeMode.Zoom || 
                (this.Picture.Width <= this.ClientSize.Width && this.Picture.Height <= this.ClientSize.Height))
            {
                this.pictureBox.Width = Math.Min(this.ClientSize.Width, this.Picture.Width);
                this.pictureBox.Height = Math.Min(this.ClientSize.Height, this.Picture.Height);
                this.pictureBox.Top = (this.ClientSize.Height - this.pictureBox.Height) / 2;
                this.pictureBox.Left = (this.ClientSize.Width - this.pictureBox.Width) / 2;
                this.AutoScroll = false;
                this.CurrentScalePercent = GetMinScalePercent();
                this.pictureBoxSizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                this.pictureBox.Width = Math.Max(this.Picture.Width * this.CurrentScalePercent / 100, this.ClientSize.Width);
                this.pictureBox.Height = Math.Max(this.Picture.Height * this.CurrentScalePercent / 100, this.ClientSize.Height);

                // Centering picture box control
                int top = (this.ClientSize.Height - this.pictureBox.Height) / 2;
                int left = (this.ClientSize.Width - this.pictureBox.Width) / 2;

                //if (top < 0)
                //{
                //    top = this.AutoScrollPosition.Y;
                //}
                //if (left < 0)
                //{
                //    left = this.AutoScrollPosition.X;
                //}
                //this.pictureBox.Left = left;
                //this.pictureBox.Top = top;

                this.AutoScroll = true;
            }

            this.pictureBox.Invalidate();

            // Raise zoom rate changed event
            if (ZoomRateChangedEvent != null)
            {
                bool isFullPictureShown = this.pictureBox.Width <= this.ClientSize.Width &&
                                          this.pictureBox.Height <= this.ClientSize.Height;
                ZoomRateChangedEvent(this.CurrentScalePercent, isFullPictureShown);
            }
        }

        /// <summary>
        /// Resize picture box on resize event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnResize(object sender, System.EventArgs e)
        {
            ScalePictureBoxToFit();
        }

        /// <summary>
        /// Scale current picture if needed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (this.Picture == null ||
                (this.Picture.Width <= this.ClientSize.Width && this.Picture.Height <= this.ClientSize.Height))
            {
                // do nothing if it is not needed to scale the picture
                return;
            }

            if (this.ImageSizeMode == PictureBoxSizeMode.Zoom)
            {
                this.ImageSizeMode = PictureBoxSizeMode.Normal;
                this.CurrentScalePercent = MAX_SCALE_PERCENT;
            }
            else
            {
                this.ImageSizeMode = PictureBoxSizeMode.Zoom;
                this.CurrentScalePercent = GetMinScalePercent();
            }

            ScalePictureBoxToFit();
        }

        /// <summary>
        /// Repaint picture box when its location changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_LocationChanged(object sender, EventArgs e)
        {
            this.pictureBox.Invalidate();
        }

        /// <summary>
        /// Get minimum scale percent of current image
        /// </summary>
        /// <returns>minimum scale percent</returns>
        private int GetMinScalePercent()
        {
            if ((this.Picture == null) || 
                (this.Picture.Width <= this.ClientSize.Width) && (this.Picture.Height <= this.ClientSize.Height))
            {
                return MAX_SCALE_PERCENT;
            }

            float minScalePercent = Math.Min((float)this.ClientSize.Width / (float)this.Picture.Width,
                                             (float)this.ClientSize.Height / (float)this.Picture.Height);
            return (int)(minScalePercent * 100.0f);
        }

        private float _zoom;
        public float ZoomFactor { get { return _zoom; } }

        private void PictureBox_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                int delta = e.Delta;
                float scale = 1;
                if (delta > 0)
                {
                    //Zoom in
                    this.currentScalePercent += delta / 12;
                    scale = 0.1f * currentScalePercent + 1;
                }
                else if (delta < 0)
                {
                    //Zoom out
                    this.currentScalePercent -= (delta) / (-12);
                    scale = -0.1f * currentScalePercent + 1;
                }

                //this.pictureBox.Left = (int)(e.X - scale * (e.X - pictureBox.Left));
                //this.pictureBox.Top = (int)(e.Y - scale * (e.Y - pictureBox.Top));
                this.ImageSizeMode = PictureBoxSizeMode.Normal;
            }
        }

        /// <summary>
        /// Raise pictureBox painted event for adjusting picture tracking control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (PictureBoxPaintedEvent != null)
            {
                Rectangle thisControlClientRect = this.ClientRectangle;
                thisControlClientRect.X -= this.AutoScrollPosition.X;
                thisControlClientRect.Y -= this.AutoScrollPosition.Y;
                PictureBoxPaintedEvent(thisControlClientRect, this.pictureBox.ClientRectangle);
            }
        }
    }
}
