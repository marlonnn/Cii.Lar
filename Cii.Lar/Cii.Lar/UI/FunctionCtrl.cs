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
    public partial class FunctionCtrl : UserControl
    {
        public EventHandler ToolStripClickHandler;
        public FunctionCtrl()
        {
            InitializeComponent();
        }

        private void ToolStripButton_Click(object sender, EventArgs e)
        {
            ToolStripClickHandler?.Invoke(sender, e);
        }
    }
}
