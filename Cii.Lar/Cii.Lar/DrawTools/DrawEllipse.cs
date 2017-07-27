using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Cii.Lar.UI;
using System.Drawing.Drawing2D;

namespace Cii.Lar.DrawTools
{
    /// <summary>
    /// Ellipse graphic object
    /// Author:Zhong Wen 2017/07/26
    /// </summary>
    public class DrawEllipse : DrawObject
    {
        private PointF startPoint;  // point at -a (in pixel)
        private PointF endPoint;    // point at a (in pixel)
        private double coeffcient;  // height / width

        /// <summary>
        /// ellipse only for draw, need to be reset when ellipse for hit test changed. 
        /// May be no same as ellipse for hit test when drawArea.
        /// Size is not equal to default draw area size for hit test
        /// </summary>
        private Ellipse _ellipseForDraw = null;

        private Matrix orgMatrix;

        public Matrix OrgMatrix
        {
            get { return orgMatrix ?? new Matrix(); }
            set { orgMatrix = value; }
        }

        private Matrix DrawMatrix
        {
            get
            {
                Matrix matrix = OrgMatrix.Clone();
                matrix.Translate(_ellipseForDraw.Center.X, _ellipseForDraw.Center.Y);
                matrix.Rotate(_ellipseForDraw.Angle);

                return matrix;
            }
        }

        private Size _drawAreaSize = DefaultDrawAreaSize; // store draw area size for data point hit test

        public DrawEllipse()
        {
            this.Color = Color.BlueViolet;
        }

        public DrawEllipse(CursorPictureBox pictureBox, int x1, int y1, int x2, int y2, double c) : this()
        {
            startPoint = new PointF(x1, y1);
            endPoint = new PointF(x2, y2);
            coeffcient = c;

            _drawAreaSize = pictureBox.Size;
            if (_drawAreaSize != DefaultDrawAreaSize)
            {
                TransformLinear(DefaultDrawAreaSize.Width * 1.0 / _drawAreaSize.Width, DefaultDrawAreaSize.Height * 1.0 / _drawAreaSize.Height, 0, 0);
                _drawAreaSize = DefaultDrawAreaSize;
            }

        }

        public void TransformLinear(double k, double h, double m, double n)
        {
            Ellipse.TransformLinear(ref startPoint, ref endPoint, ref coeffcient, k, h, m, n);
            ResetEllipseForDraw();
        }

        private void ResetEllipseForDraw()
        {
            _ellipseForDraw = null;
        }

        /// <summary>
        /// draw ellipse graphic
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pictureBox"></param>
        public override void Draw(Graphics g, CursorPictureBox pictureBox)
        {
            if (_ellipseForDraw == null)
            {
                _ellipseForDraw = new Ellipse(startPoint, endPoint, coeffcient, _drawAreaSize);
            }

            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(this.Color, PenWidth))
            {
                try
                {
                    OrgMatrix = g.Transform;
                    g.Transform = DrawMatrix;

                    g.TranslateTransform(MovingOffset.X, MovingOffset.Y, MatrixOrder.Append);

                    g.DrawEllipse(pen, _ellipseForDraw.Rectangle);

                    g.Transform = OrgMatrix;
                }
                catch
                {
                    g.Transform = OrgMatrix;
                }
            }
        }

        /// <summary>
        /// Mouse move to new point
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="point"></param>
        /// <param name="handleNumber"></param>
        public override void MoveHandleTo(CursorPictureBox pictureBox, Point point, int handleNumber)
        {
            if (handleNumber == 2 || handleNumber == 4)
            {
                handleNumber = handleNumber == 2 ? 4 : 2;
                double lenth = Ellipse.GetTwoPointLength(_ellipseForDraw.Center, point) * 2;

                double coef = lenth / _ellipseForDraw.Width;
                if (coef < 0.1) coef = 0.1;
                if (coef > 0.99) coef = 1;
                _ellipseForDraw.Coeffcient = coef;

                UpdateEllipseForHit();

                return;
            }

            if (handleNumber == 1)
            {
                _ellipseForDraw.StartPoint = point;
            }
            else
            {
                _ellipseForDraw.EndPoint = point;
            }

            UpdateEllipseForHit();
        }

        /// <summary>
        /// update ellipse for hit
        /// </summary>
        private void UpdateEllipseForHit()
        {
            startPoint = _ellipseForDraw.StartPoint;
            endPoint = _ellipseForDraw.EndPoint;
            coeffcient = _ellipseForDraw.Coeffcient;
            if (_ellipseForDraw.DrawAreaSize != _drawAreaSize && !_ellipseForDraw.DrawAreaSize.IsEmpty)
            {
                Ellipse.TransformLinear(ref startPoint, ref endPoint, ref coeffcient, _drawAreaSize.Width * 1.0 / _ellipseForDraw.DrawAreaSize.Width, _drawAreaSize.Height * 1.0 / _ellipseForDraw.DrawAreaSize.Height, 0, 0);
            }
        }

        /// <summary>
        /// inner ellipse class 
        /// </summary>
        public class Ellipse
        {
            public PointF StartPoint
            {
                get;
                set;
            }
            public PointF EndPoint
            {
                get;
                set;
            }
            public double Coeffcient
            {
                get;
                set;
            }
            public Size DrawAreaSize
            {
                get;
                set;
            }

