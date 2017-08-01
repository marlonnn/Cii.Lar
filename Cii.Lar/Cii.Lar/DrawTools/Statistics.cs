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
        private float circumference;

        public float Circumference
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

        private float area;

        public float Area
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
    }
}
