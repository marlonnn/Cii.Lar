using Cii.Lar.SysClass;
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
    /// <summary>
    /// Assign form
    /// Author: Zhong Wen 2017/08/17
    /// </summary>
    public partial class AssignForm : Office2007Form
    {
        public AssignForm()
        {
            InitializeComponent();
        }

        private bool CheckTextBoxValided(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
            return true;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Patient patient = new Patient(Int32.Parse(this.textBoxPatientID.Text), this.textBoxPatientName.Text);
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger<AssignForm>().Error(ex.Message);
                LogHelper.GetLogger<AssignForm>().Error(ex.StackTrace);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}