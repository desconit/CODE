using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using System.Linq;

namespace RSys
{
    public partial class frmWeeklyPlan : DevExpress.XtraEditors.XtraForm
    {
        private bool isEditMode = false;
        private int Id = 0;
        private bool isDirty = false;
        private bool isAdmin = false;
        DateTime lastPlanCutOffDate;
        DateTime newPlanCutoffDate;

        public frmWeeklyPlan()
        {
            //if (!Program.clsuser.isAdmin)
            //if(true)
            //{
            //    Messages.Error("You don't have previliges to view this screen.");
            //}
            //{
            InitializeComponent();


            SecurityCheck();


            lastPlanCutOffDate = DateTime.Now.AddDays(-7);
            newPlanCutoffDate = DateTime.Now;
            try
            {
                //using (
                //{

                var rsysEntities = new RsysEntities1();

                try
                {
                    lastPlanCutOffDate =
                        (from p in rsysEntities.WeeklyPlans.Where(p => p.IsDeleted == false && p.CreatedByUserId == Program.clsuser.UserID) select p.CutOffDate).Max();
                }
                catch (Exception ex)
                {
                    Functions.LogError(ex);
                    Messages.Error(ex.Message);
                }
                finally
                {
                    newPlanCutoffDate = lastPlanCutOffDate.AddDays(7);

                    lblPlanDesc.Text = string.Format("{2} From: {0}, To {1}", lastPlanCutOffDate, newPlanCutoffDate, Program.clsuser.UserName);

                }

                //Look for any placements started after the cut off date 23:59
                //  DateTime nextDay 00:00 hrs 
                // DateTime nextDay = new DateTime(lastPlanCutOffDate.Year, lastPlanCutOffDate.Month, lastPlanCutOffDate.Day, 23, 59, 00, 00);
                // var newPlanCutoffDate = lastPlanCutOffDate.Date.AddDays(7);

                var pl = (from p in rsysEntities.Placements.Where(p => p.IsDeleted == false)
                          join c in rsysEntities.Companies on p.Requirement.CompaniesID equals c.ID

                          join cs in rsysEntities.CompanySites on p.Requirement.SitesID equals cs.ID
                          join pb in rsysEntities.PersonBackOffices on p.Person.ID equals pb.PersonsID

                          where p.StartDate > lastPlanCutOffDate && p.StartDate < newPlanCutoffDate && p.CreatedBy == Program.clsuser.UserID
                          select new WeeklyPlanRow()
                          {
                              PlacementID = p.PlacementId,
                              CandidateID = p.Person.ID,
                              CandidateFirstName = p.Person.FirstName,
                              CandidateSurname = p.Person.LastName,
                              CandidateName = p.Person.FirstName + " " + p.Person.LastName,

                              RequirmentId = p.Requirement.ID,
                              RequrimentRef = p.Requirement.Reference,
                              StartDate = p.StartDate,
                              StandardRate = p.StandardRate,
                              OvertimeRate = p.OvertimeRate,
                              WeekendRate = p.WeekendRate,
                              StandardRateCharge = p.StandardRateCharge,
                              OvertimeRateCharge = p.OvertimeRateCharge,
                              WeekendRateCharge = p.WeekendRateCharge,
                              Margin = 0,
                              IsDeleted = false,
                              ClientCompany = c.CompanyName,
                              Trade = rsysEntities.Trades.Where(t => t.ID == p.Requirement.JobTitlesID).
                                  FirstOrDefault().Name,

                              LastModifiedBy =
                                  rsysEntities.Persons.Where(x => x.ID == Program.clsuser.UserID).
                                  FirstOrDefault().FirstName,
                              LastModifiedByUserId = p.Person.ID,
                              LastModifiedOn = DateTime.Now,
                              CreatedOn = DateTime.Now,
                              CreatedBy = p.Person.FirstName + " " + p.Person.LastName,
                              CreatedByUserId = p.Person.ID,
                              Site =
                                  cs.Address1 + " " + Environment.NewLine + cs.Address2 +
                                  Environment.NewLine + cs.City + cs.Postcode,
                              PaymentType =
                                  rsysEntities.PaymentMethods.Where(pm => pm.ID == pb.PaymentMethodsID).
                                  FirstOrDefault().Name,
                              StandardHours = 0,
                              WeekendHours = 0,
                              OvertimeHours = 0


                          });


                grdMain.DataSource = pl.ToList<WeeklyPlanRow>();
                grdMain.RefreshDataSource();

                //}
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                throw;
            }
        }

