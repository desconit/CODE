using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;
using DESCONIT.BLL;
using System.Collections;

namespace RSys
{
    public partial class frmContacts : BaseScreen
    {
        BLL bll = new BLL(Tables.Persons, Program.clsuser.CurrentDB);
        bool isEdit, isCalledFromReq;
        public DataSet dsMain;
        ucAttachment ucAttach;
        ucNotes ucNotesCtrl;
        ucDiaryActions ucDiaryCtrl;
        int FilterContactID = -1;
        int ParentCompany = 0;
        int personActiveStatus = 0;
        string LogicalName = "";
        private const string DeleteCol = "Deleted";

        private struct _personTypes
        {
            internal int User, ClientContact, Candidate;
        }

        _personTypes personTypes;



        int PassportID = 2, DrivingLicenceID = 4;
        public frmContacts()
        {
            InitializeComponent();
            LogicalName = this.Name;
            Initialize();

        }

        public frmContacts(string FilterContactID)
        {
            InitializeComponent();

            this.FilterContactID = Convert.ToInt32(FilterContactID);

            Initialize();



        }

        public frmContacts(string FilterContactID, int ID)
        {
            InitializeComponent();
            this.FilterContactID = Convert.ToInt32(FilterContactID);
            Initialize();

            luCode.EditValue = ID;

        }

        public frmContacts(int ID)
        {
            InitializeComponent();
            Initialize();

            luCode.EditValue = ID;

        }

        public frmContacts(bool isCalledFromReq, int CompanyID)
        {
            InitializeComponent();
           
            if (isCalledFromReq)
            {
                this.isCalledFromReq = isCalledFromReq;
                FilterContactID = ContactTypesConts.Client;
            }
            Initialize(); 
            btnSaveNClear.Visible = false;
            luCode.Properties.Buttons.RemoveAt(0);
            btnSave.Text = "Save && Close";
            btnSave.Width = btnSave.Width + 15;
            luCompany.EditValue = CompanyID;
            SetDefaults();
        }

