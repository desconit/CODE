namespace RSys
{
    partial class FrmPlacementsVW
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
            this.grpMain = new DevExpress.XtraEditors.GroupControl();
            this.grdMain = new DevExpress.XtraGrid.GridControl();
            this.gvMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.d_firstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_lastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_StartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_Company = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_StandardRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_OvertimeRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_WeekendRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_CreatedOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_Canceled = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemLookUpEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.rluCompany = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rtxtPaymentDays = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.luGender = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rluJobTitle = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rluMartialStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rluContactType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).BeginInit();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rluCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtPaymentDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luGender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rluJobTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rluMartialStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rluContactType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.grdMain);
            this.grpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMain.Location = new System.Drawing.Point(0, 0);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(927, 468);
            this.grpMain.TabIndex = 1;
            this.grpMain.Text = "Placements";
            this.grpMain.Paint += new System.Windows.Forms.PaintEventHandler(this.grpMain_Paint);
            // 
            // grdMain
            // 
            this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMain.Location = new System.Drawing.Point(2, 21);
            this.grdMain.MainView = this.gvMain;
            this.grdMain.Name = "grdMain";
            this.grdMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit2,
            this.repositoryItemLookUpEdit2,
            this.repositoryItemCheckEdit1,
            this.repositoryItemTextEdit3,
            this.repositoryItemTextEdit4,
            this.repositoryItemTextEdit5,
            this.repositoryItemLookUpEdit3,
            this.repositoryItemLookUpEdit4,
            this.repositoryItemLookUpEdit5,
            this.repositoryItemDateEdit1,
            this.rluCompany,
            this.rtxtPaymentDays,
            this.repositoryItemCheckEdit2,
            this.luGender,
            this.rluJobTitle,
            this.rluMartialStatus,
            this.rluContactType,
            this.repositoryItemCheckEdit3});
            this.grdMain.Size = new System.Drawing.Size(923, 445);
            this.grdMain.TabIndex = 4;
            this.grdMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMain});
            this.grdMain.DoubleClick += new System.EventHandler(this.grdMain_DoubleClick);
            // 
            // gvMain
            // 
            this.gvMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.d_firstName,
            this.cl_lastName,
            this.cl_StartDate,
            this.cl_Company,
            this.cl_StandardRate,
            this.cl_OvertimeRate,
            this.cl_WeekendRate,
            this.cl_CreatedOn,
            this.cl_Canceled});
            this.gvMain.GridControl = this.grdMain;
            this.gvMain.Name = "gvMain";
            this.gvMain.OptionsBehavior.Editable = false;
            this.gvMain.OptionsCustomization.AllowColumnMoving = false;
            this.gvMain.OptionsCustomization.AllowGroup = false;
            this.gvMain.OptionsCustomization.AllowQuickHideColumns = false;
            this.gvMain.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gvMain.OptionsMenu.EnableColumnMenu = false;
            this.gvMain.OptionsView.RowAutoHeight = true;
            this.gvMain.OptionsView.ShowAutoFilterRow = true;
            this.gvMain.OptionsView.ShowGroupPanel = false;
            this.gvMain.RowHeight = 2;
            this.gvMain.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.cl_CreatedOn, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gvMain.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grdView_RowStyle);
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "ID";
            this.gridColumn7.FieldName = "ID";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // d_firstName
            // 
            this.d_firstName.Caption = "Forename(s)";
            this.d_firstName.FieldName = "FirstName";
            this.d_firstName.Name = "d_firstName";
            this.d_firstName.Visible = true;
            this.d_firstName.VisibleIndex = 1;
            this.d_firstName.Width = 90;
            // 
            // cl_lastName
            // 
            this.cl_lastName.Caption = "Last Name";
            this.cl_lastName.FieldName = "LastName";
            this.cl_lastName.Name = "cl_lastName";
            this.cl_lastName.Visible = true;
            this.cl_lastName.VisibleIndex = 2;
            this.cl_lastName.Width = 95;
            // 
            // cl_StartDate
            // 
            this.cl_StartDate.Caption = "Start Date";
            this.cl_StartDate.FieldName = "StartDate";
            this.cl_StartDate.Name = "cl_StartDate";
            this.cl_StartDate.Visible = true;
            this.cl_StartDate.VisibleIndex = 3;
            this.cl_StartDate.Width = 118;
            // 
            // cl_Company
            // 
            this.cl_Company.Caption = "Company";
            this.cl_Company.FieldName = "ClientCompany";
            this.cl_Company.Name = "cl_Company";
            this.cl_Company.Visible = true;
            this.cl_Company.VisibleIndex = 0;
            this.cl_Company.Width = 192;
            // 
            // cl_StandardRate
            // 
            this.cl_StandardRate.Caption = "Standard Rate";
            this.cl_StandardRate.FieldName = "StandardRate";
            this.cl_StandardRate.Name = "cl_StandardRate";
            this.cl_StandardRate.Visible = true;
            this.cl_StandardRate.VisibleIndex = 4;
            this.cl_StandardRate.Width = 90;
            // 
            // cl_OvertimeRate
            // 
            this.cl_OvertimeRate.Caption = "Overtime Rate";
            this.cl_OvertimeRate.FieldName = "OvertimeRate";
            this.cl_OvertimeRate.Name = "cl_OvertimeRate";
            this.cl_OvertimeRate.Visible = true;
            this.cl_OvertimeRate.VisibleIndex = 5;
            this.cl_OvertimeRate.Width = 104;
            // 
            // cl_WeekendRate
            // 
            this.cl_WeekendRate.Caption = "Weekend Rate";
            this.cl_WeekendRate.FieldName = "WeekendRate";
            this.cl_WeekendRate.Name = "cl_WeekendRate";
            this.cl_WeekendRate.Visible = true;
            this.cl_WeekendRate.VisibleIndex = 6;
            this.cl_WeekendRate.Width = 94;
            // 
            // cl_CreatedOn
            // 
            this.cl_CreatedOn.Caption = "Created Date";
            this.cl_CreatedOn.FieldName = "CreatedOn";
            this.cl_CreatedOn.Name = "cl_CreatedOn";
            this.cl_CreatedOn.Visible = true;
            this.cl_CreatedOn.VisibleIndex = 7;
            this.cl_CreatedOn.Width = 119;
            // 
            // cl_Canceled
            // 
            this.cl_Canceled.Caption = "Canceled";
            this.cl_Canceled.ColumnEdit = this.repositoryItemCheckEdit1;
            this.cl_Canceled.FieldName = "Canceled";
            this.cl_Canceled.Name = "cl_Canceled";
            this.cl_Canceled.Tag = true;
            this.cl_Canceled.Visible = true;
            this.cl_Canceled.VisibleIndex = 8;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Mask.EditMask = "(999)000-0000";
            this.repositoryItemTextEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            this.repositoryItemLookUpEdit2.NullText = "";
            this.repositoryItemLookUpEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.MaxLength = 20;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // repositoryItemTextEdit4
            // 
            this.repositoryItemTextEdit4.AutoHeight = false;
            this.repositoryItemTextEdit4.MaxLength = 10;
            this.repositoryItemTextEdit4.Name = "repositoryItemTextEdit4";
            // 
            // repositoryItemTextEdit5
            // 
            this.repositoryItemTextEdit5.AutoHeight = false;
            this.repositoryItemTextEdit5.Mask.EditMask = "\\d\\d\\d\\d\\d";
            this.repositoryItemTextEdit5.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            this.repositoryItemTextEdit5.MaxLength = 5;
            this.repositoryItemTextEdit5.Name = "repositoryItemTextEdit5";
            // 
            // repositoryItemLookUpEdit3
            // 
            this.repositoryItemLookUpEdit3.AutoHeight = false;
            this.repositoryItemLookUpEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit3.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.repositoryItemLookUpEdit3.Name = "repositoryItemLookUpEdit3";
            this.repositoryItemLookUpEdit3.NullText = "";
            this.repositoryItemLookUpEdit3.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // repositoryItemLookUpEdit4
            // 
            this.repositoryItemLookUpEdit4.AutoHeight = false;
            this.repositoryItemLookUpEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit4.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.repositoryItemLookUpEdit4.Name = "repositoryItemLookUpEdit4";
            this.repositoryItemLookUpEdit4.NullText = "";
            this.repositoryItemLookUpEdit4.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // repositoryItemLookUpEdit5
            // 
            this.repositoryItemLookUpEdit5.AutoHeight = false;
            this.repositoryItemLookUpEdit5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit5.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.repositoryItemLookUpEdit5.Name = "repositoryItemLookUpEdit5";
            this.repositoryItemLookUpEdit5.NullText = "";
            this.repositoryItemLookUpEdit5.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // rluCompany
            // 
            this.rluCompany.AutoHeight = false;
            this.rluCompany.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rluCompany.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyName", "Name")});
            this.rluCompany.Name = "rluCompany";
            this.rluCompany.NullText = "";
            // 
            // rtxtPaymentDays
            // 
            this.rtxtPaymentDays.AutoHeight = false;
            this.rtxtPaymentDays.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rtxtPaymentDays.Name = "rtxtPaymentDays";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // luGender
            // 
            this.luGender.AutoHeight = false;
            this.luGender.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luGender.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.luGender.Name = "luGender";
            this.luGender.NullText = "";
            // 
            // rluJobTitle
            // 
            this.rluJobTitle.AutoHeight = false;
            this.rluJobTitle.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rluJobTitle.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.rluJobTitle.Name = "rluJobTitle";
            this.rluJobTitle.NullText = "";
            // 
            // rluMartialStatus
            // 
            this.rluMartialStatus.AutoHeight = false;
            this.rluMartialStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rluMartialStatus.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.rluMartialStatus.Name = "rluMartialStatus";
            this.rluMartialStatus.NullText = "";
            // 
            // rluContactType
            // 
            this.rluContactType.AutoHeight = false;
            this.rluContactType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rluContactType.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.rluContactType.Name = "rluContactType";
            this.rluContactType.NullText = "";
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // FrmPlacementsVW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CanAdd = true;
            this.CanDelete = true;
            this.CanExecute = true;
            this.CanPrint = true;
            this.CanUpdate = true;
            this.CanView = true;
            this.ClientSize = new System.Drawing.Size(927, 468);
            this.Controls.Add(this.grpMain);
            this.Name = "FrmPlacementsVW";
            this.Text = "Placements";
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).EndInit();
            this.grpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rluCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtPaymentDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luGender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rluJobTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rluMartialStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rluContactType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpMain;
        internal DevExpress.XtraGrid.GridControl grdMain;
        internal DevExpress.XtraGrid.Views.Grid.GridView gvMain;
        internal DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        internal DevExpress.XtraGrid.Columns.GridColumn d_firstName;
        private DevExpress.XtraGrid.Columns.GridColumn cl_lastName;
        private DevExpress.XtraGrid.Columns.GridColumn cl_StartDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rluContactType;
        internal DevExpress.XtraGrid.Columns.GridColumn cl_Company;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rluCompany;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rluJobTitle;
        private DevExpress.XtraGrid.Columns.GridColumn cl_StandardRate;
        private DevExpress.XtraGrid.Columns.GridColumn cl_WeekendRate;
        internal DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        internal DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        internal DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        internal DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        internal DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        internal DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit5;
        internal DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit3;
        internal DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit4;
        internal DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit5;
        internal DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rtxtPaymentDays;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luGender;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rluMartialStatus;
        private DevExpress.XtraGrid.Columns.GridColumn cl_OvertimeRate;
        private DevExpress.XtraGrid.Columns.GridColumn cl_CreatedOn;
        private DevExpress.XtraGrid.Columns.GridColumn cl_Canceled;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;

    }
}