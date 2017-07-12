using Cii.Lar.SysClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cii.Lar.UI
{
    public partial class SettingForm : DevComponents.DotNetBar.Office2007Form
    {
        private SysConfig sysConfig;
        public SettingForm()
        {
            InitializeComponent();
            sysConfig = SysConfig.GetSysConfig();
            this.textBoxItemStoragePath.Text = sysConfig.StorePath;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && 
                    !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    sysConfig.StorePath = fbd.SelectedPath;
                    this.textBoxItemStoragePath.Text = sysConfig.StorePath;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }
    }
}