using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar.DrawTools
{
    /// <summary>
    /// circumference and area statistics of graphic object
    /// Author:Zhong Wen 2017/07/31
    /// </summary>
    public class Statistics
    {
        private double circumference;

        public double Circumference
        {
            get
            {
                return circumference;
            }
            set
            {
                circumference = value;
            }
        }

        private double area;

        public double Area
        {
            get
            {
                return area;
            }
            set
            {
                area = value;
            }
        }

        public Statistics()
        {

        }

        public Statistics(double circumference, double area)
        {
            this.circumference = circumference;
            this.area = area;
        }
    }
}
