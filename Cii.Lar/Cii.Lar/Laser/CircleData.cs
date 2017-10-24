using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar.Laser
{
    /// <summary>
    /// Circle radius and center point
    /// </summary>
    public class CircleData
    {
        private double radius;
        public double Radius
        {
            get { return this.radius; }
            set { this.radius = value; }
        }
        private PointF centerPt;
        public PointF CenterPt
        {
            get { return this.centerPt; }
            set { this.centerPt = value; }
        }

        public CircleData()
        {
            radius = 0;
            centerPt = new PointF();
        }
    }
}
