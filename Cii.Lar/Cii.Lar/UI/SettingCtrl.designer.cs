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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingCtrl));
            this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            this.labelItemLanguage = new DevComponents.DotNetBar.LabelItem();
            this.comboBoxItemLanguage = new DevComponents.DotNetBar.ComboBoxItem();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.itemPanel2 = new DevComponents.DotNetBar.ItemPanel();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelItemStoragePath = new DevComponents.DotNetBar.LabelItem();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.textBoxItemStoragePath = new DevComponents.DotNetBar.TextBoxItem();
            this.itemPanelCamera = new DevComponents.DotNetBar.ItemPanel();
            this.labelItemCamera = new DevComponents.DotNetBar.LabelItem();
            this.itemContainer3 = new DevComponents.DotNetBar.ItemContainer();
            this.buttonItemSimulator = new System.Windows.Forms.Button();
            this.buttonSysInfo = new System.Windows.Forms.Button();
            this.itemPanel3 = new DevComponents.DotNetBar.ItemPanel();
            this.lense = new DevComponents.DotNetBar.LabelItem();
            this.comboBoxItemLense = new DevComponents.DotNetBar.ComboBoxItem();
            this.itemContainer2 = new DevComponents.DotNetBar.ItemContainer();
            this.btnDelete = new DevComponents.DotNetBar.ButtonItem();
            this.textBoxLense = new DevComponents.DotNetBar.TextBoxItem();
            this.itemPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            resources.ApplyResources(this.closeButton, "closeButton");
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
            resources.ApplyResources(this.itemPanel1, "itemPanel1");
            this.itemPanel1.Name = "itemPanel1";
            // 
            // labelItemLanguage
            // 
            this.labelItemLanguage.Name = "labelItemLanguage";
            resources.ApplyResources(this.labelItemLanguage, "labelItemLanguage");
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
            resources.ApplyResources(this.comboItem1, "comboItem1");
            // 
            // comboItem2
            // 
            resources.ApplyResources(this.comboItem2, "comboItem2");
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
            resources.ApplyResources(this.itemPanel2, "itemPanel2");
            this.itemPanel2.Name = "itemPanel2";
            // 
            // buttonSelect
            // 
            this.buttonSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(this.buttonSelect, "buttonSelect");
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(this.buttonSave, "buttonSave");
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelItemStoragePath
            // 
            this.labelItemStoragePath.Name = "labelItemStoragePath";
            resources.ApplyResources(this.labelItemStoragePath, "labelItemStoragePath");
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
            resources.ApplyResources(this.textBoxItemStoragePath, "textBoxItemStoragePath");
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
            resources.ApplyResources(this.itemPanelCamera, "itemPanelCamera");
            this.itemPanelCamera.Name = "itemPanelCamera";
            // 
            // labelItemCamera
            // 
            this.labelItemCamera.Name = "labelItemCamera";
            resources.ApplyResources(this.labelItemCamera, "labelItemCamera");
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
            resources.ApplyResources(this.buttonItemSimulator, "buttonItemSimulator");
            this.buttonItemSimulator.Name = "buttonItemSimulator";
            // 
            // buttonSysInfo
            // 
            this.buttonSysInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(this.buttonSysInfo, "buttonSysInfo");
            this.buttonSysInfo.Name = "buttonSysInfo";
            this.buttonSysInfo.Click += new System.EventHandler(this.buttonSysInfo_Click);
            // 
            // itemPanel3
            // 
            // 
            // 
            // 
            this.itemPanel3.BackgroundStyle.Class = "ItemPanel";
            this.itemPanel3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel3.ContainerControlProcessDialogKey = true;
            this.itemPanel3.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lense,
            this.comboBoxItemLense,
            this.itemContainer2});
            this.itemPanel3.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel3.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            resources.ApplyResources(this.itemPanel3, "itemPanel3");
            this.itemPanel3.Name = "itemPanel3";
            // 
            // lense
            // 
            this.lense.Name = "lense";
            resources.ApplyResources(this.lense, "lense");
            // 
            // comboBoxItemLense
            // 
            this.comboBoxItemLense.DropDownHeight = 106;
            this.comboBoxItemLense.ItemHeight = 16;
            this.comboBoxItemLense.Name = "comboBoxItemLense";
            // 
            // itemContainer2
            // 
            // 
            // 
            // 
            this.itemContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer2.Name = "itemContainer2";
            this.itemContainer2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.textBoxLense,
            this.btnDelete});
            // 
            // 
            // 
            this.itemContainer2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // textBoxLense
            // 
            this.textBoxLense.Name = "textBoxLense";
            this.textBoxLense.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textBoxLense.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxLense_KeyPress);
            // 
            // SettingCtrl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.itemPanel3);
            this.Controls.Add(this.buttonSysInfo);
            this.Controls.Add(this.itemPanelCamera);
            this.Controls.Add(this.itemPanel2);
            this.Controls.Add(this.itemPanel1);
            this.Name = "SettingCtrl";
            this.Title = global::Cii.Lar.Properties.Resources.StrSetting;
            this.Load += new System.EventHandler(this.SettingCtrl_Load);
            this.Controls.SetChildIndex(this.itemPanel1, 0);
            this.Controls.SetChildIndex(this.itemPanel2, 0);
            this.Controls.SetChildIndex(this.itemPanelCamera, 0);
            this.Controls.SetChildIndex(this.buttonSysInfo, 0);
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.itemPanel3, 0);
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
        private System.Windows.Forms.Button buttonItemSimulator;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonSysInfo;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.DotNetBar.ItemPanel itemPanel3;
        private DevComponents.DotNetBar.LabelItem lense;
        private DevComponents.DotNetBar.ComboBoxItem comboBoxItemLense;
        private DevComponents.DotNetBar.ItemContainer itemContainer2;
        private DevComponents.DotNetBar.ButtonItem btnDelete;
        private DevComponents.DotNetBar.TextBoxItem textBoxLense;
    }
}

