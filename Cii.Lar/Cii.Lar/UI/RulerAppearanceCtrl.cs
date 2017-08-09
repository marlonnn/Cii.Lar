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
    public partial class RulerAppearanceCtrl : BaseCtrl
    {
        public RulerAppearanceCtrl()
        {
            this.ShowIndex = 3;
            InitializeComponent();
        }

        private void btnLaserCtrl_Click(object sender, EventArgs e)
        {
            ClickDelegateHandler?.Invoke(sender, "Statistics control");
        }
    }
}
