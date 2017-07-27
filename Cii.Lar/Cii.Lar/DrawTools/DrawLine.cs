using Cii.Lar.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar.DrawTools
{
    /// <summary>
    /// Line graphic object
    /// Author:Zhong Wen 2017/07/26
    /// </summary>
    public class DrawLine : DrawObject
    {
        protected PointF startDataPoint;
        protected PointF endDataPoint;

        public DrawLine()
        {
            this.Color = Color.Blue;
        }

        public DrawLine(CursorPictureBox pictureBox, int x1, int y1, int x2, int y2) : this()
        {
            startDataPoint = new Point(x1, y1);
            endDataPoint = new Point(x2, y2);
        }

        /// <summary>
        /// draw line graphic
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pictureBox"></param>
        public override void Draw(Graphics g, CursorPictureBox pictureBox)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(this.Color, PenWidth))
            {
                g.DrawLine(pen, startDataPoint.X, startDataPoint.Y, endDataPoint.X, endDataPoint.Y);
            }
        }

        public override int HandleCount
        {
            get
            {
                return 2;
            }
        }

        /// <summary>
        /// Get handle point by 1-based number
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public override Point GetHandle(CursorPictureBox pictureBox, int handleNumber)
        {
            if (handleNumber == 1)
            {
                return Point.Ceiling(startDataPoint);
            }
            else
            {
                return Point.Ceiling(endDataPoint);
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
            if (handleNumber == 1)
            {
                startDataPoint = point;
            }
            else
            {
                endDataPoint = point;
            }
        }
    }
}
