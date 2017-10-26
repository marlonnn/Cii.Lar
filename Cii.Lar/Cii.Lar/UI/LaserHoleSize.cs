using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cii.Lar.UI
{
    public partial class LaserHoleSize : BaseCtrl
    {
        public LaserHoleSize()
        {
            resources = new ComponentResourceManager(typeof(LaserHoleSize));
            this.ShowIndex = 6;
            InitializeComponent();
            InitializeSlider();
        }

        private void InitializeSlider()
        {
            this.sliderPulse.SetMinMaxValue(5, 2500);
            this.sliderPulse.SetValue(5, "ms");
            this.sliderPulse.SliderValueChangedHandler += PulseSliderValueChangedHandler;

            this.sliderHole.SetMinMaxValue(1, 534);
            this.sliderHole.SetValue(1, "um");
            this.sliderHole.SliderValueChangedHandler += HoleSliderValueChangedHandler;
        }

        private void HoleSliderValueChangedHandler(object sender, EventArgs e)
        {
            var value = this.sliderHole.Slider.Value;
            this.sliderHole.SetValue(value, "um");
        }

        private void PulseSliderValueChangedHandler(object sender, EventArgs e)
        {
            var value = this.sliderPulse.Slider.Value;
            this.sliderPulse.SetValue(value, "ms");
        }

        protected override void RefreshUI()
        {
            base.RefreshUI();
            this.Title = global::Cii.Lar.Properties.Resources.StrLaserHoleSizeCalibration;
        }

        private void btnLaserCtrl_Click(object sender, EventArgs e)
        {
            ClickDelegateHandler?.Invoke(sender, "Laser Control");
        }
    }
}
