namespace Cii.Lar.UI
{
    partial class ToolbarControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btScreenShort = new System.Windows.Forms.ToolStripButton();
            this.btVideo = new System.Windows.Forms.ToolStripButton();
            this.btFiles = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btMeasure = new System.Windows.Forms.ToolStripDropDownButton();
            this.btLine = new System.Windows.Forms.ToolStripMenuItem();
            this.btRectangle = new System.Windows.Forms.ToolStripMenuItem();
            this.btEllipse = new System.Windows.Forms.ToolStripMenuItem();
            this.btPloygon = new System.Windows.Forms.ToolStripMenuItem();
            this.btView = new System.Windows.Forms.ToolStripDropDownButton();
            this.btViewRulers = new System.Windows.Forms.ToolStripMenuItem();
            this.btViewGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.btFullLines = new System.Windows.Forms.ToolStripMenuItem();
            this.btPoints = new System.Windows.Forms.ToolStripMenuItem();
            this.btCrosses = new System.Windows.Forms.ToolStripMenuItem();
            this.btUm = new System.Windows.Forms.ToolStripDropDownButton();
            this.btUmMicron = new System.Windows.Forms.ToolStripMenuItem();
            this.btUmDmm = new System.Windows.Forms.ToolStripMenuItem();
            this.btUmMillimeters = new System.Windows.Forms.ToolStripMenuItem();
            this.btUmInch = new System.Windows.Forms.ToolStripMenuItem();
            this.btUmMeters = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btZoom = new System.Windows.Forms.ToolStripButton();
            this.btZoomFit = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btLoad = new System.Windows.Forms.ToolStripButton();
            this.btSetting = new System.Windows.Forms.ToolStripButton();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.AutoSize = false;
            this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btScreenShort,
            this.btVideo,
            this.btFiles,
            this.ToolStripSeparator1,
            this.btMeasure,
            this.btView,
            this.btUm,
            this.ToolStripSeparator2,
            this.btZoom,
            this.btZoomFit,
            this.ToolStripSeparator3,
            this.btLoad,
            this.btSetting});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(552, 39);
            this.ToolStrip1.TabIndex = 78;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // btScreenShort
            // 
            this.btScreenShort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btScreenShort.Image = global::Cii.Lar.Properties.Resources.screenshort;
            this.btScreenShort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btScreenShort.Name = "btScreenShort";
            this.btScreenShort.Size = new System.Drawing.Size(36, 36);
            this.btScreenShort.Text = "Capture Screen";
            this.btScreenShort.Click += new System.EventHandler(this.btSreenShort_Click);
            // 
            // btVideo
            // 
            this.btVideo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btVideo.Image = global::Cii.Lar.Properties.Resources.video;
            this.btVideo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btVideo.Name = "btVideo";
            this.btVideo.Size = new System.Drawing.Size(36, 36);
            this.btVideo.Text = "Capture Video";
            this.btVideo.Click += new System.EventHandler(this.btVideo_Click);
            // 
            // btFiles
            // 
            this.btFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btFiles.Image = global::Cii.Lar.Properties.Resources.files;
            this.btFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btFiles.Name = "btFiles";
            this.btFiles.Size = new System.Drawing.Size(36, 36);
            this.btFiles.Text = "Assign Files";
            this.btFiles.ToolTipText = "Assign Files";
            this.btFiles.Click += new System.EventHandler(this.btFiles_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // btMeasure
            // 
            this.btMeasure.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btMeasure.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btLine,
            this.btRectangle,
            this.btEllipse,
            this.btPloygon});
            this.btMeasure.Image = global::Cii.Lar.Properties.Resources.measure;
            this.btMeasure.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btMeasure.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btMeasure.Name = "btMeasure";
            this.btMeasure.Size = new System.Drawing.Size(45, 36);
            this.btMeasure.Text = "Gauging mode";
            this.btMeasure.ToolTipText = "Gauging mode";
            // 
            // btLine
            // 
            this.btLine.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btLine.Name = "btLine";
            this.btLine.Size = new System.Drawing.Size(152, 22);
            this.btLine.Text = "Line";
            this.btLine.ToolTipText = "Line";
            this.btLine.Click += new System.EventHandler(this.drawTool_Click);
            // 
            // btRectangle
            // 
            this.btRectangle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btRectangle.Name = "btRectangle";
            this.btRectangle.Size = new System.Drawing.Size(152, 22);
            this.btRectangle.Text = "Rectangle";
            this.btRectangle.ToolTipText = "Rectangle";
            this.btRectangle.Click += new System.EventHandler(this.drawTool_Click);
            // 
            // btEllipse
            // 
            this.btEllipse.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btEllipse.Name = "btEllipse";
            this.btEllipse.Size = new System.Drawing.Size(152, 22);
            this.btEllipse.Text = "Ellipse";
            this.btEllipse.Click += new System.EventHandler(this.drawTool_Click);
            // 
            // btPloygon
            // 
            this.btPloygon.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btPloygon.Name = "btPloygon";
            this.btPloygon.Size = new System.Drawing.Size(152, 22);
            this.btPloygon.Text = "Ploygon";
            this.btPloygon.ToolTipText = "Ploygon";
            this.btPloygon.Click += new System.EventHandler(this.drawTool_Click);
            // 
            // btView
            // 
            this.btView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btViewRulers,
            this.btViewGrid});
            this.btView.Image = global::Cii.Lar.Properties.Resources.view;
            this.btView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btView.Name = "btView";
            this.btView.Size = new System.Drawing.Size(45, 36);
            this.btView.Text = "Visible items";
            this.btView.ToolTipText = "Visible items";
            // 
            // btViewRulers
            // 
            this.btViewRulers.Checked = true;
            this.btViewRulers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btViewRulers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btViewRulers.Name = "btViewRulers";
            this.btViewRulers.Size = new System.Drawing.Size(138, 22);
            this.btViewRulers.Text = "Rulers";
            this.btViewRulers.Click += new System.EventHandler(this.btViewRulers_Click);
            // 
            // btViewGrid
            // 
            this.btViewGrid.Checked = true;
            this.btViewGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btViewGrid.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btFullLines,
            this.btPoints,
            this.btCrosses});
            this.btViewGrid.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btViewGrid.Name = "btViewGrid";
            this.btViewGrid.Size = new System.Drawing.Size(138, 22);
            this.btViewGrid.Text = "Grid Type";
            this.btViewGrid.Click += new System.EventHandler(this.btViewGrid_Click);
            // 
            // btFullLines
            // 
            this.btFullLines.Name = "btFullLines";
            this.btFullLines.Size = new System.Drawing.Size(128, 22);
            this.btFullLines.Text = "Full Lines";
            this.btFullLines.ToolTipText = "Full Lines";
            this.btFullLines.Click += new System.EventHandler(this.ChooseGrid_Click);
            // 
            // btPoints
            // 
            this.btPoints.Name = "btPoints";
            this.btPoints.Size = new System.Drawing.Size(128, 22);
            this.btPoints.Text = "Points";
            this.btPoints.ToolTipText = "Points";
            this.btPoints.Click += new System.EventHandler(this.ChooseGrid_Click);
            // 
            // btCrosses
            // 
            this.btCrosses.Name = "btCrosses";
            this.btCrosses.Size = new System.Drawing.Size(128, 22);
            this.btCrosses.Text = "Crosses";
            this.btCrosses.ToolTipText = "Crosses";
            this.btCrosses.Click += new System.EventHandler(this.ChooseGrid_Click);
            // 
            // btUm
            // 
            this.btUm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btUm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btUmMicron,
            this.btUmDmm,
            this.btUmMillimeters,
            this.btUmInch,
            this.btUmMeters});
            this.btUm.Image = global::Cii.Lar.Properties.Resources.um;
            this.btUm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btUm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btUm.Name = "btUm";
            this.btUm.Size = new System.Drawing.Size(45, 36);
            this.btUm.Text = "Measure unit";
            this.btUm.ToolTipText = "Measure unit";
            // 
            // btUmMicron
            // 
            this.btUmMicron.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btUmMicron.Name = "btUmMicron";
            this.btUmMicron.Size = new System.Drawing.Size(117, 22);
            this.btUmMicron.Text = "micron";
            this.btUmMicron.Click += new System.EventHandler(this.btUmMicron_Click);
            // 
            // btUmDmm
            // 
            this.btUmDmm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btUmDmm.Name = "btUmDmm";
            this.btUmDmm.Size = new System.Drawing.Size(117, 22);
            this.btUmDmm.Text = "mm/10";
            this.btUmDmm.Click += new System.EventHandler(this.btUmMicron_Click);
            // 
            // btUmMillimeters
            // 
            this.btUmMillimeters.Checked = true;
            this.btUmMillimeters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btUmMillimeters.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btUmMillimeters.Name = "btUmMillimeters";
            this.btUmMillimeters.Size = new System.Drawing.Size(117, 22);
            this.btUmMillimeters.Text = "mm";
            this.btUmMillimeters.Click += new System.EventHandler(this.btUmMicron_Click);
            // 
            // btUmInch
            // 
            this.btUmInch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btUmInch.Name = "btUmInch";
            this.btUmInch.Size = new System.Drawing.Size(117, 22);
            this.btUmInch.Text = "inches";
            this.btUmInch.Click += new System.EventHandler(this.btUmMicron_Click);
            // 
            // btUmMeters
            // 
            this.btUmMeters.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btUmMeters.Name = "btUmMeters";
            this.btUmMeters.Size = new System.Drawing.Size(117, 22);
            this.btUmMeters.Text = "meters";
            this.btUmMeters.Click += new System.EventHandler(this.btUmMicron_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // btZoom
            // 
            this.btZoom.Checked = true;
            this.btZoom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btZoom.Image = global::Cii.Lar.Properties.Resources.zoom;
            this.btZoom.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btZoom.Name = "btZoom";
            this.btZoom.Size = new System.Drawing.Size(36, 36);
            this.btZoom.Text = "Zoom mode";
            this.btZoom.ToolTipText = "Zoom mode";
            this.btZoom.Click += new System.EventHandler(this.btZoom_Click);
            // 
            // btZoomFit
            // 
            this.btZoomFit.Checked = true;
            this.btZoomFit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btZoomFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btZoomFit.Image = global::Cii.Lar.Properties.Resources.zoomFit;
            this.btZoomFit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btZoomFit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btZoomFit.Name = "btZoomFit";
            this.btZoomFit.Size = new System.Drawing.Size(36, 36);
            this.btZoomFit.Text = "Zoom Fit";
            this.btZoomFit.ToolTipText = "Zoom Fit";
            this.btZoomFit.Click += new System.EventHandler(this.btZoomFit_Click);
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // btLoad
            // 
            this.btLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btLoad.Image = global::Cii.Lar.Properties.Resources.open;
            this.btLoad.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(36, 36);
            this.btLoad.Text = "ToolStripButton2";
            this.btLoad.ToolTipText = "Load Image";
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // btSetting
            // 
            this.btSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btSetting.Image = global::Cii.Lar.Properties.Resources.setting;
            this.btSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btSetting.Name = "btSetting";
            this.btSetting.Size = new System.Drawing.Size(36, 36);
            this.btSetting.Text = "Setting";
            this.btSetting.Click += new System.EventHandler(this.btSetting_Click);
            // 
            // ToolbarControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ToolStrip1);
            this.Name = "ToolbarControl";
            this.Size = new System.Drawing.Size(552, 39);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.ToolTip ToolTip1;
        private System.Windows.Forms.ToolStrip ToolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton btMeasure;
        private System.Windows.Forms.ToolStripButton btZoom;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton btView;
        private System.Windows.Forms.ToolStripMenuItem btViewRulers;
        private System.Windows.Forms.ToolStripMenuItem btViewGrid;
        private System.Windows.Forms.ToolStripButton btLoad;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton btUm;
        private System.Windows.Forms.ToolStripMenuItem btUmMicron;
        private System.Windows.Forms.ToolStripMenuItem btUmMillimeters;
        private System.Windows.Forms.ToolStripMenuItem btUmInch;
        private System.Windows.Forms.ToolStripMenuItem btUmMeters;
        private System.Windows.Forms.ToolStripMenuItem btUmDmm;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btZoomFit;
        #endregion

        private System.Windows.Forms.ToolStripButton btScreenShort;
        private System.Windows.Forms.ToolStripButton btVideo;
        private System.Windows.Forms.ToolStripButton btFiles;
        private System.Windows.Forms.ToolStripMenuItem btLine;
        private System.Windows.Forms.ToolStripMenuItem btRectangle;
        private System.Windows.Forms.ToolStripMenuItem btEllipse;
        private System.Windows.Forms.ToolStripMenuItem btPloygon;
        private System.Windows.Forms.ToolStripButton btSetting;
        private System.Windows.Forms.ToolStripMenuItem btFullLines;
        private System.Windows.Forms.ToolStripMenuItem btPoints;
        private System.Windows.Forms.ToolStripMenuItem btCrosses;
    }
}
