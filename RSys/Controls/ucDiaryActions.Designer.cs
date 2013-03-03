namespace RSys
{
    partial class ucDiaryActions
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            this.schedulerStorage = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerLeft = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.pnlDateNavigator = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dateNavigator = new DevExpress.XtraScheduler.DateNavigator();
            this.schedulerControl = new DevExpress.XtraScheduler.SchedulerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cbGroupBy = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblGroup = new DevExpress.XtraEditors.LabelControl();
            this.cbView = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.lblView = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.hideContainerLeft.SuspendLayout();
            this.pnlDateNavigator.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbGroupBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbView.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // schedulerStorage
            // 
            this.schedulerStorage.AppointmentInserting += new DevExpress.XtraScheduler.PersistentObjectCancelEventHandler(this.schedulerStorage_AppointmentInserting);
            this.schedulerStorage.AppointmentsInserted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage_AppointmentsInserted);
            this.schedulerStorage.AppointmentChanging += new DevExpress.XtraScheduler.PersistentObjectCancelEventHandler(this.schedulerStorage_AppointmentChanging);
            this.schedulerStorage.AppointmentDeleting += new DevExpress.XtraScheduler.PersistentObjectCancelEventHandler(this.schedulerStorage_AppointmentDeleting);
            this.schedulerStorage.AppointmentsDeleted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage_AppointmentsDeleted);
            // 
            // dockManager1
            // 
            this.dockManager1.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerLeft});
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // hideContainerLeft
            // 
            this.hideContainerLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.hideContainerLeft.Controls.Add(this.pnlDateNavigator);
            this.hideContainerLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.hideContainerLeft.Location = new System.Drawing.Point(0, 0);
            this.hideContainerLeft.Name = "hideContainerLeft";
            this.hideContainerLeft.Size = new System.Drawing.Size(19, 436);
            // 
            // pnlDateNavigator
            // 
            this.pnlDateNavigator.Controls.Add(this.dockPanel1_Container);
            this.pnlDateNavigator.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.pnlDateNavigator.ID = new System.Guid("d073d46c-c910-42a4-bdd3-415c4e1cc565");
            this.pnlDateNavigator.Location = new System.Drawing.Point(0, 0);
            this.pnlDateNavigator.Name = "pnlDateNavigator";
            this.pnlDateNavigator.Options.ShowCloseButton = false;
            this.pnlDateNavigator.OriginalSize = new System.Drawing.Size(0, 0);
            this.pnlDateNavigator.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.pnlDateNavigator.SavedIndex = 0;
            this.pnlDateNavigator.Size = new System.Drawing.Size(200, 436);
            this.pnlDateNavigator.Text = "Options";
            this.pnlDateNavigator.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.dateNavigator);
            this.dockPanel1_Container.Controls.Add(this.groupControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 25);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(194, 408);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // dateNavigator
            // 
            this.dateNavigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateNavigator.HotDate = null;
            this.dateNavigator.Location = new System.Drawing.Point(0, 90);
            this.dateNavigator.Name = "dateNavigator";
            this.dateNavigator.SchedulerControl = this.schedulerControl;
            this.dateNavigator.Size = new System.Drawing.Size(194, 318);
            this.dateNavigator.TabIndex = 1;
            // 
            // schedulerControl
            // 
            this.schedulerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControl.Location = new System.Drawing.Point(19, 0);
            this.schedulerControl.Name = "schedulerControl";
            this.schedulerControl.Size = new System.Drawing.Size(695, 436);
            this.schedulerControl.Start = new System.DateTime(2012, 7, 29, 0, 0, 0, 0);
            this.schedulerControl.Storage = this.schedulerStorage;
            this.schedulerControl.TabIndex = 0;
            this.schedulerControl.Text = "schedulerControl1";
            timeRuler1.TimeZone.DaylightBias = System.TimeSpan.Parse("-01:00:00");
            timeRuler1.TimeZone.DaylightZoneName = "Pakistan Daylight Time";
            timeRuler1.TimeZone.DisplayName = "(UTC+05:00) Islamabad, Karachi";
            timeRuler1.TimeZone.StandardZoneName = "Pakistan Standard Time";
            timeRuler1.TimeZone.UtcOffset = System.TimeSpan.Parse("05:00:00");
            timeRuler1.UseClientTimeZone = false;
            this.schedulerControl.Views.DayView.TimeRulers.Add(timeRuler1);
            timeRuler2.TimeZone.DaylightBias = System.TimeSpan.Parse("-01:00:00");
            timeRuler2.TimeZone.DaylightZoneName = "Pakistan Daylight Time";
            timeRuler2.TimeZone.DisplayName = "(UTC+05:00) Islamabad, Karachi";
            timeRuler2.TimeZone.StandardZoneName = "Pakistan Standard Time";
            timeRuler2.TimeZone.UtcOffset = System.TimeSpan.Parse("05:00:00");
            timeRuler2.UseClientTimeZone = false;
            this.schedulerControl.Views.WorkWeekView.TimeRulers.Add(timeRuler2);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cbGroupBy);
            this.groupControl1.Controls.Add(this.lblGroup);
            this.groupControl1.Controls.Add(this.cbView);
            this.groupControl1.Controls.Add(this.lblView);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(194, 90);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "View";
            // 
            // cbGroupBy
            // 
            this.cbGroupBy.Location = new System.Drawing.Point(66, 55);
            this.cbGroupBy.Name = "cbGroupBy";
            this.cbGroupBy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbGroupBy.Properties.Items.AddRange(new object[] {
            "None",
            "Date",
            "Resource"});
            this.cbGroupBy.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbGroupBy.Size = new System.Drawing.Size(122, 20);
            this.cbGroupBy.TabIndex = 3;
            this.cbGroupBy.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
            // 
            // lblGroup
            // 
            this.lblGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGroup.Location = new System.Drawing.Point(16, 58);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(44, 13);
            this.lblGroup.TabIndex = 2;
            this.lblGroup.Text = "Group By";
            // 
            // cbView
            // 
            this.cbView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbView.EditValue = "";
            this.cbView.Location = new System.Drawing.Point(66, 29);
            this.cbView.Name = "cbView";
            this.cbView.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbView.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Day View", DevExpress.XtraScheduler.SchedulerViewType.Day, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Work Week View", DevExpress.XtraScheduler.SchedulerViewType.WorkWeek, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Week View", DevExpress.XtraScheduler.SchedulerViewType.Week, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Month View", DevExpress.XtraScheduler.SchedulerViewType.Month, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Timeline View", DevExpress.XtraScheduler.SchedulerViewType.Timeline, -1)});
            this.cbView.Size = new System.Drawing.Size(122, 20);
            this.cbView.TabIndex = 1;
            this.cbView.SelectedIndexChanged += new System.EventHandler(this.cbView_SelectedIndexChanged);
            // 
            // lblView
            // 
            this.lblView.Location = new System.Drawing.Point(34, 32);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(26, 13);
            this.lblView.TabIndex = 0;
            this.lblView.Text = "Show";
            // 
            // ucDiaryActions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.schedulerControl);
            this.Controls.Add(this.hideContainerLeft);
            this.Name = "ucDiaryActions";
            this.Size = new System.Drawing.Size(714, 436);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.hideContainerLeft.ResumeLayout(false);
            this.pnlDateNavigator.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbGroupBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbView.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel pnlDateNavigator;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraScheduler.DateNavigator dateNavigator;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl lblGroup;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbView;
        private DevExpress.XtraEditors.LabelControl lblView;
        private DevExpress.XtraEditors.ComboBoxEdit cbGroupBy;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerLeft;
        private DevExpress.XtraScheduler.SchedulerControl schedulerControl;
    }
}
