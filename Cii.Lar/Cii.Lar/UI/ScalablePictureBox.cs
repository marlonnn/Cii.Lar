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

/// <summary>
/// This is public domain software - that is, you can do whatever you want
/// with it, and include it software that is licensed under the GNU or the
/// BSD license, or whatever other licence you choose, including proprietary
/// closed source licenses. 
/// https://www.codeproject.com/Articles/15373/A-scrollable-zoomable-and-scalable-picture-box
/// </summary>
namespace Cii.Lar.UI
{
    /// <summary>
    /// Front end control of the scrollable, zoomable and scalable picture box.
    /// It is a facade and mediator of ScalablePictureBoxImp control and PictureTracker control.
    /// An application should use this control for showing picture
    /// instead of using ScalablePictureBoxImp control directly.
    /// </summary>
    public partial class ScalablePictureBox : UserControl
    {
        public StatisticsCtrl StatisticsCtrl
        {
            get
            {
                return this.statisticsCtrl;
            }
            set
            {
                this.statisticsCtrl = value;
            }
        }

        public DrawToolType ActiveTool
        {
            get
            {
                return this.scalablePictureBoxImp.ActiveTool;
            }
            set
            {
                this.scalablePictureBoxImp.ActiveTool = value;
            }
        }


        public GraphicsList GraphicsList
        {
            get
            {
                return this.scalablePictureBoxImp.GraphicsList;
            }

            private set
            {
                this.scalablePictureBoxImp.GraphicsList = value;
            }
        }

        public bool CreatingDrawObject
        {
            get
            {
                return this.scalablePictureBoxImp.CreatingDrawObject;
            }
        }

        /// <summary>
        /// indicating mouse dragging mode of picture tracker control
        /// </summary>
        private bool isDraggingPictureTracker = false;

        /// <summary>
        /// last mouse position of mouse dragging
        /// </summary>
        private Point lastMousePos;

        /// <summary>
        /// the new area where the picture tracker control to be dragged
        /// </summary>
        private Rectangle draggingRectangle;

        /// <summary>
        /// indicating mouse dragging mode of Statistics control
        /// </summary>
        private bool isDraggingStatistics = false;

        /// <summary>
        /// last Statistics mouse position of mouse dragging
        /// </summary>
        private Point lastStatisticsMousePos;

        /// <summary>
        /// the new area where the Statistics control to be dragged
        /// </summary>
        private Rectangle draggingStatisticsRectangle;

        public ScalablePictureBox()
        {
            InitializeComponent();
            this.pictureTracker.BringToFront();

            // enable double buffering
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);

            // register event handler for events from ScalablePictureBox
            this.scalablePictureBoxImp.PictureBoxPaintedEvent += new ScalablePictureBoxImp.PictureBoxPaintedEventHandler(this.pictureTracker.OnPictureBoxPainted);
            this.scalablePictureBoxImp.ZoomRateChangedEvent += new ScalablePictureBoxImp.ZoomRateChangedEventHandler(this.ScalablePictureBox_ZoomRateChanged);

            // register event handler for events from PictureTracker
            this.pictureTracker.ScrollPictureEvent += new PictureTracker.ScrollPictureEventHandler(this.scalablePictureBoxImp.OnScrollPictureEvent);
            this.pictureTracker.PictureTrackerClosed += new PictureTracker.PictureTrackerClosedHandler(this.PictureTracker_PictureTrackerClosed);
        }

        /// <summary>
        /// Set a picture to show in ScalablePictureBox control 
        /// </summary>
        public Image Picture
        {
            set
            {
                this.scalablePictureBoxImp.Picture = value;
                this.pictureTracker.Picture = value;
            }
        }

        /// <summary>
        /// Get picture box control
        /// </summary>
        [Bindable(false)]
        public PictureBox PictureBox
        {
            get
            {
                return this.scalablePictureBoxImp.PictureBox;
            }
        }

        public int CurrentScalePercent
        {
            set
            {
                this.scalablePictureBoxImp.CurrentScalePercent = value;
                this.scalablePictureBoxImp.ImageSizeMode = PictureBoxSizeMode.Normal;
            }
        }

        /// <summary>
        /// Notify current scale percentage to PictureTracker control if current picture is
        /// zoomed in, or hide PictureTracker control if current picture is shown fully.
        /// </summary>
        /// <param name="zoomRate">zoom rate of picture</param>
        /// <param name="isWholePictureShown">true if the whole picture is shown</param>
        private void ScalablePictureBox_ZoomRateChanged(int zoomRate, bool isWholePictureShown)
        {
            if (isWholePictureShown)
            {
                this.pictureTracker.Visible = false;
                this.pictureTracker.Enabled = false;
            }
            else
            {
                this.pictureTracker.Visible = true;
                this.pictureTracker.Enabled = true;
                this.pictureTracker.ZoomRate = zoomRate;
            }
        }