        private void SecurityCheck()
        {
            if (Program.clsuser.UserName.ToLower() == "Noel Azebiah".ToLower() || Program.clsuser.UserName.ToLower() == "arthur kabalu".ToLower() || Program.clsuser.UserName.ToLower() == "ali Jhonson")
            {
                isAdmin = true;
                btnApprove.Enabled = true;
            }

            if (!isAdmin)
            {
                btnApprove.Enabled = false;
                btnApprove.ToolTip = "You must be a director to approve the weekly plan";
            }
        }

        // }

        // Provides data for the Total column.
        private void gridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            try
            {
                //if (e.Column.FieldName == "FormatedFullName" && e.IsGetData)
                //{ 
                //    var firstName = Convert.ToString(gvMain.GetListSourceRowCellValue(e.ListSourceRowIndex, "CandidateFirstName"));
                //  var surname = Convert.ToString(gvMain.GetListSourceRowCellValue(e.ListSourceRowIndex, "CandidateSurname"));

                //    e.Value = string.Format("{0} \r\n {1}", firstName, surname);
                //}

                if (e.Column.FieldName == "StandardRateMargin" && e.IsGetData)
                {
                    var standardCharge = Convert.ToDecimal(gvMain.GetListSourceRowCellValue(e.ListSourceRowIndex, "StandardRateCharge"));
                    var standardRate = Convert.ToDecimal(gvMain.GetListSourceRowCellValue(e.ListSourceRowIndex, "StandardRate"));

                    e.Value = (standardCharge - standardRate);
                    // getTotalValue(e.ListSourceRowIndex)
                }



                if (e.Column.FieldName == "TotalProfite" && e.IsGetData)
                {
                    var standardCharge = Convert.ToDecimal(gvMain.GetListSourceRowCellValue(e.ListSourceRowIndex, "StandardRateCharge"));
                    var standardRate = Convert.ToDecimal(gvMain.GetListSourceRowCellValue(e.ListSourceRowIndex, "StandardRate"));

                    var standardHours = Convert.ToDecimal(gvMain.GetListSourceRowCellValue(e.ListSourceRowIndex, "StandardHours"));


                    // OvertimeRate, OvertimeRateCharge
                    var OvertimeRateCharge = Convert.ToDecimal(gvMain.GetListSourceRowCellValue(e.ListSourceRowIndex, "OvertimeRateCharge"));
                    var OvertimeRate = Convert.ToDecimal(gvMain.GetListSourceRowCellValue(e.ListSourceRowIndex, "OvertimeRate"));

                    var overTimeHours = Convert.ToDecimal(gvMain.GetListSourceRowCellValue(e.ListSourceRowIndex, "OvertimeHours"));


                    //WeekendRate, WeekendRateCharge
                    var weekendRateCharge = Convert.ToDecimal(gvMain.GetListSourceRowCellValue(e.ListSourceRowIndex, "WeekendRateCharge"));
                    var weekendRate = Convert.ToDecimal(gvMain.GetListSourceRowCellValue(e.ListSourceRowIndex, "WeekendRate"));

                    var weekendHours = Convert.ToDecimal(gvMain.GetListSourceRowCellValue(e.ListSourceRowIndex, "WeekendHours"));

                    var standardProfit = ((standardCharge - standardRate) * standardHours);
                    var overtimeProfit = ((OvertimeRateCharge - OvertimeRate) * overTimeHours);
                    var weekendProfit = ((weekendRateCharge - weekendRate) * weekendHours);


                    e.Value = (standardProfit + overtimeProfit + weekendProfit);
                    // getTotalValue(e.ListSourceRowIndex)
                }
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                throw;
            }
        }

