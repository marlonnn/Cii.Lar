using DevComponents.DotNetBar;
using Manina.Windows.Forms;
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
        private ImageListViewItem imageListViewItem;
        
        public ImageListViewItem ImageListViewItem
        {
            get
            {
                return imageListViewItem;
            }
            set
            {
                imageListViewItem = value;
            }
        }

        public delegate void DeleteImageItem(ImageListViewItem imageListViewItem);
        public DeleteImageItem DeleteImageItemHandler;

        private AssignForm assignForm;
        private Bitmap currentImage;

        private bool isAssign;

        public bool IsAssign
        {
            get
            {
                return isAssign;
            }
            set
            {
                isAssign = value;
            }
        }
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
            this.isAssign = false;
            this.WindowState = FormWindowState.Maximized;
            this.Load += ImageForm_Load;
        }

        private void ImageForm_Load(object sender, EventArgs e)
        {
            //this.TitleText = this.Title;
            this.pictureBox.Width = (int)(this.ClientSize.Width * 0.8f);
            this.pictureBox.Height = this.ClientSize.Height;
            this.pictureBox.Left = (int)(this.ClientSize.Width * 0.1f);
            this.pictureBox.Top = 0;

            this.pictureBox.Image = currentImage;
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            string info = string.Format("{0}\n {1}", ImageListViewItem.Text, ImageListViewItem.DateModified);
            var result = MessageBox.Show(info, "Are you confirm to delete the file ? " , MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                //delete file
                DeleteImageItemHandler?.Invoke(ImageListViewItem);
                this.Close();
            }
            
        }

        private void toolStripButtonCopy_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonAssign_Click(object sender, EventArgs e)
        {
            assignForm = new AssignForm(imageListViewItem);
            if (assignForm.ShowDialog() == DialogResult.OK)
            {
                this.isAssign = true;
            }
            else
            {
                this.isAssign = false;
            }
        }

        private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this.DialogResult = DialogResult.OK;
        }

    }
}