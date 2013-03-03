using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DESCONIT.BLL;
using DevExpress.XtraEditors;

namespace RSys
{
    public partial class frmQuickAddCandidate : BaseScreen
    {
        BLL bll = new BLL(Tables.Persons, Program.clsuser.CurrentDB);
        bool isEdit, isCalledFromReq;
        DataSet dsMain;
        ucAttachment ucAttach;
        ucNotes ucNotesCtrl;
        ucDiaryActions ucDiaryCtrl;
        int FilterContactID = -1;

        public frmQuickAddCandidate()
        {
            InitializeComponent();
            Initialize();
        }


        private void Initialize()
        {
            // tpCheckList.Appearance.Header.ForeColor = Color.Red;
            //tpCheckList.Appearance.Header.Font = new Font(tpCheckList.Appearance.Header.Font, FontStyle.Bold);
            base.btnBaseEdit = this.btnSave;
            base.btnBaseAdd = this.btnSave;
            base.btnBaseDelete = this.btnDelete;
            base.SystemObjectName = "frmCandidates";
            Hashtable ht = new Hashtable();
            ht.Add(Persons.ID, -1);
            ht.Add(Persons.CreatedBy, Program.clsuser.UserID);
            dsMain = bll.ExecuteSP("usp_" + Tables.Persons + "GetByID", ht);
            SetTableNames();
            AddCtrls();
            RefreshData();

            luContactCountry.EditValue = "1";
            //luCode.Properties.ReadOnly = true;
            SendKeys.Send("{TAB}");
        }


