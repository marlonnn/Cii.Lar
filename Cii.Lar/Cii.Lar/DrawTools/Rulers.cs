using Cii.Lar.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar.DrawTools
{
    /// <summary>
    /// Draw horizontal and vertical ruler
    /// Author: Zhong Wen 2017/08/31
    /// </summary>
    public class Rulers
    {
        private GraphicsPropertiesManager graphicsPropertiesManager = GraphicsPropertiesManager.GraphicsManagerSingleInstance();
        public GraphicsPropertiesManager GraphicsPropertiesManager
        {
            get
            {
                return graphicsPropertiesManager;
            }
            set
            {
                graphicsPropertiesManager = value;
            }
        }

        private ZWPictureBox pictureBox;

        public Rulers()
        {

        }

        public Rulers(ZWPictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
        }

        public void DrawHorizonRalRuler(Graphics g)
        {
            using (Pen pen = new Pen(GraphicsPropertiesManager.GetPropertiesByName("Ruler").Color,
                GraphicsPropertiesManager.GetPropertiesByName("Ruler").PenWidth))
            {
                g.DrawLine(pen, 0, pictureBox.Height / 2, pictureBox.Width, pictureBox.Height / 2);
            }
        }
    }
}
