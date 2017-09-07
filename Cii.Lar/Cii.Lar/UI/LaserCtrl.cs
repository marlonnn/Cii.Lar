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

namespace Cii.Lar.UI
{
    /// <summary>
    /// Laser setting control
    /// Author: Zhong Wen 2017/08/05
    /// </summary>
    public partial class LaserCtrl : BaseCtrl
    {
        public LaserCtrl() : base()
        {
            resources = new ComponentResourceManager(typeof(LaserCtrl));
            this.ShowIndex = 0;
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

        protected override void RefreshUI()
        {
            base.RefreshUI();
            this.Title = global::Cii.Lar.Properties.Resources.StrLaserCtrlTitle;
        }
    }
}
