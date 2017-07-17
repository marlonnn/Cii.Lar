using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cii.Lar.UI
{
    /// <summary>
    /// a user control that can host a background movable control
    /// </summary>
    public class MovableObjectHost : UserControl
    {
        public class HitTestObjectArgs : EventArgs
        {
            /// <summary>
            /// gets the point to be hit test
            /// </summary>
            public Point MouseLocation
            {
                get;
                private set;
            }

            /// <summary>
            /// gets or sets if object hit
            /// </summary>
            public bool Hit
            {
                get;
                set;
            }

            public HitTestObjectArgs(Point mouseLocation)
            {
                MouseLocation = mouseLocation;
            }
        }

        public event EventHandler<HitTestObjectArgs> HitTestObject;

        /// <summary>
        /// gets if movable object hit 
        /// </summary>
        /// <returns></returns>
        protected virtual bool IsObjectHit(Point mouseLocation)
        {
            // raise event to get hit result from object
            if (HitTestObject != null)
            {
                var e = new HitTestObjectArgs(mouseLocation);
                HitTestObject(this, e);
                return e.Hit;
            }

            return false;
        }

        /// <summary>
        /// gets if allow to handle mouse move event for the object
        /// </summary>
        /// <returns></returns>
        public virtual bool AllowHandleObjectMouseMoveEvent(object sender, MouseEventArgs e)
        {
            return true;
        }

        /// <summary>
        /// gets if allow to handle mouse up event for the object
        /// </summary>
        /// <returns></returns>
        public virtual bool AllowHandleObjectMouseUpEvent(object sender, MouseEventArgs e)
        {
            return true;
        }

        /// <summary>
        /// gets if allow to handle mouse down event for the object
        /// </summary>
        /// <returns></returns>
        public virtual bool AllowHandleObjectMouseDownEvent(object sender, MouseEventArgs e)
        {
            return true;
        }

        /// <summary>
        /// cancel the host's mouse down actions if needed when object handles it
        /// </summary>
        public virtual void CancelMouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
