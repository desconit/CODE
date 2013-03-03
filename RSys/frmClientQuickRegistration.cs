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
    public partial class frmClientQuickRegistration : BaseScreen
    {
        BLL bll = new BLL(Tables.Persons, Program.clsuser.CurrentDB);
        bool isEdit, isCalledFromReq;
        DataSet dsMain;
        ucAttachment ucAttach;
        ucNotes ucNotesCtrl;
        ucDiaryActions ucDiaryCtrl;
        int FilterContactID = -1;

        int PassportID = 2, DrivingLicenceID = 4;

        public frmClientQuickRegistration()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {

            base.btnBaseEdit = this.btnSave;
            base.btnBaseAdd = this.btnSave;
            base.btnBaseDelete = this.btnDelete;
            base.SystemObjectName = "frmClientContacts";


            Hashtable ht = new Hashtable();
            ht.Add(Persons.ID, -1);
            ht.Add(Persons.CreatedBy, Program.clsuser.UserID);
            dsMain = bll.ExecuteSP("usp_" + Tables.Persons + "GetByID", ht);
            SetTableNames();
            //AddCtrls();
            RefreshData();
            //luCode.Properties.ReadOnly = true;
            SendKeys.Send("{TAB}");


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

            //luContactCountry.Properties.ValueMember = Countries.ID;
            //luContactCountry.Properties.DisplayMember = Countries.Name;
            //luContactCountry.Properties.DataSource = dsMain.Tables[Tables.Countries];

            //luContactCounty.Properties.ValueMember = Counties.ID;
            //luContactCounty.Properties.DisplayMember = Counties.Name;
            //luContactCounty.Properties.DataSource = dsMain.Tables[Tables.Counties];

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


            //rluCategory.Properties.ValueMember = Tickets.ID;
            //rluCategory.Properties.DisplayMember = Tickets.Name;
            //rluCategory.Properties.DataSource = dsMain.Tables[Tables.Tickets];

            //grdTickets.DataSource = dsMain.Tables[Tables.ContactTickets];
            //grdTickets.RefreshDataSource();

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

        private void luCode_EditValueChanged(System.Object sender, System.EventArgs e)
        {
            ////ClearFields();
            //try
            //{
            //    //if (Convert.ToInt32(luCode.EditValue) == -1)
            //    //{
            //    //    lblEntry.Text = "New Entry";
            //    //    isEdit = false;
            //    //    return;
            //    //}



            //    if (luCode.EditValue == null | object.ReferenceEquals(luCode.EditValue, DBNull.Value))
            //    {
            //        isEdit = false;
            //    }
            //    else if (Convert.ToInt32(luCode.EditValue) == -1)
            //    {
            //        isEdit = false;

            //    }
            //    else
            //    {
            //        isEdit = true;
            //    }

            //    if ((isEdit))
            //    {
            //        lblEntry.Text = "";
            //        GetByID();
            //        BindFields();

            //    }
            //}
            //catch (Exception ex)
            //{
            //    Messages.Error(ex.Message);

            //}
            //finally
            //{ }
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

        private void luCode_Leave(object sender, EventArgs e)
        {
            if (luCode.Text.Equals(string.Empty) && luCompany.EditValue == null)
            {
                luCode.EditValue = null;
                lblEntry.Text = "New Entry";
                isEdit = false;
                //ClearFields();
                luCompany.Focus();
            }
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
                UpdateView();


                //ClearFields();
                luCompany.Focus();
                luCode.EditValue = null;

                this.Close();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
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

                dsMain.Tables[Tables.Persons].Rows[0][Persons.CompaniesID] = luCompany.EditValue;

                dsMain.Tables[Tables.Persons].Rows[0][Persons.FirstName] = txtFirstName.Text;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.LastName] = txtLastName.Text;


                dsMain.Tables[Tables.Persons].Rows[0][Persons.DOB] = DBNull.Value;

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

                //if (!luContactCountry.Text.Equals(string.Empty))
                dsMain.Tables[Tables.Persons].Rows[0][Persons.CountriesID] = -1;


                // if (!luContactCounty.Text.Equals(string.Empty))
                dsMain.Tables[Tables.Persons].Rows[0][Persons.CountiesID] = -1;


                dsMain.Tables[Tables.Persons].Rows[0][Persons.Address1] = string.Empty;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.Address2] = string.Empty;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.City] = string.Empty;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.Postcode] = string.Empty;

                dsMain.Tables[Tables.Persons].Rows[0][Persons.PersonalMobile] = string.Empty;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.HomeTel] = string.Empty;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.HomeFax] = string.Empty;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.PersonalEmail] = string.Empty;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.WorkEmail] = string.Empty;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.WorkTel] = string.Empty;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.WorkMobile] = txtContactMobileNumber.Text;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.Comments] = string.Empty;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.Password] = string.Empty;
                dsMain.Tables[Tables.Persons].Rows[0][Persons.ConatactTypesID] = ContactTypesConts.Client;



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

                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.Tel] = string.Empty;
                    dsMain.Tables[Tables.PersonBackOffices].Rows[0][PersonBackOffices.Fax] = string.Empty;

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

        private bool Validation()
        {
            bool check = true;
            Err.ClearErrors();

            bool isErrOnContactTab = false;


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

            if (luCompany.EditValue == null)
            {
                Err.SetError(luCompany, "Must select a company.");
                luCompany.Focus();
            }
            else
            {
                Err.SetError(luCompany, null);
            }

            if ((txtContactWorkEmail.Text == string.Empty) || (!Functions.EmailAddressCheck(txtContactWorkEmail.Text)))
            {

                Err.SetError(txtContactWorkEmail, "Must enter valid email address.");

                check = false;

            }

            else
            {
                Err.SetError(txtContactWorkEmail, null);
            }

            if (txtContactMobileNumber.Text == string.Empty)
            {
                Err.SetError(txtContactMobileNumber, "Must enter a mobile number.");
                txtFirstName.Focus();
                check = false;
            }

            else
            {
                Err.SetError(txtFirstName, null);
            }

            return check;


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}