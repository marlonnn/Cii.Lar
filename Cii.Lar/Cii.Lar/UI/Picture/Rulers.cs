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

namespace Cii.Lar.UI.Picture
{
    /// <summary>
    /// Horizontal and vertical rulers on screen
    /// Author: Zhong Wen 2017/08/24
    /// </summary>
    public partial class Rulers : UserControl
    {
        public const int RulerSize = 20;
        private const double FreeSpaceFactor = 1.75;
        private const int RulerColorAlpha = 130;

        private ZoomblePictureBoxControl pictureBox;
        public ZoomblePictureBoxControl PictureBox
        {
            get
            {
                return pictureBox;
            }
            private set
            {
                if (pictureBox != null)
                {
                    pictureBox.OnMeasureUnitChanged -= PictureBox_MeasureUnitChanged;

                }
                pictureBox = value;
                if (pictureBox != null)
                {
                    pictureBox.OnMeasureUnitChanged += PictureBox_MeasureUnitChanged;

                }
            }
        }

        public Color RulerColor
        {
            get { return Color.FromArgb(RulerColorAlpha, Color.LightYellow); }
        }

        private Pen rulerPen;
        public Pen RulerPen
        {
            get
            {
                return rulerPen;
            }
            set
            {
                rulerPen = value;
            }
        }

        private Pen myDragPen = null;
        private Image myOriginBmp = null;
        private Bitmap myOriginBmpSnapped = null;
        private DrawNumberBitmap digitMaskCreator;

        private Bitmap myHRulerBmp = null;
        private Bitmap myVRulerBmp = null;

        private Color myDragLineColor = Color.Black;

        private int mySize = RulerSize;
        public new int Size
        {
            get { return mySize; }
            set
            {
                if (mySize == value)
                {
                    return;
                }
                mySize = value;
                myHRulerBmp = null;
                myVRulerBmp = null;
            }
        }

        public new int Width
        {
            get
            {
                return PictureBox.Width;
            }
        }

        public new int Height
        {
            get
            {
                return PictureBox.Height;
            }
        }

        private ConversionInfo myLastGraphicInfo = null;

        private bool NeedsHorizontalRedraw = true;
        private bool NeedsVerticalRedraw = true;

        public MeasureSystem.enUniMis UnitOfMeasure
        {
            get
            {
                return PictureBox.UnitOfMeasure;
            }
        }

        public float ScaleFactor
        {
            get
            {
                return PictureBox.ScaleFactor;
            }
        }

        public int LogicalWidth
        {
            get
            {
                if (ScaleFactor != 0)
                {
                    return (int)(Width / ScaleFactor);
                }
                return 0;
            }
        }

        public int LogicalHeight
        {
            get
            {
                if (ScaleFactor != 0)
                {
                    return (int)(Height / ScaleFactor);
                }
                return 0;
            }
        }

        public int LogicalSize
        {
            get
            {
                if (ScaleFactor != 0)
                {
                    return (int)(Size / ScaleFactor);
                }
                return 0;
            }
        }

        public Point LogicalOrigin
        {
            get { return PictureBox.LogicalOrigin; }
        }

        private int NeededBitmapWidth
        {
            get
            {
                int newWidth = PictureBox.Width;
                newWidth = (int)Math.Ceiling(Convert.ToDouble(newWidth) / 100.0) * 100;
                return newWidth;
            }
        }

        private int NeededBitmapHeight
        {
            get
            {

                int newHeight = PictureBox.Height;
                newHeight = (int)Math.Ceiling(Convert.ToDouble(newHeight) / 100.0) * 100;
                return newHeight;
            }
        }

        private int NeededBitmapRulerSize
        {
            get
            {
                return Size;
            }
        }

        public Rulers(ZoomblePictureBoxControl pictureBox)
        {
            InitializeComponent();
            this.PictureBox = pictureBox;
            RulerPen = new Pen(Color.Navy);
            digitMaskCreator = new DrawNumberBitmap(RulerPen);

            myOriginBmp = Properties.Resources.Rulers_RulerOrigin;
            myOriginBmpSnapped = Properties.Resources.Rulers_RulerOriginSnap;

            Size = Math.Max(myOriginBmp.Width, myOriginBmp.Height);
        }

