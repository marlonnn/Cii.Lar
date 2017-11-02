namespace Cii.Lar.UI
{
    partial class LaserHoleSize
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaserHoleSize));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnLaserCtrl = new System.Windows.Forms.Button();
            this.lblAdjustPulse = new DevComponents.DotNetBar.LabelX();
            this.lblAdjustHole = new DevComponents.DotNetBar.LabelX();
            this.sliderPulse = new Cii.Lar.UI.SliderCtrl();
            this.btnFire = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.upDownHoleSize = new System.Windows.Forms.NumericUpDown();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownHoleSize)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            resources.ApplyResources(this.closeButton, "closeButton");
            // 
            // chart1
            // 
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            resources.ApplyResources(this.chart1, "chart1");
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series3.YValuesPerPoint = 2;
            this.chart1.Series.Add(series3);
            // 
            // btnLaserCtrl
            // 
            this.btnLaserCtrl.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(this.btnLaserCtrl, "btnLaserCtrl");
            this.btnLaserCtrl.Name = "btnLaserCtrl";
            this.btnLaserCtrl.Click += new System.EventHandler(this.btnLaserCtrl_Click);
            // 
            // lblAdjustPulse
            // 
            // 
            // 
            // 
            this.lblAdjustPulse.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            resources.ApplyResources(this.lblAdjustPulse, "lblAdjustPulse");
            this.lblAdjustPulse.Name = "lblAdjustPulse";
            // 
            // lblAdjustHole
            // 
            // 
            // 
            // 
            this.lblAdjustHole.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            resources.ApplyResources(this.lblAdjustHole, "lblAdjustHole");
            this.lblAdjustHole.Name = "lblAdjustHole";
            // 
            // sliderPulse
            // 
            resources.ApplyResources(this.sliderPulse, "sliderPulse");
            this.sliderPulse.Name = "sliderPulse";
            // 
            // btnFire
            // 
            this.btnFire.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(this.btnFire, "btnFire");
            this.btnFire.Name = "btnFire";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            // 
            // upDownHoleSize
            // 
            resources.ApplyResources(this.upDownHoleSize, "upDownHoleSize");
            this.upDownHoleSize.Name = "upDownHoleSize";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            resources.ApplyResources(this.labelX1, "labelX1");
            this.labelX1.Name = "labelX1";
            // 
            // LaserHoleSize
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.upDownHoleSize);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnFire);
            this.Controls.Add(this.sliderPulse);
            this.Controls.Add(this.lblAdjustHole);
            this.Controls.Add(this.lblAdjustPulse);
            this.Controls.Add(this.btnLaserCtrl);
            this.Controls.Add(this.chart1);
            this.Name = "LaserHoleSize";
            this.Title = global::Cii.Lar.Properties.Resources.StrLaserHoleSizeCalibration;
            this.Controls.SetChildIndex(this.chart1, 0);
            this.Controls.SetChildIndex(this.btnLaserCtrl, 0);
            this.Controls.SetChildIndex(this.lblAdjustPulse, 0);
            this.Controls.SetChildIndex(this.lblAdjustHole, 0);
            this.Controls.SetChildIndex(this.sliderPulse, 0);
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.btnFire, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.upDownHoleSize, 0);
            this.Controls.SetChildIndex(this.labelX1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownHoleSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnLaserCtrl;
        private DevComponents.DotNetBar.LabelX lblAdjustPulse;
        private DevComponents.DotNetBar.LabelX lblAdjustHole;
        private SliderCtrl sliderPulse;
        private System.Windows.Forms.Button btnFire;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.NumericUpDown upDownHoleSize;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}
