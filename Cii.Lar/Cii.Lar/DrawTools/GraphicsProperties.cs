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
                penWidth = value;
            }
        }

        public GraphicsProperties()
        {
            color = System.Drawing.Color.WhiteSmoke;
            penWidth = 1;
        }
    }
}
