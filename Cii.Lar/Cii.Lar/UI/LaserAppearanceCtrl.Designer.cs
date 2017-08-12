namespace Cii.Lar.UI
{
    partial class LaserAppearanceCtrl
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
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.lblSowHoleSize = new DevComponents.DotNetBar.LabelX();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.lblTransparency = new DevComponents.DotNetBar.LabelX();
            this.sliderTransparency = new DevComponents.DotNetBar.Controls.Slider();
            this.lblThickness = new DevComponents.DotNetBar.LabelX();
            this.sliderThickness = new DevComponents.DotNetBar.Controls.Slider();
            this.lblTargerSize = new DevComponents.DotNetBar.LabelX();
            this.sliderTargetSize = new DevComponents.DotNetBar.Controls.Slider();
            this.lblZoneSize = new DevComponents.DotNetBar.LabelX();
            this.sliderZoneSize = new DevComponents.DotNetBar.Controls.Slider();
            this.lblZoneColour = new DevComponents.DotNetBar.LabelX();
            this.sliderZoneColour = new DevComponents.DotNetBar.Controls.Slider();
            this.btnLaserCtrl = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(296, 3);
            // 
            // line1
            // 
            this.line1.Location = new System.Drawing.Point(3, 16);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(309, 10);
            this.line1.TabIndex = 1;
            this.line1.Text = "line1";
            // 
            // lblSowHoleSize
            // 
            // 
            // 
            // 
            this.lblSowHoleSize.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSowHoleSize.Location = new System.Drawing.Point(3, 31);
            this.lblSowHoleSize.Name = "lblSowHoleSize";
            this.lblSowHoleSize.Size = new System.Drawing.Size(142, 21);
            this.lblSowHoleSize.TabIndex = 2;
            this.lblSowHoleSize.Text = "Show Hole Size";
            // 
            // checkBoxX1
            // 
            // 
            // 
            // 
            this.checkBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX1.Location = new System.Drawing.Point(151, 32);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(22, 21);
            this.checkBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX1.TabIndex = 3;
            // 
            // lblTransparency
            // 
            // 
            // 
            // 
            this.lblTransparency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTransparency.Location = new System.Drawing.Point(3, 58);
            this.lblTransparency.Name = "lblTransparency";
            this.lblTransparency.Size = new System.Drawing.Size(142, 21);
            this.lblTransparency.TabIndex = 4;
            this.lblTransparency.Text = "Transparency";
            // 
            // sliderTransparency
            // 
            // 
            // 
            // 
            this.sliderTransparency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.sliderTransparency.LabelVisible = false;
            this.sliderTransparency.Location = new System.Drawing.Point(150, 58);
            this.sliderTransparency.Name = "sliderTransparency";
            this.sliderTransparency.Size = new System.Drawing.Size(150, 21);
            this.sliderTransparency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sliderTransparency.TabIndex = 5;
            this.sliderTransparency.Value = 0;
            this.sliderTransparency.ValueChanged += new System.EventHandler(this.sliderTransparency_ValueChanged);
            // 
            // lblThickness
            // 
            // 
            // 
            // 
            this.lblThickness.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblThickness.Location = new System.Drawing.Point(3, 85);
            this.lblThickness.Name = "lblThickness";
            this.lblThickness.Size = new System.Drawing.Size(142, 21);
            this.lblThickness.TabIndex = 6;
            this.lblThickness.Text = "Line Thickness";
            // 
            // sliderThickness
            // 
            // 
            // 
            // 
            this.sliderThickness.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.sliderThickness.LabelVisible = false;
            this.sliderThickness.Location = new System.Drawing.Point(150, 85);
            this.sliderThickness.Name = "sliderThickness";
            this.sliderThickness.Size = new System.Drawing.Size(150, 21);
            this.sliderThickness.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sliderThickness.TabIndex = 7;
            this.sliderThickness.Value = 0;
            this.sliderThickness.ValueChanged += new System.EventHandler(this.sliderThickness_ValueChanged);
            // 
            // lblTargerSize
            // 
            // 
            // 
            // 
            this.lblTargerSize.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTargerSize.Location = new System.Drawing.Point(3, 112);
            this.lblTargerSize.Name = "lblTargerSize";
            this.lblTargerSize.Size = new System.Drawing.Size(142, 21);
            this.lblTargerSize.TabIndex = 8;
            this.lblTargerSize.Text = "Target Size";
            // 
            // sliderTargetSize
            // 
            // 
            // 
            // 
            this.sliderTargetSize.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.sliderTargetSize.LabelVisible = false;
            this.sliderTargetSize.Location = new System.Drawing.Point(150, 112);
            this.sliderTargetSize.Name = "sliderTargetSize";
            this.sliderTargetSize.Size = new System.Drawing.Size(150, 21);
            this.sliderTargetSize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sliderTargetSize.TabIndex = 9;
            this.sliderTargetSize.Value = 0;
            this.sliderTargetSize.ValueChanged += new System.EventHandler(this.slideTargetSize_ValueChanged);
            // 
            // lblZoneSize
            // 
            // 
            // 
            // 
            this.lblZoneSize.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblZoneSize.Location = new System.Drawing.Point(3, 138);
            this.lblZoneSize.Name = "lblZoneSize";
            this.lblZoneSize.Size = new System.Drawing.Size(142, 21);
            this.lblZoneSize.TabIndex = 10;
            this.lblZoneSize.Text = "Exclusion Zone Size";
            // 
            // sliderZoneSize
            // 
            // 
            // 
            // 
            this.sliderZoneSize.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.sliderZoneSize.LabelVisible = false;
            this.sliderZoneSize.Location = new System.Drawing.Point(150, 138);
            this.sliderZoneSize.Name = "sliderZoneSize";
            this.sliderZoneSize.Size = new System.Drawing.Size(150, 21);
            this.sliderZoneSize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sliderZoneSize.TabIndex = 11;
            this.sliderZoneSize.Value = 0;
            this.sliderZoneSize.ValueChanged += new System.EventHandler(this.slideZoneSize_ValueChanged);
            // 
            // lblZoneColour
            // 
            // 
            // 
            // 
            this.lblZoneColour.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblZoneColour.Location = new System.Drawing.Point(3, 165);
            this.lblZoneColour.Name = "lblZoneColour";
            this.lblZoneColour.Size = new System.Drawing.Size(142, 21);
            this.lblZoneColour.TabIndex = 12;
            this.lblZoneColour.Text = "Exclusion Zone Colour";
            // 
            // sliderZoneColour
            // 
            // 
            // 
            // 
            this.sliderZoneColour.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.sliderZoneColour.LabelVisible = false;
            this.sliderZoneColour.Location = new System.Drawing.Point(150, 165);
            this.sliderZoneColour.Name = "sliderZoneColour";
            this.sliderZoneColour.Size = new System.Drawing.Size(150, 21);
            this.sliderZoneColour.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sliderZoneColour.TabIndex = 13;
            this.sliderZoneColour.Value = 0;
            this.sliderZoneColour.ValueChanged += new System.EventHandler(this.sliderZoneColour_ValueChanged);
            // 
            // btnLaserCtrl
            // 
            this.btnLaserCtrl.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLaserCtrl.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLaserCtrl.Location = new System.Drawing.Point(3, 192);
            this.btnLaserCtrl.Name = "btnLaserCtrl";
            this.btnLaserCtrl.Size = new System.Drawing.Size(113, 21);
            this.btnLaserCtrl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLaserCtrl.TabIndex = 14;
            this.btnLaserCtrl.Text = "Laser Control";
            this.btnLaserCtrl.Click += new System.EventHandler(this.btnLaserCtrl_Click);
            // 
            // LaserAppearanceCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLaserCtrl);
            this.Controls.Add(this.sliderZoneColour);
            this.Controls.Add(this.lblZoneColour);
            this.Controls.Add(this.sliderZoneSize);
            this.Controls.Add(this.lblZoneSize);
            this.Controls.Add(this.sliderTargetSize);
            this.Controls.Add(this.lblTargerSize);
            this.Controls.Add(this.sliderThickness);
            this.Controls.Add(this.lblThickness);
            this.Controls.Add(this.sliderTransparency);
            this.Controls.Add(this.lblTransparency);
            this.Controls.Add(this.checkBoxX1);
            this.Controls.Add(this.lblSowHoleSize);
            this.Controls.Add(this.line1);
            this.Name = "LaserAppearanceCtrl";
            this.Size = new System.Drawing.Size(315, 219);
            this.Title = "Taget Appearance";
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.line1, 0);
            this.Controls.SetChildIndex(this.lblSowHoleSize, 0);
            this.Controls.SetChildIndex(this.checkBoxX1, 0);
            this.Controls.SetChildIndex(this.lblTransparency, 0);
            this.Controls.SetChildIndex(this.sliderTransparency, 0);
            this.Controls.SetChildIndex(this.lblThickness, 0);
            this.Controls.SetChildIndex(this.sliderThickness, 0);
            this.Controls.SetChildIndex(this.lblTargerSize, 0);
            this.Controls.SetChildIndex(this.sliderTargetSize, 0);
            this.Controls.SetChildIndex(this.lblZoneSize, 0);
            this.Controls.SetChildIndex(this.sliderZoneSize, 0);
            this.Controls.SetChildIndex(this.lblZoneColour, 0);
            this.Controls.SetChildIndex(this.sliderZoneColour, 0);
            this.Controls.SetChildIndex(this.btnLaserCtrl, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.Line line1;
        private DevComponents.DotNetBar.LabelX lblSowHoleSize;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
        private DevComponents.DotNetBar.LabelX lblTransparency;
        private DevComponents.DotNetBar.Controls.Slider sliderTransparency;
        private DevComponents.DotNetBar.LabelX lblThickness;
        private DevComponents.DotNetBar.LabelX lblZoneColour;
        private DevComponents.DotNetBar.Controls.Slider sliderThickness;
        private DevComponents.DotNetBar.LabelX lblTargerSize;
        private DevComponents.DotNetBar.Controls.Slider sliderTargetSize;
        private DevComponents.DotNetBar.LabelX lblZoneSize;
        private DevComponents.DotNetBar.Controls.Slider sliderZoneSize;
        private DevComponents.DotNetBar.Controls.Slider sliderZoneColour;
        private DevComponents.DotNetBar.ButtonX btnLaserCtrl;
    }
}