        /// <summary>
        /// returns the value of the per step displayed on the shares of a ruler
        /// </summary>
        /// <param name="horizontalRuler"></param>
        /// <returns></returns>
        private int CalculateBaseStep(bool horizontalRuler)
        {
            float startValue = 0;
            float stopValue = 0;
            float maxNumberWidth = 0;

            if (horizontalRuler)
            {
                startValue = LogicalOrigin.X;
                stopValue = LogicalOrigin.X + LogicalWidth;
            }
            else
            {
                startValue = LogicalOrigin.Y;
                stopValue = LogicalOrigin.Y + LogicalHeight;
            }

            startValue /= MeasureSystem.CustomUnitToMicron(1, UnitOfMeasure);
            stopValue /= MeasureSystem.CustomUnitToMicron(1, UnitOfMeasure);
            startValue = digitMaskCreator.MaskWidth(startValue);
            stopValue = digitMaskCreator.MaskWidth(stopValue);

            maxNumberWidth = Math.Max(startValue, stopValue);

            int availableSpace = 0;
            if (horizontalRuler)
            {
                availableSpace = Convert.ToInt32(PictureBox.GraphicInfo.ToPhysicalDimension(LogicalWidth));
            }
            else
            {
                availableSpace = Convert.ToInt32(PictureBox.GraphicInfo.ToPhysicalDimension(LogicalHeight));
            }

            int totalNumQuotes = availableSpace / Convert.ToInt32(maxNumberWidth);
            if (totalNumQuotes == 0)
            {
                return 0;
            }

            if (horizontalRuler)
            {
                return LogicalWidth / totalNumQuotes;
            }
            else
            {
                return LogicalHeight / totalNumQuotes;
            }
        }

        /// <summary>
        /// redraw hotizontal ruler
        /// </summary>
        /// <returns></returns>
        private Bitmap RedrawHorizontalRuler()
        {
            Graphics g = null;
            try
            {
                if (Width <= 0)
                {
                    return null;
                }

                g = PictureBox.GetScaledGraphicObject(myHRulerBmp);
                int rulerLogicSize = (int)((Size - 1) / ScaleFactor);

                g.Clear(RulerColor);

                g.DrawLine(RulerPen, LogicalOrigin.X + rulerLogicSize, LogicalOrigin.Y + rulerLogicSize, LogicalOrigin.X + LogicalWidth, LogicalOrigin.Y + rulerLogicSize);

                float RulerValueFactor = (float)(1.0 / MeasureSystem.CustomUnitToMicron(1, UnitOfMeasure));

                float rulerStep = GetRulerStep();
                if ((rulerStep <= 0))
                {
                    return myHRulerBmp;
                }


                int XDisplacement = 0;
                int OverNeedles = 0;

                XDisplacement = 0;
                OverNeedles = 1;

                float startPoint = (float)Math.Ceiling((LogicalOrigin.X + rulerLogicSize) / rulerStep) * rulerStep + XDisplacement;
                int yCoord = (int)(LogicalOrigin.Y + 2 / ScaleFactor);
                int yHalfLine = LogicalOrigin.Y + rulerLogicSize / 2;
                int yQuarterLine = LogicalOrigin.Y + rulerLogicSize - rulerLogicSize / 4;
                int yRulerBase = LogicalOrigin.Y + rulerLogicSize;

                for (float xCoord = startPoint; xCoord <= LogicalOrigin.X + LogicalWidth; xCoord += rulerStep)
                {
                    g.DrawLine(RulerPen, xCoord, yHalfLine, xCoord, yRulerBase);
                    g.DrawLine(RulerPen, Convert.ToInt32(xCoord + rulerStep / 2), yQuarterLine, Convert.ToInt32(xCoord + rulerStep / 2), yRulerBase);
                    digitMaskCreator.DrawScaledNumber(g, (xCoord - XDisplacement) * RulerValueFactor - OverNeedles + 1, xCoord, yCoord, ScaleFactor, true);
                }

                NeedsHorizontalRedraw = false;

                return myHRulerBmp;
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<Rulers>().Error(ex.Message);
                LogHelper.GetLogger<Rulers>().Error(ex.StackTrace);
                return null;
            }
            finally
            {
                if (g != null)
                {
                    g.Dispose();
                }
            }
        }

