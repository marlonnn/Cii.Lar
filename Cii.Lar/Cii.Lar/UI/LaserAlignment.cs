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
    /// Laser alignment
    /// Author: Zhong Wen 2018/10/18
    /// </summary>
    public partial class LaserAlignment : BaseCtrl
    {
        private int index;
        public int Index
        {
            get { return index; }
            set
            {
                if (value != this.index)
                {
                    this.index = value;
                    if (!(value < 0))
                    {
                        this.Title = helper.AlignmentInfo(index, true, this);
                        this.Invalidate();
                    }
                }
            }
        }

        private AlignInfoHelper helper;
        public LaserAlignment() :base()
        {
            resources = new ComponentResourceManager(typeof(LaserAlignment));
            InitializeComponent();
            helper = new AlignInfoHelper();
            this.Load += LaserAlignment_Load;
            index = -2;
        }


        private void LaserAlignment_Load(object sender, System.EventArgs e)
        {
            this.lblInfo.Text = Res.LaserAlignment.StrPreSet0;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Index++;
            this.lblInfo.Text = helper.AlignmentInfo(index, index < 0,  this);
        }

        protected override void RefreshUI()
        {
            base.RefreshUI();

            this.Title = Res.LaserAlignment.StrTitle;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Index--;
            this.lblInfo.Text = helper.AlignmentInfo(index, index < 0, this);
        }

        public class AlignInfoHelper
        {
            public AlignInfoHelper()
            {

            }
            public string AlignmentInfo(int index, bool isTitle, LaserAlignment laserAlignment)
            {
                string info = "";
                switch (index)
                {
                    case -2:
                        info = Res.LaserAlignment.StrPreSet0;
                        break;
                    case -1:
                        info = Res.LaserAlignment.StrPreSet1;
                        break;
                    case 0:
                        info = isTitle ? Res.LaserAlignment.StrStepTitleOne : Res.LaserAlignment.StrStepOne;
                        //laserAlignment.Title = Res.LaserAlignment.StrStepTitleOne;
                        break;
                    case 1:
                        info = isTitle ? Res.LaserAlignment.StrStepTitleTwo : Res.LaserAlignment.StrStepTwo;
                        //laserAlignment.Title = Res.LaserAlignment.StrStepTitleTwo;
                        break;
                    case 2:
                        info = isTitle ? Res.LaserAlignment.StrStepTitleThree : Res.LaserAlignment.StrStepThree;
                        //laserAlignment.Title = Res.LaserAlignment.StrStepTitleThree;
                        break;
                    case 3:
                        info = isTitle ? Res.LaserAlignment.StrStepTitleFour : Res.LaserAlignment.StrStepFour;
                        //laserAlignment.Title = Res.LaserAlignment.StrStepTitleFour;
                        break;
                    case 4:
                        info = isTitle ? Res.LaserAlignment.StrStepTitleFive : Res.LaserAlignment.StrStepFive;
                        //laserAlignment.Title = Res.LaserAlignment.StrStepTitleFive;
                        break;
                    case 5:
                        info = isTitle ? Res.LaserAlignment.StrStepTitleSix : Res.LaserAlignment.StrStepSix;
                        //laserAlignment.Title = Res.LaserAlignment.StrStepTitleSix;
                        break;
                    case 6:
                        info = isTitle ? Res.LaserAlignment.StrStepTitleSeven : Res.LaserAlignment.StrStepSeven;
                        //laserAlignment.Title = Res.LaserAlignment.StrStepTitleSeven;
                        break;
                    case 7:
                        info = isTitle ? Res.LaserAlignment.StrStepTitleComplete : Res.LaserAlignment.StrStepComplete;
                        //laserAlignment.Title = Res.LaserAlignment.StrStepTitleComplete;
                        break;
                }
                return info;
            }

        }
    }
}
