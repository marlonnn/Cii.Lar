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
using System.Threading;

namespace Cii.Lar.UI
{
    public enum PanDirection
    {
        None,
        Left,
        Right,
        Up,
        Down
    }

    public enum DrawToolType
    {
        None,
        Pointer,
        Line,
        Rectangle,
        Ellipse,
        Polygon,
        PolyLine,
        Circle,
        Move,
        NumberOfDrawTools
    }

    /// <summary>
    ///  My Custom picture box
    ///  Author: Zhong Wen 2017/08/31
    /// </summary>
    public partial class ZWPictureBox : PictureBox
    {
        private DrawObject drawObject;
        //Set this to Tag of delete Button
        private ListViewItemArray listViewItemArray;

        /// <summary>
        /// the new area where the picture tracker control to be dragged
        /// </summary>
        private Rectangle draggingRectangle;

        /// <summary>
        /// indicating mouse dragging mode of Statistics control
        /// </summary>
        private bool isDraggingBaseCtrl = false;

        /// <summary>
        /// last Statistics mouse position of mouse dragging
        /// </summary>
        private Point lastBaseCtrlMousePos;

        /// <summary>
        /// the new area where the Statistics control to be dragged
        /// </summary>
        private Rectangle draggingBaseCtrlRectangle;

        #region BaseCtrl
        private BaseCtrl baseCtrl;
        public BaseCtrl BaseCtrl
        {
            get
            {
                return this.baseCtrl;
            }
        }

        private List<BaseCtrl> controls;

        public StatisticsCtrl StatisticsControl
        {
            get
            {
                return this.controls[2] as StatisticsCtrl;
            }
        }
        #endregion

        #region Draw tools
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
        #endregion

        #region Measure tool
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
        #endregion

        #region Zoom and Pan
        private Point mouseDownPoint;
        private bool mousePressed;
        private int startX;
        private int startY;

        //current offset of image
        private int offsetX;
        public int OffsetX
        {
            get
            {
                return offsetX;
            }
            set
            {
                offsetX = value;
            }
        }

        private int offsetY;
        public int OffsetY
        {
            get
            {
                return offsetY;
            }
            set
            {
                offsetY = value;
            }
        }

        private float zoom = 1; 
        public float Zoom
        {
            get
            {
                return zoom;
            }
            set
            {
                zoom = value;
            }
        }
        #endregion

        public ZWPictureBox()
        {
            // enable double buffering
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            listViewItemArray = new ListViewItemArray();
            GraphicsList = new GraphicsList();
            this.GraphicsList.DrawObjsChanged += GraphicsList_DrawObjsChanged;

            Initialize();
            InitializeControls();
        }

        private void GraphicsList_DrawObjsChanged(object sender, ArrayChangedEventArgs<DrawObject> e)
        {
            if (e.ChangeType == ArrayChangedType.ItemAdded)
            {
                Invalidate();
            }
            else if (e.ChangeType == ArrayChangedType.ItemRemoved)
            {
                Cursor = Cursors.Default;
                Invalidate();
            }
        }

        /// <summary>
        /// initialize all the base controls
        /// </summary>
        private void InitializeControls()
        {
            controls = new List<BaseCtrl>();
            controls.Add(new LaserCtrl());
            controls.Add(new LaserAppearanceCtrl());
            controls.Add(new StatisticsCtrl());
            RulerAppearanceCtrl rulerAppearance = new RulerAppearanceCtrl();
            //rulerAppearance.UpdateTimerStatesHandler += UpdateTimerStatesHandler;
            controls.Add(rulerAppearance);

            SettingCtrl settingCtrl = new SettingCtrl();
            //settingCtrl.UpdateTimerStatesHandler += UpdateTimerStatesHandler;
            controls.Add(settingCtrl);
        }

        /// <summary>
        /// Update statistics information in listviewEx control
        /// </summary>
        /// <param name="statistics"></param>
        public void UpdateStatisticInfoHandler(DrawObject drawObject, Statistics statistics)
        {
            AppendItems(drawObject, statistics);
        }

        /// <summary>
        /// Append new list view item to StatisticsListView items
        /// </summary>
        /// <param name="drawObject"></param>
        /// <param name="statistics"></param>
        private void AppendItems(DrawObject drawObject, Statistics statistics)
        {
            if (this.drawObject == null || drawObject.Name != this.drawObject.Name)
            {
                this.drawObject = drawObject;
                ListViewItem lvi = new ListViewItem();
                lvi.Text = drawObject.Name;
                lvi.SubItems.Add(statistics.Circumference.ToString());
                lvi.SubItems.Add(statistics.Area.ToString());
                StatisticsControl.StatisticsListView.Items.Add(lvi);
                ListViewItemEx listViewItemEx = new ListViewItemEx(lvi, drawObject);
                AddEmbeddedControlToListView(listViewItemEx);
                EnableAppearanceButton();
            }
        }

