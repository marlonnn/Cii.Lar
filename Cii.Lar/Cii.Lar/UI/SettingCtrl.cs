using Cii.Lar.SysClass;
using DevComponents.DotNetBar;
using DevComponents.Editors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cii.Lar.UI
{
    public partial class SettingCtrl : BaseCtrl
    {
        private SystemInfoForm systemInfoForm;

        public delegate void UpdateTimerState(bool enable);
        public UpdateTimerState UpdateTimerStatesHandler;

        public delegate void UpdateLense(Lense lense);
        public UpdateLense UpdateLenseHandler;

        public SettingCtrl() : base()
        {
            this.ShowIndex = 4;
            InitializeComponent();
            resources = new ComponentResourceManager(typeof(SettingCtrl));
            this.textBoxItemStoragePath.Text = sysConfig.StorePath;
            UpdateComboLanguage();
        }

        /// <summary>
        /// update combo language item when load or make a change
        /// </summary>
        private void UpdateComboLanguage()
        {
            foreach (ComboItem item in comboBoxItemLanguage.Items)
            {
                if (item.Value.ToString() == sysConfig.UICulture)
                {
                    comboBoxItemLanguage.SelectedItem = item;
                    break;
                }
            }
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && 
                    !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    sysConfig.StorePath = fbd.SelectedPath;
                    this.textBoxItemStoragePath.Text = sysConfig.StorePath;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }

        private void buttonSysInfo_Click(object sender, EventArgs e)
        {
            systemInfoForm = new SystemInfoForm();
            systemInfoForm.ShowDialog();
        }

        private void ComboBoxItemLanguage_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string language = this.comboBoxItemLanguage.SelectedItem.ToString();
            var culture = ((ComboItem)comboBoxItemLanguage.SelectedItem).Value.ToString();
            SysConfig.GetSysConfig().UICulture = culture;
        }

        private void comboBoxItemLanguage_ExpandChange(object sender, EventArgs e)
        {
            var v = this.comboBoxItemLanguage.Expanded;
            UpdateTimerStatesHandler?.Invoke(!this.comboBoxItemLanguage.Expanded);
        }

        protected override void RefreshUI()
        {
            this.Title = global::Cii.Lar.Properties.Resources.StrSetting;
            resources.ApplyResources(this.labelItemLanguage, labelItemLanguage.Name);
            resources.ApplyResources(this.labelItemStoragePath, labelItemStoragePath.Name);
            resources.ApplyResources(this.labelItemCamera, labelItemCamera.Name);
            resources.ApplyResources(this.lense, lense.Name);
            resources.ApplyResources(this.btnDelete, btnDelete.Name);
            this.itemContainer2.Refresh();
            foreach (var ctrl in this.Controls)
            {
                ButtonX btnX = ctrl as ButtonX;
                if (btnX != null)
                {
                    resources.ApplyResources(btnX, btnX.Name);
                }

                ItemPanel itemPanel = ctrl as ItemPanel;
                if (itemPanel != null)
                {
                    foreach (var itemCtrl in itemPanel.Controls)
                    {
                        ButtonX subBtnX = itemCtrl as ButtonX;
                        if (subBtnX != null)
                        {
                            resources.ApplyResources(subBtnX, subBtnX.Name);
                        }
                    }
                }
            }
            this.Invalidate();
        }

        private void SettingCtrl_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Create a new object lense
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// delete existing lense
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var lense = comboBoxItemLense.SelectedItem;
            if (lense != null)
            {
                int index = SysConfig.GetSysConfig().Lenses.FindIndex(l => (l.ToString() == lense.ToString()));
                SysConfig.GetSysConfig().DeleteLense(lense.ToString());
                comboBoxItemLense.Items.Clear();
                comboBoxItemLense.Items.AddRange(SysConfig.GetSysConfig().Lenses.ToArray());
                comboBoxItemLense.SelectedIndex = index - 1;

            }
        }

        private void textBoxLense_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                int factor = 0;
                Int32.TryParse(textBoxLense.Text, out factor);
                if (factor != 0)
                {
                    Lense lense = new Lense(factor);
                    if (SysConfig.GetSysConfig().AddLense(lense))
                    {
                        UpdateComBoxItemLense(lense);
                        UpdateLenseHandler?.Invoke(lense);
                    }

                }
                else
                {
                    //should input correct lense factor
                    //TO DO
                }
            }
        }

        private void UpdateComBoxItemLense(Lense lense)
        {
            comboBoxItemLense.Items.Clear();
            comboBoxItemLense.Items.AddRange(SysConfig.GetSysConfig().Lenses.ToArray());
            int index = SysConfig.GetSysConfig().Lenses.FindIndex(l => (l.ToString() == lense.ToString()));
            comboBoxItemLense.SelectedIndex = index;
        }
    }
}