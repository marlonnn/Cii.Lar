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
            this.zwPictureBox = new Cii.Lar.UI.ZWPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.zwPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // zwPictureBox
            // 
            this.zwPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zwPictureBox.Location = new System.Drawing.Point(-5, 2);
            this.zwPictureBox.Name = "zwPictureBox";
            this.zwPictureBox.Size = new System.Drawing.Size(737, 563);
            this.zwPictureBox.Enabled = true;
            this.zwPictureBox.TabIndex = 0;
            this.zwPictureBox.TabStop = false;
            // 
            // EntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 560);
            this.Controls.Add(this.zwPictureBox);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "EntryForm";
            this.ShowIcon = false;
            this.Text = "DotNetBar Metro-Bill";
            ((System.ComponentModel.ISupportInitialize)(this.zwPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.ZWPictureBox zwPictureBox;
    }
}

