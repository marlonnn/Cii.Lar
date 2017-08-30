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
            this.scalablePictureBox = new Cii.Lar.UI.ScalablePictureBox();
            this.SuspendLayout();
            // 
            // controlCtrl
            // 
            this.controlCtrl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.controlCtrl.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlCtrl.Location = new System.Drawing.Point(0, 0);
            this.controlCtrl.Name = "controlCtrl";
            this.controlCtrl.ShowIndex = 0;
            this.controlCtrl.Size = new System.Drawing.Size(726, 23);
            this.controlCtrl.TabIndex = 0;
            this.controlCtrl.Title = "";
            // 
            // scalablePictureBox1
            // 
            this.scalablePictureBox.ActiveTool = Cii.Lar.UI.DrawToolType.None;
            this.scalablePictureBox.Location = new System.Drawing.Point(0, 23);
            this.scalablePictureBox.Name = "scalablePictureBox";
            this.scalablePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scalablePictureBox.Size = new System.Drawing.Size(391, 235);
            this.scalablePictureBox.TabIndex = 1;
            // 
            // EntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 560);
            this.Controls.Add(this.scalablePictureBox);
            this.Controls.Add(this.controlCtrl);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "EntryForm";
            this.ShowIcon = false;
            this.Text = "Lar-100";
            this.ResumeLayout(false);

        }

        #endregion

        private UI.ControlCtrl controlCtrl;
        private UI.ScalablePictureBox scalablePictureBox;
    }
}

