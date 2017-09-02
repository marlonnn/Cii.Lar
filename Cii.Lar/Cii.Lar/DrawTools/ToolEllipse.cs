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
    /// Draw ellipse shape tool
    /// Author:Zhong Wen 2017/07/27
    /// </summary>
    public class ToolEllipse : ToolObject
    {
        private static Cursor s_cursor = new Cursor(new MemoryStream((byte[])new ResourceManager(typeof(ZWPictureBox)).GetObject("Ellipse")));

        public ToolEllipse()
        {
            Cursor = s_cursor;
        }

        public override void OnMouseDown(ZWPictureBox pictureBox, MouseEventArgs e)
        {
            Point point = new Point((int)(e.X / pictureBox.Zoom - pictureBox.OffsetX), (int)(e.Y / pictureBox.Zoom - pictureBox.OffsetY));

            AddNewObject(pictureBox, new DrawEllipse(pictureBox, point.X, point.Y, point.X, point.Y, 0.6));
        }

        public override void OnMouseMove(ZWPictureBox pictureBox, MouseEventArgs e)
        {
            pictureBox.Cursor = Cursor;

            if (e.Button == MouseButtons.Left)
            {
                Point point = new Point((int)(e.X / pictureBox.Zoom - pictureBox.OffsetX), (int)(e.Y / pictureBox.Zoom - pictureBox.OffsetY));
                pictureBox.GraphicsList[0].MoveHandleTo(pictureBox, point, 5);
                pictureBox.Refresh();
            }
        }
    }
}
