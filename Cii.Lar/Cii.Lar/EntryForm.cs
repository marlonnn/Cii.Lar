using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cii.Lar
{
    /// <summary>
    /// Entry form
    /// Author: Zhong Wen 2017/08/24
    /// </summary>
    public partial class EntryForm : Office2007Form
    {
        public EntryForm()
        {
            InitializeComponent();
            this.Load += EntryForm_Load;
        }

        private void EntryForm_Load(object sender, EventArgs e)
        {
            this.toolbarControl.LinkedPictureBox = this.zoomblePictureBoxControl;
        }
    }
}