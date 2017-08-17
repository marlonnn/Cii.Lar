using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cii.Lar.UI
{
    /// <summary>
    /// image viewer form
    /// Author: Zhong Wen 2017/08/10
    /// </summary>
    public partial class ImageForm : Office2007Form
    {
        private AssignForm assignForm;
        private Bitmap currentImage;
        public Bitmap CurrentImage
        {
            get
            {
                return currentImage;
            }
            set
            {
                currentImage = value;
            }
        }

        private string fileName;
        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                if (value != this.fileName)
                {
                    this.fileName = value;
                    currentImage = new Bitmap(value);
                }
            }
        }

        public ImageForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Load += ImageForm_Load;
        }

        private void ImageForm_Load(object sender, EventArgs e)
        {
            this.pictureBox.Width = (int)(this.ClientSize.Width * 0.8f);
            this.pictureBox.Height = this.ClientSize.Height;
            this.pictureBox.Left = (int)(this.ClientSize.Width * 0.1f);
            this.pictureBox.Top = 0;

            this.pictureBox.Image = currentImage;
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonCopy_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonAssign_Click(object sender, EventArgs e)
        {
            assignForm = new AssignForm();
            assignForm.ShowDialog();
        }

        private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {

        }

    }
}