        private void Initialize()
        {
            tpCheckList.Appearance.Header.ForeColor = Color.Red;


            Hashtable ht = new Hashtable();
            ht.Add(Persons.ID, -1);
            ht.Add(Persons.CreatedBy, Program.clsuser.UserID);
            dsMain = bll.ExecuteSP("usp_" + Tables.Persons + "GetByID", ht);
            SetTableNames();
            AddCtrls();
            RefreshData();

            DataSet ds = bll.ExecuteSP("usp_" + Tables.ContactTypes + "Search");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i][ContactTypes.Name].ToString().ToLower().StartsWith("user"))
                        personTypes.User = Convert.ToInt32(ds.Tables[0].Rows[i][ContactTypes.ID]);
                    else if (ds.Tables[0].Rows[i][ContactTypes.Name].ToString().ToLower().StartsWith("client"))
                        personTypes.ClientContact = Convert.ToInt32(ds.Tables[0].Rows[i][ContactTypes.ID]);
                    else if (ds.Tables[0].Rows[i][ContactTypes.Name].ToString().ToLower().StartsWith("candidate"))
                        personTypes.Candidate = Convert.ToInt32(ds.Tables[0].Rows[i][ContactTypes.ID]);
                }
            }

            for (int i = 0; i < dsMain.Tables[Tables.Statuses].Rows.Count; i++)
            {
                if (dsMain.Tables[Tables.Statuses].Rows[i][Statuses.Name].ToString().ToLower().StartsWith("active"))
                {
                    personActiveStatus = Convert.ToInt32(dsMain.Tables[Tables.Statuses].Rows[i][Statuses.ID]);
                    break;
                }
            }


            SetDefaults();

            base.btnBaseAdd = this.btnSaveNClear;
            base.btnBaseEdit = this.btnSave;
            base.btnBaseDelete = this.btnDelete;
            base.SystemObjectName = LogicalName;
            SendKeys.Send("{TAB}");
        }

        private void SetDefaults()
        {
            pnlContactLookup.Visible = false;

            lblCompany.ForeColor = Color.Black;
            lblJobTitle.ForeColor = Color.Black;
            lblForeName.ForeColor = Color.Black;
            lblSurName.ForeColor = Color.Black;
            lblStatus.ForeColor = Color.Black;
            lblWorkEmail.ForeColor = Color.Black;
            lblPassword.ForeColor = Color.Black;
            lblConifrmPassword.ForeColor = Color.Black;
            lblGender.ForeColor = Color.Black;
            ConditionsAdjustment();

            if (this.FilterContactID == personTypes.User)
            {
                this.Text = "Users";
                this.grpMain.Text = "Create/Edit Users";

                tpBackOffice.PageVisible = false;
                tpCheckList.PageVisible = false;
                tpBackOffice.PageVisible = false;
                tpAddress.PageVisible = false;
                tpTickets.PageVisible = false;
                luTrades.Enabled = false;
                luWorkType.Enabled = false;
                pnlTypeofWork.Visible = false;
                dtDOB.Enabled = false;
                //tpTrades.PageVisible = false;

                txtContactAddress1.Enabled = false;
                txtContactAddress2.Enabled = false;
                txtContactCity.Enabled = false;
                txtContactPostCode.Enabled = false;
                luContactCounty.Enabled = false;
                luContactCounty.Enabled = false;


                lblCompany.ForeColor = Color.Red;
                lblJobTitle.ForeColor = Color.Red;
                lblForeName.ForeColor = Color.Red;
                lblSurName.ForeColor = Color.Red;
                lblStatus.ForeColor = Color.Red;
                lblWorkEmail.ForeColor = Color.Red;
                lblPassword.ForeColor = Color.Red;
                lblConifrmPassword.ForeColor = Color.Red;
                lblGender.ForeColor = Color.Red;

                DataRow[] drs = dsMain.Tables[Tables.Companies].Select(Companies.isParentCompany + " = 1");

                if (drs.Length > 0)
                {
                    this.ParentCompany = Convert.ToInt32(drs[0][Companies.ID]);
                }

                luCompany.EditValue = this.ParentCompany;
                this.LogicalName = "frmUsers";

            }
            else if (this.FilterContactID == personTypes.ClientContact)
            {
                this.Text = "Client Contact";
                this.grpMain.Text = "Create/Edit Client Contacts";

                tpBackOffice.PageVisible = false;
                tpCheckList.PageVisible = false;
                tpBackOffice.PageVisible = false;
                tpTickets.PageVisible = false;
                tpAddress.PageVisible = false;
                //tpTrades.PageVisible = false;
                tpNotes.PageVisible = false;
                tpAttachments.PageVisible = false;
                luTrades.Enabled = false;
                pnlTrade.Visible = false;
                luWorkType.Enabled = false;
                dtDOB.Enabled = false;

                txtContactAddress1.Enabled = false;
                txtContactAddress2.Enabled = false;
                txtContactCity.Enabled = false;
                luContactCounty.Enabled = false;
                luContactCounty.Enabled = false;
                this.LogicalName = "frmClientContacts";

                lblCompany.ForeColor = Color.Red;
                lblJobTitle.ForeColor = Color.Red;
                lblForeName.ForeColor = Color.Red;
                lblSurName.ForeColor = Color.Red;
                lblStatus.ForeColor = Color.Red;
                lblGender.ForeColor = Color.Red;
               
            }
            else if (this.FilterContactID == personTypes.Candidate)
            {
                this.Text = "Candidates";
                this.grpMain.Text = "Create/Edit Candidates";

                luStatus.EditValue = personActiveStatus;
                luJobTitle.Enabled = false;
                pnlJobtitle.Visible = false;
                txtContactAddress1.Enabled = false;
                tpAddress.PageVisible = false;
                tpNotes.PageVisible = false;
                tpDiaryActions.PageVisible = false;
                pnlContactLookup.Visible = false;
                pnlCompany.Visible = false;
                tpAttachments.Text = "Identification";
                //tpTrades.PageVisible = false;
                lblTrade.Visible = true;
                luTrades.Visible = true;
                pnlTrade.Visible = true;
                pnlUTR.Visible = true;
                this.LogicalName = "frmCandidates";

               
                lblForeName.ForeColor = Color.Red;
                lblSurName.ForeColor = Color.Red;
                lblGender.ForeColor = Color.Red;
            }
            else
            {
                this.LogicalName = this.Name;
            }
            luContactCountry.EditValue = Program.clsuser.HomeCountryID;
            gvTickets.Appearance.Row.Font = new Font(gvTickets.Appearance.Row.Font.FontFamily, 12f, FontStyle.Regular);
            gvTickets.Appearance.HeaderPanel.Font = new Font(gvTickets.Appearance.HeaderPanel.Font.FontFamily, 12f, FontStyle.Regular);

            //gvTrades.Appearance.Row.Font = new Font(gvTrades.Appearance.Row.Font.FontFamily, 12f, FontStyle.Regular);
            //gvTrades.Appearance.HeaderPanel.Font = new Font(gvTrades.Appearance.HeaderPanel.Font.FontFamily, 12f, FontStyle.Regular);

            ucAttach.gvAttach.Appearance.Row.Font = new Font(ucAttach.gvAttach.Appearance.Row.Font.FontFamily, 12f, FontStyle.Regular);
            ucAttach.gvAttach.Appearance.HeaderPanel.Font = new Font(ucAttach.gvAttach.Appearance.HeaderPanel.Font.FontFamily, 12f, FontStyle.Regular);

            ucNotesCtrl.gvAttach.Appearance.Row.Font = new Font(ucNotesCtrl.gvAttach.Appearance.Row.Font.FontFamily, 12f, FontStyle.Regular);
            ucNotesCtrl.gvAttach.Appearance.HeaderPanel.Font = new Font(ucNotesCtrl.gvAttach.Appearance.HeaderPanel.Font.FontFamily, 12f, FontStyle.Regular);
        }


        private void AddCtrls()
        {
            ucAttach = new ucAttachment(dsMain.Tables[Tables.Attachments], Screens.frmPersons, ScreensNames.frmPersons);
            ucAttach.Location = new Point(0, 0);
            ucAttach.Show();
            ucAttach.Dock = DockStyle.Fill;
            tpAttachments.Controls.Add(ucAttach);

            ucNotesCtrl = new ucNotes(dsMain.Tables[Tables.Notes], Screens.frmPersons, ScreensNames.frmPersons);
            ucNotesCtrl.Location = new Point(0, 0);
            ucNotesCtrl.Show();
            ucNotesCtrl.Dock = DockStyle.Fill;
            tpNotes.Controls.Add(ucNotesCtrl);

            ucDiaryCtrl = new ucDiaryActions(dsMain.Tables[Tables.DiaryActions], Screens.frmPersons, ScreensNames.frmPersons);
            ucDiaryCtrl.Location = new Point(0, 0);
            ucDiaryCtrl.Show();
            ucDiaryCtrl.Dock = DockStyle.Fill;
            tpDiaryActions.Controls.Add(ucDiaryCtrl);


        }

        private void SetTableNames()
        {
            dsMain.Tables[0].TableName = Tables.Persons;
            dsMain.Tables[1].TableName = Tables.ExistingData;
            dsMain.Tables[2].TableName = Tables.Genders;
            dsMain.Tables[3].TableName = Tables.MartialStatuses;
            dsMain.Tables[4].TableName = Tables.ContactTypes;
            dsMain.Tables[5].TableName = Tables.Trades;
            dsMain.Tables[6].TableName = Tables.JobTitles;
            dsMain.Tables[7].TableName = Tables.Statuses;
            dsMain.Tables[8].TableName = Tables.WorkTypes;
            dsMain.Tables[9].TableName = Tables.Counties;
            dsMain.Tables[10].TableName = Tables.Countries;
            dsMain.Tables[11].TableName = Tables.PaymentTypes;
            dsMain.Tables[12].TableName = Tables.PaymentMethods;
            dsMain.Tables[13].TableName = Tables.Companies;
            dsMain.Tables[14].TableName = Tables.PersonBackOffices;
            dsMain.Tables[15].TableName = Tables.Attachments;
            dsMain.Tables[16].TableName = Tables.Notes;
            dsMain.Tables[17].TableName = Tables.DiaryActions;
            dsMain.Tables[18].TableName = Tables.ContactTickets;
            dsMain.Tables[19].TableName = Tables.Tickets;
            dsMain.Tables[20].TableName = Tables.PersonTrades;

            DataRelation relation = new DataRelation("relation", dsMain.Tables[Tables.Persons].Columns[Persons.ID], dsMain.Tables[Tables.PersonBackOffices].Columns[PersonBackOffices.PersonsID], false);
            dsMain.Relations.Add(relation);

            relation = new DataRelation("relTickets", dsMain.Tables[Tables.Persons].Columns[Persons.ID], dsMain.Tables[Tables.ContactTickets].Columns[ContactTickets.PersonsID], false);
            dsMain.Relations.Add(relation);


            relation = new DataRelation("relTrades", dsMain.Tables[Tables.Persons].Columns[Persons.ID], dsMain.Tables[Tables.PersonTrades].Columns[ContactTickets.PersonsID], false);
            dsMain.Relations.Add(relation);
            //relation = new DataRelation("relAttachment", dsMain.Tables[Tables.Persons].Columns[Persons.ID], dsMain.Tables[Tables.Attachments].Columns[Attachments.RecordID], false);
            //dsMain.Relations.Add(relation);


        }

        private void RefreshData()
        {
            luCode.Properties.ValueMember = Persons.ID;
            luCode.Properties.DisplayMember = "Name";
            luCode.Properties.DataSource = dsMain.Tables[Tables.ExistingData];

            luCompany.Properties.ValueMember = Companies.ID;
            luCompany.Properties.DisplayMember = Companies.CompanyName;
            luCompany.Properties.DataSource = dsMain.Tables[Tables.Companies];

            luGender.Properties.ValueMember = Genders.ID;
            luGender.Properties.DisplayMember = Genders.Name;
            luGender.Properties.DataSource = dsMain.Tables[Tables.Genders];

            luMartialStatus.Properties.ValueMember = MartialStatuses.ID;
            luMartialStatus.Properties.DisplayMember = MartialStatuses.Name;
            luMartialStatus.Properties.DataSource = dsMain.Tables[Tables.MartialStatuses];

            luContactType.Properties.ValueMember = ContactTypes.ID;
            luContactType.Properties.DisplayMember = ContactTypes.Name;
            luContactType.Properties.DataSource = dsMain.Tables[Tables.ContactTypes];

            luTrades.Properties.ValueMember = Trades.ID;
            luTrades.Properties.DisplayMember = Trades.Name;
            luTrades.Properties.DataSource = dsMain.Tables[Tables.Trades];

            luJobTitle.Properties.ValueMember = JobTitles.ID;
            luJobTitle.Properties.DisplayMember = JobTitles.Name;
            luJobTitle.Properties.DataSource = dsMain.Tables[Tables.JobTitles];

            luWorkType.Properties.ValueMember = WorkTypes.ID;
            luWorkType.Properties.DisplayMember = WorkTypes.Name;
            luWorkType.Properties.DataSource = dsMain.Tables[Tables.WorkTypes];

            luStatus.Properties.ValueMember = Statuses.ID;
            luStatus.Properties.DisplayMember = Statuses.Name;
            luStatus.Properties.DataSource = dsMain.Tables[Tables.Statuses];

            luContactCountry.Properties.ValueMember = Countries.ID;
            luContactCountry.Properties.DisplayMember = Countries.Name;
            luContactCountry.Properties.DataSource = dsMain.Tables[Tables.Countries];

            luContactCounty.Properties.ValueMember = Counties.ID;
            luContactCounty.Properties.DisplayMember = Counties.Name;
            luContactCounty.Properties.DataSource = dsMain.Tables[Tables.Counties];

            luPaymentMethod.Properties.ValueMember = PaymentMethods.ID;
            luPaymentMethod.Properties.DisplayMember = PaymentMethods.Name;
            luPaymentMethod.Properties.DataSource = dsMain.Tables[Tables.PaymentMethods];

            luPayType.Properties.ValueMember = PaymentTypes.ID;
            luPayType.Properties.DisplayMember = PaymentTypes.Name;
            luPayType.Properties.DataSource = dsMain.Tables[Tables.PaymentTypes];

            luBOffCountry.Properties.ValueMember = Countries.ID;
            luBOffCountry.Properties.DisplayMember = Countries.Name;
            luBOffCountry.Properties.DataSource = dsMain.Tables[Tables.Countries];

            luBOffCounty.Properties.ValueMember = Counties.ID;
            luBOffCounty.Properties.DisplayMember = Counties.Name;
            luBOffCounty.Properties.DataSource = dsMain.Tables[Tables.Counties];


            luBOffCorrCountry.Properties.ValueMember = Countries.ID;
            luBOffCorrCountry.Properties.DisplayMember = Countries.Name;
            luBOffCorrCountry.Properties.DataSource = dsMain.Tables[Tables.Countries];

            luBOffCorrCounty.Properties.ValueMember = Counties.ID;
            luBOffCorrCounty.Properties.DisplayMember = Counties.Name;
            luBOffCorrCounty.Properties.DataSource = dsMain.Tables[Tables.Counties];


            rluCategory.Properties.ValueMember = Tickets.ID;
            rluCategory.Properties.DisplayMember = Tickets.Name;
            rluCategory.Properties.DataSource = dsMain.Tables[Tables.Tickets];

            grdTickets.DataSource = dsMain.Tables[Tables.ContactTickets];
            grdTickets.RefreshDataSource();
            gvTickets.ExpandAllGroups();

            //grdTrades.DataSource = dsMain.Tables[Tables.PersonTrades];
            //grdTrades.RefreshDataSource();

            ucAttach.RefreshDataSource(dsMain.Tables[Tables.Attachments]);
            ucNotesCtrl.RefreshDataSource(dsMain.Tables[Tables.Notes]);
            ucDiaryCtrl.RefreshDataSource(dsMain.Tables[Tables.DiaryActions]);

            if (FilterContactID > 0)
            {
                luContactType.EditValue = FilterContactID;
                luContactType.Properties.ReadOnly = true;
            }
            else
            {

                luContactType.Properties.ReadOnly = false;
            }

            SetDefaults();
        }

        private void ClearFields()
        {
            try
            {
                grpLogin.Enabled = false;
                txtFirstName.EditValue = null;
                txtLastName.EditValue = null;
                luCompany.EditValue = null;
                dtDOB.EditValue = null;
                txtAge.EditValue = null;
                luGender.EditValue = null;
                luMartialStatus.EditValue = null;

                if (FilterContactID > 0)
                {
                    luContactType.EditValue = FilterContactID;
                    ///luContactType.Enabled = false;
                    luContactType.Properties.ReadOnly = true;
                }
                else
                {
                    luContactType.EditValue = null;
                    //luContactType.Enabled = true;
                    luContactType.Properties.ReadOnly = false;
                }

                luTrades.EditValue = 1;
                luJobTitle.EditValue = null;
                luStatus.EditValue = null;
                luWorkType.EditValue = 3;

                txtContactAddress1.EditValue = null;
                txtContactAddress2.EditValue = null;
                txtContactCity.EditValue = null;
                txtContactPostCode.EditValue = null;
                txtUTR.EditValue = null;
                txtNI.EditValue = null;
                chkDriving.Checked = false;
                luContactCountry.EditValue = null;
                luContactCounty.EditValue = null;
                txtContactMobile.EditValue = null;
                txtContactTel.EditValue = null;
                txtContactFax.EditValue = null;
                txtContactEmail.EditValue = null;
                txtContactWorkEmail.EditValue = null;
                txtContactWorkTel.EditValue = null;
                txtContactWorkMobile.EditValue = null;
                txtContactComments.EditValue = null;

                txtPassword.EditValue = null;
                txtConfirmPass.EditValue = null;


                chkIsAppUser.Checked = false;
                chkActive.Checked = true;

                txtBackofficeCompanyRegNo.EditValue = null;
                txtNationalInsurace.EditValue = null;
                luPaymentMethod.EditValue = null;
                txtVAT.EditValue = null;
                txtTaxCode.EditValue = null;
                luPayType.EditValue = null;
                txtBackOfficeComments.EditValue = null;

                txtBOffAddress1.EditValue = null;
                txtBOffAddress2.EditValue = null;
                txtBOffCity.EditValue = null;
                txtBOffPostCode.EditValue = null;
                luBOffCountry.EditValue = null;
                luBOffCounty.EditValue = null;
                txtBOffTel.EditValue = null;
                txtBOffFax.EditValue = null;


                txtBOffCorrAddress1.EditValue = null;
                txtBOffCorrAddrss2.EditValue = null;
                txtBOffCorrCity.EditValue = null;
                txtBOffCorrPostCode.EditValue = null;
                luBOffCorrCountry.EditValue = null;
                luBOffCorrCounty.EditValue = null;
                txtBOffCorrTel.EditValue = null;
                txtBOffCorrFax.EditValue = null;

                //////checklist tab////////////
                chkPassport.Checked = false;
                txtPassortAttachment.EditValue = null;
                txtPassortAttachment.Tag = "";
                chkProofofAddress.Checked = false;
                chkBirthCertificate.Checked = false;
                chkCV.Checked = false;
                chkPayDetails.Checked = false;
                chkVisa.Checked = false;
                chkDrivingLicence.Checked = false;
                txtLicenceAttachment.EditValue = null;
                txtLicenceAttachment.Tag = string.Empty;

                tpCheckList.Appearance.Header.ForeColor = Color.Red;
                //tpCheckList.Appearance.Header.Font = new Font(tpCheckList.Appearance.Header.Font, FontStyle.Bold);
                //////checklist tab////////////


                lblEntry.Text = string.Empty;
                btnDelete.Enabled = false;
                Hashtable ht = new Hashtable();
                ht.Add(Persons.ID, -1);
                ht.Add(Persons.CreatedBy, Program.clsuser.UserID);
                dsMain = bll.ExecuteSP("usp_" + Tables.Persons + "GetByID", ht);

                SetTableNames();

                RefreshData();
                isEdit = false;

                if (luContactType.EditValue != null && luContactType.EditValue.ToString().Equals(ContactTypesConts.Users.ToString()))
                    grpLogin.Enabled = true;
                else
                    grpLogin.Enabled = false;
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            {
            }
        }

        private void GetByID()
        {
            Hashtable ht = new Hashtable();
            ht.Add(Persons.ID, Convert.ToInt32(luCode.EditValue));
            ht.Add(Persons.CreatedBy, Program.clsuser.UserID);
            dsMain = bll.ExecuteSP("usp_" + Tables.Persons + "GetByID", ht);

            //dsMain = bll.GetByID(Convert.ToInt32(luCode.EditValue));
            SetTableNames();
        }
        private void BindFields()
        {
            try
            {

                txtFirstName.Text = dsMain.Tables[Tables.Persons].Rows[0][Persons.FirstName].ToString();
                txtLastName.Text = dsMain.Tables[Tables.Persons].Rows[0][Persons.LastName].ToString();
                
                if (dsMain.Tables[Tables.Persons].Rows[0][Persons.DOB] != DBNull.Value)
                    dtDOB.EditValue = Convert.ToDateTime(dsMain.Tables[Tables.Persons].Rows[0][Persons.DOB]);

                luCompany.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.CompaniesID];
                txtAge.EditValue = dsMain.Tables[Tables.Persons].Rows[0]["Age"];
                luGender.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.GendersID];
                luMartialStatus.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.MartialStatusesID];
                luContactType.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.ConatactTypesID];

                int personTradeId = 1;
                int.TryParse(dsMain.Tables[Tables.Persons].Rows[0][Persons.TradesID].ToString(), out personTradeId);
                if(personTradeId == 0)
                    personTradeId = 1;
                luTrades.EditValue = personTradeId;
                
                
                luJobTitle.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.JobTitlesID];


                int personStatus = 1;
                int.TryParse(dsMain.Tables[Tables.Persons].Rows[0][Persons.StatusesID].ToString(), out personStatus);
                if (personStatus == 0)
                    personStatus = 1;
                luStatus.EditValue = personStatus;

                int personTypeOfWork = 4;
                int.TryParse(dsMain.Tables[Tables.Persons].Rows[0][Persons.WorkTypesID].ToString(), out personTypeOfWork);
                if (personTypeOfWork == 0)
                    personTypeOfWork = 4;
                luWorkType.EditValue = personTypeOfWork;

                txtContactAddress1.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.Address1];
                txtContactAddress2.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.Address2];
                txtContactCity.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.City];
                txtContactPostCode.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.Postcode];
                luContactCountry.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.CountriesID];
                luContactCounty.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.CountiesID];
                txtContactMobile.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.PersonalMobile];
                txtContactTel.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.HomeTel];
                txtContactFax.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.HomeFax];
                txtContactEmail.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.PersonalEmail];
                txtContactWorkEmail.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.WorkEmail];
                txtContactWorkTel.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.WorkTel];
                txtContactWorkMobile.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.WorkMobile];
                txtContactComments.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.Comments];

                txtUTR.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.UTR];
                txtNI.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.NI]; ;
                chkDriving.Checked = Convert.ToBoolean(dsMain.Tables[Tables.Persons].Rows[0][Persons.isDriving]);

                txtPassword.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.Password];
                txtConfirmPass.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.Password];


                chkIsAppUser.Checked = Convert.ToInt32(dsMain.Tables[Tables.Persons].Rows[0][Persons.ConatactTypesID]).Equals(ContactTypesConts.Users);
                chkActive.Checked = Convert.ToBoolean(dsMain.Tables[Tables.Persons].Rows[0][Persons.isActive]);

                chkPassport.Checked = Convert.ToBoolean(dsMain.Tables[Tables.Persons].Rows[0][Persons.isPassport]);
                chkProofofAddress.Checked = Convert.ToBoolean(dsMain.Tables[Tables.Persons].Rows[0][Persons.isProofOfAddress]);
                chkBirthCertificate.Checked = Convert.ToBoolean(dsMain.Tables[Tables.Persons].Rows[0][Persons.isBirthCertificate]);
                chkCV.Checked = Convert.ToBoolean(dsMain.Tables[Tables.Persons].Rows[0][Persons.isCV]);
                chkPayDetails.Checked = Convert.ToBoolean(dsMain.Tables[Tables.Persons].Rows[0][Persons.isPayDetails]);
                chkVisa.Checked = Convert.ToBoolean(dsMain.Tables[Tables.Persons].Rows[0][Persons.isVisa]);
                chkDrivingLicence.Checked = Convert.ToBoolean(dsMain.Tables[Tables.Persons].Rows[0][Persons.isDrivingLicence]);

                if (dsMain.Tables[Tables.PersonBackOffices].Rows.Count > 0)
                {
                    txtBackofficeCompanyRegNo.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CompanyRegNo];
                    txtNationalInsurace.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.NationalInsuranceNo];
                    luPaymentMethod.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.PaymentMethodsID];
                    txtVAT.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.VATNumber];
                    txtTaxCode.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.TaxCode];
                    luPayType.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.PayTypesID];
                    txtBackOfficeComments.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.Comments];

                    txtBOffAddress1.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.Address1];
                    txtBOffAddress2.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.Address2];
                    txtBOffCity.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.City];
                    txtBOffPostCode.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.Postcode];
                    luBOffCountry.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CountriesID];
                    luBOffCounty.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CountiesID];
                    txtBOffTel.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.Tel];
                    txtBOffFax.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.Fax];


                    txtBOffCorrAddress1.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrAddress1];
                    txtBOffCorrAddrss2.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrAddress2];
                    txtBOffCorrCity.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrCity];
                    txtBOffCorrPostCode.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrPostcode];
                    luBOffCorrCountry.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrCountriesID];
                    luBOffCorrCounty.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrCountiesID];
                    txtBOffCorrTel.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrTel];
                    txtBOffCorrFax.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrFax];
                }

                grdTickets.DataSource = dsMain.Tables[Tables.ContactTickets];
                grdTickets.RefreshDataSource();
                gvTickets.ExpandAllGroups();

                //grdTrades.DataSource = dsMain.Tables[Tables.PersonTrades];
                //grdTrades.RefreshDataSource();

                ucAttach.RefreshDataSource(dsMain.Tables[Tables.Attachments]);
                ucNotesCtrl.RefreshDataSource(dsMain.Tables[Tables.Notes]);
                ucDiaryCtrl.RefreshDataSource(dsMain.Tables[Tables.DiaryActions]);

                DataRow[] drs = dsMain.Tables[Tables.Attachments].Select(Attachments.AttachmentTypesID + "=" + PassportID.ToString());

                if (drs.Length > 0)
                {
                    try
                    {
                        txtPassortAttachment.Tag = drs[0][Attachments.AttPath].ToString();
                        txtPassortAttachment.EditValue = drs[0][Attachments.Attachment].ToString();
                    }
                    catch (Exception ex)
                    { }
                    txtPassortAttachment.EditValue = drs[0][Attachments.Attachment].ToString();
                    txtPassortAttachment.Tag = drs[0][Attachments.AttPath].ToString();
                }

                drs = dsMain.Tables[Tables.Attachments].Select(Attachments.AttachmentTypesID + "=" + DrivingLicenceID.ToString());

                if (drs.Length > 0)
                {
                    try
                    {
                        txtLicenceAttachment.Tag = drs[0][Attachments.AttPath].ToString();
                        txtLicenceAttachment.EditValue = drs[0][Attachments.Attachment].ToString();

                    }
                    catch (Exception ex)
                    {
                    }
                    txtLicenceAttachment.EditValue = drs[0][Attachments.Attachment].ToString();
                    txtLicenceAttachment.Tag = drs[0][Attachments.AttPath].ToString();
                }



                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
        }

        private void luCode_EditValueChanged(System.Object sender, System.EventArgs e)
        {
            //ClearFields();
            try
            {
                if (Convert.ToInt32(luCode.EditValue) == -1)
                {
                    lblEntry.Text = "New Entry";
                    isEdit = false;
                    return;
                }



                if (luCode.EditValue == null | object.ReferenceEquals(luCode.EditValue, DBNull.Value))
                {
                    isEdit = false;
                }
                else if (Convert.ToInt32(luCode.EditValue) == -1)
                {
                    isEdit = false;

                }
                else
                {
                    isEdit = true;
                }

                if ((isEdit))
                {
                    lblEntry.Text = "";
                    GetByID();
                    BindFields();

                }
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);

            }
            finally
            { }
        }

        private void gvMain_InvalidRowException(System.Object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {

        }

        private bool Save()
        {
            if (!Messages.Save())
                return false;

            if (!Validation())
                return false;

            try
            {

                if (dsMain.Tables[Tables.Persons].Rows.Count == 0)
                    dsMain.Tables[Tables.Persons].Rows.Add(dsMain.Tables[Tables.Persons].NewRow());

                if (dsMain.Tables[Tables.PersonBackOffices].Rows.Count == 0)
                    dsMain.Tables[Tables.PersonBackOffices].Rows.Add(dsMain.Tables[Tables.PersonBackOffices].NewRow());

                if (pnlCompany.Visible)
                    dsMain.Tables[Tables.Persons].Rows[0][Persons.CompaniesID] = luCompany.EditValue == null ? -1: Convert.ToInt32(luCompany.EditValue);
                else
                    dsMain.Tables[Tables.Persons].Rows[0][Persons.CompaniesID] = -1;

                dsMain.Tables[Tables.Persons].Rows[0][Persons.FirstName] = txtFirstName.Text;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.LastName] = txtLastName.Text;

                if (!dtDOB.Text.Equals(string.Empty))
                    dsMain.Tables[Tables.Persons].Rows[0][Persons.DOB] = dtDOB.EditValue.ToString();

                if (!luGender.Text.Equals(string.Empty))
                    dsMain.Tables[Tables.Persons].Rows[0][Persons.GendersID] = luGender.EditValue;

                if (!luMartialStatus.Text.Equals(string.Empty))
                    dsMain.Tables[Tables.Persons].Rows[0][Persons.MartialStatusesID] = luMartialStatus.EditValue;
                else
                    dsMain.Tables[Tables.Persons].Rows[0][Persons.MartialStatusesID] = DBNull.Value;

                if (!luContactType.Text.Equals(string.Empty))
                    dsMain.Tables[Tables.Persons].Rows[0][Persons.ConatactTypesID] = luContactType.EditValue;
                else
                    dsMain.Tables[Tables.Persons].Rows[0][Persons.ConatactTypesID] = DBNull.Value;

                if (!luTrades.Text.Equals(string.Empty))
                    dsMain.Tables[Tables.Persons].Rows[0][Persons.TradesID] = luTrades.EditValue;
                else
                    dsMain.Tables[Tables.Persons].Rows[0][Persons.TradesID] = DBNull.Value;

                if (luContactType.EditValue == null || luContactType.EditValue.ToString().Equals(ContactTypesConts.Candidate.ToString()))
                    dsMain.Tables[Tables.Persons].Rows[0][Persons.JobTitlesID] = -1;
                else
                {
                    if (!luJobTitle.Text.Equals(string.Empty))
                        dsMain.Tables[Tables.Persons].Rows[0][Persons.JobTitlesID] = luJobTitle.EditValue;
                    else
                        dsMain.Tables[Tables.Persons].Rows[0][Persons.JobTitlesID] = DBNull.Value;
                }

                if (!luStatus.Text.Equals(string.Empty))
                    dsMain.Tables[Tables.Persons].Rows[0][Persons.StatusesID] = luStatus.EditValue;
                else
                    dsMain.Tables[Tables.Persons].Rows[0][Persons.StatusesID] = DBNull.Value;
                if (!luWorkType.Text.Equals(string.Empty))
                    dsMain.Tables[Tables.Persons].Rows[0][Persons.WorkTypesID] = luWorkType.EditValue;
                else
                    dsMain.Tables[Tables.Persons].Rows[0][Persons.WorkTypesID] = DBNull.Value;

                if (!luWorkType.Text.Equals(string.Empty))
                    dsMain.Tables[Tables.Persons].Rows[0][Persons.WorkTypesID] = luWorkType.EditValue;
                else
                    dsMain.Tables[Tables.Persons].Rows[0][Persons.WorkTypesID] = DBNull.Value;

                if (!luContactCountry.Text.Equals(string.Empty))
                    dsMain.Tables[Tables.Persons].Rows[0][Persons.CountriesID] = luContactCountry.EditValue;


                if (!luContactCounty.Text.Equals(string.Empty))
                    dsMain.Tables[Tables.Persons].Rows[0][Persons.CountiesID] = luContactCounty.EditValue;


                dsMain.Tables[Tables.Persons].Rows[0][Persons.Address1] = txtContactAddress1.Text;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.Address2] = txtContactAddress2.EditValue;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.City] = txtContactCity.EditValue;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.Postcode] = txtContactPostCode.EditValue;

                dsMain.Tables[Tables.Persons].Rows[0][Persons.PersonalMobile] = txtContactMobile.EditValue;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.HomeTel] = txtContactTel.EditValue;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.HomeFax] = txtContactFax.EditValue;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.PersonalEmail] = txtContactEmail.EditValue;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.WorkEmail] = txtContactWorkEmail.EditValue;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.WorkTel] = txtContactWorkTel.EditValue;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.WorkMobile] = txtContactWorkMobile.EditValue;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.Comments] = txtContactComments.EditValue;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.Password] = txtPassword.EditValue;

                dsMain.Tables[Tables.Persons].Rows[0][Persons.UTR] = txtUTR.EditValue;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.NI] = txtNI.EditValue;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.isDriving] = chkDriving.Checked;

                dsMain.Tables[Tables.Persons].Rows[0][Persons.isStaff] = dsMain.Tables[Tables.Persons].Rows[0][Persons.ConatactTypesID].ToString().Equals(ContactTypesConts.Users.ToString());
                dsMain.Tables[Tables.Persons].Rows[0][Persons.isActive] = 1;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.isPassport] = chkPassport.Checked;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.isProofOfAddress] = chkProofofAddress.Checked;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.isBirthCertificate] = chkBirthCertificate.Checked;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.isCV] = chkCV.Checked;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.isPayDetails] = chkPayDetails.Checked;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.isVisa] = chkVisa.Checked;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.isDrivingLicence] = chkDrivingLicence.Checked;


                if (dsMain.Tables[Tables.PersonBackOffices].Rows.Count > 0)
                {
                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CompanyRegNo] = txtBackofficeCompanyRegNo.EditValue;
                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.NationalInsuranceNo] = txtNationalInsurace.EditValue;
                    if (!luPaymentMethod.Text.Equals(string.Empty))
                        dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.PaymentMethodsID] = luPaymentMethod.EditValue;

                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.VATNumber] = txtVAT.EditValue;
                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.TaxCode] = txtTaxCode.EditValue;

                    if (!luPayType.Text.Equals(string.Empty))
                        dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.PayTypesID] = luPayType.EditValue;

                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.Comments] = txtBackOfficeComments.EditValue;

                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.Address1] = txtBOffAddress1.EditValue;
                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.Address2] = txtBOffAddress2.EditValue;
                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.City] = txtBOffCity.EditValue;
                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.Postcode] = txtBOffPostCode.EditValue;

                    if (!luBOffCorrCountry.Text.Equals(string.Empty))
                        dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CountriesID] = luBOffCorrCountry.EditValue;

                    if (!luBOffCorrCounty.Text.Equals(string.Empty))
                        dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CountiesID] = luBOffCorrCounty.EditValue;

                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.Tel] = txtBOffTel.EditValue;
                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.Fax] = txtBOffFax.EditValue;

                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrAddress1] = txtBOffCorrAddress1.EditValue;
                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrAddress2] = txtBOffCorrAddrss2.EditValue;
                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrCity] = txtBOffCorrCity.EditValue;
                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrPostcode] = txtBOffCorrPostCode.EditValue;
                    if (!luBOffCorrCountry.Text.Equals(string.Empty))
                        dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrCountriesID] = luBOffCorrCountry.EditValue;

                    if (!luBOffCorrCounty.Text.Equals(string.Empty))
                        dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrCountiesID] = luBOffCorrCounty.EditValue;

                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrTel] = txtBOffCorrTel.EditValue;
                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrFax] = txtBOffCorrFax.EditValue;

                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.isActive] = 1;
                }


                for (int i = 0; i < dsMain.Tables[Tables.PersonTrades].Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(dsMain.Tables[Tables.PersonTrades].Rows[i][PersonTrades.ID].ToString()))
                    {
                        if (dsMain.Tables[Tables.PersonTrades].Rows[i].RowState == DataRowState.Modified && Convert.ToBoolean(dsMain.Tables[Tables.PersonTrades].Rows[i]["Checked"]))
                        {
                            dsMain.Tables[Tables.PersonTrades].Rows[i].AcceptChanges();
                            dsMain.Tables[Tables.PersonTrades].Rows[i].SetAdded();
                        }
                    }
                    else
                    {
                        if (dsMain.Tables[Tables.PersonTrades].Rows[i].RowState == DataRowState.Modified && !Convert.ToBoolean(dsMain.Tables[Tables.PersonTrades].Rows[i]["Checked"]))
                        {
                            dsMain.Tables[Tables.PersonTrades].Rows[i].AcceptChanges();
                            dsMain.Tables[Tables.PersonTrades].Rows[i].Delete();
                        }
                    }

                }

                if (dsMain.Relations.Contains("relAttachment"))
                    dsMain.Relations.Remove("relAttachment");

                dsMain.Tables.Remove(Tables.Attachments);
                dsMain.Tables.Add(ucAttach.GetAttachmentTable().Copy());
                DataRelation relation = new DataRelation("relAttachment", dsMain.Tables[Tables.Persons].Columns[Persons.ID], dsMain.Tables[Tables.Attachments].Columns[Attachments.RecordID], false);
                dsMain.Relations.Add(relation);


                if (dsMain.Relations.Contains("relNotes"))
                    dsMain.Relations.Remove("relNotes");

                dsMain.Tables.Remove(Tables.Notes);
                dsMain.Tables.Add(ucNotesCtrl.GetNotesTable().Copy());
                relation = new DataRelation("relNotes", dsMain.Tables[Tables.Persons].Columns[Persons.ID], dsMain.Tables[Tables.Notes].Columns[Attachments.RecordID], false);
                dsMain.Relations.Add(relation);

                if (dsMain.Relations.Contains("relDiary"))
                    dsMain.Relations.Remove("relDiary");

                dsMain.Tables.Remove(Tables.DiaryActions);
                dsMain.Tables.Add(ucDiaryCtrl.GetScheduleTable().Copy());
                relation = new DataRelation("relDiary", dsMain.Tables[Tables.Persons].Columns[Persons.ID], dsMain.Tables[Tables.DiaryActions].Columns[Attachments.RecordID], false);
                dsMain.Relations.Add(relation);


                MarkAsDelete();
                dsMain = bll.SaveComplex(dsMain, isEdit);
                SetTableNames();

                return true;

            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
                return false;
            }
            finally

            { }
        }


        private void UpdateView()
        {
            if (this.Owner.GetType() == typeof(frmContactsVW))
            {
                ((frmContactsVW)(this.Owner)).RefreshData(Convert.ToInt32(luCode.EditValue));
                ((frmMain)(((frmContactsVW)(this.Owner)).MdiParent)).RefreshDiaryActions();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Save())
                    return;

                //GetByID();
                RefreshData();
                if (luCode.EditValue == null)
                    luCode.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.ID];
                BindFields();


                if (isCalledFromReq)
                {
                    this.Visible = false;
                }
                else
                {
                    UpdateView();
                }

                lblEntry.Text = string.Empty;
                this.isEdit = true;
                btnDelete.Enabled = true;

            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            {
            }
        }


        private bool Validation()
        {
            bool check = true;
            Err.ClearErrors();

            bool isErrOnContactTab = false;


            if (luContactType.EditValue != null && luContactType.EditValue.ToString().Equals(ContactTypesConts.Users.ToString()))
            {
                grpLogin.Enabled = true;
                if (txtPassword.Text.Equals(string.Empty))
                {
                    Err.SetError(txtPassword, "Must enter password.");
                    isErrOnContactTab = true;
                    txtPassword.Focus();
                    check = false;
                }
                else if (txtPassword.Text != txtConfirmPass.Text)
                {
                    Err.SetError(txtPassword, "Password and confirm password don't match.");
                    txtPassword.Focus();
                    isErrOnContactTab = true;
                    check = false;
                }
                else
                {
                    Err.SetError(txtPassword, null);
                }


                if ((txtContactWorkEmail.Text == string.Empty) || (!Functions.EmailAddressCheck(txtContactWorkEmail.Text)))
                {

                    Err.SetError(txtContactWorkEmail, "Must enter valid email address.");
                    if (xtMain.SelectedTabPage == tpPersonalAddress)
                        txtContactWorkEmail.Focus();
                    check = false;
                    isErrOnContactTab = true;
                }

                else
                {
                    Err.SetError(txtContactWorkEmail, null);
                }
            }


            if (txtContactAddress1.Text.ToString().Trim().Equals(string.Empty) && txtContactAddress1.Enabled)
            {
                Err.SetError(txtContactAddress1, "Must enter address line 1.");
                txtContactAddress1.Focus();
                check = false;
                isErrOnContactTab = true;
            }

            else
            {
                Err.SetError(txtContactAddress1, null);
            }

            if (luContactCountry.EditValue == null)
            {
                Err.SetError(luContactCountry, "Must select a country.");
                luContactCountry.Focus();
                check = false;
                isErrOnContactTab = true;
            }

            else
            {
                Err.SetError(luContactCountry, null);
            }

            if (luStatus.EditValue == null)
            {
                Err.SetError(luStatus, "Must select a status.");
                luStatus.Focus();
                check = false;
            }

            else
            {
                Err.SetError(luStatus, null);
            }


            if (luJobTitle.Text.Trim().Equals(string.Empty)  && luJobTitle.Enabled)
            {
                Err.SetError(luJobTitle, "Must select job title.");
                luJobTitle.Focus();
                check = false;
            }

            else
            {
                Err.SetError(luJobTitle, null);
            }


            //if (luMartialStatus.EditValue == null)
            //{
            //    Err.SetError(luMartialStatus, "Must select job title.");
            //    luMartialStatus.Focus();
            //    check = false;
            //}

            //else
            //{
            //    Err.SetError(luMartialStatus, null);
            //}


            if (luGender.EditValue == null)
            {
                Err.SetError(luGender, "Must select gender.");
                luGender.Focus();
                check = false;
            }

            else
            {
                Err.SetError(luGender, null);
            }

            if (luContactType.EditValue == null && luContactType.Enabled)
            {
                Err.SetError(luContactType, "Must select contact type.");
                luContactType.Focus();
                check = false;
            }

            else
            {
                Err.SetError(luContactType, null);
            }


            if (txtLastName.Text == string.Empty)
            {
                Err.SetError(txtLastName, "Must enter last name.");
                txtLastName.Focus();
                check = false;
            }

            else
            {
                Err.SetError(txtLastName, null);
            }

            if (txtFirstName.Text == string.Empty)
            {
                Err.SetError(txtFirstName, "Must enter first name.");
                txtFirstName.Focus();
                check = false;
            }

            else
            {
                Err.SetError(txtFirstName, null);
            }

            if (luCompany.EditValue == null && pnlCompany.Visible)
            {
                Err.SetError(luCompany, "Must select a company.");
                luCompany.Focus();
            }
            else
            {
                Err.SetError(luCompany, null);
            }



            if (xtMain.SelectedTabPage != tpPersonalAddress && isErrOnContactTab)
            {
                Messages.Error("Error on contact's address tab.");
            }

            
             if (!(txtFirstName.Text.Equals(string.Empty) && txtLastName.Text.Equals(string.Empty)) && check )
            {
                if (!CheckDuplicatePerson())
                {
                    check = false;
                    Err.SetError(txtFirstName, "Duplicate contact with matching firstname and surname detected under the same company.");
                    Err.SetError(txtLastName, "Duplicate contact with matching firstname and surname detected under the same company.");
                }
            }

            return check;


        }

        private bool CheckDuplicatePerson()
        {
            bool isValid = true;


            if (!isEdit && luCompany.EditValue != null)
            {
                Hashtable ht = new Hashtable();
                ht.Add(Persons.FirstName, txtFirstName.Text);
                ht.Add(Persons.LastName, txtLastName.Text.Trim());
               
                    ht.Add(Persons.CompaniesID, luCompany.EditValue);

                DataSet ds =  bll.ExecuteSP("usp_" + Tables.Persons + "GetByFields", ht);

                if (!isEdit && ds.Tables[0].Rows.Count > 0)
                {
                    Messages.Error("Cannot add duplicate contact under the same company.");
                    isValid = false;
                }
            }


            return isValid;


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (luCode.EditValue != null)
                {
                    if (Messages.Delete())
                    {
                        bll.Delete(Convert.ToInt32(luCode.EditValue));
                        ClearFields();
                        luCode.EditValue = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally { }
        }

        private void grpMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSaveNClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Save())
                    return;
                UpdateView();


                ClearFields();
                luCompany.Focus();
                luCode.EditValue = null;
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        private void xtMain_Click(object sender, EventArgs e)
        {

        }

        private void luCode_Leave(object sender, EventArgs e)
        {
            if (luCode.Text.Equals(string.Empty) && luCompany.EditValue == null)
            {
                luCode.EditValue = null;
                lblEntry.Text = "New Entry";
                isEdit = false;
                ClearFields();
                luCompany.Focus();
            }
        }

        private void luContactType_EditValueChanged(object sender, EventArgs e)
        {
            if (luContactType.EditValue == null)
            {
                return;
            }
            else
            {
                this.FilterContactID = Convert.ToInt32(luContactType.EditValue);
                SetDefaults();
            }
            if (luContactType.EditValue.ToString().Equals(ContactTypesConts.Users.ToString()))
                grpLogin.Enabled = true;
            else
                grpLogin.Enabled = false;
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            frmCompanies frm = new frmCompanies(true, null);
            frm.Owner = this;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();

            UpdateCompanyList(Convert.ToInt32(frm.luCode.EditValue), frm.luCode.Text, frm.txtCompanyNo.Text, frm.txtVATNo.Text);
            frm.Close();
        }

        public void UpdateCompanyList(int CompanyID, string CompanyName, string RegNo, string VATNo)
        {
            dsMain.Tables[Tables.Companies].Rows.Add(dsMain.Tables[Tables.Companies].NewRow());

            dsMain.Tables[Tables.Companies].Rows[dsMain.Tables[Tables.Companies].Rows.Count - 1][Companies.ID] = CompanyID;
            dsMain.Tables[Tables.Companies].Rows[dsMain.Tables[Tables.Companies].Rows.Count - 1][Companies.CompanyName] = CompanyName;
            dsMain.Tables[Tables.Companies].Rows[dsMain.Tables[Tables.Companies].Rows.Count - 1][Companies.CompanyRegNo] = RegNo;
            dsMain.Tables[Tables.Companies].Rows[dsMain.Tables[Tables.Companies].Rows.Count - 1][Companies.VATNumber] = VATNo;
            dsMain.AcceptChanges();

            luCompany.EditValue = CompanyID;

        }

        private void gvTickets_ValidateRow(object sender, ValidateRowEventArgs e)
        {

        }

        private void gvTickets_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {

        }

        private void rluCategory_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lkp = (LookUpEdit)(sender);

            if (lkp.EditValue == null)
            {
                return;
            }


            gvTickets.SetRowCellValue(gvTickets.FocusedRowHandle, "TicketType", lkp.GetColumnValue("TicketType"));

        }
        //AttachmentTypesID 2 for Passport and 4 for Driving Licence
        private void GetAttachmentPath(ref object sender, int AttachmentTypesID)
        {
            string AttachmentFolder = Program.clsuser.AttachmentPath + "\\" + ScreensNames.frmPersons + "\\" + Program.clsuser.UserID.ToString() + "_" + Program.clsuser.UserName;
            string AttachPath = "";
            ButtonEdit txt = (ButtonEdit)sender;
            if ((!Directory.Exists(Program.clsuser.AttachmentPath)))
            {
                XtraMessageBox.Show("Attachments path is not set in application settings.", Constants.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                //dlg.Filter = "Word|*.doc;*.docx|Excel|*.xls;*.xlsx|PDF|*.pdf|All Supported Formats(Word, Excel, PDF)|*.doc;*.docx;*.xls;*.xlsx;*.pdf"
                //dlg.Filter = "PDF|*.pdf";
                string path = null;

                dlg.ShowDialog();
                //path = "\" & sTabs(ProdTabID) & "\" & dlg.SafeFileName
                path = dlg.FileName;

                if ((path.Trim().Equals(string.Empty)))
                {
                    return;
                }

                AttachPath = "\\" + ScreensNames.frmPersons + "\\" + Program.clsuser.UserID.ToString() + "_" + Program.clsuser.UserName + "\\" + dlg.SafeFileName;

                if (!File.Exists(AttachmentFolder + "\\" + dlg.SafeFileName))
                {
                    if ((!Directory.Exists(AttachmentFolder)))
                    {
                        Directory.CreateDirectory(AttachmentFolder);
                    }

                    File.Copy(path, AttachmentFolder + "\\" + dlg.SafeFileName, true);
                    txt.EditValue = dlg.SafeFileName;
                    DataTable dt = ucAttach.dtAttach;

                    DataRow[] drs = dt.Select(Attachments.AttachmentTypesID + "=" + AttachmentTypesID.ToString());

                    int rowHandle = -1;
                    if (drs.Length == 0)
                    {
                        dt.Rows.Add(dt.NewRow());
                        rowHandle = dt.Rows.Count - 1;
                    }
                    else
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i][Attachments.AttachmentTypesID].ToString().Equals(AttachmentTypesID.ToString()))
                            {
                                rowHandle = i;
                                break;
                            }
                        }
                    }
                    dt.Rows[rowHandle][Attachments.Attachment] = txt.EditValue;
                    dt.Rows[rowHandle][Attachments.AttPath] = AttachPath;
                    dt.Rows[rowHandle][Attachments.AttType] = Path.GetExtension(path);
                    dt.Rows[rowHandle][Attachments.ScreensID] = Screens.frmPersons;
                    dt.Rows[rowHandle][Attachments.AttachmentTypesID] = AttachmentTypesID;

                    string _pth = Path.GetExtension(path);

                }
                else
                {
                    txt.EditValue = dlg.SafeFileName;

                }

                txt.Tag = AttachPath;
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
        }

        private void txtPassortAttachment_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GetAttachmentPath(ref sender, PassportID);
        }

        private void txtLicenceAttachment_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GetAttachmentPath(ref sender, DrivingLicenceID);
        }

        private void txtPassortAttachment_DoubleClick(object sender, EventArgs e)
        {
            if (((ButtonEdit)sender).Tag.Equals(string.Empty))
                return;

            System.Diagnostics.Process.Start(Program.clsuser.AttachmentPath + ((ButtonEdit)sender).Tag.ToString());
        }


        private void txtLicenceAttachment_DoubleClick(object sender, EventArgs e)
        {
            txtPassortAttachment_DoubleClick(sender, e);
        }

        private void SetCheckListTabColor()
        {
            if (chkBirthCertificate.Checked && chkCV.Checked && chkDrivingLicence.Checked && chkPassport.Checked
                && chkPayDetails.Checked && chkProofofAddress.Checked && chkVisa.Checked)
            {
                tpCheckList.Appearance.Header.ForeColor = Color.Black;
                tpCheckList.Appearance.Header.Font = new Font(tpCheckList.Appearance.Header.Font, FontStyle.Regular);
            }
            else
            {
                tpCheckList.Appearance.Header.ForeColor = Color.Red;
                //tpCheckList.Appearance.Header.Font = new Font(tpCheckList.Appearance.Header.Font, FontStyle.Bold);
            }
        }

        private void chkPassport_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckListTabColor();
        }

        private void frmContacts_Load(object sender, EventArgs e)
        {

        }

        private void luStatus_EditValueChanged(object sender, EventArgs e)
        {
            
            
        }

        private void Delete()
        {
            try
            {
                if (gvTickets.FocusedRowHandle > -1)
                {
                    //if (DialogResult.Yes == XtraMessageBox.Show(Constants.DeleteMsg, Constants.ApplicationTitle, MessageBoxButtons.YesNo))
                    //{
                    if (gvTickets.GetRowCellValue(gvTickets.FocusedRowHandle, Attachments.ID) != DBNull.Value)
                    {
                        if (Convert.ToInt32(gvTickets.GetRowCellValue(gvTickets.FocusedRowHandle, DeleteCol)) == 1)
                        {
                            gvTickets.SetRowCellValue(gvTickets.FocusedRowHandle, DeleteCol, 0);
                            

                        }
                        else
                        {
                            gvTickets.SetRowCellValue(gvTickets.FocusedRowHandle, DeleteCol, 1);

                         
                        }


                        gvTickets.RefreshData();


                    }
                    else
                    {
                        dsMain.Tables[Tables.ContactTickets].Rows[gvTickets.FocusedRowHandle].Delete();
                    }

                    //}
                }
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally { }
        }

        private void gvTickets_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Delete();
            }
        }

        private void ConditionsAdjustment()
        {
            StyleFormatCondition cn;

            cn = new StyleFormatCondition(FormatConditionEnum.Equal, gvTickets.Columns[DeleteCol], null, 1);
            cn.ApplyToRow = true;
            cn.Appearance.Font = new Font(AppearanceObject.DefaultFont, FontStyle.Bold | FontStyle.Strikeout);
            
            cn.Appearance.BorderColor = Color.Red;
            //cn.Appearance.ForeColor = SystemColors.ControlDark;
            cn.Appearance.ForeColor = System.Drawing.Color.Red;
            gvTickets.FormatConditions.Add(cn);

            gvTickets.BestFitColumns();
        }

        private void MarkAsDelete()
        {
            for (int i = 0; i < dsMain.Tables[Tables.ContactTickets].Rows.Count; i++)
            {
                if (dsMain.Tables[Tables.ContactTickets].Rows[i][DeleteCol].ToString().Equals("1"))
                {
                    if (dsMain.Tables[Tables.ContactTickets].Rows[i].RowState == DataRowState.Unchanged)
                        dsMain.Tables[Tables.ContactTickets].Rows[i].AcceptChanges();

                    dsMain.Tables[Tables.ContactTickets].Rows[i].Delete();
                }
            }
        }


    }
}