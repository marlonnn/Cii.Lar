using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar
{
    public enum ToolStripAction
    {
        Empty,
        Capture,
        Video,
        Archive,
        ZoomOut,
        ZoomIn,
        ZoomFit,
        Scale,
        Line,
        Rectangle,
        Ellipse,
        Polygon,
        Move,
        Laser,
        Setting,
        OpenFile,
        PortConfig
    }
    /// <summary>
    /// Tool strip eventargs
    /// </summary>
    public class ToolStripEventArgs : EventArgs
    {
        private ToolStripAction action;
        public ToolStripAction Action
        {
            get
            {
                return action;
            }
            set
            {
                action = value;
            }
        }
        public ToolStripEventArgs(ToolStripAction action)
        {
            this.action = action;
        }
    }
}