            public Ellipse(PointF start, PointF end, double coef, Size drawAreaSize)
            {
                StartPoint = start;
                EndPoint = end;
                Coeffcient = coef;
                DrawAreaSize = drawAreaSize;
            }

            public PointF Center   // center point of ellipse
            {
                get { return new PointF((StartPoint.X + EndPoint.X) / 2, (StartPoint.Y + EndPoint.Y) / 2); }
            }

            public double Height      // length between b and -b (in pixel)
            {
                get { return Width * Coeffcient; }
            }

            public double Width
            {
                get { return GetTwoPointLength(StartPoint, EndPoint); }
            }

            public RectangleF Rectangle
            {
                get { return new RectangleF((float)-Width / 2, (float)-Height / 2, (float)Width, (float)Height); }
            }

            public float Angle
            {
                get
                {
                    return (float)(System.Math.Atan2(EndPoint.Y - StartPoint.Y, EndPoint.X - StartPoint.X) * (180 / System.Math.PI));
                }
            }

            #region Helper Functions

            public static double GetTwoPointLength(PointF p1, PointF p2)
            {
                return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
            }

            #endregion

            /// <summary>
            /// linear transform ellipse to new draw area size
            /// </summary>
            /// <param name="newDrawAreaSize"></param>
            public void TransformLinear(Size newDrawAreaSize)
            {
                if (newDrawAreaSize.IsEmpty) return;

                double k = newDrawAreaSize.Width * 1.0 / DrawAreaSize.Width;
                double h = newDrawAreaSize.Height * 1.0 / DrawAreaSize.Height;
                double m = 0;
                double n = 0;
                PointF start = StartPoint;
                PointF end = EndPoint;
                double coef = Coeffcient;
                TransformLinear(ref start, ref end, ref coef, k, h, m, n);
                StartPoint = start;
                EndPoint = end;
                Coeffcient = coef;
                DrawAreaSize = newDrawAreaSize;
            }

            /// <summary>
            /// linear transformations for ellipse, refer to page 1 of "Linear Transform of Ellipse.docx"
            /// </summary>
            /// <param name="start">point at -a</param>
            /// <param name="end">point at a</param>
            /// <param name="coef">height / width</param>
            /// <param name="k"></param>
            /// <param name="h"></param>
            /// <param name="m"></param>
            /// <param name="n"></param>
            public static void TransformLinear(ref PointF start, ref PointF end, ref double coef, double k, double h, double m, double n)
            {
                if (start == end) return;

                PointF oldStart = start;
                PointF oldEnd = end;
                double oldCoef = coef;

                double width = GetTwoPointLength(start, end);
                double height = width * coef;
                PointF center = new PointF((start.X + end.X) / 2, (start.Y + end.Y) / 2);

                double len = GetTwoPointLength(start, end);
                double cos = (end.X - start.X) / len;
                double sin = (end.Y - start.Y) / len;
                double a = width / 2, b = height / 2;
                PointF c = center;

                // calculate A, B, C of original ellipse
                double A = Math.Pow(cos / a, 2) + Math.Pow(sin / b, 2);
                double B = 2 * cos * sin * (1 / Math.Pow(a, 2) - 1 / Math.Pow(b, 2));
                double C = Math.Pow(sin / a, 2) + Math.Pow(cos / b, 2);

                // scale
                A = A / k / k;
                B = B / k / h;
                C = C / h / h;
                double b2 = -(A + C), c2 = A * C - B * B / 4;
                double temp = Math.Max(0, b2 * b2 - 4 * c2);    // precision issue may bring a negative number
                double r = (-b2 + Math.Sqrt(temp)) / 2;
                double t = (-b2 - Math.Sqrt(temp)) / 2;

                // calculate new ellipse's parameter
                b = Math.Sqrt(1 / r);
                a = Math.Sqrt(1 / t);
                double tempRatio = Math.Max(0, (A - r) / (t - r));
                cos = t == r ? 1 : Math.Sqrt(tempRatio) * (sin * cos > 0 ? 1 : -1);
                double tempSubcos = Math.Max(0, 1 - Math.Pow(cos, 2));
                sin = Math.Sqrt(tempSubcos);

                coef = b / a;

                if (Math.Abs(coef - 1) < 1e-6)
                {
                    start.X = (float)(oldStart.X * k + m);
                    start.Y = (float)(oldStart.Y * h + n);
                    end.X = (float)(oldEnd.X * k + m);
                    end.Y = (float)(oldEnd.Y * h + n);
                }
                else
                {
                    // translate
                    start.X = (float)(-a * cos + c.X * k + m);
                    start.Y = (float)(-a * sin + c.Y * h + n);
                    end.X = (float)(a * cos + c.X * k + m);
                    end.Y = (float)(a * sin + c.Y * h + n);

                    //remain start end order
                    if ((start.X > end.X && oldStart.X < oldEnd.X) || (start.X < end.X && oldStart.X > oldEnd.X))
                    {
                        PointF tempPoint = start;
                        start = end;
                        end = tempPoint;
                    }
                }

            }
        }

    }
}
