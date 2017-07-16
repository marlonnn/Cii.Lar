using System;
using Cii.Lar.UI;

namespace Cii.Lar
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.metroStatusBar1 = new DevComponents.DotNetBar.Metro.MetroStatusBar();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.scalablePictureBox = new Cii.Lar.UI.ScalablePictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonCapture = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonVideo = new System.Windows.Forms.ToolStripButton();
            this.toolStripFiles = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonScale = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMeasure = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLaser = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSetting = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroStatusBar1
            // 
            this.metroStatusBar1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.metroStatusBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroStatusBar1.ContainerControlProcessDialogKey = true;
            this.metroStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroStatusBar1.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroStatusBar1.ForeColor = System.Drawing.Color.Black;
            this.metroStatusBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem1});
            this.metroStatusBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.metroStatusBar1.Location = new System.Drawing.Point(0, 503);
            this.metroStatusBar1.Name = "metroStatusBar1";
            this.metroStatusBar1.Size = new System.Drawing.Size(740, 20);
            this.metroStatusBar1.TabIndex = 1;
            this.metroStatusBar1.Text = "metroStatusBar1";
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "Ready";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))));
            // 
            // scalablePictureBox
            // 
            this.scalablePictureBox.BackColor = System.Drawing.Color.White;
            this.scalablePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scalablePictureBox.ForeColor = System.Drawing.Color.Black;
            this.scalablePictureBox.Location = new System.Drawing.Point(0, 0);
            this.scalablePictureBox.Name = "scalablePictureBox";
            this.scalablePictureBox.Size = new System.Drawing.Size(740, 503);
            this.scalablePictureBox.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonCapture,
            this.toolStripButtonVideo,
            this.toolStripFiles,
            this.toolStripComboBox1,
            this.toolStripButtonZoomOut,
            this.toolStripButtonZoomIn,
            this.toolStripButtonScale,
            this.toolStripButtonMeasure,
            this.toolStripButtonLaser,
            this.toolStripButtonSetting});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(740, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonCapture
            // 
            this.toolStripButtonCapture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCapture.Image = global::Cii.Lar.Properties.Resources.camera;
            this.toolStripButtonCapture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCapture.Name = "toolStripButtonCapture";
            this.toolStripButtonCapture.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCapture.Text = "toolStripButtonCapture";
            this.toolStripButtonCapture.ToolTipText = "Screen Capture";
            this.toolStripButtonCapture.Click += new System.EventHandler(this.toolStripButtonCapture_Click);
            // 
            // toolStripButtonVideo
            // 
            this.toolStripButtonVideo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonVideo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonVideo.Image")));
            this.toolStripButtonVideo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonVideo.Name = "toolStripButtonVideo";
            this.toolStripButtonVideo.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonVideo.Text = "toolStripButtonVideo";
            this.toolStripButtonVideo.ToolTipText = "Catch Video";
            this.toolStripButtonVideo.Click += new System.EventHandler(this.toolStripButtonVideo_Click);
            // 
            // toolStripFiles
            // 
            this.toolStripFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripFiles.Image = global::Cii.Lar.Properties.Resources.files;
            this.toolStripFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripFiles.Name = "toolStripFiles";
            this.toolStripFiles.Size = new System.Drawing.Size(23, 22);
            this.toolStripFiles.Text = "toolStripFiles";
            this.toolStripFiles.ToolTipText = "File Archiving";
            this.toolStripFiles.Click += new System.EventHandler(this.toolStripFiles_Click);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(80, 25);
            // 
            // toolStripButtonZoomOut
            // 
            this.toolStripButtonZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonZoomOut.Image = global::Cii.Lar.Properties.Resources.Zoom_out;
            this.toolStripButtonZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonZoomOut.Name = "toolStripButtonZoomOut";
            this.toolStripButtonZoomOut.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonZoomOut.Text = "toolStripButtonZoomOut";
            this.toolStripButtonZoomOut.ToolTipText = "Zoom Out";
            this.toolStripButtonZoomOut.Click += new System.EventHandler(this.toolStripButtonZoomOut_Click);
            // 
            // toolStripButtonZoomIn
            // 
            this.toolStripButtonZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonZoomIn.Image = global::Cii.Lar.Properties.Resources.Zoom_in;
            this.toolStripButtonZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonZoomIn.Name = "toolStripButtonZoomIn";
            this.toolStripButtonZoomIn.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonZoomIn.Text = "toolStripButtonZoomIn";
            this.toolStripButtonZoomIn.ToolTipText = "Zoom In";
            this.toolStripButtonZoomIn.Click += new System.EventHandler(this.toolStripButtonZoomIn_Click);
            // 
            // toolStripButtonScale
            // 
            this.toolStripButtonScale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonScale.Image = global::Cii.Lar.Properties.Resources.scale;
            this.toolStripButtonScale.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonScale.Name = "toolStripButtonScale";
            this.toolStripButtonScale.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonScale.Text = "toolStripButtonScale";
            this.toolStripButtonScale.ToolTipText = "Scale";
            this.toolStripButtonScale.Click += new System.EventHandler(this.toolStripButtonScale_Click);
            // 
            // toolStripButtonMeasure
            // 
            this.toolStripButtonMeasure.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMeasure.Image = global::Cii.Lar.Properties.Resources.measure;
            this.toolStripButtonMeasure.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMeasure.Name = "toolStripButtonMeasure";
            this.toolStripButtonMeasure.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonMeasure.Text = "toolStripButtonMeasure";
            this.toolStripButtonMeasure.ToolTipText = "Measure";
            this.toolStripButtonMeasure.Click += new System.EventHandler(this.toolStripButtonMeasure_Click);
            // 
            // toolStripButtonLaser
            // 
            this.toolStripButtonLaser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLaser.Image = global::Cii.Lar.Properties.Resources.laser;
            this.toolStripButtonLaser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLaser.Name = "toolStripButtonLaser";
            this.toolStripButtonLaser.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonLaser.Text = "toolStripButtonLaser";
            this.toolStripButtonLaser.ToolTipText = "Laser";
            this.toolStripButtonLaser.Click += new System.EventHandler(this.toolStripButtonLaser_Click);
            // 
            // toolStripButtonSetting
            // 
            this.toolStripButtonSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSetting.Image = global::Cii.Lar.Properties.Resources.setting;
            this.toolStripButtonSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSetting.Name = "toolStripButtonSetting";
            this.toolStripButtonSetting.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSetting.Text = "toolStripButtonSetting";
            this.toolStripButtonSetting.ToolTipText = "Setting";
            this.toolStripButtonSetting.Click += new System.EventHandler(this.toolStripButtonSetting_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(740, 523);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.scalablePictureBox);
            this.Controls.Add(this.metroStatusBar1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Lar-100";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevComponents.DotNetBar.Metro.MetroStatusBar metroStatusBar1;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private ScalablePictureBox scalablePictureBox;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonCapture;
        private System.Windows.Forms.ToolStripButton toolStripButtonVideo;
        private System.Windows.Forms.ToolStripButton toolStripFiles;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripButton toolStripButtonZoomOut;
        private System.Windows.Forms.ToolStripButton toolStripButtonZoomIn;
        private System.Windows.Forms.ToolStripButton toolStripButtonScale;
        private System.Windows.Forms.ToolStripButton toolStripButtonMeasure;
        private System.Windows.Forms.ToolStripButton toolStripButtonLaser;
        private System.Windows.Forms.ToolStripButton toolStripButtonSetting;
    }
}

