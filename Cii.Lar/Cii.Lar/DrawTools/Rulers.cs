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

        public void Draw(Graphics g)
        {
            using (Pen pen = new Pen(GraphicsPropertiesManager.GetPropertiesByName("Ruler").Color,
                GraphicsPropertiesManager.GetPropertiesByName("Ruler").PenWidth))
            {
                g.ResetTransform();
                DrawHorizontalRuler(g, pen);
                DrawVerticalRuler(g, pen);
            }
        }

        private float rulerStep = 50;

        public float RulerStep
        {
            get
            {
                return rulerStep * pictureBox.Zoom;
            }
            set
            {
                if (value != rulerStep)
                {
                    rulerStep = value;
                }
            }
        }
        
        /// <summary>
        /// draw hotizontal ruler
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        public void DrawHorizontalRuler(Graphics g, Pen pen)
        {
            float x1Coord = pictureBox.Width / 2;
            float x2Coord = pictureBox.Width / 2;
            for ( ; x1Coord < pictureBox.Width; x1Coord += RulerStep)
            {
                //1.X > 0
                g.DrawLine(pen, x1Coord, pictureBox.Height / 2 - 10, x1Coord, pictureBox.Height / 2);
                g.DrawLine(pen, x1Coord + RulerStep / 2, pictureBox.Height / 2 - 5, x1Coord + RulerStep / 2, pictureBox.Height / 2);

                //2.X < 0
                g.DrawLine(pen, x2Coord, pictureBox.Height / 2 - 10, x2Coord, pictureBox.Height / 2);
                g.DrawLine(pen, x2Coord + RulerStep / 2, pictureBox.Height / 2 - 5, x2Coord + RulerStep / 2, pictureBox.Height / 2);
                x2Coord -= RulerStep;
            }

            g.DrawLine(pen, 0, pictureBox.Height / 2, pictureBox.Width, pictureBox.Height / 2);
        }

        /// <summary>
        /// draw vertical ruler
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        public void DrawVerticalRuler(Graphics g, Pen pen)
        {
            float y1Coord = pictureBox.Height / 2;
            float y2Coord = pictureBox.Height / 2;
            for ( ; y1Coord < pictureBox.Height; y1Coord += RulerStep)
            {
                //1.Y > 0
                g.DrawLine(pen, pictureBox.Width / 2 - 10, y1Coord, pictureBox.Width / 2, y1Coord);
                g.DrawLine(pen, pictureBox.Width / 2 - 5, y1Coord + RulerStep / 2, pictureBox.Width / 2, y1Coord + RulerStep / 2);

                g.DrawLine(pen, pictureBox.Width / 2 - 10, y2Coord, pictureBox.Width / 2, y2Coord);
                g.DrawLine(pen, pictureBox.Width / 2 - 5, y2Coord + RulerStep / 2, pictureBox.Width / 2, y2Coord + RulerStep / 2);
                y2Coord -= RulerStep;
            }
            g.DrawLine(pen, pictureBox.Width / 2, 0, pictureBox.Width / 2, pictureBox.Height);
        }
    }
}
