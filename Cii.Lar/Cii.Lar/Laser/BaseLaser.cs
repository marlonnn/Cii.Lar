using Cii.Lar.DrawTools;
using Cii.Lar.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cii.Lar.Laser
{
    public class BaseLaser
    {
        protected ZWPictureBox pictureBox;
        /// <summary>
        /// GraphicsProperties of this draw object 
        /// </summary>
        private GraphicsProperties graphicsProperties;
        public GraphicsProperties GraphicsProperties
        {
            get
            {
                return graphicsProperties;
            }
            set
            {
                graphicsProperties = value;
            }
        }

        /// <summary>
        /// GraphicsPropertiesManager: include all the draw object graphics properties
        /// </summary>
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

        protected SolidBrush brush;

        public BaseLaser()
        {
            InitializeGraphicsProperties();
        }

        private void InitializeGraphicsProperties()
        {
            this.GraphicsProperties = GraphicsPropertiesManager.GetPropertiesByName("Circle");
            this.GraphicsProperties.Color = Color.Yellow;
        }

        /// <summary>
        /// Left nous button is pressed
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="e"></param>
        public virtual void OnMouseDown(ZWPictureBox pictureBox, MouseEventArgs e)
        {
        }

        /// <summary>
        /// Mouse is moved, left mouse button is pressed or none button is pressed
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="e"></param>
        public virtual void OnMouseMove(ZWPictureBox pictureBox, MouseEventArgs e)
        {
        }

        /// <summary>
        /// Left mouse button is released
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="e"></param>
        public virtual void OnMouseUp(ZWPictureBox pictureBox, MouseEventArgs e)
        {
        }

        public virtual void OnPaint(PaintEventArgs e)
        {

        }
    }
}
