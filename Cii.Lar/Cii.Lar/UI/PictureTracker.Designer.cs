﻿namespace Cii.Lar.UI
{
    partial class PictureTracker
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
            this.picturePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // picturePanel
            // 
            this.picturePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picturePanel.BackColor = System.Drawing.Color.Transparent;
            this.picturePanel.Location = new System.Drawing.Point(1, 22);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(148, 123);
            this.picturePanel.TabIndex = 1;
            this.picturePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicturePanel_MouseDown);
            this.picturePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicturePanel_MouseMove);
            this.picturePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.PicturePanel_Paint);
            this.picturePanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicturePanel_MouseUp);
            // 
            // PictureTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picturePanel);
            this.Name = "PictureTracker";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureTracker_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel picturePanel;
    }
}
