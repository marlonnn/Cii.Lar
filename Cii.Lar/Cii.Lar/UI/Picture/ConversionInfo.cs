using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cii.Lar.UI.Picture.PublicTypes;

namespace Cii.Lar.UI.Picture
{
    /// <summary>
    /// Conversion information class
    /// Author: Zhong Wen 2017/08/22
    /// </summary>
    public class ConversionInfo
    {
        public int PhysicalWidth = 640;
        public int PhysicalHeight = 480;
        private float myScaleFactor = 1f;

        public Point LogicalOrigin = RECT.InvalidPoint();

        public float ScaleFactor
        {
            get
            {
                if (float.IsNaN(myScaleFactor) || float.IsInfinity(myScaleFactor))
                {
                    myScaleFactor = 1;
                }
                return myScaleFactor;
            }
            set
            {
                myScaleFactor = Math.Abs(value);
            }
        }

        public int LogicalWidth
        {
            get
            {
                if (ScaleFactor == 0)
                {
                    ScaleFactor = 1;
                    return PhysicalWidth;
                }
                else
                {
                    return (int)((float)PhysicalWidth / ScaleFactor);
                }
            }
            set
            {
                if (value != 0)
                {
                    float v = (float)PhysicalWidth / value;
                    ScaleFactor = (float)PhysicalWidth / value;
                }
            }
        }

        public int LogicalHeight
        {
            get
            {
                if (ScaleFactor == 0)
                {
                    ScaleFactor = 1;
                    return PhysicalHeight;
                }
                else
                {
                    return (int)((float)PhysicalHeight / ScaleFactor);
                }
            }
            set
            {
                if (value != 0)
                {
                    ScaleFactor = (float)PhysicalHeight / value;
                }
            }
        }

        public RECT LogicalArea
        {
            get
            {
                RECT functionReturnValue = default(RECT);
                bool isNotValidArea = (LogicalOrigin == RECT.InvalidPoint()) || (LogicalWidth == int.MaxValue) || (LogicalHeight == int.MaxValue);
                isNotValidArea = isNotValidArea || (LogicalWidth == 0) || (LogicalHeight == 0);
                if (isNotValidArea)
                {
                    return new RECT();
                }
                functionReturnValue.left = LogicalOrigin.X;
                functionReturnValue.top = LogicalOrigin.Y;
                functionReturnValue.bottom = LogicalOrigin.Y + LogicalHeight;
                functionReturnValue.right = LogicalOrigin.X + LogicalWidth;
                functionReturnValue.NormalizeRect();
                return functionReturnValue;
            }
            set
            {
                if (LogicalArea == value)
                {
                    return;
                }
                LogicalOrigin = new Point(value.left, value.top);
                LogicalWidth = value.Width;
                LogicalHeight = value.Height;
            }
        }

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
            ConversionInfo c = (ConversionInfo)obj;
            if (this.GetHashCode() == c.GetHashCode())
                return true;
            else
                return false;
        }

        public static bool operator ==(ConversionInfo C1, ConversionInfo C2)
        {
            try
            {
                return (C1.PhysicalWidth == C2.PhysicalWidth) && (C1.PhysicalHeight == C2.PhysicalHeight) && (C1.ScaleFactor == C2.ScaleFactor) && (C1.LogicalOrigin == C2.LogicalOrigin);
            }
            catch
            {
                return false;
            }
        }
        public static bool operator !=(ConversionInfo C1, ConversionInfo C2)
        {
            return !(C1 == C2);
        }

        public float ToLogicalCoordX(float PhysicalCoordX)
        {
            try
            {
                return PhysicalCoordX / ScaleFactor + LogicalOrigin.X;
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ConversionInfo>().Error(ex.Message);
                LogHelper.GetLogger<ConversionInfo>().Error(ex.StackTrace);
                return float.NaN;
            }
        }

        public float ToLogicalCoordY(float PhysicalCoordY)
        {
            try
            {
                return PhysicalCoordY / ScaleFactor + LogicalOrigin.Y;
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ConversionInfo>().Error(ex.Message);
                LogHelper.GetLogger<ConversionInfo>().Error(ex.StackTrace);
                return float.NaN;
            }
        }

