namespace Cii.Lar.UI
{
    partial class ScalablePictureBox
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
            this.scalablePictureBoxImp = new Cii.Lar.UI.ScalablePictureBoxImp();
            this.pictureTracker = new Cii.Lar.UI.PictureTracker();
            this.statisticsCtrl = new StatisticsCtrl();
            this.SuspendLayout();

            this.statisticsCtrl.Location = new System.Drawing.Point(5, 30);
            this.statisticsCtrl.Name = "statisticsCtrl";
            this.statisticsCtrl.MouseDown += StatisticsCtrl_MouseDown;
            this.statisticsCtrl.MouseMove += StatisticsCtrl_MouseMove;
            this.statisticsCtrl.MouseUp += StatisticsCtrl_MouseUp;

            // 
            // scalablePictureBoxImp
            // 
            this.scalablePictureBoxImp.BackColor = System.Drawing.Color.Gray;
            this.scalablePictureBoxImp.CurrentScalePercent = 100;
            this.scalablePictureBoxImp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scalablePictureBoxImp.Location = new System.Drawing.Point(0, 0);
            this.scalablePictureBoxImp.Name = "scalablePictureBoxImp";
            this.scalablePictureBoxImp.Picture = null;
            this.scalablePictureBoxImp.Size = new System.Drawing.Size(391, 255);
            this.scalablePictureBoxImp.TabIndex = 0;
            // 
            // pictureTracker
            // 
            this.pictureTracker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureTracker.Location = new System.Drawing.Point(233, 131);
            this.pictureTracker.Name = "pictureTracker";
            this.pictureTracker.Size = new System.Drawing.Size(137, 102);
            this.pictureTracker.TabIndex = 1;
            this.pictureTracker.ZoomRate = 0;
            this.pictureTracker.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureTracker_MouseDown);
            this.pictureTracker.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureTracker_MouseMove);
            this.pictureTracker.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureTracker_MouseUp);
            // 
            // ScalablePictureBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statisticsCtrl);
            this.Controls.Add(this.pictureTracker);
            this.Controls.Add(this.scalablePictureBoxImp);
            this.Name = "ScalablePictureBox";
            this.Size = new System.Drawing.Size(391, 255);
            this.ResumeLayout(false);

        }

        #endregion

        private ScalablePictureBoxImp scalablePictureBoxImp;
        private PictureTracker pictureTracker;
        private StatisticsCtrl statisticsCtrl;
    }
}
