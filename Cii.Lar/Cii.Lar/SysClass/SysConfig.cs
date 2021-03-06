﻿using Cii.Lar.UI;
using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cii.Lar.SysClass
{
    [Serializable]
    public class SysConfig
    {
        private LaserConfig laserConfig;
        public LaserConfig LaserConfig
        {
            get { return this.laserConfig; }
        }

        public static SysConfig systemConfig;

        private string storagePath;

        public string StorePath
        {
            get
            {
                return this.storagePath;
            }
            set
            {
                this.storagePath = value;
            }
        }

        private string archivePath;
        public string ArchivePath
        {
            get
            {
                return this.archivePath;
            }
            set
            {
                this.archivePath = value;
            }
        }

        private string uiCulture;

        public string UICulture
        {
            get
            {
                if (string.IsNullOrEmpty(uiCulture))
                {
                    UICulture = GetSysDefaultCulture().Name;
                }

                return uiCulture;
            }
            set
            {
                if (uiCulture == value) // compare after previous check
                {
                    return;
                }
                uiCulture = value;

                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(uiCulture);
                MessageBoxManager.Reset();  // after UI culture changes

                OnPropertyChanged(() => UICulture);
            }
        }

        private List<Lense> lenses;

        public List<Lense> Lenses
        {
            get { return lenses; }
            set { lenses = value; }
        }

        public bool AddLense(Lense newLense)
        {
            var lense = Lenses.Find(l => (l.Factor == newLense.Factor));
            if (lense == null)
            {
                //create a new lense
                Lenses.Add(newLense);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteLense(string lense)
        {
            var item = Lenses.Find(l => (l.ToString() == lense));
            if (item != null)
            {
                Lenses.Remove(item);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged<T>(Expression<Func<T>> propertyId)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(((MemberExpression)propertyId.Body).Member.Name));
            }
        }

        /// <summary>
        /// if this is Chinese edition which need register process
        /// </summary>
        public static bool ChineseEdition
        {
            get { return s_chineseEdition ?? (bool)(s_chineseEdition = File.Exists(Application.StartupPath + "\\zh-CN\\Cii.Lar.resources.dll")); }
        }

        private static bool? s_chineseEdition;

        public SysConfig()
        {
            this.storagePath = string.Format("{0}\\Archive",System.Environment.CurrentDirectory);
            this.archivePath = string.Format("{0}\\Archive", System.Environment.CurrentDirectory);
            lenses = new List<Lense>();
            this.laserConfig = LaserConfig.GetLaserConfig();
        }

        public CultureInfo GetSysDefaultCulture()
        {
            CultureInfo sysDefault = System.Threading.Thread.CurrentThread.CurrentCulture;
            if (sysDefault.Name == "zh-CN" && !ChineseEdition)
            {
                sysDefault = new CultureInfo("en-US");
            }
            return sysDefault;
        }

        public static SysConfig GetSysConfig()
        {
            if (systemConfig == null)
            {
                systemConfig = new SysConfig();
            }
            return systemConfig;
        }

        public string GetPropertyName<TValue>(Expression<Func<TValue>> propertyId)
        {
            return ((MemberExpression)propertyId.Body).Member.Name;
        }

        public void RefreshUICulture(ComponentResourceManager resources, Control ctr)
        {
            foreach (Control c in ctr.Controls)
            {
                //resources.ApplyResources(c, c.Name);
                ControlCtrl control = c as ControlCtrl;
                if (control != null)
                {
                    control.RefreshUI();
                }
                //RefreshUICulture(resources, c);

                //if (c is ToolStripButton)
                //{
                //    RefreshBaseItemsUICulture(resources, (c as ToolStripButton).Items);
                //}
                //else  if (c is RibbonBar)
                //{
                //    RefreshBaseItemsUICulture(resources, (c as RibbonBar).Items);
                //}
                //else if (c is RibbonControl)
                //{
                //    RefreshBaseItemsUICulture(resources, (c as RibbonControl).Items);
                //}
                //else if (c is Bar)
                //{
                //    RefreshBaseItemsUICulture(resources, (c as Bar).Items);
                //}
                //else if (c is ButtonX)
                //{
                //    RefreshBaseItemsUICulture(resources, (c as ButtonX).SubItems);
                //}
                //else if (c is ToolStrip)
                //{
                //    RefreshToolStripUICulture(resources, (c as ToolStrip).Items);
                //}
            }
        }

        private void RefreshBaseItemsUICulture(ComponentResourceManager resources, SubItemsCollection items)
        {
            foreach (BaseItem item in items)
            {
                resources.ApplyResources(item, item.Name);
                RefreshBaseItemsUICulture(resources, item.SubItems);
            }
        }

        private void RefreshToolStripUICulture(ComponentResourceManager resources, ToolStripItemCollection items)
        {
            foreach (ToolStripItem item in items)
            {
                resources.ApplyResources(item, item.Name);
                if (item is ToolStripDropDownItem)
                    RefreshToolStripUICulture(resources, (item as ToolStripDropDownItem).DropDownItems);
            }
        }

    }
}
