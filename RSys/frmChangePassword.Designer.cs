namespace RSys
{
    partial class frmChangePassword
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.Err = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.txtOldPass = new DevExpress.XtraEditors.TextEdit();
            this.txtNewPass = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtConfirmPass = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.pnlButtons = new DevExpress.XtraEditors.PanelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Err)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(34, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(65, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Old Password";
            // 
            // Err
            // 
            this.Err.ContainerControl = this;
            // 
            // txtOldPass
            // 
            this.txtOldPass.Location = new System.Drawing.Point(105, 18);
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.Properties.MaxLength = 20;
            this.txtOldPass.Properties.PasswordChar = '*';
            this.txtOldPass.Size = new System.Drawing.Size(141, 20);
            this.txtOldPass.TabIndex = 1;
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(105, 44);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Properties.MaxLength = 15;
            this.txtNewPass.Properties.PasswordChar = '*';
            this.txtNewPass.Size = new System.Drawing.Size(141, 20);
            this.txtNewPass.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(29, 47);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "New Password";
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Location = new System.Drawing.Point(105, 70);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.Properties.MaxLength = 15;
            this.txtConfirmPass.Properties.PasswordChar = '*';
            this.txtConfirmPass.Size = new System.Drawing.Size(141, 20);
            this.txtConfirmPass.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 73);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(86, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Confirm Password";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnOK);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 115);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(258, 28);
            this.pnlButtons.TabIndex = 6;
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(106, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 24);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(181, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmChangePassword
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(258, 143);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.txtConfirmPass);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtOldPass);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangePassword";
            this.Text = "Change Password";
            ((System.ComponentModel.ISupportInitialize)(this.Err)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal DevExpress.XtraEditors.LabelControl labelControl1;
        internal DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider Err;
        private DevExpress.XtraEditors.TextEdit txtConfirmPass;
        internal DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtNewPass;
        internal DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtOldPass;
        internal DevExpress.XtraEditors.PanelControl pnlButtons;
        internal DevExpress.XtraEditors.SimpleButton btnOK;
        internal DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}