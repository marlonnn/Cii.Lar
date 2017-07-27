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
    public class ToolEllipse : ToolObject
    {
        private static Cursor s_cursor = new Cursor(new MemoryStream((byte[])new ResourceManager(typeof(CursorPictureBox)).GetObject("Ellipse")));

        public ToolEllipse()
        {
            Cursor = s_cursor;
        }

        public override void OnMouseDown(CursorPictureBox pictureBox, MouseEventArgs e)
        {
            AddNewObject(pictureBox, new DrawEllipse(pictureBox, e.X, e.Y, e.X, e.Y, 0.6));
        }

        public override void OnMouseMove(CursorPictureBox pictureBox, MouseEventArgs e)
        {
            pictureBox.Cursor = Cursor;

            if (e.Button == MouseButtons.Left)
            {
                Point point = new Point(e.X, e.Y);
                pictureBox.GraphicsList[0].MoveHandleTo(pictureBox, point, 5);
                pictureBox.Refresh();
            }
        }
    }
}
