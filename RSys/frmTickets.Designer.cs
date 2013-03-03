namespace RSys
{
    partial class frmTickets
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
            this.pnlButtons = new DevExpress.XtraEditors.PanelControl();
            this.lblEntry = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grdMain = new DevExpress.XtraGrid.GridControl();
            this.gvMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cl_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_ticketType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rluTicketType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cl_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxtPhone = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.cl_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxtEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.cl_Desc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxtDesc = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.cl_isActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rchkActive = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.rtxtEmail = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.xtraTreeListBlending1 = new DevExpress.XtraTreeList.Blending.XtraTreeListBlending();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).BeginInit();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rluTicketType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtEmail)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.lblEntry);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 353);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(699, 28);
            this.pnlButtons.TabIndex = 2;
            // 
            // lblEntry
            // 
            this.lblEntry.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblEntry.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblEntry.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblEntry.Location = new System.Drawing.Point(28, 6);
            this.lblEntry.Name = "lblEntry";
            this.lblEntry.Size = new System.Drawing.Size(70, 18);
            this.lblEntry.TabIndex = 0;
            this.lblEntry.Text = "XXX";
            this.lblEntry.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Location = new System.Drawing.Point(472, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(547, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 24);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(622, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.grdMain);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(699, 347);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Here you can add/edit Tickets";
            // 
            // grdMain
            // 
            this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMain.Location = new System.Drawing.Point(2, 21);
            this.grdMain.MainView = this.gvMain;
            this.grdMain.Name = "grdMain";
            this.grdMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rtxtEdit,
            this.rtxtPhone,
            this.rluTicketType,
            this.rchkActive,
            this.rtxtEmail,
            this.rtxtDesc});
            this.grdMain.Size = new System.Drawing.Size(695, 324);
            this.grdMain.TabIndex = 1;
            this.grdMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMain});
            // 
            // gvMain
            // 
            this.gvMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cl_ID,
            this.cl_ticketType,
            this.cl_code,
            this.cl_Name,
            this.cl_Desc,
            this.cl_isActive});
            this.gvMain.GridControl = this.grdMain;
            this.gvMain.Name = "gvMain";
            this.gvMain.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvMain.OptionsView.ShowGroupPanel = false;
            this.gvMain.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvMain_RowClick);
            this.gvMain.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvMain_ValidateRow);
            // 
            // cl_ID
            // 
            this.cl_ID.Caption = "ID";
            this.cl_ID.FieldName = "ID";
            this.cl_ID.Name = "cl_ID";
            // 
            // cl_ticketType
            // 
            this.cl_ticketType.Caption = "Ticket Type";
            this.cl_ticketType.ColumnEdit = this.rluTicketType;
            this.cl_ticketType.FieldName = "TicketTypesID";
            this.cl_ticketType.Name = "cl_ticketType";
            this.cl_ticketType.Visible = true;
            this.cl_ticketType.VisibleIndex = 0;
            this.cl_ticketType.Width = 88;
            // 
            // rluTicketType
            // 
            this.rluTicketType.AutoHeight = false;
            this.rluTicketType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rluTicketType.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.rluTicketType.Name = "rluTicketType";
            this.rluTicketType.NullText = "";
            // 
            // cl_code
            // 
            this.cl_code.Caption = "Cat. Ref.";
            this.cl_code.ColumnEdit = this.rtxtPhone;
            this.cl_code.FieldName = "Code";
            this.cl_code.Name = "cl_code";
            this.cl_code.Visible = true;
            this.cl_code.VisibleIndex = 1;
            this.cl_code.Width = 87;
            // 
            // rtxtPhone
            // 
            this.rtxtPhone.AutoHeight = false;
            this.rtxtPhone.MaxLength = 10;
            this.rtxtPhone.Name = "rtxtPhone";
            // 
            // cl_Name
            // 
            this.cl_Name.Caption = "Category";
            this.cl_Name.ColumnEdit = this.rtxtEdit;
            this.cl_Name.FieldName = "Name";
            this.cl_Name.Name = "cl_Name";
            this.cl_Name.Visible = true;
            this.cl_Name.VisibleIndex = 2;
            this.cl_Name.Width = 138;
            // 
            // rtxtEdit
            // 
            this.rtxtEdit.AutoHeight = false;
            this.rtxtEdit.MaxLength = 100;
            this.rtxtEdit.Name = "rtxtEdit";
            // 
            // cl_Desc
            // 
            this.cl_Desc.Caption = "Description";
            this.cl_Desc.ColumnEdit = this.rtxtDesc;
            this.cl_Desc.FieldName = "Description";
            this.cl_Desc.Name = "cl_Desc";
            this.cl_Desc.Visible = true;
            this.cl_Desc.VisibleIndex = 3;
            this.cl_Desc.Width = 234;
            // 
            // rtxtDesc
            // 
            this.rtxtDesc.AutoHeight = false;
            this.rtxtDesc.MaxLength = 500;
            this.rtxtDesc.Name = "rtxtDesc";
            // 
            // cl_isActive
            // 
            this.cl_isActive.AppearanceCell.Options.UseTextOptions = true;
            this.cl_isActive.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cl_isActive.AppearanceHeader.Options.UseTextOptions = true;
            this.cl_isActive.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cl_isActive.Caption = "isActive?";
            this.cl_isActive.ColumnEdit = this.rchkActive;
            this.cl_isActive.FieldName = "isActive";
            this.cl_isActive.Name = "cl_isActive";
            this.cl_isActive.Visible = true;
            this.cl_isActive.VisibleIndex = 4;
            this.cl_isActive.Width = 49;
            // 
            // rchkActive
            // 
            this.rchkActive.AutoHeight = false;
            this.rchkActive.Name = "rchkActive";
            this.rchkActive.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // rtxtEmail
            // 
            this.rtxtEmail.AutoHeight = false;
            this.rtxtEmail.MaxLength = 100;
            this.rtxtEmail.Name = "rtxtEmail";
            // 
            // frmTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CanAdd = true;
            this.CanDelete = true;
            this.CanExecute = true;
            this.CanPrint = true;
            this.CanUpdate = true;
            this.CanView = true;
            this.ClientSize = new System.Drawing.Size(699, 381);
            this.ControlBox = false;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.pnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTickets";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tickets";
            this.Load += new System.EventHandler(this.form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rluTicketType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtEmail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraEditors.PanelControl pnlButtons;
        internal DevExpress.XtraEditors.LabelControl lblEntry;
        internal DevExpress.XtraEditors.SimpleButton btnSave;
        internal DevExpress.XtraEditors.SimpleButton btnDelete;
        internal DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        internal DevExpress.XtraGrid.GridControl grdMain;
        internal DevExpress.XtraGrid.Views.Grid.GridView gvMain;
        internal DevExpress.XtraGrid.Columns.GridColumn cl_ID;
        internal DevExpress.XtraGrid.Columns.GridColumn cl_Name;
        internal DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtEdit;
        internal DevExpress.XtraGrid.Columns.GridColumn cl_isActive;
        internal DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rchkActive;
        internal DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtPhone;
        internal DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rluTicketType;
        internal DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtEmail;
        private DevExpress.XtraTreeList.Blending.XtraTreeListBlending xtraTreeListBlending1;
        private DevExpress.XtraGrid.Columns.GridColumn cl_code;
        private DevExpress.XtraGrid.Columns.GridColumn cl_Desc;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtDesc;
        private DevExpress.XtraGrid.Columns.GridColumn cl_ticketType;
    }
}