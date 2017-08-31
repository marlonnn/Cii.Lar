using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cii.Lar.UI
{
    public partial class ControlCtrl : BaseCtrl
    {
        public delegate void StripButtonClick(object sender, ToolStripEventArgs e);
        public StripButtonClick StripButtonClickHandler;
        public ControlCtrl()
        {
            InitializeComponent();
            InitializeToolStrip();
        }

        private void InitializeToolStrip()
        {
            toolStripButtonCapture.Tag = ToolStripAction.Capture;
            toolStripButtonVideo.Tag = ToolStripAction.Video;
            toolStripFiles.Tag = ToolStripAction.Archive;
            toolStripButtonZoomOut.Tag = ToolStripAction.ZoomOut;
            toolStripButtonZoomIn.Tag = ToolStripAction.ZoomIn;
            toolStripButtonFit.Tag = ToolStripAction.ZoomFit;
            toolStripButtonScale.Tag = ToolStripAction.Scale;
            toolStripButtonLine.Tag = ToolStripAction.Line;
            toolStripButtonRectangle.Tag = ToolStripAction.Rectangle;
            toolStripButtonElliptical.Tag = ToolStripAction.Ellipse;
            toolStripButtonPolygon.Tag = ToolStripAction.Polygon;
            toolStripButtonLaser.Tag = ToolStripAction.Laser;
            toolStripButtonSetting.Tag = ToolStripAction.Setting;
            toolStripButtonOpen.Tag = ToolStripAction.OpenFile;
        }

        private void toolStripButtonClick(object sender, EventArgs e)
        {
            ToolStripButton toolStripButton = sender as ToolStripButton;
            ToolStripAction action = (ToolStripAction)toolStripButton.Tag;
            StripButtonClickHandler?.Invoke(sender, new ToolStripEventArgs(action));
        }
    }
}
