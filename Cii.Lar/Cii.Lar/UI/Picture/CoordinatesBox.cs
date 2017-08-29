using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cii.Lar.UI.Picture
{
    /// <summary>
    /// Draw coordinate box
    /// Author: Zhong Wen 2017/08/24
    /// </summary>
    public partial class CoordinatesBox : UserControl
    {
        //font
        private Font boxFont;
        public Font BoxFont
        {
            get
            {
                return boxFont;
            }
            set
            {
                boxFont = value;
            }
        }

        //border size
        private int boxSize;

        private Rectangle myDrawingRect = Rectangle.Empty;
        public Rectangle DrawingRect
        {
            get
            {
                return myDrawingRect;
            }
        }

        private Point myLastCoordToDraw = new Point(int.MaxValue, int.MaxValue);

        private ZoomblePictureBoxControl myPictureBoxControl;
        public ZoomblePictureBoxControl PictureBoxControl
        {
            get
            {
                return myPictureBoxControl;
            }
            set
            {
                myPictureBoxControl = value;
            }
        }

        public MeasureSystem.enUniMis UnitOfMeasure
        {
            get
            {
                return PictureBoxControl.UnitOfMeasure;
            }
        }

        //custom unit to micron
        private float UnitOfMeasureFactor
        {
            get { return MeasureSystem.CustomUnitToMicron(1, UnitOfMeasure); }
        }

        private string UnitOfMeasureString
        {
            get { return MeasureSystem.UniMisDescription(UnitOfMeasure); }
        }

        public CoordinatesBox()
        {
            InitializeComponent();
        }

        public CoordinatesBox(ZoomblePictureBoxControl pictureBox)
        {
            myPictureBoxControl = pictureBox;
            BoxFont = new Font("Arial narrow", 8);
        }

        public void DrawCoordinate(Graphics g, Point coordToDraw, bool pixelCoordMode = false)
        {
            try
            {
                if (myPictureBoxControl == null)
                {
                    return;
                }
                if (g == null)
                {
                    return;
                }
                if (coordToDraw.X == int.MaxValue || coordToDraw.Y == int.MaxValue)
                {
                    return;
                }

                myLastCoordToDraw = coordToDraw;
                boxSize = (int)Math.Ceiling(g.MeasureString("_", BoxFont).Width / 2);

                float umsf = UnitOfMeasureFactor;
                if (pixelCoordMode)
                {
                    umsf = 1;
                }

                float xValue = coordToDraw.X / umsf;
                float yValue = coordToDraw.Y / umsf;

                string textToDraw = "";

                if (pixelCoordMode)
                {
                    textToDraw = "X=" + xValue.ToString("0000.00") + ", Y=" + yValue.ToString("0000.00");
                }
                else
                {
                    if (UnitOfMeasure != MeasureSystem.enUniMis.micron)
                    {
                        textToDraw = "X=" + xValue.ToString("0000.00") + ", Y=" + yValue.ToString("0000.00") + UnitOfMeasureString;
                    }
                    else
                    {
                        textToDraw = "X=" + xValue.ToString("0000") + ", Y=" + yValue.ToString("0000") + UnitOfMeasureString;
                    }
                }

                SizeF textBoxSize = g.MeasureString(textToDraw, BoxFont);

                myDrawingRect.X = (int)(myPictureBoxControl.ClientRectangle.Width - textBoxSize.Width - boxSize);
                myDrawingRect.Y = (int)(myPictureBoxControl.ClientRectangle.Height - textBoxSize.Height - boxSize);
                myDrawingRect.Width = (int)(textBoxSize.Width + boxSize);
                myDrawingRect.Height = (int)(textBoxSize.Height + boxSize);

                g.FillRectangle(Brushes.White, myDrawingRect);
                g.DrawRectangle(Pens.Black, myDrawingRect);

                g.DrawString(textToDraw, BoxFont, Brushes.Black, myDrawingRect.X + boxSize / 2, myDrawingRect.Y + boxSize / 2);
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<CoordinatesBox>().Error(ex.Message);
                LogHelper.GetLogger<CoordinatesBox>().Error(ex.StackTrace);
            }
        }
    }
}
