using Cii.Lar.Operation;
using Cii.Lar.SysClass;
using Cii.Lar.UI;
using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Cii.Lar
{
    public partial class EntryForm : Office2007Form
    {
        private FullScreen fullScreen;
        private ComponentResourceManager resources;
        private SysConfig sysConfig;
        private IDSCamera camera;
        private IController controller;
        private SerialPortConfigCtrl serialConfigForm;

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
            //CtrlFactory.InitializeCtrlFactory(this.zwPictureBox);
            this.controlCtrl.StripButtonClickHandler += Program.ExpManager.StripButtonClickHandler;
            this.WindowState = FormWindowState.Maximized;
            resources = new ComponentResourceManager(typeof(EntryForm));
            sysConfig = SysConfig.GetSysConfig();
            this.SizeChanged += EntryForm_SizeChanged;
            this.FormClosing += EntryForm_FormClosing;
            camera = new IDSCamera(this.zwPictureBox);
            camera.CameraSizeControl.AOIChanged += OnDisplayChanged;
            serialConfigForm = new SerialPortConfigCtrl();
            controller = new IController(serialConfigForm);
        }

        private void OnDisplayChanged(object sender, EventArgs e)
        {
            // get image size
            System.Drawing.Rectangle rect;
            camera.SetSize(out rect);
            this.zwPictureBox.Bounds = rect;
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

        private void EntryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
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

        public void OpenCamera()
        {
            CameraChooseForm chooseForm = new CameraChooseForm();
            if (chooseForm.ShowDialog() == DialogResult.OK)
            {
                if (camera.InitCamera(chooseForm.DeviceID | (Int32)uEye.Defines.DeviceEnumeration.UseDeviceID))
                {
                    SetCameraSize();
                    camera.DisplayLive();
                }
            }
        }

        private void SetCameraSize()
        {
            if (camera != null && camera.IsOpened())
            {
                camera.CameraSizeControl.SetAoiBounds(1392, 1080, (this.zwPictureBox.Width - 1392) / 2, 0);
            }
        }
    }
}