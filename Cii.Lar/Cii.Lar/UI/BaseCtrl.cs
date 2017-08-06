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
    public partial class BaseCtrl : UserControl
    {
        protected Font font = new System.Drawing.Font("Times New Roman", 9.75F,
            ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))),
            System.Drawing.GraphicsUnit.Point, ((byte)(0)));

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

        }

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