        private void btnSavePlan_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Are you sure you want to save the weekly plan?", "Confirm save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    var weeklyPlanRows = new List<WeeklyPlanRow>();
                    for (int i = 0; i < gvMain.RowCount; i++)
                    {
                        var weeklyPlanRow = gvMain.GetRow(i) as WeeklyPlanRow;

                        if (weeklyPlanRow != null)
                            weeklyPlanRows.Add(weeklyPlanRow);
                    }

                    BinaryFormatter bf = new BinaryFormatter();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        bf.Serialize(ms, weeklyPlanRows.ToList());
                        ms.GetBuffer();

                        using (var rsysEntities = new RsysEntities1())
                        {

                            if (isEditMode)
                            {
                                var weeklyPlan =
                                    (from p in rsysEntities.WeeklyPlans where p.Id == Id select p).FirstOrDefault();

                                weeklyPlan.LastModifiedDate = DateTime.Now;
                                weeklyPlan.LastModifiedByUser = Program.clsuser.UserName;
                                weeklyPlan.LastModifiedByUserId = Program.clsuser.UserID;

                                weeklyPlan.WeeklyPlanData = ms.ToArray();
                                rsysEntities.SaveChanges();

                                isDirty = true;

                                MessageBox.Show("Weekly Plan successfully updated", "Weekly Plan updated", MessageBoxButtons.OK, MessageBoxIcon.Information);


                            }
                            else
                            {
                                WeeklyPlan weeklyPlan = new WeeklyPlan();
                                weeklyPlan.CutOffDate = newPlanCutoffDate;

                                weeklyPlan.CreateByUser = Program.clsuser.UserName;
                                weeklyPlan.CreatedByUserId = Program.clsuser.UserID;
                                weeklyPlan.CreatedDate = DateTime.Now;
                                weeklyPlan.LastModifiedDate = DateTime.Now;
                                weeklyPlan.LastModifiedByUser = Program.clsuser.UserName;
                                weeklyPlan.LastModifiedByUserId = Program.clsuser.UserID;
                                weeklyPlan.IsDeleted = false;
                                weeklyPlan.StartDate = lastPlanCutOffDate;
                                weeklyPlan.Profit = 0;
                                weeklyPlan.WeeklyPlanData = ms.ToArray();
                                weeklyPlan.IsApproved = false;

                                rsysEntities.AddToWeeklyPlans(weeklyPlan);
                                rsysEntities.SaveChanges();

                                isDirty = true;
                                isEditMode = true;
                                Id = weeklyPlan.Id;
                                btnApprove.Enabled = true;

                                MessageBox.Show("Weekly Plan successfully created", "Weekly Plan Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }


                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                throw ;
            }
        }

        public void loadWeeklyPlan(int id)
        {
            isEditMode = true;

            Id = id;

            SecurityCheck();

            var rsysEntities = new RsysEntities1();

            var weeklyPlans = (from p in rsysEntities.WeeklyPlans.Where(p => p.IsDeleted == false && p.Id == id) select p).FirstOrDefault();

            lblPlanDesc.Text = string.Format("{2} From: {0}, To {1}", weeklyPlans.StartDate , weeklyPlans.CutOffDate, Program.clsuser.UserName);
            


            var items = weeklyPlans.WeeklyPlanData.ToArray();

            BinaryFormatter bf = new BinaryFormatter();
            List<WeeklyPlanRow> _list = new List<WeeklyPlanRow>();

            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(items, 0, items.Length);
                    ms.Position = 0;

                    _list = bf.Deserialize(ms) as List<WeeklyPlanRow>;
                }

               

                if (weeklyPlans.IsApproved)
                {

                    // this.grpMain.Enabled = false;
                    SetUpForm();
                }
                else
                {
                    //Get any placements open after the last modified date

                    var missingPlacements = GetMissingPlacements(rsysEntities, DateTime.Now.AddDays(-3), weeklyPlans.CutOffDate);

                    foreach (WeeklyPlanRow missingPlacement in missingPlacements)
                    {
                        var existingPlacement =
                            from pl in _list where pl.PlacementID == missingPlacement.PlacementID select pl;


                        if (existingPlacement.Count() < 1)
                        {
                            var placementToAdd = missingPlacement;
                            if (_list != null) _list.Add(placementToAdd);
                        }
                    }
                }

                grdMain.DataSource = _list;
                grdMain.RefreshDataSource();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                throw;
            }
        }

        private void SetUpForm()
        {
            btnSavePlan.Enabled = false;
            btnUnlock.Enabled = true;
            btnApprove.Enabled = false;
            btnClose.Enabled = true;


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rsysEntities"></param>
        /// <returns></returns>
        private IQueryable<WeeklyPlanRow> GetMissingPlacements(RsysEntities1 rsysEntities, DateTime lastModifiedDate, DateTime planCutOffDate)
        {
            return (from p in rsysEntities.Placements.Where(p => p.IsDeleted == false)
                    join c in rsysEntities.Companies on p.Requirement.CompaniesID equals c.ID

                    join cs in rsysEntities.CompanySites on p.Requirement.SitesID equals cs.ID
                    join pb in rsysEntities.PersonBackOffices on p.Person.ID equals pb.PersonsID

                    where p.StartDate > lastModifiedDate && p.StartDate < planCutOffDate && p.CreatedBy == Program.clsuser.UserID
                    select new WeeklyPlanRow()
                    {
                        PlacementID = p.PlacementId,
                        CandidateID = p.Person.ID,
                        CandidateFirstName = p.Person.FirstName,
                        CandidateSurname = p.Person.LastName,
                        CandidateName = p.Person.FirstName + " " + p.Person.LastName,

                        RequirmentId = p.Requirement.ID,
                        RequrimentRef = p.Requirement.Reference,
                        StartDate = p.StartDate,
                        StandardRate = p.StandardRate,
                        OvertimeRate = p.OvertimeRate,
                        WeekendRate = p.WeekendRate,
                        StandardRateCharge = p.StandardRateCharge,
                        OvertimeRateCharge = p.OvertimeRateCharge,
                        WeekendRateCharge = p.WeekendRateCharge,
                        Margin = 0,
                        IsDeleted = false,
                        ClientCompany = c.CompanyName,
                        Trade = rsysEntities.Trades.Where(t => t.ID == p.Requirement.JobTitlesID).
                            FirstOrDefault().Name,

                        LastModifiedBy =
                            rsysEntities.Persons.Where(x => x.ID == Program.clsuser.UserID).
                            FirstOrDefault().FirstName,
                        LastModifiedByUserId = p.Person.ID,
                        LastModifiedOn = DateTime.Now,
                        CreatedOn = DateTime.Now,
                        CreatedBy = p.Person.FirstName + " " + p.Person.LastName,
                        CreatedByUserId = p.Person.ID,
                        Site =
                            cs.Address1 + " " + Environment.NewLine + cs.Address2 +
                            Environment.NewLine + cs.City + cs.Postcode,
                        PaymentType =
                            rsysEntities.PaymentMethods.Where(pm => pm.ID == pb.PaymentMethodsID).
                            FirstOrDefault().Name,
                        StandardHours = 0,
                        WeekendHours = 0,
                        OvertimeHours = 0


                    });
        }


        private void frmWeeklyPlan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isDirty)
                DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.Cancel;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {

            if (
                MessageBox.Show("Are you sure you want to appove the weekly plan?", "Confirm Approval",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (isEditMode || isDirty)
                {
                    using (var rsysEntities = new RsysEntities1())
                    {

                        var weeklyPlan =
                            (from p in rsysEntities.WeeklyPlans where p.Id == Id select p).FirstOrDefault();

                        weeklyPlan.ApprovedByUser = Program.clsuser.UserName;
                        weeklyPlan.IsApprovedByUserId = Program.clsuser.UserID;
                        weeklyPlan.IsApproved = weeklyPlan.IsApproved ? false : true;


                        isDirty = true;

                        btnSavePlan.Enabled = false;
                        btnApprove.Enabled = false;
                        btnClose.Text = "Close";

                        MessageBox.Show("Weekly Plan successfully approved", "Weekly Plan Approved",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);



                        //Now rollover the plans that are set to roll


                        WeeklyPlan weeklyPlans = (from p in rsysEntities.WeeklyPlans.Where(p => p.IsDeleted == false && p.Id == Id) select p).FirstOrDefault();

                        var items = weeklyPlans.WeeklyPlanData.ToArray();

                        BinaryFormatter bf = new BinaryFormatter();
                        List<WeeklyPlanRow> _list = new List<WeeklyPlanRow>();
                        List<WeeklyPlanRow> rowsToRollover = new List<WeeklyPlanRow>();

                        try
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                ms.Write(items, 0, items.Length);
                                ms.Position = 0;

                                _list = bf.Deserialize(ms) as List<WeeklyPlanRow>;
                            }


                           foreach (WeeklyPlanRow weeklyPlanRow in _list)
                            {
                                if (weeklyPlanRow.Rollover)
                                {
                                    rowsToRollover.Add(weeklyPlanRow);

                                    var newStartDate = weeklyPlanRow.StartDate.AddDays(7);

                                    Placement placement = ConvertWeekToWeeklyPlanObject(weeklyPlanRow, newStartDate);
                                    placement.Person =
                                        (from p in rsysEntities.Persons.Where(p => p.ID == weeklyPlanRow.CandidateID)
                                         select p).FirstOrDefault();
                                    placement.Requirement =
                                        (from r in
                                             rsysEntities.Requirements.Where(p => p.ID == weeklyPlanRow.RequirmentId)
                                         select r).FirstOrDefault();

                                    rsysEntities.AddToPlacements(placement);

                                }

                            }

                            rsysEntities.SaveChanges();

                            btnApprove.Enabled = false;
                            btnUnlock.Enabled = true;


                        }
                        catch (Exception ex)
                        {
                            Functions.LogError(ex);
                            throw;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You must save the plan before approving it.", "Plan not saved",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
            }
        }

        private Placement ConvertWeekToWeeklyPlanObject(WeeklyPlanRow wp, DateTime startDate)
        {
            Placement placement = new Placement();

            // placement.PlacementId = wp.PlacementID;
            placement.StartDate = startDate;
            placement.IsDeleted = false;
            placement.IsCanceled = false;
            placement.StandardRate = wp.StandardRate;
            placement.OvertimeRate = wp.OvertimeRate;
            placement.WeekendRate = wp.WeekendRate;
            placement.StandardRateCharge = wp.StandardRateCharge;
            placement.OvertimeRateCharge = wp.OvertimeRateCharge;
            placement.WeekendRateCharge = wp.WeekendRateCharge;
            placement.EndDate = startDate.AddDays(7);
            placement.CreatedBy = Program.clsuser.UserID;
            placement.CreatedOn = DateTime.Now;
            placement.LastModifiedOn = DateTime.Now;
            placement.LastModifiedBy = Program.clsuser.UserID;

            return placement;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (
               MessageBox.Show("Are you sure you want to unlock the weekly plan?", "Confirm Unlock",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var rsysEntities = new RsysEntities1())
                {

                    var weeklyPlan =
                        (from p in rsysEntities.WeeklyPlans where p.Id == Id select p).FirstOrDefault();

                    weeklyPlan.ApprovedByUser = Program.clsuser.UserName;
                    weeklyPlan.IsApprovedByUserId = Program.clsuser.UserID;
                    weeklyPlan.IsApproved = false;
                    
                    isDirty = true;

                    btnSavePlan.Enabled = true;
                    btnApprove.Enabled = true;
                    btnClose.Text = "Close";

                    rsysEntities.SaveChanges();

                    MessageBox.Show("Weekly Plan successfully unlocked", "Weekly Plan unlocked",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    btnUnlock.Enabled = false;

                    
                }

                loadWeeklyPlan(Id);
            }
        }

    }
}

