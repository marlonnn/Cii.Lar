using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cii.Lar.UI
{
    /// <summary>
    /// Custom base control
    /// Author: Zhong Wen 2017/08/05
    /// </summary>
    public partial class BaseCtrl : UserControl
    {
        /// <summary>
        /// title font
        /// </summary>
        protected Font font = new System.Drawing.Font("Times New Roman", 9.75F,
            ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))),
            System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        /// <summary>
        /// button click delegate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="name"></param>
        public delegate void ClickDelegate(object sender, string name);
        public ClickDelegate ClickDelegateHandler;

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

        public BaseCtrl()
        {
            InitializeComponent();
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
