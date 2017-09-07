﻿namespace Cii.Lar.UI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaserCtrl));
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
            resources.ApplyResources(this.closeButton, "closeButton");
            // 
            // lblPulseWidth
            // 
            this.lblPulseWidth.BackColor = System.Drawing.SystemColors.ActiveCaption;
            // 
            // 
            // 
            this.lblPulseWidth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPulseWidth.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.lblPulseWidth, "lblPulseWidth");
            this.lblPulseWidth.Name = "lblPulseWidth";
            // 
            // sliderCtrl1
            // 
            resources.ApplyResources(this.sliderCtrl1, "sliderCtrl1");
            this.sliderCtrl1.Name = "sliderCtrl1";
            // 
            // line1
            // 
            this.line1.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.line1, "line1");
            this.line1.Name = "line1";
            // 
            // lblPreSet
            // 
            // 
            // 
            // 
            this.lblPreSet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            resources.ApplyResources(this.lblPreSet, "lblPreSet");
            this.lblPreSet.Name = "lblPreSet";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnFire
            // 
            this.btnFire.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFire.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(this.btnFire, "btnFire");
            this.btnFire.Name = "btnFire";
            this.btnFire.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnFire.Click += new System.EventHandler(this.btnFire_Click);
            // 
            // line2
            // 
            this.line2.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.line2, "line2");
            this.line2.Name = "line2";
            // 
            // btnAlignLaser
            // 
            this.btnAlignLaser.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAlignLaser.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(this.btnAlignLaser, "btnAlignLaser");
            this.btnAlignLaser.Name = "btnAlignLaser";
            this.btnAlignLaser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAlignLaser.Click += new System.EventHandler(this.btnAlignLaser_Click);
            // 
            // btnHoleSize
            // 
            this.btnHoleSize.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHoleSize.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(this.btnHoleSize, "btnHoleSize");
            this.btnHoleSize.Name = "btnHoleSize";
            this.btnHoleSize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnHoleSize.Click += new System.EventHandler(this.btnHoleSize_Click);
            // 
            // btnAppearance
            // 
            this.btnAppearance.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAppearance.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(this.btnAppearance, "btnAppearance");
            this.btnAppearance.Name = "btnAppearance";
            this.btnAppearance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAppearance.Click += new System.EventHandler(this.btnAppearance_Click);
            // 
            // LaserCtrl
            // 
            resources.ApplyResources(this, "$this");
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
            this.Title = global::Cii.Lar.Properties.Resources.StrLaserCtrlTitle;
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
