using Cii.Lar.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar.DrawTools
{
    /// <summary>
    /// Base class for all draw objects
    /// Author:Zhong Wen 2017/07/25
    /// </summary>
    public abstract class DrawObject
    {
        public enum ElementType
        {
            Nothing,
            Label,
            Handle,
            Gate
        }

        public class HitTestResult
        {
            public ElementType ElementType
            {
                get;
                private set;
            }


            /// <summary>
            /// handle, gate or label index 
            /// </summary>
            public int Index
            {
                get;
                private set;
            }


            public HitTestResult(ElementType type, int index)
            {
                ElementType = type;
                Index = index;
            }
        }

        private bool selected;

        public bool Selected
        {
            get
            {
                return selected;
            }
            set
            {
                this.selected = value;
            }
        }

        private bool creating; // this value does not need to serialize, it always false when deserializing
        public bool Creating
        {
            get { return creating; }
            set { creating = value; }
        }

        protected RectangleF[] _rectProportion; // gate label rectangle proportion        

        protected RectangleF[] rectF;   // gate label rectangle, keep for old data, and in memory use

        // Allows to write Undo - Redo functions and don't care about
        // objects order in the list.
        private int id;

        private bool _autoSnap;
        public bool AutoSnap
        {
            get { return _autoSnap; }
            set { _autoSnap = value; }
        }

        protected static Size DefaultDrawAreaSize = new Size(256, 256); //const draw area size use for hit test

        private int penWidth = 1;

        public int PenWidth
        {
            get
            {
                return penWidth;
            }
            set
            {
                penWidth = value;
            }
        }
        private Color color;
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
        private Point movingOffset;
        public Point MovingOffset
        {
            get { return movingOffset; }
            set { movingOffset = value; }
        }


        /// <summary>
        /// Number of handles
        /// </summary>
        public virtual int HandleCount
        {
            get
            {
                return 0;
            }
        }
        public virtual bool IsHandleVisible(int handleNumber)
        {
            return true;
        }

        /// <summary>
        /// Get handle point by 1-based number
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public virtual Point GetHandle(CursorPictureBox pictureBox, int handleNumber)
        {
            return new Point(0, 0);
        }

        /// <summary>
        /// Get handle rectangle by 1-based number
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public virtual Rectangle GetHandleRectangle(CursorPictureBox pictureBox, int handleNumber)
        {
            Point point = GetHandle(pictureBox, handleNumber);

            return new Rectangle(point.X - 3, point.Y - 3, 6, 6);
        }

        /// <summary>
        /// Move handle to the point
        /// </summary>
        /// <param name="point"></param>
        /// <param name="handleNumber"></param>
        public virtual void MoveHandleTo(CursorPictureBox pictureBox, Point point, int handleNumber)
        {
        }

        /// <summary>
        /// Draw object
        /// </summary>
        /// <param name="g"></param>
        public virtual void Draw(Graphics g, CursorPictureBox pictureBox)
        {
        }

        public virtual void DrawTracker(Graphics g, CursorPictureBox pictureBox)
        {
            if (Selected)
            {
                SolidBrush brush = new SolidBrush(Color.White);
                Pen pen = new Pen(Color.Black, penWidth);

                for (int i = 1; i <= HandleCount; i++)
                {
                    if (!IsHandleVisible(i))
                        continue;

                    Rectangle r = GetHandleRectangle(pictureBox, i);
                    r.Offset(MovingOffset);
                    try
                    {
                        g.DrawRectangle(pen, r);
                        g.FillRectangle(brush, r);
                    }
                    catch (System.Exception ex)
                    {
                        Selected = false;
                    }
                }
                pen.Dispose();
                brush.Dispose();
            }
        }
    }
}
