using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar;

namespace Cii.Lar.UI
{
    /// <summary>
    /// Pulse width and hole size control
    /// Author: Zhong Wen 2018/08/05
    /// </summary>
    public partial class SliderCtrl : UserControl
    {
        public Slider Slider
        {
            get
            {
                return slider;
            }
            set
            {
                slider = value;
            }
        }

        public LabelX PulseHole
        {
            get
            {
                return this.PulseHoleWS;
            }
            set
            {
                PulseHoleWS = value;
            }
        }
        public SliderCtrl()
        {
            InitializeComponent();
        }
    }
}
