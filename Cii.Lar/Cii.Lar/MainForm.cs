using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.Metro.ColorTables;
using DevComponents.DotNetBar;
using Cii.Lar.UI;
using Cii.Lar.SysClass;
using System.Drawing.Imaging;
using System.Linq;

namespace Cii.Lar
{
    public enum MeasureTools
    {
        Scale,
        Pointer,
        Line,
        Rectangular,
        Elliptical,
        Polygon,
        Circle
    }
    public partial class MainForm : DevComponents.DotNetBar.Office2007Form
    {
        private ComponentResourceManager resources;
        private SysConfig sysConfig;

        private int CurrentScalePercent = 100;
        private FilesForm filesForm;

        public MainForm()
        {
            IsMdiContainer = true;
            InitializeComponent();
            this.controlCtrl.StripButtonClickHandler += Program.ExpManager.StripButtonClickHandler;
            Program.ExpManager.ScalablePictureBox = this.scalablePictureBox;
            //this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            resources = new ComponentResourceManager(typeof(MainForm));
            sysConfig = SysConfig.GetSysConfig();
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //for test
            //string defaultImage = string.Format("{0}\\Resources\\1.bmp", System.Environment.CurrentDirectory);
            //this.scalablePictureBox.Picture = new Bitmap(defaultImage);
            this.ActiveControl = this.scalablePictureBox.PictureBox;

            sysConfig.PropertyChanged += MainForm_PropertyChanged;

        }

        private void MainForm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == sysConfig.GetPropertyName(() => sysConfig.UICulture))
            {
                sysConfig.RefreshUICulture(resources, this);
            }
        }


        private void MainForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && !e.Handled && this.scalablePictureBox.ActiveTool != DrawToolType.Pointer)
            {
                Program.ExpManager.SetMeasureTool(MeasureTools.Pointer);
                e.Handled = true;
            }
        }
    }
}