﻿using Cii.Lar.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cii.Lar.DrawTools
{
    /// <summary>
    /// Rectangle graphic object
    /// Author:Zhong Wen 2017/07/26
    /// </summary>
    public class DrawRectangle : DrawObject
    {
        protected float dataLeft;
        protected float dataRight;
        protected float dataTop;
        protected float dataBottom;

        private Rectangle rectangle;
        public DrawRectangle()
        {
            this.Color = Color.Red;
        }

        public DrawRectangle(CursorPictureBox pictureBox, int x, int y, int width, int height) : this()
        {
            rectangle = new Rectangle(x, y, width, height);
            SetRectangle(rectangle);
        }

        /// <summary>
        /// draw graphic object
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pictureBox"></param>
        public override void Draw(Graphics g, CursorPictureBox pictureBox)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle r = GetNormalizedRectangle(GetRectangle());
            using (Pen pen = new Pen(this.Color, PenWidth))
            {
                if (IsMoving)
                {
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                    pen.DashPattern = new float[] { 4.0F, 2.8F };
                }

                rectangle.Offset(MovingOffset);
                g.DrawRectangle(pen, r);
            }
        }

        public static Rectangle GetNormalizedRectangle(Rectangle r)
        {
            return GetNormalizedRectangle(r.X, r.Y, r.X + r.Width, r.Y + r.Height);
        }

        /// <summary>
        /// Get normalized rectangle when move left or top
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public static Rectangle GetNormalizedRectangle(int x1, int y1, int x2, int y2)
        {
            if (x2 < x1)
            {
                int tmp = x2;
                x2 = x1;
                x1 = tmp;
            }

            if (y2 < y1)
            {
                int tmp = y2;
                y2 = y1;
                y1 = tmp;
            }

            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        /// <summary>
        /// Get handle point by 1-based number
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public override Point GetHandle(CursorPictureBox pictureBox, int handleNumber)
        {
            int x, y, xCenter, yCenter;
            Rectangle rectangle = GetRectangle();

            xCenter = rectangle.X + rectangle.Width / 2;
            yCenter = rectangle.Y + rectangle.Height / 2;
            x = rectangle.X;
            y = rectangle.Y;

            switch (handleNumber)
            {
                case 1:
                    x = rectangle.X;
                    y = rectangle.Y;
                    break;
                case 2:
                    x = xCenter;
                    y = rectangle.Y;
                    break;
                case 3:
                    x = rectangle.Right;
                    y = rectangle.Y;
                    break;
                case 4:
                    x = rectangle.Right;
                    y = yCenter;
                    break;
                case 5:
                    x = rectangle.Right;
                    y = rectangle.Bottom;
                    break;
                case 6:
                    x = xCenter;
                    y = rectangle.Bottom;
                    break;
                case 7:
                    x = rectangle.X;
                    y = rectangle.Bottom;
                    break;
                case 8:
                    x = rectangle.X;
                    y = yCenter;
                    break;
            }

            return new Point(x, y);

        }

        /// <summary>
        /// Mouse move to new point
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="point"></param>
        /// <param name="handleNumber"></param>
        public override void MoveHandleTo(CursorPictureBox pictureBox, Point point, int handleNumber)
        {
            int left = rectangle.Left;
            int top = rectangle.Top;
            int right = rectangle.Right;
            int bottom = rectangle.Bottom;
            switch (handleNumber)
            {
                case 1:
                    left = point.X;
                    top = point.Y;
                    break;
                case 2:
                    top = point.Y;
                    break;
                case 3:
                    right = point.X;
                    top = point.Y;
                    break;
                case 4:
                    right = point.X;
                    break;
                case 5:
                    right = point.X;
                    bottom = point.Y;
                    break;
                case 6:
                    bottom = point.Y;
                    break;
                case 7:
                    left = point.X;
                    bottom = point.Y;
                    break;
                case 8:
                    left = point.X;
                    break;
            }
            rectangle = new Rectangle(left, top, right - left, bottom - top);
            SetRectangle(rectangle);
        }

        private void SetRectangle(Rectangle r)
        {
            PointF dataLeftTop =  new PointF(r.Left, r.Top);
            PointF dataRightBottom = new PointF(r.Right, r.Bottom);
            dataLeft = dataLeftTop.X;
            dataTop = dataLeftTop.Y;
            dataRight = dataRightBottom.X;
            dataBottom = dataRightBottom.Y;
        }

        protected Rectangle GetRectangle()
        {
            return ToDrawRectangle(dataLeft, dataRight, dataTop, dataBottom);
        }

        private Rectangle ToDrawRectangle(float left, float right, float top, float bottom)
        {
            Point leftTop = Point.Ceiling(new PointF(left, top));
            Point rightBottom = Point.Ceiling(new PointF(right, bottom));

            return new Rectangle(leftTop.X, leftTop.Y, rightBottom.X - leftTop.X, rightBottom.Y - leftTop.Y);
        }

        /// <summary>
        /// Get number of handles
        /// </summary>
        public override int HandleCount
        {
            get
            {
                return 8;
            }
        }
    }
}
