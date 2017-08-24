using Cii.Lar.UI;
using Cii.Lar.UI.Picture;
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
    /// Author:Zhong Wen 2017/07/25
    /// </summary>
    public class Tool
    {
        /// <summary>
        /// Left nous button is pressed
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="e"></param>
        public virtual void OnMouseDown(ZoomblePictureBoxControl pictureBox, MouseEventArgs e)
        {
        }


        /// <summary>
        /// Mouse is moved, left mouse button is pressed or none button is pressed
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="e"></param>
        public virtual void OnMouseMove(ZoomblePictureBoxControl pictureBox, MouseEventArgs e)
        {
        }
        public virtual void OnMouseMoveZoom(ZoomblePictureBoxControl pictureBox, MouseEventArgs e)
        {
        }

        /// <summary>
        /// Left mouse button is released
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="e"></param>
        public virtual void OnMouseUp(ZoomblePictureBoxControl pictureBox, MouseEventArgs e)
        {
        }
        public virtual void OnMouseUpZoom(ZoomblePictureBoxControl pictureBox, MouseEventArgs e)
        {
        }

        /// <summary>
        /// Mouse leave draw area
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="e"></param>
        public virtual void OnMouseLeave(ZoomblePictureBoxControl pictureBox, EventArgs e)
        {

        }

        /// <summary>
        /// Mouse button is double clicked
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="e"></param>
        public virtual void OnDoubleClick(ZoomblePictureBoxControl pictureBox, MouseEventArgs e)
        {
        }

        /// <summary>
        /// call when press "Escape" key
        /// </summary>
        public virtual void OnCancel(ZoomblePictureBoxControl pictureBox, bool cancelSelection)
        {
        }

        public virtual void OnKeyMove(ZoomblePictureBoxControl pictureBox, Keys keyData, bool isPressCtrl)
        {

        }

        public virtual void OnKeyUp(ZoomblePictureBoxControl pictureBox, Keys keyData, bool isPressCtrl)
        {

        }
    }
}