        public float ToLogicalDimension(float dimension)
        {
            try
            {
                return dimension / ScaleFactor;
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ConversionInfo>().Error(ex.Message);
                LogHelper.GetLogger<ConversionInfo>().Error(ex.StackTrace);
                return float.NaN;
            }
        }

        public System.Drawing.Point ToLogicalPoint(System.Drawing.Point PhysicalPoint)
        {
            try
            {
                return new System.Drawing.Point((int)(PhysicalPoint.X / ScaleFactor + LogicalOrigin.X), (int)(PhysicalPoint.Y / ScaleFactor + LogicalOrigin.Y));
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ConversionInfo>().Error(ex.Message);
                LogHelper.GetLogger<ConversionInfo>().Error(ex.StackTrace);
                return Point.Empty;
            }
        }

        public Point ToLogicalPoint(int X, int Y)
        {
            try
            {
                return new Point((int)(X / ScaleFactor + LogicalOrigin.X), (int)(Y / ScaleFactor + LogicalOrigin.Y));
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ConversionInfo>().Error(ex.Message);
                LogHelper.GetLogger<ConversionInfo>().Error(ex.StackTrace);
                return Point.Empty;
            }
        }

        public float ToPhysicalCoordX(float LogicalCoordX)
        {
            try
            {
                return (LogicalCoordX - LogicalOrigin.X) * ScaleFactor;
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ConversionInfo>().Error(ex.Message);
                LogHelper.GetLogger<ConversionInfo>().Error(ex.StackTrace);
                return float.NaN;
            }
        }

        public float ToPhysicalCoordY(float LogicalCoordY)
        {
            try
            {
                return (LogicalCoordY - LogicalOrigin.Y) * ScaleFactor;
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ConversionInfo>().Error(ex.Message);
                LogHelper.GetLogger<ConversionInfo>().Error(ex.StackTrace);
                return float.NaN;
            }
        }

        public float ToPhysicalDimension(float dimension)
        {
            try
            {
                return dimension * ScaleFactor;
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ConversionInfo>().Error(ex.Message);
                LogHelper.GetLogger<ConversionInfo>().Error(ex.StackTrace);
                return float.NaN;
            }
        }

        public System.Drawing.Point ToPhysicalPoint(System.Drawing.Point LogicalPoint)
        {
            try
            {
                return new System.Drawing.Point((int)((LogicalPoint.X - LogicalOrigin.X) * ScaleFactor), (int)((LogicalPoint.Y - LogicalOrigin.Y) * ScaleFactor));
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ConversionInfo>().Error(ex.Message);
                LogHelper.GetLogger<ConversionInfo>().Error(ex.StackTrace);
                return Point.Empty;
            }
        }

        public RECT ToPhysicalRect(RECT LogicalRect)
        {
            try
            {
                return new RECT((int)ToPhysicalCoordX(LogicalRect.left), (int)ToPhysicalCoordY(LogicalRect.top),
                    (int)ToPhysicalCoordX(LogicalRect.right), (int)ToPhysicalCoordY(LogicalRect.bottom));
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ConversionInfo>().Error(ex.Message);
                LogHelper.GetLogger<ConversionInfo>().Error(ex.StackTrace);
                return new RECT();
            }
        }
        public static float DotToMicron(int BitmapDPI)
        {
            try
            {
                return (float)(1 / ((BitmapDPI / 25.4) / 1000));
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ConversionInfo>().Error(ex.Message);
                LogHelper.GetLogger<ConversionInfo>().Error(ex.StackTrace);
                return -1f;
            }
        }

        public object Clone()
        {
            ConversionInfo retVal = new ConversionInfo();
            retVal.CopyParamsFrom(this);
            return retVal;
        }
        public virtual void CopyParamsFrom(ConversionInfo info)
        {
            this.PhysicalWidth = info.PhysicalWidth;
            this.PhysicalHeight = info.PhysicalHeight;
            this.ScaleFactor = info.ScaleFactor;
            this.LogicalOrigin = info.LogicalOrigin;
        }
    }
}