        /// <summary>
        /// redraw vertical ruler
        /// </summary>
        /// <returns></returns>
        private Bitmap RedrawVerticalRuler()
        {
            Graphics g = null;

            try
            {
                if (Height <= 0)
                {
                    return null;
                }

                g = PictureBox.GetScaledGraphicObject(myVRulerBmp);
                int rulerLogicSize = (int)((Size - 1) / ScaleFactor);

                g.Clear(RulerColor);

                g.DrawLine(RulerPen, LogicalOrigin.X + rulerLogicSize, LogicalOrigin.Y + rulerLogicSize, LogicalOrigin.X + rulerLogicSize, LogicalOrigin.Y + LogicalHeight);

                float RulerValueFactor = (float)(1.0 / MeasureSystem.CustomUnitToMicron(1, UnitOfMeasure));

                float rulerStep = GetRulerStep();

                if ((rulerStep <= 0))
                {
                    return myVRulerBmp;
                }

                int startPoint = (int)(Math.Ceiling((LogicalOrigin.Y + rulerLogicSize) / rulerStep) * rulerStep);

                int xCoord = (int)(LogicalOrigin.X + 2 / ScaleFactor);
                int xHalfLine = LogicalOrigin.X + rulerLogicSize / 2;
                int xQuarterLine = LogicalOrigin.X + rulerLogicSize - rulerLogicSize / 4;
                int xRulerBase = LogicalOrigin.X + rulerLogicSize;

                for (float yCoord = startPoint; yCoord <= LogicalOrigin.Y + LogicalHeight; yCoord += rulerStep)
                {
                    g.DrawLine(RulerPen, xHalfLine, yCoord, xRulerBase, yCoord);
                    g.DrawLine(RulerPen, xQuarterLine, Convert.ToInt32(yCoord + rulerStep / 2), xRulerBase, Convert.ToInt32(yCoord + rulerStep / 2));
                    digitMaskCreator.DrawScaledNumber(g, yCoord * RulerValueFactor, xCoord, yCoord, ScaleFactor, false);
                }

                NeedsVerticalRedraw = false;

                return myVRulerBmp;
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<Rulers>().Error(ex.Message);
                LogHelper.GetLogger<Rulers>().Error(ex.StackTrace);
                return null;
            }
            finally
            {
                if (g != null)
                {
                    g.Dispose();
                }
            }
        }

        private void CreateDragPen()
        {
            myDragPen = new Pen(myDragLineColor);
            float[] DashPattern = {
                20,
                7,
                1,
                7
            };
            myDragPen.DashPattern = DashPattern;
            myDragPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
        }

        /// <summary>
        /// check horizontal ruler bitmap
        /// </summary>
        private void CheckHorizontalRulerBitmap()
        {
            if ((myHRulerBmp != null) && (myHRulerBmp.Width != NeededBitmapWidth))
            {
                myHRulerBmp.Dispose();
                myHRulerBmp = null;
            }
            if ((myHRulerBmp == null))
            {
                myHRulerBmp = new Bitmap(NeededBitmapWidth, NeededBitmapRulerSize);
                NeedsHorizontalRedraw = true;
            }
        }

        private void CheckVerticalRulerBitmap()
        {
            if ((myVRulerBmp != null) && (myVRulerBmp.Height != NeededBitmapHeight))
            {
                myVRulerBmp.Dispose();
                myVRulerBmp = null;
            }
            if ((myVRulerBmp == null))
            {
                myVRulerBmp = new Bitmap(NeededBitmapRulerSize, NeededBitmapHeight);
                NeedsVerticalRedraw = true;
            }
        }

