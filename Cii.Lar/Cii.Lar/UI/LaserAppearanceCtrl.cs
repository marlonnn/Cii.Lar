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
    /// <summary>
    /// Laser apparance control
    /// Author:Zhong Wen 2017/08/06
    /// </summary>
    public partial class LaserAppearanceCtrl : BaseCtrl
    {
        public LaserAppearanceCtrl()
        {
            this.ShowIndex = 1;
            InitializeComponent();
        }

        private void btnLaserCtrl_Click(object sender, EventArgs e)
        {
            ClickDelegateHandler?.Invoke(sender, "Laser Control");
        }
    }
}
