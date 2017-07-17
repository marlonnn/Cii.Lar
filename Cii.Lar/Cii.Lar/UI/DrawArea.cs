using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cii.Lar.DrawTools;

namespace Cii.Lar.UI
{
    public partial class DrawArea : UserControl
    {
        public enum DrawToolType
        {
            None,
            Pointer,
            Line,
            Rectangle,
            Ellipse,
            Polygon
        }

        private DrawToolType activeTool;

        private Tool[] tools;

        public DrawArea()
        {
            InitializeComponent();
        }
    }
}
