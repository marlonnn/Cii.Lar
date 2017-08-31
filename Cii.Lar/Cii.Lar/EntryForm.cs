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
    public partial class EntryForm : Office2007Form
    {
        public EntryForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.zwPictureBox.Enabled = true;
            this.zwPictureBox.Focus();
            this.zwPictureBox.OffsetX = (this.zwPictureBox.Width - this.zwPictureBox.Image.Width) / 2;
        }
    }
}