        /// <summary>
        /// Add embedded delete button control to list view
        /// </summary>
        /// <param name="listViewItemEx"></param>
        private void AddEmbeddedControlToListView(ListViewItemEx listViewItemEx)
        {
            TransparentButton deleteButton = new TransparentButton();
            deleteButton.BackColor = System.Drawing.Color.Transparent;
            deleteButton.BackgroundImage = global::Cii.Lar.Properties.Resources.delete;
            deleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            deleteButton.Name = "removeButton";
            deleteButton.Size = new System.Drawing.Size(16, 16);
            deleteButton.Tag = listViewItemEx;
            listViewItemArray.AddItem(listViewItemEx.ListViewItem);
            StatisticsControl.StatisticsListView.AddEmbeddedControl(deleteButton, 3, listViewItemArray.Count - 1);
            deleteButton.Click += DeleteButton_Click;
        }

        /// <summary>
        /// Delete button click event
        /// delete listviewitem and draw object graphic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            TransparentButton deleteButton = sender as TransparentButton;
            if (deleteButton != null)
            {
                deleteButton.Click -= DeleteButton_Click;
                ListViewItemEx listViewItemEx = (ListViewItemEx)deleteButton.Tag;
                listViewItemArray.DeleteItem(listViewItemEx.ListViewItem);
                StatisticsControl.StatisticsListView.Items.Remove(listViewItemEx.ListViewItem);
                StatisticsControl.StatisticsListView.Invalidate();
                DeleteDrawObject(listViewItemEx.DrawObject);
            }
        }

        /// <summary>
        /// delete draw objcect graphic
        /// </summary>
        /// <param name="drawObject"></param>
        private void DeleteDrawObject(DrawObject drawObject)
        {
            if (drawObject != null)
            {
                this.GraphicsList.DeleteDrawObject(drawObject);
                this.Invalidate();
                EnableAppearanceButton();
            }
        }

        /// <summary>
        /// switch to different base control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="name"></param>
        private void ClickDelegateHandler(object sender, string name)
        {
            switch (name)
            {
                case "Laser Control":
                    ShowBaseCtrl(true, controls[0]);
                    break;
                case "Laser Appearance":
                    ShowBaseCtrl(true, controls[1]);
                    break;
                case "Statistics control":
                    ShowBaseCtrl(true, controls[2]);
                    break;
                case "Ruler Appearance":
                    ShowBaseCtrl(true, controls[3]);
                    break;
            }
        }

        public int StartOffsetX = 0;

        public void LoadImage()
        {
            this.Image = Image.FromFile(string.Format("{0}\\Resources\\1.bmp", System.Environment.CurrentDirectory));
            StartOffsetX = (this.Width - this.Image.Width) / 2;
            this.OffsetX = StartOffsetX;
            InitializeBaseCtrls();

        }

        private void InitializeBaseCtrls()
        {
            foreach (var ctrl in this.controls)
            {
                ctrl.Location = new Point(5, 30);
                ctrl.ClickDelegateHandler += new BaseCtrl.ClickDelegate(this.ClickDelegateHandler);
                ctrl.MouseDown += BaseCtrl_MouseDown;
                ctrl.MouseMove += BaseCtrl_MouseMove;
                ctrl.MouseUp += BaseCtrl_MouseUp;
                ctrl.Visible = false;
                ctrl.Enabled = false;
                this.Controls.Add(ctrl);
            }
        }

        private void Initialize()
        {
            Tools = new Tool[(int)DrawToolType.NumberOfDrawTools];
            Tools[(int)DrawToolType.None] = new Tool();
            Tools[(int)DrawToolType.Pointer] = new ToolPointer();
            Tools[(int)DrawToolType.Line] = new ToolLine();
            Tools[(int)DrawToolType.Rectangle] = new ToolRectangle();
            Tools[(int)DrawToolType.Ellipse] = new ToolEllipse();
            Tools[(int)DrawToolType.Polygon] = new ToolPolygon();
            Tools[(int)DrawToolType.PolyLine] = new ToolPolyLine();
            Tools[(int)DrawToolType.Circle] = new ToolCircle();
            Tools[(int)DrawToolType.Move] = new ToolMove();
        }

