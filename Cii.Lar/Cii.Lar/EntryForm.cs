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
            Program.ExpManager.ZWPictureBox = this.zwPictureBox;
            this.controlCtrl.StripButtonClickHandler += Program.ExpManager.StripButtonClickHandler;
            this.WindowState = FormWindowState.Maximized;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.controlCtrl.PictureBox = this.zwPictureBox;
            this.zwPictureBox.LoadImage();
        }
    }
}