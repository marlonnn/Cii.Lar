using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar.UI.Picture
{
    public class MeasureSystem
    {
        public static event MeasureUnitChangedEventHandler MeasureUnitChanged;
        public delegate void MeasureUnitChangedEventHandler(enUniMis NewUnit);

        public enum enUniMis
        {
            micron = 0,
            mm = 1,
            inches = 2,
            dmm = 3,
            meters = 4
        }

        private enUniMis myUserUnit;
        public enUniMis UserUnit
        {
            get { return myUserUnit; }
            set
            {
                if ((value == enUniMis.dmm) | (value == enUniMis.inches) | (value == enUniMis.micron) | (value == enUniMis.mm) | (value == enUniMis.meters))
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
                UserUnit = enUniMis.micron;
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<MeasureSystem>().Error(ex.Message);
                LogHelper.GetLogger<MeasureSystem>().Error(ex.StackTrace);
            }
        }

        public static double MicronToCustomUnit(double Measure_micron, enUniMis CustomUnit, bool Round = false)
        {
            double retValue = 0;
            try
            {
                if (CustomUnit == enUniMis.micron)
                {
                    return Measure_micron;
                }
                else
                {
                    //Converto da micron a AracneInfo.BaseUnit ...
                    switch (CustomUnit)
                    {
                        case enUniMis.inches:
                            // 1 inch = 25400 micron ...
                            retValue = Measure_micron / 25400;
                            if (Round)
                            {
                                //Risoluzione = inch/100
                                retValue = Convert.ToDouble(retValue * 100) / 100;
                            }
                            break;
                        case enUniMis.micron:
                            retValue = Measure_micron;
                            break;
                        case enUniMis.mm:
                            retValue = Measure_micron / 1000;
                            if (Round)
                            {
                                //Risoluzione = mm/10
                                retValue = Convert.ToDouble(retValue * 10) / 10;
                            }
                            break;
                        case enUniMis.meters:
                            retValue = Measure_micron / 1000000;
                            if (Round)
                            {
                                //Risoluzione = m/10
                                retValue = Convert.ToDouble(retValue * 10) / 10;
                            }
                            break;
                        case enUniMis.dmm:
                            retValue = Measure_micron / 100;
                            if (Round)
                            {
                                //Risoluzione = dmm
                                retValue = Convert.ToDouble(retValue);
                            }
                            break;
                    }
                    return retValue;
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<MeasureSystem>().Error(ex.Message);
                LogHelper.GetLogger<MeasureSystem>().Error(ex.StackTrace);
                return 0;
            }
        }

        public static int MicronToCustomUnit(int Measure_micron, enUniMis CustomUnit, bool Round = false)
        {
            return Convert.ToInt32(MicronToCustomUnit(Convert.ToDouble(Measure_micron), CustomUnit, Round));
        }
        public double MicronToUserUnit(double Measure_micron, bool Round = false)
        {
            return MicronToCustomUnit(Measure_micron, UserUnit, Round);
        }

        public static int CustomUnitToMicron(double MeasureValue, enUniMis CustomUnit)
        {
            try
            {
                int retVal = 0;
                //Converto in micron ...
                switch (CustomUnit)
                {
                    case enUniMis.inches:
                        // 1 inch = 25400 micron ...
                        retVal = Convert.ToInt32(25400 * MeasureValue);
                        break;
                    case enUniMis.micron:
                        retVal = Convert.ToInt32(MeasureValue);
                        break;
                    case enUniMis.meters:
                        retVal = Convert.ToInt32(1000000 * MeasureValue);
                        break;
                    case enUniMis.mm:
                        retVal = Convert.ToInt32(1000 * MeasureValue);
                        break;
                    case enUniMis.dmm:
                        retVal = Convert.ToInt32(100 * MeasureValue);
                        break;
                }
                return retVal;
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<MeasureSystem>().Error(ex.Message);
                LogHelper.GetLogger<MeasureSystem>().Error(ex.StackTrace);
                return 0;
            }
        }

        public int UserUnitToMicron(double MeasureValue)
        {
            return CustomUnitToMicron(MeasureValue, UserUnit);
        }
        public string UserUnitDescription()
        {
            return UniMisDescription(UserUnit);
        }

        public void FillComboWithAvailableUnits(System.Windows.Forms.ComboBox cbMeasureUnit)
        {
            try
            {
                cbMeasureUnit.Items.Clear();
                List<enUniMis> myArray = Enum.GetValues(typeof(enUniMis)).Cast<enUniMis>().ToList();
                for (int iCounter = 0; iCounter <= myArray.Count - 1; iCounter++)
                {
                    cbMeasureUnit.Items.Add(UniMisDescription(myArray[iCounter]));
                }
                cbMeasureUnit.SelectedIndex = (int)this.UserUnit;
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<MeasureSystem>().Error(ex.Message);
                LogHelper.GetLogger<MeasureSystem>().Error(ex.StackTrace);
            }
        }
        public static string UniMisDescription(enUniMis UNIT)
        {
            try
            {
                switch (UNIT)
                {
                    case enUniMis.inches:
                        return "inches";
                    case enUniMis.micron:
                        return "micron";
                    case enUniMis.mm:
                        return "mm";
                    case enUniMis.meters:
                        return "m";
                    case enUniMis.dmm:
                        return "dmm";
                    default:
                        return "";
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<MeasureSystem>().Error(ex.Message);
                LogHelper.GetLogger<MeasureSystem>().Error(ex.StackTrace);
                return "";
            }
        }
    }
}
