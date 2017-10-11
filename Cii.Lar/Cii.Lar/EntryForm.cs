using Cii.Lar.SysClass;
using Cii.Lar.UI;
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
        private FullScreen fullScreen;
        private ComponentResourceManager resources;
        private SysConfig sysConfig;

        public ControlCtrl ControlCtrl
        {
            get
            {
                return this.controlCtrl;
            }
        }

        public EntryForm()
        {
            InitializeComponent();
            Program.ExpManager.ZWPictureBox = this.zwPictureBox;
            this.controlCtrl.StripButtonClickHandler += Program.ExpManager.StripButtonClickHandler;
            this.WindowState = FormWindowState.Maximized;
            resources = new ComponentResourceManager(typeof(EntryForm));
            sysConfig = SysConfig.GetSysConfig();
            this.SizeChanged += EntryForm_SizeChanged;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            fullScreen = new FullScreen(this);
            this.controlCtrl.PictureBox = this.zwPictureBox;
            this.zwPictureBox.RegisterHandler();
            this.zwPictureBox.LoadImage();
            this.zwPictureBox.EscapeFullScreenHandler += EscapeFullScreenHandler;
            sysConfig.PropertyChanged += EntryForm_PropertyChanged;
            fullScreen.ShowFullScreen();
        }

        private void EscapeFullScreenHandler()
        {
            fullScreen.ShowFullScreen();
        }

        private FormWindowState tempWindowState;
        private void EntryForm_SizeChanged(object sender, EventArgs e)
        {
            if (tempWindowState != FormWindowState.Maximized && this.WindowState == FormWindowState.Maximized)//点击最大化
            {
                tempWindowState = FormWindowState.Maximized;
                if (fullScreen != null)
                {
                    fullScreen.ShowFullScreen();
                }
            }

        }
        private void EntryForm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == sysConfig.GetPropertyName(() => sysConfig.UICulture))
            {
                sysConfig.RefreshUICulture(resources, this);
            }
        }

        private void ZwPictureBox_OnMeasureUnitChanged(DrawTools.enUniMis unit)
        {
        }
    }
}