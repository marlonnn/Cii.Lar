using Cii.Lar.DrawTools;
using Cii.Lar.Laser;
using Cii.Lar.SysClass;
using Cii.Lar.UI;
using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cii.Lar.ExpClass
{
    public enum LaserType
    {
        SaturnFixed,
        SaturnActive,
        Alignment
    }
    /// <summary>
    /// ExpManager to set measure tool to scalable picture box
    /// Author:Zhong Wen 2017/07/28
    /// </summary>
    public class ExpManager
    {
        private ZWPictureBox pictureBox;

        public ZWPictureBox ZWPictureBox
        {
            get
            {
                return this.pictureBox;
            }
            set
            {
                pictureBox = value;
            }
        }

        private LaserType laserType;

        public LaserType LaserType
        {
            get { return this.laserType; }
            set
            {
                if (value != this.laserType)
                {
                    laserType = value;
                    //CreateLaser(value);
                    LaserFactory.GetInstance(this.pictureBox).SetLaserByType(value);
                }
            }
        }

        private FilesForm filesForm;

        public ExpManager()
        {
            LaserType = LaserType.SaturnFixed;
        }

        public void StripButtonClickHandler(object sender, ToolStripEventArgs e)
        {
            switch (e.Action)
            {
                case ToolStripAction.Capture:
                    this.ZWPictureBox.LaserFunction = false;
                    CaptureImage();
                    break;
                case ToolStripAction.Video:
                    this.ZWPictureBox.LaserFunction = false;
                    break;
                case ToolStripAction.Archive:
                    this.ZWPictureBox.LaserFunction = false;
                    filesForm = new FilesForm();
                    filesForm.ShowDialog();
                    break;
                case ToolStripAction.ZoomOut:
                    this.ZWPictureBox.LaserFunction = false;
                    this.ZWPictureBox.ZoonOut();
                    break;
                case ToolStripAction.ZoomIn:
                    this.ZWPictureBox.LaserFunction = false;
                    this.ZWPictureBox.ZoomIn();
                    break;
                case ToolStripAction.ZoomFit:
                    this.ZWPictureBox.LaserFunction = false;
                    this.ZWPictureBox.ZoomFit();
                    break;
                case ToolStripAction.Scale:
                    this.ZWPictureBox.LaserFunction = false;
                    ToolStripButton toolStripButton = sender as ToolStripButton;
                    toolStripButton.Checked = !toolStripButton.Checked;
                    this.ZWPictureBox.Rulers.ShowRulers = toolStripButton.Checked;
                    this.ZWPictureBox.Invalidate();
                    break;
                case ToolStripAction.Line:
                case ToolStripAction.Rectangle:
                case ToolStripAction.Ellipse:
                case ToolStripAction.Polygon:
                    this.ZWPictureBox.LaserFunction = false;
                    SetMeasureTool(e.Action, false);
                    this.ZWPictureBox.ShowBaseCtrl(true, 2);
                    this.ZWPictureBox.Invalidate();
                    break;
                case ToolStripAction.Move:
                    SetMeasureTool(e.Action, false);
                    break;
                case ToolStripAction.Laser:
                    this.ZWPictureBox.LaserFunction = true;
                    this.ZWPictureBox.ShowBaseCtrl(true, 0);
                    this.ZWPictureBox.GraphicsList.DeleteAll();
                    this.ZWPictureBox.Invalidate();
                    break;
                case ToolStripAction.Setting:
                    this.ZWPictureBox.LaserFunction = false;
                    this.ZWPictureBox.ShowBaseCtrl(true, 4);
                    break;
                case ToolStripAction.OpenFile:
                    this.ZWPictureBox.LaserFunction = false;
                    OpenFile();
                    break;
            }
        }

        private void CaptureImage()
        {
            try
            {
                using (Bitmap bitmap = new Bitmap(this.ZWPictureBox.Image))
                {
                    string fileName = string.Format("{0}\\{1}.png", SysConfig.GetSysConfig().StorePath, DateTime.Now.ToString("yyyyMMddHHmmsss"));
                    bitmap.Save(fileName);
                    ShowToastNotification();
                }
            }
            catch (Exception e)
            {
                LogHelper.GetLogger<MainForm>().Error(e.Message);
                LogHelper.GetLogger<MainForm>().Error(e.StackTrace);
            }
        }

        private void ShowToastNotification()
        {
            ToastNotification.Show(this.ZWPictureBox, "Screenshot success",
                global::Cii.Lar.Properties.Resources.capture, 1000, eToastGlowColor.Blue,
                eToastPosition.MiddleCenter);
        }

        private void OpenFile()
        {
            try
            {
                string strFilter = "All file (*.*)|*.*|JPEG File Interchange Format (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphics (*.png)|*.png|Tiff Format(*.tiff)|*.tiff|Graphics Interchange Format (*.gif)|*.gif";
                System.Windows.Forms.OpenFileDialog OpenImageDialog = new System.Windows.Forms.OpenFileDialog();
                OpenImageDialog.Filter = strFilter;
                OpenImageDialog.InitialDirectory = string.Format("{0}\\Resources\\Simulator", System.Environment.CurrentDirectory);
                OpenImageDialog.ShowDialog();
                if (OpenImageDialog.FileName.Length > 0)
                {
                    this.ZWPictureBox.LoadImage(OpenImageDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<MainForm>().Error(ex.Message);
                LogHelper.GetLogger<MainForm>().Error(ex.StackTrace);
            }
        }
        public int GetNextDrawObjectID()
        {
            List<int> objectIDs = new List<int>();
            foreach (DrawObject o in ZWPictureBox.GraphicsList)
            {
                if (o is DrawCircle)
                {
                    continue;
                }
                objectIDs.Add(o.ID);
            }
            objectIDs.Sort();
            // find the id that larger than previous id plus one
            for (int i = 1; i < objectIDs.Count; i++)
                if (objectIDs[i] > objectIDs[i - 1] + 1) return objectIDs[i - 1] + 1;

            return objectIDs.LastOrDefault() + 1;
        }

        /// <summary>
        /// set cursor shape when click toolstrip button
        /// </summary>
        /// <param name="action"></param>
        /// <param name="isDoubleClick"></param>
        public void SetMeasureTool(ToolStripAction action, bool isDoubleClick)
        {
            SetMeasureTool(action);
        }

        public void SetMeasureTool(ToolStripAction action)
        {
            switch (action)
            {
                case ToolStripAction.Line:
                    CommandLine();
                    break;
                case ToolStripAction.Rectangle:
                    CommandRectangle();
                    break;
                case ToolStripAction.Ellipse:
                    CommandEllipse();
                    break;
                case ToolStripAction.Polygon:
                    CommandPolyLine();
                    break;
                case ToolStripAction.Laser:
                    if (LaserType == LaserType.SaturnFixed)
                    {
                        CommandCircle();
                    }
                    else if (LaserType == LaserType.SaturnActive)
                    {
                        CommandMultipleCircle();
                    }
                    break;
                case ToolStripAction.Move:
                    CommandMove();
                    break;
                default:
                    CommandPointer();
                    break;
            }
        }

        /// <summary>
        /// set cursor shape according to different measure tool
        /// </summary>
        /// <param name="measureTool"></param>
        public void SetMeasureTool(MeasureTools measureTool)
        {
            if (measureTool == MeasureTools.Line)
            {
                CommandLine();
            }
            else if (measureTool == MeasureTools.Rectangular)
            {
                CommandRectangle();
            }
            else if (measureTool == MeasureTools.Elliptical)
            {
                CommandEllipse();
            }
            else if (measureTool == MeasureTools.Polygon)
            {
                CommandPolyLine();
            }
            else if (measureTool == MeasureTools.Circle)
            {
                CommandCircle();
            }
            else
            {
                CommandPointer();
            }
        }

        /// <summary>
        /// draw line shape graphics
        /// </summary>
        private void CommandLine()
        {
            this.pictureBox.ActiveTool = DrawToolType.Line;
        }

        /// <summary>
        /// draw rectangle shape graphics
        /// </summary>
        private void CommandRectangle()
        {
            this.pictureBox.ActiveTool = DrawToolType.Rectangle;
        }

        /// <summary>
        /// draw ellipse shape graphics
        /// </summary>
        private void CommandEllipse()
        {
            this.pictureBox.ActiveTool = DrawToolType.Ellipse;
        }

        /// <summary>
        /// draw poly line shape graphics
        /// </summary>
        private void CommandPolyLine()
        {
            this.pictureBox.ActiveTool = DrawToolType.PolyLine;
        }

        private void CommandPointer()
        {
            this.pictureBox.ActiveTool = DrawToolType.Pointer;
        }

        /// <summary>
        /// draw circle shape graphics
        /// </summary>
        private void CommandCircle()
        {
            this.pictureBox.ActiveTool = DrawToolType.Circle;
        }

        private void CommandMultipleCircle()
        {
            this.pictureBox.ActiveTool = DrawToolType.MultipleCircle;
        }

        private void CommandMove()
        {
            this.pictureBox.ActiveTool = DrawToolType.Move;
        }
    }
}
