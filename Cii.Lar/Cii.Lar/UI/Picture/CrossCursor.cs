using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cii.Lar.UI.Picture.PublicTypes;

namespace Cii.Lar.UI.Picture
{
    /// <summary>
    /// Mouse Cross cursor
    /// Author: Zhong Wen 2017/08/24
    /// </summary>
    public class CrossCursor
    {
        /// <summary>
        /// Cross cursor default size
        /// </summary>

        public static readonly Size DefaultSize = new Size(20, 20);

        private Size mySize = DefaultSize;

        public Size Size
        {
            get
            {
                return mySize;
            }
            set
            {
                mySize = value;
            }
        }
        private ZoomblePictureBoxControl myPictureBox;
        public ZoomblePictureBoxControl PictureBoxControl
        {
            get
            {
                return myPictureBox;
            }
            private set
            {
                myPictureBox = value;
            }
        }

        private bool myFullPictureBoxCross = false;

        /// <summary>
        /// Cross cursor color
        /// </summary>
        private Color myColor = System.Drawing.Color.Black;

        public Color CrossColor
        {
            get
            {
                return myColor;
            }
            set
            {
                if (value != myColor)
                {
                    myColor = value;
                }
            }
        }

        private Point myCrossPosition = RECT.InvalidPoint();
        public Point CrossPosition
        {
            get
            {
                return myCrossPosition;
            }
            set
            {
                myCrossPosition = value;
            }
        }

        private Point myLastCrossTopPoint;
        private Point myLastCrossLeftPoint;
        private Point myLastCrossRightPoint;
        private Point myLastCrossBottomPoint;

        /// <summary>
        /// Coordinates box to draw mouse position when cursor is over on screen
        /// </summary>
        private CoordinatesBox myCoordinatesBox = null;
        public CoordinatesBox CoordinatesBox
        {
            get
            {
                return myCoordinatesBox;
            }
            set
            {
                myCoordinatesBox = value;
            }
        }

        public CrossCursor(ZoomblePictureBoxControl picBoxControl)
        {
            myPictureBox = picBoxControl;
        }

        public void DrawCross(Graphics g, Point logicalCoord)
        {
            try
            {
                if (myPictureBox != null && logicalCoord != RECT.InvalidPoint())
                {
                    Point physicalCrossCoords = PictureBoxControl.GraphicInfo.ToPhysicalPoint(logicalCoord);

                    Point minCrossValue = Point.Empty;
                    Point maxCrossValue = new Point(myPictureBox.Width, myPictureBox.Height);

                    if (myCoordinatesBox != null)
                    {
                        if (!myFullPictureBoxCross && myCoordinatesBox.DrawingRect.Contains(physicalCrossCoords))
                        {
                            return;
                        }
                        if (physicalCrossCoords.X > myCoordinatesBox.DrawingRect.X)
                        {
                            maxCrossValue.Y -= myCoordinatesBox.DrawingRect.Height;
                        }
                        if (physicalCrossCoords.Y > myCoordinatesBox.DrawingRect.Y)
                        {
                            maxCrossValue.X -= myCoordinatesBox.DrawingRect.Width;
                        }
                    }

                    int maxCrossValueX = maxCrossValue.X;
                    int maxCrossValueY = maxCrossValue.Y;

                    if (myFullPictureBoxCross)
                    {
                        // horizontal line
                        myLastCrossLeftPoint.X = minCrossValue.X;
                        myLastCrossRightPoint.X = maxCrossValue.X;
                        myLastCrossLeftPoint.Y = physicalCrossCoords.Y;
                        myLastCrossRightPoint.Y = physicalCrossCoords.Y;
                        // vertical line
                        myLastCrossTopPoint.Y = minCrossValue.Y;
                        myLastCrossBottomPoint.Y = maxCrossValue.Y;
                        myLastCrossTopPoint.X = physicalCrossCoords.X;
                        myLastCrossBottomPoint.X = physicalCrossCoords.X;
                    }
                    else
                    {
                        // horizontal line
                        myLastCrossLeftPoint.X = physicalCrossCoords.X - mySize.Width / 2;
                        myLastCrossRightPoint.X = physicalCrossCoords.X + mySize.Width / 2;
                        myLastCrossLeftPoint.Y = physicalCrossCoords.Y;
                        myLastCrossRightPoint.Y = physicalCrossCoords.Y;
                        // vertical line
                        myLastCrossTopPoint.Y = physicalCrossCoords.Y - mySize.Height / 2;
                        myLastCrossBottomPoint.Y = physicalCrossCoords.Y + mySize.Height / 2;
                        myLastCrossTopPoint.X = physicalCrossCoords.X;
                        myLastCrossBottomPoint.X = physicalCrossCoords.X;
                    }

                    if (myLastCrossRightPoint.X > maxCrossValueX)
                        myLastCrossRightPoint.X = maxCrossValueX;
                    if (myLastCrossRightPoint.Y > maxCrossValueY)
                        myLastCrossRightPoint.Y = maxCrossValueY;
                    if (myLastCrossRightPoint.Y < minCrossValue.Y)
                        myLastCrossRightPoint.Y = minCrossValue.Y;
                    if (myLastCrossBottomPoint.Y > maxCrossValueY)
                        myLastCrossBottomPoint.Y = maxCrossValueY;
                    if (myLastCrossBottomPoint.X > maxCrossValueX)
                        myLastCrossBottomPoint.X = maxCrossValueX;
                    if (myLastCrossBottomPoint.X < minCrossValue.X)
                        myLastCrossBottomPoint.X = minCrossValue.X;
                    if (myLastCrossLeftPoint.X < minCrossValue.X)
                        myLastCrossLeftPoint.X = minCrossValue.X;
                    if (myLastCrossLeftPoint.Y > maxCrossValueY)
                        myLastCrossLeftPoint.Y = maxCrossValueY;
                    if (myLastCrossLeftPoint.Y < minCrossValue.Y)
                        myLastCrossLeftPoint.Y = minCrossValue.Y;
                    if (myLastCrossTopPoint.Y < minCrossValue.Y)
                        myLastCrossTopPoint.Y = minCrossValue.Y;
                    if (myLastCrossTopPoint.X > maxCrossValueX)
                        myLastCrossTopPoint.X = maxCrossValueX;
                    if (myLastCrossTopPoint.X < minCrossValue.X)
                        myLastCrossTopPoint.X = minCrossValue.X;

                    using (Pen crossPen = new Pen(myColor))
                    {
                        g.DrawLine(crossPen, myLastCrossLeftPoint, myLastCrossRightPoint);
                        g.DrawLine(crossPen, myLastCrossTopPoint, myLastCrossBottomPoint);
                    }

                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<CrossCursor>().Error(ex.Message);
                LogHelper.GetLogger<CrossCursor>().Error(ex.StackTrace);
            }

        }
    }
}
