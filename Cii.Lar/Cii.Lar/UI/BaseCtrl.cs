﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cii.Lar.SysClass;

namespace Cii.Lar.UI
{
    /// <summary>
    /// Custom base control
    /// Author: Zhong Wen 2017/08/05
    /// </summary>
    public partial class BaseCtrl : UserControl
    {
        protected ComponentResourceManager resources;
        protected SysConfig sysConfig;

        /// <summary>
        /// title font
        /// </summary>
        protected Font font = new System.Drawing.Font("Times New Roman", 9.75F,
            ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))),
            System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        /// <summary>
        /// title of this contrl
        /// </summary>
        protected string title = "Title";
        [Description("Title of this control"), Category("Appearance"), DefaultValue("Title")]
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        private int showIndex;
        public int ShowIndex
        {
            get
            {
                return showIndex;
            }
            set
            {
                this.showIndex = value;
            }
        }


        /// <summary>
        /// button click delegate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="name"></param>
        public delegate void ClickDelegate(object sender, string name);
        public ClickDelegate ClickDelegateHandler;
        public BaseCtrl()
        {
            InitializeComponent();
            sysConfig = SysConfig.GetSysConfig();
            this.Load += BaseCtrl_Load;
        }

        private void BaseCtrl_Load(object sender, EventArgs e)
        {
            sysConfig.PropertyChanged += SysConfig_PropertyChanged;
        }

        private void SysConfig_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == sysConfig.GetPropertyName(() => sysConfig.UICulture))
            {
                RefreshUI();
            }
        }

        protected virtual void RefreshUI()
        {

        }

        protected virtual void closeButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Enabled = false;
        }

        /// <summary>
        /// paint border and title
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle borderRect = this.ClientRectangle;
            borderRect.Width -= 1;
            borderRect.Height -= 1;
            e.Graphics.DrawRectangle(Pens.Navy, borderRect);

            e.Graphics.DrawString(Title, font, Brushes.Navy, 3, 3);
        }
    }
}
