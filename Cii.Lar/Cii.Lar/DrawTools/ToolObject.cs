using Cii.Lar.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cii.Lar.DrawTools
{
    /// <summary>
    /// Base class for all tools which create new graphic object
    /// Author:Zhong Wen 2017/07/25
    /// </summary>
    public abstract class ToolObject : Tool
    {
        private Cursor cursor;

        /// <summary>
        /// Tool cursor.
        /// </summary>
        public Cursor Cursor
        {
            get
            {
                return cursor;
            }
            set
            {
                cursor = value;
            }
        }

        /// <summary>
        /// Left mouse is released.
        /// New object is created and resized.
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="e"></param>
        public override void OnMouseUp(CursorPictureBox pictureBox, MouseEventArgs e)
        {
            // if new object creation is canceled
            //if (!pictureBox.CreatingDrawObject)
            //{
            //    return;
            //}
            //pictureBox.GraphicsList[0].Creating = false;

            //Program.ExpManager.SetMeasureTool(MeasureTools.Pointer);

            //pictureBox.Capture = false;
            //pictureBox.Refresh();
        }

        /// <summary>
        /// left mouse is leave
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="e"></param>
        public override void OnMouseLeave(CursorPictureBox pictureBox, EventArgs e)
        {
            OnMouseUp(pictureBox, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
        }

        /// <summary>
        /// call when press "Escape" key
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="cancelSelection"></param>
        public override void OnCancel(CursorPictureBox pictureBox, bool cancelSelection)
        {
            // cancel adding 
            //if (drawArea.GraphicsList.Count > 0 && drawArea.GraphicsList[0].Creating)
            //{
            //    drawArea.GraphicsList.DeleteLastAddedObject();
            //}
        }

        /// <summary>
        /// add new object to picturebox
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="o"></param>
        protected void AddNewObject(CursorPictureBox pictureBox, DrawObject o)
        {
            pictureBox.GraphicsList.UnselectAll();

            o.Selected = true;
            o.Creating = true;

            pictureBox.GraphicsList.Add(o);
        }
    }
}
