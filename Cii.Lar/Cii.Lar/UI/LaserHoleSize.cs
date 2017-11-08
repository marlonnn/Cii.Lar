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
using Cii.Lar.SysClass;

namespace Cii.Lar.UI
{
    public partial class LaserHoleSize : BaseCtrl
    {
        private List<HolePulsePoint> holePulsePoints;
        private GraphicsPropertiesManager graphicsPropertiesManager = GraphicsPropertiesManager.GraphicsManagerSingleInstance();

        private GraphicsProperties graphicsProperties;

        private HolePulsePoint currentPoint;
        public HolePulsePoint CurrentPoint
        {
            get { return this.currentPoint; }
            set
            {
                this.currentPoint = value;
                this.holeSizeCtrl.HoleSize = value.Y;
            }
        }

        public LaserHoleSize()
        {
            resources = new ComponentResourceManager(typeof(LaserHoleSize));
            this.ShowIndex = 6;
            graphicsProperties = graphicsPropertiesManager.GetPropertiesByName("Circle");
            InitializeComponent();
            InitializeSlider();
            InitializeChartSeries();
            InitializeHolePulsePoints();
            this.holeSizeCtrl.UpdownClickHandler += UpdownClickHandler;

        }

        private void InitializeHolePulsePoints()
        {
            holePulsePoints = new List<HolePulsePoint>();
            holePulsePoints.Add(new HolePulsePoint(0.005f, 0.1f));
            holePulsePoints.Add(new HolePulsePoint(2.5f, 50f));
            CalPiecewiseFunction();
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
        }

        private void UpdownClickHandler(bool isUp)
        {
            CurrentPoint = new HolePulsePoint(CurrentPoint.X, isUp ? CurrentPoint.Y + 0.2f : CurrentPoint.Y - 0.2f);
            if (CheckPoint(CurrentPoint))
            {
                UpdatePoint(CurrentPoint);
            }
            else
            {
                AddPoint(CurrentPoint);
            }
        }

        private void RemovePoint(HolePulsePoint point)
        {
            if (holePulsePoints != null)
            {
                for (int i = 0; i < holePulsePoints.Count; i++)
                {
                    if (holePulsePoints[i].X == point.X)
                    {
                        holePulsePoints.Remove(holePulsePoints[i]);
                    }
                }
                CalPiecewiseFunction();
            }
        }

        private void AddPoint(HolePulsePoint point)
        {
            if (holePulsePoints != null)
            {
                holePulsePoints.Add(point);
                CalPiecewiseFunction();
            }
        }

        private void UpdatePoint(HolePulsePoint point)
        {
            if (holePulsePoints != null && holePulsePoints.Count > 0)
            {
                for (int i = 0; i < holePulsePoints.Count; i++)
                {
                    if (holePulsePoints[i].X == point.X)
                    {
                        holePulsePoints[i].Y = point.Y;
                    }
                }
                CalPiecewiseFunction();
            }
        }

        private bool CheckPoint(HolePulsePoint point)
        {
            bool exist = false;
            if (holePulsePoints != null && holePulsePoints.Count > 0)
            {
                for (int i=0; i< holePulsePoints.Count; i++)
                {
                    if (holePulsePoints[i].X == point.X)
                    {
                        exist = true;
                    }
                }
            }
            return exist;
        }

        private bool CheckPoint(float x)
        {
            bool exist = false;
            if (holePulsePoints != null && holePulsePoints.Count > 0)
            {
                for (int i = 0; i < holePulsePoints.Count; i++)
                {
                    if (holePulsePoints[i].X == x)
                    {
                        exist = true;
                    }
                }
            }
            return exist;
        }

        private void SortPoints()
        {
            holePulsePoints.Sort((p1, p2) => p1.X.CompareTo(p2.X));
        }

        private void CalPiecewiseFunction()
        {
            if (holePulsePoints != null && holePulsePoints.Count > 0)
            {
                SortPoints();
                this.chart1.Series[0].Points.Clear();
                for (int i=0; i<holePulsePoints.Count; i++)
                {
                    if (i + 1 < holePulsePoints.Count)
                    {
                        CalSlopeFunction(holePulsePoints[i], holePulsePoints[i + 1]);
                    }
                }
            }
        }

        private void CalSlopeFunction(HolePulsePoint p1, HolePulsePoint p2)
        {
            double k = 0;
            k = (p2.Y - p1.Y) / (p2.X - p1.X);
            int startX = (int)(p1.X * 1000);
            int endX = (int)(p2.X * 1000);
            for (int i = startX; i <= endX; i++)
            {
                var x = i / 1000d;
                var y = k * (x - p1.X) + p1.Y;
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
            var x = value / 1000f;
            CalXY(x);
            SaveDeleteButtonVisiable(CheckPoint(x));
        }

        private void CalXY(float value)
        {
            for (int i = 0; i < holePulsePoints.Count - 1; i++)
            {
                var x = value;
                double k = (holePulsePoints[i + 1].Y - holePulsePoints[i].Y) / (holePulsePoints[i + 1].X - holePulsePoints[i].X);
                var y = k * (value - holePulsePoints[i].X) + holePulsePoints[i].Y;
                CurrentPoint = new HolePulsePoint(x, (float)y);
            }
        }

        private void SaveDeleteButtonVisiable(bool isVisiable)
        {
            this.btnSave.Visible = isVisiable;
            this.btnDelete.Visible = isVisiable;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            RemovePoint(CurrentPoint);
            SaveDeleteButtonVisiable(false);
        }
    }
}
