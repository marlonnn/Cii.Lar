namespace Cii.Lar.UI
{
    partial class StatisticsCtrl
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
            this.panel = new System.Windows.Forms.Panel();
            this.listViewEx = new Cii.Lar.UI.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAppearance = new DevComponents.DotNetBar.ButtonX();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(339, 3);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.listViewEx);
            this.panel.Location = new System.Drawing.Point(3, 25);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(352, 230);
            this.panel.TabIndex = 1;
            // 
            // listViewEx
            // 
            this.listViewEx.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewEx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewEx.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewEx.Location = new System.Drawing.Point(0, 0);
            this.listViewEx.Name = "listViewEx";
            this.listViewEx.Size = new System.Drawing.Size(302, 230);
            this.listViewEx.TabIndex = 0;
            this.listViewEx.UseCompatibleStateImageBehavior = false;
            this.listViewEx.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Circumference";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Area";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "";
            this.columnHeader4.Width = 40;
            // 
            // btnAppearance
            // 
            this.btnAppearance.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAppearance.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAppearance.Location = new System.Drawing.Point(3, 256);
            this.btnAppearance.Name = "btnAppearance";
            this.btnAppearance.Size = new System.Drawing.Size(75, 23);
            this.btnAppearance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAppearance.TabIndex = 2;
            this.btnAppearance.Text = "Appearance";
            this.btnAppearance.Click += new System.EventHandler(this.btnAppearance_Click);
            // 
            // StatisticsCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.btnAppearance);
            this.Controls.Add(this.panel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "StatisticsCtrl";
            this.Size = new System.Drawing.Size(358, 284);
            this.Controls.SetChildIndex(this.panel, 0);
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.btnAppearance, 0);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private ListViewEx listViewEx;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private DevComponents.DotNetBar.ButtonX btnAppearance;
    }
}

