namespace RSys
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.chkRememberPass = new DevExpress.XtraEditors.CheckEdit();
            this.Err = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.chkRememberMe = new DevExpress.XtraEditors.CheckEdit();
            this.LabelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.LabelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPass = new DevExpress.XtraEditors.TextEdit();
            this.txtUserId = new DevExpress.XtraEditors.TextEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.cmbDB = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lblVersion = new DevExpress.XtraEditors.LabelControl();
            this.luUser = new DevExpress.XtraEditors.LookUpEdit();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRememberPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Err)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRememberMe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // chkRememberPass
            // 
            this.chkRememberPass.Location = new System.Drawing.Point(281, 228);
            this.chkRememberPass.Name = "chkRememberPass";
            this.chkRememberPass.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkRememberPass.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.chkRememberPass.Properties.Appearance.Options.UseBackColor = true;
            this.chkRememberPass.Properties.Appearance.Options.UseFont = true;
            this.chkRememberPass.Properties.Appearance.Options.UseForeColor = true;
            this.chkRememberPass.Properties.Caption = "Remember my password";
            this.chkRememberPass.Size = new System.Drawing.Size(162, 19);
            this.chkRememberPass.TabIndex = 8;
            this.chkRememberPass.CheckedChanged += new System.EventHandler(this.chkRememberPass_CheckedChanged);
            // 
            // Err
            // 
            this.Err.ContainerControl = this;
            // 
            // chkRememberMe
            // 
            this.chkRememberMe.Location = new System.Drawing.Point(281, 207);
            this.chkRememberMe.Name = "chkRememberMe";
            this.chkRememberMe.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkRememberMe.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkRememberMe.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.chkRememberMe.Properties.Appearance.Options.UseBackColor = true;
            this.chkRememberMe.Properties.Appearance.Options.UseFont = true;
            this.chkRememberMe.Properties.Appearance.Options.UseForeColor = true;
            this.chkRememberMe.Properties.Caption = "Remember me";
            this.chkRememberMe.Size = new System.Drawing.Size(108, 19);
            this.chkRememberMe.TabIndex = 7;
            this.chkRememberMe.CheckedChanged += new System.EventHandler(this.chkRememberMe_CheckedChanged);
            // 
            // LabelControl2
            // 
            this.LabelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.LabelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.LabelControl2.Appearance.Options.UseFont = true;
            this.LabelControl2.Appearance.Options.UseForeColor = true;
            this.LabelControl2.Location = new System.Drawing.Point(221, 158);
            this.LabelControl2.Name = "LabelControl2";
            this.LabelControl2.Size = new System.Drawing.Size(54, 13);
            this.LabelControl2.TabIndex = 3;
            this.LabelControl2.Text = "Password";
            this.LabelControl2.Click += new System.EventHandler(this.LabelControl2_Click);
            // 
            // LabelControl1
            // 
            this.LabelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.LabelControl1.Appearance.Options.UseFont = true;
            this.LabelControl1.Appearance.Options.UseForeColor = true;
            this.LabelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.LabelControl1.Location = new System.Drawing.Point(245, 132);
            this.LabelControl1.Name = "LabelControl1";
            this.LabelControl1.Size = new System.Drawing.Size(30, 13);
            this.LabelControl1.TabIndex = 1;
            this.LabelControl1.Text = "Email";
            this.LabelControl1.Click += new System.EventHandler(this.LabelControl1_Click);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(283, 155);
            this.txtPass.Name = "txtPass";
            this.txtPass.Properties.MaxLength = 50;
            this.txtPass.Properties.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(160, 20);
            this.txtPass.TabIndex = 4;
            this.txtPass.EditValueChanged += new System.EventHandler(this.txtPass_EditValueChanged);
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(283, 129);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Properties.MaxLength = 50;
            this.txtUserId.Size = new System.Drawing.Size(160, 20);
            this.txtUserId.TabIndex = 0;
            this.txtUserId.EditValueChanged += new System.EventHandler(this.txtUserId_EditValueChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(366, 254);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 25);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLogin.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.Appearance.Options.UseFont = true;
            this.btnLogin.Appearance.Options.UseForeColor = true;
            this.btnLogin.Location = new System.Drawing.Point(283, 254);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(77, 25);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "&Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // cmbDB
            // 
            this.cmbDB.Location = new System.Drawing.Point(283, 181);
            this.cmbDB.Name = "cmbDB";
            this.cmbDB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDB.Properties.Items.AddRange(new object[] {
            "Live",
            "Training"});
            this.cmbDB.Size = new System.Drawing.Size(160, 20);
            this.cmbDB.TabIndex = 6;
            this.cmbDB.SelectedIndexChanged += new System.EventHandler(this.cmbDB_SelectedIndexChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(221, 184);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(54, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Database";
            this.labelControl3.Click += new System.EventHandler(this.labelControl3_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(29, 271);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(45, 13);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Version:";
            this.labelControl4.Click += new System.EventHandler(this.labelControl4_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblVersion.Appearance.Options.UseFont = true;
            this.lblVersion.Location = new System.Drawing.Point(85, 269);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(0, 13);
            this.lblVersion.TabIndex = 12;
            this.lblVersion.Click += new System.EventHandler(this.lblVersion_Click);
            // 
            // luUser
            // 
            this.luUser.Location = new System.Drawing.Point(359, 114);
            this.luUser.Name = "luUser";
            this.luUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luUser.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Login", 8, "Login"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.luUser.Properties.MaxLength = 10;
            this.luUser.Properties.NullText = "";
            this.luUser.Properties.PopupWidth = 216;
            this.luUser.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.luUser.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.luUser.Size = new System.Drawing.Size(39, 20);
            this.luUser.TabIndex = 2;
            this.luUser.Visible = false;
            this.luUser.EditValueChanged += new System.EventHandler(this.luUser_EditValueChanged);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureEdit1.EditValue = global::RSys.Properties.Resources.AJK;
            this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.pictureEdit1.Properties.PictureAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.pictureEdit1.Size = new System.Drawing.Size(477, 315);
            this.pictureEdit1.TabIndex = 13;
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(477, 317);
            this.Controls.Add(this.luUser);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.cmbDB);
            this.Controls.Add(this.chkRememberPass);
            this.Controls.Add(this.chkRememberMe);
            this.Controls.Add(this.LabelControl2);
            this.Controls.Add(this.LabelControl1);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.pictureEdit1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chkRememberPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Err)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRememberMe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal DevExpress.XtraEditors.CheckEdit chkRememberPass;
        internal DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider Err;
        internal DevExpress.XtraEditors.CheckEdit chkRememberMe;
        internal DevExpress.XtraEditors.LabelControl LabelControl2;
        internal DevExpress.XtraEditors.LabelControl LabelControl1;
        internal DevExpress.XtraEditors.TextEdit txtPass;
        internal DevExpress.XtraEditors.TextEdit txtUserId;
        internal DevExpress.XtraEditors.SimpleButton btnCancel;
        internal DevExpress.XtraEditors.SimpleButton btnLogin;
        internal DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cmbDB;
        internal DevExpress.XtraEditors.LabelControl labelControl4;
        internal DevExpress.XtraEditors.LabelControl lblVersion;
        internal DevExpress.XtraEditors.LookUpEdit luUser;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}