        /// <summary>
        /// show laser control
        /// </summary>
        /// <param name="show"></param>
        public void ShowBaseCtrl(bool show, int index)
        {
            for (int i = 0; i < this.controls.Count; i++)
            {
                if (this.controls[i].ShowIndex == index)
                {
                    this.baseCtrl = controls[index];
                    this.Controls.SetChildIndex(this.baseCtrl, 0);
                    this.baseCtrl.Visible = show;
                    this.baseCtrl.Enabled = show;
                    EnableAppearanceButton();
                }
                else
                {
                    this.controls[i].Visible = !show;
                    this.controls[i].Enabled = !show;
                }
            }
        }

        /// <summary>
        /// enable or disable ruler appearance button
        /// </summary>
        private void EnableAppearanceButton()
        {
            var baseCtrl = this.controls[2] as StatisticsCtrl;
            if (baseCtrl != null)
            {
                if (this.GraphicsList != null && this.GraphicsList.Count > 0)
                {
                    baseCtrl.BtnAppearance.Enabled = true;
                }
                else
                {
                    baseCtrl.BtnAppearance.Enabled = false;
                }
            }
        }

        /// <summary>
        /// switch to the base control
        /// </summary>
        /// <param name="show"></param>
        /// <param name="baseCtrl"></param>
        public void ShowBaseCtrl(bool show, BaseCtrl baseCtrl)
        {
            this.baseCtrl.Visible = false;
            this.baseCtrl.Enabled = false;

            this.baseCtrl = baseCtrl;
            this.Controls.SetChildIndex(this.baseCtrl, 0);

            this.baseCtrl.Visible = show;
            this.baseCtrl.Enabled = show;
        }

        /// <summary>
        /// Draw a reversible rectangle
        /// </summary>
        /// <param name="rect">rectangle to be drawn</param>
        private void DrawReversibleRect(Rectangle rect)
        {
            // Convert the location of rectangle to screen coordinates.
            rect.Location = PointToScreen(rect.Location);

            // Draw the reversible frame.
            ControlPaint.DrawReversibleFrame(rect, Color.Navy, FrameStyle.Thick);
        }