        private void AddCtrls()
        {
            ucAttach = new ucAttachment(dsMain.Tables[Tables.Attachments], Screens.frmPersons, ScreensNames.frmPersons);
            //ucAttach.Location = new Point(0, 0);
            //ucAttach.Show();
            //ucAttach.Dock = DockStyle.Fill;
            //tpAttachments.Controls.Add(ucAttach);

            //ucNotesCtrl = new ucNotes(dsMain.Tables[Tables.Notes], Screens.frmPersons, ScreensNames.frmPersons);
            //ucNotesCtrl.Location = new Point(0, 0);
            //ucNotesCtrl.Show();
            //ucNotesCtrl.Dock = DockStyle.Fill;
            //tpNotes.Controls.Add(ucNotesCtrl);

            //ucDiaryCtrl = new ucDiaryActions(dsMain.Tables[Tables.DiaryActions], Screens.frmPersons, ScreensNames.frmPersons);
            //ucDiaryCtrl.Location = new Point(0, 0);
            //ucDiaryCtrl.Show();
            //ucDiaryCtrl.Dock = DockStyle.Fill;
            //tpDiaryActions.Controls.Add(ucDiaryCtrl);


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
            //luCode.Properties.ValueMember = Persons.ID;
            //luCode.Properties.DisplayMember = "Name";
            //luCode.Properties.DataSource = dsMain.Tables[Tables.ExistingData];

            //luCompany.Properties.ValueMember = Companies.ID;
            //luCompany.Properties.DisplayMember = Companies.CompanyName;
            //luCompany.Properties.DataSource = dsMain.Tables[Tables.Companies];

            //luGender.Properties.ValueMember = Genders.ID;
            //luGender.Properties.DisplayMember = Genders.Name;
            //luGender.Properties.DataSource = dsMain.Tables[Tables.Genders];

            //luMartialStatus.Properties.ValueMember = MartialStatuses.ID;
            //luMartialStatus.Properties.DisplayMember = MartialStatuses.Name;
            //luMartialStatus.Properties.DataSource = dsMain.Tables[Tables.MartialStatuses];

            //luContactType.Properties.ValueMember = ContactTypes.ID;
            //luContactType.Properties.DisplayMember = ContactTypes.Name;
            //luContactType.Properties.DataSource = dsMain.Tables[Tables.ContactTypes];

            //luTrades.Properties.ValueMember = Trades.ID;
            //luTrades.Properties.DisplayMember = Trades.Name;
            //luTrades.Properties.DataSource = dsMain.Tables[Tables.Trades];

            //luJobTitle.Properties.ValueMember = JobTitles.ID;
            //luJobTitle.Properties.DisplayMember = JobTitles.Name;
            //luJobTitle.Properties.DataSource = dsMain.Tables[Tables.JobTitles];

            //luWorkType.Properties.ValueMember = WorkTypes.ID;
            //luWorkType.Properties.DisplayMember = WorkTypes.Name;
            //luWorkType.Properties.DataSource = dsMain.Tables[Tables.WorkTypes];

            //luStatus.Properties.ValueMember = Statuses.ID;
            //luStatus.Properties.DisplayMember = Statuses.Name;
            //luStatus.Properties.DataSource = dsMain.Tables[Tables.Statuses];

            luContactCountry.Properties.ValueMember = Countries.ID;
            luContactCountry.Properties.DisplayMember = Countries.Name;
            luContactCountry.Properties.DataSource = dsMain.Tables[Tables.Countries];

            luContactCounty.Properties.ValueMember = Counties.ID;
            luContactCounty.Properties.DisplayMember = Counties.Name;
            luContactCounty.Properties.DataSource = dsMain.Tables[Tables.Counties];

            //luPaymentMethod.Properties.ValueMember = PaymentMethods.ID;
            //luPaymentMethod.Properties.DisplayMember = PaymentMethods.Name;
            //luPaymentMethod.Properties.DataSource = dsMain.Tables[Tables.PaymentMethods];

            //luPayType.Properties.ValueMember = PaymentTypes.ID;
            //luPayType.Properties.DisplayMember = PaymentTypes.Name;
            //luPayType.Properties.DataSource = dsMain.Tables[Tables.PaymentTypes];

            //luBOffCountry.Properties.ValueMember = Countries.ID;
            //luBOffCountry.Properties.DisplayMember = Countries.Name;
            //luBOffCountry.Properties.DataSource = dsMain.Tables[Tables.Countries];

            //luBOffCounty.Properties.ValueMember = Counties.ID;
            //luBOffCounty.Properties.DisplayMember = Counties.Name;
            //luBOffCounty.Properties.DataSource = dsMain.Tables[Tables.Counties];


            //luBOffCorrCountry.Properties.ValueMember = Countries.ID;
            //luBOffCorrCountry.Properties.DisplayMember = Countries.Name;
            //luBOffCorrCountry.Properties.DataSource = dsMain.Tables[Tables.Countries];

            //luBOffCorrCounty.Properties.ValueMember = Counties.ID;
            //luBOffCorrCounty.Properties.DisplayMember = Counties.Name;
            //luBOffCorrCounty.Properties.DataSource = dsMain.Tables[Tables.Counties];


            rluCategory.Properties.ValueMember = Tickets.ID;
            rluCategory.Properties.DisplayMember = Tickets.Name;
            rluCategory.Properties.DataSource = dsMain.Tables[Tables.Tickets];

            grdTickets.DataSource = dsMain.Tables[Tables.ContactTickets];
            grdTickets.RefreshDataSource();
            gvTickets.ExpandAllGroups();

            //grdTrades.DataSource = dsMain.Tables[Tables.PersonTrades];
            //grdTrades.RefreshDataSource();

            //ucAttach.RefreshDataSource(dsMain.Tables[Tables.Attachments]);
            //ucNotesCtrl.RefreshDataSource(dsMain.Tables[Tables.Notes]);
            //ucDiaryCtrl.RefreshDataSource(dsMain.Tables[Tables.DiaryActions]);

            //if (FilterContactID > 0)
            //{
            //    luContactType.EditValue = FilterContactID;
            //    //luContactType.Enabled = false;
            //    luContactType.Properties.ReadOnly = true;
            //}
            //else
            //{
            //    //luContactType.Enabled = true;
            //    luContactType.Properties.ReadOnly = false;
            //}

        }

