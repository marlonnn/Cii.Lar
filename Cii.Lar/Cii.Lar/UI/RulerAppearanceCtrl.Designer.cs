namespace Cii.Lar.UI
{
    partial class RulerAppearanceCtrl
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
            this.btnLaserCtrl = new DevComponents.DotNetBar.ButtonX();
            this.sliderColour = new DevComponents.DotNetBar.Controls.Slider();
            this.lblZColour = new DevComponents.DotNetBar.LabelX();
            this.sliderTickLength = new DevComponents.DotNetBar.Controls.Slider();
            this.lblTickLength = new DevComponents.DotNetBar.LabelX();
            this.sliderTargetSize = new DevComponents.DotNetBar.Controls.Slider();
            this.lblTargerSize = new DevComponents.DotNetBar.LabelX();
            this.sliderThickness = new DevComponents.DotNetBar.Controls.Slider();
            this.lblThickness = new DevComponents.DotNetBar.LabelX();
            this.sliderTransparency = new DevComponents.DotNetBar.Controls.Slider();
            this.lblTransparency = new DevComponents.DotNetBar.LabelX();
            this.lblRuler = new DevComponents.DotNetBar.LabelX();
            this.cmboxRuler = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(296, 3);
            // 
            // line1
            // 
            this.line1.Location = new System.Drawing.Point(3, 18);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(309, 9);
            this.line1.TabIndex = 1;
            this.line1.Text = "line1";
            // 
            // btnLaserCtrl
            // 
            this.btnLaserCtrl.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLaserCtrl.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLaserCtrl.Location = new System.Drawing.Point(5, 193);
            this.btnLaserCtrl.Name = "btnLaserCtrl";
            this.btnLaserCtrl.Size = new System.Drawing.Size(88, 21);
            this.btnLaserCtrl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLaserCtrl.TabIndex = 25;
            this.btnLaserCtrl.Text = "Laser Control";
            this.btnLaserCtrl.Click += new System.EventHandler(this.btnLaserCtrl_Click);
            // 
            // sliderColour
            // 
            // 
            // 
            // 
            this.sliderColour.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.sliderColour.LabelVisible = false;
            this.sliderColour.Location = new System.Drawing.Point(127, 166);
            this.sliderColour.Name = "sliderColour";
            this.sliderColour.Size = new System.Drawing.Size(150, 21);
            this.sliderColour.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sliderColour.TabIndex = 24;
            this.sliderColour.Value = 0;
            // 
            // lblZColour
            // 
            // 
            // 
            // 
            this.lblZColour.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblZColour.Location = new System.Drawing.Point(5, 166);
            this.lblZColour.Name = "lblZColour";
            this.lblZColour.Size = new System.Drawing.Size(113, 21);
            this.lblZColour.TabIndex = 23;
            this.lblZColour.Text = "Colour";
            // 
            // sliderTickLength
            // 
            // 
            // 
            // 
            this.sliderTickLength.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.sliderTickLength.LabelVisible = false;
            this.sliderTickLength.Location = new System.Drawing.Point(127, 140);
            this.sliderTickLength.Name = "sliderTickLength";
            this.sliderTickLength.Size = new System.Drawing.Size(150, 21);
            this.sliderTickLength.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sliderTickLength.TabIndex = 22;
            this.sliderTickLength.Value = 0;
            // 
            // lblTickLength
            // 
            // 
            // 
            // 
            this.lblTickLength.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTickLength.Location = new System.Drawing.Point(5, 140);
            this.lblTickLength.Name = "lblTickLength";
            this.lblTickLength.Size = new System.Drawing.Size(113, 21);
            this.lblTickLength.TabIndex = 21;
            this.lblTickLength.Text = "Thick Length";
            // 
            // sliderTargetSize
            // 
            // 
            // 
            // 
            this.sliderTargetSize.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.sliderTargetSize.LabelVisible = false;
            this.sliderTargetSize.Location = new System.Drawing.Point(127, 113);
            this.sliderTargetSize.Name = "sliderTargetSize";
            this.sliderTargetSize.Size = new System.Drawing.Size(150, 21);
            this.sliderTargetSize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sliderTargetSize.TabIndex = 20;
            this.sliderTargetSize.Value = 0;
            // 
            // lblTargerSize
            // 
            // 
            // 
            // 
            this.lblTargerSize.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTargerSize.Location = new System.Drawing.Point(5, 113);
            this.lblTargerSize.Name = "lblTargerSize";
            this.lblTargerSize.Size = new System.Drawing.Size(116, 21);
            this.lblTargerSize.TabIndex = 19;
            this.lblTargerSize.Text = "Target Size";
            // 
            // sliderThickness
            // 
            // 
            // 
            // 
            this.sliderThickness.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.sliderThickness.LabelVisible = false;
            this.sliderThickness.Location = new System.Drawing.Point(127, 86);
            this.sliderThickness.Name = "sliderThickness";
            this.sliderThickness.Size = new System.Drawing.Size(150, 21);
            this.sliderThickness.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sliderThickness.TabIndex = 18;
            this.sliderThickness.Value = 0;
            // 
            // lblThickness
            // 
            // 
            // 
            // 
            this.lblThickness.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblThickness.Location = new System.Drawing.Point(5, 86);
            this.lblThickness.Name = "lblThickness";
            this.lblThickness.Size = new System.Drawing.Size(116, 21);
            this.lblThickness.TabIndex = 17;
            this.lblThickness.Text = "Line Thickness";
            // 
            // sliderTransparency
            // 
            // 
            // 
            // 
            this.sliderTransparency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.sliderTransparency.LabelVisible = false;
            this.sliderTransparency.Location = new System.Drawing.Point(127, 59);
            this.sliderTransparency.Name = "sliderTransparency";
            this.sliderTransparency.Size = new System.Drawing.Size(150, 21);
            this.sliderTransparency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sliderTransparency.TabIndex = 16;
            this.sliderTransparency.Value = 0;
            // 
            // lblTransparency
            // 
            // 
            // 
            // 
            this.lblTransparency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTransparency.Location = new System.Drawing.Point(5, 59);
            this.lblTransparency.Name = "lblTransparency";
            this.lblTransparency.Size = new System.Drawing.Size(116, 21);
            this.lblTransparency.TabIndex = 15;
            this.lblTransparency.Text = "Transparency";
            // 
            // lblRuler
            // 
            // 
            // 
            // 
            this.lblRuler.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblRuler.Location = new System.Drawing.Point(5, 32);
            this.lblRuler.Name = "lblRuler";
            this.lblRuler.Size = new System.Drawing.Size(116, 21);
            this.lblRuler.TabIndex = 26;
            this.lblRuler.Text = "Ruler";
            // 
            // cmboxRuler
            // 
            this.cmboxRuler.DisplayMember = "Text";
            this.cmboxRuler.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmboxRuler.FormattingEnabled = true;
            this.cmboxRuler.ItemHeight = 15;
            this.cmboxRuler.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3,
            this.comboItem4});
            this.cmboxRuler.Location = new System.Drawing.Point(127, 32);
            this.cmboxRuler.Name = "cmboxRuler";
            this.cmboxRuler.Size = new System.Drawing.Size(150, 21);
            this.cmboxRuler.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmboxRuler.TabIndex = 27;
            this.cmboxRuler.DropDown += new System.EventHandler(this.cmboxRuler_DropDown);
            this.cmboxRuler.DropDownClosed += new System.EventHandler(this.cmboxRuler_DropDownClosed);
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "Line";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "Rectangle";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "Ellipse";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "Polygon";
            // 
            // RulerAppearanceCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmboxRuler);
            this.Controls.Add(this.lblRuler);
            this.Controls.Add(this.btnLaserCtrl);
            this.Controls.Add(this.sliderColour);
            this.Controls.Add(this.lblZColour);
            this.Controls.Add(this.sliderTickLength);
            this.Controls.Add(this.lblTickLength);
            this.Controls.Add(this.sliderTargetSize);
            this.Controls.Add(this.lblTargerSize);
            this.Controls.Add(this.sliderThickness);
            this.Controls.Add(this.lblThickness);
            this.Controls.Add(this.sliderTransparency);
            this.Controls.Add(this.lblTransparency);
            this.Controls.Add(this.line1);
            this.DoubleBuffered = true;
            this.Name = "RulerAppearanceCtrl";
            this.Size = new System.Drawing.Size(315, 226);
            this.Title = "Ruler Appearance";
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.line1, 0);
            this.Controls.SetChildIndex(this.lblTransparency, 0);
            this.Controls.SetChildIndex(this.sliderTransparency, 0);
            this.Controls.SetChildIndex(this.lblThickness, 0);
            this.Controls.SetChildIndex(this.sliderThickness, 0);
            this.Controls.SetChildIndex(this.lblTargerSize, 0);
            this.Controls.SetChildIndex(this.sliderTargetSize, 0);
            this.Controls.SetChildIndex(this.lblTickLength, 0);
            this.Controls.SetChildIndex(this.sliderTickLength, 0);
            this.Controls.SetChildIndex(this.lblZColour, 0);
            this.Controls.SetChildIndex(this.sliderColour, 0);
            this.Controls.SetChildIndex(this.btnLaserCtrl, 0);
            this.Controls.SetChildIndex(this.lblRuler, 0);
            this.Controls.SetChildIndex(this.cmboxRuler, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.Line line1;
        private DevComponents.DotNetBar.ButtonX btnLaserCtrl;
        private DevComponents.DotNetBar.Controls.Slider sliderColour;
        private DevComponents.DotNetBar.LabelX lblZColour;
        private DevComponents.DotNetBar.Controls.Slider sliderTickLength;
        private DevComponents.DotNetBar.LabelX lblTickLength;
        private DevComponents.DotNetBar.Controls.Slider sliderTargetSize;
        private DevComponents.DotNetBar.LabelX lblTargerSize;
        private DevComponents.DotNetBar.Controls.Slider sliderThickness;
        private DevComponents.DotNetBar.LabelX lblThickness;
        private DevComponents.DotNetBar.Controls.Slider sliderTransparency;
        private DevComponents.DotNetBar.LabelX lblTransparency;
        private DevComponents.DotNetBar.LabelX lblRuler;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmboxRuler;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
    }
}
