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

        private void cmboxRuler_DropDown(object sender, EventArgs e)
        {
            UpdateTimerStatesHandler?.Invoke(false);
        }

        private void cmboxRuler_DropDownClosed(object sender, EventArgs e)
        {
            UpdateTimerStatesHandler?.Invoke(true);
        }

        public delegate void UpdateTimerState(bool enable);
        public UpdateTimerState UpdateTimerStatesHandler;

        private void cmboxRuler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
