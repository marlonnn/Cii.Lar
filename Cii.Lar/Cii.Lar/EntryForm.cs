using Cii.Lar.DrawTools;
using Cii.Lar.UI;
using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cii.Lar
{
    /// <summary>
    /// Entry form
    /// Author: Zhong Wen 2017/08/24
    /// </summary>
    public partial class EntryForm : Office2007Form
    {
        /// <summary>
        /// indicating mouse dragging mode of Statistics control
        /// </summary>
        private bool isDraggingBaseCtrl = false;

        /// <summary>
        /// last Statistics mouse position of mouse dragging
        /// </summary>
        private Point lastBaseCtrlMousePos;

        /// <summary>
        /// the new area where the Statistics control to be dragged
        /// </summary>
        private Rectangle draggingBaseCtrlRectangle;

        private List<BaseCtrl> controls;

        private BaseCtrl baseCtrl;
        public BaseCtrl BaseCtrl
        {
            get
            {
                return this.baseCtrl;
            }
        }

        public GraphicsList GraphicsList
        {
            get
            {
                return this.zoomblePictureBoxControl.GraphicsList;
            }

            private set
            {
                this.zoomblePictureBoxControl.GraphicsList = value;
            }
        }

        public EntryForm()
        {
            InitializeComponent();
            InitializeControls();
            //this.WindowState = FormWindowState.Maximized;
            this.Load += EntryForm_Load;
            this.toolbarControl.ShowBaseCtrlHandler += ShowBaseCtrlHandler;
        }

        private void ShowBaseCtrlHandler(string controlName)
        {
            switch (controlName)
            {
                case "DrawTool":
                    ShowBaseCtrl(true, 2);
                    break;
                case "Setting":
                    ShowBaseCtrl(true, 4);
                    break;
            }
        }

        /// <summary>
        /// initialize all the base controls
        /// </summary>
        private void InitializeControls()
        {
            controls = new List<BaseCtrl>();
            controls.Add(new LaserCtrl());
            controls.Add(new LaserAppearanceCtrl());
            controls.Add(new StatisticsCtrl());
            RulerAppearanceCtrl rulerAppearance = new RulerAppearanceCtrl();
            rulerAppearance.UpdateTimerStatesHandler += UpdateTimerStatesHandler;
            controls.Add(rulerAppearance);

            SettingCtrl settingCtrl = new SettingCtrl();
            settingCtrl.UpdateTimerStatesHandler += UpdateTimerStatesHandler;
            controls.Add(settingCtrl);
        }

        private void UpdateTimerStatesHandler(bool enable)
        {
            //this.focusTimer.Enabled = enable;
        }

        private void EntryForm_Load(object sender, EventArgs e)
        {
            this.toolbarControl.LinkedPictureBox = this.zoomblePictureBoxControl;
            foreach (var ctrl in this.controls)
            {
                ctrl.Location = new Point(22, 62);
                ctrl.ClickDelegateHandler += new BaseCtrl.ClickDelegate(this.ClickDelegateHandler);
                ctrl.MouseDown += BaseCtrl_MouseDown;
                ctrl.MouseMove += BaseCtrl_MouseMove;
                ctrl.MouseUp += BaseCtrl_MouseUp;
                this.Controls.Add(ctrl);
                ctrl.Visible = false;
                ctrl.Enabled = false;
            }
        }

        /// <summary>
        /// switch to different base control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="name"></param>
        private void ClickDelegateHandler(object sender, string name)
        {
            switch (name)
            {
                case "Laser Control":
                    ShowBaseCtrl(true, controls[0]);
                    break;
                case "Laser Appearance":
                    ShowBaseCtrl(true, controls[1]);
                    break;
                case "Statistics control":
                    ShowBaseCtrl(true, controls[2]);
                    break;
                case "Ruler Appearance":
                    ShowBaseCtrl(true, controls[3]);
                    break;
            }
        }

        /// <summary>
        /// show laser control
        /// </summary>
        /// <param name="show"></param>
        public void ShowBaseCtrl(bool show, int index)
        {
            for (int i = 0; i < this.controls.Count; i++)
            {
                if (this.controls[i].ShowIndex == index)
                {
                    this.baseCtrl = controls[index];
                    this.Controls.SetChildIndex(this.baseCtrl, 0);
                    this.baseCtrl.Visible = show;
                    this.baseCtrl.Enabled = show;
                    EnableAppearanceButton();
                }
                else
                {
                    this.controls[i].Visible = !show;
                    this.controls[i].Enabled = !show;
                }
            }
        }

        /// <summary>
        /// enable or disable ruler appearance button
        /// </summary>
        private void EnableAppearanceButton()
        {
            var baseCtrl = this.controls[2] as StatisticsCtrl;
            if (baseCtrl != null)
            {
                if (this.GraphicsList != null && this.GraphicsList.Count > 0)
                {
                    baseCtrl.BtnAppearance.Enabled = true;
                }
                else
                {
                    baseCtrl.BtnAppearance.Enabled = false;
                }
            }
        }

        /// <summary>
        /// switch to the base control
        /// </summary>
        /// <param name="show"></param>
        /// <param name="baseCtrl"></param>
        public void ShowBaseCtrl(bool show, BaseCtrl baseCtrl)
        {
            this.baseCtrl.Visible = false;
            this.baseCtrl.Enabled = false;

            this.baseCtrl = baseCtrl;
            this.Controls.SetChildIndex(this.baseCtrl, 0);

            this.baseCtrl.Visible = show;
            this.baseCtrl.Enabled = show;
        }

        private void BaseCtrl_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (isDraggingBaseCtrl)
            {
                isDraggingBaseCtrl = false;

                // erase dragging rectangle
                DrawReversibleRect(draggingBaseCtrlRectangle);

                // move the Statistics control to the new position
                this.baseCtrl.Location = draggingBaseCtrlRectangle.Location;
            }
        }

        private void BaseCtrl_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (isDraggingBaseCtrl)
            {
                // caculating next candidate dragging rectangle
                Point newPos = new Point(draggingBaseCtrlRectangle.Location.X + e.X - lastBaseCtrlMousePos.X,
                                         draggingBaseCtrlRectangle.Location.Y + e.Y - lastBaseCtrlMousePos.Y);
                Rectangle newPictureTrackerArea = draggingBaseCtrlRectangle;
                newPictureTrackerArea.Location = newPos;

                // saving current mouse position to be used for next dragging
                this.lastBaseCtrlMousePos = new Point(e.X, e.Y);

                // dragging Statistics ctrl only when the candidate dragging rectangle
                // is within this ScalablePictureBox control
                if (this.ClientRectangle.Contains(newPictureTrackerArea))
                {
                    // removing previous rubber-band frame
                    DrawReversibleRect(draggingBaseCtrlRectangle);

                    // updating dragging rectangle
                    draggingBaseCtrlRectangle = newPictureTrackerArea;

                    // drawing new rubber-band frame
                    DrawReversibleRect(draggingBaseCtrlRectangle);
                }
            }
        }

        private void BaseCtrl_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            isDraggingBaseCtrl = true;    // Make a note that we are dragging Statistics control

            // Store the last mouse poit for this rubber-band rectangle.
            lastBaseCtrlMousePos.X = e.X;
            lastBaseCtrlMousePos.Y = e.Y;

            // draw initial dragging rectangle
            draggingBaseCtrlRectangle = this.baseCtrl.Bounds;
            DrawReversibleRect(draggingBaseCtrlRectangle);
        }

        /// <summary>
        /// Draw a reversible rectangle
        /// </summary>
        /// <param name="rect">rectangle to be drawn</param>
        private void DrawReversibleRect(Rectangle rect)
        {
            // Convert the location of rectangle to screen coordinates.
            rect.Location = PointToScreen(rect.Location);

            // Draw the reversible frame.
            ControlPaint.DrawReversibleFrame(rect, Color.Navy, FrameStyle.Thick);
        }
    }
}