using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
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
                if (activeTool == DrawToolType.PolyLine && activeTool != value)
                {
                    if (GraphicsList.Count > 0 && GraphicsList[0] is DrawPolyLine)
                    {
                        DrawPolyLine polygon = (DrawPolyLine)GraphicsList[0];
                        if (polygon != null && polygon.Creating)
                        {
                            tools[(int)DrawToolType.PolyLine].OnCancel(this, true);
                        }
                    }
                }
                activeTool = value;
                if (tools != null && activeTool != DrawToolType.None)
                {
                    Cursor = tools[(int)activeTool] is ToolPointer ? Cursors.Default : (tools[(int)activeTool] as ToolObject).Cursor;
                }
                Enabled = activeTool != DrawToolType.None;
            }
        }

        public void GraphicsPropertiesChangedHandler(DrawObject drawObject, GraphicsProperties graphicsProperties)
        {
            this.Invalidate();
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

        public Rectangle RectNetSelection
        {
            get;
            set;
        }

        public event OnMeasureUnitChangedEventHandler OnMeasureUnitChanged;
        public delegate void OnMeasureUnitChangedEventHandler(enUniMis unit);
        public const enUniMis DefaultUnitOfMeasure = enUniMis.mm;
        private enUniMis myUnitOfMeasure = DefaultUnitOfMeasure;

        public enUniMis UnitOfMeasure
        {
            get
            {
                return myUnitOfMeasure;
            }
            set
            {
                if (value != myUnitOfMeasure)
                {
                    myUnitOfMeasure = value;
                    OnMeasureUnitChanged?.Invoke(value);
                }
            }
        }
        public CursorPictureBox()
        {
            InitializeComponent();
            this.MouseDown += this.CursorPictureBox_MouseDown;
            this.MouseMove += this.CursorPictureBox_MouseMove;
            this.MouseUp += this.CursorPictureBox_MouseUp;
            this.MouseDoubleClick += CursorPictureBox_MouseDoubleClick;
        }

        private void CursorPictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tools[(int)activeTool].OnDoubleClick(this, e);
        }

        private void CursorPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                tools[(int)activeTool].OnMouseUp(this, e);
            }
        }

        private void CursorPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.None)
            {
                tools[(int)activeTool].OnMouseMove(this, e);
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void CursorPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                tools[(int)activeTool].OnMouseDown(this, e);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (GraphicsList != null)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                GraphicsList.Draw(e.Graphics, this);
            }
            DrawNetSelection(e.Graphics);
        }

        private void DrawNetSelection(Graphics graphics)
        {
            if (RectNetSelection.IsEmpty)
            {
                return;
            }
            SmoothingMode mode = graphics.SmoothingMode;
            graphics.SmoothingMode = SmoothingMode.Default;

            Pen pen = new Pen(Color.DimGray, 1);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            RectNetSelection = DrawRectangle.GetNormalizedRectangle(RectNetSelection);
            graphics.DrawRectangle(pen, RectNetSelection);

            pen.Dispose();
            graphics.SmoothingMode = mode;
        }
    }
}
