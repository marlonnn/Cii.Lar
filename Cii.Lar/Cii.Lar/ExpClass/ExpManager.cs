using Cii.Lar.DrawTools;
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
    /// <summary>
    /// ExpManager to set measure tool to scalable picture box
    /// Author:Zhong Wen 2017/07/28
    /// </summary>
    public class ExpManager
    {
        private ScalablePictureBox scalablePictureBox;

        public ScalablePictureBox ScalablePictureBox
        {
            get
            {
                return this.scalablePictureBox;
            }
            set
            {
                scalablePictureBox = value;
            }
        }

        private FilesForm filesForm;

        public ExpManager()
        {

        }

        public void StripButtonClickHandler(object sender, ToolStripEventArgs e)
        {
            switch (e.Action)
            {
                case ToolStripAction.Capture:
                    CaptureImage();
                    break;
                case ToolStripAction.Video:
                    break;
                case ToolStripAction.Archive:
                    filesForm = new FilesForm();
                    filesForm.ShowDialog();
                    break;
                case ToolStripAction.ZoomOut:
                    break;
                case ToolStripAction.ZoomIn:
                    break;
                case ToolStripAction.ZoomFit:
                    break;
                case ToolStripAction.Scale:
                    break;
                case ToolStripAction.Line:
                case ToolStripAction.Rectangle:
                case ToolStripAction.Ellipse:
                case ToolStripAction.Polygon:
                    SetMeasureTool(e.Action, false);
                    this.ScalablePictureBox.ShowBaseCtrl(true, 2);
                    break;
                case ToolStripAction.Laser:
                    SetMeasureTool(e.Action, false);
                    this.ScalablePictureBox.ShowBaseCtrl(true, 0);
                    break;
                case ToolStripAction.Setting:
                    this.ScalablePictureBox.ShowBaseCtrl(true, 4);
                    break;
                case ToolStripAction.OpenFile:
                    OpenFile();
                    break;
            }
        }

        private void CaptureImage()
        {
            try
            {
                using (Bitmap bitmap = new Bitmap(this.ScalablePictureBox.PictureBox.Image))
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
            ToastNotification.Show(this.ScalablePictureBox, "Screenshot success",
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
                OpenImageDialog.ShowDialog();
                if (OpenImageDialog.FileName.Length > 0)
                {
                    this.ScalablePictureBox.Picture = new Bitmap(OpenImageDialog.FileName);
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
            foreach (DrawObject o in ScalablePictureBox.GraphicsList)
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
                    CommandCircle();
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
            this.scalablePictureBox.ActiveTool = DrawToolType.Line;
        }

        /// <summary>
        /// draw rectangle shape graphics
        /// </summary>
        private void CommandRectangle()
        {
            this.scalablePictureBox.ActiveTool = DrawToolType.Rectangle;
        }

        /// <summary>
        /// draw ellipse shape graphics
        /// </summary>
        private void CommandEllipse()
        {
            this.scalablePictureBox.ActiveTool = DrawToolType.Ellipse;
        }

        /// <summary>
        /// draw poly line shape graphics
        /// </summary>
        private void CommandPolyLine()
        {
            this.scalablePictureBox.ActiveTool = DrawToolType.PolyLine;
        }

        private void CommandPointer()
        {
            this.scalablePictureBox.ActiveTool = DrawToolType.Pointer;
        }

        /// <summary>
        /// draw circle shape graphics
        /// </summary>
        private void CommandCircle()
        {
            this.scalablePictureBox.ActiveTool = DrawToolType.Circle;
        }
    }
}