        /// <summary>
        /// picture boc measure unit changed invoke event
        /// </summary>
        /// <param name="unit"></param>
        private void PictureBox_MeasureUnitChanged(MeasureSystem.enUniMis unit)
        {
            NeedsHorizontalRedraw = true;
            NeedsVerticalRedraw = true;
        }

        public void Draw(Graphics g)
        {
            try
            {
                if ((Width <= 0) || (Height <= 0))
                {
                    return;
                }

                if ((myLastGraphicInfo == null) || (myLastGraphicInfo != PictureBox.GraphicInfo))
                {
                    NeedsHorizontalRedraw = true;
                    NeedsVerticalRedraw = true;
                }

                CheckHorizontalRulerBitmap();
                CheckVerticalRulerBitmap();

                if (NeedsHorizontalRedraw)
                {
                    RedrawHorizontalRuler();
                }
                if (NeedsVerticalRedraw)
                {
                    RedrawVerticalRuler();
                }

                myLastGraphicInfo = (ConversionInfo)PictureBox.GraphicInfo.Clone();


                bool bitmapOk = true;
                bitmapOk = bitmapOk && (myHRulerBmp != null) && (myHRulerBmp.Width > 0) && (myHRulerBmp.Height > 0);
                bitmapOk = bitmapOk && (myVRulerBmp != null) && (myVRulerBmp.Width > 0) && (myVRulerBmp.Height > 0);
                bitmapOk = bitmapOk && (myOriginBmp != null) && (myOriginBmp.Width > 0) && (myOriginBmp.Height > 0);
                bitmapOk = bitmapOk && (myOriginBmpSnapped != null) && (myOriginBmpSnapped.Width > 0) && (myOriginBmpSnapped.Height > 0);
                if (!bitmapOk)
                {
                    return;
                }

                GraphicsState oldState = g.Save();
                g.ResetTransform();

                try
                {
                    g.DrawImageUnscaled(myHRulerBmp, 0, 0);
                    g.DrawImageUnscaled(myVRulerBmp, 0, 0);

                    g.DrawImage(myOriginBmp, 0, 0, myOriginBmp.Width, myOriginBmp.Height);
                }
                catch (Exception ex)
                {
                    LogHelper.GetLogger<Rulers>().Error(ex.Message);
                    LogHelper.GetLogger<Rulers>().Error(ex.StackTrace);
                }
                finally
                {
                    g.Restore(oldState);
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<Rulers>().Error(ex.Message);
                LogHelper.GetLogger<Rulers>().Error(ex.StackTrace);
            }
        }

        /// <summary>
        /// returns to the step of horizontal or vertical ruler
        /// </summary>
        /// <returns></returns>
        public float GetRulerStep()
        {
            // find the step of basis on which to write the numbers in the ruler [micron]
            //the basic step is the step most necessary for the two rulers(horizontal and vertical)
            double stepValue = Math.Max(CalculateBaseStep(true), CalculateBaseStep(false));

            if (stepValue == 0)
            {
                return 1f;
            }

            stepValue *= FreeSpaceFactor;

            double baseUnit = 1;
            if (UnitOfMeasure == MeasureSystem.enUniMis.inches)
            {
                stepValue /= 25400;
                baseUnit = 25400;
            }

            double[] valuesArray = {
                1,
                2,
                5
            };

            double actualLog = 0;
            double actualRounded = 0;
            double actualError = 0;
            double bestStep = 0;
            double minError = double.MaxValue;
            foreach (double actualValue in valuesArray)
            {
                actualLog = Math.Log10(stepValue / actualValue);
                actualRounded = Math.Round(actualLog);
                actualError = Math.Abs(actualRounded - actualLog);
                if (actualError < minError)
                {
                    bestStep = actualValue * baseUnit * Math.Pow(10, actualRounded);
                    minError = actualError;
                }
            }
            return (float)bestStep;
        }
    }
}
