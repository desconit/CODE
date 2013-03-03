using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Utils;
using System.Collections;
using DESCONIT.BLL;

namespace RSys
{
    public partial class frmCompanies :BaseScreen
    {
        BLL bll = new BLL(Tables.Companies, Program.clsuser.CurrentDB);
        bool isEdit;
       public DataSet dsMain;
        int? ID = null;
        DataTable dt = new DataTable();
        bool isCalledFromContact = false;
        string DeleteCol = "Deleted";
        ucAttachment ucAttach;
        ucNotes ucNotesCtrl;
        ucDiaryActions ucDiaryCtrl;
      

        
        public frmCompanies()
        {
            InitializeComponent();
            Initialize();
            dsMain = bll.GetByID(-1);
            SetTableNames();
            AddAttachmentCtrl();
            RefreshData();

            lulookup.Parent = grpMain;
            //lulookup.ShowPopup();
           
        }

        public frmCompanies(int ID)
        {
            InitializeComponent();
            Initialize();
            dsMain = bll.GetByID(-1);
            SetTableNames();
            AddAttachmentCtrl();
            RefreshData();
            this.ID = ID;
            SendKeys.Send("{TAB}") ;
        }

        private void Initialize()
        {
            base.btnBaseAdd = this.btnSaveNClear;
            base.btnBaseEdit = this.btnSave;
            base.btnBaseDelete = this.btnDelete;
            base.SystemObjectName = this.Name;
           
           

            ConditionsAdjustment();

           

        }
        public frmCompanies(bool isCalledFromContact, int? CompanyID)
        {
            InitializeComponent();
            Initialize();
            if (CompanyID == null)
            {
                dsMain = bll.GetByID(-1);
                isEdit = true;
            }
            else
            {
                dsMain = bll.GetByID(Convert.ToInt32(CompanyID));
                this.ID = Convert.ToInt32(CompanyID);
                SendKeys.Send("{TAB}");
            }

            SetTableNames();
            AddAttachmentCtrl();
            RefreshData();
            this.isCalledFromContact = isCalledFromContact;
            btnSaveNClear.Visible = false;
            luCode.Properties.Buttons.RemoveAt(0);
            lulookup.Properties.Buttons.RemoveAt(0);
            btnSave.Text = "Save && Close";


        }

        private void AddAttachmentCtrl()
        {
            ucAttach = new ucAttachment(dsMain.Tables[Tables.Attachments], Screens.frmCompanies, ScreensNames.frmCompanies);
            ucAttach.Location = new Point(0, 0);
            ucAttach.Show();
            ucAttach.Dock = DockStyle.Fill;
            tpAttachments.Controls.Add(ucAttach);

            ucNotesCtrl = new ucNotes(dsMain.Tables[Tables.Notes], Screens.frmCompanies, ScreensNames.frmCompanies);
            ucNotesCtrl.Location = new Point(0, 0);
            ucNotesCtrl.Show();
            ucNotesCtrl.Dock = DockStyle.Fill;
            tpNotes.Controls.Add(ucNotesCtrl);

            ucDiaryCtrl = new ucDiaryActions(dsMain.Tables[Tables.DiaryActions], Screens.frmCompanies, ScreensNames.frmCompanies);
            ucDiaryCtrl.Location = new Point(0, 0);
            ucDiaryCtrl.Show();
            ucDiaryCtrl.Dock = DockStyle.Fill;
            tpDiaryActions.Controls.Add(ucDiaryCtrl);
        }

