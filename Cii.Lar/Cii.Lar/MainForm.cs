using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Metro;

namespace Cii.Lar
{
    public partial class MainForm : MetroAppForm
    {
        public MainForm()
        {
            InitializeComponent();
            //Fullscreen(true);
        }

        private void RibbonStateCommand_Executed(object sender, EventArgs e)
        {
            ribbonControl1.Expanded = RibbonStateCommand.Checked;
            RibbonStateCommand.Checked = !RibbonStateCommand.Checked;
        }

        private void Fullscreen(bool fullscreen)
        {
            this.TopMost = fullscreen;
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Maximized;
                //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }

    }
}