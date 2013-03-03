namespace RSys
{
    partial class frmTrades
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
            this.cl_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxtEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.cl_isActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rchkActive = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.rtxtPhone = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.rluRoles = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rtxtEmail = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.xtraTreeListBlending1 = new DevExpress.XtraTreeList.Blending.XtraTreeListBlending();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).BeginInit();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rluRoles)).BeginInit();
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
            this.pnlButtons.Size = new System.Drawing.Size(621, 28);
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
            this.btnSave.Location = new System.Drawing.Point(394, 2);
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
            this.btnDelete.Location = new System.Drawing.Point(469, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 24);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(544, 2);
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
            this.groupControl1.Size = new System.Drawing.Size(621, 347);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Here you can add/edit Trades";
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
            this.rluRoles,
            this.rchkActive,
            this.rtxtEmail});
            this.grdMain.Size = new System.Drawing.Size(617, 324);
            this.grdMain.TabIndex = 1;
            this.grdMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMain});
            // 
            // gvMain
            // 
            this.gvMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cl_ID,
            this.cl_Name,
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
            // cl_Name
            // 
            this.cl_Name.Caption = "Name";
            this.cl_Name.ColumnEdit = this.rtxtEdit;
            this.cl_Name.FieldName = "Name";
            this.cl_Name.Name = "cl_Name";
            this.cl_Name.Visible = true;
            this.cl_Name.VisibleIndex = 0;
            this.cl_Name.Width = 568;
            // 
            // rtxtEdit
            // 
            this.rtxtEdit.AutoHeight = false;
            this.rtxtEdit.MaxLength = 100;
            this.rtxtEdit.Name = "rtxtEdit";
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
            this.cl_isActive.VisibleIndex = 1;
            this.cl_isActive.Width = 100;
            // 
            // rchkActive
            // 
            this.rchkActive.AutoHeight = false;
            this.rchkActive.Name = "rchkActive";
            this.rchkActive.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // rtxtPhone
            // 
            this.rtxtPhone.AutoHeight = false;
            this.rtxtPhone.Mask.EditMask = "(999)000-0000";
            this.rtxtPhone.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.rtxtPhone.Name = "rtxtPhone";
            // 
            // rluRoles
            // 
            this.rluRoles.AutoHeight = false;
            this.rluRoles.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rluRoles.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.rluRoles.Name = "rluRoles";
            this.rluRoles.NullText = "";
            // 
            // rtxtEmail
            // 
            this.rtxtEmail.AutoHeight = false;
            this.rtxtEmail.MaxLength = 100;
            this.rtxtEmail.Name = "rtxtEmail";
            // 
            // frmTrades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CanAdd = true;
            this.CanDelete = true;
            this.CanExecute = true;
            this.CanPrint = true;
            this.CanUpdate = true;
            this.CanView = true;
            this.ClientSize = new System.Drawing.Size(621, 381);
            this.ControlBox = false;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.pnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTrades";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trades";
            this.Load += new System.EventHandler(this.form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rluRoles)).EndInit();
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
        internal DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rluRoles;
        internal DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtEmail;
        private DevExpress.XtraTreeList.Blending.XtraTreeListBlending xtraTreeListBlending1;
    }
}