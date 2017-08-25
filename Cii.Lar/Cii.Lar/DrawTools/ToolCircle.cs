using Cii.Lar.UI;
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
    /// Draw circle shape tool
    /// Author:Zhong Wen 2017/07/27
    /// </summary>
    public class ToolCircle : ToolObject
    {
        public ToolCircle()
        {
        }

        public override void OnMouseDown(ZoomblePictureBoxControl pictureBox, MouseEventArgs e)
        {
            AddNewObject(pictureBox, new DrawCircle(pictureBox, new PointF(e.X, e.Y)));
        }

        public override void OnMouseMove(ZoomblePictureBoxControl pictureBox, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    Point point = new Point(e.X, e.Y);
            //    pictureBox.GraphicsList[0].MoveHandleTo(pictureBox, point, 5);
            //}
        }
    }
}
