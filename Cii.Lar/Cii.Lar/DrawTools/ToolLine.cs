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
    /// Draw line shape tool
    /// Author:Zhong Wen 2017/07/27
    /// </summary>
    public class ToolLine : ToolObject
    {
        private static Cursor s_cursor = new Cursor(new MemoryStream((byte[])new ResourceManager(typeof(
            CursorPictureBox)).GetObject("Line")));

        public ToolLine()
        {
            Cursor = s_cursor;
        }

        public override void OnMouseDown(CursorPictureBox pictureBox, MouseEventArgs e)
        {
            AddNewObject(pictureBox, new DrawLine(pictureBox, e.X, e.Y, e.X + 1, e.Y + 1));
        }

        public override void OnMouseMove(CursorPictureBox pictureBox, MouseEventArgs e)
        {
            pictureBox.Cursor = Cursor;

            if (pictureBox.CreatingDrawObject)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Point point = new Point(e.X, e.Y);
                    pictureBox.GraphicsList[0].MoveHandleTo(pictureBox, point, 2);
                    pictureBox.Refresh();
                }
            }
        }
    }
}
