namespace RSys
{
    partial class frmRequirementSearch
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtFirstName = new DevExpress.XtraEditors.TextEdit();
            this.txtLastName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtCity = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.chkTickets = new DevExpress.XtraEditors.CheckEdit();
            this.chkCurrentlyPlacements = new DevExpress.XtraEditors.CheckEdit();
            this.pnlButtons = new DevExpress.XtraEditors.PanelControl();
            this.btnSendTextToCandidates = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.grdDetails = new DevExpress.XtraGrid.GridControl();
            this.gvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cl_Select = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_FirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_LastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_Company = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.xtMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpMain = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.txtMobile = new DevExpress.XtraEditors.TextEdit();
            this.luCounty = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl34 = new DevExpress.XtraEditors.LabelControl();
            this.luTrades = new DevExpress.XtraEditors.LookUpEdit();
            this.lblTrade = new DevExpress.XtraEditors.LabelControl();
            this.labelControl35 = new DevExpress.XtraEditors.LabelControl();
            this.txtContactPostCode = new DevExpress.XtraEditors.TextEdit();
            this.tpTickets = new DevExpress.XtraTab.XtraTabPage();
            this.grdTickets = new DevExpress.XtraGrid.GridControl();
            this.gvTickets = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_TicketType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rluCategory = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cl_Desc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxtComments = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTickets.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCurrentlyPlacements.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).BeginInit();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtMain)).BeginInit();
            this.xtMain.SuspendLayout();
            this.tpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luCounty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luTrades.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactPostCode.Properties)).BeginInit();
            this.tpTickets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTickets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTickets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rluCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtComments)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Location = new System.Drawing.Point(37, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(95, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "First Name(s)";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(138, 13);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtFirstName.Properties.Appearance.Options.UseFont = true;
            this.txtFirstName.Properties.MaxLength = 100;
            this.txtFirstName.Size = new System.Drawing.Size(204, 26);
            this.txtFirstName.TabIndex = 1;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(528, 13);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtLastName.Properties.Appearance.Options.UseFont = true;
            this.txtLastName.Properties.MaxLength = 100;
            this.txtLastName.Size = new System.Drawing.Size(204, 26);
            this.txtLastName.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl2.Location = new System.Drawing.Point(429, 17);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(93, 19);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Last Name(s)";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(138, 45);
            this.txtCity.Name = "txtCity";
            this.txtCity.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtCity.Properties.Appearance.Options.UseFont = true;
            this.txtCity.Properties.MaxLength = 50;
            this.txtCity.Size = new System.Drawing.Size(204, 26);
            this.txtCity.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl3.Location = new System.Drawing.Point(59, 49);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(73, 19);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Town/City";
            // 
            // chkTickets
            // 
            this.chkTickets.EditValue = true;
            this.chkTickets.Location = new System.Drawing.Point(528, 109);
            this.chkTickets.Name = "chkTickets";
            this.chkTickets.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.chkTickets.Properties.Appearance.Options.UseFont = true;
            this.chkTickets.Properties.Caption = "Inclued tickets in search";
            this.chkTickets.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chkTickets.Size = new System.Drawing.Size(204, 24);
            this.chkTickets.TabIndex = 13;
            this.chkTickets.CheckedChanged += new System.EventHandler(this.chkTickets_CheckedChanged);
            // 
            // chkCurrentlyPlacements
            // 
            this.chkCurrentlyPlacements.Location = new System.Drawing.Point(86, 109);
            this.chkCurrentlyPlacements.Name = "chkCurrentlyPlacements";
            this.chkCurrentlyPlacements.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.chkCurrentlyPlacements.Properties.Appearance.Options.UseFont = true;
            this.chkCurrentlyPlacements.Properties.Caption = "Include candidates in placements";
            this.chkCurrentlyPlacements.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chkCurrentlyPlacements.Size = new System.Drawing.Size(256, 24);
            this.chkCurrentlyPlacements.TabIndex = 8;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSendTextToCandidates);
            this.pnlButtons.Controls.Add(this.btnOK);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 556);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(1145, 31);
            this.pnlButtons.TabIndex = 10;
            // 
            // btnSendTextToCandidates
            // 
            this.btnSendTextToCandidates.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSendTextToCandidates.Location = new System.Drawing.Point(852, 2);
            this.btnSendTextToCandidates.Name = "btnSendTextToCandidates";
            this.btnSendTextToCandidates.Size = new System.Drawing.Size(122, 27);
            this.btnSendTextToCandidates.TabIndex = 3;
            this.btnSendTextToCandidates.Text = "Send msg to candidates";
            this.btnSendTextToCandidates.Click += new System.EventHandler(this.btnSendTextToCandidates_Click);
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(974, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 27);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(1061, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 27);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(851, 77);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(204, 27);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "&Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grdDetails
            // 
            this.grdDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDetails.Location = new System.Drawing.Point(0, 181);
            this.grdDetails.MainView = this.gvDetail;
            this.grdDetails.Name = "grdDetails";
            this.grdDetails.Size = new System.Drawing.Size(1145, 375);
            this.grdDetails.TabIndex = 9;
            this.grdDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetail});
            this.grdDetails.Click += new System.EventHandler(this.grdDetails_Click);
            // 
            // gvDetail
            // 
            this.gvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cl_Select,
            this.cl_FirstName,
            this.cl_LastName,
            this.cl_Address,
            this.cl_Company,
            this.gridColumn1});
            this.gvDetail.GridControl = this.grdDetails;
            this.gvDetail.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "TicketType", null, "(Count={0})")});
            this.gvDetail.Name = "gvDetail";
            this.gvDetail.OptionsView.ShowGroupPanel = false;
            this.gvDetail.DoubleClick += new System.EventHandler(this.gvDetail_DoubleClick);
            // 
            // cl_Select
            // 
            this.cl_Select.Caption = "Select";
            this.cl_Select.FieldName = "Select";
            this.cl_Select.Name = "cl_Select";
            this.cl_Select.Visible = true;
            this.cl_Select.VisibleIndex = 0;
            this.cl_Select.Width = 51;
            // 
            // cl_FirstName
            // 
            this.cl_FirstName.Caption = "First Name";
            this.cl_FirstName.FieldName = "FirstName";
            this.cl_FirstName.Name = "cl_FirstName";
            this.cl_FirstName.OptionsColumn.AllowEdit = false;
            this.cl_FirstName.Visible = true;
            this.cl_FirstName.VisibleIndex = 1;
            this.cl_FirstName.Width = 91;
            // 
            // cl_LastName
            // 
            this.cl_LastName.Caption = "Last Name";
            this.cl_LastName.FieldName = "LastName";
            this.cl_LastName.Name = "cl_LastName";
            this.cl_LastName.OptionsColumn.AllowEdit = false;
            this.cl_LastName.Visible = true;
            this.cl_LastName.VisibleIndex = 2;
            this.cl_LastName.Width = 108;
            // 
            // cl_Address
            // 
            this.cl_Address.Caption = "Address line 1";
            this.cl_Address.FieldName = "Address1";
            this.cl_Address.Name = "cl_Address";
            this.cl_Address.OptionsColumn.AllowEdit = false;
            this.cl_Address.Visible = true;
            this.cl_Address.VisibleIndex = 3;
            this.cl_Address.Width = 176;
            // 
            // cl_Company
            // 
            this.cl_Company.Caption = "City";
            this.cl_Company.FieldName = "City";
            this.cl_Company.Name = "cl_Company";
            this.cl_Company.OptionsColumn.AllowEdit = false;
            this.cl_Company.Visible = true;
            this.cl_Company.VisibleIndex = 4;
            this.cl_Company.Width = 73;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Postcode";
            this.gridColumn1.FieldName = "PostCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 5;
            this.gridColumn1.Width = 76;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.MaxLength = 500;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Name = "gridColumn3";
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // xtMain
            // 
            this.xtMain.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 12F);
            this.xtMain.AppearancePage.Header.Options.UseFont = true;
            this.xtMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.xtMain.Font = new System.Drawing.Font("Tahoma", 12F);
            this.xtMain.Location = new System.Drawing.Point(0, 0);
            this.xtMain.Name = "xtMain";
            this.xtMain.SelectedTabPage = this.tpMain;
            this.xtMain.Size = new System.Drawing.Size(1145, 181);
            this.xtMain.TabIndex = 0;
            this.xtMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpMain,
            this.tpTickets});
            // 
            // tpMain
            // 
            this.tpMain.Controls.Add(this.labelControl5);
            this.tpMain.Controls.Add(this.labelControl4);
            this.tpMain.Controls.Add(this.txtEmail);
            this.tpMain.Controls.Add(this.txtMobile);
            this.tpMain.Controls.Add(this.luCounty);
            this.tpMain.Controls.Add(this.labelControl34);
            this.tpMain.Controls.Add(this.btnSearch);
            this.tpMain.Controls.Add(this.luTrades);
            this.tpMain.Controls.Add(this.lblTrade);
            this.tpMain.Controls.Add(this.labelControl35);
            this.tpMain.Controls.Add(this.txtContactPostCode);
            this.tpMain.Controls.Add(this.txtLastName);
            this.tpMain.Controls.Add(this.labelControl1);
            this.tpMain.Controls.Add(this.txtFirstName);
            this.tpMain.Controls.Add(this.labelControl2);
            this.tpMain.Controls.Add(this.chkCurrentlyPlacements);
            this.tpMain.Controls.Add(this.labelControl3);
            this.tpMain.Controls.Add(this.chkTickets);
            this.tpMain.Controls.Add(this.txtCity);
            this.tpMain.Name = "tpMain";
            this.tpMain.Size = new System.Drawing.Size(1139, 147);
            this.tpMain.Text = "General";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Location = new System.Drawing.Point(806, 48);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(39, 19);
            this.labelControl5.TabIndex = 16;
            this.labelControl5.Text = "Email";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(799, 16);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(46, 19);
            this.labelControl4.TabIndex = 14;
            this.labelControl4.Text = "Mobile";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(851, 45);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Properties.Appearance.Options.UseFont = true;
            this.txtEmail.Properties.MaxLength = 100;
            this.txtEmail.Size = new System.Drawing.Size(204, 26);
            this.txtEmail.TabIndex = 17;
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(851, 13);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobile.Properties.Appearance.Options.UseFont = true;
            this.txtMobile.Properties.MaxLength = 20;
            this.txtMobile.Size = new System.Drawing.Size(204, 26);
            this.txtMobile.TabIndex = 15;
            // 
            // luCounty
            // 
            this.luCounty.Location = new System.Drawing.Point(138, 77);
            this.luCounty.Name = "luCounty";
            this.luCounty.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.luCounty.Properties.Appearance.Options.UseFont = true;
            this.luCounty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luCounty.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.luCounty.Properties.MaxLength = 10;
            this.luCounty.Properties.NullText = "";
            this.luCounty.Properties.PopupWidth = 216;
            this.luCounty.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.luCounty.Size = new System.Drawing.Size(204, 26);
            this.luCounty.TabIndex = 7;
            // 
            // labelControl34
            // 
            this.labelControl34.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl34.Location = new System.Drawing.Point(82, 81);
            this.labelControl34.Name = "labelControl34";
            this.labelControl34.Size = new System.Drawing.Size(50, 19);
            this.labelControl34.TabIndex = 6;
            this.labelControl34.Text = "County";
            // 
            // luTrades
            // 
            this.luTrades.Location = new System.Drawing.Point(528, 77);
            this.luTrades.Name = "luTrades";
            this.luTrades.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.luTrades.Properties.Appearance.Options.UseFont = true;
            this.luTrades.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luTrades.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.luTrades.Properties.MaxLength = 10;
            this.luTrades.Properties.NullText = "";
            this.luTrades.Properties.PopupWidth = 216;
            this.luTrades.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.luTrades.Size = new System.Drawing.Size(204, 26);
            this.luTrades.TabIndex = 12;
            // 
            // lblTrade
            // 
            this.lblTrade.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrade.Location = new System.Drawing.Point(481, 81);
            this.lblTrade.Name = "lblTrade";
            this.lblTrade.Size = new System.Drawing.Size(41, 19);
            this.lblTrade.TabIndex = 11;
            this.lblTrade.Text = "Trade";
            // 
            // labelControl35
            // 
            this.labelControl35.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl35.Location = new System.Drawing.Point(459, 49);
            this.labelControl35.Name = "labelControl35";
            this.labelControl35.Size = new System.Drawing.Size(63, 19);
            this.labelControl35.TabIndex = 9;
            this.labelControl35.Text = "Postcode";
            // 
            // txtContactPostCode
            // 
            this.txtContactPostCode.Location = new System.Drawing.Point(528, 45);
            this.txtContactPostCode.Name = "txtContactPostCode";
            this.txtContactPostCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactPostCode.Properties.Appearance.Options.UseFont = true;
            this.txtContactPostCode.Properties.MaxLength = 10;
            this.txtContactPostCode.Size = new System.Drawing.Size(204, 26);
            this.txtContactPostCode.TabIndex = 10;
            // 
            // tpTickets
            // 
            this.tpTickets.Controls.Add(this.grdTickets);
            this.tpTickets.Name = "tpTickets";
            this.tpTickets.Size = new System.Drawing.Size(1139, 147);
            this.tpTickets.Text = "Tickets";
            // 
            // grdTickets
            // 
            this.grdTickets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTickets.Location = new System.Drawing.Point(0, 0);
            this.grdTickets.MainView = this.gvTickets;
            this.grdTickets.Name = "grdTickets";
            this.grdTickets.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rluCategory,
            this.rtxtComments});
            this.grdTickets.Size = new System.Drawing.Size(1139, 147);
            this.grdTickets.TabIndex = 4;
            this.grdTickets.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTickets});
            this.grdTickets.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdTickets_KeyDown);
            // 
            // gvTickets
            // 
            this.gvTickets.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.cl_TicketType,
            this.cl_Name,
            this.cl_Desc});
            this.gvTickets.GridControl = this.grdTickets;
            this.gvTickets.GroupCount = 1;
            this.gvTickets.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "TicketType", null, "(Count={0})")});
            this.gvTickets.Name = "gvTickets";
            this.gvTickets.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvTickets.OptionsView.ShowGroupPanel = false;
            this.gvTickets.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.cl_TicketType, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvTickets.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gvTickets_ShowingEditor);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "ID";
            this.gridColumn2.FieldName = "ID";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // cl_TicketType
            // 
            this.cl_TicketType.Caption = "Ticket Type";
            this.cl_TicketType.FieldName = "TicketType";
            this.cl_TicketType.Name = "cl_TicketType";
            this.cl_TicketType.Visible = true;
            this.cl_TicketType.VisibleIndex = 1;
            // 
            // cl_Name
            // 
            this.cl_Name.Caption = "Category";
            this.cl_Name.ColumnEdit = this.rluCategory;
            this.cl_Name.FieldName = "TicketsID";
            this.cl_Name.Name = "cl_Name";
            this.cl_Name.Visible = true;
            this.cl_Name.VisibleIndex = 0;
            this.cl_Name.Width = 200;
            // 
            // rluCategory
            // 
            this.rluCategory.AutoHeight = false;
            this.rluCategory.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rluCategory.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TicketType", 12, "Ticket Type"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", 8, "Ref. Cat."),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.rluCategory.Name = "rluCategory";
            this.rluCategory.NullText = "";
            this.rluCategory.PopupWidth = 300;
            // 
            // cl_Desc
            // 
            this.cl_Desc.Caption = "Comments";
            this.cl_Desc.ColumnEdit = this.repositoryItemTextEdit1;
            this.cl_Desc.FieldName = "Comments";
            this.cl_Desc.Name = "cl_Desc";
            this.cl_Desc.Visible = true;
            this.cl_Desc.VisibleIndex = 1;
            this.cl_Desc.Width = 438;
            // 
            // rtxtComments
            // 
            this.rtxtComments.Name = "rtxtComments";
            // 
            // frmRequirementSearch
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 587);
            this.ControlBox = false;
            this.Controls.Add(this.grdDetails);
            this.Controls.Add(this.xtMain);
            this.Controls.Add(this.pnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmRequirementSearch";
            this.Text = "Candidate Search";
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTickets.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCurrentlyPlacements.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtMain)).EndInit();
            this.xtMain.ResumeLayout(false);
            this.tpMain.ResumeLayout(false);
            this.tpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luCounty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luTrades.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactPostCode.Properties)).EndInit();
            this.tpTickets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTickets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTickets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rluCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtComments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtFirstName;
        private DevExpress.XtraEditors.TextEdit txtLastName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtCity;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        internal DevExpress.XtraEditors.CheckEdit chkTickets;
        internal DevExpress.XtraEditors.CheckEdit chkCurrentlyPlacements;
        internal DevExpress.XtraEditors.PanelControl pnlButtons;
        internal DevExpress.XtraEditors.SimpleButton btnSearch;
        internal DevExpress.XtraEditors.SimpleButton btnCancel;
        internal DevExpress.XtraGrid.GridControl grdDetails;
        internal DevExpress.XtraGrid.Views.Grid.GridView gvDetail;
        private DevExpress.XtraGrid.Columns.GridColumn cl_FirstName;
        private DevExpress.XtraGrid.Columns.GridColumn cl_LastName;
        private DevExpress.XtraGrid.Columns.GridColumn cl_Select;
        private DevExpress.XtraGrid.Columns.GridColumn cl_Company;
        internal DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraGrid.Columns.GridColumn cl_Address;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        internal DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        internal DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        internal DevExpress.XtraEditors.SimpleButton btnSendTextToCandidates;
        private DevExpress.XtraTab.XtraTabControl xtMain;
        private DevExpress.XtraTab.XtraTabPage tpMain;
        private DevExpress.XtraTab.XtraTabPage tpTickets;
        internal DevExpress.XtraGrid.GridControl grdTickets;
        internal DevExpress.XtraGrid.Views.Grid.GridView gvTickets;
        internal DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn cl_TicketType;
        internal DevExpress.XtraGrid.Columns.GridColumn cl_Name;
        internal DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rluCategory;
        private DevExpress.XtraGrid.Columns.GridColumn cl_Desc;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtComments;
        internal DevExpress.XtraEditors.LookUpEdit luCounty;
        internal DevExpress.XtraEditors.LabelControl labelControl34;
        internal DevExpress.XtraEditors.LookUpEdit luTrades;
        internal DevExpress.XtraEditors.LabelControl lblTrade;
        internal DevExpress.XtraEditors.LabelControl labelControl35;
        private DevExpress.XtraEditors.TextEdit txtContactPostCode;
        internal DevExpress.XtraEditors.LabelControl labelControl5;
        internal DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.TextEdit txtMobile;
    }
}