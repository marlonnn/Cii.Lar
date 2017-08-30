using Cii.Lar.DrawTools;
using Cii.Lar.UI;
using System;
using System.Collections.Generic;
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

        public ExpManager()
        {

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
        /// <param name="sender"></param>
        /// <param name="isDoubleClick"></param>
        public void SetMeasureTool(object sender, bool isDoubleClick)
        {
            ToolStripItem item = sender as ToolStripItem;
            MeasureTools measureTool = (MeasureTools)item.Tag;
            SetMeasureTool(measureTool);
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
