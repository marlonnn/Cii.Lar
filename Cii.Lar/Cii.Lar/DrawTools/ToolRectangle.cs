﻿using Cii.Lar.UI;
using Cii.Lar.UI.Picture;
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
    /// Draw rectangle shape tool
    /// Author:Zhong Wen 2017/07/27
    /// </summary>
    public class ToolRectangle : ToolObject
    {
        private static Cursor s_cursor = new Cursor(new MemoryStream((byte[])new ResourceManager(typeof(ZoomblePictureBoxControl)).GetObject("Rectangle")));

        public ToolRectangle()
        {
            Cursor = s_cursor;
        }

        public override void OnMouseDown(ZoomblePictureBoxControl pictureBox, MouseEventArgs e)
        {
            AddNewObject(pictureBox, new DrawRectangle(pictureBox, e.X, e.Y, 1, 1));
        }

        public override void OnMouseMove(ZoomblePictureBoxControl pictureBox, MouseEventArgs e)
        {
            pictureBox.Cursor = Cursor;

            if (pictureBox.CreatingDrawObject)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Point point = new Point(e.X, e.Y);
                    pictureBox.GraphicsList[0].MoveHandleTo(pictureBox, point, 5);
                    pictureBox.Refresh();
                }
            }
        }
    }
}
