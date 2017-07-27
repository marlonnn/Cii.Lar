using Cii.Lar.UI;
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
        private Rectangle rectangle;
        public DrawRectangle()
        {
            this.Color = Color.Red;
        }

        public DrawRectangle(CursorPictureBox pictureBox, int x, int y, int width, int height) : this()
        {
            rectangle = new Rectangle(x, y, width, height);
        }

        /// <summary>
        /// draw graphic object
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pictureBox"></param>
        public override void Draw(Graphics g, CursorPictureBox pictureBox)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(this.Color, PenWidth))
            {
                g.DrawRectangle(pen, rectangle);
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
        }
    }
}