        private void BaseCtrl_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (isDraggingBaseCtrl)
            {
                isDraggingBaseCtrl = false;

                // erase dragging rectangle
                DrawReversibleRect(draggingBaseCtrlRectangle);

                // move the Statistics control to the new position
                this.baseCtrl.Location = draggingBaseCtrlRectangle.Location;
            }
        }

        private void BaseCtrl_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (isDraggingBaseCtrl)
            {
                // caculating next candidate dragging rectangle
                Point newPos = new Point(draggingBaseCtrlRectangle.Location.X + e.X - lastBaseCtrlMousePos.X,
                                         draggingBaseCtrlRectangle.Location.Y + e.Y - lastBaseCtrlMousePos.Y);
                Rectangle newPictureTrackerArea = draggingBaseCtrlRectangle;
                newPictureTrackerArea.Location = newPos;

                // saving current mouse position to be used for next dragging
                this.lastBaseCtrlMousePos = new Point(e.X, e.Y);

                // dragging Statistics ctrl only when the candidate dragging rectangle
                // is within this ScalablePictureBox control
                if (this.ClientRectangle.Contains(newPictureTrackerArea))
                {
                    // removing previous rubber-band frame
                    DrawReversibleRect(draggingBaseCtrlRectangle);

                    // updating dragging rectangle
                    draggingBaseCtrlRectangle = newPictureTrackerArea;

                    // drawing new rubber-band frame
                    DrawReversibleRect(draggingBaseCtrlRectangle);
                }
            }
        }

        private void BaseCtrl_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            isDraggingBaseCtrl = true;    // Make a note that we are dragging Statistics control

            // Store the last mouse poit for this rubber-band rectangle.
            lastBaseCtrlMousePos.X = e.X;
            lastBaseCtrlMousePos.Y = e.Y;

            // draw initial dragging rectangle
            draggingBaseCtrlRectangle = this.baseCtrl.Bounds;
            DrawReversibleRect(draggingBaseCtrlRectangle);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            tools[(int)activeTool].OnDoubleClick(this, e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.Enabled = true;
            this.Focus();
            base.OnMouseEnter(e);
        }

        /// <summary>
        /// Handles the MouseDown event.
        /// </summary>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!mousePressed)
                {
                    if (activeTool == DrawToolType.Move)
                    {
                        mousePressed = true;
                        mouseDownPoint = e.Location;
                        startX = OffsetX;
                        startY = OffsetY;
                    }
                    else
                    {
                        tools[(int)activeTool].OnMouseDown(this, e);
                    }
                }
            }
        }
        /// <summary>
        /// Handles the MouseUp event.
        /// </summary>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            mousePressed = false;
            if (e.Button == MouseButtons.Left)
            {
                if (activeTool != DrawToolType.Move)
                {
                    tools[(int)activeTool].OnMouseUp(this, e);
                }
            }
        }
        /// <summary>
        /// Handles the MouseMove event.
        /// </summary>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left || e.Button == MouseButtons.None) && ActiveTool != DrawToolType.Move)
            {

                tools[(int)activeTool].OnMouseMove(this, e);
            }
            else if (e.Button == MouseButtons.Left && ActiveTool == DrawToolType.Move)
            {
                Point mousePosNow = e.Location;

                int deltaX = mousePosNow.X - mouseDownPoint.X;
                int deltaY = mousePosNow.Y - mouseDownPoint.Y;

                OffsetX = (int)(startX + deltaX / zoom);
                OffsetY = (int)(startY + deltaY / zoom);

                this.Invalidate();
            }
        }

        public void ZoomFit()
        {
            this.OffsetX = (this.Width - this.Image.Width) / 2;
            this.OffsetY = 0;
            this.zoom = 1;
            this.Invalidate();
        }

        /// <summary>
        /// Handles the MouseWheel event.
        /// </summary>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            float oldzoom = zoom;

            if (e.Delta > 0)
            {
                if (IsCtrlKeyPressed)
                {
                    PanAllDrirection(oldzoom, PanDirection.Left);
                }
                else if (IsShiftKeyPressed)
                {
                    PanAllDrirection(oldzoom, PanDirection.Up);
                }
                else
                {
                    zoom += 0.2F;
                    ZoomOnMouseCenter(e, oldzoom);
                }
            }
            else if (e.Delta < 0)
            {
                if (IsCtrlKeyPressed)
                {
                    PanAllDrirection(oldzoom, PanDirection.Right);
                }
                else if (IsShiftKeyPressed)
                {
                    PanAllDrirection(oldzoom, PanDirection.Down);
                }
                else
                {
                    if (zoom > 1)
                    {
                        zoom = Math.Max(zoom - 0.2F, 0.01F);
                        ZoomOnMouseCenter(e, oldzoom);
                    }
                }
            }

            this.Refresh();
        }
        /// <summary>
        /// Handles the Paint event
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if (this.Image != null)
                {
                    e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    e.Graphics.ScaleTransform(zoom, zoom);
                    e.Graphics.TranslateTransform(OffsetX, OffsetY);
                    e.Graphics.DrawImage(this.Image, 0, 0);
                }
                if (GraphicsList != null)
                {
                    GraphicsList.Draw(e.Graphics, this);
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZWPictureBox>().Error(ex.Message);
                LogHelper.GetLogger<ZWPictureBox>().Error(ex.StackTrace);
            }
        }

        private void PanAllDrirection(float zoom, PanDirection panDirection)
        {
            switch (panDirection)
            {
                case PanDirection.Left:
                    this.OffsetX += (int)(this.Width * 0.1f / zoom);
                    break;
                case PanDirection.Up:
                    this.OffsetY += (int)(this.Height * 0.1f / zoom);
                    break;
                case PanDirection.Right:
                    this.OffsetX -= (int)(this.Width * 0.1f / zoom);
                    break;
                case PanDirection.Down:
                    this.OffsetY -= (int)(this.Height * 0.1f / zoom);
                    break;
                default:
                    break;
            }
        }

        private void ZoomOnMouseCenter(MouseEventArgs e, float oldzoom)
        {
            Test();
            Point mousePosNow = e.Location;

            // Where location of the mouse in the pictureframe
            int x = mousePosNow.X - this.Location.X;
            int y = mousePosNow.Y - this.Location.Y;

            // Where in the IMAGE is it now
            int oldImageX = (int)(x / oldzoom);
            int oldImageY = (int)(y / oldzoom);

            // Where in the IMAGE will it be when the new zoom i made
            int newImageX = (int)(x / zoom);
            int newImageY = (int)(y / zoom);

            // Where to move image to keep focus on one point
            offsetX = newImageX - oldImageX + offsetX;
            offsetY = newImageY - oldImageY + offsetY;
        }

        public void Test()
        {
            if (GraphicsList != null && GraphicsList.Count > 0 )
            {
                foreach (var drawObject in GraphicsList)
                {
                    drawObject.Zooming = true;
                }
            }
        }

        #region "Check key pressed"

        /// <summary>
        /// returns true if the shift key is pressed
        /// </summary>
        public static bool IsShiftKeyPressed
        {
            get { return (Control.ModifierKeys & Keys.Shift) != 0; }
        }
        public static bool IsAltKeyPressed
        {
            get { return (Control.ModifierKeys & Keys.Alt) != 0; }
        }
        public static bool IsCtrlKeyPressed
        {
            get { return (Control.ModifierKeys & Keys.Control) != 0; }
        }
        #endregion
    }
}
