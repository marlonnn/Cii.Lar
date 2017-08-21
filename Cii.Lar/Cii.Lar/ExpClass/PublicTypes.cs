using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar.ExpClass
{
    /// <summary>
    /// Public types contains: RECT and SEGMENT
    /// </summary>
    public class PublicTypes
    {
        public enum GridKind
        {
            FullLines = 0,
            Points = 1,
            Crosses = 2
        }

        public enum enClickAction
        {
            None = 0,
            Zoom = 2,
            MeasureDistance = 3
        }

        public enum ResizeMode
        {
            Normal,
            Stretch
        }

        public struct RECT
        {
            public static System.Drawing.Point InvalidPoint()
            {
                System.Drawing.Point retVal = new System.Drawing.Point();
                retVal.X = int.MaxValue;
                retVal.Y = int.MaxValue;
                return retVal;
            }

            #region "Public members"
            public int left;
            public int top;
            public int right;
            public int bottom;
            #endregion

            #region "Operators"

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;

                if (GetType() != obj.GetType())
                    return false;
                RECT r = (RECT)obj;
                if (this.GetHashCode() == r.GetHashCode())
                    return true;
                else
                    return false;
            }

            public static bool operator ==(RECT R1, RECT R2)
            {
                return R1.top == R2.top && R1.left == R2.left && R1.right == R2.right && R1.bottom == R2.bottom;
            }
            public static bool operator !=(RECT R1, RECT R2)
            {
                return R1.top != R2.top || R1.left != R2.left || R1.right != R2.right || R1.bottom != R2.bottom;
            }

            public static implicit operator Rectangle(RECT InRect)
            {
                return new Rectangle(InRect.left, InRect.top, InRect.right - InRect.left, InRect.bottom - InRect.top);
            }

            public static implicit operator RectangleF(RECT InRect)
            {
                return new RectangleF(InRect.left, InRect.top, InRect.right - InRect.left, InRect.bottom - InRect.top);
            }

            public static implicit operator RECT(RectangleF InRect)
            {
                return new RECT(InRect);
            }
            #endregion

            #region "Constructors"
            public RECT(RECT InRect)
            {
                top = InRect.Y;
                left = InRect.X;
                right = InRect.X + InRect.Width;
                bottom = InRect.Y + InRect.Height;
            }
            public RECT(Rectangle InRect)
            {
                top = InRect.Y;
                left = InRect.X;
                try
                {
                    right = InRect.X + InRect.Width;
                    bottom = InRect.Y + InRect.Height;
                }
                catch (Exception ex)
                {
                    LogHelper.GetLogger<RECT>().Error(ex.Message);
                    LogHelper.GetLogger<RECT>().Error(ex.StackTrace);
                    right = InRect.X + 1000;
                    bottom = InRect.Y + 1000;
                }
            }
            public RECT(RectangleF InRect)
            {
                top = Convert.ToInt32(InRect.Y);
                left = Convert.ToInt32(InRect.X);
                right = Convert.ToInt32(InRect.X + InRect.Width);
                bottom = Convert.ToInt32(InRect.Y + InRect.Height);
            }
            public RECT(Point[] vector)
            {
                top = left = right = bottom = 0;
                try
                {
                    if (vector == null)
                    {
                        return;
                    }
                    else
                    {
                        int TotalPoints = vector.Length;
                        if (TotalPoints == 0)
                        {
                            return;
                        }
                        else
                        {
                            left = vector[0].X;
                            right = vector[0].X;
                            top = vector[0].Y;
                            bottom = vector[0].Y;
                            for (int iCounter = 1; iCounter <= TotalPoints - 1; iCounter++)
                            {
                                if (vector[iCounter].X > right)
                                {
                                    right = vector[iCounter].X;
                                }
                                else
                                {
                                    if (vector[iCounter].X < left)
                                    {
                                        left = vector[iCounter].X;
                                    }
                                }
                                if (vector[iCounter].Y > bottom)
                                {
                                    bottom = vector[iCounter].Y;
                                }
                                else
                                {
                                    if (vector[iCounter].Y < top)
                                    {
                                        top = vector[iCounter].Y;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.GetLogger<RECT>().Error(ex.Message);
                    LogHelper.GetLogger<RECT>().Error(ex.StackTrace);
                }
            }
            public RECT(int left, int top, int right, int bottom)
            {
                this.top = top;
                this.left = left;
                this.right = right;
                this.bottom = bottom;
            }
            public RECT(System.Drawing.Point pointTopLeft, System.Drawing.Size size)
            {
                left = pointTopLeft.X;
                top = pointTopLeft.Y;
                right = pointTopLeft.X + size.Width;
                bottom = pointTopLeft.Y + size.Height;
            }
            public RECT(System.Drawing.Point pointTopLeft, System.Drawing.Point pointBottomRight)
            {
                left = pointTopLeft.X;
                top = pointTopLeft.Y;
                right = pointBottomRight.X;
                bottom = pointBottomRight.Y;
            }

            #endregion

            #region "Properties'"
            public int X
            {
                get { return this.left; }
                set
                {
                    this.left = value;
                    this.right = this.left + this.Width;
                }
            }
            public int Y
            {
                get { return this.top; }
                set
                {
                    this.top = value;
                    this.bottom = this.top + this.Height;
                }
            }
            public int Width
            {
                get { return right - left; }
                set { right = left + value; }
            }
            public int Height
            {
                get { return bottom - top; }
                set { bottom = top + value; }
            }
            public Point CenterPoint
            {
                get { return new Point((left + right) / 2, (top + bottom) / 2); }
            }
            public System.Drawing.Size Size
            {
                get { return new System.Drawing.Size(Width, Height); }
            }
            public System.Drawing.Point TopLeft
            {
                get { return new System.Drawing.Point(this.left, this.top); }
                set
                {
                    this.left = value.X;
                    this.top = value.Y;
                }
            }
            public System.Drawing.Point TopRight
            {
                get { return new System.Drawing.Point(this.right, this.top); }
                set
                {
                    this.right = value.X;
                    this.top = value.Y;
                }
            }
            public System.Drawing.Point BottomRight
            {
                get { return new System.Drawing.Point(this.right, this.bottom); }
                set
                {
                    this.right = value.X;
                    this.bottom = value.Y;
                }
            }
            public System.Drawing.Point BottomCenter
            {
                get { return new System.Drawing.Point((this.left + this.right) / 2, this.bottom); }
            }
            public System.Drawing.Point TopCenter
            {
                get { return new System.Drawing.Point((this.left + this.right) / 2, this.top); }
            }
            public System.Drawing.Point LeftCenter
            {
                get { return new System.Drawing.Point(this.left, (this.top + this.bottom) / 2); }
            }
            public System.Drawing.Point RightCenter
            {
                get { return new System.Drawing.Point(this.right, (this.top + this.bottom) / 2); }
            }
            public System.Drawing.Point BottomLeft
            {
                get { return new System.Drawing.Point(this.left, this.bottom); }
                set
                {
                    this.left = value.X;
                    this.bottom = value.Y;
                }
            }
            public bool IsZeroSized
            {
                get { return (this.Height == 0 && this.Width == 0); }
            }
            public bool IsNonZeroSized
            {
                get { return !IsZeroSized; }
            }
            public bool IsNormalized
            {
                get { return (this.right >= this.left) && (this.bottom >= this.top); }
            }
            #endregion

            #region "Funzioni pubbliche"

            #region "Routine per la normalizzazione del rettangolo"
            public void AssertIfNotNormalized()
            {
                if (IsNormalized)
                {
                    return;
                }
                else
                {
                    if (!(this.right >= this.left))
                    {
                        //Debug.Assert(this.right >= this.left, "RECT.right e RECT.left sono invertite!");
                    }
                    if (!(this.bottom >= this.top))
                    {
                        // Debug.Assert(this.bottom >= this.top, "RECT.bottom e RECT.top sono invertite!");
                    }
                }
            }
            public void NormalizeRect()
            {
                if (!(this.right >= this.left))
                {
                    int tmp = this.right;
                    this.right = this.left;
                    this.left = tmp;
                }
                if (!(this.bottom >= this.top))
                {
                    int tmp = this.bottom;
                    this.bottom = this.top;
                    this.top = tmp;
                }
            }
            #endregion

            #region "Routine per spostare il rettangolo"
            public void Offset(int x, int y)
            {
                left = left + x;
                top = top + y;
                right = right + x;
                bottom = bottom + y;
            }
            public void Offset(System.Drawing.Point offs)
            {
                Offset(offs.X, offs.Y);
            }
            #endregion

            #region "Routine per ridimensionare il rettangolo"
            public void Inflate(Size size)
            {
                this.Inflate(size.Width, size.Height);
            }
            public void Inflate(int width, int height)
            {
                this.left = (this.left - width);
                this.top = (this.top - height);
                this.right = (this.right + width);
                this.bottom = (this.bottom + height);
            }
            public void Inflate(int left, int top, int right, int bottom)
            {
                this.left = (this.left - left);
                this.top = (this.top - top);
                this.right = (this.right + right);
                this.bottom = (this.bottom + bottom);
            }
            public RECT ExpandFromFixedPoint(float zoomMultiplier, Point fixedPoint)
            {
                float distanceX = this.left - fixedPoint.X;
                float distanceY = this.top - fixedPoint.Y;
                distanceX *= zoomMultiplier;
                distanceY *= zoomMultiplier;

                float newOriginX = fixedPoint.X + distanceX;
                float newOriginY = fixedPoint.Y + distanceY;

                float newWidth = zoomMultiplier * this.Width;
                float newHeight = zoomMultiplier * this.Height;

                return new RECT((int)newOriginX, (int)newOriginY, (int)(newOriginX + newWidth), (int)(newOriginY + newHeight));
            }

            #endregion

            #region "Routine di check per punti o RECT contenuti"
            public bool IsContainedIn(ref RECT ARect)
            {
                try
                {
                    // Check preliminari
                    this.AssertIfNotNormalized();
                    ARect.AssertIfNotNormalized();
                    // Controllo le coordinate
                    if ((this.bottom <= ARect.bottom) && (this.top >= ARect.top))
                    {
                        if ((this.left >= ARect.left) && (this.right <= ARect.right))
                        {
                            return true;
                        }
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    LogHelper.GetLogger<RECT>().Error(ex.Message);
                    LogHelper.GetLogger<RECT>().Error(ex.StackTrace);
                    return false;
                }
            }
            public bool Contains(ref RECT ARect)
            {
                return ARect.IsContainedIn(ref this);
            }
            public bool Contains(ref Rectangle ARect)
            {
                RECT ar = new RECT(ARect);
                return ar.IsContainedIn(ref this);
            }
            public bool Contains(ref System.Drawing.PointF pt)
            {
                try
                {
                    AssertIfNotNormalized();
                    if (pt.X > this.right || pt.X < this.left)
                        return false;
                    if (pt.Y > this.bottom || pt.Y < this.top)
                        return false;
                    return true;
                }
                catch (Exception ex)
                {
                    LogHelper.GetLogger<RECT>().Error(ex.Message);
                    LogHelper.GetLogger<RECT>().Error(ex.StackTrace);
                    return false;
                }
            }
            public bool Contains(ref System.Drawing.Point pt)
            {
                try
                {
                    AssertIfNotNormalized();
                    if (pt.X > this.right || pt.X < this.left)
                        return false;
                    if (pt.Y > this.bottom || pt.Y < this.top)
                        return false;
                    return true;
                }
                catch (Exception ex)
                {
                    LogHelper.GetLogger<RECT>().Error(ex.Message);
                    LogHelper.GetLogger<RECT>().Error(ex.StackTrace);
                    return false;
                }
            }
            #endregion

            public bool IntersectsWith(ref RECT rect)
            {
                AssertIfNotNormalized();
                rect.AssertIfNotNormalized();
                return !Intersect(ref this, ref rect).IsZeroSized;
            }

            public override string ToString()
            {
                return string.Format("Left={0} Top={1} Right={2} Bottom={3} [Width={4},Height={5}]", left, top, right, bottom, Width, Height);
            }

            public System.Drawing.Point[] ToPointArray()
            {
                System.Drawing.Point[] _PArr = new System.Drawing.Point[5];
                _PArr[0].X = this.left;
                _PArr[0].Y = this.top;
                _PArr[1].X = this.left;
                _PArr[1].Y = this.bottom;
                _PArr[2].X = this.right;
                _PArr[2].Y = this.bottom;
                _PArr[3].X = this.right;
                _PArr[3].Y = this.top;
                _PArr[4].X = this.left;
                _PArr[4].Y = this.top;
                return _PArr;
            }

            public System.Drawing.Rectangle ToRectangle()
            {
                return new System.Drawing.Rectangle(this.left, this.top, this.Width, this.Height);
            }

            #endregion

            #region "static function"
            public static RECT Union(ref RECT a, ref RECT b)
            {
                Rectangle ra = Rectangle.Union((Rectangle)a, (Rectangle)b);
                return new RECT(ra);
            }
            public static RECT UnionWithoutZeroSized(ref RECT a, ref RECT b)
            {
                if (a.IsZeroSized)
                    return b;

                if (b.IsZeroSized)
                    return a;

                Rectangle ra = Rectangle.Union((Rectangle)a, (Rectangle)b);
                return new RECT(ra);
            }
            public static RECT Intersect(ref RECT a, ref RECT b)
            {
                Rectangle ra = Rectangle.Intersect((Rectangle)a, (Rectangle)b);
                return new RECT(ra);
            }
            public static RECT IntersectWithoutInvalid(RECT a, RECT b)
            {
                if (a.IsZeroSized)
                {
                    return b;
                }
                if (b.IsZeroSized)
                {
                    return a;
                }
                return Intersect(ref a, ref b);
            }
            public static RECT Inflate(RECT r, int x, int y)
            {
                RECT rectangle1 = r;
                rectangle1.Inflate(x, y);
                return rectangle1;
            }
            public static RECT CoordsBoundaries(System.Drawing.Point[] coords)
            {
                RECT retVal = default(RECT);
                if ((coords != null) && (coords.Length > 0))
                {
                    try
                    {
                        retVal.left = coords[0].X;
                        retVal.right = coords[0].X;
                        retVal.top = coords[0].Y;
                        retVal.bottom = coords[0].Y;
                        for (int cCounter = 0; cCounter <= coords.Length - 1; cCounter++)
                        {
                            if (coords[cCounter].X > retVal.right)
                            {
                                retVal.right = coords[cCounter].X;
                            }
                            if (coords[cCounter].X < retVal.left)
                            {
                                retVal.left = coords[cCounter].X;
                            }
                            if (coords[cCounter].Y < retVal.top)
                            {
                                retVal.top = coords[cCounter].Y;
                            }
                            if (coords[cCounter].Y > retVal.bottom)
                            {
                                retVal.bottom = coords[cCounter].Y;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.GetLogger<RECT>().Error(ex.Message);
                        LogHelper.GetLogger<RECT>().Error(ex.StackTrace);
                    }
                }
                return retVal;
            }
            #endregion

        }

        public struct SEGMENT
        {

            #region "Members"
            public int X0;
            public int Y0;
            public int X1;
            public int Y1;
            public System.Drawing.Point P0
            {
                get { return new System.Drawing.Point(X0, Y0); }
                set
                {
                    X0 = value.X;
                    Y0 = value.Y;
                }
            }
            public System.Drawing.Point P1
            {
                get { return new System.Drawing.Point(X1, Y1); }
                set
                {
                    X1 = value.X;
                    Y1 = value.Y;
                }
            }
            #endregion

            #region "Constructors"
            public SEGMENT(SEGMENT aSEGMENT)
            {
                X0 = Y0 = X1 = Y1 = 0;
                try
                {
                    this.X0 = aSEGMENT.X0;
                    this.Y0 = aSEGMENT.Y0;
                    this.X1 = aSEGMENT.X1;
                    this.Y1 = aSEGMENT.Y1;
                }
                catch (Exception ex)
                {
                    LogHelper.GetLogger<SEGMENT>().Error(ex.Message);
                    LogHelper.GetLogger<SEGMENT>().Error(ex.StackTrace);
                }
            }
            public SEGMENT(int X0, int Y0, int X1, int Y1)
            {
                this.X0 = this.Y0 = this.X1 = this.Y1 = 0;
                try
                {
                    this.X0 = X0;
                    this.Y0 = Y0;
                    this.X1 = X1;
                    this.Y1 = Y1;
                }
                catch (Exception ex)
                {
                    LogHelper.GetLogger<SEGMENT>().Error(ex.Message);
                    LogHelper.GetLogger<SEGMENT>().Error(ex.StackTrace);
                }
            }
            public SEGMENT(Point P0, Point P1)
            {
                X0 = Y0 = X1 = Y1 = 0;
                try
                {
                    this.X0 = P0.X;
                    this.Y0 = P0.Y;
                    this.X1 = P1.X;
                    this.Y1 = P1.Y;
                }
                catch (Exception ex)
                {
                    LogHelper.GetLogger<SEGMENT>().Error(ex.Message);
                    LogHelper.GetLogger<SEGMENT>().Error(ex.StackTrace);
                }
            }
            #endregion

            #region "Member functions"
            public bool ContainsX(int XQuote)
            {
                //(Valido se P1 a sinistra di P0)
                if ((XQuote >= P0.X) && (XQuote <= P1.X))
                {
                    return true;
                }
                else
                {
                    //(Valido se P0 a sinistra di P1)
                    if ((XQuote >= P1.X) && (XQuote <= P0.X))
                    {
                        return true;
                    }
                }
                return false;
            }
            public System.Drawing.Point MediumPoint()
            {
                try
                {
                    System.Drawing.Point retVal = default(System.Drawing.Point);
                    retVal.X = (this.X0 + this.X1) / 2;
                    retVal.Y = (this.Y0 + this.Y1) / 2;
                    return retVal;
                }
                catch (Exception ex)
                {
                    LogHelper.GetLogger<SEGMENT>().Error(ex.Message);
                    LogHelper.GetLogger<SEGMENT>().Error(ex.StackTrace);
                    return Point.Empty;
                }
            }
            public static double SegmentModule(System.Drawing.Point P0, System.Drawing.Point P1)
            {
                try
                {
                    return System.Math.Sqrt(System.Math.Pow(P1.X - P0.X, 2) + System.Math.Pow(P1.Y - P0.Y, 2));
                }
                catch (Exception ex)
                {
                    LogHelper.GetLogger<SEGMENT>().Error(ex.Message);
                    LogHelper.GetLogger<SEGMENT>().Error(ex.StackTrace);
                    return 0;
                }
            }
            public double SegmentModule()
            {
                try
                {
                    return System.Math.Sqrt(System.Math.Pow(X1 - X0, 2) + System.Math.Pow(Y1 - Y0, 2));
                }
                catch (Exception ex)
                {
                    LogHelper.GetLogger<SEGMENT>().Error(ex.Message);
                    LogHelper.GetLogger<SEGMENT>().Error(ex.StackTrace);
                    return 0;
                }
            }
            /// <summary>
            /// Ritorna la direzione (angolo in radianti) del segmento ...
            /// </summary>
            /// <returns></returns>
            /// <remarks></remarks>
            public double SegmentDirection()
            {
                try
                {
                    double dblHyp = 0;
                    double dblSin = 0;
                    double RefX = 0;
                    double RefY = 0;
                    //Traslo il segmento in modo che parta dall'origine ...
                    RefX = X1 - X0;
                    RefY = -(Y1 - Y0);
                    //Memo: in Windows l'asse Y � invertito ...
                    //Riporto a sistema di coordinate standard per
                    //applicare formule trigonometriche ...

                    if ((RefY == 0))
                    {
                        //Segmento orizzontale ...
                        if ((RefX > 0))
                        {
                            //Angolo nullo ...
                            return 0;
                        }
                        else
                        {
                            //Angolo piatto ...
                            return System.Math.PI;
                        }
                    }

                    if ((RefX == 0))
                    {
                        //Segmento verticale ...
                        if ((RefY > 0))
                        {
                            return System.Math.PI / 2;
                        }
                        else
                        {
                            return -System.Math.PI / 2;
                        }
                    }

                    //Se sono arrivato fino a qui, l'angolo non � un multiplo di Pi/2 ...
                    if ((RefX > 0))
                    {
                        if ((RefY > 0))
                        {
                            //Primo quadrante ....
                            dblHyp = System.Math.Sqrt((RefX * RefX + RefY * RefY));
                            //Ipotenusa ...
                            dblSin = RefY / dblHyp;
                            return System.Math.Atan(dblSin / System.Math.Sqrt(-dblSin * dblSin + 1));
                        }
                        else
                        {
                            //Quarto quadrante ...
                            RefY = -RefY;
                            dblHyp = System.Math.Sqrt((RefX * RefX + RefY * RefY));
                            //Ipotenusa ...
                            dblSin = RefY / dblHyp;
                            return (2 * System.Math.PI) - System.Math.Atan(dblSin / System.Math.Sqrt(-dblSin * dblSin + 1));
                        }
                    }
                    else
                    {
                        if ((RefY > 0))
                        {
                            //Secondo quadrante ...
                            RefX = -RefX;
                            dblHyp = System.Math.Sqrt((RefX * RefX + RefY * RefY));
                            //Ipotenusa ...
                            dblSin = Convert.ToDouble(RefY) / dblHyp;
                            return -System.Math.Atan(dblSin / System.Math.Sqrt(-dblSin * dblSin + 1)) + System.Math.PI;
                        }
                        else
                        {
                            //Terzo quadrante ...
                            RefX = -RefX;
                            RefY = -RefY;
                            dblHyp = System.Math.Sqrt((RefX * RefX + RefY * RefY));
                            //Ipotenusa ...
                            dblSin = RefY / dblHyp;
                            return System.Math.Atan(dblSin / System.Math.Sqrt(-dblSin * dblSin + 1)) + System.Math.PI;
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.GetLogger<SEGMENT>().Error(ex.Message);
                    LogHelper.GetLogger<SEGMENT>().Error(ex.StackTrace);
                    return 0;
                }
            }
            #endregion

            #region "Operators"

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;

                if (GetType() != obj.GetType())
                    return false;
                SEGMENT g = (SEGMENT)obj;
                if (this.GetHashCode() == g.GetHashCode())
                    return true;
                else
                    return false;
            }

            public static bool operator ==(SEGMENT S1, SEGMENT S2)
            {
                if ((S1.X0 == S2.X0) && (S1.X1 == S2.X1) && (S1.Y0 == S2.Y0) && (S1.Y1 == S2.Y1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public static bool operator !=(SEGMENT S1, SEGMENT S2)
            {
                if ((S1.X0 != S2.X0) | (S1.X1 != S2.X1) | (S1.Y0 != S2.Y0) | (S1.Y1 != S2.Y1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            #endregion
        }
    }
}