        private void SetTableNames()
        {
            dsMain.Tables[0].TableName = Tables.Companies;
            dsMain.Tables[1].TableName = Tables.ExistingData;
            dsMain.Tables[2].TableName = Tables.CompanyBackOffices;
            dsMain.Tables[3].TableName = Tables.TimeSheetFrequencies;
            dsMain.Tables[4].TableName = Tables.Statuses;
            dsMain.Tables[5].TableName = Tables.Industries;
            dsMain.Tables[6].TableName = Tables.Counties;
            dsMain.Tables[7].TableName = Tables.Countries;
            dsMain.Tables[8].TableName = Tables.Attachments;
            dsMain.Tables[9].TableName = Tables.Notes;
            dsMain.Tables[10].TableName = Tables.DiaryActions;
            dsMain.Tables[11].TableName = Tables.CompanySites;
            dsMain.Tables[12].TableName = Tables.ContactTypes;
            dsMain.Tables[13].TableName = Tables.Persons;
            dsMain.Tables[14].TableName = Tables.JobTitles;
            dsMain.Tables[15].TableName = Tables.Consultant;


            DataRelation relation = new DataRelation("relBackOffices", dsMain.Tables[Tables.Companies].Columns[Companies.ID], dsMain.Tables[Tables.CompanyBackOffices].Columns[CompanyBackOffices.CompaniesID], false);
            dsMain.Relations.Add(relation);

            relation = new DataRelation("relSites", dsMain.Tables[Tables.Companies].Columns[Companies.ID], dsMain.Tables[Tables.CompanySites].Columns[CompanySites.CompaniesID], false);
            dsMain.Relations.Add(relation);

        }
       
       

        private void RefreshData()
        {
            luCode.Properties.ValueMember = Companies.ID;
            luCode.Properties.DisplayMember = Companies.CompanyName;
            luCode.Properties.DataSource = dsMain.Tables[Tables.ExistingData];

            lulookup.Properties.ValueMember = Companies.ID;
            lulookup.Properties.DisplayMember = Companies.CompanyName;
            lulookup.Properties.DataSource = dsMain.Tables[Tables.ExistingData];

            //lookUpEdit1.Properties.ValueMember = Companies.ID;
            //lookUpEdit1.Properties.DisplayMember = Companies.CompanyName;
            //lookUpEdit1.Properties.DataSource = dsMain.Tables[Tables.ExistingData];

            luStatus.Properties.ValueMember = Statuses.ID;
            luStatus.Properties.DisplayMember = Statuses.Name;
            luStatus.Properties.DataSource = dsMain.Tables[Tables.Statuses];

            luConsultant.Properties.ValueMember = Persons.ID;
            luConsultant.Properties.DisplayMember = Persons.FullName;
            luConsultant.Properties.DataSource = dsMain.Tables[Tables.Consultant];


            luIndustry.Properties.ValueMember = Industries.ID;
            luIndustry.Properties.DisplayMember = Industries.Name;
            luIndustry.Properties.DataSource = dsMain.Tables[Tables.Industries];


            luTimeSheetFrequency.Properties.ValueMember = TimeSheetFrequencies.ID;
            luTimeSheetFrequency.Properties.DisplayMember = TimeSheetFrequencies.Name;
            luTimeSheetFrequency.Properties.DataSource = dsMain.Tables[Tables.TimeSheetFrequencies];


            luCountry.Properties.ValueMember = Countries.ID;
            luCountry.Properties.DisplayMember = Countries.Name;
            luCountry.Properties.DataSource = dsMain.Tables[Tables.Countries];

            luCounty.Properties.ValueMember = Counties.ID;
            luCounty.Properties.DisplayMember = Counties.Name;
            luCounty.Properties.DataSource = dsMain.Tables[Tables.Counties];


            rluCountry.Properties.ValueMember = Countries.ID;
            rluCountry.Properties.DisplayMember = Countries.Name;
            rluCountry.Properties.DataSource = dsMain.Tables[Tables.Countries];

            rluCounty.Properties.ValueMember = Counties.ID;
            rluCounty.Properties.DisplayMember = Counties.Name;
            rluCounty.Properties.DataSource = dsMain.Tables[Tables.Counties];

            ucAttach.RefreshDataSource(dsMain.Tables[Tables.Attachments]);
            ucNotesCtrl.RefreshDataSource(dsMain.Tables[Tables.Notes]);
            ucDiaryCtrl.RefreshDataSource(dsMain.Tables[Tables.DiaryActions]);

            grdSites.DataSource = dsMain.Tables[Tables.CompanySites];
            grdSites.RefreshDataSource();


            rluContactType.ValueMember = ContactTypes.ID;
            rluContactType.DisplayMember = ContactTypes.Name;
            rluContactType.DataSource = dsMain.Tables[Tables.ContactTypes];

            rluJobTitle.ValueMember = JobTitles.ID;
            rluJobTitle.DisplayMember = JobTitles.Name;
            rluJobTitle.DataSource = dsMain.Tables[Tables.JobTitles];


            grdContacts.DataSource = dsMain.Tables[Tables.Persons];
            grdContacts.RefreshDataSource();
        }

