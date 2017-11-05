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
    public partial class HoleSizeCtrl : UserControl
    {
        public HoleSizeCtrl()
        {
            InitializeComponent();
        }

        public void UpdateHoleSize(double value)
        {
            var v = value.ToString("0.00");
            this.lblHoleSize.Text = string.Format("{0}um", v);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {

        }

        private void btnDown_Click(object sender, EventArgs e)
        {

        }
    }
}
