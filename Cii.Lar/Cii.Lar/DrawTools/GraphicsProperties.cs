using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar.DrawTools
{
    /// <summary>
    /// Graphics property
    /// Author:Zhong Wen 2017/07/25
    /// </summary>
    public class GraphicsProperties
    {
        private string graphicsName;
        public string GraphicsName
        {
            get
            {
                return graphicsName;
            }
            set
            {
                graphicsName = value;
            }
        }

        private Color color;
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
        private int penWidth;
        public int PenWidth
        {
            get
            {
                return penWidth;
            }
            set
            {
                if (value != penWidth)
                {
                    penWidth = value;
                }
            }
        }

        /// <summary>
        /// set color transparency
        /// </summary>
        private int alpha;

        public int Alpha
        {
            get
            {
                return this.alpha;
            }
            set
            {
                if (value != this.alpha)
                {
                    this.alpha = value;
                    color = Color.FromArgb(value, this.color);
                }
            }
        }

        public GraphicsProperties(string name)
        {
            color = Color.White;
            penWidth = 1;
            graphicsName = name;
        }
    }
}
