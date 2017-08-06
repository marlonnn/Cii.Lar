namespace Cii.Lar.UI
{
    partial class LaserCtrl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPulseWidth = new DevComponents.DotNetBar.LabelX();
            this.sliderCtrl1 = new Cii.Lar.UI.SliderCtrl();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.lblPreSet = new DevComponents.DotNetBar.LabelX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnFire = new DevComponents.DotNetBar.ButtonX();
            this.line2 = new DevComponents.DotNetBar.Controls.Line();
            this.btnAlignLaser = new DevComponents.DotNetBar.ButtonX();
            this.btnHoleSize = new DevComponents.DotNetBar.ButtonX();
            this.btnAppearance = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(248, 3);
            // 
            // lblPulseWidth
            // 
            this.lblPulseWidth.BackColor = System.Drawing.SystemColors.ActiveCaption;
            // 
            // 
            // 
            this.lblPulseWidth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPulseWidth.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPulseWidth.Location = new System.Drawing.Point(73, 37);
            this.lblPulseWidth.Name = "lblPulseWidth";
            this.lblPulseWidth.Size = new System.Drawing.Size(125, 19);
            this.lblPulseWidth.TabIndex = 2;
            this.lblPulseWidth.Text = "Pulse Width / Hole Size";
            // 
            // sliderCtrl1
            // 
            this.sliderCtrl1.Location = new System.Drawing.Point(3, 62);
            this.sliderCtrl1.Name = "sliderCtrl1";
            this.sliderCtrl1.Size = new System.Drawing.Size(261, 19);
            this.sliderCtrl1.TabIndex = 3;
            // 
            // line1
            // 
            this.line1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.line1.Location = new System.Drawing.Point(3, 21);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(261, 10);
            this.line1.TabIndex = 1;
            this.line1.Text = "line1";
            // 
            // lblPreSet
            // 
            // 
            // 
            // 
            this.lblPreSet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPreSet.Location = new System.Drawing.Point(41, 87);
            this.lblPreSet.Name = "lblPreSet";
            this.lblPreSet.Size = new System.Drawing.Size(42, 23);
            this.lblPreSet.TabIndex = 4;
            this.lblPreSet.Text = "Preset";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(167, 87);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnFire
            // 
            this.btnFire.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFire.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFire.Location = new System.Drawing.Point(88, 118);
            this.btnFire.Name = "btnFire";
            this.btnFire.Size = new System.Drawing.Size(75, 23);
            this.btnFire.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnFire.TabIndex = 6;
            this.btnFire.Text = "FIRE";
            this.btnFire.Click += new System.EventHandler(this.btnFire_Click);
            // 
            // line2
            // 
            this.line2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.line2.Location = new System.Drawing.Point(3, 156);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(261, 10);
            this.line2.TabIndex = 7;
            this.line2.Text = "line2";
            // 
            // btnAlignLaser
            // 
            this.btnAlignLaser.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAlignLaser.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAlignLaser.Location = new System.Drawing.Point(41, 189);
            this.btnAlignLaser.Name = "btnAlignLaser";
            this.btnAlignLaser.Size = new System.Drawing.Size(182, 23);
            this.btnAlignLaser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAlignLaser.TabIndex = 8;
            this.btnAlignLaser.Text = "Align Laser";
            this.btnAlignLaser.Click += new System.EventHandler(this.btnAlignLaser_Click);
            // 
            // btnHoleSize
            // 
            this.btnHoleSize.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHoleSize.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnHoleSize.Location = new System.Drawing.Point(41, 218);
            this.btnHoleSize.Name = "btnHoleSize";
            this.btnHoleSize.Size = new System.Drawing.Size(182, 23);
            this.btnHoleSize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnHoleSize.TabIndex = 9;
            this.btnHoleSize.Text = "Hole Size Calibration";
            this.btnHoleSize.Click += new System.EventHandler(this.btnHoleSize_Click);
            // 
            // btnAppearance
            // 
            this.btnAppearance.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAppearance.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAppearance.Location = new System.Drawing.Point(41, 247);
            this.btnAppearance.Name = "btnAppearance";
            this.btnAppearance.Size = new System.Drawing.Size(182, 23);
            this.btnAppearance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAppearance.TabIndex = 10;
            this.btnAppearance.Text = "Apprearance";
            this.btnAppearance.Click += new System.EventHandler(this.btnAppearance_Click);
            // 
            // LaserCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAppearance);
            this.Controls.Add(this.btnHoleSize);
            this.Controls.Add(this.btnAlignLaser);
            this.Controls.Add(this.line2);
            this.Controls.Add(this.btnFire);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblPreSet);
            this.Controls.Add(this.sliderCtrl1);
            this.Controls.Add(this.lblPulseWidth);
            this.Controls.Add(this.line1);
            this.Name = "LaserCtrl";
            this.Size = new System.Drawing.Size(267, 293);
            this.Title = "Laser Control";
            this.Controls.SetChildIndex(this.line1, 0);
            this.Controls.SetChildIndex(this.lblPulseWidth, 0);
            this.Controls.SetChildIndex(this.sliderCtrl1, 0);
            this.Controls.SetChildIndex(this.lblPreSet, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.btnFire, 0);
            this.Controls.SetChildIndex(this.line2, 0);
            this.Controls.SetChildIndex(this.btnAlignLaser, 0);
            this.Controls.SetChildIndex(this.btnHoleSize, 0);
            this.Controls.SetChildIndex(this.btnAppearance, 0);
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.LabelX lblPulseWidth;
        private SliderCtrl sliderCtrl1;
        private DevComponents.DotNetBar.Controls.Line line1;
        private DevComponents.DotNetBar.LabelX lblPreSet;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnFire;
        private DevComponents.DotNetBar.Controls.Line line2;
        private DevComponents.DotNetBar.ButtonX btnAlignLaser;
        private DevComponents.DotNetBar.ButtonX btnHoleSize;
        private DevComponents.DotNetBar.ButtonX btnAppearance;
    }
}
