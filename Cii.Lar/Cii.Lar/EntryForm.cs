using Cii.Lar.SysClass;
using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cii.Lar
{
    public partial class EntryForm : Office2007Form
    {
        private ComponentResourceManager resources;
        private SysConfig sysConfig;
        public EntryForm()
        {
            InitializeComponent();
            Program.ExpManager.ZWPictureBox = this.zwPictureBox;
            this.controlCtrl.StripButtonClickHandler += Program.ExpManager.StripButtonClickHandler;
            this.WindowState = FormWindowState.Maximized;
            resources = new ComponentResourceManager(typeof(EntryForm));
            sysConfig = SysConfig.GetSysConfig();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.controlCtrl.PictureBox = this.zwPictureBox;
            this.zwPictureBox.LoadImage();
            sysConfig.PropertyChanged += EntryForm_PropertyChanged;
        }

        private void EntryForm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == sysConfig.GetPropertyName(() => sysConfig.UICulture))
            {
                sysConfig.RefreshUICulture(resources, this);
            }
        }
    }
}