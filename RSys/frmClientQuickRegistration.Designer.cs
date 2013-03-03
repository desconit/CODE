namespace RSys
{
    partial class frmClientQuickRegistration
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
            this.components = new System.ComponentModel.Container();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtLastName = new DevExpress.XtraEditors.TextEdit();
            this.txtFirstName = new DevExpress.XtraEditors.TextEdit();
            this.btnCompany = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.luCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtContactMobileNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtContactWorkEmail = new DevExpress.XtraEditors.TextEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.luCode = new DevExpress.XtraEditors.LookUpEdit();
            this.Err = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactMobileNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactWorkEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Err)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.labelControl8.Location = new System.Drawing.Point(12, 12);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(387, 33);
            this.labelControl8.TabIndex = 48;
            this.labelControl8.Text = "Client Contact Quick Registration";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(13, 87);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(89, 19);
            this.labelControl2.TabIndex = 44;
            this.labelControl2.Text = "Forename(s)";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(424, 87);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(63, 19);
            this.labelControl3.TabIndex = 46;
            this.labelControl3.Text = "Surname";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(493, 84);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Properties.Appearance.Options.UseFont = true;
            this.txtLastName.Properties.MaxLength = 50;
            this.txtLastName.Size = new System.Drawing.Size(319, 26);
            this.txtLastName.TabIndex = 47;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(108, 84);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Properties.Appearance.Options.UseFont = true;
            this.txtFirstName.Properties.MaxLength = 50;
            this.txtFirstName.Size = new System.Drawing.Size(213, 26);
            this.txtFirstName.TabIndex = 45;
            // 
            // btnCompany
            // 
            this.btnCompany.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompany.Appearance.Options.UseFont = true;
            this.btnCompany.Location = new System.Drawing.Point(666, 57);
            this.btnCompany.Name = "btnCompany";
            this.btnCompany.Size = new System.Drawing.Size(35, 21);
            this.btnCompany.TabIndex = 51;
            this.btnCompany.Text = "...";
            this.btnCompany.ToolTip = "Create a new company (client)";
            this.btnCompany.Click += new System.EventHandler(this.btnCompany_Click);
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl12.Location = new System.Drawing.Point(35, 59);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(67, 19);
            this.labelControl12.TabIndex = 49;
            this.labelControl12.Text = "Company";
            // 
            // luCompany
            // 
            this.luCompany.Location = new System.Drawing.Point(108, 58);
            this.luCompany.Name = "luCompany";
            this.luCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luCompany.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyName", 35, "Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyRegNo", 10, "Reg. No"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VATNumber", 10, "VAT No.")});
            this.luCompany.Properties.MaxLength = 10;
            this.luCompany.Properties.NullText = "";
            this.luCompany.Properties.PopupWidth = 216;
            this.luCompany.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.luCompany.Size = new System.Drawing.Size(552, 20);
            this.luCompany.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(13, 126);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(81, 19);
            this.labelControl1.TabIndex = 52;
            this.labelControl1.Text = "Work Email";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(379, 126);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(108, 19);
            this.labelControl4.TabIndex = 54;
            this.labelControl4.Text = "Mobile Number";
            // 
            // txtContactMobileNumber
            // 
            this.txtContactMobileNumber.Location = new System.Drawing.Point(493, 123);
            this.txtContactMobileNumber.Name = "txtContactMobileNumber";
            this.txtContactMobileNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactMobileNumber.Properties.Appearance.Options.UseFont = true;
            this.txtContactMobileNumber.Properties.MaxLength = 50;
            this.txtContactMobileNumber.Size = new System.Drawing.Size(319, 26);
            this.txtContactMobileNumber.TabIndex = 55;
            // 
            // txtContactWorkEmail
            // 
            this.txtContactWorkEmail.Location = new System.Drawing.Point(108, 123);
            this.txtContactWorkEmail.Name = "txtContactWorkEmail";
            this.txtContactWorkEmail.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactWorkEmail.Properties.Appearance.Options.UseFont = true;
            this.txtContactWorkEmail.Properties.MaxLength = 50;
            this.txtContactWorkEmail.Size = new System.Drawing.Size(213, 26);
            this.txtContactWorkEmail.TabIndex = 53;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(634, 167);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 31);
            this.btnSave.TabIndex = 56;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(730, 167);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 31);
            this.btnClose.TabIndex = 57;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // luCode
            // 
            this.luCode.Location = new System.Drawing.Point(102, 32);
            this.luCode.Name = "luCode";
            this.luCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyName", 40, "Company")});
            this.luCode.Properties.MaxLength = 10;
            this.luCode.Properties.NullText = "Leave this empty for new entry";
            this.luCode.Properties.PopupWidth = 216;
            this.luCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.luCode.Size = new System.Drawing.Size(596, 18);
            this.luCode.TabIndex = 1;
            this.luCode.EditValueChanged += new System.EventHandler(this.luCode_EditValueChanged);
            this.luCode.Leave += new System.EventHandler(this.luCode_Leave);
            // 
            // Err
            // 
            this.Err.ContainerControl = this;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(634, 167);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 14);
            this.btnDelete.TabIndex = 58;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Visible = false;
            // 
            // frmClientQuickRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CanAdd = true;
            this.CanDelete = true;
            this.CanExecute = true;
            this.CanPrint = true;
            this.CanUpdate = true;
            this.CanView = true;
            this.ClientSize = new System.Drawing.Size(823, 210);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtContactMobileNumber);
            this.Controls.Add(this.txtContactWorkEmail);
            this.Controls.Add(this.btnCompany);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.luCompany);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.btnDelete);
            this.Name = "frmClientQuickRegistration";
            this.Text = "Client Quick Registration";
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactMobileNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactWorkEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Err)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal DevExpress.XtraEditors.LabelControl labelControl8;
        internal DevExpress.XtraEditors.LabelControl labelControl2;
        internal DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtLastName;
        private DevExpress.XtraEditors.TextEdit txtFirstName;
        private DevExpress.XtraEditors.SimpleButton btnCompany;
        internal DevExpress.XtraEditors.LabelControl labelControl12;
        internal DevExpress.XtraEditors.LookUpEdit luCompany;
        internal DevExpress.XtraEditors.LabelControl labelControl1;
        internal DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtContactMobileNumber;
        private DevExpress.XtraEditors.TextEdit txtContactWorkEmail;
        internal DevExpress.XtraEditors.SimpleButton btnSave;
        internal DevExpress.XtraEditors.SimpleButton btnClose;
        internal DevExpress.XtraEditors.LabelControl lblEntry;
        internal DevExpress.XtraEditors.LookUpEdit luCode;
        internal DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider Err;
        internal DevExpress.XtraEditors.SimpleButton btnDelete;
    }
}