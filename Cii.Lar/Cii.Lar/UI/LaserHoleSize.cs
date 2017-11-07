using System;
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

        private double currentX;
        private double currentY;
        public double CurrentY
        {
            get { return this.currentY; }
            set
            {
                if (value != this.currentY)
                {
                    this.currentY = value;
                }
            }
        }

        private HolePulsePoint currentPoint;
        public HolePulsePoint CurrentPoint
        {
            get { return this.currentPoint; }
            set
            {
                if (value.X == this.currentPoint.X && value.Y != this.currentPoint.Y)
                {
                    this.currentPoint.Y = value.Y;
                    AddHolePulsePoints(value);
                }
            }
        }

        private void UpdownClickHandler(bool isUp)
        {
            CurrentPoint = new HolePulsePoint((float)currentX, isUp ? (float)(currentY++) : (float)(currentY--));
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
            //CalcPoint();
        }

        private void AddHolePulsePoints(HolePulsePoint point)
        {
            bool exist = false;
            if (holePulsePoints != null && holePulsePoints.Count > 0)
            {
                for (int i = 0; i < holePulsePoints.Count; i++)
                {
                    if (holePulsePoints[i].X == point.X && holePulsePoints[i].Y == point.Y)
                    {
                        exist = true;
                    }
                    else if (holePulsePoints[i].X == point.X && holePulsePoints[i].Y != point.Y)
                    {
                        exist = false;
                    }
                }
                if (!exist)
                {
                    holePulsePoints.Add(point);
                    CalPiecewiseFunction();
                }
            }
        }

        private void InitializeHolePulsePoints()
        {
            holePulsePoints = new List<HolePulsePoint>();
            holePulsePoints.Add(new HolePulsePoint(0.005f, 0.1f));
            holePulsePoints.Add(new HolePulsePoint(2.5f, 50f));
            CalPiecewiseFunction();
        }

        private void CalPiecewiseFunction()
        {
            holePulsePoints.Sort((p1, p2) => { return (int)(p1.X - p2.X); });
            if (holePulsePoints != null && holePulsePoints.Count > 0)
            {
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

        private void CalY(float value)
        {
            var c = GetPiecewiseCount();
            for (int i=0; i < c; i++)
            {
                if (i + 1 < holePulsePoints.Count)
                {
                    //if (Math.Abs(holePulsePoints[i + 1].X - value) < 0.00002)
                    {
                        currentX = value;
                        double k = (holePulsePoints[i + 1].Y - holePulsePoints[i].Y) / (holePulsePoints[i + 1].X - holePulsePoints[i].X);
                        currentY = k * (currentX - holePulsePoints[i].X) + holePulsePoints[i].Y;
                        currentPoint = new HolePulsePoint((float)currentX, (float)currentY);
                        this.holeSizeCtrl.UpdateHoleSize(currentY);
                        //this.chart1.Series[0].Points.AddXY(x, y);
                    }
                }
            }
        }

        private int GetPiecewiseCount()
        {
            return holePulsePoints.Count - 1;
        }

        private void PulseSliderValueChangedHandler(object sender, EventArgs e)
        {
            var value = this.sliderPulse.Slider.Value;
            this.sliderPulse.SetValue(value, "ms");
            if (this.graphicsProperties != null)
            {
                this.graphicsProperties.PulseSize = value;
            }
            CalY(value / 1000f);
            //var v = k * (value / 1000d - 0.005) + 0.1;
            //this.holeSizeCtrl.UpdateHoleSize(v);
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
