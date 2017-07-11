using System;
using Cii.Lar.UI;

namespace Cii.Lar
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.metroStatusBar1 = new DevComponents.DotNetBar.Metro.MetroStatusBar();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.scalablePictureBox = new Cii.Lar.UI.ScalablePictureBox();
            this.functionCtrl = new Cii.Lar.UI.FunctionCtrl();
            this.SuspendLayout();
            // 
            // metroStatusBar1
            // 
            this.metroStatusBar1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.metroStatusBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroStatusBar1.ContainerControlProcessDialogKey = true;
            this.metroStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroStatusBar1.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroStatusBar1.ForeColor = System.Drawing.Color.Black;
            this.metroStatusBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem1});
            this.metroStatusBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.metroStatusBar1.Location = new System.Drawing.Point(0, 545);
            this.metroStatusBar1.Name = "metroStatusBar1";
            this.metroStatusBar1.Size = new System.Drawing.Size(740, 22);
            this.metroStatusBar1.TabIndex = 1;
            this.metroStatusBar1.Text = "metroStatusBar1";
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "Ready";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))));
            // 
            // scalablePictureBox
            // 
            this.scalablePictureBox.BackColor = System.Drawing.Color.White;
            this.scalablePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scalablePictureBox.ForeColor = System.Drawing.Color.Black;
            this.scalablePictureBox.Location = new System.Drawing.Point(0, 23);
            this.scalablePictureBox.Name = "scalablePictureBox";
            this.scalablePictureBox.Size = new System.Drawing.Size(740, 522);
            this.scalablePictureBox.TabIndex = 3;
            // 
            // functionCtrl
            // 
            this.functionCtrl.BackColor = System.Drawing.Color.White;
            this.functionCtrl.Dock = System.Windows.Forms.DockStyle.Top;
            this.functionCtrl.ForeColor = System.Drawing.Color.Black;
            this.functionCtrl.Location = new System.Drawing.Point(0, 0);
            this.functionCtrl.Name = "functionCtrl";
            this.functionCtrl.Size = new System.Drawing.Size(740, 23);
            this.functionCtrl.TabIndex = 2;
            this.functionCtrl.ToolStripClickHandler += new System.EventHandler(ToolStripClickHandler);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(740, 567);
            this.Controls.Add(this.scalablePictureBox);
            this.Controls.Add(this.functionCtrl);
            this.Controls.Add(this.metroStatusBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Cii Lar-100";
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.Metro.MetroStatusBar metroStatusBar1;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private FunctionCtrl functionCtrl;
        private ScalablePictureBox scalablePictureBox;
        private DevComponents.DotNetBar.StyleManager styleManager1;
    }
}

