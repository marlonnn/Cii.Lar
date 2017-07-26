using Cii.Lar.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cii.Lar.DrawTools
{
    /// <summary>
    /// Base class for all drawing tools
    /// </summary>
    public class Tool
    {
        /// <summary>
        /// Left nous button is pressed
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="e"></param>
        public virtual void OnMouseDown(CursorPictureBox pictureBox, MouseEventArgs e)
        {
        }


        /// <summary>
        /// Mouse is moved, left mouse button is pressed or none button is pressed
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="e"></param>
        public virtual void OnMouseMove(CursorPictureBox pictureBox, MouseEventArgs e)
        {
        }
        public virtual void OnMouseMoveZoom(CursorPictureBox pictureBox, MouseEventArgs e)
        {
        }

        /// <summary>
        /// Left mouse button is released
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="e"></param>
        public virtual void OnMouseUp(CursorPictureBox pictureBox, MouseEventArgs e)
        {
        }
        public virtual void OnMouseUpZoom(CursorPictureBox pictureBox, MouseEventArgs e)
        {
        }

        /// <summary>
        /// Mouse leave draw area
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="e"></param>
        public virtual void OnMouseLeave(CursorPictureBox pictureBox, EventArgs e)
        {

        }

        /// <summary>
        /// Mouse button is double clicked
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="e"></param>
        public virtual void OnDoubleClick(CursorPictureBox pictureBox, MouseEventArgs e)
        {
        }

        /// <summary>
        /// call when press "Escape" key
        /// </summary>
        public virtual void OnCancel(CursorPictureBox pictureBox, bool cancelSelection)
        {
        }

        public virtual void OnKeyMove(CursorPictureBox pictureBox, Keys keyData, bool isPressCtrl)
        {

        }

        public virtual void OnKeyUp(CursorPictureBox pictureBox, Keys keyData, bool isPressCtrl)
        {

        }
    }
}
