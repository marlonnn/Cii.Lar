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
    /// Base class for all tools which create new graphic object
    /// </summary>
    abstract class ToolObject :Tool
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
        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {

        }

        public override void OnMouseLeave(DrawArea drawArea, EventArgs e)
        {
            OnMouseUp(drawArea, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
        }


    }
}
