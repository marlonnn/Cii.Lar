using Cii.Lar.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cii.Lar.DrawTools
{
    /// <summary>
    /// draw polygon tool
    /// Author:Zhong Wen 2017/07/27
    /// </summary>
    public class ToolPolygon : ToolObject
    {
        private int lastX;
        private int lastY;
        private DrawPolygon newPolygon;
        private const int minDistance = 15 * 15;

        private static Cursor s_cursor = new Cursor(
            new MemoryStream((byte[])new ResourceManager(typeof(CursorPictureBox)).GetObject("Pencil")));
        public ToolPolygon()
        {
            Cursor = s_cursor;
        }

        public override void OnMouseDown(CursorPictureBox pictureBox, MouseEventArgs e)
        {
            newPolygon = new DrawPolygon(pictureBox, e.X, e.Y, e.X + 1, e.Y + 1);
            AddNewObject(pictureBox, newPolygon);

            lastX = e.X;
            lastY = e.Y;
        }

        public override void OnMouseMove(CursorPictureBox pictureBox, MouseEventArgs e)
        {
            pictureBox.Cursor = Cursor;

            if (newPolygon == null)
            {
                return;
            }
            if (e.Button == MouseButtons.Left)
            {
                Point point = new Point(e.X, e.Y);
                int distance = (e.X - lastX) * (e.X - lastX) + (e.Y - lastY) * (e.Y - lastY);

                if (distance < minDistance)
                {
                    // Distance between last two points is less than minimum -
                    // move last point
                    newPolygon.MoveHandleTo(pictureBox, point, newPolygon.PointCount);
                }
                else
                {
                    // Add new point
                    newPolygon.AddPoint(pictureBox, point, false);
                    lastX = e.X;
                    lastY = e.Y;
                }
                pictureBox.Refresh();
            }
        }

        public override void OnMouseUp(CursorPictureBox pictureBox, MouseEventArgs e)
        {
            newPolygon.Creating = false;
            newPolygon = null;

            base.OnMouseUp(pictureBox, e);
        }
    }
}
