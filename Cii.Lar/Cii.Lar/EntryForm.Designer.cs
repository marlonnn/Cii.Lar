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
            this.controlCtrl = new Cii.Lar.UI.ControlCtrl();
            this.zwPictureBox = new Cii.Lar.UI.ZWPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.zwPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // controlCtrl
            // 
            this.controlCtrl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.controlCtrl.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlCtrl.Location = new System.Drawing.Point(0, 0);
            this.controlCtrl.Name = "controlCtrl";
            this.controlCtrl.ShowIndex = 0;
            this.controlCtrl.Size = new System.Drawing.Size(726, 25);
            this.controlCtrl.TabIndex = 1;
            this.controlCtrl.Title = "";
            // 
            // zwPictureBox
            // 
            this.zwPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zwPictureBox.Location = new System.Drawing.Point(0, 0);
            this.zwPictureBox.Name = "zwPictureBox";
            this.zwPictureBox.OffsetX = 0;
            this.zwPictureBox.OffsetY = 0;
            this.zwPictureBox.Size = new System.Drawing.Size(726, 563);
            this.zwPictureBox.TabIndex = 0;
            this.zwPictureBox.TabStop = false;
            // 
            // EntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 560);
            this.Controls.Add(this.controlCtrl);
            this.Controls.Add(this.zwPictureBox);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "EntryForm";
            this.ShowIcon = false;
            this.Text = "Lar-100";
            ((System.ComponentModel.ISupportInitialize)(this.zwPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.ZWPictureBox zwPictureBox;
        private UI.ControlCtrl controlCtrl;
    }
}

