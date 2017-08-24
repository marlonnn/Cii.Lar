using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cii.Lar.UI.Picture.PublicTypes;

namespace Cii.Lar.UI.Picture
{
    public delegate void CaptureFishedEventHandler(object sender, CaptureEventArgs e);

    public class CaptureEventArgs : EventArgs
    {
        private readonly Point startPoint;

        private readonly Point endPoint;
        public CaptureEventArgs(Point startPoint, Point endPoint)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
        }

        public Point StartPoint
        {
            get { return startPoint; }
        }

        public Point EndPoint
        {
            get { return endPoint; }
        }
    }

    /// <summary>
    /// Calculate distance ruler tool
    /// Author: Zhong Wen 2017/08/24
    /// </summary>
    public class DistanceRuler
    {
        public event CaptureFishedEventHandler CaptureFinished;
        private bool mouseCaptured;
        private float angle;
        private float length;
        private Point origin;

        private Point last;
        private int lineWidth = 5;

        private float[] compArray = new float[]
        {
            0.0f,
            0.16f,
            0.33f,
            0.66f,
            0.83f,
            1.0f
        };

        private ZoomblePictureBoxControl myPictureBoxControl;
        public ZoomblePictureBoxControl PictureBoxControl
        {
            get { return myPictureBoxControl; }
            private set { myPictureBoxControl = value; }
        }
        private MeasureSystem.enUniMis UnitOfMeasure
        {
            get { return PictureBoxControl.UnitOfMeasure; }
        }
        public DistanceRuler(ZoomblePictureBoxControl pictureBox)
        {
            if (pictureBox == null)
            {
                throw new ArgumentNullException("pictureBox", "MouseCapture must be associated with a control.");
            }

            myPictureBoxControl = pictureBox;
        }

        public Color Backcolor
        {
            get { return myPictureBoxControl.BackgroundColor; }
            set { myPictureBoxControl.BackgroundColor = value; }
        }
        public Color ForeColor
        {
            get { return myPictureBoxControl.ForeColor; }
            set { myPictureBoxControl.ForeColor = value; }
        }
        public int LineWidth
        {
            get { return lineWidth; }
            set
            {
                if (lineWidth < 1)
                {
                    throw new ArgumentOutOfRangeException("LineWidth", value, "Line width must greater than or equal to one.");
                }
                lineWidth = value;
            }
        }

        /// <summary>
        /// Gets or sets an array values that specify a compound pen. A compound pen draws a compound line made up of parallel lines and spaces.
        /// </summary>
        /// <value>An array of single values.</value>
        /// <remarks>A compound line is made up of alternating parallel lines and spaces of varying widths.
        /// The values in the array specify the starting points of each component of the compound line 
        /// relative to the pen's width. The first value in the array specifies where the first component 
        /// (a line) begins as a fraction of the distance across the width of the pen. The second value in the 
        /// array specifies the beginning of the next component (a space) as a fraction of the distance across 
        /// the width of the pen. The final value in the array specifies where the last component ends.
        /// Suppose you want a pen to draw two parallel lines where the width of the first line is 20 percent of 
        /// the pen's width, the width of the space that separates the two lines is 50 percent of the pen' s width, 
        /// and the width of the second line is 30 percent of the pen's width. Start by creating a Pen object and 
        /// an array of real numbers. 
        /// Set the compound array by passing the array with the values 0.0, 0.2, 0.7, and 1.0 to this property.
        /// </remarks>
        public float[] LineCompoundArray
        {
            get { return compArray; }
            set
            {
                foreach (float i in value)
                {
                    if (i < 0 || i > 1)
                    {
                        throw new ArgumentOutOfRangeException("LineCompoundArray", i, "All elements in the compound array must be >=0 or <=1.");
                    }
                }
                compArray = value;
            }
        }
        private double CvRadToDeg(double RadAngle)
        {
            return RadAngle * (180 / (System.Math.Atan(1) * 4));
        }

        public static double CutDecimals(double Value, int DesiredDecDigits)
        {
            double functionReturnValue = 0;
            try
            {
                if ((Value == double.NegativeInfinity || Value == double.PositiveInfinity))
                {
                    return Value;
                }
                if (DesiredDecDigits > 5)
                {
                    DesiredDecDigits = 5;
                }
                functionReturnValue = Convert.ToInt32(Value * Math.Pow(10, DesiredDecDigits)) / (Math.Pow(10, DesiredDecDigits));
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<DistanceRuler>().Error(ex.Message);
                LogHelper.GetLogger<DistanceRuler>().Error(ex.StackTrace);
                functionReturnValue = Value;
            }
            return functionReturnValue;
        }
        public static string strCutDecimals(double Value, int DesiredDecDigits)
        {
            return Convert.ToString(CutDecimals(Value, DesiredDecDigits));
        }

        public void Painting(Graphics GR, double ScaleFactor = 1.0)
        {
            if (!mouseCaptured)
            {
                return;
            }

            int OriginCrossArmLength = 20;

            double CurrentAngle = new SEGMENT(origin.X, origin.Y, last.X, last.Y).SegmentDirection();
            CurrentAngle = CvRadToDeg(CurrentAngle);

            if (CurrentAngle > 180)
            {
                CurrentAngle = CurrentAngle - 360;
            }
            float Scale = PictureBoxControl.ScaleFactor * UnitOfMeasureFactor;
            using (Pen wallpen = new Pen(myPictureBoxControl.ForeColor, 1))
            {
                Point midPoint = new Point();
                midPoint.X = Math.Min(origin.X, last.X) + ((Math.Max(origin.X, last.X) - Math.Min(origin.X, last.X)) / 2);
                midPoint.Y = Math.Min(origin.Y, last.Y) + ((Math.Max(origin.Y, last.Y) - Math.Min(origin.Y, last.Y)) / 2);



                GR.DrawLine(wallpen, origin.X - OriginCrossArmLength, origin.Y, origin.X + OriginCrossArmLength, origin.Y);
                GR.DrawLine(wallpen, origin.X, origin.Y - OriginCrossArmLength, origin.X, origin.Y + OriginCrossArmLength);
                GR.DrawArc(wallpen, origin.X - OriginCrossArmLength, origin.Y - OriginCrossArmLength, 2 * OriginCrossArmLength, 2 * OriginCrossArmLength, 0, Convert.ToInt32(-CurrentAngle));

                using (System.Drawing.Drawing2D.Matrix mx = new System.Drawing.Drawing2D.Matrix())
                {
                    using (StringFormat sf = new StringFormat())
                    {
                        string lineLength = (LineLength(origin, last, Scale) / ScaleFactor).ToString("F2");
                        string ls = string.Format("{0} ({1}°)", lineLength, strCutDecimals(CurrentAngle, 1));
                        //ls = string.Format(LineLength(origin, last, Scale) / ScaleFactor, "#.00") + "  (" + strCutDecimals(CurrentAngle, 1) + "�)";
                        SizeF l = GR.MeasureString(ls, myPictureBoxControl.Font, myPictureBoxControl.ClientSize, sf);
                        sf.LineAlignment = StringAlignment.Center;
                        sf.Alignment = StringAlignment.Center;
                        GR.DrawLine(wallpen, origin, last);
                        mx.Translate(midPoint.X, midPoint.Y);
                        mx.Rotate(Angle(origin, last));
                        GR.Transform = mx;
                        Rectangle rt = new Rectangle(0, 0, (int)l.Width, (int)l.Height);
                        rt.Inflate(3, 3);
                        rt.Offset(-(int)(l.Width / 2), -(int)(l.Height / 2));
                        using (SolidBrush backBrush = new SolidBrush(myPictureBoxControl.BackgroundColor))
                        {
                            GR.FillEllipse(backBrush, rt);
                        }
                        using (SolidBrush foreBrush = new SolidBrush(myPictureBoxControl.ForeColor))
                        {
                            GR.DrawString(ls, myPictureBoxControl.Font, foreBrush, 0, 0, sf);
                        }
                    }
                }
            }
        }

        public void MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mouseCaptured = true;
            origin = e.Location;
            last = new Point(-1, -1);
        }

        public void MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (mouseCaptured)
            {
                Rectangle r = NormalizeRect(origin, last);
                r.Inflate(myPictureBoxControl.Font.Height, myPictureBoxControl.Font.Height);
                last = e.Location;
            }
        }

        public void MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mouseCaptured = false;
            myPictureBoxControl.Invalidate();
            if (CaptureFinished != null)
            {
                CaptureFinished(this, new CaptureEventArgs(origin, e.Location));
            }
        }

        private float UnitOfMeasureFactor
        {
            get { return MeasureSystem.CustomUnitToMicron(1, UnitOfMeasure); }
        }

        private Rectangle NormalizeRect(Point p1, Point p2)
        {
            Rectangle r = new Rectangle();
            if (p1.X < p2.X)
            {
                r.X = p1.X;
                r.Width = p2.X - p1.X;
            }
            else
            {
                r.X = p2.X;
                r.Width = p1.X - p2.X;
            }
            if (p1.Y < p2.Y)
            {
                r.Y = p1.Y;
                r.Height = p2.Y - p1.Y;
            }
            else
            {
                r.Y = p2.Y;
                r.Height = p1.Y - p2.Y;
            }
            return r;
        }

        private float LineLength(Point p1, Point p2, float ScaleFactor = 1)
        {
            Rectangle r = NormalizeRect(p1, p2);
            length = (float)(Math.Sqrt(Math.Pow(r.Width, 2) + Math.Pow(r.Height, 2)) / ScaleFactor);
            return length;
        }

        private float Angle(Point p1, Point p2)
        {
            angle = (float)(Math.Atan((p1.Y - p2.Y) / (p1.X - p2.X)) * (180 / Math.PI));
            return angle;
        }
        private void Dispose(bool disposing)
        {
            try
            {
                myPictureBoxControl = null;

            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<DistanceRuler>().Error(ex.Message);
                LogHelper.GetLogger<DistanceRuler>().Error(ex.StackTrace);
            }
        }
    }
}
