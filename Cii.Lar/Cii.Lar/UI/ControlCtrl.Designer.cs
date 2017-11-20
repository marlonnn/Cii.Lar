namespace Cii.Lar.UI
{
    partial class ControlCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlCtrl));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonCapture = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonVideo = new System.Windows.Forms.ToolStripButton();
            this.toolStripFiles = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.comboBoxLense = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonScale = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonMove = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLine = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRectangle = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonElliptical = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPolygon = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButtonUnit = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnUm = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDmm = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMm = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCm = new System.Windows.Forms.ToolStripMenuItem();
            this.btnInches = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMeters = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonLaser = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSetting = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openCameraLive = new System.Windows.Forms.ToolStripMenuItem();
            this.openCameraAndStop = new System.Windows.Forms.ToolStripMenuItem();
            this.closeCameraTool = new System.Windows.Forms.ToolStripMenuItem();
            this.freeRun = new System.Windows.Forms.ToolStripMenuItem();
            this.snapshot = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            resources.ApplyResources(this.closeButton, "closeButton");
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonCapture,
            this.toolStripButtonVideo,
            this.toolStripFiles,
            this.toolStripSeparator1,
            this.comboBoxLense,
            this.toolStripSeparator2,
            this.toolStripButtonZoomOut,
            this.toolStripButtonZoomIn,
            this.toolStripButtonFit,
            this.toolStripSeparator3,
            this.toolStripButtonScale,
            this.toolStripSeparator4,
            this.toolStripButtonMove,
            this.toolStripButtonLine,
            this.toolStripButtonRectangle,
            this.toolStripButtonElliptical,
            this.toolStripButtonPolygon,
            this.toolStripDropDownButtonUnit,
            this.toolStripSeparator5,
            this.toolStripButtonLaser,
            this.toolStripButtonSetting,
            this.toolStripButtonOpen,
            this.toolStripDropDownButton1});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripButtonCapture
            // 
            this.toolStripButtonCapture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCapture.Image = global::Cii.Lar.Properties.Resources.camera;
            resources.ApplyResources(this.toolStripButtonCapture, "toolStripButtonCapture");
            this.toolStripButtonCapture.Name = "toolStripButtonCapture";
            this.toolStripButtonCapture.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripButtonVideo
            // 
            this.toolStripButtonVideo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonVideo.Image = global::Cii.Lar.Properties.Resources.video;
            resources.ApplyResources(this.toolStripButtonVideo, "toolStripButtonVideo");
            this.toolStripButtonVideo.Name = "toolStripButtonVideo";
            this.toolStripButtonVideo.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripFiles
            // 
            this.toolStripFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripFiles.Image = global::Cii.Lar.Properties.Resources.files;
            resources.ApplyResources(this.toolStripFiles, "toolStripFiles");
            this.toolStripFiles.Name = "toolStripFiles";
            this.toolStripFiles.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // comboBoxLense
            // 
            this.comboBoxLense.Name = "comboBoxLense";
            resources.ApplyResources(this.comboBoxLense, "comboBoxLense");
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolStripButtonZoomOut
            // 
            this.toolStripButtonZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonZoomOut.Image = global::Cii.Lar.Properties.Resources.Zoom_out;
            resources.ApplyResources(this.toolStripButtonZoomOut, "toolStripButtonZoomOut");
            this.toolStripButtonZoomOut.Name = "toolStripButtonZoomOut";
            this.toolStripButtonZoomOut.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripButtonZoomIn
            // 
            this.toolStripButtonZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonZoomIn.Image = global::Cii.Lar.Properties.Resources.Zoom_in;
            resources.ApplyResources(this.toolStripButtonZoomIn, "toolStripButtonZoomIn");
            this.toolStripButtonZoomIn.Name = "toolStripButtonZoomIn";
            this.toolStripButtonZoomIn.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripButtonFit
            // 
            this.toolStripButtonFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFit.Image = global::Cii.Lar.Properties.Resources.zoomFit;
            resources.ApplyResources(this.toolStripButtonFit, "toolStripButtonFit");
            this.toolStripButtonFit.Name = "toolStripButtonFit";
            this.toolStripButtonFit.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // toolStripButtonScale
            // 
            this.toolStripButtonScale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonScale.Image = global::Cii.Lar.Properties.Resources.ruler;
            resources.ApplyResources(this.toolStripButtonScale, "toolStripButtonScale");
            this.toolStripButtonScale.Name = "toolStripButtonScale";
            this.toolStripButtonScale.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // toolStripButtonMove
            // 
            this.toolStripButtonMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMove.Image = global::Cii.Lar.Properties.Resources.hand;
            resources.ApplyResources(this.toolStripButtonMove, "toolStripButtonMove");
            this.toolStripButtonMove.Name = "toolStripButtonMove";
            this.toolStripButtonMove.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripButtonLine
            // 
            this.toolStripButtonLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLine.Image = global::Cii.Lar.Properties.Resources.line;
            resources.ApplyResources(this.toolStripButtonLine, "toolStripButtonLine");
            this.toolStripButtonLine.Name = "toolStripButtonLine";
            this.toolStripButtonLine.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripButtonRectangle
            // 
            this.toolStripButtonRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRectangle.Image = global::Cii.Lar.Properties.Resources.rectangular;
            resources.ApplyResources(this.toolStripButtonRectangle, "toolStripButtonRectangle");
            this.toolStripButtonRectangle.Name = "toolStripButtonRectangle";
            this.toolStripButtonRectangle.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripButtonElliptical
            // 
            this.toolStripButtonElliptical.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonElliptical.Image = global::Cii.Lar.Properties.Resources.elliptical;
            resources.ApplyResources(this.toolStripButtonElliptical, "toolStripButtonElliptical");
            this.toolStripButtonElliptical.Name = "toolStripButtonElliptical";
            this.toolStripButtonElliptical.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripButtonPolygon
            // 
            this.toolStripButtonPolygon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPolygon.Image = global::Cii.Lar.Properties.Resources.polygon;
            resources.ApplyResources(this.toolStripButtonPolygon, "toolStripButtonPolygon");
            this.toolStripButtonPolygon.Name = "toolStripButtonPolygon";
            this.toolStripButtonPolygon.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripDropDownButtonUnit
            // 
            this.toolStripDropDownButtonUnit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonUnit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUm,
            this.btnDmm,
            this.btnMm,
            this.btnCm,
            this.btnInches,
            this.btnMeters});
            this.toolStripDropDownButtonUnit.Image = global::Cii.Lar.Properties.Resources.unit;
            resources.ApplyResources(this.toolStripDropDownButtonUnit, "toolStripDropDownButtonUnit");
            this.toolStripDropDownButtonUnit.Name = "toolStripDropDownButtonUnit";
            // 
            // btnUm
            // 
            this.btnUm.Name = "btnUm";
            resources.ApplyResources(this.btnUm, "btnUm");
            this.btnUm.Click += new System.EventHandler(this.btnMenuItem_Click);
            // 
            // btnDmm
            // 
            this.btnDmm.Name = "btnDmm";
            resources.ApplyResources(this.btnDmm, "btnDmm");
            this.btnDmm.Click += new System.EventHandler(this.btnMenuItem_Click);
            // 
            // btnMm
            // 
            this.btnMm.Checked = true;
            this.btnMm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnMm.Name = "btnMm";
            resources.ApplyResources(this.btnMm, "btnMm");
            this.btnMm.Click += new System.EventHandler(this.btnMenuItem_Click);
            // 
            // btnCm
            // 
            this.btnCm.Name = "btnCm";
            resources.ApplyResources(this.btnCm, "btnCm");
            this.btnCm.Click += new System.EventHandler(this.btnMenuItem_Click);
            // 
            // btnInches
            // 
            this.btnInches.Name = "btnInches";
            resources.ApplyResources(this.btnInches, "btnInches");
            this.btnInches.Click += new System.EventHandler(this.btnMenuItem_Click);
            // 
            // btnMeters
            // 
            this.btnMeters.Name = "btnMeters";
            resources.ApplyResources(this.btnMeters, "btnMeters");
            this.btnMeters.Click += new System.EventHandler(this.btnMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // toolStripButtonLaser
            // 
            this.toolStripButtonLaser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLaser.Image = global::Cii.Lar.Properties.Resources.laser;
            resources.ApplyResources(this.toolStripButtonLaser, "toolStripButtonLaser");
            this.toolStripButtonLaser.Name = "toolStripButtonLaser";
            this.toolStripButtonLaser.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripButtonSetting
            // 
            this.toolStripButtonSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSetting.Image = global::Cii.Lar.Properties.Resources.setting;
            resources.ApplyResources(this.toolStripButtonSetting, "toolStripButtonSetting");
            this.toolStripButtonSetting.Name = "toolStripButtonSetting";
            this.toolStripButtonSetting.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpen.Image = global::Cii.Lar.Properties.Resources.open;
            resources.ApplyResources(this.toolStripButtonOpen, "toolStripButtonOpen");
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openCameraLive,
            this.openCameraAndStop,
            this.closeCameraTool,
            this.freeRun,
            this.snapshot});
            resources.ApplyResources(this.toolStripDropDownButton1, "toolStripDropDownButton1");
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            // 
            // openCameraLive
            // 
            this.openCameraLive.Name = "openCameraLive";
            resources.ApplyResources(this.openCameraLive, "openCameraLive");
            this.openCameraLive.Click += new System.EventHandler(this.openCameraLive_Click);
            // 
            // openCameraAndStop
            // 
            this.openCameraAndStop.Name = "openCameraAndStop";
            resources.ApplyResources(this.openCameraAndStop, "openCameraAndStop");
            this.openCameraAndStop.Click += new System.EventHandler(this.openCameraAndStop_Click);
            // 
            // closeCameraTool
            // 
            this.closeCameraTool.Name = "closeCameraTool";
            resources.ApplyResources(this.closeCameraTool, "closeCameraTool");
            this.closeCameraTool.Click += new System.EventHandler(this.closeCamera_Click);
            // 
            // freeRun
            // 
            this.freeRun.Name = "freeRun";
            resources.ApplyResources(this.freeRun, "freeRun");
            this.freeRun.Click += new System.EventHandler(this.freeRun_Click);
            // 
            // snapshot
            // 
            this.snapshot.Name = "snapshot";
            resources.ApplyResources(this.snapshot, "snapshot");
            this.snapshot.Click += new System.EventHandler(this.snapshot_Click);
            // 
            // ControlCtrl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Name = "ControlCtrl";
            this.Title = "";
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonCapture;
        private System.Windows.Forms.ToolStripButton toolStripButtonVideo;
        private System.Windows.Forms.ToolStripButton toolStripFiles;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox comboBoxLense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonZoomOut;
        private System.Windows.Forms.ToolStripButton toolStripButtonZoomIn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonScale;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonLine;
        private System.Windows.Forms.ToolStripButton toolStripButtonRectangle;
        private System.Windows.Forms.ToolStripButton toolStripButtonElliptical;
        private System.Windows.Forms.ToolStripButton toolStripButtonPolygon;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButtonLaser;
        private System.Windows.Forms.ToolStripButton toolStripButtonSetting;
        private System.Windows.Forms.ToolStripButton toolStripButtonFit;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonUnit;
        private System.Windows.Forms.ToolStripMenuItem btnUm;
        private System.Windows.Forms.ToolStripMenuItem btnDmm;
        private System.Windows.Forms.ToolStripMenuItem btnInches;
        private System.Windows.Forms.ToolStripMenuItem btnMeters;
        private System.Windows.Forms.ToolStripMenuItem btnMm;
        private System.Windows.Forms.ToolStripMenuItem btnCm;
        private System.Windows.Forms.ToolStripButton toolStripButtonMove;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem openCameraLive;
        private System.Windows.Forms.ToolStripMenuItem openCameraAndStop;
        private System.Windows.Forms.ToolStripMenuItem closeCameraTool;
        private System.Windows.Forms.ToolStripMenuItem freeRun;
        private System.Windows.Forms.ToolStripMenuItem snapshot;
    }
}
