namespace Cii.Lar
{
    partial class EntryForm
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
            this.toolbarControl = new Cii.Lar.UI.ToolbarControl();
            this.zoomblePictureBoxControl = new Cii.Lar.UI.Picture.ZoomblePictureBoxControl();
            this.SuspendLayout();
            // 
            // toolbarControl
            // 
            this.toolbarControl.BackColor = System.Drawing.Color.Transparent;
            this.toolbarControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbarControl.LinkedPictureBox = null;
            this.toolbarControl.Location = new System.Drawing.Point(0, 0);
            this.toolbarControl.Name = "toolbarControl";
            this.toolbarControl.Size = new System.Drawing.Size(1143, 39);
            this.toolbarControl.TabIndex = 0;
            // 
            // zoomblePictureBoxControl
            // 
            this.zoomblePictureBoxControl.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.zoomblePictureBoxControl.BackgroundImagePixelSize_Mic = 100;
            this.zoomblePictureBoxControl.ClickAction = Cii.Lar.UI.Picture.PublicTypes.enClickAction.Zoom;
            this.zoomblePictureBoxControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.zoomblePictureBoxControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zoomblePictureBoxControl.Image = null;
            this.zoomblePictureBoxControl.ImageCustomOrigin = new System.Drawing.Point(0, 0);
            this.zoomblePictureBoxControl.ImagePosition = Cii.Lar.UI.Picture.enBitmapOriginPosition.TopLeft;
            this.zoomblePictureBoxControl.Location = new System.Drawing.Point(0, 39);
            this.zoomblePictureBoxControl.Name = "zoomblePictureBoxControl";
            this.zoomblePictureBoxControl.Size = new System.Drawing.Size(1143, 640);
            this.zoomblePictureBoxControl.SmartGridAdjust = true;
            this.zoomblePictureBoxControl.TabIndex = 1;
            this.zoomblePictureBoxControl.UnitOfMeasure = Cii.Lar.UI.Picture.MeasureSystem.enUniMis.mm;
            // 
            // EntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 627);
            this.Controls.Add(this.zoomblePictureBoxControl);
            this.Controls.Add(this.toolbarControl);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "EntryForm";
            this.ShowIcon = false;
            this.Text = "Lar - 100";
            this.ResumeLayout(false);

        }

        #endregion

        private UI.ToolbarControl toolbarControl;
        private UI.Picture.ZoomblePictureBoxControl zoomblePictureBoxControl;
    }
}

