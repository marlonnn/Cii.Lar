using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cii.Lar.UI
{
    public partial class ImageTracker : UserControl
    {
        /// <summary>
        /// image thumbnail for tracking image.
        /// We make thumbnail of original picture for performance consideration
        /// instead of using original picture for tracking.
        /// </summary>
        private Image thumbnail = null;

        /// <summary>
        /// rectangle area where to draw the thumbnail picture
        /// </summary>
        private Rectangle pictureDestRect;

        /// <summary>
        /// rectangle area where to draw part of visible picture
        /// </summary>
        private Rectangle highlightingRect;

        /// <summary>
        /// current zoom rate
        /// </summary>
        private float zoomRate = 100;

        /// <summary>
        /// zoom rate of current image
        /// </summary>
        public float ScalePercent
        {
            get { return this.zoomRate; }
            set
            {
                if (value != zoomRate)
                {
                    zoomRate = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Font for drawing zoom rate text
        /// </summary>
        private Font zoomRateFont = new System.Drawing.Font("Times New Roman", 9.75F, 
            ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), 
            System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        /// <summary>
        /// a transperent brush for shadowing invisible part of picture.
        /// It uses sliver color for shadowing picture
        /// </summary>
        private Brush tranparentBrush = new SolidBrush(Color.FromArgb(180, 0xc0, 0xc0, 0xc0));

        /// <summary>
        /// image for tracking
        /// </summary>
        public Image Picture
        {
            set
            {
                if (thumbnail != null)
                {
                    thumbnail.Dispose();
                }
                if (value != null)
                {
                    Rectangle srcRect = this.picturePanel.ClientRectangle;
                    srcRect.X += 1;
                    srcRect.Y += 1;
                    srcRect.Width -= 2;
                    srcRect.Height -= 2;
                    thumbnail = Util.CreateThumbnail(value, srcRect.Height);
                    pictureDestRect = Util.ScaleToFit(thumbnail, srcRect, false);
                    highlightingRect = new Rectangle(0, 0, 0, 0);
                }
            }
        }

        public ImageTracker()
        {
            InitializeComponent();
        }

        public void OnPicturePainted(Rectangle showingRect, Rectangle pictureBoxRect)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // draw control border
            Rectangle borderRect = this.ClientRectangle;
            borderRect.Width -= 1;
            borderRect.Height -= 1;
            e.Graphics.DrawRectangle(Pens.Navy, borderRect);

            // draw zoom rate text
            e.Graphics.DrawString("Zoom rate:" + ScalePercent + "%", zoomRateFont, Brushes.Navy, 3, 3);
        }

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

        private void picturePanel_Paint(object sender, PaintEventArgs e)
        {
            if (thumbnail != null)
            {
                // draw thumbnail image
                e.Graphics.DrawImage(this.thumbnail, this.pictureDestRect);

                // adjust highlighting region of visible picture area
                Region highlightRegion = new Region(this.pictureDestRect);
                if (highlightingRect.Width > 0 && highlightingRect.Height > 0)
                {
                    highlightRegion.Exclude(highlightingRect);
                }
                e.Graphics.FillRegion(tranparentBrush, highlightRegion);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            Rectangle borderRect = this.ClientRectangle;

            const int MSG_HEIGHT = 18;
            const int OFFSET = 5;
            this.picturePanel.Location = new Point(OFFSET, MSG_HEIGHT);
            this.picturePanel.Width = this.ClientRectangle.Width - OFFSET * 2;
            this.picturePanel.Height = this.ClientRectangle.Height - (MSG_HEIGHT + OFFSET);
        }
    }
}
