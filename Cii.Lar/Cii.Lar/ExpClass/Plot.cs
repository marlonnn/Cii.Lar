using Cii.Lar.DrawTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar.ExpClass
{
    public partial class Plot
    {
        private GraphicsList _drawObjects;
        /// <summary>
        /// draw objects defined inside this plot
        /// </summary>
        public GraphicsList DrawObjects
        {
            get { return _drawObjects; }
            private set { _drawObjects = value; }
        }
    }
}
