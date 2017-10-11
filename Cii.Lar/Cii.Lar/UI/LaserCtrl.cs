using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Cii.Lar.DrawTools;

namespace Cii.Lar.UI
{
    /// <summary>
    /// Laser setting control
    /// Author: Zhong Wen 2017/08/05
    /// </summary>
    public partial class LaserCtrl : BaseCtrl
    {
        private GraphicsPropertiesManager graphicsPropertiesManager = GraphicsPropertiesManager.GraphicsManagerSingleInstance();

        private GraphicsProperties graphicsProperties;

        public LaserCtrl() : base()
        {
            resources = new ComponentResourceManager(typeof(LaserCtrl));
            this.ShowIndex = 0;
            graphicsProperties = graphicsPropertiesManager.GetPropertiesByName("Circle");
            InitializeComponent();
        }

        /// <summary>
        /// save preset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// fire laser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFire_Click(object sender, EventArgs e)
        {

        }

        private void btnAlignLaser_Click(object sender, EventArgs e)
        {

        }

        private void btnHoleSize_Click(object sender, EventArgs e)
        {

        }

        private void btnAppearance_Click(object sender, EventArgs e)
        {
            ClickDelegateHandler?.Invoke(sender, "Laser Appearance");
        }

        private void SliderValueChangedHandler(object sender, EventArgs e)
        {
            var value = this.sliderCtrl.Slider.Value;
            this.sliderCtrl.PulseHole.Text = string.Format("{0}ms {1}um", 5 + (value * 0.1), 10 + (value * 0.1));
            if (value > 8)
            {
                this.btnFire.BackColor = Color.LightSalmon;
                this.btnFire.Text = Res.LaserCtrl.StrBigPulse;
            }
            else if (value < 2)
            {
                this.btnFire.BackColor = Color.LightSalmon;
                this.btnFire.Text = Res.LaserCtrl.StrSmallPulse;
            }
            else
            {
                this.btnFire.BackColor = Color.LightYellow;
                this.btnFire.Text = Res.LaserCtrl.StrFire;
            }
            this.btnFire.Invalidate();
            if (graphicsProperties != null)
            {
                graphicsProperties.TargetSize = value;
            }
        }

        protected override void RefreshUI()
        {
            base.RefreshUI();
            this.Title = global::Cii.Lar.Properties.Resources.StrLaserCtrlTitle;
        }
    }
}
