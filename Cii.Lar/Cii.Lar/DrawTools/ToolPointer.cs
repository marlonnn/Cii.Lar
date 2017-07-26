using Cii.Lar.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cii.Lar.DrawTools
{
    public class ToolPointer : Tool
    {
        private enum SelectionMode
        {
            None,
            Select,
            NetSelection,   // group selection is active
            MoveLabel,
            Move,           // object(s) are moves
            Size,           // object is resized
            Drag,           // object is dragged
        }

        private SelectionMode selectMode = SelectionMode.None;

        public ToolPointer()
        {

        }

        public override void OnMouseDown(CursorPictureBox pictureBox, MouseEventArgs e)
        {

        }

        public override void OnMouseMove(CursorPictureBox pictureBox, MouseEventArgs e)
        {

        }

        public override void OnMouseUp(CursorPictureBox pictureBox, MouseEventArgs e)
        {

        }

        public override void OnCancel(CursorPictureBox pictureBox, bool cancelSelection)
        {

        }
    }
}
