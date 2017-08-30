using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.Metro.ColorTables;
using DevComponents.DotNetBar;
using Cii.Lar.UI;
using Cii.Lar.SysClass;
using System.Drawing.Imaging;
using System.Linq;

namespace Cii.Lar
{
    public enum MeasureTools
    {
        Scale,
        Pointer,
        Line,
        Rectangular,
        Elliptical,
        Polygon,
        Circle
    }
    public partial class MainForm : DevComponents.DotNetBar.Office2007Form
    {
        private ComponentResourceManager resources;
        private SysConfig sysConfig;

        private int CurrentScalePercent = 100;
        private FilesForm filesForm;

        public MainForm()
        {
            IsMdiContainer = true;
            InitializeComponent();
            InitializeToolStrip();
            Program.ExpManager.ScalablePictureBox = this.scalablePictureBox;
            //this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            resources = new ComponentResourceManager(typeof(MainForm));
            sysConfig = SysConfig.GetSysConfig();
            this.Load += MainForm_Load;
        }

        private void InitializeToolStrip()
        {
            toolStripButtonScale.Tag = MeasureTools.Scale;
            toolStripButtonLine.Tag = MeasureTools.Line;
            toolStripButtonRectangle.Tag = MeasureTools.Rectangular;
            toolStripButtonElliptical.Tag = MeasureTools.Elliptical;
            toolStripButtonPolygon.Tag = MeasureTools.Polygon;
            toolStripButtonLaser.Tag = MeasureTools.Circle;
        }

        private void CaptureImage()
        {
            try
            {
                using (Bitmap bitmap = new Bitmap(this.scalablePictureBox.PictureBox.Image))
                {
                    string fileName = string.Format("{0}\\{1}.png", SysConfig.GetSysConfig().StorePath, DateTime.Now.ToString("yyyyMMddHHmmsss"));
                    bitmap.Save(fileName);
                    ShowToastNotification();
                }
            }
            catch (Exception e)
            {

            }
        }

        private void ShowToastNotification()
        {
            ToastNotification.Show(this, "Screenshot success", 
                global::Cii.Lar.Properties.Resources.capture, 1000, eToastGlowColor.Blue,
                eToastPosition.MiddleCenter);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //for test
            //string defaultImage = string.Format("{0}\\Resources\\1.bmp", System.Environment.CurrentDirectory);
            //this.scalablePictureBox.Picture = new Bitmap(defaultImage);
            this.ActiveControl = this.scalablePictureBox.PictureBox;

            sysConfig.PropertyChanged += MainForm_PropertyChanged;

        }

        private void MainForm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == sysConfig.GetPropertyName(() => sysConfig.UICulture))
            {
                sysConfig.RefreshUICulture(resources, this);
            }
        }

        private void ToolStripClickHandler(object sender, EventArgs e)
        {
            var toolStripButton = sender as ToolStripButton;
            switch (toolStripButton.Text)
            {
                case "toolStripButtonCapture":
                    CaptureImage();
                    break;
                case "toolStripFiles":
                    filesForm = new FilesForm();
                    filesForm.ShowDialog();
                    break;
                case "toolStripButtonZoomOut":
                    if (CurrentScalePercent == 60)
                    {
                        CurrentScalePercent = 100;
                    }
                    CurrentScalePercent -= 10;
                    this.scalablePictureBox.CurrentScalePercent = CurrentScalePercent;
                    break;
                case "toolStripButtonZoomIn":
                    if (CurrentScalePercent == 1500)
                    {
                        CurrentScalePercent = 100;
                    }
                    CurrentScalePercent += 10;
                    this.scalablePictureBox.CurrentScalePercent = CurrentScalePercent;
                    break;
                case "toolStripButtonSetting":
                    break;
            }
        }

        private void Fullscreen(bool fullscreen)
        {
            this.TopMost = fullscreen;
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Maximized;
                //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }

        private void toolStripButtonCapture_Click(object sender, EventArgs e)
        {
            CaptureImage();
        }

        private void toolStripButtonVideo_Click(object sender, EventArgs e)
        {

        }

        private void toolStripFiles_Click(object sender, EventArgs e)
        {
            filesForm = new FilesForm();
            filesForm.ShowDialog();
        }

        private void toolStripButtonZoomOut_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonZoomIn_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonScale_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_Click(object sender, EventArgs e)
        {
            Program.ExpManager.SetMeasureTool(sender, false);
            this.scalablePictureBox.ShowBaseCtrl(true, 2);
        }

        private void toolStripButtonLaser_Click(object sender, EventArgs e)
        {
            Program.ExpManager.SetMeasureTool(sender, false);
            this.scalablePictureBox.ShowBaseCtrl(true, 0);
        }

        private void toolStripButtonSetting_Click(object sender, EventArgs e)
        {
            this.scalablePictureBox.ShowBaseCtrl(true, 4);
        }

        private void MainForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && !e.Handled && this.scalablePictureBox.ActiveTool != DrawToolType.Pointer)
            {
                Program.ExpManager.SetMeasureTool(MeasureTools.Pointer);
                e.Handled = true;
            }
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                string strFilter = "All file (*.*)|*.*|JPEG File Interchange Format (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphics (*.png)|*.png|Tiff Format(*.tiff)|*.tiff|Graphics Interchange Format (*.gif)|*.gif";
                System.Windows.Forms.OpenFileDialog OpenImageDialog = new System.Windows.Forms.OpenFileDialog();
                OpenImageDialog.Filter = strFilter;
                OpenImageDialog.ShowDialog();
                if (OpenImageDialog.FileName.Length > 0)
                {
                    this.scalablePictureBox.Picture = new Bitmap(OpenImageDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<MainForm>().Error(ex.Message);
                LogHelper.GetLogger<MainForm>().Error(ex.StackTrace);
            }
        }
    }
}