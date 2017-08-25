using Cii.Lar.UI;
using Cii.Lar.UI.Picture;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cii.Lar.DrawTools
{
    public class ToolPolyLine : ToolObject
    {
        private DrawPolyLine newPolyLine;
        /// <summary>
        /// used for double click to end drawing polygon gate when in Continuous mode
        /// </summary>
        private bool cancelNewFlag = false;
        public ToolPolyLine()
        {
        }

        public override void OnMouseDown(ZoomblePictureBoxControl pictureBox, MouseEventArgs e)
        {
            // operations are done in OnMouseUp
        }

        public override void OnMouseUp(ZoomblePictureBoxControl pictureBox, MouseEventArgs e)
        {
            if (cancelNewFlag)
            {
                cancelNewFlag = false;
                return;
            }

            // if new object creation is canceled
            if (!pictureBox.CreatingDrawObject && newPolyLine != null)
            {
                return;
            }

            if (newPolyLine == null)
            {
                newPolyLine = new DrawPolyLine(pictureBox, e.X, e.Y, e.X + 1, e.Y + 1);
                AddNewObject(pictureBox, newPolyLine);
            }
            else
            {
                // polygon gate should have at least 3 points
                if (newPolyLine.CloseToFirstPoint(e.Location) && newPolyLine.PointCount > 3)
                {
                    newPolyLine.RemovePointAt(newPolyLine.PointCount - 1); // remove the last added point, it is closed to first
                    EndCreating(pictureBox);
                    return;
                }
                // Drawing is in process, so simply add a new point
                newPolyLine.AddPoint(pictureBox, e.Location, true);
            }
        }

        public override void OnMouseMove(ZoomblePictureBoxControl pictureBox, MouseEventArgs e)
        {
            // if new object creation is canceled
            if (!pictureBox.CreatingDrawObject) return;

            if (newPolyLine == null)
                return; // precaution

            Point point = new Point(e.X, e.Y);
            // move last point
            newPolyLine.MoveLastHandleTo(pictureBox, point);
        }

        public override void OnMouseLeave(ZoomblePictureBoxControl pictureBox, System.EventArgs e)
        {
        }

        public override void OnCancel(ZoomblePictureBoxControl pictureBox, bool cancelSelection)
        {
            base.OnCancel(pictureBox, cancelSelection);

            newPolyLine = null;
        }

        /// <summary>
        /// Mouse button is double clicked
        /// New Polyline is created and resized.
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="e"></param>
        public override void OnDoubleClick(ZoomblePictureBoxControl pictureBox, MouseEventArgs e)
        {
            if (newPolyLine == null)
                return;

            newPolyLine.RemovePointAt(newPolyLine.PointCount - 1); // remove the last added point, it is duplicated
            // polygon gate should have at least 3 points
            if (newPolyLine.PointCount < 3)
                return;

            EndCreating(pictureBox);

            // there is a mouse up event after double click event when in Continuous mode
            cancelNewFlag = true;

            pictureBox.GraphicsList[0].UpdateStatisticsInformation();
        }

        private void EndCreating(ZoomblePictureBoxControl pictureBox)
        {
            newPolyLine.Creating = false;
            newPolyLine = null;
        }
    }
}
