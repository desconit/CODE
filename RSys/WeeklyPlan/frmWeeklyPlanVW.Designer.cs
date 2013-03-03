namespace RSys
{
    partial class frmWeeklyPlanVW
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
            this.cl_CutOffDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_StartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_CreatedOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_CreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_LastModifiedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_LastModifiedOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_Approved = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_ApprovedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_Profit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
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
            this.btnAddWeeklyPlan = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).BeginInit();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
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
            this.grpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMain.Controls.Add(this.grdMain);
            this.grpMain.Location = new System.Drawing.Point(0, 0);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(927, 562);
            this.grpMain.TabIndex = 2;
            this.grpMain.Text = "Weekly Plans";
            // 
            // grdMain
            // 
            this.grdMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdMain.Location = new System.Drawing.Point(2, 22);
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
            this.grdMain.Size = new System.Drawing.Size(923, 499);
            this.grdMain.TabIndex = 4;
            this.grdMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMain});
            // 
            // gvMain
            // 
            this.gvMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.cl_CutOffDate,
            this.cl_StartDate,
            this.cl_CreatedOn,
            this.cl_CreatedBy,
            this.cl_LastModifiedBy,
            this.cl_LastModifiedOn,
            this.cl_Approved,
            this.cl_ApprovedBy,
            this.cl_Profit});
            this.gvMain.GridControl = this.grdMain;
            this.gvMain.Name = "gvMain";
            this.gvMain.OptionsBehavior.Editable = false;
            this.gvMain.OptionsCustomization.AllowColumnMoving = false;
            this.gvMain.OptionsCustomization.AllowQuickHideColumns = false;
            this.gvMain.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gvMain.OptionsMenu.EnableColumnMenu = false;
            this.gvMain.OptionsView.RowAutoHeight = true;
            this.gvMain.OptionsView.ShowAutoFilterRow = true;
            this.gvMain.RowHeight = 2;
            this.gvMain.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.cl_CutOffDate, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.cl_StartDate, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.cl_CreatedBy, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gvMain.DoubleClick += new System.EventHandler(this.EditWeekly_Plan);
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "ID";
            this.gridColumn7.FieldName = "Id";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            // 
            // cl_CutOffDate
            // 
            this.cl_CutOffDate.Caption = "Plan To";
            this.cl_CutOffDate.FieldName = "CutOffDate";
            this.cl_CutOffDate.GroupFormat.FormatString = "d";
            this.cl_CutOffDate.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cl_CutOffDate.Name = "cl_CutOffDate";
            this.cl_CutOffDate.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.cl_CutOffDate.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.cl_CutOffDate.Visible = true;
            this.cl_CutOffDate.VisibleIndex = 1;
            // 
            // cl_StartDate
            // 
            this.cl_StartDate.Caption = "Plan From";
            this.cl_StartDate.DisplayFormat.FormatString = "d";
            this.cl_StartDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cl_StartDate.FieldName = "StartDate";
            this.cl_StartDate.GroupFormat.FormatString = "d";
            this.cl_StartDate.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cl_StartDate.Name = "cl_StartDate";
            this.cl_StartDate.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.cl_StartDate.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.cl_StartDate.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.cl_StartDate.Visible = true;
            this.cl_StartDate.VisibleIndex = 0;
            this.cl_StartDate.Width = 118;
            // 
            // cl_CreatedOn
            // 
            this.cl_CreatedOn.Caption = "Created Date";
            this.cl_CreatedOn.FieldName = "CreatedDate";
            this.cl_CreatedOn.GroupFormat.FormatString = "d";
            this.cl_CreatedOn.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cl_CreatedOn.Name = "cl_CreatedOn";
            this.cl_CreatedOn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.cl_CreatedOn.Width = 119;
            // 
            // cl_CreatedBy
            // 
            this.cl_CreatedBy.Caption = "Plan Owner";
            this.cl_CreatedBy.FieldName = "CreateByUser";
            this.cl_CreatedBy.GroupFormat.FormatString = "d";
            this.cl_CreatedBy.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.cl_CreatedBy.Name = "cl_CreatedBy";
            this.cl_CreatedBy.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.cl_CreatedBy.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.cl_CreatedBy.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.cl_CreatedBy.Visible = true;
            this.cl_CreatedBy.VisibleIndex = 2;
            // 
            // cl_LastModifiedBy
            // 
            this.cl_LastModifiedBy.Caption = "Last Modified By";
            this.cl_LastModifiedBy.FieldName = "LastModifiedByUser";
            this.cl_LastModifiedBy.Name = "cl_LastModifiedBy";
            // 
            // cl_LastModifiedOn
            // 
            this.cl_LastModifiedOn.Caption = "Last Modified";
            this.cl_LastModifiedOn.FieldName = "LastModifiedDate";
            this.cl_LastModifiedOn.Name = "cl_LastModifiedOn";
            // 
            // cl_Approved
            // 
            this.cl_Approved.Caption = "Approved ";
            this.cl_Approved.FieldName = "IsApproved";
            this.cl_Approved.Name = "cl_Approved";
            this.cl_Approved.Visible = true;
            this.cl_Approved.VisibleIndex = 3;
            // 
            // cl_ApprovedBy
            // 
            this.cl_ApprovedBy.Caption = "Approved By";
            this.cl_ApprovedBy.FieldName = "ApprovedByUser";
            this.cl_ApprovedBy.Name = "cl_ApprovedBy";
            this.cl_ApprovedBy.Visible = true;
            this.cl_ApprovedBy.VisibleIndex = 4;
            // 
            // cl_Profit
            // 
            this.cl_Profit.Caption = "Profit";
            this.cl_Profit.Name = "cl_Profit";
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
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
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
            // btnAddWeeklyPlan
            // 
            this.btnAddWeeklyPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddWeeklyPlan.Location = new System.Drawing.Point(786, 527);
            this.btnAddWeeklyPlan.Name = "btnAddWeeklyPlan";
            this.btnAddWeeklyPlan.Size = new System.Drawing.Size(139, 23);
            this.btnAddWeeklyPlan.TabIndex = 3;
            this.btnAddWeeklyPlan.Text = "Create New Weekly Plan";
            this.btnAddWeeklyPlan.Click += new System.EventHandler(this.btnAddWeeklyPlan_Click);
            // 
            // frmWeeklyPlanVW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 562);
            this.Controls.Add(this.btnAddWeeklyPlan);
            this.Controls.Add(this.grpMain);
            this.Name = "frmWeeklyPlanVW";
            this.Text = "Manage Weekly Plans";
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).EndInit();
            this.grpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn cl_StartDate;
        private DevExpress.XtraGrid.Columns.GridColumn cl_CreatedOn;
        internal DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        internal DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        internal DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        internal DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        internal DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        internal DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit5;
        internal DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit3;
        internal DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit4;
        internal DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit5;
        internal DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rluCompany;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rtxtPaymentDays;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luGender;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rluJobTitle;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rluMartialStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rluContactType;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraGrid.Columns.GridColumn cl_CutOffDate;
        private DevExpress.XtraGrid.Columns.GridColumn cl_CreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn cl_LastModifiedBy;
        private DevExpress.XtraGrid.Columns.GridColumn cl_LastModifiedOn;
        private DevExpress.XtraGrid.Columns.GridColumn cl_Approved;
        private DevExpress.XtraGrid.Columns.GridColumn cl_ApprovedBy;
        private DevExpress.XtraGrid.Columns.GridColumn cl_Profit;
        private DevExpress.XtraEditors.SimpleButton btnAddWeeklyPlan;
    }
}