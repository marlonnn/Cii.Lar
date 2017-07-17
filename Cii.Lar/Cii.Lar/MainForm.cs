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
using Cii.Lar.UI;
using Cii.Lar.SysClass;
using System.Drawing.Imaging;

namespace Cii.Lar
{
    public partial class MainForm : DevComponents.DotNetBar.Office2007Form
    {
        private int CurrentScalePercent = 100;
        private SettingForm settingForm;
        private FilesForm filesForm;
        public MainForm()
        {
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
            this.Load += MainForm_Load;
        }

        private void CaptureImage()
        {
            try
            {
                using (Bitmap bitmap = new Bitmap(this.scalablePictureBox.PictureBox.Image))
                {
                    string fileName = string.Format("{0}\\{1}.png", SysConfig.GetSysConfig().StorePath, DateTime.Now.ToString("yyyyMMddHHmmsss"));
                    bitmap.Save(fileName);
                    ShowToastNotification();
                }
            }
            catch (Exception e)
            {

            }
        }

        private void ShowToastNotification()
        {
            ToastNotification.Show(this, "Screenshot success", 
                global::Cii.Lar.Properties.Resources.capture, 1000, eToastGlowColor.Blue,
                eToastPosition.MiddleCenter);
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
                case "toolStripButtonCapture":
                    CaptureImage();
                    break;
                case "toolStripFiles":
                    filesForm = new FilesForm();
                    filesForm.ShowDialog();
                    break;
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
                case "toolStripButtonSetting":
                    settingForm = new SettingForm();
                    settingForm.ShowDialog();
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

        private void toolStripButtonCapture_Click(object sender, EventArgs e)
        {
            CaptureImage();
        }

        private void toolStripButtonVideo_Click(object sender, EventArgs e)
        {

        }

        private void toolStripFiles_Click(object sender, EventArgs e)
        {
            filesForm = new FilesForm();
            filesForm.ShowDialog();
        }

        private void toolStripButtonZoomOut_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonZoomIn_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonScale_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonLine_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonLaser_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonRectangle_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonElliptical_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonPolygon_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonSetting_Click(object sender, EventArgs e)
        {
            settingForm = new SettingForm();
            settingForm.ShowDialog();
        }
    }
}