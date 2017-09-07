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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntryForm));
            this.controlCtrl = new Cii.Lar.UI.ControlCtrl();
            this.zwPictureBox = new Cii.Lar.UI.ZWPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.zwPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // controlCtrl
            // 
            resources.ApplyResources(this.controlCtrl, "controlCtrl");
            this.controlCtrl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.controlCtrl.Name = "controlCtrl";
            this.controlCtrl.PictureBox = null;
            this.controlCtrl.ShowIndex = 0;
            this.controlCtrl.Title = "";
            // 
            // zwPictureBox
            // 
            resources.ApplyResources(this.zwPictureBox, "zwPictureBox");
            this.zwPictureBox.Name = "zwPictureBox";
            this.zwPictureBox.OffsetX = 0;
            this.zwPictureBox.OffsetY = 0;
            this.zwPictureBox.TabStop = false;
            this.zwPictureBox.UnitOfMeasure = Cii.Lar.DrawTools.enUniMis.mm;
            this.zwPictureBox.Zoom = 1F;
            // 
            // EntryForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.controlCtrl);
            this.Controls.Add(this.zwPictureBox);
            this.Name = "EntryForm";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.zwPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.ZWPictureBox zwPictureBox;
        private UI.ControlCtrl controlCtrl;
    }
}

