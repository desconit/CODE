namespace RSys
{
    partial class ucAttachment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAttachment));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grdAttach = new DevExpress.XtraGrid.GridControl();
            this.gvAttach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_AttachmentType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rluRoles = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cl_AttName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rbtnFile = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.cl_Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rImageCombo = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.cl_Attachment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_ScreensID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_RecordID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxtEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.rtxtPhone = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.rtxtEmail = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.lblAttachmentPath = new DevExpress.XtraEditors.LabelControl();
            this.images = new DevExpress.Utils.ImageCollection(this.components);
            this.cl_Deleted = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAttach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rluRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rImageCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.images)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.grdAttach);
            this.groupControl1.Controls.Add(this.lblAttachmentPath);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(567, 310);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Attachments";
            this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // grdAttach
            // 
            this.grdAttach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAttach.Location = new System.Drawing.Point(0, 25);
            this.grdAttach.MainView = this.gvAttach;
            this.grdAttach.Name = "grdAttach";
            this.grdAttach.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rtxtEdit,
            this.rtxtPhone,
            this.rluRoles,
            this.rtxtEmail,
            this.repositoryItemCheckEdit1,
            this.rbtnFile,
            this.rImageCombo});
            this.grdAttach.Size = new System.Drawing.Size(567, 285);
            this.grdAttach.TabIndex = 1;
            this.grdAttach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAttach});
            this.grdAttach.DoubleClick += new System.EventHandler(this.grdAttach_DoubleClick);
            this.grdAttach.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdAttach_KeyPress);
            // 
            // gvAttach
            // 
            this.gvAttach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GridColumn1,
            this.cl_AttachmentType,
            this.cl_AttName,
            this.cl_Type,
            this.cl_Attachment,
            this.cl_ScreensID,
            this.cl_RecordID,
            this.cl_Deleted});
            this.gvAttach.GridControl = this.grdAttach;
            this.gvAttach.Name = "gvAttach";
            this.gvAttach.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvAttach.OptionsView.ShowGroupPanel = false;
            this.gvAttach.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvAttach_InvalidRowException);
            this.gvAttach.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvAttach_ValidateRow);
            this.gvAttach.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvAttach_KeyDown);
            this.gvAttach.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gvAttach_KeyPress);
            // 
            // GridColumn1
            // 
            this.GridColumn1.Caption = "ID";
            this.GridColumn1.FieldName = "ID";
            this.GridColumn1.Name = "GridColumn1";
            // 
            // cl_AttachmentType
            // 
            this.cl_AttachmentType.Caption = "Doc. Type";
            this.cl_AttachmentType.ColumnEdit = this.rluRoles;
            this.cl_AttachmentType.FieldName = "AttachmentTypesID";
            this.cl_AttachmentType.Name = "cl_AttachmentType";
            this.cl_AttachmentType.Visible = true;
            this.cl_AttachmentType.VisibleIndex = 0;
            this.cl_AttachmentType.Width = 83;
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
            this.rluRoles.EditValueChanged += new System.EventHandler(this.rluRoles_EditValueChanged);
            // 
            // cl_AttName
            // 
            this.cl_AttName.Caption = "Attachment";
            this.cl_AttName.ColumnEdit = this.rbtnFile;
            this.cl_AttName.FieldName = "Attachment";
            this.cl_AttName.Name = "cl_AttName";
            this.cl_AttName.Visible = true;
            this.cl_AttName.VisibleIndex = 1;
            this.cl_AttName.Width = 321;
            // 
            // rbtnFile
            // 
            this.rbtnFile.AutoHeight = false;
            this.rbtnFile.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rbtnFile.Name = "rbtnFile";
            this.rbtnFile.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rbtnFile_ButtonClick);
            // 
            // cl_Type
            // 
            this.cl_Type.AppearanceCell.Options.UseTextOptions = true;
            this.cl_Type.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cl_Type.Caption = "Type";
            this.cl_Type.ColumnEdit = this.rImageCombo;
            this.cl_Type.FieldName = "AttType";
            this.cl_Type.Name = "cl_Type";
            this.cl_Type.OptionsColumn.AllowEdit = false;
            this.cl_Type.Visible = true;
            this.cl_Type.VisibleIndex = 2;
            this.cl_Type.Width = 69;
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
            // cl_Attachment
            // 
            this.cl_Attachment.Caption = "Attachment";
            this.cl_Attachment.FieldName = "AttPath";
            this.cl_Attachment.Name = "cl_Attachment";
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
            // lblAttachmentPath
            // 
            this.lblAttachmentPath.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttachmentPath.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblAttachmentPath.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblAttachmentPath.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblAttachmentPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAttachmentPath.Location = new System.Drawing.Point(0, 0);
            this.lblAttachmentPath.Name = "lblAttachmentPath";
            this.lblAttachmentPath.Size = new System.Drawing.Size(567, 25);
            this.lblAttachmentPath.TabIndex = 6;
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
            // ucAttachment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Name = "ucAttachment";
            this.Size = new System.Drawing.Size(567, 310);
            this.Load += new System.EventHandler(this.ucAttachment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAttach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rluRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rImageCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.images)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        internal DevExpress.XtraGrid.GridControl grdAttach;
        internal DevExpress.XtraGrid.Views.Grid.GridView gvAttach;
        internal DevExpress.XtraGrid.Columns.GridColumn GridColumn1;
        internal DevExpress.XtraGrid.Columns.GridColumn cl_AttName;
        internal DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtEdit;
        private DevExpress.XtraGrid.Columns.GridColumn cl_Type;
        internal DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtPhone;
        internal DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rluRoles;
        internal DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtEmail;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rbtnFile;
        public DevExpress.XtraGrid.Columns.GridColumn cl_Attachment;
        private DevExpress.XtraGrid.Columns.GridColumn cl_ScreensID;
        private DevExpress.XtraGrid.Columns.GridColumn cl_RecordID;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox rImageCombo;
        private DevExpress.Utils.ImageCollection images;
        private DevExpress.XtraGrid.Columns.GridColumn cl_AttachmentType;
        internal DevExpress.XtraEditors.LabelControl lblAttachmentPath;
        private DevExpress.XtraGrid.Columns.GridColumn cl_Deleted;
    }
}
