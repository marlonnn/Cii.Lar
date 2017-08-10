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
        }
    }
}