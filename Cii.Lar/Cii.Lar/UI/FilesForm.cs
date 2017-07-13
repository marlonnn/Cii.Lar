using Cii.Lar.SysClass;
using DevComponents.DotNetBar;
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
        public FilesForm()
        {
            InitializeComponent();
            string folderName = SysConfig.GetSysConfig().StorePath;
            string[] extesnsions = new string[] { ".png", ".wmv" };
            var files = GetFiles(folderName, extesnsions, SearchOption.TopDirectoryOnly);
            foreach (var file in files)
            {
                imageListView.Items.Add(file.ToString());
            }
        }

        private IEnumerable GetFiles(string sourceDirectory, string[] exts, SearchOption searchOpt)
        {
            return Directory.GetFiles(sourceDirectory, "*.*", searchOpt)
                    .Where(
                inS => exts.Contains(System.IO.Path.GetExtension(inS),
                StringComparer.OrdinalIgnoreCase)
                           );
        }
    }
}