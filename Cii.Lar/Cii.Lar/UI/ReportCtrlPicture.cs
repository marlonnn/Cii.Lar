using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cii.Lar.ExpClass;

namespace Cii.Lar.UI
{
    public partial class ReportCtrlPicture : ReportCtrl
    {
        public PictureBox SubCtrl
        {
            get { return subCtrl as PictureBox; }
            set { subCtrl = value; }
        }

        public ReportPictureItem PictureItem
        {
            get { return ReportItem as ReportPictureItem; }
            set { ReportItem = value; }
        }

        public Image Picture
        {
            get
            {
                return PictureItem.Picture;
            }
            set
            {
                PictureItem.Picture = value;
                SubCtrl.Image = value;

                Rectangle rect = PictureItem.Bounds;
                rect.Width = PictureItem.Picture.Width + 12;
                rect.Height = PictureItem.Picture.Height + 12;
                PictureItem.Bounds = rect;
                this.Width = rect.Width;
                this.Height = rect.Height;
                SubCtrl.Width = PictureItem.Picture.Width;
                SubCtrl.Height = PictureItem.Picture.Height;
            }
        }

        public ReportCtrlPicture(ReportPictureItem reportItem) :base(reportItem)
        {
            InitializeComponent();
            subCtrl = new PictureBox();
            SubCtrl.Image = PictureItem.Picture;
        }

        protected override void ReportCtrl_Load(object sender, EventArgs e)
        {
            base.ReportCtrl_Load(sender, e);
            SetSubCtrl();
        }

        public override void Draw(Graphics g, Rectangle bounds)
        {
            Point p = bounds.Location;
            p.Offset(SubCtrl.Location);

            if (oldBounds.Size.Width == 0 || oldBounds.Size.Height == 0)
            {
                oldBounds.Size = this.Size;
            }

            Rectangle rectSrc = new Rectangle(new Point(0, 0), PictureItem.OldImageSize);

            Rectangle rectDec = new Rectangle(p, SubCtrl.Size);

            g.DrawImage(SubCtrl.Image, rectDec, rectSrc, GraphicsUnit.Pixel);
        }

        private void ScaleImage()
        {

        }
    }
}
