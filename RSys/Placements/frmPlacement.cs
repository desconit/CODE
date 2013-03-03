using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TextMsgTest;

namespace RSys
{
    public partial class frmPlacement : Form
    {
        private int PlacementID = 0;
        private int CandidateID = 0;
        private int ReqID = 0;
        RsysEntities1 rsysEntities;
        private bool EditMode = false;

        public frmPlacement()
        {
            InitializeComponent();

            rsysEntities = new RsysEntities1();

            EditMode = false;

            SetUpPage();

            SendKeys.Send("TAB");
        }

        public frmPlacement(bool editMode, int candidateId, int reqId)
        {
            InitializeComponent();

            ReqID = reqId;
            CandidateID = candidateId;

            rsysEntities = new RsysEntities1();

            EditMode = editMode;

            loadPlacementInEditMode(reqId, candidateId);

            SendKeys.Send("TAB");
        }

        private void SetUpPage()
        {
            dtStartDate.MinDate = DateTime.Now.AddYears(-5);
            dtStartTime.MinDate = DateTime.Now.AddYears(-5);

            //Edit mode 
            if (EditMode)
            {
                btnDelete.Text = "Create Placement";
                btnTerminatePlacement.Enabled = false;
            }
            else
            {
                btnTxtPlacementDeatils.Enabled = true;
                btnDelete.Text = "Delete Placement";
                btnTerminatePlacement.Text = "Terminate placement";
                btnTerminatePlacement.Enabled = true;
            }
        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl26_Click(object sender, EventArgs e)
        {

        }

        public void loadPlacementInEditMode(int reqID, int candidateID)
        {
            EditMode = true;

            SetUpPage();

            var candidate = (from p in rsysEntities.Persons
                             where p.ID == candidateID
                             select p).First();

            ////Load the candidate details 
            txtFirstName.Text = candidate.FirstName;
            txtSurname.Text = candidate.LastName;
            txtContactAddress1.Text = candidate.Address1;
            txtContactAddress2.Text = candidate.Address2;
            txtContactCity.Text = candidate.City;
            txtContactMobile.Text = candidate.PersonalMobile;
            txtContactTel.Text = candidate.HomeTel;
            txtContactPostCode.Text = candidate.Postcode;

            var requirement = (from r in rsysEntities.Requirements
                               where r.ID == reqID
                               select r).First();

            var reqType =
                (from ct in rsysEntities.RequirementTypes.Where(x => x.ID == requirement.RequirementTypesID) select ct).First();


            var reqJobTitle = requirement.JobName;
            //    (from jt in rsysEntities.JobTitles.Where(j => j.ID == requirement.JobTitlesID) select jt).First();

            var company =
                (from co in rsysEntities.Companies.Where(c => c.ID == requirement.CompaniesID) select co).First();


            //Get rate types 
            var standardContract = (from c in rsysEntities.Contracts
                                    join rt in rsysEntities.RateTypes on c.RateTypesID equals rt.ID
                                    where rt.Name.Contains("Standard")
                                    select c).FirstOrDefault();


            if (standardContract != null)
            {
                if (standardContract.PayRate.HasValue)
                    txtStandardRate.Text = standardContract.PayRate.Value.ToString();

                if (standardContract.ChargeRate.HasValue)
                    txtCharge.Text = standardContract.ChargeRate.Value.ToString();
            }
            else
            {
                txtStandardRate.Text = 0.ToString();
                txtCharge.Text = 0.ToString();
            }

            //Overtime contract 
            //Get rate types 
            var overTimeContract = (from c in rsysEntities.Contracts
                                    join rt in rsysEntities.RateTypes on c.RateTypesID equals rt.ID
                                    where rt.Name.Contains("Overtime")
                                    select c).FirstOrDefault();


            if (overTimeContract != null)
            {
                if (overTimeContract.PayRate.HasValue)
                    txtOvertimeRate.Text = overTimeContract.PayRate.Value.ToString();

                if (overTimeContract.ChargeRate.HasValue)
                    txtOTCharge.Text = overTimeContract.ChargeRate.Value.ToString();
            }
            else
            {
                txtOTCharge.Text = 0.ToString();
                txtOvertimeRate.Text = 0.ToString();
            }

            //Overtime contract 
            //Get rate types 
            var weekendContract = (from c in rsysEntities.Contracts
                                   join rt in rsysEntities.RateTypes on c.RateTypesID equals rt.ID
                                   where rt.Name.Contains("Weekend")
                                   select c).FirstOrDefault();


            if (weekendContract != null)
            {
                if (weekendContract.PayRate.HasValue)
                    txtWeekendRate.Text = weekendContract.PayRate.Value.ToString();

                if (weekendContract.ChargeRate.HasValue)
                    txtWeekendCharge.Text = weekendContract.ChargeRate.Value.ToString();

            }
            else
            {
                txtWeekendRate.Text = 0.ToString();
                txtWeekendCharge.Text = 0.ToString();
            }


            //Load the requirement 
            txtRef.Text = requirement.Reference;
            txtReqType.Text = reqType.Name;

            if (requirement.EarliestStart.HasValue)
                txtEarlistStart.Text = requirement.EarliestStart.Value.ToShortDateString();
            txtCompany.Text = company.CompanyName;
           txtJobTitle.Text = requirement.JobName;

        }

        public void loadPlacement(int id)
        {
            PlacementID = id;

            var pl = (from p in rsysEntities.Placements.Where(p => p.IsDeleted == false)
                      join c in rsysEntities.Companies on p.Requirement.CompaniesID equals c.ID
                      where p.PlacementId == id
                      select new PlacementObject()
                                 {
                                     ID = p.PlacementId,
                                     CandidateID = p.Person.ID,
                                     FirstName = p.Person.FirstName,
                                     LastName = p.Person.LastName,
                                     RequirmentId = p.Requirement.ID,
                                     RequrimentRefrecnce = p.Requirement.Reference,

                                     StartDate = p.StartDate,
                                     StandardRate = p.StandardRate,
                                     OvertimeRate = p.OvertimeRate,
                                     WeekendRate = p.WeekendRate,
                                     IsCanceled = p.IsCanceled,
                                     ClientCompany = c.CompanyName,
                                     LastModifiedBy =
                                         rsysEntities.Persons.Where(x => x.ID == p.LastModifiedBy).FirstOrDefault
                                         ().FirstName,

                                     LastModifiedOn = p.LastModifiedOn,
                                     CreatedOn = p.CreatedOn,
                                     Canceled = p.IsCanceled,
                                     PlacementObjectStored = p,

                                     CreatedBy =
                                         rsysEntities.Persons.Where(x => x.ID == p.CreatedBy).FirstOrDefault().FirstName,


                                 }).First();

            CandidateID = pl.CandidateID;
            ReqID = pl.RequirmentId;

            LoadForm(pl);
        }

        private void LoadForm(PlacementObject pl)
        {
            var candidate = (from p in rsysEntities.Persons
                             where p.ID == pl.CandidateID
                             select p).First();



            var requirement = (from r in rsysEntities.Requirements
                               where r.ID == pl.RequirmentId
                               select r).First();

            var reqType =
                (from ct in rsysEntities.RequirementTypes.Where(x => x.ID == requirement.RequirementTypesID) select ct).First();


            //TODO: 
            var reqJobTitle = string.Empty;
            //    (from jt in rsysEntities.JobTitles.Where(j => j.ID == requirement.JobTitlesID) select jt).First();


            //Load the candidate details 
            txtFirstName.Text = pl.FirstName;
            txtSurname.Text = pl.LastName;
            txtContactAddress1.Text = candidate.Address1;
            txtContactAddress2.Text = candidate.Address2;
            txtContactCity.Text = candidate.City;
            txtContactMobile.Text = candidate.PersonalMobile;
            txtContactTel.Text = candidate.HomeTel;
            txtContactPostCode.Text = candidate.Postcode;

            //Load the requirement 
            txtRef.Text = requirement.Reference;
            txtReqType.Text = reqType.Name;

            if (requirement.EarliestStart.HasValue)
                txtEarlistStart.Text = requirement.EarliestStart.Value.ToShortDateString();
            txtCompany.Text = pl.ClientCompany;
           // txtJobTitle.Text = reqJobTitle.Name;


            dtStartTime.Value = pl.StartDate;

            //Site 
            //Client contact

            //load placement details 
            txtCreatedOn.Text = pl.CreatedOn.ToShortDateString();
            txtUpdatedOn.Text = pl.LastModifiedOn.ToShortDateString();

            txtCreatedBy.Text = pl.CreatedBy;
            txtUpdatedBy.Text = pl.LastModifiedBy;

            string specificer = "G";
            txtStandardRate.Text = string.Format("{0}", pl.StandardRate.ToString(specificer));
            txtWeekendRate.Text = string.Format("{0}", pl.WeekendRate.ToString(specificer));
            txtOvertimeRate.Text = string.Format("{0}", pl.OvertimeRate.ToString(specificer));
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {

                frmContacts frm;

                frm = new frmContacts(CandidateID);

                frm.Owner = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
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

        private void btnViewRequirement_Click(object sender, EventArgs e)
        {
            try
            {

                frmRequirements frm = new frmRequirements(ReqID);
                frm.Owner = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();


            }
            catch (Exception ex)
            {

                Functions.LogError(ex);
                throw;
            }

        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (EditMode)
            {
                try
                {
                    if (MessageBox.Show("Are you sure you want to create this placement?", "Confirm placement", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        //Save the placement 

                        Placement p = new Placement();

                        p.CreatedBy = Program.clsuser.UserID;
                        p.CreatedOn = DateTime.Now;
                        p.StartDate = new DateTime(dtStartDate.Value.Year, dtStartDate.Value.Month, dtStartDate.Value.Day, dtStartTime.Value.Hour, dtStartTime.Value.Minute, 0);
                        p.EndDate = DateTime.Now.AddDays(7);
                        p.LastModifiedOn = DateTime.Now;
                        p.IsCanceled = false;
                        p.IsDeleted = false;
                        //Rates 
                        p.StandardRate = Convert.ToDecimal(txtStandardRate.Text);
                        p.OvertimeRate = Convert.ToDecimal(txtOvertimeRate.Text);
                        p.WeekendRate = Convert.ToDecimal(txtWeekendRate.Text);

                        p.StandardRateCharge = Convert.ToDecimal(txtCharge.Text);
                        p.OvertimeRateCharge = Convert.ToDecimal(txtOTCharge.Text);
                        p.WeekendRateCharge = Convert.ToDecimal(txtWeekendCharge.Text);

                        p.Requirement = (from r in rsysEntities.Requirements.Where(re => re.ID == ReqID) select r).First();
                        p.Person = (from c in rsysEntities.Persons where c.ID == CandidateID select c).First();

                        rsysEntities.AddToPlacements(p);
                        rsysEntities.SaveChanges();

                        MessageBox.Show("Placement successfully created", "Placement Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    Functions.LogError(ex);
                    //Messages.Error(ex.Message);

                    throw;
                }


            }
            else
            {
                if (MessageBox.Show("Are you sure you wante to delete this placement?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        //Delete placment 
                        var placement = (from p in rsysEntities.Placements.Where(p => p.PlacementId == PlacementID) select p).First();
                        placement.IsDeleted = true;

                        rsysEntities.SaveChanges();

                        FrmPlacementsVW frm = Owner as FrmPlacementsVW;

                        if (frm != null)
                            frm.GetAllPlacemnts();

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    catch (Exception ex)
                    {
                        Functions.LogError(ex);
                        //Messages.Error(ex.Message);
                        throw;
                    }

                }
            }

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wante to cancel this placement?", "Cancel placement", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    //Delete placment 
                    var placement =
                        (from p in rsysEntities.Placements.Where(p => p.PlacementId == PlacementID) select p).First();
                    placement.IsCanceled = true;

                    rsysEntities.SaveChanges();

                    FrmPlacementsVW frm = Owner as FrmPlacementsVW;

                    if (frm != null)
                        frm.GetAllPlacemnts();

                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    Functions.LogError(ex);
                    //Messages.Error(ex.Message);
                    throw;
                }

            }
        }

        private void btnTxtPlacementDeatils_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to send this placements details?", "Text placement details to candidate", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    //Get Placement details 

                    var pl = (from p in rsysEntities.Placements.Where(p => p.IsDeleted == false)
                              join c in rsysEntities.Companies on p.Requirement.CompaniesID equals c.ID
                              join cs in rsysEntities.CompanySites on p.Requirement.SitesID equals cs.ID
                              where p.PlacementId == PlacementID
                              select new PlacementObject()
                                         {
                                             ID = p.PlacementId,
                                             CandidateID = p.Person.ID,
                                             FirstName = p.Person.FirstName,
                                             LastName = p.Person.LastName,
                                             RequirmentId = p.Requirement.ID,
                                             RequrimentRefrecnce = p.Requirement.Reference,
                                             ReportTo = rsysEntities.Persons.Where(x => x.ID == p.Requirement.PersonsID).FirstOrDefault().FirstName,
                                             ReportToContactNumber = rsysEntities.Persons.Where(x => x.ID == p.Requirement.PersonsID).FirstOrDefault().WorkMobile,
                                             CandidateMustBring = p.Requirement.MustBringText,
                                             StartDate = p.StartDate,
                                             StandardRate = p.StandardRate,
                                             OvertimeRate = p.OvertimeRate,
                                             WeekendRate = p.WeekendRate,
                                             IsCanceled = p.IsCanceled,
                                             ClientCompany = c.CompanyName,
                                             LastModifiedBy = rsysEntities.Persons.Where(x => x.ID == p.LastModifiedBy).FirstOrDefault().FirstName,
                                             LastModifiedOn = p.LastModifiedOn,
                                             CreatedOn = p.CreatedOn,
                                             Canceled = p.IsCanceled,
                                             PlacementObjectStored = p,
                                             CreatedBy = rsysEntities.Persons.Where(x => x.ID == p.CreatedBy).FirstOrDefault().FirstName,
                                             CompanyAddressLine1 = cs.Address1,
                                             CompanyAddressLine2 = cs.Address2,

                                             CompanyPostcode = cs.Postcode,

                                         }).First();

                  //Create candidate object 
                    var messageSender = new MessageSender();
                    var candidateMessage = new MessageSender.CandidateMessage();

                    candidateMessage.CandidateName = pl.FirstName;
                    candidateMessage.CandidateNumber = "+447958656944";
                    candidateMessage.CompanyName = pl.ClientCompany;
                    candidateMessage.CompanyAddressLine1 = pl.CompanyAddressLine1;
                    candidateMessage.CompanyAddressLine2 = pl.CompanyAddressLine2;
                    //  candidateMessage.CompanyAddressLine3 = "Address line 3";
                    candidateMessage.ReportToName = pl.ReportTo;
                    candidateMessage.ReportToContactNumber = pl.ReportToContactNumber;
                    candidateMessage.Start = new DateTime(dtStartDate.Value.Year, dtStartDate.Value.Month, dtStartDate.Value.Day, dtStartTime.Value.Hour, dtStartTime.Value.Minute, 0);
                    candidateMessage.MustBring = pl.CandidateMustBring;
                    candidateMessage.TextMessageSigniture = "Thanks AJK Resources LTD";

                    var msgResponse = messageSender.SendMessage(candidateMessage);

                    if (msgResponse.Success)
                    {
                        MessageBox.Show("Your message has been sent to the candidate", "Message Sent",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(
                            "There was an error sending sending your message: please provide this error code to the system administrator: " + msgResponse.Response, "Error sending message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    Functions.LogError(ex);
                    //Messages.Error(ex.Message);
                    throw;
                }
            }
        }
    }
}