        /// <summary>
        /// Inform ScalablePictureBox control to show picture fully.
        /// </summary>
        private void PictureTracker_PictureTrackerClosed()
        {
            this.scalablePictureBoxImp.ImageSizeMode = PictureBoxSizeMode.Zoom;
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


        /// <summary>
        /// begin to drag picture tracker control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureTracker_MouseDown(object sender, MouseEventArgs e)
        {
            isDraggingPictureTracker = true;    // Make a note that we are dragging picture tracker control

            // Store the last mouse poit for this rubber-band rectangle.
            lastMousePos.X = e.X;
            lastMousePos.Y = e.Y;

            // draw initial dragging rectangle
            draggingRectangle = this.pictureTracker.Bounds;
            DrawReversibleRect(draggingRectangle);
        }

        /// <summary>
        /// dragging picture tracker control in mouse dragging mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureTracker_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDraggingPictureTracker)
            {
                // caculating next candidate dragging rectangle
                Point newPos = new Point(draggingRectangle.Location.X + e.X - lastMousePos.X,
                                         draggingRectangle.Location.Y + e.Y - lastMousePos.Y);
                Rectangle newPictureTrackerArea = draggingRectangle;
                newPictureTrackerArea.Location = newPos;

                // saving current mouse position to be used for next dragging
                this.lastMousePos = new Point(e.X, e.Y);

                // dragging picture tracker only when the candidate dragging rectangle
                // is within this ScalablePictureBox control
                if (this.ClientRectangle.Contains(newPictureTrackerArea))
                {
                    // removing previous rubber-band frame
                    DrawReversibleRect(draggingRectangle);

                    // updating dragging rectangle
                    draggingRectangle = newPictureTrackerArea;

                    // drawing new rubber-band frame
                    DrawReversibleRect(draggingRectangle);
                }
            }
        }

        /// <summary>
        /// end dragging picture tracker control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureTracker_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDraggingPictureTracker)
            {
                isDraggingPictureTracker = false;

                // erase dragging rectangle
                DrawReversibleRect(draggingRectangle);

                // move the picture tracker control to the new position
                this.pictureTracker.Location = draggingRectangle.Location;
            }
        }


        private void StatisticsCtrl_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (isDraggingStatistics)
            {
                isDraggingStatistics = false;

                // erase dragging rectangle
                DrawReversibleRect(draggingStatisticsRectangle);

                // move the Statistics control to the new position
                this.statisticsCtrl.Location = draggingStatisticsRectangle.Location;
            }
        }

        private void StatisticsCtrl_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (isDraggingStatistics)
            {
                // caculating next candidate dragging rectangle
                Point newPos = new Point(draggingStatisticsRectangle.Location.X + e.X - lastStatisticsMousePos.X,
                                         draggingStatisticsRectangle.Location.Y + e.Y - lastStatisticsMousePos.Y);
                Rectangle newPictureTrackerArea = draggingStatisticsRectangle;
                newPictureTrackerArea.Location = newPos;

                // saving current mouse position to be used for next dragging
                this.lastStatisticsMousePos = new Point(e.X, e.Y);

                // dragging Statistics ctrl only when the candidate dragging rectangle
                // is within this ScalablePictureBox control
                if (this.ClientRectangle.Contains(newPictureTrackerArea))
                {
                    // removing previous rubber-band frame
                    DrawReversibleRect(draggingStatisticsRectangle);

                    // updating dragging rectangle
                    draggingStatisticsRectangle = newPictureTrackerArea;

                    // drawing new rubber-band frame
                    DrawReversibleRect(draggingStatisticsRectangle);
                }
            }
        }

        private void StatisticsCtrl_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            isDraggingStatistics = true;    // Make a note that we are dragging Statistics control

            // Store the last mouse poit for this rubber-band rectangle.
            lastStatisticsMousePos.X = e.X;
            lastStatisticsMousePos.Y = e.Y;

            // draw initial dragging rectangle
            draggingStatisticsRectangle = this.statisticsCtrl.Bounds;
            DrawReversibleRect(draggingStatisticsRectangle);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            int x = this.ClientSize.Width - this.pictureTracker.Width - 20;
            int y = this.ClientSize.Height - this.pictureTracker.Height - 20;
            this.pictureTracker.Location = new Point(x, y);
        }
    }
}
