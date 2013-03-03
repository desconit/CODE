namespace RSys
{
    partial class frmAppSettings
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtSagePath = new DevExpress.XtraEditors.ButtonEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtSageUser = new DevExpress.XtraEditors.TextEdit();
            this.txtSagePwd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtSageConfimPwd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.Err = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSagePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSageUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSagePwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSageConfimPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Err)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtSageConfimPwd);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.txtSagePwd);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtSageUser);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtSagePath);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(500, 165);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Here you can set application\'s parameters";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(54, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(49, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Sage Path";
            // 
            // txtSagePath
            // 
            this.txtSagePath.Location = new System.Drawing.Point(109, 31);
            this.txtSagePath.Name = "txtSagePath";
            this.txtSagePath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtSagePath.Size = new System.Drawing.Size(343, 20);
            this.txtSagePath.TabIndex = 0;
            this.txtSagePath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtSagePath_ButtonClick);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Controls.Add(this.btnCancel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 165);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(500, 28);
            this.panelControl1.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Location = new System.Drawing.Point(348, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(423, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(82, 60);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(22, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "User";
            // 
            // txtSageUser
            // 
            this.txtSageUser.Location = new System.Drawing.Point(110, 57);
            this.txtSageUser.Name = "txtSageUser";
            this.txtSageUser.Size = new System.Drawing.Size(122, 20);
            this.txtSageUser.TabIndex = 3;
            // 
            // txtSagePwd
            // 
            this.txtSagePwd.Location = new System.Drawing.Point(110, 83);
            this.txtSagePwd.Name = "txtSagePwd";
            this.txtSagePwd.Properties.PasswordChar = '*';
            this.txtSagePwd.Size = new System.Drawing.Size(122, 20);
            this.txtSagePwd.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(58, 86);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(46, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Password";
            // 
            // txtSageConfimPwd
            // 
            this.txtSageConfimPwd.Location = new System.Drawing.Point(110, 109);
            this.txtSageConfimPwd.Name = "txtSageConfimPwd";
            this.txtSageConfimPwd.Properties.PasswordChar = '*';
            this.txtSageConfimPwd.Size = new System.Drawing.Size(122, 20);
            this.txtSageConfimPwd.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(18, 112);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(86, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Confirm Password";
            // 
            // Err
            // 
            this.Err.ContainerControl = this;
            // 
            // frmAppSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 193);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAppSettings";
            this.Text = "Application Settings";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSagePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSageUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSagePwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSageConfimPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Err)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ButtonEdit txtSagePath;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        internal DevExpress.XtraEditors.SimpleButton btnSave;
        internal DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.TextEdit txtSageConfimPwd;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtSagePwd;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtSageUser;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        internal DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider Err;

    }
}