        private bool Validation()
        {
            bool check = true;
            Err.ClearErrors();


            if (txtMobile.Text.ToString().Trim().Equals(string.Empty))
            {
                Err.SetError(txtMobile, "Must enter a mobile number");
                txtMobile.Focus();
                check = false;
                // isErrOnContactTab = true;
            }

            else
            {
                Err.SetError(txtMobile, null);
            }


            if (txtContactAddress1.Text.ToString().Trim().Equals(string.Empty))
            {
                Err.SetError(txtContactAddress1, "Must enter address line 1.");
                txtContactAddress1.Focus();
                check = false;
                // isErrOnContactTab = true;
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
                // isErrOnContactTab = true;
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

            return check;
        }

        private void ClearFields()
        {
            try
            {
                // grpLogin.Enabled = false;
                txtFirstName.EditValue = null;
                txtLastName.EditValue = null;
                // luCompany.EditValue = null;
                dtDOB.EditValue = null;
                txtAge.EditValue = null;
                // luGender.EditValue = null;
                // luMartialStatus.EditValue = null;

                if (FilterContactID > 0)
                {
                    // luContactType.EditValue = FilterContactID;
                    ///luContactType.Enabled = false;
                    // luContactType.Properties.ReadOnly = true;
                }
                else
                {
                    // luContactType.EditValue = null;
                    //luContactType.Enabled = true;
                    //  luContactType.Properties.ReadOnly = false;
                }

                //luTrades.EditValue = null;
                //luJobTitle.EditValue = null;
                //luStatus.EditValue = null;
                //luWorkType.EditValue = null;

                txtContactAddress1.EditValue = null;
                txtContactAddress2.EditValue = null;
                txtContactCity.EditValue = null;
                txtContactPostCode.EditValue = null;
                luContactCountry.EditValue = null;
                luContactCounty.EditValue = null;
                txtContactMobile.EditValue = null;
                txtContactTel.EditValue = null;
                //txtContactFax.EditValue = null;
                //txtContactEmail.EditValue = null;
                //txtContactWorkEmail.EditValue = null;
                //txtContactWorkTel.EditValue = null;
                //txtContactWorkMobile.EditValue = null;
                txtContactComments.EditValue = null;

                //txtPassword.EditValue = null;
                //txtConfirmPass.EditValue = null;


                //chkIsAppUser.Checked = false;
                //chkActive.Checked = true;

                //txtBackofficeCompanyRegNo.EditValue = null;
                //txtNationalInsurace.EditValue = null;
                //luPaymentMethod.EditValue = null;
                //txtVAT.EditValue = null;
                //txtTaxCode.EditValue = null;
                //luPayType.EditValue = null;
                //txtBackOfficeComments.EditValue = null;

                //txtBOffAddress1.EditValue = null;
                //txtBOffAddress2.EditValue = null;
                //txtBOffCity.EditValue = null;
                //txtBOffPostCode.EditValue = null;
                //luBOffCountry.EditValue = null;
                //luBOffCounty.EditValue = null;
                //txtBOffTel.EditValue = null;
                //txtBOffFax.EditValue = null;


                //txtBOffCorrAddress1.EditValue = null;
                //txtBOffCorrAddrss2.EditValue = null;
                //txtBOffCorrCity.EditValue = null;
                //txtBOffCorrPostCode.EditValue = null;
                //luBOffCorrCountry.EditValue = null;
                //luBOffCorrCounty.EditValue = null;
                //txtBOffCorrTel.EditValue = null;
                //txtBOffCorrFax.EditValue = null;

                ////////checklist tab////////////
                //chkPassport.Checked = false;
                //txtPassortAttachment.EditValue = null;
                //txtPassortAttachment.Tag = "";
                //chkProofofAddress.Checked = false;
                //chkBirthCertificate.Checked = false;
                //chkCV.Checked = false;
                //chkPayDetails.Checked = false;
                //chkVisa.Checked = false;
                //chkDrivingLicence.Checked = false;
                //txtLicenceAttachment.EditValue = null;
                //txtLicenceAttachment.Tag = string.Empty;

                //tpCheckList.Appearance.Header.ForeColor = Color.Red;
                //tpCheckList.Appearance.Header.Font = new Font(tpCheckList.Appearance.Header.Font, FontStyle.Bold);
                //////checklist tab////////////


                //lblEntry.Text = string.Empty;
                //btnDelete.Enabled = false;
                Hashtable ht = new Hashtable();
                ht.Add(Persons.ID, -1);
                ht.Add(Persons.CreatedBy, Program.clsuser.UserID);
                dsMain = bll.ExecuteSP("usp_" + Tables.Persons + "GetByID", ht);

                SetTableNames();

                RefreshData();
                isEdit = false;

                //if (luContactType.EditValue != null && luContactType.EditValue.ToString().Equals(ContactTypesConts.Users.ToString()))
                //    grpLogin.Enabled = true;
                //else
                //    grpLogin.Enabled = false;
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

        private void BindFields()
        {
            try
            {

                txtFirstName.Text = dsMain.Tables[Tables.Persons].Rows[0][Persons.FirstName].ToString();
                txtLastName.Text = dsMain.Tables[Tables.Persons].Rows[0][Persons.LastName].ToString();
                if (dsMain.Tables[Tables.Persons].Rows[0][Persons.DOB] != DBNull.Value)
                    dtDOB.EditValue = Convert.ToDateTime(dsMain.Tables[Tables.Persons].Rows[0][Persons.DOB]);

                //luCompany.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.CompaniesID];
                txtAge.EditValue = dsMain.Tables[Tables.Persons].Rows[0]["Age"];
                //luGender.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.GendersID];
                //luMartialStatus.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.MartialStatusesID];
                //luContactType.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.ConatactTypesID];

                //luTrades.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.TradesID];
                //luJobTitle.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.JobTitlesID];
                //luStatus.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.StatusesID];
                //luWorkType.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.WorkTypesID];


                txtContactAddress1.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.Address1];
                txtContactAddress2.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.Address2];
                txtContactCity.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.City];
                txtContactPostCode.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.Postcode];
                luContactCountry.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.CountriesID];
                luContactCounty.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.CountiesID];
                txtContactMobile.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.PersonalMobile];
                txtContactTel.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.HomeTel];
                //txtContactFax.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.HomeFax];
                //txtContactEmail.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.PersonalEmail];
                //txtContactWorkEmail.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.WorkEmail];
                //txtContactWorkTel.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.WorkTel];
                //txtContactWorkMobile.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.WorkMobile];
                txtContactComments.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.Comments];
                
                //txtPassword.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.Password];
                //txtConfirmPass.EditValue = dsMain.Tables[Tables.Persons].Rows[0][Persons.Password];


                //chkIsAppUser.Checked = Convert.ToInt32(dsMain.Tables[Tables.Persons].Rows[0][Persons.ConatactTypesID]).Equals(ContactTypesConts.Users);
                //chkActive.Checked = Convert.ToBoolean(dsMain.Tables[Tables.Persons].Rows[0][Persons.isActive]);

                //chkPassport.Checked = Convert.ToBoolean(dsMain.Tables[Tables.Persons].Rows[0][Persons.isPassport]);
                //chkProofofAddress.Checked = Convert.ToBoolean(dsMain.Tables[Tables.Persons].Rows[0][Persons.isProofOfAddress]);
                //chkBirthCertificate.Checked = Convert.ToBoolean(dsMain.Tables[Tables.Persons].Rows[0][Persons.isBirthCertificate]);
                //chkCV.Checked = Convert.ToBoolean(dsMain.Tables[Tables.Persons].Rows[0][Persons.isCV]);
                //chkPayDetails.Checked = Convert.ToBoolean(dsMain.Tables[Tables.Persons].Rows[0][Persons.isPayDetails]);
                //chkVisa.Checked = Convert.ToBoolean(dsMain.Tables[Tables.Persons].Rows[0][Persons.isVisa]);
                //chkDrivingLicence.Checked = Convert.ToBoolean(dsMain.Tables[Tables.Persons].Rows[0][Persons.isDrivingLicence]);

                if (dsMain.Tables[Tables.PersonBackOffices].Rows.Count > 0)
                {
                    //txtBackofficeCompanyRegNo.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CompanyRegNo];
                    //txtNationalInsurace.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.NationalInsuranceNo];
                    //luPaymentMethod.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.PaymentMethodsID];
                    //txtVAT.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.VATNumber];
                    //txtTaxCode.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.TaxCode];
                    //luPayType.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.PayTypesID];
                    //txtBackOfficeComments.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.Comments];

                    //txtBOffAddress1.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.Address1];
                    //txtBOffAddress2.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.Address2];
                    //txtBOffCity.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.City];
                    //txtBOffPostCode.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.Postcode];
                    //luBOffCountry.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CountriesID];
                    //luBOffCounty.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CountiesID];
                    //txtBOffTel.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.Tel];
                    //txtBOffFax.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.Fax];


                    //txtBOffCorrAddress1.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrAddress1];
                    //txtBOffCorrAddrss2.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrAddress2];
                    //txtBOffCorrCity.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrCity];
                    //txtBOffCorrPostCode.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrPostcode];
                    //luBOffCorrCountry.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrCountriesID];
                    //luBOffCorrCounty.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrCountiesID];
                    //txtBOffCorrTel.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrTel];
                    //txtBOffCorrFax.EditValue = dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrFax];
                }

                grdTickets.DataSource = dsMain.Tables[Tables.ContactTickets];
                grdTickets.RefreshDataSource();
                gvTickets.ExpandAllGroups();

                //grdTrades.DataSource = dsMain.Tables[Tables.PersonTrades];
                //grdTrades.RefreshDataSource();

                ucAttach.RefreshDataSource(dsMain.Tables[Tables.Attachments]);
                ucNotesCtrl.RefreshDataSource(dsMain.Tables[Tables.Notes]);
                ucDiaryCtrl.RefreshDataSource(dsMain.Tables[Tables.DiaryActions]);

                //  DataRow[] drs = dsMain.Tables[Tables.Attachments].Select(Attachments.AttachmentTypesID + "=" + PassportID.ToString());

                //if (drs.Length > 0)
                //{
                //    try
                //    {
                //        txtPassortAttachment.Tag = drs[0][Attachments.AttPath].ToString();
                //        txtPassortAttachment.EditValue = drs[0][Attachments.Attachment].ToString();
                //    }
                //    catch (Exception ex)
                //    { }
                //    txtPassortAttachment.EditValue = drs[0][Attachments.Attachment].ToString();
                //    txtPassortAttachment.Tag = drs[0][Attachments.AttPath].ToString();
                //}

                // drs = dsMain.Tables[Tables.Attachments].Select(Attachments.AttachmentTypesID + "=" + DrivingLicenceID.ToString());

                //if (drs.Length > 0)
                //{
                //    try
                //    {
                //        txtLicenceAttachment.Tag = drs[0][Attachments.AttPath].ToString();
                //        txtLicenceAttachment.EditValue = drs[0][Attachments.Attachment].ToString();

                //    }
                //    catch (Exception ex)
                //    {
                //    }
                //    txtLicenceAttachment.EditValue = drs[0][Attachments.Attachment].ToString();
                //    txtLicenceAttachment.Tag = drs[0][Attachments.AttPath].ToString();
                //}



                // btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Save())
                    return;

                UpdateView();

                this.Close();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
                throw;
            }



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

                dsMain.Tables[Tables.Persons].Rows[0][Persons.CompaniesID] = -1;

                dsMain.Tables[Tables.Persons].Rows[0][Persons.FirstName] = txtFirstName.Text;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.LastName] = txtLastName.Text;

                if (!dtDOB.Text.Equals(string.Empty))
                    dsMain.Tables[Tables.Persons].Rows[0][Persons.DOB] = dtDOB.EditValue.ToString();

                // if (!luGender.Text.Equals(string.Empty))
                dsMain.Tables[Tables.Persons].Rows[0][Persons.GendersID] = 1;


                dsMain.Tables[Tables.Persons].Rows[0][Persons.MartialStatusesID] = 1;


               // dsMain.Tables[Tables.Persons].Rows[0][Persons.ConatactTypesID] = DBNull.Value;

                //if (!luTrades.Text.Equals(string.Empty))
                //    dsMain.Tables[Tables.Persons].Rows[0][Persons.TradesID] = luTrades.EditValue;
                //else
                //    dsMain.Tables[Tables.Persons].Rows[0][Persons.TradesID] = DBNull.Value;

                //if (false)
                //    dsMain.Tables[Tables.Persons].Rows[0][Persons.JobTitlesID] = luJobTitle.EditValue;
                //else
                    dsMain.Tables[Tables.Persons].Rows[0][Persons.JobTitlesID] = -1;

                if (false)
                    dsMain.Tables[Tables.Persons].Rows[0][Persons.StatusesID] = 3;
                else
                    dsMain.Tables[Tables.Persons].Rows[0][Persons.StatusesID] = 1;

                //if (!luWorkType.Text.Equals(string.Empty))
                //    dsMain.Tables[Tables.Persons].Rows[0][Persons.WorkTypesID] = luWorkType.EditValue;
                //else
                dsMain.Tables[Tables.Persons].Rows[0][Persons.WorkTypesID] = 1;

                //if (!luWorkType.Text.Equals(string.Empty))
                //    dsMain.Tables[Tables.Persons].Rows[0][Persons.WorkTypesID] = luWorkType.EditValue;
                //else
                //    dsMain.Tables[Tables.Persons].Rows[0][Persons.WorkTypesID] = DBNull.Value;

                if (!luContactCountry.Text.Equals(string.Empty))
                    dsMain.Tables[Tables.Persons].Rows[0][Persons.CountriesID] = luContactCountry.EditValue;


                if (!luContactCounty.Text.Equals(string.Empty))
                    dsMain.Tables[Tables.Persons].Rows[0][Persons.CountiesID] = luContactCounty.EditValue;


                dsMain.Tables[Tables.Persons].Rows[0][Persons.Address1] = txtContactAddress1.EditValue;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.Address2] = txtContactAddress2.EditValue;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.City] = txtContactCity.EditValue;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.Postcode] = txtContactPostCode.EditValue;

                dsMain.Tables[Tables.Persons].Rows[0][Persons.PersonalMobile] = txtMobile.EditValue;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.HomeTel] = txtContactTel.EditValue;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.HomeFax] = string.Empty;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.PersonalEmail] = string.Empty;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.WorkEmail] = string.Empty;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.WorkTel] = string.Empty;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.WorkMobile] = string.Empty;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.Comments] = txtContactComments.EditValue;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.Password] = string.Empty;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.ConatactTypesID] = ContactTypesConts.Candidate;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.UTR] = txtUTR;




                dsMain.Tables[Tables.Persons].Rows[0][Persons.isStaff] = false; //Convert.ToInt32(dsMain.Tables[Tables.Persons].Rows[0][Persons.ConatactTypesID]).Equals(ContactTypesConts.Users);
                dsMain.Tables[Tables.Persons].Rows[0][Persons.isActive] = 1;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.isPassport] = false;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.isProofOfAddress] = false;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.isBirthCertificate] = false;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.isCV] = false;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.isPayDetails] = false;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.isVisa] = false;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.isDrivingLicence] = false;


                if (dsMain.Tables[Tables.PersonBackOffices].Rows.Count > 0)
                {
                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CompanyRegNo] = string.Empty;
                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.NationalInsuranceNo] = string.Empty;
                    //if (!luPaymentMethod.Text.Equals(string.Empty))
                   // dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.PaymentMethodsID] = string.Empty;

                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.VATNumber] = string.Empty;
                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.TaxCode] = string.Empty;

                    // if (!luPayType.Text.Equals(string.Empty))
                    // dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.PayTypesID] = luPayType.EditValue;

                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.Comments] = string.Empty;

                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.Address1] = string.Empty;
                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.Address2] = string.Empty;
                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.City] = string.Empty;
                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.Postcode] = string.Empty;

                    //if (!luBOffCorrCountry.Text.Equals(string.Empty))
                    //    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CountriesID] = luBOffCorrCountry.EditValue;

                    //if (!luBOffCorrCounty.Text.Equals(string.Empty))
                    //    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CountiesID] = luBOffCorrCounty.EditValue;

                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.Tel] = txtHomeTel.EditValue;
                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.Fax] = string.Empty;

                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.NationalInsuranceNo] = txtNI.Text;

                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrAddress1] = string.Empty;
                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrAddress2] = string.Empty;
                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrCity] = string.Empty;
                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrPostcode] = string.Empty;
                    //if (!luBOffCorrCountry.Text.Equals(string.Empty))
                    //dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrCountriesID] = string.Empty;

                    // if (!luBOffCorrCounty.Text.Equals(string.Empty))
                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrCountiesID] = 1;

                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrTel] = string.Empty;
                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.CrFax] = string.Empty;

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

                //if (dsMain.Relations.Contains("relAttachment"))
                //    dsMain.Relations.Remove("relAttachment");

                //dsMain.Tables.Remove(Tables.Attachments);
                //dsMain.Tables.Add(ucAttach.GetAttachmentTable().Copy());
                //DataRelation relation = new DataRelation("relAttachment", dsMain.Tables[Tables.Persons].Columns[Persons.ID], dsMain.Tables[Tables.Attachments].Columns[Attachments.RecordID], false);
                //dsMain.Relations.Add(relation);


                //if (dsMain.Relations.Contains("relNotes"))
                //    dsMain.Relations.Remove("relNotes");

                //dsMain.Tables.Remove(Tables.Notes);
                //dsMain.Tables.Add(ucNotesCtrl.GetNotesTable().Copy());
                //relation = new DataRelation("relNotes", dsMain.Tables[Tables.Persons].Columns[Persons.ID], dsMain.Tables[Tables.Notes].Columns[Attachments.RecordID], false);
                //dsMain.Relations.Add(relation);

                //if (dsMain.Relations.Contains("relDiary"))
                //    dsMain.Relations.Remove("relDiary");

                //dsMain.Tables.Remove(Tables.DiaryActions);
                //dsMain.Tables.Add(ucDiaryCtrl.GetScheduleTable().Copy());
                //relation = new DataRelation("relDiary", dsMain.Tables[Tables.Persons].Columns[Persons.ID], dsMain.Tables[Tables.DiaryActions].Columns[Attachments.RecordID], false);
                //dsMain.Relations.Add(relation);

                dsMain = bll.SaveComplex(dsMain, isEdit);
               

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
                ((frmContactsVW)(this.Owner)).RefreshData(Convert.ToInt32(dsMain.Tables[0].Rows[0]["ID"]));
                ((frmMain)(((frmContactsVW)(this.Owner)).MdiParent)).RefreshDiaryActions();
            }
        }
    }
}