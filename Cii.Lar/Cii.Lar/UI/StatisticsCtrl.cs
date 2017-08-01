using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cii.Lar.UI
{
    public partial class StatisticsCtrl : UserControl
    {
        private Font font = new System.Drawing.Font("Times New Roman", 9.75F, 
            ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))),
            System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        /// <summary>
        /// delegate of StatisticsCtrl control closed event handler
        /// </summary>
        public delegate void StatisticsClosedHandler();

        /// <summary>
        /// StatisticsCtrl control closed event
        /// </summary>
        public event StatisticsClosedHandler StatisticsClosed;

        public StatisticsCtrl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// close the StatisticsCtrl control when close button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Enabled = false;
            StatisticsClosed?.Invoke();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle borderRect = this.ClientRectangle;
            borderRect.Width -= 1;
            borderRect.Height -= 1;
            e.Graphics.DrawRectangle(Pens.Navy, borderRect);

            e.Graphics.DrawString("Statistics Information", font, Brushes.Navy, 3, 3);
        }

    }
}