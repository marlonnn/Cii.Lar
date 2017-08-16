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
                    this.pictureBox.Image = currentImage;
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
            var scale = Math.Min((float)this.CurrentImage.Width / this.ClientSize.Width, (float)this.CurrentImage.Height /this.ClientSize.Height);

            this.pictureBox.Width = (int)(this.CurrentImage.Width * scale);
            this.pictureBox.Height = (int)(this.CurrentImage.Height * scale);
            this.pictureBox.Top = (this.ClientSize.Height - this.pictureBox.Height) / 2;
            this.pictureBox.Left = (this.ClientSize.Width - this.pictureBox.Width) / 2;
            this.AutoScroll = false;
            //if (this.CurrentImage.Width <= this.ClientSize.Width && this.CurrentImage.Height <= this.ClientSize.Height)
            //{
            //    this.pictureBox.Width = this.CurrentImage.Width;
            //    this.pictureBox.Height = this.CurrentImage.Height;
            //    this.pictureBox.Top = (this.ClientSize.Height - this.pictureBox.Height) / 2;
            //    this.pictureBox.Left = (this.ClientSize.Width - this.pictureBox.Width) / 2;
            //    this.AutoScroll = false;
            //}
        }
    }
}