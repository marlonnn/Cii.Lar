using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cii.Lar.UI.Picture.PublicTypes;

namespace Cii.Lar.UI.Picture
{
    public class SelectionBoxElement
    {
        public Point TopLeftCorner = Point.Empty;
        public Point BottomRightCorner = RECT.InvalidPoint();
        public bool KeepAspectRatio = false;
        public ZoomblePictureBoxControl LinkedPictureBox;
        private static Pen myBoxPenAreaSelection = new Pen(Color.FromArgb(200, Color.Black));
        private static Pen myBoxPenSingleClick = new Pen(Color.FromArgb(200, Color.Red));
        private static SolidBrush myBoxBrush = new SolidBrush(Color.FromArgb(40, Color.CadetBlue));

        #region "Proprities'"
        public bool IsInvalid
        {
            get { return BottomRightCorner == RECT.InvalidPoint() || TopLeftCorner == RECT.InvalidPoint(); }
        }
        private int PointSelectAreaSize
        {
            get { return (int)LinkedPictureBox.GraphicInfo.ToLogicalDimension(15f); }
        }
        private RECT SingleClickRectangle
        {
            get
            {
                int halfAreaSize = PointSelectAreaSize / 2;
                RECT r = new RECT(TopLeftCorner.X - halfAreaSize, TopLeftCorner.Y - halfAreaSize, TopLeftCorner.X + halfAreaSize, TopLeftCorner.Y + halfAreaSize);
                r.NormalizeRect();
                return r;
            }
        }
        public bool IsCreatedFromSinglePoint
        {
            get
            {
                if (IsInvalid)
                {
                    return false;
                }
                if ((TopLeftCorner == BottomRightCorner))
                {
                    return true;
                }
                return SingleClickRectangle.Contains(ref BottomRightCorner);
            }
        }
        #endregion

        public static implicit operator RECT(SelectionBoxElement box)
        {
            if (box.IsInvalid)
            {
                return new RECT();
            }
            if (box.IsCreatedFromSinglePoint)
            {
                return box.SingleClickRectangle;
            }
            else
            {
                return box.RectFromPoints(box.TopLeftCorner, box.BottomRightCorner);
            }
        }

        public SelectionBoxElement(ZoomblePictureBoxControl picBox)
        {
            LinkedPictureBox = picBox;
        }

        private RECT RectFromPoints(System.Drawing.Point FirstCorner, System.Drawing.Point SecondCorner)
        {
            try
            {
                if (FirstCorner == RECT.InvalidPoint() || SecondCorner == RECT.InvalidPoint())
                {
                    return new RECT();
                }

                if (KeepAspectRatio)
                {
                    int Sign = 0;
                    if ((Math.Abs((SecondCorner.X - FirstCorner.X) / LinkedPictureBox.Width)) > Math.Abs(((SecondCorner.Y - FirstCorner.Y) / LinkedPictureBox.Height)))
                    {
                        if (SecondCorner.Y > FirstCorner.Y)
                            Sign = 1;
                        else
                            Sign = -1;
                        SecondCorner.Y = FirstCorner.Y + Math.Abs((SecondCorner.X - FirstCorner.X) * (LinkedPictureBox.Height / LinkedPictureBox.Width)) * Sign;
                    }
                    else
                    {
                        if (SecondCorner.X > FirstCorner.X)
                            Sign = 1;
                        else
                            Sign = -1;
                        SecondCorner.X = FirstCorner.X + Math.Abs((SecondCorner.Y - FirstCorner.Y) * (LinkedPictureBox.Width / LinkedPictureBox.Height)) * Sign;
                    }
                }

                RECT r = new RECT(FirstCorner.X, FirstCorner.Y, SecondCorner.X, SecondCorner.Y);
                r.NormalizeRect();

                return r;
            }
            catch (Exception e)
            {
                LogHelper.GetLogger<SelectionBoxElement>().Error(e.Message);
                LogHelper.GetLogger<SelectionBoxElement>().Error(e.StackTrace);
                return new RECT();
            }
        }

        #region "Draw method"
        public void Reset()
        {
            TopLeftCorner = RECT.InvalidPoint();
            BottomRightCorner = RECT.InvalidPoint();
        }

        public void Draw(Graphics g, bool usePhysicalCoords = true)
        {
            if (this.IsInvalid)
            {
                return;
            }

            RECT r = this;

            if (usePhysicalCoords)
            {
                r = LinkedPictureBox.GraphicInfo.ToPhysicalRect(r);
            }

            if (r.IsZeroSized)
            {
                return;
            }

            if (this.IsCreatedFromSinglePoint)
            {
                g.DrawRectangle(myBoxPenSingleClick, r);
            }
            else
            {
                g.FillRectangle(myBoxBrush, r);
                g.DrawRectangle(myBoxPenAreaSelection, r);
            }
        }
        public void Invalidate()
        {
            RECT r = this;
            r = LinkedPictureBox.GraphicInfo.ToPhysicalRect(r);
            r.Inflate(1, 1);
            LinkedPictureBox.Invalidate(r);
        }
        #endregion
    }
}
