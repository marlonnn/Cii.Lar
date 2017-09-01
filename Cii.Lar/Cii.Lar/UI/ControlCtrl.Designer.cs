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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonCapture = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonVideo = new System.Windows.Forms.ToolStripButton();
            this.toolStripFiles = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonScale = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
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
            this.toolStripButtonMove = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(575, 0);
            this.closeButton.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonCapture,
            this.toolStripButtonVideo,
            this.toolStripFiles,
            this.toolStripSeparator1,
            this.toolStripComboBox1,
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
            this.toolStripButtonOpen});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(725, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonCapture
            // 
            this.toolStripButtonCapture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCapture.Image = global::Cii.Lar.Properties.Resources.camera;
            this.toolStripButtonCapture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCapture.Name = "toolStripButtonCapture";
            this.toolStripButtonCapture.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCapture.Text = global::Cii.Lar.Properties.Resources.toolStripButtonCaptureStr;
            this.toolStripButtonCapture.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripButtonVideo
            // 
            this.toolStripButtonVideo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonVideo.Image = global::Cii.Lar.Properties.Resources.video;
            this.toolStripButtonVideo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonVideo.Name = "toolStripButtonVideo";
            this.toolStripButtonVideo.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonVideo.Text = global::Cii.Lar.Properties.Resources.toolStripButtonVideoStr;
            this.toolStripButtonVideo.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripFiles
            // 
            this.toolStripFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripFiles.Image = global::Cii.Lar.Properties.Resources.files;
            this.toolStripFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripFiles.Name = "toolStripFiles";
            this.toolStripFiles.Size = new System.Drawing.Size(23, 22);
            this.toolStripFiles.Text = global::Cii.Lar.Properties.Resources.toolStripFilesStr;
            this.toolStripFiles.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(80, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonZoomOut
            // 
            this.toolStripButtonZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonZoomOut.Image = global::Cii.Lar.Properties.Resources.Zoom_out;
            this.toolStripButtonZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonZoomOut.Name = "toolStripButtonZoomOut";
            this.toolStripButtonZoomOut.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonZoomOut.Text = global::Cii.Lar.Properties.Resources.toolStripButtonZoomOutStr;
            this.toolStripButtonZoomOut.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripButtonZoomIn
            // 
            this.toolStripButtonZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonZoomIn.Image = global::Cii.Lar.Properties.Resources.Zoom_in;
            this.toolStripButtonZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonZoomIn.Name = "toolStripButtonZoomIn";
            this.toolStripButtonZoomIn.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonZoomIn.Text = global::Cii.Lar.Properties.Resources.toolStripButtonZoomInStr;
            this.toolStripButtonZoomIn.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripButtonFit
            // 
            this.toolStripButtonFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFit.Image = global::Cii.Lar.Properties.Resources.zoomFit;
            this.toolStripButtonFit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFit.Name = "toolStripButtonFit";
            this.toolStripButtonFit.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonFit.Text = "Zoom Fit";
            this.toolStripButtonFit.ToolTipText = "Zoom Fit";
            this.toolStripButtonFit.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonScale
            // 
            this.toolStripButtonScale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonScale.Image = global::Cii.Lar.Properties.Resources.ruler;
            this.toolStripButtonScale.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonScale.Name = "toolStripButtonScale";
            this.toolStripButtonScale.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonScale.Text = global::Cii.Lar.Properties.Resources.toolStripButtonScaleStr;
            this.toolStripButtonScale.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonLine
            // 
            this.toolStripButtonLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLine.Image = global::Cii.Lar.Properties.Resources.line;
            this.toolStripButtonLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLine.Name = "toolStripButtonLine";
            this.toolStripButtonLine.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonLine.Text = global::Cii.Lar.Properties.Resources.toolStripButtonLineStr;
            this.toolStripButtonLine.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripButtonRectangle
            // 
            this.toolStripButtonRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRectangle.Image = global::Cii.Lar.Properties.Resources.rectangular;
            this.toolStripButtonRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRectangle.Name = "toolStripButtonRectangle";
            this.toolStripButtonRectangle.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRectangle.Text = global::Cii.Lar.Properties.Resources.toolStripButtonRectangleStr;
            this.toolStripButtonRectangle.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripButtonElliptical
            // 
            this.toolStripButtonElliptical.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonElliptical.Image = global::Cii.Lar.Properties.Resources.elliptical;
            this.toolStripButtonElliptical.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonElliptical.Name = "toolStripButtonElliptical";
            this.toolStripButtonElliptical.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonElliptical.Text = global::Cii.Lar.Properties.Resources.toolStripButtonEllipticalStr;
            this.toolStripButtonElliptical.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripButtonPolygon
            // 
            this.toolStripButtonPolygon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPolygon.Image = global::Cii.Lar.Properties.Resources.polygon;
            this.toolStripButtonPolygon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPolygon.Name = "toolStripButtonPolygon";
            this.toolStripButtonPolygon.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonPolygon.Text = global::Cii.Lar.Properties.Resources.toolStripButtonPolygonStr;
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
            this.toolStripDropDownButtonUnit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonUnit.Name = "toolStripDropDownButtonUnit";
            this.toolStripDropDownButtonUnit.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButtonUnit.Text = "toolStripDropDownButton1";
            // 
            // btnUm
            // 
            this.btnUm.Name = "btnUm";
            this.btnUm.Size = new System.Drawing.Size(113, 22);
            this.btnUm.Text = "um";
            this.btnUm.ToolTipText = "um";
            this.btnUm.Click += new System.EventHandler(this.btnMenuItem_Click);
            // 
            // btnDmm
            // 
            this.btnDmm.Name = "btnDmm";
            this.btnDmm.Size = new System.Drawing.Size(113, 22);
            this.btnDmm.Text = "mm/10";
            this.btnDmm.ToolTipText = "mm/10";
            this.btnDmm.Click += new System.EventHandler(this.btnMenuItem_Click);
            // 
            // btnMm
            // 
            this.btnMm.Checked = true;
            this.btnMm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnMm.Name = "btnMm";
            this.btnMm.Size = new System.Drawing.Size(113, 22);
            this.btnMm.Text = "mm";
            this.btnMm.ToolTipText = "mm";
            this.btnMm.Click += new System.EventHandler(this.btnMenuItem_Click);
            // 
            // btnCm
            // 
            this.btnCm.Name = "btnCm";
            this.btnCm.Size = new System.Drawing.Size(113, 22);
            this.btnCm.Text = "cm";
            this.btnCm.ToolTipText = "cm";
            this.btnCm.Click += new System.EventHandler(this.btnMenuItem_Click);
            // 
            // btnInches
            // 
            this.btnInches.Name = "btnInches";
            this.btnInches.Size = new System.Drawing.Size(113, 22);
            this.btnInches.Text = "inches";
            this.btnInches.ToolTipText = "inches";
            this.btnInches.Click += new System.EventHandler(this.btnMenuItem_Click);
            // 
            // btnMeters
            // 
            this.btnMeters.Name = "btnMeters";
            this.btnMeters.Size = new System.Drawing.Size(113, 22);
            this.btnMeters.Text = "meters";
            this.btnMeters.ToolTipText = "meters";
            this.btnMeters.Click += new System.EventHandler(this.btnMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonLaser
            // 
            this.toolStripButtonLaser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLaser.Image = global::Cii.Lar.Properties.Resources.laser;
            this.toolStripButtonLaser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLaser.Name = "toolStripButtonLaser";
            this.toolStripButtonLaser.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonLaser.Text = global::Cii.Lar.Properties.Resources.toolStripButtonLaserStr;
            this.toolStripButtonLaser.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripButtonSetting
            // 
            this.toolStripButtonSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSetting.Image = global::Cii.Lar.Properties.Resources.setting;
            this.toolStripButtonSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSetting.Name = "toolStripButtonSetting";
            this.toolStripButtonSetting.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSetting.Text = global::Cii.Lar.Properties.Resources.toolStripButtonSettingStr;
            this.toolStripButtonSetting.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpen.Image = global::Cii.Lar.Properties.Resources.open;
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOpen.Text = "Open";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // toolStripButtonMove
            // 
            this.toolStripButtonMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMove.Image = global::Cii.Lar.Properties.Resources.hand;
            this.toolStripButtonMove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMove.Name = "toolStripButtonMove";
            this.toolStripButtonMove.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonMove.Text = "Move";
            this.toolStripButtonMove.Click += new System.EventHandler(this.toolStripButtonClick);
            // 
            // ControlCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Name = "ControlCtrl";
            this.Size = new System.Drawing.Size(725, 25);
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
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
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
    }
}
