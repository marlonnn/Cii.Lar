using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar.ExpClass
{
    public class ReportPage
    {
        private List<ReportItemBase> reportItems;

        public List<ReportItemBase> ReportItems
        {
            get
            {
                return reportItems;
            }
            set
            {
                reportItems = value;
            }
        }

        public ReportPage()
        {
            reportItems = new List<ReportItemBase>();
        }
    }
}
