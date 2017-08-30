using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar.DrawTools
{
    public enum enUniMis
    {
        um = 0,
        mm = 1,
        inches = 2,
        dmm = 3,
        meters = 4
    }

    public class MeasureSystem
    {
        public static event MeasureUnitChangedEventHandler MeasureUnitChanged;
        public delegate void MeasureUnitChangedEventHandler(enUniMis NewUnit);

        private enUniMis myUserUnit;
        public enUniMis UserUnit
        {
            get { return myUserUnit; }
            set
            {
                if ((value == enUniMis.dmm) | (value == enUniMis.inches) | (value == enUniMis.um) | (value == enUniMis.mm) | (value == enUniMis.meters))
                {
                    if (myUserUnit != value)
                    {
                        myUserUnit = value;
                        MeasureUnitChanged?.Invoke(myUserUnit);
                    }
                }
            }
        }

        public MeasureSystem()
        {
            try
            {
                UserUnit = enUniMis.mm;
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<MeasureSystem>().Error(ex.Message);
                LogHelper.GetLogger<MeasureSystem>().Error(ex.StackTrace);
            }
        }


    }
}
