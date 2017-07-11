using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.Metro.ColorTables;
using DevComponents.DotNetBar;

namespace Cii.Lar
{
    public partial class MainForm : DevComponents.DotNetBar.Office2007Form
    {
        private int CurrentScalePercent = 100;
        public MainForm()
        {
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //for test
            string defaultImage = string.Format("{0}\\Resources\\1.bmp", System.Environment.CurrentDirectory);
            this.scalablePictureBox.Picture = new Bitmap(defaultImage);
            this.ActiveControl = this.scalablePictureBox.PictureBox;
        }

        private void ToolStripClickHandler(object sender, EventArgs e)
        {
            var toolStripButton = sender as ToolStripButton;
            switch (toolStripButton.Text)
            {
                case "toolStripButtonZoomOut":
                    if (CurrentScalePercent == 60)
                    {
                        CurrentScalePercent = 100;
                    }
                    CurrentScalePercent -= 10;
                    this.scalablePictureBox.CurrentScalePercent = CurrentScalePercent;
                    break;
                case "toolStripButtonZoomIn":
                    if (CurrentScalePercent == 1500)
                    {
                        CurrentScalePercent = 100;
                    }
                    CurrentScalePercent += 10;
                    this.scalablePictureBox.CurrentScalePercent = CurrentScalePercent;
                    break;
            }
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