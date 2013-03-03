namespace RSys
{
    partial class frmCandidateMessagePreview
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtTrade = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtLocation = new DevExpress.XtraEditors.TextEdit();
            this.btnOk = new System.Windows.Forms.Button();
            this.Err = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Err)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(12, 22);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(484, 19);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "Please enter a Trade that best describes the role you are trying to fill";
            // 
            // txtTrade
            // 
            this.txtTrade.Location = new System.Drawing.Point(535, 19);
            this.txtTrade.Name = "txtTrade";
            this.txtTrade.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrade.Properties.Appearance.Options.UseFont = true;
            this.txtTrade.Properties.MaxLength = 50;
            this.txtTrade.Size = new System.Drawing.Size(462, 26);
            this.txtTrade.TabIndex = 14;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(12, 70);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(504, 19);
            this.labelControl1.TabIndex = 15;
            this.labelControl1.Text = "Please enter the area this role this role is located in eg HA8 or Edgware";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(535, 67);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocation.Properties.Appearance.Options.UseFont = true;
            this.txtLocation.Properties.MaxLength = 50;
            this.txtLocation.Size = new System.Drawing.Size(277, 26);
            this.txtLocation.TabIndex = 16;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(841, 102);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 17;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // Err
            // 
            this.Err.ContainerControl = this;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(922, 102);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmCandidateMessagePreview
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 137);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtTrade);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCandidateMessagePreview";
            this.Text = "Candidate text message add Trade and Location";
            ((System.ComponentModel.ISupportInitialize)(this.txtTrade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Err)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtTrade;
        internal DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtLocation;
        private System.Windows.Forms.Button btnOk;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider Err;
        private System.Windows.Forms.Button btnCancel;

    }
}