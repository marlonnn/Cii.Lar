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
using Cii.Lar.SysClass;

namespace Cii.Lar.UI
{
    public partial class ControlCtrl : BaseCtrl
    {
        public delegate void StripButtonClick(object sender, ToolStripEventArgs e);
        public StripButtonClick StripButtonClickHandler;

        public void UpdateLenseHandler(Lense lense)
        {
            comboBoxLense.Items.Clear();
            comboBoxLense.Items.AddRange(SysConfig.GetSysConfig().Lenses.ToArray());
            int index = SysConfig.GetSysConfig().Lenses.FindIndex(l => (l.ToString() == lense.ToString()));
            comboBoxLense.SelectedIndex = index;
        }

        private ZWPictureBox pictureBox;
        public ZWPictureBox PictureBox
        {
            get
            {
                return pictureBox;
            }
            set
            {
                pictureBox = value;
            }
        }

        public ControlCtrl() : base()
        {
            resources = new ComponentResourceManager(typeof(ControlCtrl));
            InitializeComponent();
            InitializeToolStrip();
            InitializeLenses();
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
            toolStripButtonMove.Tag = ToolStripAction.Move;
            toolStripButtonLaser.Tag = ToolStripAction.Laser;
            toolStripButtonSetting.Tag = ToolStripAction.Setting;
            toolStripButtonOpen.Tag = ToolStripAction.OpenFile;
        }

        private void InitializeLenses()
        {
            List<Lense> lenses = SysConfig.GetSysConfig().Lenses;
            if (lenses != null && lenses.Count > 0)
            {
                comboBoxLense.Items.AddRange(lenses.ToArray());
                comboBoxLense.SelectedIndex = 0;
            }
        }

        private void toolStripButtonClick(object sender, EventArgs e)
        {
            ToolStripButton toolStripButton = sender as ToolStripButton;
            ToolStripAction action = (ToolStripAction)toolStripButton.Tag;
            StripButtonClickHandler?.Invoke(sender, new ToolStripEventArgs(action));
            RefreshButtonState();
        }

        private void RefreshButtonState()
        {
            toolStripButtonScale.Checked = this.pictureBox.Rulers.ShowRulers;
        }

        private void btnMenuItem_Click(object sender, EventArgs e)
        {
            if (object.ReferenceEquals(sender, btnDmm))
            {
                Program.ExpManager.ZWPictureBox.UnitOfMeasure = enUniMis.dmm;
            }
            else if (object.ReferenceEquals(sender, btnInches))
            {
                Program.ExpManager.ZWPictureBox.UnitOfMeasure = enUniMis.inches;
            }
            else if (object.ReferenceEquals(sender, btnMeters))
            {
                Program.ExpManager.ZWPictureBox.UnitOfMeasure = enUniMis.meters;
            }
            else if (object.ReferenceEquals(sender, btnMm))
            {
                Program.ExpManager.ZWPictureBox.UnitOfMeasure = enUniMis.mm;
            }
            else if (object.ReferenceEquals(sender, btnUm))
            {
                Program.ExpManager.ZWPictureBox.UnitOfMeasure = enUniMis.um;
            }
            else if (object.ReferenceEquals(sender, btnCm))
            {
                Program.ExpManager.ZWPictureBox.UnitOfMeasure = enUniMis.cm;
            }
            RefreshChechStates(sender);
        }

        private void RefreshChechStates(object sender)
        {
            btnDmm.Checked = false;
            btnInches.Checked = false;
            btnMeters.Checked = false;
            btnUm.Checked = false;
            btnMm.Checked = false;
            btnCm.Checked = false;
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                item.Checked = true;
            }
        }

        public void RefreshUI()
        {
            foreach (var item in this.toolStrip1.Items)
            {
                ToolStripButton tsb = item as ToolStripButton;
                if (tsb != null)
                {
                    resources.ApplyResources(tsb, tsb.Name);
                }
                ToolStripDropDownButton tsbdd = item as ToolStripDropDownButton;
                if (tsbdd != null)
                {
                    resources.ApplyResources(tsbdd, tsbdd.Name);
                    foreach (var dropItem in tsbdd.DropDownItems)
                    {
                        ToolStripMenuItem tsmi = dropItem as ToolStripMenuItem;
                        if (tsmi != null)
                        {
                            resources.ApplyResources(tsmi, tsmi.Name);
                        }
                    }
                }
            }
        }
    }
}
