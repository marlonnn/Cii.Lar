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
    public partial class CursorPictureBox : PictureBox
    {
        private Tool[] tools;                 // array of tools

        public Tool[] Tools
        {
            get
            {
                return tools;
            }
            set
            {
                this.tools = value;
            }
        }
        private DrawToolType activeTool;      // active drawing tool

        public DrawToolType ActiveTool
        {
            get
            {
                return activeTool;
            }
            set
            {
                activeTool = value;
                if (tools != null && activeTool != DrawToolType.None)
                {
                    Cursor = tools[(int)activeTool] is ToolPointer ? Cursors.Default : (tools[(int)activeTool] as ToolObject).Cursor;
                }
                Enabled = activeTool != DrawToolType.None;
            }
        }

        private GraphicsList drawObjects;

        public GraphicsList GraphicsList
        {
            get
            {
                return drawObjects;
            }

            set
            {
                drawObjects = value;
            }
        }
        public bool CreatingDrawObject
        {
            get
            {
                return ActiveTool != DrawToolType.None && ActiveTool != DrawToolType.Pointer &&
                      GraphicsList.Count > 0 && GraphicsList[0].Creating;
            }
        }

        public CursorPictureBox()
        {
            InitializeComponent();
        }
    }
}
