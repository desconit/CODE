namespace RSys
{
    partial class ucNotes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucNotes));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grdAttach = new DevExpress.XtraGrid.GridControl();
            this.gvAttach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_Priority = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rluPriority = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cl_Notes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxtNote = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.cl_ScreensID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_RecordID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_CreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_modifiedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxtEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.rtxtPhone = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.rtxtEmail = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.rbtnFile = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.rImageCombo = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.images = new DevExpress.Utils.ImageCollection(this.components);
            this.cl_Deleted = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAttach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rluPriority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rImageCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.images)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.grdAttach);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(567, 310);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Notess";
            // 
            // grdAttach
            // 
            this.grdAttach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAttach.Location = new System.Drawing.Point(0, 0);
            this.grdAttach.MainView = this.gvAttach;
            this.grdAttach.Name = "grdAttach";
            this.grdAttach.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rtxtEdit,
            this.rtxtPhone,
            this.rluPriority,
            this.rtxtEmail,
            this.repositoryItemCheckEdit1,
            this.rbtnFile,
            this.rImageCombo,
            this.rtxtNote});
            this.grdAttach.Size = new System.Drawing.Size(567, 310);
            this.grdAttach.TabIndex = 1;
            this.grdAttach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAttach});
            this.grdAttach.DoubleClick += new System.EventHandler(this.grdAttach_DoubleClick);
            // 
            // gvAttach
            // 
            this.gvAttach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GridColumn1,
            this.cl_Priority,
            this.cl_Notes,
            this.cl_ScreensID,
            this.cl_RecordID,
            this.cl_CreatedBy,
            this.cl_modifiedBy,
            this.cl_Deleted});
            this.gvAttach.GridControl = this.grdAttach;
            this.gvAttach.Name = "gvAttach";
            this.gvAttach.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvAttach.OptionsView.ShowGroupPanel = false;
            this.gvAttach.RowHeight = 30;
            this.gvAttach.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvAttach_InvalidRowException);
            this.gvAttach.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvAttach_ValidateRow);
            this.gvAttach.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvAttach_KeyDown);
            // 
            // GridColumn1
            // 
            this.GridColumn1.Caption = "ID";
            this.GridColumn1.FieldName = "ID";
            this.GridColumn1.Name = "GridColumn1";
            // 
            // cl_Priority
            // 
            this.cl_Priority.Caption = "Priority";
            this.cl_Priority.ColumnEdit = this.rluPriority;
            this.cl_Priority.FieldName = "NotePrioritiesID";
            this.cl_Priority.Name = "cl_Priority";
            this.cl_Priority.Visible = true;
            this.cl_Priority.VisibleIndex = 0;
            this.cl_Priority.Width = 61;
            // 
            // rluPriority
            // 
            this.rluPriority.AutoHeight = false;
            this.rluPriority.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rluPriority.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.rluPriority.Name = "rluPriority";
            this.rluPriority.NullText = "";
            this.rluPriority.EditValueChanged += new System.EventHandler(this.rluRoles_EditValueChanged);
            // 
            // cl_Notes
            // 
            this.cl_Notes.Caption = "Note";
            this.cl_Notes.ColumnEdit = this.rtxtNote;
            this.cl_Notes.FieldName = "Note";
            this.cl_Notes.Name = "cl_Notes";
            this.cl_Notes.Visible = true;
            this.cl_Notes.VisibleIndex = 1;
            this.cl_Notes.Width = 325;
            // 
            // rtxtNote
            // 
            this.rtxtNote.Name = "rtxtNote";
            // 
            // cl_ScreensID
            // 
            this.cl_ScreensID.Caption = "ScreensID";
            this.cl_ScreensID.FieldName = "ScreensID";
            this.cl_ScreensID.Name = "cl_ScreensID";
            // 
            // cl_RecordID
            // 
            this.cl_RecordID.Caption = "RecordID";
            this.cl_RecordID.FieldName = "RecordID";
            this.cl_RecordID.Name = "cl_RecordID";
            // 
            // cl_CreatedBy
            // 
            this.cl_CreatedBy.Caption = "Created By";
            this.cl_CreatedBy.FieldName = "CreatedByName";
            this.cl_CreatedBy.Name = "cl_CreatedBy";
            this.cl_CreatedBy.OptionsColumn.AllowEdit = false;
            this.cl_CreatedBy.Visible = true;
            this.cl_CreatedBy.VisibleIndex = 2;
            this.cl_CreatedBy.Width = 81;
            // 
            // cl_modifiedBy
            // 
            this.cl_modifiedBy.Caption = "Modified By";
            this.cl_modifiedBy.FieldName = "ModifiedByName";
            this.cl_modifiedBy.Name = "cl_modifiedBy";
            this.cl_modifiedBy.OptionsColumn.AllowEdit = false;
            this.cl_modifiedBy.Visible = true;
            this.cl_modifiedBy.VisibleIndex = 3;
            this.cl_modifiedBy.Width = 79;
            // 
            // rtxtEdit
            // 
            this.rtxtEdit.AutoHeight = false;
            this.rtxtEdit.MaxLength = 50;
            this.rtxtEdit.Name = "rtxtEdit";
            // 
            // rtxtPhone
            // 
            this.rtxtPhone.AutoHeight = false;
            this.rtxtPhone.Mask.EditMask = "(999)000-0000";
            this.rtxtPhone.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.rtxtPhone.Name = "rtxtPhone";
            // 
            // rtxtEmail
            // 
            this.rtxtEmail.AutoHeight = false;
            this.rtxtEmail.MaxLength = 100;
            this.rtxtEmail.Name = "rtxtEmail";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // rbtnFile
            // 
            this.rbtnFile.AutoHeight = false;
            this.rbtnFile.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rbtnFile.Name = "rbtnFile";
            // 
            // rImageCombo
            // 
            this.rImageCombo.AutoHeight = false;
            this.rImageCombo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rImageCombo.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", ".doc", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", null, -1)});
            this.rImageCombo.Name = "rImageCombo";
            // 
            // images
            // 
            this.images.ImageSize = new System.Drawing.Size(24, 24);
            this.images.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("images.ImageStream")));
            this.images.Images.SetKeyName(0, "doc.png");
            this.images.Images.SetKeyName(1, "xls.png");
            this.images.Images.SetKeyName(2, "PDF.png");
            // 
            // cl_Deleted
            // 
            this.cl_Deleted.Caption = "Deleted";
            this.cl_Deleted.FieldName = "Deleted";
            this.cl_Deleted.Name = "cl_Deleted";
            // 
            // ucNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Name = "ucNotes";
            this.Size = new System.Drawing.Size(567, 310);
            this.Load += new System.EventHandler(this.ucNotes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAttach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rluPriority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rImageCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.images)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        internal DevExpress.XtraGrid.GridControl grdAttach;
        internal DevExpress.XtraGrid.Views.Grid.GridView gvAttach;
        internal DevExpress.XtraGrid.Columns.GridColumn GridColumn1;
        internal DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtEdit;
        internal DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtPhone;
        internal DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rluPriority;
        internal DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtEmail;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rbtnFile;
        private DevExpress.XtraGrid.Columns.GridColumn cl_Notes;
        private DevExpress.XtraGrid.Columns.GridColumn cl_ScreensID;
        private DevExpress.XtraGrid.Columns.GridColumn cl_RecordID;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox rImageCombo;
        private DevExpress.Utils.ImageCollection images;
        private DevExpress.XtraGrid.Columns.GridColumn cl_Priority;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit rtxtNote;
        private DevExpress.XtraGrid.Columns.GridColumn cl_CreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn cl_modifiedBy;
        private DevExpress.XtraGrid.Columns.GridColumn cl_Deleted;
    }
}
