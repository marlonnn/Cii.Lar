using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cii.Lar.ExpClass;
using static Cii.Lar.UI.Picture.PublicTypes;
using System.Drawing.Imaging;
using Cii.Lar.DrawTools;

namespace Cii.Lar.UI.Picture
{
    /// <summary>
    /// Zoomble picture box
    /// Author: Zhong Wen 2017/08/24
    /// </summary>
    public partial class ZoomblePictureBoxControl : UserControl
    {
        private Tool[] tools; // array of tools

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

        private void InitializeTools()
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
                //if (tools != null && activeTool != DrawToolType.None)
                //{
                //    Cursor = tools[(int)activeTool] is ToolPointer ? Cursors.Default : (tools[(int)activeTool] as ToolObject).Cursor;
                //}
                Enabled = activeTool != DrawToolType.None;
            }
        }

        internal void GraphicsPropertiesChangedHandler(DrawObject drawObject, GraphicsProperties graphicsProperties)
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

        #region "Pan & zoom"
        public const float ZoomMultiplier = 1.25f;
        public const float PanFactorNoShift = 100f / 3f;
        public const float PanFactorWithShift = 10f;
        #endregion

        // Max & Min Size
        public static Size DefaultMinLogicalWindowSize = new Size(2000, 2000);
        public static Size DefaultMaxLogicalWindowSize = new Size(100000000, 100000000);

        public const MeasureSystem.enUniMis DefaultUnitOfMeasure = MeasureSystem.enUniMis.mm;


        private MeasureSystem.enUniMis myUnitOfMeasure = DefaultUnitOfMeasure;

        #region "Event"
        public new event MouseClickEventHandler MouseClick;
        public delegate void MouseClickEventHandler(ZoomblePictureBoxControl sender, System.Windows.Forms.MouseEventArgs e, Point LogicalCoord, enClickAction CurrentClickAction);
        public new event MouseMoveEventHandler MouseMove;
        public delegate void MouseMoveEventHandler(ZoomblePictureBoxControl sender, System.Windows.Forms.MouseEventArgs e, Point LogicalCoord, enClickAction CurrentClickAction);
        public new event MouseDownEventHandler MouseDown;
        public delegate void MouseDownEventHandler(ZoomblePictureBoxControl sender, System.Windows.Forms.MouseEventArgs e, Point LogicalCoord, enClickAction CurrentClickAction);
        public new event MouseUpEventHandler MouseUp;
        public delegate void MouseUpEventHandler(ZoomblePictureBoxControl sender, System.Windows.Forms.MouseEventArgs e, Point LogicalCoord, enClickAction CurrentClickAction);
        public new event MouseEnterEventHandler MouseEnter;
        public delegate void MouseEnterEventHandler(ZoomblePictureBoxControl sender, System.EventArgs e);
        public new event MouseLeaveEventHandler MouseLeave;
        public delegate void MouseLeaveEventHandler(ZoomblePictureBoxControl sender, System.EventArgs e);
        public new event PaintEventHandler Paint;
        public delegate void PaintEventHandler(ZoomblePictureBoxControl sender, System.Windows.Forms.PaintEventArgs e);

        public event OnMeasureCompletedEventHandler OnMeasureCompleted;
        public delegate void OnMeasureCompletedEventHandler(ZoomblePictureBoxControl sender, Point StartPoint, Point EndPoint);
        public event OnRedrawCompletedEventHandler OnRedrawCompleted;
        public delegate void OnRedrawCompletedEventHandler(ZoomblePictureBoxControl sender, bool CacheRebuilded);
        public event OnPictureBoxDoubleClickEventHandler OnPictureBoxDoubleClick;
        public delegate void OnPictureBoxDoubleClickEventHandler(ZoomblePictureBoxControl sender, System.Windows.Forms.MouseEventArgs e, Point LogicalCoord);
        public event OnMinimumZoomLevelReachedEventHandler OnMinimumZoomLevelReached;
        public delegate void OnMinimumZoomLevelReachedEventHandler(ZoomblePictureBoxControl sender);
        public event OnMaximumZoomLevelReachedEventHandler OnMaximumZoomLevelReached;
        public delegate void OnMaximumZoomLevelReachedEventHandler(ZoomblePictureBoxControl sender);

        public event OnMeasureUnitChangedEventHandler OnMeasureUnitChanged;
        public delegate void OnMeasureUnitChangedEventHandler(MeasureSystem.enUniMis unit);
        public event OnClickActionChangedEventHandler OnClickActionChanged;
        public delegate void OnClickActionChangedEventHandler(enClickAction oldClickAction, enClickAction newClickAction);
        #region "context menu"
        public event ShowContextMenuRequiredEventHandler ShowContextMenuRequired;
        public delegate void ShowContextMenuRequiredEventHandler(ZoomblePictureBoxControl sender, float X, float Y);
        public void RaiseContextMenuRequest(ZoomblePictureBoxControl sender, float X, float Y)
        {
            try
            {
                ShowContextMenuRequired?.Invoke(sender, X, Y);
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
            }
        }
        #endregion
        #endregion

        private enClickAction myClickAction = enClickAction.Zoom;
        private CoordinatesBox myCoordinatesBox;
        private Color myDefaultBackgroundColor = Color.WhiteSmoke;

        private Color myZoomSelectionBoxColor = Color.Black;

        private bool myShowMouseCoordinates = true;
        private bool myShowRulers = true;
        private bool myShowGrid = true;

        private GridKind myGridView = GridKind.Crosses;
        private int myGridStep = 10000;

        private bool mySmartGridAdjust = true;

        private Bitmap myRefreshBackBuffer;
        private Bitmap myRedrawBackBuffer;

        private bool myIsDragging = false;
        private bool myIsLoaded = false;
        private Rulers myRulers;
        private Point myLastMouseDownPoint;
        public Point LastMouseDownLogicalCoord
        {
            get { return myLastMouseDownPoint; }
        }
        private bool myIsLayoutSuspended = true;

        private RECT myLastVisibleAreaRequested = DefaultRect;
        private RECT myResizeBeginEndPreviewArea = DefaultRect;
        private ResizeMode myResizeMode = ResizeMode.Stretch;
        private bool myIsBetweenResizeBeginEnd = false;

        Rectangle myBeginResizeClientArea;

        private enBitmapOriginPosition myPictureBoxImagePosition = enBitmapOriginPosition.TopLeft;
        private bool myShowPictureBoxImage = true;
        private BackImageGraphics myPictureBoxImageGR;
        private Image myPictureBoxImage;

        private BorderStyle myBorderStyle = BorderStyle.FixedSingle;

        private Size myMinLogicalWindowSize = DefaultMinLogicalWindowSize;
        private Size myMaxLogicalWindowSize = DefaultMaxLogicalWindowSize;

        private bool myIsChangingAutoScroll = false;

        private DistanceRuler withEventsField_myDistanceRuler;
        //private DistanceRuler myDistanceRuler
        //{
        //    get { return withEventsField_myDistanceRuler; }
        //    set
        //    {
        //        if (withEventsField_myDistanceRuler != null)
        //        {
        //            withEventsField_myDistanceRuler.CaptureFinished -= myDistanceRuler_CaptureFinished;
        //        }
        //        withEventsField_myDistanceRuler = value;
        //        if (withEventsField_myDistanceRuler != null)
        //        {
        //            withEventsField_myDistanceRuler.CaptureFinished += myDistanceRuler_CaptureFinished;
        //        }
        //    }
        //}

        private void myDistanceRuler_CaptureFinished(object sender, CaptureEventArgs e)
        {
            if (OnMeasureCompleted != null)
            {
                OnMeasureCompleted(this, GraphicInfo.ToLogicalPoint(e.StartPoint), GraphicInfo.ToLogicalPoint(e.EndPoint));
            }
        }

        private SelectionBoxElement mySelectionBox;
        public SelectionBoxElement SelectionBox
        {
            get { return mySelectionBox; }
        }

        private int myPictureBoxImagePixelSize_micron = 100;
        public int BackgroundImagePixelSize_Mic
        {
            get { return myPictureBoxImagePixelSize_micron; }
            set
            {
                if (myPictureBoxImagePixelSize_micron != value)
                {
                    myPictureBoxImagePixelSize_micron = value;
                    myPictureBoxImageGR = new BackImageGraphics((Bitmap)myPictureBoxImage, ImageCustomOrigin.X, ImageCustomOrigin.Y, 
                        enBitmapOriginPosition.TopLeft, myPictureBoxImagePixelSize_micron, myPictureBoxImagePixelSize_micron);
                }
            }
        }

        private Point myPictureBoxImageCustomOrigin;

        public Point ImageCustomOrigin
        {
            get { return myPictureBoxImageCustomOrigin; }
            set { myPictureBoxImageCustomOrigin = value; }
        }

        public enBitmapOriginPosition ImagePosition
        {
            get { return myPictureBoxImagePosition; }
            set
            {
                myPictureBoxImagePosition = value;
                if (myPictureBoxImage != null)
                {
                    myPictureBoxImageGR = new BackImageGraphics((Bitmap)myPictureBoxImage, ImageCustomOrigin.X, ImageCustomOrigin.Y,
                        enBitmapOriginPosition.TopLeft, myPictureBoxImagePixelSize_micron, myPictureBoxImagePixelSize_micron);
                }
            }
        }

        public Image Image
        {
            get { return myPictureBoxImage; }
            set
            {
                myPictureBoxImage = value;
                if (value != null)
                {
                    myPictureBoxImageGR = new BackImageGraphics((Bitmap)myPictureBoxImage, ImageCustomOrigin.X, ImageCustomOrigin.Y,
                        enBitmapOriginPosition.TopLeft, myPictureBoxImagePixelSize_micron, myPictureBoxImagePixelSize_micron);
                }
                else
                {
                    myPictureBoxImageGR = null;
                }
            }
        }

        protected override Size DefaultSize
        {
            get { return new Size(560, 400); }
        }


        private ConversionInfo myGraphicInfo = new ConversionInfo();
        public ConversionInfo GraphicInfo
        {
            get
            {
                return myGraphicInfo;
            }
            set
            {
                myGraphicInfo = value;
            }
        }

        public float ScaleFactor
        {
            get
            {
                return GraphicInfo.ScaleFactor;
            }
            set
            {
                if ((Width / value) > MaxLogicalWindowSize.Width && value < GraphicInfo.ScaleFactor)
                    return;
                if ((Height / value) > MaxLogicalWindowSize.Height && value < GraphicInfo.ScaleFactor)
                    return;
                if ((Width / value) < MinLogicalWindowSize.Width && value > GraphicInfo.ScaleFactor)
                    return;
                if ((Height / value) < MinLogicalWindowSize.Height && value > GraphicInfo.ScaleFactor)

                GraphicInfo.ScaleFactor = value;
            }
        }

        public Point LogicalOrigin
        {
            get { return GraphicInfo.LogicalOrigin; }
            set { GraphicInfo.LogicalOrigin = value; }
        }

        public Point LogicalCenter
        {
            get { return new Point(LogicalOrigin.X + LogicalWidth / 2, LogicalOrigin.Y + LogicalHeight / 2); }
        }

        public int LogicalWidth
        {
            get { return GraphicInfo.LogicalWidth; }
            set { GraphicInfo.LogicalWidth = value; }
        }

        public int LogicalHeight
        {
            get { return GraphicInfo.LogicalHeight; }
            set { GraphicInfo.LogicalHeight = value; }
        }

        public RECT LogicalArea
        {
            get { return GraphicInfo.LogicalArea; }
            private set { GraphicInfo.LogicalArea = value; }
        }

        public Size MinLogicalWindowSize
        {
            get { return myMinLogicalWindowSize; }
            set { myMinLogicalWindowSize = value; }
        }
        public Size MaxLogicalWindowSize
        {
            get { return myMaxLogicalWindowSize; }
            set
            {
                myMaxLogicalWindowSize = value;
            }
        }

        /// <summary>
        /// allows to display the coordinates where the mouse is
        /// </summary>
        [Description("allows to display the coordinates where the mouse is"), DefaultValue(true)]
        public bool ShowMouseCoordinates
        {
            get { return myShowMouseCoordinates; }
            set { myShowMouseCoordinates = value; }
        }

        [Description("allows to display the grid"), Category("display options"), DefaultValue(true)]
        public bool ShowGrid
        {
            get { return myShowGrid; }
            set { myShowGrid = value; }
        }

        /// <summary>
        /// allows to display the rulers
        /// </summary>
        [Description("allows to display the rulers"), Category("display options"), DefaultValue(true)]
        public bool ShowRulers
        {
            get { return myShowRulers; }
            set { myShowRulers = value; }
        }

        public Color AxesColor
        {
            get { return Color.Navy; }
        }

        public Color BackgroundColor
        {
            get { return myDefaultBackgroundColor; }
            set { myDefaultBackgroundColor = value; }
        }

        [Description("set the logical unit of measure of system of coordinates of the picturebox"), DefaultValue(typeof(MeasureSystem.enUniMis), "Millimeter")]
        public MeasureSystem.enUniMis UnitOfMeasure
        {
            get { return myUnitOfMeasure; }
            set
            {
                if (myUnitOfMeasure == value)
                {
                    return;
                }
                myUnitOfMeasure = value;
                if (OnMeasureUnitChanged != null)
                {
                    OnMeasureUnitChanged(value);
                }

                if (ShowMouseCoordinates || ShowRulers)
                {
                    Invalidate();
                }
            }
        }

        public Color GridColor
        {
            get { return Color.LightSteelBlue; }
        }

        #region "grid and snap"
        [Description("set the kind of display grids"), DefaultValue(typeof(GridKind), "Crosses")]
        public GridKind GridView
        {
            get { return myGridView; }
            set { myGridView = value; }
        }
        /// <summary>
        /// set the step of the grid
        /// </summary>
        [Description("set the step of the grid"), DefaultValue(10000)]
        public int GridStep
        {
            get { return myGridStep; }
            set { myGridStep = value; }
        }
        public bool SmartGridAdjust
        {
            get { return mySmartGridAdjust; }
            set { mySmartGridAdjust = value; }
        }
        #endregion

        #region "check keys pressed"

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

        protected Cursor CurrentCursor
        {
            get { return base.Cursor; }
            set
            {
                if (UseWaitCursor)
                {
                    return;
                }
                if (!object.ReferenceEquals(base.Cursor, value))
                {
                    base.Cursor = value;
                }
            }
        }

        protected override Cursor DefaultCursor
        {
            get
            {
                if (this.ClickAction == enClickAction.Zoom)
                {
                    return CommonCursors.ZoomCursor;
                }
                else
                {
                    return CommonCursors.EditCursor;
                }
            }
        }

        #region "current state"
        /// <summary>
        /// sets the type of action to be carried out on the click of a mouse
        /// </summary>
        [Description("sets the type of action to be carried out on the click of a mouse"), DefaultValue(typeof(enClickAction), "SelectObjects")]
        public enClickAction ClickAction
        {
            get { return myClickAction; }
            set
            {
                enClickAction oldClickAction = myClickAction;
                myClickAction = value;


                if (DesignMode)
                {
                    return;
                }

                if (OnClickActionChanged != null)
                {
                    OnClickActionChanged(oldClickAction, myClickAction);
                }

                switch (myClickAction)
                {
                    case enClickAction.Zoom:
                        SelectionBox.KeepAspectRatio = true;
                        Cursor = CommonCursors.ZoomCursor;
                        break;
                    case enClickAction.MeasureDistance:
                        SelectionBox.KeepAspectRatio = true;
                        Cursor = CommonCursors.EditCursor;
                        break;
                }
            }
        }
        #endregion

        #region "variables for the Resize mode"
        [DefaultValue(typeof(ResizeMode), "Stretch")]
        public ResizeMode ResizeMode
        {
            get { return myResizeMode; }
            set { myResizeMode = value; }
        }
        #endregion

        [Browsable(false)]
        public bool IsLayoutSuspended
        {
            get { return myIsLayoutSuspended; }
        }

        protected bool IsDragging
        {
            get { return myIsDragging; }
        }

        protected bool IsLoaded
        {
            get { return myIsLoaded; }
            private set { myIsLoaded = value; }
        }

        public bool ContainsMousePosition
        {
            get { return this.ClientRectangle.Contains(PointToClient(MousePosition)); }
        }

        private CrossCursor myFullCrossCursor;
        private CrossCursor FullCrossCursor
        {
            get
            {
                if (myFullCrossCursor == null)
                {
                    myFullCrossCursor = new CrossCursor(this);
                }
                return myFullCrossCursor;
            }
        }
        private bool FullPictureBoxCross
        {
            get { return myClickAction == enClickAction.MeasureDistance; }
        }

        /// <summary>
        /// returns the currently displayed by the picturebox coordinates area [logical]
        /// note: the area varies in the range of the zoom lens
        /// </summary>
        [Browsable(false)]
        public RECT VisibleRect
        {
            get { return new RECT(LogicalOrigin.X, LogicalOrigin.Y, LogicalOrigin.X + LogicalWidth, LogicalOrigin.Y + LogicalHeight); }
        }

        public ZoomblePictureBoxControl(bool visible) : base()
        {
            InitializeTools();
            GraphicsList = new GraphicsList();
            myCoordinatesBox = new CoordinatesBox(this);
            myRulers = new Rulers(this);
            withEventsField_myDistanceRuler = new DistanceRuler(this);
            mySelectionBox = new SelectionBoxElement(this);
            Load += PictureBoxEx_Load;
            GiveFeedback += ListDragSource_GiveFeedback;
            //This call is required by the Windows Form Designer.

            try
            {
                this.Visible = visible;
                InitializeComponent();
                //Add any initialization after the InitializeComponent() call
                this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
            }
        }

        public ZoomblePictureBoxControl() : this(true)
        {
        }

        private void ResetTemporaryData()
        {
            SelectionBox.Reset();
        }

        protected void UpdateDraggingState()
        {
            myIsDragging = (MouseButtons == MouseButtons.Left) && (!(SelectionBox.TopLeftCorner == RECT.InvalidPoint()));
            if (myIsDragging)
            {
                Point physicalMousePos = PointToClient(MousePosition);
                int distanceX = physicalMousePos.X - myLastMouseDownPoint.X;
                int distanceY = physicalMousePos.Y - myLastMouseDownPoint.Y;
                myIsDragging = (Math.Abs(distanceX) >= 3 || Math.Abs(distanceY) >= 3);
            }
        }

        private bool UpdateDimensions()
        {
            try
            {
                if ((Width < 1) || (Height < 1))
                {
                    return false;
                }

                int newWidth = (int)(Math.Ceiling(Convert.ToDouble(this.Width) / 100.0) * 100);
                int newHeight = (int)(Math.Ceiling(Convert.ToDouble(this.Height) / 100.0) * 100);


                bool bitmapCreationNeeded = (myRedrawBackBuffer == null) || (myRedrawBackBuffer.Width < newWidth) || (myRedrawBackBuffer.Height < newHeight);
                if (bitmapCreationNeeded)
                {
                    if ((myRedrawBackBuffer != null))
                        myRedrawBackBuffer.Dispose();
                    if ((myRefreshBackBuffer != null))
                        myRefreshBackBuffer.Dispose();

                    myRedrawBackBuffer = new Bitmap(newWidth, newHeight);
                    myRefreshBackBuffer = new Bitmap(newWidth, newHeight);
                }


                return bitmapCreationNeeded;
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
                return false;
            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                myIsDragging = false;

                Point logicalMousePos = GraphicInfo.ToLogicalPoint(e.X, e.Y);
                myLastMouseDownPoint = logicalMousePos;

                if (e.Button == MouseButtons.Right)
                {
                    if (MouseDown != null)
                    {
                        MouseDown(this, e, logicalMousePos, myClickAction);
                    }
                    base.OnMouseDown(e);
                    RaiseContextMenuRequest(this, e.X, e.Y);
                    return;
                }

                if ((e.Button == MouseButtons.Left))
                {
                    SelectionBox.TopLeftCorner = logicalMousePos;
                    SelectionBox.BottomRightCorner = logicalMousePos;
                }

                switch (ClickAction)
                {
                    case enClickAction.None:
                        break; // TODO: might not be correct. Was : Exit Select
                    case enClickAction.MeasureDistance:
                        //myDistanceRuler.MouseDown(this, e);
                        if (e.Button == MouseButtons.Left)
                            tools[(int)activeTool].OnMouseDown(this, e);
                        break;
                    case enClickAction.Zoom:
                        SelectionBox.KeepAspectRatio = true;
                        break;
                }

                if (MouseDown != null)
                {
                    MouseDown(this, e, logicalMousePos, myClickAction);
                }
                base.OnMouseDown(e);
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
            }
        }
        protected override void OnMouseClick(System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                if (IsDragging)
                {
                    return;
                }
                Point physicalMousePos = new Point(e.X, e.Y);
                Point logicalMousePos = GraphicInfo.ToLogicalPoint(physicalMousePos);
                if (MouseClick != null)
                {
                    MouseClick(this, e, logicalMousePos, myClickAction);
                }
                base.OnMouseClick(e);
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
            }
        }


        private void ListDragSource_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            // Set the custom cursor based upon the effect.
            if (((e.Effect & DragDropEffects.Move) == DragDropEffects.Move))
            {
                Cursor.Current = Cursors.SizeAll;
            }
            else
            {
                Cursor.Current = Cursors.No;
            }

        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            bool needsRepaint = false;
            try
            {
                Point physicalMousePos = new Point(e.X, e.Y);
                Point logicalMousePos = GraphicInfo.ToLogicalPoint(physicalMousePos);

                this.UpdateDraggingState();

                switch (myClickAction)
                {
                    case enClickAction.None:
                        break; // TODO: might not be correct. Was : Exit Select
                    case enClickAction.MeasureDistance:
                        if (e.Button == System.Windows.Forms.MouseButtons.Left || e.Button == MouseButtons.None)
                        {
                            //myDistanceRuler.MouseMove(this, e);
                            needsRepaint = true;

                            tools[(int)activeTool].OnMouseMove(this, e);
                        }
                        break;
                    case enClickAction.Zoom:
                        if (IsDragging)
                        {
                            SelectionBox.BottomRightCorner = logicalMousePos;
                            needsRepaint = true;
                        }
                        break;
                }

                MouseMove?.Invoke(this, e, logicalMousePos, myClickAction);
                base.OnMouseMove(e);
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
            }
            finally
            {
                if (needsRepaint || myShowMouseCoordinates)
                {
                    Invalidate();
                }
            }
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                Point logicalMousePos = GraphicInfo.ToLogicalPoint(e.X, e.Y);

                if ((e.Button == MouseButtons.Left))
                {
                    if ((SelectionBox.BottomRightCorner != logicalMousePos))
                    {
                        SelectionBox.BottomRightCorner = logicalMousePos;
                    }
                }

                switch (myClickAction)
                {
                    case enClickAction.None:
                        break; // TODO: might not be correct. Was : Exit Select
                    case enClickAction.MeasureDistance:
                        //myDistanceRuler.MouseUp(this, e);
                        if ((e.Button == MouseButtons.Left))
                            tools[(int)activeTool].OnMouseUp(this, e);
                        break;
                    case enClickAction.Zoom:
                        if (!IsDragging)
                        {
                            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                                ZoomForward(ref logicalMousePos);
                            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                                ZoomBack(ref logicalMousePos);
                        }
                        else
                        {
                            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                            {
                                ShowLogicalWindow(SelectionBox);
                            }
                        }
                        break;
                }

                if (MouseUp != null)
                {
                    MouseUp(this, e, logicalMousePos, myClickAction);
                }
                base.OnMouseUp(e);
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
            }
            finally
            {
                ResetTemporaryData();
            }
        }
        protected override void OnMouseDoubleClick(System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                base.OnMouseDoubleClick(e);
                tools[(int)activeTool].OnDoubleClick(this, e);
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
            }
        }
        private void PictureBoxEx_Load(object sender, EventArgs e)
        {
            Initialize();

            IsLoaded = true;

            UpdateDimensions();
            if (DesignMode)
            {
                Redraw();
            }
        }

        public void Redraw()
        {
            Redraw(false);
        }

        public virtual void Redraw(bool forceGraphicCacheRebuild)
        {
            Graphics g = null;
            try
            {
                if ((this.IsDisposed))
                {
                    return;
                }

                UpdateDimensions();

                if ((ScaleFactor == 0.0) || (LogicalWidth == 0) || (LogicalHeight == 0))
                {
                    return;
                }

                g = GetScaledGraphicObject(myRedrawBackBuffer);
                if (g == null)
                    return;

                g.Clear(BackgroundColor);

                if (myShowPictureBoxImage)
                {
                    DrawPictureBoxImage(g);
                }

                DrawGrids(g);

                if (GraphicsList != null)
                {
                    GraphicsList.Draw(g, this);
                }

                Refresh();

                if (OnRedrawCompleted != null)
                {
                    OnRedrawCompleted(this, forceGraphicCacheRebuild);
                }
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.ToUpper().Contains("CROSS-THREAD"))
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
            }
            finally
            {
                if (g != null)
                {
                    g.Dispose();
                }
            }
        }

        public Image GetScreenShot()
        {
            try
            {
                System.Drawing.Size OutSize = new System.Drawing.Size(this.Width, this.Height);
                System.Drawing.Bitmap retValue = new System.Drawing.Bitmap(OutSize.Width, OutSize.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                Graphics gr = Graphics.FromImage(retValue);
                this.Redraw(true);
                gr.DrawImageUnscaled(myRedrawBackBuffer, 0, 0);
                return retValue;
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
                return null;
            }
        }

        public bool SaveAScreenShot(string strDestFileName, ImageFormat _Format)
        {
            try
            {
                if (myRedrawBackBuffer != null)
                {
                    myRedrawBackBuffer.Save(strDestFileName, _Format);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
                return false;
            }
        }

        private void DrawPictureBoxImage(Graphics g)
        {
            try
            {
                if (myPictureBoxImageGR == null)
                    return;
                switch (myPictureBoxImagePosition)
                {
                    case enBitmapOriginPosition.TopLeft:
                        myPictureBoxImageGR.Origin = Point.Empty;
                        break;
                    case enBitmapOriginPosition.Custom:
                        myPictureBoxImageGR.Origin = myPictureBoxImageCustomOrigin;
                        break;
                }
                myPictureBoxImageGR.Draw(g);
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
            }
        }

        private void DrawGrids(Graphics g)
        {
            if (myShowGrid)
            {
                DrawGrid(g, 0, GridStep, GridView, GridColor, SmartGridAdjust);
            }
            if (myShowGrid)
            {
                DrawAxes(g);
            }
        }

        private void DrawGrid(Graphics g, int GridInitialOffset, int GridStep, GridKind GridMode, Color GridColor, bool SmartAdjust)
        {
            try
            {
                if (GridStep == 0)
                {
                    return;
                }
                if ((ScaleFactor <= 0.0))
                {
                    return;
                }
                if ((GridStep < myRulers.GetRulerStep()) && SmartAdjust)
                {
                    GridStep = (int)myRulers.GetRulerStep();
                }

                int InitialX = (int)(Math.Ceiling((double)(LogicalOrigin.X / GridStep)) * GridStep);
                int InitialY = (int)(Math.Ceiling((double)(LogicalOrigin.Y / GridStep)) * GridStep);
                Pen myPen = new Pen(GridColor);
                int FinalX = (int)(Math.Floor((double)((LogicalOrigin.X + LogicalWidth) / GridStep)) * GridStep);
                int FinalY = (int)(Math.Floor((double)((LogicalOrigin.Y + LogicalHeight) / GridStep)) * GridStep);
                int iIterX = 0;
                int iIterY = 0;
                switch (GridMode)
                {
                    case GridKind.Crosses:
                        for (iIterY = InitialY; iIterY <= FinalY; iIterY += GridStep)
                        {
                            for (iIterX = InitialX; iIterX <= FinalX; iIterX += GridStep)
                            {
                                g.DrawLine(myPen, iIterX + GridInitialOffset - 10 / ScaleFactor, iIterY + GridInitialOffset,
                                    iIterX + GridInitialOffset + 10 / ScaleFactor, iIterY + GridInitialOffset);
                                g.DrawLine(myPen, iIterX + GridInitialOffset, iIterY + GridInitialOffset - 10 / ScaleFactor,
                                    iIterX + GridInitialOffset, iIterY + GridInitialOffset + 10 / ScaleFactor);
                            }
                        }

                        break;
                    case GridKind.FullLines:
                        for (iIterY = InitialY; iIterY <= FinalY; iIterY += GridStep)
                        {
                            g.DrawLine(myPen, LogicalOrigin.X, iIterY + GridInitialOffset, LogicalWidth + LogicalOrigin.X,
                                iIterY + GridInitialOffset);
                        }

                        for (iIterX = InitialX; iIterX <= FinalX; iIterX += GridStep)
                        {
                            g.DrawLine(myPen, iIterX + GridInitialOffset, LogicalOrigin.Y, iIterX + GridInitialOffset,
                                LogicalHeight + LogicalOrigin.Y);
                        }

                        break;
                    case GridKind.Points:
                        for (iIterY = InitialY; iIterY <= FinalY; iIterY += GridStep)
                        {
                            for (iIterX = InitialX; iIterX <= FinalX; iIterX += GridStep)
                            {
                                g.DrawLine(myPen, iIterX + GridInitialOffset - 1 / ScaleFactor, iIterY + GridInitialOffset,
                                    iIterX + GridInitialOffset + 1 / ScaleFactor, iIterY + GridInitialOffset);
                                g.DrawLine(myPen, iIterX + GridInitialOffset, iIterY + GridInitialOffset - 1 / ScaleFactor,
                                    iIterX + GridInitialOffset, iIterY + GridInitialOffset + 1 / ScaleFactor);
                            }
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
            }
        }

        private void DrawAxes(Graphics g)
        {
            try
            {
                if ((ScaleFactor <= 0.0))
                {
                    return;
                }

                g.DrawLine(new Pen(AxesColor, -1), 0, LogicalOrigin.Y, 0, LogicalOrigin.Y + LogicalHeight);
                g.DrawLine(new Pen(AxesColor, -1), LogicalOrigin.X, 0, LogicalOrigin.X + LogicalWidth, 0);
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
            }
        }

        public void Refresh(bool _Invalidate = true)
        {
            Graphics g = null;
            try
            {
                if ((!this.Created) || (this.IsDisposed))
                {
                    return;
                }

                if (ScaleFactor == 0.0)
                {
                    return;
                }

                g = Graphics.FromImage(myRefreshBackBuffer);

                g.DrawImageUnscaledAndClipped(myRedrawBackBuffer, this.ClientRectangle);

                if (myShowRulers)
                {
                    myRulers.Draw(g);
                }

                ScaleGraphicObject(ref g);

                if (_Invalidate)
                    Invalidate();

            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
            }
            finally
            {
                if (g != null)
                {
                    g.Dispose();
                }
            }
        }

        private void DrawResizePreview(Graphics g)
        {
            g.Clear(BackgroundColor);

            ScaleGraphicObject(ref g);
            DrawGrids(g);
            g.ResetTransform();

            if ((myRedrawBackBuffer == null) || (myRedrawBackBuffer.Width == 0) || (myRedrawBackBuffer.Width == 0))
            {
                return;
            }

            if ((ResizeMode == ResizeMode.Normal))
            {
                g.DrawImage(myRedrawBackBuffer, Point.Empty);

                if (myShowRulers)
                {
                    myRulers.Draw(g);
                }
                return;
            }

            RECT actualPreviewArea = GraphicInfo.ToPhysicalRect(myLastVisibleAreaRequested);
            float tmpScaleFactor = Convert.ToSingle(Math.Max(actualPreviewArea.Width, 1)) / Convert.ToSingle(Math.Max(myResizeBeginEndPreviewArea.Width, 1));

            RECT bitmapOutputRect = new RECT();

            bitmapOutputRect.top = (int)(actualPreviewArea.top - (myResizeBeginEndPreviewArea.top * tmpScaleFactor));
            bitmapOutputRect.left = (int)(actualPreviewArea.left - (myResizeBeginEndPreviewArea.left * tmpScaleFactor));
            bitmapOutputRect.Width = (int)(myRedrawBackBuffer.Width * tmpScaleFactor);
            bitmapOutputRect.Height = (int)(myRedrawBackBuffer.Height * tmpScaleFactor);

            g.DrawImage(myRedrawBackBuffer, bitmapOutputRect);

            if (myShowRulers)
            {
                myRulers.Draw(g);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if (IsLayoutSuspended || (!Visible) || (!Created) || (IsDisposed))
                {
                    return;
                }

                Graphics g = e.Graphics;

                if (myIsBetweenResizeBeginEnd)
                {
                    DrawResizePreview(g);
                    return;
                }

                g.DrawImage(myRefreshBackBuffer, e.ClipRectangle, e.ClipRectangle, GraphicsUnit.Pixel);

                if (DesignMode)
                {
                    return;
                }

                Point physicalMousePos = this.PointToClient(MousePosition);
                Point logicalMousePos = GraphicInfo.ToLogicalPoint(physicalMousePos);

                ScaleGraphicObject(ref g);

                bool drawSelectionBox = false;

                switch (myClickAction)
                {
                    case enClickAction.None:
                        break; // TODO: might not be correct. Was : Exit Select
                    case enClickAction.MeasureDistance:
                        //g.ResetTransform();
                        if (GraphicsList != null)
                        {
                            GraphicsList.Draw(g, this);
                        }

                        //if (IsCtrlKeyPressed)
                        //{
                        //    double ScaleFactor = MeasureSystem.MicronToCustomUnit(Convert.ToDouble(BackgroundImagePixelSize_Mic), myUnitOfMeasure, false);
                        //    myDistanceRuler.Painting(gr, ScaleFactor);
                        //}
                        //else
                        //{
                        //    myDistanceRuler.Painting(gr);
                        //}
                        break;
                    case enClickAction.Zoom:
                        drawSelectionBox = IsDragging;
                        break; // TODO: might not be correct. Was : Exit Select
                }

                g.ResetTransform();

                if (drawSelectionBox && (!SelectionBox.IsInvalid))
                {
                    SelectionBox.Draw(g);
                }

                if (this.FullPictureBoxCross && ContainsMousePosition)
                {
                    FullCrossCursor.DrawCross(g, logicalMousePos);
                }

                if (myShowMouseCoordinates)
                {
                    if (IsCtrlKeyPressed)
                    {
                        System.Drawing.Point BitmapCoord = default(System.Drawing.Point);
                        BitmapCoord.X = logicalMousePos.X / BackgroundImagePixelSize_Mic;
                        BitmapCoord.Y = logicalMousePos.Y / BackgroundImagePixelSize_Mic;
                        myCoordinatesBox.DrawCoordinate(g, BitmapCoord, true);
                    }
                    else
                    {
                        myCoordinatesBox.DrawCoordinate(g, logicalMousePos);
                    }
                }

            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
            }
        }

        private void OnResizeBegin(System.Object sender, System.EventArgs e)
        {
            myIsBetweenResizeBeginEnd = true;
            myBeginResizeClientArea = this.ClientRectangle;
            myResizeBeginEndPreviewArea = GraphicInfo.ToPhysicalRect(myLastVisibleAreaRequested);
        }

        private void OnResizeEnd(System.Object sender, System.EventArgs e)
        {
            myIsBetweenResizeBeginEnd = false;
            if ((myBeginResizeClientArea != this.ClientRectangle))
            {
                OnSizeChanged(e);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            try
            {
                if (myIsChangingAutoScroll)
                {
                    return;
                }

                GraphicInfo.PhysicalWidth = this.Width;
                GraphicInfo.PhysicalHeight = this.Height;

                if ((Width < 1) || (Height < 1))
                {
                    return;
                }

                if (!IsLoaded & ResizeMode != ResizeMode.Stretch)
                {
                    return;
                }

                if (myIsBetweenResizeBeginEnd)
                {
                    if ((ResizeMode == ResizeMode.Stretch))
                    {
                        LogicalArea = VisibleAreaToLogicalArea(myLastVisibleAreaRequested);
                    }

                    Invalidate();
                    return;
                }

                UpdateDimensions();

                if ((ResizeMode == ResizeMode.Stretch))
                {
                    ShowLogicalWindow(myLastVisibleAreaRequested, false);
                }
                else
                {
                    Redraw();
                }

            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
            }
            finally
            {
                base.OnSizeChanged(e);
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            CurrentCursor = DefaultCursor;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            try
            {
                if (this.FullPictureBoxCross)
                {
                    Invalidate();
                }
                base.OnMouseLeave(e);
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
            }
        }

        protected override void OnMouseWheel(System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                Point MouseLogicalPosition = default(Point);
                MouseLogicalPosition.X = (int)(e.X / ScaleFactor + LogicalOrigin.X);
                MouseLogicalPosition.Y = (int)(e.Y / ScaleFactor + LogicalOrigin.Y);

                if (e.Delta > 0)
                {
                    if (IsCtrlKeyPressed)
                    {
                        PanLeft(PanFactorWithShift);
                        return;
                    }
                    if (IsShiftKeyPressed)
                    {
                        PanUp(PanFactorWithShift);
                        return;
                    }
                    ZoomForward(ref MouseLogicalPosition);
                }
                else
                {
                    if (IsCtrlKeyPressed)
                    {
                        PanRight(PanFactorWithShift);
                        return;
                    }
                    if (IsShiftKeyPressed)
                    {
                        PanDown(PanFactorWithShift);
                        return;
                    }

                    ZoomBack(ref MouseLogicalPosition);
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_BORDER = 0x800000;
                const int WS_EX_STATICEDGE = 0x20000;
                CreateParams cp = base.CreateParams;
                switch (myBorderStyle)
                {
                    case BorderStyle.FixedSingle:
                        cp.Style = cp.Style | WS_BORDER;
                        break;
                    case BorderStyle.Fixed3D:
                        cp.ExStyle = cp.ExStyle | WS_EX_STATICEDGE;
                        break;
                }

                return cp;
            }
        }

        private void AddResizeHandlers()
        {
            Form parentForm = FindForm();

            if ((parentForm == null))
            {
                return;
            }
            if ((parentForm.IsMdiChild))
            {
                parentForm = parentForm.MdiParent;
                if ((parentForm == null))
                {
                    return;
                }
            }
            parentForm.ResizeBegin += this.OnResizeBegin;
            parentForm.ResizeEnd += this.OnResizeEnd;
        }

        private void RemoveResizeHandlers()
        {
            Form parentForm = FindForm();
            if ((parentForm == null))
            {
                return;
            }
            parentForm.ResizeBegin -= this.OnResizeBegin;
            parentForm.ResizeEnd -= this.OnResizeEnd;
        }

        [Browsable(false)]
        public bool MinimumZoomReached
        {
            get
            {
                int nextHeight = (int)(LogicalHeight * ZoomMultiplier);
                int nextWidth = (int)(LogicalWidth * ZoomMultiplier);
                return nextHeight > MaxLogicalWindowSize.Height || nextWidth > MaxLogicalWindowSize.Width;
            }
        }

        [Browsable(false)]
        public bool MaximumZoomReached
        {
            get
            {
                int nextHeight = (int)(LogicalHeight / ZoomMultiplier);
                int nextWidth = (int)(LogicalWidth / ZoomMultiplier);
                return nextHeight < myMinLogicalWindowSize.Height || nextWidth < myMinLogicalWindowSize.Width;
            }
        }

        #region "Zoom in"
        public void ZoomForwardUsingCenter(Point ZoomCenter)
        {
            try
            {
                if (MaximumZoomReached)
                {
                    if (OnMaximumZoomLevelReached != null)
                    {
                        OnMaximumZoomLevelReached(this);
                    }
                    return;
                }

                RECT tmpArea = LogicalArea.ExpandFromFixedPoint(1f / ZoomMultiplier, LogicalCenter);
                tmpArea.Offset(ZoomCenter.X - LogicalCenter.X, ZoomCenter.Y - LogicalCenter.Y);

                myLastVisibleAreaRequested = myLastVisibleAreaRequested.ExpandFromFixedPoint(1f / ZoomMultiplier, LogicalCenter);
                myLastVisibleAreaRequested.Offset(ZoomCenter.X - LogicalCenter.X, ZoomCenter.Y - LogicalCenter.Y);

                LogicalArea = tmpArea;

                //this.OffsetX = (int)this.GraphicInfo.ToLogicalCoordX(ZoomCenter.X - LogicalCenter.X);
                //this.OffsetY = (int)this.GraphicInfo.ToLogicalCoordY(ZoomCenter.Y - LogicalCenter.Y);
                Console.WriteLine(string.Format("zoom forward--->X offset: {0}, Y offset: {1}", this.GraphicInfo.ToLogicalCoordX(ZoomCenter.X - LogicalCenter.X), 
                    this.GraphicInfo.ToLogicalCoordY(ZoomCenter.Y - LogicalCenter.Y)));
                Redraw();
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
            }
        }

        public void ZoomForwardOnLogicalCenter()
        {
            ZoomForwardUsingCenter(LogicalCenter);
        }

        public void ZoomForward(ref Point LogicalPosition)
        {
            if (MaximumZoomReached)
            {
                if (OnMaximumZoomLevelReached != null)
                {
                    OnMaximumZoomLevelReached(this);
                }
                return;
            }
            Point distance = new Point(LogicalPosition.X - LogicalCenter.X, LogicalPosition.Y - LogicalCenter.Y);

            distance.X = (int)(distance.X / ZoomMultiplier);
            distance.Y = (int)(distance.Y / ZoomMultiplier);
            Point newZoomCenter = new Point(LogicalPosition.X - distance.X, LogicalPosition.Y - distance.Y);

            ZoomForwardUsingCenter(newZoomCenter);
        }

        #endregion

        #region "Zoom out"

        public void ZoomBackUsingCenter(Point ZoomCenter)
        {
            try
            {
                if (MinimumZoomReached)
                {
                    if (OnMinimumZoomLevelReached != null)
                    {
                        OnMinimumZoomLevelReached(this);
                    }
                    return;
                }

                RECT tmpArea = LogicalArea.ExpandFromFixedPoint(ZoomMultiplier, LogicalCenter);
                tmpArea.Offset(ZoomCenter.X - LogicalCenter.X, ZoomCenter.Y - LogicalCenter.Y);

                //this.OffsetX = (int)this.GraphicInfo.ToLogicalCoordX(ZoomCenter.X - LogicalCenter.X);
                //this.OffsetY = (int)this.GraphicInfo.ToLogicalCoordY(ZoomCenter.Y - LogicalCenter.Y);
                myLastVisibleAreaRequested = myLastVisibleAreaRequested.ExpandFromFixedPoint(ZoomMultiplier, LogicalCenter);
                myLastVisibleAreaRequested.Offset(ZoomCenter.X - LogicalCenter.X, ZoomCenter.Y - LogicalCenter.Y);

                LogicalArea = tmpArea;

                Console.WriteLine(string.Format("zoom back--->X offset: {0}, Y offset: {1}", this.GraphicInfo.ToLogicalCoordX(ZoomCenter.X - LogicalCenter.X),
                    this.GraphicInfo.ToLogicalCoordY(ZoomCenter.Y - LogicalCenter.Y)));
                Redraw();
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
            }
        }

        public void ZoomBackOnLogicalCenter()
        {
            ZoomBackUsingCenter(LogicalCenter);
        }


        public void ZoomBack(ref Point LogicalPosition)
        {
            if (MinimumZoomReached)
            {
                if (OnMinimumZoomLevelReached != null)
                {
                    OnMinimumZoomLevelReached(this);
                }
                return;
            }

            Point distance = new Point(LogicalPosition.X - LogicalCenter.X, LogicalPosition.Y - LogicalCenter.Y);


            distance.X = (int)(distance.X * ZoomMultiplier);
            distance.Y = (int)(distance.Y * ZoomMultiplier);
            Point newZoomCenter = new Point(LogicalPosition.X - distance.X, LogicalPosition.Y - distance.Y);

            ZoomBackUsingCenter(newZoomCenter);
        }

        #endregion

        public void ZoomToDefaultRect()
        {
            try
            {
                if (Image != null)
                {
                    ZoomToFit();
                }
                else
                {
                    ShowLogicalWindow(DefaultRect, false);
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
            }
        }

        /// <summary>
        /// reset X/Y offset to original
        /// </summary>
        private void ResetOffset()
        {
            this.offsetX = 0;
            this.offsetY = 0;
        }

        public void ZoomToFit()
        {
            try
            {
                if (Image != null)
                {
                    ResetOffset();
                    RECT ImgR = new RECT(ImageCustomOrigin.X, ImageCustomOrigin.Y, ImageCustomOrigin.X + Image.Width, ImageCustomOrigin.Y + Image.Height);
                    RECT PhysicalR = default(RECT);
                    PhysicalR.left = ImgR.left * BackgroundImagePixelSize_Mic;
                    PhysicalR.top = ImgR.top * BackgroundImagePixelSize_Mic;
                    PhysicalR.Width = ImgR.Width * BackgroundImagePixelSize_Mic;
                    PhysicalR.Height = ImgR.Height * BackgroundImagePixelSize_Mic;
                    ShowLogicalWindow(PhysicalR, true);
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
            }
        }

        [Browsable(false)]
        public static RECT DefaultRect
        {
            get
            {
                RECT _Rect = default(RECT);
                _Rect.left = -3000;
                // -3mm 
                _Rect.top = -3000;
                // -3mm 
                _Rect.right = 100000;
                // 10cm 
                _Rect.bottom = 100000;
                // 10cm 
                return _Rect;
            }
        }

        #region management of pan
        private int offsetX = 0;
        public int OffsetX
        {
            get
            {
                return offsetX;
            }
            set
            {
                offsetX += value;
            }
        }
        private int offsetY = 0;
        public int OffsetY
        {
            get
            {
                return offsetY;
            }
            set
            {
                offsetY += value;
            }
        }

        public virtual void PanHome()
        {
        }
        public virtual void PanEnd()
        {
        }
        public virtual void PageUp()
        {
        }
        public virtual void PageDown()
        {
        }

        public virtual void PanDown(float Percent)
        {
            try
            {
                if (LogicalOrigin.Y + LogicalHeight > MaxLogicalWindowSize.Height / 2)
                {
                    return;
                }
                int tempOffsetY = Convert.ToInt32(Convert.ToSingle(LogicalHeight) * (Percent / 100f));
                OffsetY = tempOffsetY;
                LogicalOrigin = new Point(LogicalOrigin.X, LogicalOrigin.Y + tempOffsetY);
                myLastVisibleAreaRequested.Offset(0, tempOffsetY);
                Redraw();
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
            }
        }

        public virtual void PanUp(float Percent)
        {
            if (LogicalOrigin.Y < -MaxLogicalWindowSize.Height / 2)
            {
                return;
            }
            int tempOffsetY = Convert.ToInt32(Convert.ToSingle(LogicalHeight) * (Percent / 100f));
            OffsetY = -tempOffsetY;
            LogicalOrigin = new Point(LogicalOrigin.X, LogicalOrigin.Y - tempOffsetY);
            myLastVisibleAreaRequested.Offset(0, -tempOffsetY);
            Redraw();
        }

        public virtual void PanLeft(float Percent)
        {
            if (LogicalOrigin.X < -MaxLogicalWindowSize.Width / 2)
            {
                return;
            }
            int tempOffsetX = Convert.ToInt32(Convert.ToSingle(LogicalWidth) * (Percent / 100f));
            OffsetX = -tempOffsetX;
            LogicalOrigin = new Point(LogicalOrigin.X - tempOffsetX, LogicalOrigin.Y);
            myLastVisibleAreaRequested.Offset(-tempOffsetX, 0);
            Redraw();
        }

        public virtual void PanRight(float Percent)
        {
            if (LogicalOrigin.X + LogicalWidth > MaxLogicalWindowSize.Width / 2)
            {
                return;
            }
            int tempOffsetX = Convert.ToInt32(Convert.ToSingle(LogicalWidth) * (Percent / 100f));
            OffsetX = tempOffsetX;
            LogicalOrigin = new Point(LogicalOrigin.X + tempOffsetX, LogicalOrigin.Y);
            myLastVisibleAreaRequested.Offset(tempOffsetX, 0);
            Redraw();
        }
        #endregion

        #region "input from the keyboard"

        private bool myAlreadyInProcessCmdKey = false;

        public bool ProcessKeyboardKey(ref Message msg, Keys keyData)
        {
            return ProcessCmdKey(ref msg, keyData);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (myAlreadyInProcessCmdKey)
            {
                return false;
            }

            try
            {
                myAlreadyInProcessCmdKey = true;
                bool shiftIsPressed = (keyData & Keys.Shift) == Keys.Shift;
                bool ctrlIsPressed = (keyData & Keys.Control) == Keys.Control;

                Keys msgKey = (Keys)msg.WParam.ToInt32();

                // Output debug

                if ((msgKey != Keys.Control) && (msgKey != Keys.Shift) && (msgKey != Keys.Alt) && (msgKey != Keys.ControlKey) && (msgKey != Keys.ShiftKey))
                {
                    //??
                }

                switch (msgKey)
                {
                    case Keys.Left:
                        // -> Pan Left
                        if (shiftIsPressed)
                        {
                            PanLeft(PanFactorWithShift);
                        }
                        else
                        {
                            PanLeft(PanFactorNoShift);
                        }
                        return true;
                    case Keys.Right:
                        // -> Pan Right
                        if (shiftIsPressed)
                        {
                            PanRight(PanFactorWithShift);
                        }
                        else
                        {
                            PanRight(PanFactorNoShift);
                        }
                        return true;
                    case Keys.PageDown:
                        PageDown();
                        break;
                    case Keys.PageUp:
                        PageUp();
                        break;
                    case Keys.Up:
                        // -> Pan Up
                        if (shiftIsPressed)
                        {
                            PanUp(PanFactorWithShift);
                        }
                        else
                        {
                            PanUp(PanFactorNoShift);
                        }
                        return true;
                    case Keys.Down:
                        // -> Pan Down
                        if (shiftIsPressed)
                        {
                            PanDown(PanFactorWithShift);
                        }
                        else
                        {
                            PanDown(PanFactorNoShift);
                        }
                        return true;
                    case Keys.End:
                        PanEnd();
                        break;
                    case Keys.Home:
                        PanHome();
                        break;
                    case Keys.Add:
                        // -> Zoom In
                        ZoomForwardOnLogicalCenter();
                        return true;
                    case Keys.Subtract:
                        // -> Zoom Out
                        ZoomBackOnLogicalCenter();
                        return true;
                    case Keys.Escape:
                        switch (MouseButtons)
                        {
                            case MouseButtons.Left:
                                ResetTemporaryData();
                                Invalidate();
                                break;
                            case MouseButtons.None:
                                break;

                        }
                        return true;
                }

                return base.ProcessCmdKey(ref msg, keyData);
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);

                return false;
            }
            finally
            {
                myAlreadyInProcessCmdKey = false;
            }
        }
        #endregion

        #region "calculate routine to show windows logical"

        public void ShowLogicalWindow(RECT LogicalWindow, bool CenterWindow = true, bool AddEmptyBorder = true, bool ExcludeRulersArea = true)
        {
            try
            {
                if (LogicalWindow.IsZeroSized)
                {
                    ZoomToDefaultRect();
                    return;
                }

                LogicalArea = VisibleAreaToLogicalArea(LogicalWindow, CenterWindow, AddEmptyBorder, ExcludeRulersArea);

                Redraw();
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
            }
        }

        private RECT VisibleAreaToLogicalArea(RECT visibleArea, bool CenterWindow = true, bool AddEmptyBorder = true, bool ExcludeRulersArea = true)
        {
            if (visibleArea.IsZeroSized)
            {
                return new RECT();
            }

            visibleArea.NormalizeRect();

            myLastVisibleAreaRequested = visibleArea;

            float clientWidth = this.ClientRectangle.Width;
            float clientHeight = this.ClientRectangle.Height;

            float rulersPhysicalSize = 0;

            if (myShowRulers && ExcludeRulersArea)
            {
                rulersPhysicalSize = myRulers.Size;
            }

            if (AddEmptyBorder)
            {
                int widthBorder = Convert.ToInt32(visibleArea.Width / 18);
                int heightBorder = Convert.ToInt32(visibleArea.Height / 18);
                visibleArea.top -= heightBorder;
                visibleArea.bottom += heightBorder;
                visibleArea.left -= widthBorder;
                visibleArea.right += widthBorder;
            }

            float availableWidth = Math.Max(clientWidth - rulersPhysicalSize, 1);
            float availableHeight = Math.Max(clientHeight - rulersPhysicalSize, 1);

            float minScaleFactor = Math.Min(availableWidth / MinLogicalWindowSize.Width, availableHeight / MinLogicalWindowSize.Height);
            float maxScaleFactor = Math.Min(availableWidth / MaxLogicalWindowSize.Width, availableHeight / MaxLogicalWindowSize.Height);
            if (availableWidth == 1)
            {
                availableWidth = 1;
            }

            float horzScaleFactor = availableWidth / visibleArea.Width;
            float vertScaleFactor = availableHeight / visibleArea.Height;

            if ((horzScaleFactor <= 0))
                horzScaleFactor = maxScaleFactor;
            if ((vertScaleFactor <= 0))
                vertScaleFactor = maxScaleFactor;

            float newScaleFactor = Math.Min(horzScaleFactor, vertScaleFactor);
            if ((newScaleFactor > minScaleFactor))
                newScaleFactor = minScaleFactor;
            if ((newScaleFactor < maxScaleFactor))
                newScaleFactor = maxScaleFactor;


            float newLogicalHeight = clientHeight / newScaleFactor;
            float newLogicalWidth = clientWidth / newScaleFactor;

            int rulersLogicalSize = (int)(rulersPhysicalSize / newScaleFactor);

            float horizontalOffset = 0;
            float verticalOffset = 0;

            if (CenterWindow)
            {
                verticalOffset = Math.Abs((newLogicalHeight - rulersLogicalSize - visibleArea.Height) / 2);
                horizontalOffset = Math.Abs((newLogicalWidth - rulersLogicalSize - visibleArea.Width) / 2);
            }

            RECT logicalAreaToShow = new RECT();
            logicalAreaToShow.left = (int)(visibleArea.left - rulersLogicalSize - horizontalOffset);
            logicalAreaToShow.top = (int)(visibleArea.top - rulersLogicalSize - verticalOffset);
            logicalAreaToShow.Width = (int)(this.Width / newScaleFactor);
            logicalAreaToShow.Height = (int)(this.Height / newScaleFactor);
            logicalAreaToShow.NormalizeRect();

            return logicalAreaToShow;
        }
        #endregion

        #region "preview of the changes"

        public PointF CalculateScaleFactors(Point ScalingCenter, Point FirstScalePoint, Point SecondScalePoint, bool mantainAspectRatio = false)
        {
            try
            {
                double DeltaX = SecondScalePoint.X - FirstScalePoint.X;
                double DeltaY = SecondScalePoint.Y - FirstScalePoint.Y;

                if (mantainAspectRatio)
                {
                    if (Math.Abs(DeltaX) > Math.Abs(DeltaY))
                    {
                        DeltaY = DeltaX * ((FirstScalePoint.Y - ScalingCenter.Y) / (FirstScalePoint.X - ScalingCenter.X));
                    }
                    else
                    {
                        DeltaX = DeltaY * ((FirstScalePoint.X - ScalingCenter.X) / (FirstScalePoint.Y - ScalingCenter.Y));
                    }
                }

                double commonFactorX = 0.0;
                if (FirstScalePoint.X != ScalingCenter.X)
                {
                    commonFactorX = DeltaX / (FirstScalePoint.X - ScalingCenter.X);
                }
                double commonFactorY = 0.0;
                if (FirstScalePoint.Y != ScalingCenter.Y)
                {
                    commonFactorY = DeltaY / (FirstScalePoint.Y - ScalingCenter.Y);
                }

                return new System.Drawing.PointF((float)(1.0f + commonFactorX), (float)(1.0f + commonFactorY));
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
                return new System.Drawing.PointF(1.0f, 1.0f);
            }
        }
        #endregion

        private void Initialize()
        {
            try
            {
                FullCrossCursor.CoordinatesBox = myCoordinatesBox;
                FullCrossCursor.CoordinatesBox = myCoordinatesBox;

                ZoomToDefaultRect();

                AddResizeHandlers();
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
            }
        }

        #region "functions for the management of logic layout"
        private new void SuspendLayout()
        {
            base.SuspendLayout();
            this.myIsLayoutSuspended = true;
        }

        private new void ResumeLayout()
        {
            base.ResumeLayout();
            this.myIsLayoutSuspended = false;
            Redraw();
        }

        private new void ResumeLayout(bool performLayout)
        {
            base.ResumeLayout(performLayout);
            this.myIsLayoutSuspended = false;
            Redraw();
        }
        #endregion

        #region "routine for the scaling of graphics"

        /// <summary>
        /// returns an object derived from the bitmap graphics 
        /// the object is the matrix scaling and translation set on the scale factor and the logicalorigin currently in use. 
        /// </summary>
        /// <param name="Src"></param>
        /// <returns></returns>
        protected internal Graphics GetScaledGraphicObject(Bitmap Src)
        {
            if (Src == null)
                return null;
            Graphics g = Graphics.FromImage(Src);
            return ScaleGraphicObject(ref g);
        }

        /// <summary>
        /// returns an object graphics with the plates to scaling and translation approaches
        /// the scale factor and the logicalorigin currently in use.
        /// </summary>
        protected internal Graphics ScaleGraphicObject(ref Graphics g)
        {
            try
            {
                if (g == null)
                {
                    return null;
                }

                if ((ScaleFactor <= 0.0))
                {
                    return g;
                }

                g.ResetTransform();
                g.ScaleTransform(ScaleFactor, ScaleFactor);
                g.TranslateTransform(-LogicalOrigin.X, -LogicalOrigin.Y);
                return g;
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
                return null;
            }
        }

        public Graphics GetGraphics()
        {
            try
            {
                Graphics g = Graphics.FromImage(myRefreshBackBuffer);

                if ((ScaleFactor <= 0.0))
                {
                    return g;
                }

                g.ResetTransform();

                g.ScaleTransform(ScaleFactor, ScaleFactor);
                g.TranslateTransform(-LogicalOrigin.X, -LogicalOrigin.Y);
                return g;
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.Message);
                LogHelper.GetLogger<ZoomblePictureBoxControl>().Error(ex.StackTrace);
                return null;
            }
        }
        #endregion
    }
}
