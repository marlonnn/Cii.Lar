using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cii.Lar.UI.Picture;
using static Cii.Lar.UI.Picture.PublicTypes;
using Cii.Lar.SysClass;
using DevComponents.DotNetBar;

namespace Cii.Lar.UI
{
    /// <summary>
    /// Tool bar control
    /// Author: Zhong Wen 2017/08/24
    /// </summary>
    public partial class ToolbarControl : UserControl
    {
        public delegate void ShowBaseCtrl(string controlName);
        public ShowBaseCtrl ShowBaseCtrlHandler;

        private ZoomblePictureBoxControl myZRGPictureBox;
        private FilesForm filesForm;

        public ZoomblePictureBoxControl LinkedPictureBox
        {
            get { return myZRGPictureBox; }
            set
            {
                myZRGPictureBox = value;
                RefreshDisplayButtonState();
            }
        }

        private void RefreshDisplayButtonState()
        {
            try
            {
                if (LinkedPictureBox != null)
                {
                    btViewRulers.Checked = LinkedPictureBox.ShowRulers;
                    btViewScrollBars.Checked = LinkedPictureBox.ShowScrollbars;
                    btViewGrid.Checked = LinkedPictureBox.ShowGrid;
                    btUmDmm.Checked = false;
                    btUmInch.Checked = false;
                    btUmMeters.Checked = false;
                    btUmMicron.Checked = false;
                    btUmMillimeters.Checked = false;
                    switch (LinkedPictureBox.UnitOfMeasure)
                    {
                        case MeasureSystem.enUniMis.dmm:
                            btUmDmm.Checked = true;
                            break;
                        case MeasureSystem.enUniMis.inches:
                            btUmInch.Checked = true;
                            break;
                        case MeasureSystem.enUniMis.meters:
                            btUmMeters.Checked = true;
                            break;
                        case MeasureSystem.enUniMis.micron:
                            btUmMicron.Checked = true;
                            break;
                        case MeasureSystem.enUniMis.mm:
                            btUmMillimeters.Checked = true;
                            break;
                    }
                    switch (LinkedPictureBox.ClickAction)
                    {
                        case enClickAction.MeasureDistance:
                            btZoom.Checked = false;
                            break;
                        case enClickAction.Zoom:
                            btZoom.Checked = true;
                            break;
                        default:
                            btZoom.Checked = true;
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                LogHelper.GetLogger<ToolbarControl>().Error(e.Message);
                LogHelper.GetLogger<ToolbarControl>().Error(e.StackTrace);
            }
        }
        public ToolbarControl()
        {
            InitializeComponent();
            this.btLoad.Click += btLoad_Click;
            this.btZoom.Click += btZoom_Click;
            this.btMeasure.Click += btMeasure_Click;
            this.btZoomFit.Click += btZoomFit_Click;
        }
        private void btMeasure_Click(object sender, EventArgs e)
        {
            try
            {
                if (LinkedPictureBox != null)
                {
                    LinkedPictureBox.ClickAction = enClickAction.MeasureDistance;
                    RefreshDisplayButtonState();
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ToolbarControl>().Error(ex.Message);
                LogHelper.GetLogger<ToolbarControl>().Error(ex.StackTrace);
            }
        }

        private void btUmMicron_Click(object sender, EventArgs e)
        {
            try
            {
                if (LinkedPictureBox == null)
                    return;

                if (object.ReferenceEquals(sender, btUmDmm))
                {
                    LinkedPictureBox.UnitOfMeasure = MeasureSystem.enUniMis.dmm;
                }
                else if (object.ReferenceEquals(sender, btUmInch))
                {
                    LinkedPictureBox.UnitOfMeasure = MeasureSystem.enUniMis.inches;
                }
                else if (object.ReferenceEquals(sender, btUmMeters))
                {
                    LinkedPictureBox.UnitOfMeasure = MeasureSystem.enUniMis.meters;
                }
                else if (object.ReferenceEquals(sender, btUmMicron))
                {
                    LinkedPictureBox.UnitOfMeasure = MeasureSystem.enUniMis.micron;
                }
                else if (object.ReferenceEquals(sender, btUmMillimeters))
                {
                    LinkedPictureBox.UnitOfMeasure = MeasureSystem.enUniMis.mm;
                }
                LinkedPictureBox.Redraw();
                RefreshDisplayButtonState();
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ToolbarControl>().Error(ex.Message);
                LogHelper.GetLogger<ToolbarControl>().Error(ex.StackTrace);
            }
        }

        private void btSreenShort_Click(object sender, EventArgs e)
        {
            CaptureImage();
        }

        private void CaptureImage()
        {
            try
            {
                if (this.LinkedPictureBox.Image != null)
                {
                    string fileName = string.Format("{0}\\{1}.png", SysConfig.GetSysConfig().StorePath, DateTime.Now.ToString("yyyyMMddHHmmsss"));
                    this.LinkedPictureBox.Image.Save(fileName);
                    ShowToastNotification();
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ToolbarControl>().Error(ex.Message);
                LogHelper.GetLogger<ToolbarControl>().Error(ex.StackTrace);
            }
        }

        private void ShowToastNotification()
        {
            ToastNotification.Show(this, "Screenshot success",
                global::Cii.Lar.Properties.Resources.capture, 1000, eToastGlowColor.Blue,
                eToastPosition.MiddleCenter);
        }

        private void btVideo_Click(object sender, EventArgs e)
        {

        }

        private void btFiles_Click(object sender, EventArgs e)
        {
            filesForm = new FilesForm();
            filesForm.ShowDialog();
        }

        #region Draw & measure tools 
        private void drawTool_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                btLine.Checked = false;
                btRectangle.Checked = false;
                btEllipse.Checked = false;
                btPloygon.Checked = false;
                switch (item.Text)
                {
                    case "Line":
                        btLine.Checked = true;
                        break;
                    case "Rectangle":
                        btRectangle.Checked = true;
                        break;
                    case "Ellipse":
                        btEllipse.Checked = true;
                        break;
                    case "Ploygon":
                        btPloygon.Checked = true;
                        break;
                }
                ShowBaseCtrlHandler?.Invoke("DrawTool");
            }
        }
        #endregion

        #region Show rulers、ScrollBars or Grid
        private void btViewRulers_Click(object sender, EventArgs e)
        {
            try
            {
                if (LinkedPictureBox != null)
                {
                    btViewRulers.Checked = !(btViewRulers.Checked);
                    LinkedPictureBox.ShowRulers = btViewRulers.Checked;
                    LinkedPictureBox.Redraw();
                    RefreshDisplayButtonState();
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ToolbarControl>().Error(ex.Message);
                LogHelper.GetLogger<ToolbarControl>().Error(ex.StackTrace);
                //Interaction.MsgBox(ex.Message);
            }
        }

        private void btViewScrollBars_Click(object sender, EventArgs e)
        {
            try
            {
                if (LinkedPictureBox != null)
                {
                    btViewScrollBars.Checked = !(btViewScrollBars.Checked);
                    LinkedPictureBox.ShowScrollbars = btViewScrollBars.Checked;
                    LinkedPictureBox.Redraw();
                    RefreshDisplayButtonState();
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ToolbarControl>().Error(ex.Message);
                LogHelper.GetLogger<ToolbarControl>().Error(ex.StackTrace);
            }
        }

        private void btViewGrid_Click(object sender, EventArgs e)
        {
            try
            {
                if (LinkedPictureBox != null)
                {
                    btViewGrid.Checked = !(btViewGrid.Checked);
                    LinkedPictureBox.ShowGrid = btViewGrid.Checked;
                    LinkedPictureBox.Redraw();
                    RefreshDisplayButtonState();
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ToolbarControl>().Error(ex.Message);
                LogHelper.GetLogger<ToolbarControl>().Error(ex.StackTrace);
            }
        }
        #endregion

        private void btZoom_Click(object sender, EventArgs e)
        {
            try
            {
                if (LinkedPictureBox != null)
                {
                    LinkedPictureBox.ClickAction = enClickAction.Zoom;
                    RefreshDisplayButtonState();
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ToolbarControl>().Error(ex.Message);
                LogHelper.GetLogger<ToolbarControl>().Error(ex.StackTrace);
            }
        }

        private void btZoomFit_Click(object sender, EventArgs e)
        {
            try
            {
                if (LinkedPictureBox != null)
                {
                    LinkedPictureBox.ZoomToFit();
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ToolbarControl>().Error(ex.Message);
                LogHelper.GetLogger<ToolbarControl>().Error(ex.StackTrace);
            }
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog OpenImageDialog = new System.Windows.Forms.OpenFileDialog();
                OpenImageDialog.Filter = "All file (*.*)|*.*|JPEG File Interchange Format (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphics (*.png)|*.png|Tiff Format(*.tiff)|*.tiff|Graphics Interchange Format (*.gif)|*.gif";
                OpenImageDialog.ShowDialog();
                if (OpenImageDialog.FileName.Length > 0)
                {
                    LinkedPictureBox.Image = Image.FromFile(OpenImageDialog.FileName);
                    LinkedPictureBox.ZoomToDefaultRect();
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<ToolbarControl>().Error(ex.Message);
                LogHelper.GetLogger<ToolbarControl>().Error(ex.StackTrace);
            }
        }
    }
}
