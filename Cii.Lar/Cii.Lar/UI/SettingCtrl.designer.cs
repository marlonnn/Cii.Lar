namespace Cii.Lar.UI
{
    partial class SettingCtrl
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
            this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            this.labelItemLanguage = new DevComponents.DotNetBar.LabelItem();
            this.comboBoxItemLanguage = new DevComponents.DotNetBar.ComboBoxItem();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.itemPanel2 = new DevComponents.DotNetBar.ItemPanel();
            this.buttonSelect = new DevComponents.DotNetBar.ButtonX();
            this.buttonSave = new DevComponents.DotNetBar.ButtonX();
            this.labelItemStoragePath = new DevComponents.DotNetBar.LabelItem();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.textBoxItemStoragePath = new DevComponents.DotNetBar.TextBoxItem();
            this.itemPanelCamera = new DevComponents.DotNetBar.ItemPanel();
            this.labelItemCamera = new DevComponents.DotNetBar.LabelItem();
            this.itemContainer3 = new DevComponents.DotNetBar.ItemContainer();
            this.buttonItemSimulator = new DevComponents.DotNetBar.ButtonX();
            this.buttonSysInfo = new DevComponents.DotNetBar.ButtonX();
            this.itemPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(197, 1);
            // 
            // itemPanel1
            // 
            this.itemPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            // 
            // 
            // 
            this.itemPanel1.BackgroundStyle.Class = "ItemPanel";
            this.itemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel1.ContainerControlProcessDialogKey = true;
            this.itemPanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItemLanguage,
            this.comboBoxItemLanguage});
            this.itemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel1.Location = new System.Drawing.Point(3, 182);
            this.itemPanel1.Name = "itemPanel1";
            this.itemPanel1.Size = new System.Drawing.Size(209, 53);
            this.itemPanel1.TabIndex = 2;
            this.itemPanel1.Text = "Language";
            // 
            // labelItemLanguage
            // 
            this.labelItemLanguage.Name = "labelItemLanguage";
            this.labelItemLanguage.Text = global::Cii.Lar.Properties.Resources.labelItemLanguageStr;
            // 
            // comboBoxItemLanguage
            // 
            this.comboBoxItemLanguage.DropDownHeight = 106;
            this.comboBoxItemLanguage.ItemHeight = 16;
            this.comboBoxItemLanguage.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.comboBoxItemLanguage.Name = "comboBoxItemLanguage";
            this.comboBoxItemLanguage.SelectedIndexChanged += new System.EventHandler(this.ComboBoxItemLanguage_SelectedIndexChanged);
            this.comboBoxItemLanguage.ExpandChange += new System.EventHandler(this.comboBoxItemLanguage_ExpandChange);
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "English";
            this.comboItem1.Value = "en-US";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "¼òÌåÖÐÎÄ";
            this.comboItem2.Value = "zh-CN";
            // 
            // itemPanel2
            // 
            // 
            // 
            // 
            this.itemPanel2.BackgroundStyle.Class = "ItemPanel";
            this.itemPanel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel2.ContainerControlProcessDialogKey = true;
            this.itemPanel2.Controls.Add(this.buttonSelect);
            this.itemPanel2.Controls.Add(this.buttonSave);
            this.itemPanel2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItemStoragePath,
            this.itemContainer1});
            this.itemPanel2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel2.Location = new System.Drawing.Point(3, 241);
            this.itemPanel2.Name = "itemPanel2";
            this.itemPanel2.Size = new System.Drawing.Size(209, 72);
            this.itemPanel2.TabIndex = 3;
            this.itemPanel2.Text = "itemPanel2";
            // 
            // buttonSelect
            // 
            this.buttonSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonSelect.Location = new System.Drawing.Point(165, 20);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(41, 21);
            this.buttonSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonSelect.TabIndex = 1;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonSave.Location = new System.Drawing.Point(6, 44);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(41, 21);
            this.buttonSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Save";
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelItemStoragePath
            // 
            this.labelItemStoragePath.Name = "labelItemStoragePath";
            this.labelItemStoragePath.Text = global::Cii.Lar.Properties.Resources.labelItemStoragePathStr;
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.textBoxItemStoragePath});
            // 
            // 
            // 
            this.itemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // textBoxItemStoragePath
            // 
            this.textBoxItemStoragePath.Name = "textBoxItemStoragePath";
            this.textBoxItemStoragePath.Text = "textBoxItem1";
            this.textBoxItemStoragePath.TextBoxWidth = 160;
            this.textBoxItemStoragePath.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // itemPanelCamera
            // 
            this.itemPanelCamera.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.itemPanelCamera.BackgroundStyle.Class = "ItemPanel";
            this.itemPanelCamera.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanelCamera.ContainerControlProcessDialogKey = true;
            this.itemPanelCamera.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItemCamera,
            this.itemContainer3});
            this.itemPanelCamera.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanelCamera.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanelCamera.Location = new System.Drawing.Point(3, 57);
            this.itemPanelCamera.Name = "itemPanelCamera";
            this.itemPanelCamera.Size = new System.Drawing.Size(209, 119);
            this.itemPanelCamera.TabIndex = 4;
            this.itemPanelCamera.Text = "itemPanel3";
            // 
            // labelItemCamera
            // 
            this.labelItemCamera.Name = "labelItemCamera";
            this.labelItemCamera.Text = "Camera";
            // 
            // itemContainer3
            // 
            // 
            // 
            // 
            this.itemContainer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer3.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer3.Name = "itemContainer3";
            // 
            // 
            // 
            this.itemContainer3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // buttonItemSimulator
            // 
            this.buttonItemSimulator.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonItemSimulator.Location = new System.Drawing.Point(0, 0);
            this.buttonItemSimulator.Name = "buttonItemSimulator";
            this.buttonItemSimulator.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.buttonItemSimulator.Size = new System.Drawing.Size(0, 0);
            this.buttonItemSimulator.TabIndex = 0;
            this.buttonItemSimulator.Text = "Open Simulator Mode";
            // 
            // buttonSysInfo
            // 
            this.buttonSysInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonSysInfo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonSysInfo.Location = new System.Drawing.Point(3, 28);
            this.buttonSysInfo.Name = "buttonSysInfo";
            this.buttonSysInfo.Size = new System.Drawing.Size(210, 23);
            this.buttonSysInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonSysInfo.TabIndex = 5;
            this.buttonSysInfo.Text = "System Infomation";
            this.buttonSysInfo.Click += new System.EventHandler(this.buttonSysInfo_Click);
            // 
            // SettingCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSysInfo);
            this.Controls.Add(this.itemPanelCamera);
            this.Controls.Add(this.itemPanel2);
            this.Controls.Add(this.itemPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SettingCtrl";
            this.Size = new System.Drawing.Size(216, 560);
            this.Title = "Setting";
            this.Controls.SetChildIndex(this.itemPanel1, 0);
            this.Controls.SetChildIndex(this.itemPanel2, 0);
            this.Controls.SetChildIndex(this.itemPanelCamera, 0);
            this.Controls.SetChildIndex(this.buttonSysInfo, 0);
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.itemPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.ItemPanel itemPanel1;
        private DevComponents.DotNetBar.LabelItem labelItemLanguage;
        private DevComponents.DotNetBar.ComboBoxItem comboBoxItemLanguage;
        private DevComponents.DotNetBar.ItemPanel itemPanel2;
        private DevComponents.DotNetBar.LabelItem labelItemStoragePath;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.TextBoxItem textBoxItemStoragePath;
        private DevComponents.DotNetBar.ItemPanel itemPanelCamera;
        private DevComponents.DotNetBar.LabelItem labelItemCamera;
        private DevComponents.DotNetBar.ItemContainer itemContainer3;
        private DevComponents.DotNetBar.ButtonX buttonItemSimulator;
        private DevComponents.DotNetBar.ButtonX buttonSelect;
        private DevComponents.DotNetBar.ButtonX buttonSave;
        private DevComponents.DotNetBar.ButtonX buttonSysInfo;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
    }
}