        private void ClearFields()
        {
            try
            {
                Err.ClearErrors();
                
                txtCompanyNo.Text = string.Empty;
                txtVATNo.Text = string.Empty;
                txtAccountID.Text = string.Empty;

                luTimeSheetFrequency.EditValue = null;
                txtPaymentDays.EditValue = 0;
                chkValidVAT.Checked = false;

                txtBackofficeCompanyName.Text = string.Empty;
                txtNoOfEmp.EditValue = 0;
                txtTurnover.EditValue = 0;
                luIndustry.EditValue = null;
                luStatus.EditValue = null;
                txtComments.EditValue = string.Empty;

                txtAddress1.Text = string.Empty;
                txtAddress2.Text = string.Empty;
                txtCity.Text = string.Empty;
                txtPostCode.Text = string.Empty;

                luCountry.EditValue = null;
                luCounty.EditValue = null;

                txtTel.Text = string.Empty;
                txtFax.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtWebsite.Text = string.Empty;

                lblEntry.Text = string.Empty;
                btnDelete.Enabled = false;

                luConsultant.EditValue = null;
                dtStartDate.EditValue = null;

                //grdSites.DataSource = null;

                for (int i = 0; i < dsMain.Tables[Tables.CompanySites].Rows.Count; i++)
                {
                    dsMain.Tables[Tables.CompanySites].Rows.RemoveAt(i);
                    i--;
 
                }
                dsMain.Tables[Tables.CompanySites].AcceptChanges();
                grdSites.RefreshDataSource();

                try
                {
                    for (int i = 0; i < dsMain.Tables[Tables.Persons].Rows.Count; i++)
                    {
                        dsMain.Tables[Tables.Persons].Rows.RemoveAt(i);
                        i--;

                    }
                }


                catch (Exception ex)
                {
                    Functions.LogError(ex);
                    Messages.Error(ex.Message);
                   
                }
               


                isEdit = false;
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
            //ht.Add(Companies.ID, Convert.ToInt32(luCode.EditValue));
            ht.Add(Companies.ID, Convert.ToInt32(lulookup.EditValue));
            ht.Add(DiaryActions.CreatedBy, Program.clsuser.UserID);
           dsMain = bll.ExecuteSP("usp_" + Tables.Companies + "GetByID", ht);
            
            //dsMain = bll.GetByID(Convert.ToInt32(luCode.EditValue));
            SetTableNames();

            RefreshData();
        }
        private void BindFields()
        {
            try
            {
                
                txtCompanyNo.Text = dsMain.Tables[Tables.Companies].Rows[0][Companies.CompanyRegNo].ToString(); ;
                txtVATNo.Text = dsMain.Tables[Tables.Companies].Rows[0][Companies.VATNumber].ToString();
                txtAccountID.Text = dsMain.Tables[Tables.Companies].Rows[0][Companies.AccountID].ToString();

                luConsultant.EditValue = dsMain.Tables[Tables.Companies].Rows[0][Companies.ConsultantID];
                if(string.IsNullOrEmpty( dsMain.Tables[Tables.Companies].Rows[0][Companies.ConsultantStartDate].ToString()))
                     dtStartDate.EditValue = dsMain.Tables[Tables.Companies].Rows[0][Companies.ConsultantStartDate];

                luTimeSheetFrequency.EditValue = dsMain.Tables[Tables.Companies].Rows[0][Companies.TimeSheetFrequenciesID];
                txtPaymentDays.EditValue = dsMain.Tables[Tables.Companies].Rows[0][Companies.PaymentTermDays];
                chkValidVAT.Checked = Convert.ToBoolean( dsMain.Tables[Tables.Companies].Rows[0][Companies.isVATStatus]);
                //backoffice
                if(dsMain.Tables[Tables.CompanyBackOffices].Rows.Count > 0)
                {
                    txtBackofficeCompanyName.Text = dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.CompanyName].ToString();
                    txtNoOfEmp.EditValue = dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.NoOfEmployees];
                    txtTurnover.EditValue = dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.TurnOver] ;
                    luIndustry.EditValue = dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.IndustriesID];
                    luStatus.EditValue = dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.StatusesID];
                    txtComments.EditValue = dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.Comments].ToString(); ;

                    txtAddress1.Text = dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.Address1].ToString(); ;
                    txtAddress2.Text = dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.Address2].ToString();
                    txtCity.Text = dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.City].ToString();
                    txtPostCode.Text = dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.Postcode].ToString();

                    luCountry.EditValue = dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.CountriesID];
                    luCounty.EditValue = dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.CountiesID];

                    txtTel.Text = dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.Tel].ToString();
                    txtFax.Text = dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.Fax].ToString();
                    txtEmail.Text = dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.Email].ToString();
                    txtWebsite.Text = dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.Website].ToString();
                }

                chkActive.Checked = Convert.ToBoolean(dsMain.Tables[Tables.Companies].Rows[0][Companies.isActive]);
                ucAttach.RefreshDataSource(dsMain.Tables[Tables.Attachments]);
                ucNotesCtrl.RefreshDataSource(dsMain.Tables[Tables.Notes]);
                ucDiaryCtrl.RefreshDataSource(dsMain.Tables[Tables.DiaryActions]);



                grdSites.DataSource = dsMain.Tables[Tables.CompanySites];
                grdSites.RefreshDataSource();
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
                    //luCode.Text = dsMain.Tables[Tables.ExistingData].Rows[dsMain.Tables[Tables.ExistingData].Rows.Count - 1][Companies.CompanyName].ToString();
                    //luCode.EditValue = -1;
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
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
        }

        private bool Save()
        {
            if (!Messages.Save())
                return false;

            if (!Validation())
                return false;

            try
            {
                MarkAsDelete();
                if (dsMain.Tables[Tables.Companies].Rows.Count == 0)
                    dsMain.Tables[Tables.Companies].Rows.Add(dsMain.Tables[Tables.Companies].NewRow());

                if (dsMain.Tables[Tables.CompanyBackOffices].Rows.Count == 0)
                    dsMain.Tables[Tables.CompanyBackOffices].Rows.Add(dsMain.Tables[Tables.CompanyBackOffices].NewRow());


                //if (!isEdit)
                //{
                //    dsMain.Tables[Tables.CompanyBackOffices].Rows.Add(dsMain.Tables[Tables.CompanyBackOffices].NewRow());
                //    dsMain.Tables[Tables.Companies].Rows.Add(dsMain.Tables[Tables.Companies].NewRow());
                //}


                //dsMain.Tables[Tables.Companies].Rows[0][Companies.CompanyName]= luCode.Text;
                dsMain.Tables[Tables.Companies].Rows[0][Companies.CompanyName] = lulookup.Text;
                dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.CompanyName] = txtBackofficeCompanyName.Text;
                
                if(txtNoOfEmp.EditValue == null)
                    dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.NoOfEmployees] = 0;
                else
                    dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.NoOfEmployees]= txtNoOfEmp.EditValue ;
                
                if(txtTurnover.EditValue == null)
                    dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.TurnOver] = 0;
                else
                    dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.TurnOver]= txtTurnover.EditValue ;
                if(luIndustry.EditValue != null)
                    dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.IndustriesID]= luIndustry.EditValue ;

                if (luStatus.EditValue != null)
                    dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.StatusesID]= luStatus.EditValue ;

                dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.Comments] = txtComments.EditValue ;

                dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.Address1] = txtAddress1.Text ;
                dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.Address2]= txtAddress2.Text ;
                dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.City]= txtCity.Text ;
                dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.Postcode]= txtPostCode.Text ;

                if (luCountry.EditValue != null)
                    dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.CountriesID]= luCountry.EditValue ;

                if (luCounty.EditValue != null)
                dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.CountiesID]= luCounty.EditValue ;

                dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.Tel]= txtTel.Text ;
                dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.Fax]= txtFax.Text ;
                dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.Email]= txtEmail.Text ;
                dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.Website]= txtWebsite.Text ;
                dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.isActive] = true;

                dsMain.Tables[Tables.Companies].Rows[0][Companies.VATNumber]= txtVATNo.Text ;
                dsMain.Tables[Tables.Companies].Rows[0][Companies.AccountID]= txtAccountID.Text ;
                dsMain.Tables[Tables.Companies].Rows[0][Companies.CompanyRegNo] = txtCompanyNo.Text;
                
                if(!luConsultant.Text.Equals(string.Empty))
                    dsMain.Tables[Tables.Companies].Rows[0][Companies.ConsultantID] = luConsultant.EditValue;
                

                if (luTimeSheetFrequency.EditValue != null)
                    dsMain.Tables[Tables.Companies].Rows[0][Companies.TimeSheetFrequenciesID]= luTimeSheetFrequency.EditValue ;

                if(txtPaymentDays.EditValue == null)
                    dsMain.Tables[Tables.Companies].Rows[0][Companies.PaymentTermDays]= 0 ;
                else
                    dsMain.Tables[Tables.Companies].Rows[0][Companies.PaymentTermDays] = txtPaymentDays.EditValue;

                dsMain.Tables[Tables.Companies].Rows[0][Companies.isVATStatus]= chkValidVAT.Checked ;
               // dsMain.Tables["CompanyBackOffices"].Rows[0]["CompaniesID"] = DBNull.Value;
                dsMain.Tables[Tables.Companies].Rows[0][Companies.isActive] = chkActive.Checked;


                if(dsMain.Relations.Contains("relAttachment"))
                    dsMain.Relations.Remove("relAttachment");

                dsMain.Tables.Remove(Tables.Attachments);
                dsMain.Tables.Add(ucAttach.GetAttachmentTable().Copy());
                DataRelation relation = new DataRelation("relAttachment", dsMain.Tables[Tables.Companies].Columns[Companies.ID], dsMain.Tables[Tables.Attachments].Columns[Attachments.RecordID], false);
                dsMain.Relations.Add(relation);

                if (dsMain.Relations.Contains("relNotes"))
                    dsMain.Relations.Remove("relNotes");

                dsMain.Tables.Remove(Tables.Notes);
                dsMain.Tables.Add(ucNotesCtrl.GetNotesTable().Copy());
                 relation = new DataRelation("relNotes", dsMain.Tables[Tables.Companies].Columns[Companies.ID], dsMain.Tables[Tables.Notes].Columns[Notes.RecordID], false);
                dsMain.Relations.Add(relation);

                if (dsMain.Relations.Contains("relDiary"))
                    dsMain.Relations.Remove("relDiary");

                dsMain.Tables.Remove(Tables.DiaryActions);
                dsMain.Tables.Add(ucDiaryCtrl.GetScheduleTable().Copy());
                relation = new DataRelation("relDiary", dsMain.Tables[Tables.Companies].Columns[Companies.ID], dsMain.Tables[Tables.DiaryActions].Columns[Attachments.RecordID], false);
                dsMain.Relations.Add(relation);

                dsMain =  bll.SaveComplex(dsMain, isEdit);
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
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Save())
                    return;

                //SetTableNames();
                RefreshData();
                //if (luCode.EditValue == null || luCode.EditValue.ToString().Equals("-1"))
                //    luCode.EditValue = dsMain.Tables[Tables.Companies].Rows[0][Companies.ID];

                if (lulookup.EditValue == null || lulookup.EditValue.ToString().Equals("-1"))
                    lulookup.EditValue = dsMain.Tables[Tables.Companies].Rows[0][Companies.ID];

                GetByID();
               
                BindFields();

                if (isCalledFromContact)
                {
                    //((frmContacts)this.Owner).UpdateCompanyList(Convert.ToInt32(luCode.EditValue), luCode.Text, txtCompanyNo.Text, txtVATNo.Text);
                    this.Visible = false;
                }
                else
                {
                    //((frmCompaniesVW)(this.Owner)).RefreshData(Convert.ToInt32(luCode.EditValue));
                    //((frmMain)(((frmCompaniesVW)(this.Owner)).MdiParent)).RefreshDiaryActions();

                    ((frmCompaniesVW)(this.Owner)).RefreshData(Convert.ToInt32(lulookup.EditValue));
                    ((frmMain)(((frmCompaniesVW)(this.Owner)).MdiParent)).RefreshDiaryActions();
                
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
            //Err.ClearErrors();


            if (txtAccountID.Text.Trim().Equals(string.Empty))
            {
                Err.SetError(txtAccountID, "Enter account id.");
                txtAccountID.Focus();
                check = false;
            }
            else
            {
                Err.SetError(txtAccountID, null);
            }



            //if (txtVATNo.Text.Trim().Equals(string.Empty))
            //{
            //    Err.SetError(txtVATNo, "Enter VAT number.");
            //    txtVATNo.Focus();
            //    check = false;
            //}
            //else
            //{
            //    Err.SetError(txtVATNo, null);
            //}


            if ((txtCompanyNo.Text.Trim() == string.Empty) )
            {
                Err.SetError(txtCompanyNo, "Enter company number.");
                txtCompanyNo.Focus();
                check = false;
            }

            else
            {
                Err.SetError(txtCompanyNo, null);
            }

            if ((lulookup.Text == string.Empty))
            {
                Err.SetError(lulookup, "Enter company name.");
                lulookup.Focus();
                check = false;
            }

            else
            {
                Err.SetError(lulookup, null);
            }

            //if ((luCode.Text == string.Empty))
            //{
            //    Err.SetError(luCode, "Enter company name.");
            //    luCode.Focus();
            //    check = false;
            //}

            //else
            //{
            //    Err.SetError(luCode, null);
            //}


            return check;


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //if (luCode.EditValue != null)
                //{
                //    if (Messages.Delete())
                //    {
                //        bll.Delete(Convert.ToInt32(luCode.EditValue));
                //        ClearFields();
                //        luCode.EditValue = null;
                //    }
                //}
                if (lulookup.EditValue != null)
                {
                    if (Messages.Delete())
                    {
                        bll.Delete(Convert.ToInt32(lulookup.EditValue));
                        ClearFields();
                        lulookup.EditValue = null;
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
                
               
                ClearFields();
                //luBranches.Focus();
                //luCode.EditValue = null;
                lulookup.EditValue = null;
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);

            }
            finally
            { }
        }

        bool isCalledFromProcessNewVal = false;

        private void luCode_ProcessNewValue(System.Object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            try
            {
                //luCode.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;

               

                if (e.DisplayValue == null || string.Empty.Equals(e.DisplayValue))
                {
                    return;
                }

                if (this.isEdit)
                {
                    for (int i = 0; i < dsMain.Tables[Tables.ExistingData].Rows.Count; i++)
                    {
                        if (dsMain.Tables[Tables.ExistingData].Rows[i][Companies.ID].ToString().Equals(luCode.EditValue.ToString()))
                        {
                            dsMain.Tables[Tables.ExistingData].Rows[i][Companies.CompanyName] = e.DisplayValue;
                            e.Handled = true;
                            return;
                        }
                    }
                }
                
                if (dsMain.Tables[Tables.ExistingData].Rows.Count > 0)
                {
                    DataRow dr = dsMain.Tables[Tables.ExistingData].Rows[dsMain.Tables[Tables.ExistingData].Rows.Count - 1];
                    if (dr[ExistingData.ID].ToString().Equals("-1"))
                    {
                        dr[luCode.Properties.DisplayMember] = e.DisplayValue.ToString();
                        e.Handled = true;
                    }
                    else
                    {
                        ClearFields();
                      
                        
                        DataRow r = dsMain.Tables[Tables.ExistingData].Rows.Add(new object[] { });
                        r[luCode.Properties.DisplayMember] = e.DisplayValue.ToString();
                        r[luCode.Properties.ValueMember] = -1;
                        e.Handled = true;
                        
                    }
                }
                else
                {
                   
                    DataRow dr = dsMain.Tables[Tables.ExistingData].NewRow();
                    dr["CompanyName"] = e.DisplayValue.ToString();
                   
                    dsMain.Tables[Tables.ExistingData].Rows.Add(dr);
                }

                
                
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

        private void SetEditValuetoNewRec()
        {
            if (isCalledFromProcessNewVal)
            {
               // luCode.EditValue = -1;
                lulookup.EditValue = -1;
                isCalledFromProcessNewVal = false;
            }
        }

        private void luCode_KeyDown(object sender, KeyEventArgs e)
        {
            //luCode.EditValue = null;
        }

        private void frmCompanies_Load(object sender, EventArgs e)
        {
            if (this.ID != null)
            {
                //luCode.EditValue = this.ID;
                lulookup.EditValue = this.ID;
                lulookup_Leave(null, null);
                
            }
            luCode.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;

            //DataColumn dc = new DataColumn();
            //dc.ColumnName = "ID";
            //dc.DataType = typeof(int);

            //dt.Columns.Add(dc);

            //dc = new DataColumn();
            //dc.ColumnName = "CompanyName";

            //dt.Columns.Add(dc);


            //for (int i = 0; i < 3; i++)
            //    this.dt.Rows.Add(new object[] { i, "Name" + i });

            //luCanType.Properties.DataSource = dsMain.Tables[Tables.ExistingData];
            //luCanType.Properties.DisplayMember = Companies.CompanyName;
            //luCanType.Properties.ValueMember= Companies.ID;

           // dt = dsMain.Tables[Tables.ExistingData];

           
           //luCanType.Properties.DataSource = dt;
           // luCanType.Properties.DisplayMember = Companies.CompanyName;
           // luCanType.Properties.ValueMember = Companies.ID;

            luCode.Properties.DataSource = dsMain.Tables[Tables.ExistingData];
            luCode.Properties.DisplayMember = Companies.CompanyName;
            luCode.Properties.ValueMember = Companies.ID;

            lulookup.Properties.DataSource = dsMain.Tables[Tables.ExistingData];
            lulookup.Properties.DisplayMember = Companies.CompanyName;
            lulookup.Properties.ValueMember = Companies.ID;

            luCode.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;

            //lulookup.ShowPopup();
        }

        private void luCanType_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.DisplayValue.ToString()))
            {
                if (luCanType.EditValue== null || luCanType.EditValue.ToString() != "-1")
                {
                    LookUpEdit edit = (sender as LookUpEdit);
                    DataRow r = dt.Rows.Add(new object[] { });
                    r[edit.Properties.DisplayMember] = e.DisplayValue.ToString();
                    r[edit.Properties.ValueMember] = "-1";
                    e.Handled = true;
                }
                else
                {
                     dt.Rows[dt.Rows.Count - 1]["Name"] =e.DisplayValue.ToString() ;
                    
                }
            }
        }

        private void frmCompanies_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (isCalledFromContact && !luCode.EditValue.ToString().Equals("-1") && luCode.EditValue != null)
            
        }

        private void luCode_Leave(object sender, EventArgs e)
        {
            if (luCode.EditValue == null)
            {
                ClearFields();
            }
            else
            {
                string companyName = luCode.Text;
                    luCode_EditValueChanged(null, null);

                    for (int i = 0; i < dsMain.Tables[Tables.ExistingData].Rows.Count; i++)
                    {
                        if (dsMain.Tables[Tables.ExistingData].Rows[i][Companies.ID].ToString().Equals(luCode.EditValue.ToString()))
                        {
                            dsMain.Tables[Tables.ExistingData].Rows[i][Companies.CompanyName] = companyName;
                            return;
                        }
                    }

               
            }

            
        }

        private void txtWebsite_DoubleClick(object sender, EventArgs e)
        {
            string txt = ((TextEdit)sender).Text;
            
            if (txt.Trim().Equals(string.Empty)  )
                return;

            if (!Functions.UrlIsValid(txt))
                return;

            if(!txt.StartsWith("www.",StringComparison.OrdinalIgnoreCase))
                txt = "www." + txt;

            System.Diagnostics.Process.Start(txt);

        }

        private void gvSites_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if(gvSites.GetRowCellValue(e.RowHandle, CompanySites.CountriesID).ToString().Equals(string.Empty))
                gvSites.SetRowCellValue(e.RowHandle, CompanySites.CountriesID, Program.clsuser.HomeCountryID);
            //gvSites.SetRowCellValue(e.RowHandle, DeleteCol,0);

        }

        private void Delete()
        {
            try
            {
                if (gvSites.FocusedRowHandle > -1)
                {
                    //if (DialogResult.Yes == XtraMessageBox.Show(Constants.DeleteMsg, Constants.ApplicationTitle, MessageBoxButtons.YesNo))
                    //{
                    if (gvSites.GetRowCellValue(gvSites.FocusedRowHandle, Attachments.ID) != DBNull.Value)
                    {
                        if (Convert.ToInt32(gvSites.GetRowCellValue(gvSites.FocusedRowHandle, DeleteCol)) == 1)
                        {
                            gvSites.SetRowCellValue(gvSites.FocusedRowHandle, DeleteCol, 0);


                        }
                        else
                        {
                            gvSites.SetRowCellValue(gvSites.FocusedRowHandle, DeleteCol, 1);


                        }


                        gvSites.RefreshData();


                    }
                    else
                    {
                        dsMain.Tables[Tables.CompanySites].Rows[gvSites.FocusedRowHandle].Delete();
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

       
        private void ConditionsAdjustment()
        {
            StyleFormatCondition cn;

            cn = new StyleFormatCondition(FormatConditionEnum.Equal, gvSites.Columns[DeleteCol], null, 1);
            cn.ApplyToRow = true;
            cn.Appearance.Font = new Font(AppearanceObject.DefaultFont, FontStyle.Bold | FontStyle.Strikeout);

            cn.Appearance.BorderColor = Color.Red;
            //cn.Appearance.ForeColor = SystemColors.ControlDark;
            cn.Appearance.ForeColor = System.Drawing.Color.Red;
            gvSites.FormatConditions.Add(cn);

            gvSites.BestFitColumns();
        }

        private void MarkAsDelete()
        {
            for (int i = 0; i < dsMain.Tables[Tables.CompanySites].Rows.Count; i++)
            {
                if (dsMain.Tables[Tables.CompanySites].Rows[i][DeleteCol].ToString().Equals("1"))
                {
                    if (dsMain.Tables[Tables.CompanySites].Rows[i].RowState == DataRowState.Unchanged)
                        dsMain.Tables[Tables.CompanySites].Rows[i].AcceptChanges();

                    dsMain.Tables[Tables.CompanySites].Rows[i].Delete();
                }
            }
        }

        private void gvSites_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Delete();
            }
        }

        int CompanyID = 0;
        private void luCode_Enter(object sender, EventArgs e)
        {
            if (luCode.EditValue != null)
            {
                CompanyID = Convert.ToInt32(luCode.EditValue);
            }
            else
            {
                CompanyID = 0;
            }
        }

        private void searchLookUpEdit1_Properties_AddNewValue(object sender, DevExpress.XtraEditors.Controls.AddNewValueEventArgs e)
        {

        }

        private void lulookup_AddNewValue(object sender, DevExpress.XtraEditors.Controls.AddNewValueEventArgs e)
        {
             string txt = ((sender as SearchLookUpEdit).Properties.View as ColumnView).FindFilterText;

            if(dsMain.Tables[Tables.ExistingData].Rows[dsMain.Tables[Tables.ExistingData].Rows.Count -1][ExistingData.ID].ToString().Equals("-1"))
            {
               
            }
            else
            {
                dsMain.Tables[Tables.ExistingData].Rows.Add(dsMain.Tables[Tables.ExistingData].NewRow());
            }


            dsMain.Tables[Tables.ExistingData].Rows[dsMain.Tables[Tables.ExistingData].Rows.Count - 1][Companies.CompanyName] = txt;
            dsMain.Tables[Tables.ExistingData].Rows[dsMain.Tables[Tables.ExistingData].Rows.Count - 1][Companies.ID] = -1;
            isEdit = false;
            lblEntry.Text = "New Entry";
            lulookup.EditValue = -1;
             e.NewValue = -1; 
        }

        private void lulookup_Leave(object sender, EventArgs e)
        {
            if(lulookup.Text == string.Empty)
            {
                if (dsMain.Tables[Tables.ExistingData].Rows[dsMain.Tables[Tables.ExistingData].Rows.Count - 1][ExistingData.ID].ToString().Equals("-1"))
                    lulookup.EditValue = -1;
            }

            if (lulookup.EditValue == null || lulookup.EditValue.ToString().Equals("-1"))
            {
                isEdit = false;
                ClearFields();
                lblEntry.Text = "New Entry";
            }
            else
            {
                isEdit = true;
                lblEntry.Text = "";
                GetByID();
                BindFields();
            }

            if ((isEdit))
            {
               

            }
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            lulookup.ShowPopup();
        }

        private void lulookup_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            SendKeys.Send("{TAB}");
        }


    }
}