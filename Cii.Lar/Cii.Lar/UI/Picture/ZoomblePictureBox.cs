﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cii.Lar.ExpClass;
using static Cii.Lar.ExpClass.PublicTypes;

namespace Cii.Lar.UI.Picture
{
    public partial class ZoomblePictureBox : UserControl
    {
        private RxPictureBox pictureBox;

        public const MeasureSystem.enUniMis DefaultUnitOfMeasure = MeasureSystem.enUniMis.mm;

        private MeasureSystem.enUniMis myUnitOfMeasure = DefaultUnitOfMeasure;

        public event OnMeasureUnitChangedEventHandler OnMeasureUnitChanged;
        public delegate void OnMeasureUnitChangedEventHandler(MeasureSystem.enUniMis unit);

        private bool myShowMouseCoordinates = true;
        private bool myShowRulers = true;
        private bool myShowGrid = true;

        private int myPictureBoxImagePixelSize_micron = 100;
        public int BackgroundImagePixelSize_Mic
        {
            get { return myPictureBoxImagePixelSize_micron; }
            set
            {
                if (myPictureBoxImagePixelSize_micron != value)
                {
                    myPictureBoxImagePixelSize_micron = value;
                }
            }
        }

        private Point myPictureBoxImageCustomOrigin;

        public Point ImageCustomOrigin
        {
            get { return myPictureBoxImageCustomOrigin; }
            set { myPictureBoxImageCustomOrigin = value; }
        }

        private ConversionInfo myGraphicInfo;
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
                GraphicInfo.ScaleFactor = value;
            }
        }

        public System.Drawing.Point LogicalOrigin
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

        public Image Image
        {
            get
            {
                return this.pictureBox.Image;
            }
            set
            {
                //this.pictureBox.Image = value;
                if (value != null)
                {
                    //this.pictureBox = new RxPictureBox((Bitmap)myPictureBoxImage, ImageCustomOrigin.X, ImageCustomOrigin.Y,
                    //    enBitmapOriginPosition.TopLeft, myPictureBoxImagePixelSize_micron, myPictureBoxImagePixelSize_micron);
                }
            }
        }

        public ZoomblePictureBox()
        {

            this.Load += ZoomblePictureBox_Load;

            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        }

        private void ZoomblePictureBox_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Initialize()
        {
            ImageCustomOrigin = new Point();
            pictureBox = new RxPictureBox();
            ZoomToDefaultRect();
        }

        private void ZoomToDefaultRect()
        {
            if (this.pictureBox.Image != null)
            {
                ZoomToFit();
            }
            else
            {
                ShowLogicalWindow(DefaultRect, false);
            }
        }

        private void ZoomToFit()
        {
            if (this.pictureBox.Image != null)
            {
                RECT ImgR = new RECT(ImageCustomOrigin.X, ImageCustomOrigin.Y, 
                    ImageCustomOrigin.X + this.pictureBox.Image.Width, ImageCustomOrigin.Y + this.pictureBox.Image.Height);
                RECT PhysicalR = default(RECT);
                PhysicalR.left = ImgR.left * BackgroundImagePixelSize_Mic;
                PhysicalR.top = ImgR.top * BackgroundImagePixelSize_Mic;
                PhysicalR.Width = ImgR.Width * BackgroundImagePixelSize_Mic;
                PhysicalR.Height = ImgR.Height * BackgroundImagePixelSize_Mic;
                ShowLogicalWindow(PhysicalR, true);
            }
        }

        public void ShowLogicalWindow(RECT LogicalWindow, bool CenterWindow = true, bool AddEmptyBorder = true, bool ExcludeRulersArea = true)
        {
            if (LogicalWindow.IsZeroSized)
            {
                ZoomToDefaultRect();
                return;
            }

        }
    }
}
