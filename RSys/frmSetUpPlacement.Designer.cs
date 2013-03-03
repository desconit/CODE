namespace RSys
{
    partial class frmSetUpPlacement
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
            this.luCode = new DevExpress.XtraEditors.LookUpEdit();
            this.btnSelect = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.luJob = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.luCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luJob.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // luCode
            // 
            this.luCode.Location = new System.Drawing.Point(181, 80);
            this.luCode.Name = "luCode";
            this.luCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.luCode.Properties.Appearance.Options.UseFont = true;
            this.luCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PostCode", 40, "PostCode")});
            this.luCode.Properties.MaxLength = 10;
            this.luCode.Properties.NullText = "Leave this empty for new entry";
            this.luCode.Properties.PopupWidth = 216;
            this.luCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.luCode.Size = new System.Drawing.Size(548, 26);
            this.luCode.TabIndex = 2;
            this.luCode.EditValueChanged += new System.EventHandler(this.luCode_EditValueChanged);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(654, 190);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "Select";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(110, 85);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(49, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Candidate";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(142, 156);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(17, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Job";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(13, 13);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(328, 19);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Select Candidate and Job To Create Placement";
            // 
            // luJob
            // 
            this.luJob.Location = new System.Drawing.Point(181, 151);
            this.luJob.Name = "luJob";
            this.luJob.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.luJob.Properties.Appearance.Options.UseFont = true;
            this.luJob.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luJob.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyName", "CompanyName"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("JobName", "Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PostCode", 40, "PostCode"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("JobSiteName", "SiteName")});
            this.luJob.Properties.MaxLength = 10;
            this.luJob.Properties.NullText = "Leave this empty for new entry";
            this.luJob.Properties.PopupWidth = 216;
            this.luJob.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.luJob.Size = new System.Drawing.Size(548, 26);
            this.luJob.TabIndex = 8;
            // 
            // frmSetUpPlacement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 225);
            this.Controls.Add(this.luJob);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.luCode);
            this.Name = "frmSetUpPlacement";
            this.Text = "Choose Candidate and Job";
            ((System.ComponentModel.ISupportInitialize)(this.luCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luJob.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal DevExpress.XtraEditors.LookUpEdit luCode;
        private DevExpress.XtraEditors.SimpleButton btnSelect;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        internal DevExpress.XtraEditors.LookUpEdit luJob;
    }
}