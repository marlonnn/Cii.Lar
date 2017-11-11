using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar.UI
{
    public enum CtrlType
    {
        LaserAlignment,
        LaserAppreance,
        LaserCtrl,
        LaserHoleSize,
        StatisticsCtrl,
        RulerAppearanceCtrl,
        SettingCtrl
    }

    /// <summary>
    /// Base Control factory
    /// get base control by type
    /// Author: Zhong Wen 2017/11/11
    /// </summary>
    public class CtrlFactory
    {
        private static CtrlFactory ctrlFactory;

        private ZWPictureBox pictureBox;

        public ZWPictureBox ZWPictureBox
        {
            get { return this.pictureBox; }
            set { this.pictureBox = value; }
        }

        private LaserCtrl laserCtrl;
        private LaserAlignment laserAlignment;
        private LaserAppearanceCtrl laserAppearance;
        private LaserHoleSize laserHoleSize;
        private StatisticsCtrl statisticsCtrl;
        private RulerAppearanceCtrl rulerAppearanceCtrl;
        private SettingCtrl settingCtrl;

        public CtrlFactory(ZWPictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            this.laserCtrl = new LaserCtrl(pictureBox);
            this.laserAlignment = new LaserAlignment(pictureBox);
            this.laserAppearance = new LaserAppearanceCtrl();
            this.laserHoleSize = new LaserHoleSize();
            this.statisticsCtrl = new StatisticsCtrl();
            this.rulerAppearanceCtrl = new RulerAppearanceCtrl();
            this.settingCtrl = new SettingCtrl(pictureBox);
        }

        /// <summary>
        /// first shold initialize ZWPictureBox
        /// </summary>
        /// <param name="ZWPictureBox"></param>
        public static void InitializeCtrlFactory(ZWPictureBox pictureBox)
        {
            ctrlFactory = new CtrlFactory(pictureBox);

        }

        public static CtrlFactory GetCtrlFactory()
        {
            return ctrlFactory;
        }

        /// <summary>
        /// Get control by control type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ctrlType"></param>
        /// <returns></returns>
        public T GetCtrlByType<T>(CtrlType ctrlType) where T : BaseCtrl
        {
            T ctrl = null;
            switch (ctrlType)
            {
                case CtrlType.LaserAlignment:
                    ctrl = this.laserAlignment as T;
                    break;
                case CtrlType.LaserAppreance:
                    ctrl = this.laserAppearance as T;
                    break;
                case CtrlType.LaserCtrl:
                    ctrl = this.laserCtrl as T;
                    break;
                case CtrlType.LaserHoleSize:
                    ctrl = this.laserHoleSize as T;
                    break;
                case CtrlType.RulerAppearanceCtrl:
                    ctrl = this.rulerAppearanceCtrl as T;
                    break;
                case CtrlType.StatisticsCtrl:
                    ctrl = this.statisticsCtrl as T;
                    break;
                case CtrlType.SettingCtrl:
                    ctrl = this.settingCtrl as T;
                    break;
            }
            return ctrl;
        }

    }
}
