﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cii.Lar.DrawTools;

namespace Cii.Lar.UI
{
    public partial class LaserHoleSize : BaseCtrl
    {
        private GraphicsPropertiesManager graphicsPropertiesManager = GraphicsPropertiesManager.GraphicsManagerSingleInstance();

        private GraphicsProperties graphicsProperties;

        public LaserHoleSize()
        {
            resources = new ComponentResourceManager(typeof(LaserHoleSize));
            this.ShowIndex = 6;
            graphicsProperties = graphicsPropertiesManager.GetPropertiesByName("Circle");
            InitializeComponent();
            InitializeSlider();
            InitializeChartSeries();
        }

        private void InitializeSlider()
        {
            this.sliderPulse.SetMinMaxValue(5, 2500);
            this.sliderPulse.SetValue(5, "ms");
            this.sliderPulse.SliderValueChangedHandler += PulseSliderValueChangedHandler;
        }

        private void InitializeChartSeries()
        {
            this.chart1.ChartAreas[0].AxisX.Maximum = 2.500d;
            this.chart1.ChartAreas[0].AxisX.Minimum = 0.005d;
            this.chart1.ChartAreas[0].AxisX.Title = "ms";

            this.chart1.ChartAreas[0].AxisY.Maximum = 50d;
            this.chart1.ChartAreas[0].AxisY.Minimum = 0.1d;
            this.chart1.ChartAreas[0].AxisY.Title = "um";
            CalcPoint();
        }

        private double k;
        private void CalcPoint()
        {
            k = (0.1 - 53.4) / (0.005 - 2.5);
            for (int i = 5; i<2500; i++)
            {
                var x = i / 1000;
                var y = k * (x - 0.005) + 0.1;
                this.chart1.Series[0].Points.AddXY(x, y);
            }
        }

        private void PulseSliderValueChangedHandler(object sender, EventArgs e)
        {
            var value = this.sliderPulse.Slider.Value;
            this.sliderPulse.SetValue(value, "ms");
            if (this.graphicsProperties != null)
            {
                this.graphicsProperties.PulseSize = value;
            }
            var v = k * (value / 1000d - 0.005) + 0.1;
            this.holeSizeCtrl.UpdateHoleSize(v);
            //this.upDownHoleSize.Value = Convert.ToDecimal(k * (value / 1000d - 0.005) + 0.1);
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
