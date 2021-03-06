using Cii.Lar.ExpClass;
using Cii.Lar.SysClass;
using Cii.Lar.UI;
using DevComponents.DotNetBar;
using Manina.Windows.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cii.Lar
{
    public partial class FilesForm : Office2007Form
    {
        private AssignForm assignForm;
        private ReportForm reportFrom;
        //private VideoForm videoForm;
        private List<string> videoFiles;
        public FilesForm()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            videoFiles = new List<string>();
            string folderName = SysConfig.GetSysConfig().StorePath;
            string[] extesnsions = new string[] { ".png", ".avi" };
            var files = GetFiles(folderName, extesnsions, SearchOption.TopDirectoryOnly);
            //this.imageListView.View = Manina.Windows.Forms.View.Gallery;
            foreach (var file in files)
            {
                imageListView.Items.Add(file.ToString());
                if (Path.GetExtension(file.ToString()) == ".avi")
                {
                    videoFiles.Add(file.ToString());
                }
            }
            imageForm = new ImageForm();
            imageForm.DeleteImageItemHandler += DeleteImageItemHandler;
        }

        private void DeleteImageItemHandler(ImageListViewItem imageListViewItem)
        {
            imageListView.SuspendLayout();

            // Remove selected items
            imageListView.Items.Remove(imageListViewItem);

            // Resume layout logic.
            imageListView.ResumeLayout(true);
        }

        /// <summary>
        /// Get files form directory
        /// </summary>
        /// <param name="sourceDirectory">source directory</param>
        /// <param name="exts">extensions</param>
        /// <param name="searchOpt">search option</param>
        /// <returns></returns>
        private IEnumerable GetFiles(string sourceDirectory, string[] exts, SearchOption searchOpt)
        {
            return Directory.GetFiles(sourceDirectory, "*.*", searchOpt)
                    .Where(
                inS => exts.Contains(System.IO.Path.GetExtension(inS),
                StringComparer.OrdinalIgnoreCase)
                           );
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            // Suspend the layout logic while we are removing items.
            // Otherwise the control will be refreshed after each item
            // is removed.
            imageListView.SuspendLayout();

            // Remove selected items
            foreach (var item in imageListView.SelectedItems)
            {
                imageListView.Items.Remove(item);
            }

            // Resume layout logic.
            imageListView.ResumeLayout(true);
        }

        private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            CreateReportFrom();
        }

        private void CreateReportFrom()
        {
            Report report = new Report();
            report.ReportPages.Capacity = imageListView.Items.Count;
            for (int i=0; i<imageListView.Items.Count; i++)
            {
                ReportPage reportPage = new ReportPage();
                ReportPictureItem reportItem = new ReportPictureItem();
                string fileName = imageListView.Items[i].FileName;
                reportItem.Picture = new Bitmap(fileName);
                reportItem.OldImageSize = reportItem.Picture.Size;
                reportItem.Bounds = new Rectangle(new Point(0, 0), reportItem.Picture.Size);
                reportPage.ReportItems.Add(reportItem);
                report.ReportPages.Add(reportPage);
            }
            reportFrom = new ReportForm(report);
            reportFrom.ShowDialog();
        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            UpdateStatus();
            timerStatus.Enabled = false;
        }

        private void imageListView_SelectionChanged(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            if (imageListView.Items.Count == 0)
                UpdateStatus("Ready");
            else if (imageListView.SelectedItems.Count == 0)
                UpdateStatus(string.Format("{0} images", imageListView.Items.Count));
            else
                UpdateStatus(string.Format("{0} images ({1} selected)", imageListView.Items.Count, 
                    imageListView.SelectedItems.Count));
        }

        private void UpdateStatus(string text)
        {
            toolStripStatusLabel.Text = text;
        }

        private ImageForm imageForm;

        private void imageListView_ItemDoubleClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                ImageListViewItem item = this.imageListView.Items.FocusedItem;
                if (item != null)
                {
                    var fileExtension = Path.GetExtension(item.FileName);
                    if (fileExtension == ".avi")
                    {
                        string fileName = item.FileName;
                        //int v = videoFiles.FindIndex(file => { return file == fileName; });
                        //videoForm = new VideoForm(videoFiles, fileName);
                        //videoForm.ShowDialog();
                    }
                    else if (fileExtension == ".png")
                    {
                        string fileName = item.FileName;
                        imageForm.Text = item.Text;
                        imageForm.ImageListViewItem = item;
                        imageForm.FileName = fileName;
                        DialogResult dr = imageForm.ShowDialog();
                        if (dr == DialogResult.OK && imageForm.IsAssign)
                        {
                            DeleteImageItemHandler(item);
                            File.Delete(item.FileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<FilesForm>().Error(ex.Message);
                LogHelper.GetLogger<FilesForm>().Error(ex.StackTrace);
            }
        }

        private void RemoveAndDelete(ImageListViewItem item)
        {

        }

        private void imageListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ImageListViewItem item = this.imageListView.Items.FocusedItem;
            //if (item != null)
            //{
            //    string fileName = item.FileName;
            //    imageForm.FileName = fileName;
            //    imageForm.ShowDialog();
            //}
        }

        private void toolStripButtonAssign_Click(object sender, EventArgs e)
        {
            assignForm = new AssignForm();
            assignForm.Show();
        }

    }
}