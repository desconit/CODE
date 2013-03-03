using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DESCONIT.BLL;
using System.Collections;

namespace RSys
{
    public partial class frmPlacementWizard : DevExpress.XtraEditors.XtraForm
    {
        DataSet dsMain;
        BLL bll = new BLL(Program.clsuser.CurrentDB);

        public frmPlacementWizard()
        {
            InitializeComponent();
            RefreshData();
            
        }

        private void SetTableNames()
        {
            dsMain.Tables[0].TableName = Tables.Persons;
            dsMain.Tables[1].TableName = Tables.Requirements;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshData()
        {
            try
            {
                teStartTime.Time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 30, 0);

                
                dsMain = bll.ExecuteSP("usp_PlacementWizardGet");
                SetTableNames();
                luCandidate.Properties.DataSource = dsMain.Tables[Tables.Persons];
                luCandidate.Properties.DisplayMember = Persons.FullName;
                luCandidate.Properties.ValueMember = Persons.ID;

                luJob.Properties.DataSource = dsMain.Tables[Tables.Requirements];
                luJob.Properties.DisplayMember = Requirements.Reference;
                luJob.Properties.ValueMember = Requirements.ID;


                ClearFields();
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

        private void ClearFields()
        {
            
            HideTabs(0);
            teStartTime.Time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 30, 0);
            btnNext.Text = "&Next";
            btnPrevious.Enabled = false;
            luCandidate.EditValue = null;
            luJob.EditValue = null;
            luCandidate.Focus();
        }

        private void HideTabs(int iCurrTab)
        {
           
            for (int i = 0; i < xtMain.TabPages.Count; i++)
            {
                    xtMain.TabPages[i].PageVisible = false;
            }
            xtMain.TabPages[iCurrTab].PageVisible = true;
            xtMain.SelectedTabPageIndex = iCurrTab;

            if (iCurrTab == 0)
                luCandidate.Focus();
            else if (iCurrTab == 1)
                luJob.Focus();
            

        }
        private void luCandidate_EditValueChanged(object sender, EventArgs e)
        {
            if (luCandidate.EditValue == null)
            {
                txtContactAddress1.Text = "";
                txtContactAddress2.Text = "";
                txtContactCity.Text = "";
                txtContactMobile.Text = "";
                txtContactPostCode.Text = "";
                txtContactTel.Text = "";

                txtCandidateConfimAddress1.Text = "";
                txtCandidateConfimAddress2.Text = "";
                txtCandidateConfimCity.Text = "";
                txtCandidateConfimMobile.Text = "";
                txtCandidateConfimPostcode.Text = "";
                txtCandidateConfimTel.Text = "";
            }
            else
            {
                txtContactAddress1.Text = luCandidate.GetColumnValue(Persons.Address1).ToString();
                txtContactAddress2.Text = luCandidate.GetColumnValue(Persons.Address2).ToString();
                txtContactCity.Text = luCandidate.GetColumnValue(Persons.City).ToString();
                txtContactMobile.Text = luCandidate.GetColumnValue(Persons.PersonalMobile).ToString();
                txtContactPostCode.Text = luCandidate.GetColumnValue(Persons.Postcode).ToString(); ;
                txtContactTel.Text = luCandidate.GetColumnValue(Persons.HomeTel).ToString(); ;

                txtCandidateConfimAddress1.Text = luCandidate.GetColumnValue(Persons.Address1).ToString();
                txtCandidateConfimAddress2.Text = luCandidate.GetColumnValue(Persons.Address2).ToString();
                txtCandidateConfimCity.Text = luCandidate.GetColumnValue(Persons.City).ToString();
                txtCandidateConfimMobile.Text = luCandidate.GetColumnValue(Persons.PersonalMobile).ToString();
                txtCandidateConfimPostcode.Text = luCandidate.GetColumnValue(Persons.Postcode).ToString(); ;
                txtCandidateConfimTel.Text = luCandidate.GetColumnValue(Persons.HomeTel).ToString(); ;
            }

            txtCandidateConfimName.Text = luCandidate.Text.Trim();
            dtJobConfirmStartDate.EditValue = dtEarliestStartDate.EditValue;
        }

        private void luJob_EditValueChanged(object sender, EventArgs e)
        {
            if (luJob.EditValue == null)
            {
                txtRef.Text = "";
                txtReqType.Text = "";
                txtJobTitle.Text = "";
                txtCompany.Text = "";
                dtEarliestStartDate.EditValue = null;
                
                txtOvertime.EditValue = 0;
                txtOvertimeCharged.EditValue = 0;
                
                txtWeekend.EditValue = 0;
                txtWeekendCharged.EditValue = 0;

                txtStandardRate.EditValue = 0;
                txtStandardCharged.EditValue = 0;
                dtStartDate.EditValue = null;
                teStartTime.Time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 30, 0);

                txtJobConfirmRef.Text ="";
                txtJobConfirmType.Text = "";
                txtJobConfirmJobTitle.Text = "";
                txtJobConfirmCompany.Text = "";
            }
            else
            {
                txtRef.Text = luJob.GetColumnValue(Requirements.Reference).ToString();
                txtReqType.Text = luJob.GetColumnValue("RequirementsType").ToString();
                txtJobTitle.Text = luJob.GetColumnValue(Requirements.JobName).ToString();
                txtCompany.Text = luJob.GetColumnValue(Companies.CompanyName).ToString();
                if (!String.IsNullOrEmpty(luJob.GetColumnValue(Requirements.EarliestStart).ToString()))
                {
                    dtEarliestStartDate.EditValue = Convert.ToDateTime(luJob.GetColumnValue(Requirements.EarliestStart));
                    
                }

                txtJobConfirmRef.Text = luJob.GetColumnValue(Requirements.Reference).ToString();
                txtJobConfirmType.Text = luJob.GetColumnValue("RequirementsType").ToString();
                txtJobConfirmJobTitle.Text = luJob.GetColumnValue(Requirements.JobName).ToString();
                txtJobConfirmCompany.Text = luJob.GetColumnValue(Companies.CompanyName).ToString();

                Hashtable ht = new Hashtable();
                ht.Add(Placements.RequirementId, luJob.EditValue);
                DataSet ds = bll.ExecuteSP("usp_PlacementWizardGetRequirementRates", ht);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i][RateTypes.Name].ToString().ToLower().Contains("weekend"))
                    {
                        txtWeekend.EditValue = ds.Tables[0].Rows[i][Contracts.PayRate];
                        txtWeekendCharged.EditValue = ds.Tables[0].Rows[i][Contracts.ChargeRate];
                    }
                    else if (ds.Tables[0].Rows[i][RateTypes.Name].ToString().ToLower().Contains("standard"))
                    {
                        txtStandardRate.EditValue = ds.Tables[0].Rows[i][Contracts.PayRate];
                        txtStandardCharged.EditValue = ds.Tables[0].Rows[i][Contracts.ChargeRate];
                    }
                    else if (ds.Tables[0].Rows[i][RateTypes.Name].ToString().ToLower().Contains("overtime"))
                    {
                        txtOvertime.EditValue = ds.Tables[0].Rows[i][Contracts.PayRate];
                        txtOvertimeCharged.EditValue = ds.Tables[0].Rows[i][Contracts.ChargeRate];
                    }
                }
            }

            txtJobConfirmRef.Text = luJob.Text.Trim();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int iCurrTab = xtMain.SelectedTabPageIndex;

            btnNext.Text = "&Next";
            

            if (iCurrTab == 0)
            {
               
                return;
            }
             //xtMain.SelectedTabPageIndex = --iCurrTab;
            HideTabs(--iCurrTab);
             xtMain.TabPages[iCurrTab].PageVisible = true;
            if(iCurrTab==0)
                btnPrevious.Enabled = false;

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int iCurrTab = xtMain.SelectedTabPageIndex;

          
            if(!Validation(iCurrTab))
                return;

            btnPrevious.Enabled = true;
            if (iCurrTab == 2)
            {
                SavePlacement();
            }
            else
            {
                HideTabs(++iCurrTab);
                if (iCurrTab == 2)
                {
                    btnNext.Text = "Fi&nish";
                }
                
                
            }
           
            
        }

        private bool Validation(int iCurrTab)
        {
            bool isValid = true;
            Err.ClearErrors();

            if(iCurrTab ==0)
            {
                if(luCandidate.Text.Equals(string.Empty))
                {
                    Err.SetError(luCandidate,"Must select candidate.");
                    isValid = false;
                }
            }
            else if (iCurrTab == 1)
            {


                if (teStartTime.Text.Equals(string.Empty))
                {
                    Err.SetError(teStartTime, "Must selet start time");
                    isValid = false;
                    teStartTime.Focus();
                }

                if (dtStartDate.Text.Equals(string.Empty))
                {
                    Err.SetError(dtStartDate, "Must select start date.");
                    isValid = false;
                    dtStartDate.Focus();
                }


                if (luJob.Text.Equals(string.Empty))
                {
                    Err.SetError(luJob, "Must select candidate.");
                    isValid = false;
                    luJob.Focus();
                }
                else if(isValid )
                {
                    Hashtable ht = new Hashtable();
                    ht.Add(Placements.RequirementId, luJob.EditValue);
                    ht.Add(Placements.PersonId, luCandidate.EditValue);
                    ht.Add(Placements.StartDate, dtStartDate.DateTime.Date.ToString());

                    DataSet ds = bll.ExecuteSP("usp_" + Tables.Placements + "GetByFields", ht);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Err.SetError(luJob, "Selected candidate has aleady in placement for selected job and date.");
                        Err.SetError(luCandidate, "Selected candidate has aleady in placement for selected job and date.");
                        isValid = false;
                        luJob.Focus();
                    }
                }
                

                
            }

            return isValid;
        }

        private void SavePlacement()
        {
            try
            {
                Hashtable ht = new Hashtable();

                ht.Add(Placements.RequirementId, luJob.EditValue);
                ht.Add(Placements.PersonId, luCandidate.EditValue);
                ht.Add(Placements.StartDate, new DateTime(dtStartDate.DateTime.Year, dtStartDate.DateTime.Month, dtStartDate.DateTime.Day, teStartTime.Time.Hour, teStartTime.Time.Minute, teStartTime.Time.Second));
                ht.Add(Placements.StandardRate, txtStandardRate.EditValue);
                ht.Add(Placements.StandardRateCharge, txtStandardCharged.EditValue);

                ht.Add(Placements.OvertimeRate, txtOvertime.EditValue);
                ht.Add(Placements.OvertimeRateCharge, txtOvertimeCharged.EditValue);

                ht.Add(Placements.WeekendRate, txtWeekend.EditValue);
                ht.Add(Placements.WeekendRateCharge, txtWeekendCharged.EditValue);
                ht.Add(Placements.IsDeleted, 0);
                ht.Add(Placements.IsCanceled, 0);
                ht.Add(Placements.EndDate,  dtStartDate.DateTime.AddDays(7));
                ht.Add(Placements.CreatedBy, Program.clsuser.UserID);
                DataSet ds = bll.ExecuteSP("usp_PlacementsAdd", ht);
                RefreshData();
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

        private void UPdateConfirmation()
        {
 
        }

        private void txtStandardRate_EditValueChanged(object sender, EventArgs e)
        {
            sePayDetailConfirmStdRate.EditValue = txtStandardRate.EditValue;
        }

        private void txtStandardCharged_EditValueChanged(object sender, EventArgs e)
        {
            sePayDetailConfirmStdCharge.EditValue = txtStandardCharged.EditValue;
        }

        private void txtOvertime_EditValueChanged(object sender, EventArgs e)
        {
            sePayDetailConfirmOvertime.EditValue = txtOvertime.EditValue;
        }

        private void txtOvertimeCharged_EditValueChanged(object sender, EventArgs e)
        {
            sePayDetailConfirmOverTimeCharge.EditValue = txtOvertimeCharged.EditValue;
        }

        private void txtWeekend_EditValueChanged(object sender, EventArgs e)
        {
            sePayDetailConfirmWeekend.EditValue = txtWeekend.EditValue;
        }

        private void txtWeekendCharged_EditValueChanged(object sender, EventArgs e)
        {
            sePayDetailConfirmWeekEndCharged.EditValue = txtWeekendCharged.EditValue;
        }

        private void dtStartDate_EditValueChanged(object sender, EventArgs e)
        {
            dtPayDetailConfirmStartDate.EditValue = dtStartDate.EditValue;
        }

       

        private void teStartTime_EditValueChanged(object sender, EventArgs e)
        {
            tePayDetailConfirmTime.EditValue = teStartTime.EditValue;
        }

        private void btnViewRequirement_Click(object sender, EventArgs e)
        {
            try
            {
                if (!luJob.Text.Equals(string.Empty))
                {
                    frmRequirements frm = new frmRequirements(Convert.ToInt32(luJob.EditValue ));
                    frm.Owner = this;
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                }

            }
            catch (Exception ex)
            {

                Functions.LogError(ex);
                throw;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {

               

                if (!luCandidate.Text.Equals(string.Empty))
                {
                     frmContacts frm;
                    frm = new frmContacts(ContactTypesConts.Candidate.ToString(), Convert.ToInt32( luCandidate.EditValue));

                    frm.Owner = this;
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
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

        
    }
}