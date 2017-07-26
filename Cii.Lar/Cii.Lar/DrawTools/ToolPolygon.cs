using Cii.Lar.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cii.Lar.DrawTools
{
    public class ToolPolygon : ToolObject
    {
        private static Cursor _cursor = new Cursor(new MemoryStream((byte[])new ResourceManager(typeof(CursorPictureBox)).GetObject("Pencil")));
        public ToolPolygon()
        {
            Cursor = _cursor;
        }


    }
}
