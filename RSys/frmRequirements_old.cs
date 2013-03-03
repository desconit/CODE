using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using System.Collections;
using DevExpress.XtraCharts;
using DESCONIT.BLL;
using System.Linq;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using RSys.Placements;

namespace RSys
{
    public partial class frmRequirements : DevExpress.XtraEditors.XtraForm
    {
        BLL bll = new BLL(Tables.Requirements, Program.clsuser.CurrentDB);
        bool isEdit;
        DataSet dsMain;
        int? ID = null;
        DataTable dt = new DataTable();
        bool isCalledFromContact = false;
        ucAttachment ucAttach;

        public frmRequirements()
        {
            InitializeComponent();
            dtEarliestStart.DateTime = DateTime.Now;
            dsMain = bll.GetByID(-1);
            SetTableNames();
            AddAttachmentCtrl();
            RefreshData();
            SendKeys.Send("{TAB}");

            SetUpPage();
        }

        public frmRequirements(int ID)
        {
            InitializeComponent();
            dtEarliestStart.DateTime = DateTime.Now;
            dsMain = bll.GetByID(-1);
            SetTableNames();
            AddAttachmentCtrl();
            AddAttachmentCtrl();
            RefreshData();
            this.ID = ID;
            SendKeys.Send("{TAB}");

            SetUpPage();
        }

        public frmRequirements(bool isCalledFromContact)
        {
            InitializeComponent();
            dsMain = bll.GetByID(-1);
            SetTableNames();
            AddAttachmentCtrl();
            RefreshData();
            this.isCalledFromContact = isCalledFromContact;
            btnSaveNClear.Visible = false;
            luCode.Properties.Buttons.RemoveAt(0);
            btnSave.Text = "Save && Close";
            SendKeys.Send("{TAB}");

            SetUpPage();
        }

        private void SetUpPage()
        {
            this.gvShortList.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gvShortList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseMove);
            this.gvShortList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseDown);
            this.gvShortList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseUp);
            this.gvShortList.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gvMain.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grdView_RowStyle);

            GetAllReqPlacements();


        }

        private void AddAttachmentCtrl()
        {
            ucAttach = new ucAttachment(dsMain.Tables[Tables.Attachments], Screens.frmRequirements, ScreensNames.frmRequirements);
            ucAttach.Location = new Point(0, 0);
            ucAttach.Show();
            ucAttach.Dock = DockStyle.Fill;
            tpAttachments.Controls.Add(ucAttach);


        }

        private void SetTableNames()
        {
            dsMain.Tables[0].TableName = Tables.Requirements;
            dsMain.Tables[1].TableName = Tables.ExistingData;
            dsMain.Tables[2].TableName = Tables.RequirementTypes;
            dsMain.Tables[3].TableName = Tables.Companies;
            dsMain.Tables[4].TableName = Tables.Persons;
            dsMain.Tables[5].TableName = Tables.CompanySites;
            dsMain.Tables[6].TableName = Tables.JobStatuses;
            dsMain.Tables[7].TableName = Tables.JobTitles;
            dsMain.Tables[8].TableName = Tables.Contracts;
            dsMain.Tables[9].TableName = Tables.Attachments;
            dsMain.Tables[10].TableName = Tables.RateTypes;
            dsMain.Tables[11].TableName = Tables.RateFrequencies;
            dsMain.Tables[12].TableName = Tables.ShortlistContacts;
            dsMain.Tables[13].TableName = "Contacts";
            dsMain.Tables[14].TableName = Tables.RequirementTickets;
            dsMain.Tables[15].TableName = Tables.Tickets;



            DataRelation relation = new DataRelation("relContract", dsMain.Tables[Tables.Requirements].Columns[Requirements.ID], dsMain.Tables[Tables.Contracts].Columns[Contracts.RequirementsID], false);
            dsMain.Relations.Add(relation);


            relation = new DataRelation("relShortList", dsMain.Tables[Tables.Requirements].Columns[Requirements.ID], dsMain.Tables[Tables.ShortlistContacts].Columns[Contracts.RequirementsID], false);
            dsMain.Relations.Add(relation);


            relation = new DataRelation("relTickets", dsMain.Tables[Tables.Requirements].Columns[Requirements.ID], dsMain.Tables[Tables.RequirementTickets].Columns[RequirementTickets.RequirementsID], false);
            dsMain.Relations.Add(relation);

        }

        private void save()
        {

        }

        private void RefreshData()
        {
            luCode.Properties.ValueMember = Requirements.ID;
            luCode.Properties.DisplayMember = Requirements.Reference;
            luCode.Properties.DataSource = dsMain.Tables[Tables.ExistingData];



            luType.Properties.ValueMember = RequirementTypes.ID;
            luType.Properties.DisplayMember = RequirementTypes.Name;
            luType.Properties.DataSource = dsMain.Tables[Tables.RequirementTypes];


            luStatus.Properties.ValueMember = JobStatuses.ID;
            luStatus.Properties.DisplayMember = JobStatuses.Name;
            luStatus.Properties.DataSource = dsMain.Tables[Tables.JobStatuses];

            luJobTitle.Properties.ValueMember = JobTitles.ID;
            luJobTitle.Properties.DisplayMember = JobTitles.Name;
            luJobTitle.Properties.DataSource = dsMain.Tables[Tables.JobTitles];


            rluRateFrequency.Properties.ValueMember = RateFrequencies.ID;
            rluRateFrequency.Properties.DisplayMember = RateFrequencies.Name;
            rluRateFrequency.Properties.DataSource = dsMain.Tables[Tables.RateFrequencies];

            rluRateType.Properties.ValueMember = RateTypes.ID;
            rluRateType.Properties.DisplayMember = RateTypes.Name;
            rluRateType.Properties.DataSource = dsMain.Tables[Tables.RateTypes];

            luPersons.Properties.ValueMember = Persons.ID;
            luPersons.Properties.DisplayMember = Persons.FullName;
            luPersons.Properties.DataSource = dsMain.Tables[Tables.Persons];


            luCompany.Properties.ValueMember = Companies.ID;
            luCompany.Properties.DisplayMember = Companies.CompanyName;
            luCompany.Properties.DataSource = dsMain.Tables[Tables.Companies];

            luSite.Properties.ValueMember = CompanySites.ID;
            luSite.Properties.DisplayMember = CompanySites.Name;
            luSite.Properties.DataSource = dsMain.Tables[Tables.CompanySites];

            rluShortList.Properties.ValueMember = Persons.ID;
            rluShortList.Properties.DisplayMember = Persons.FullName;
            rluShortList.Properties.DataSource = dsMain.Tables["Contacts"];


            ucAttach.RefreshDataSource(dsMain.Tables[Tables.Attachments]);

            grdContract.DataSource = dsMain.Tables[Tables.Contracts];
            grdContract.RefreshDataSource();

            grdShortList.DataSource = dsMain.Tables[Tables.ShortlistContacts];
            grdShortList.RefreshDataSource();

            //set up requirment tickets
            if (dsMain.Tables[Tables.Contracts].Rows.Count == 0)
            {
                var standardContractRow = dsMain.Tables[Tables.Contracts].NewRow();
                standardContractRow[Contracts.RequirementsID] = 0;
                standardContractRow[Contracts.RateTypesID] = 1;
                standardContractRow[Contracts.RateFrequenciesID] = 3;
                standardContractRow[Contracts.PayRate] = 0;
                standardContractRow[Contracts.ChargeRate] = 0;

                standardContractRow[Contracts.Note] = string.Empty;
                standardContractRow[Contracts.LastModifiedOn] = DateTime.Now;
                standardContractRow[Contracts.LastModifiedBy] = Program.clsuser.UserID;
                standardContractRow[Contracts.CreatedOn] = DateTime.Now;
                standardContractRow[Contracts.CreatedBy] = Program.clsuser.UserID;
                standardContractRow[Contracts.isActive] = true;


                var overtimeContractRow = dsMain.Tables[Tables.Contracts].NewRow();
                overtimeContractRow[Contracts.RequirementsID] = 0;
                overtimeContractRow[Contracts.RateTypesID] = 2;
                overtimeContractRow[Contracts.RateFrequenciesID] = 3;
                overtimeContractRow[Contracts.PayRate] = 0;
                overtimeContractRow[Contracts.ChargeRate] = 0;

                overtimeContractRow[Contracts.Note] = string.Empty;
                overtimeContractRow[Contracts.LastModifiedOn] = DateTime.Now;
                overtimeContractRow[Contracts.LastModifiedBy] = Program.clsuser.UserID;
                overtimeContractRow[Contracts.CreatedOn] = DateTime.Now;
                overtimeContractRow[Contracts.CreatedBy] = Program.clsuser.UserID;
                overtimeContractRow[Contracts.isActive] = true;


                var weekendContractRow = dsMain.Tables[Tables.Contracts].NewRow();
                weekendContractRow[Contracts.RequirementsID] = 0;
                weekendContractRow[Contracts.RateTypesID] = 4;
                weekendContractRow[Contracts.RateFrequenciesID] = 3;
                weekendContractRow[Contracts.PayRate] = 0;
                weekendContractRow[Contracts.ChargeRate] = 0;

                weekendContractRow[Contracts.Note] = string.Empty;
                weekendContractRow[Contracts.LastModifiedOn] = DateTime.Now;
                weekendContractRow[Contracts.LastModifiedBy] = Program.clsuser.UserID;
                weekendContractRow[Contracts.CreatedOn] = DateTime.Now;
                weekendContractRow[Contracts.CreatedBy] = Program.clsuser.UserID;
                weekendContractRow[Contracts.isActive] = true;


                //Add rates to dataset 
                dsMain.Tables[Tables.Contracts].Rows.Add(standardContractRow);
                dsMain.Tables[Tables.Contracts].Rows.Add(overtimeContractRow);
                dsMain.Tables[Tables.Contracts].Rows.Add(weekendContractRow);


                // standardContractRow[Contracts.]

            }

            grdTickets.DataSource = dsMain.Tables[Tables.RequirementTickets];
            grdTickets.RefreshDataSource();

            rluCategory.DataSource = dsMain.Tables[Tables.Tickets];
            rluCategory.ValueMember = Tickets.ID;
            rluCategory.DisplayMember = Tickets.Name;
        }

        private void ClearFields()
        {
            try
            {
                Err.ClearErrors();

                luType.EditValue = null;
                luCompany.EditValue = null;
                luPersons.EditValue = null;


                txtAddress1.Text = string.Empty;
                txtAddress2.Text = string.Empty;
                txtCity.Text = string.Empty;
                txtPostCode.Text = string.Empty;
                txtWorkEmail.Text = string.Empty;
                txtWorkTel.Text = string.Empty;

                luStatus.EditValue = null;
                luJobTitle.EditValue = null;
                dtEarliestStart.Text = string.Empty;
                luSite.EditValue = null;
                txtComments.EditValue = null;

                txtSiteAddress1.Text = string.Empty;
                txtSiteAddress2.Text = string.Empty;
                txtSiteCity.Text = string.Empty;
                txtSitePostcode.Text = string.Empty;

                txtNoRequired.EditValue = 0;
                txtDaysPerWeek.EditValue = 0;
                txtHourPerDay.EditValue = 0;
                txtDurtionPerWeek.EditValue = 0;

                lblEntry.Text = "New Entry";
                btnDelete.Enabled = false;
                luCode.Properties.Buttons[0].Caption = "";
                lblReference.Text = string.Empty;

                //grdContract.DataSource = null;


                isEdit = false;
            }
            catch (Exception ex)
            {
                Messages.Error(ex.Message);
            }
            finally
            {
            }
        }

        private void GetByID()
        {
            Hashtable ht = new Hashtable();
            ht.Add(Requirements.ID, Convert.ToInt32(luCode.EditValue));
            ht.Add(DiaryActions.CreatedBy, Program.clsuser.UserID);
            dsMain = bll.ExecuteSP("usp_" + Tables.Requirements + "GetByID", ht);

            //dsMain = bll.GetByID(Convert.ToInt32(luCode.EditValue));
            SetTableNames();

            RefreshData();
        }
        private void BindFields()
        {
            try
            {

                luType.EditValue = dsMain.Tables[Tables.Requirements].Rows[0][Requirements.RequirementTypesID];
                luCompany.EditValue = dsMain.Tables[Tables.Requirements].Rows[0][Requirements.CompaniesID];
                luPersons.EditValue = dsMain.Tables[Tables.Requirements].Rows[0][Requirements.PersonsID];




                luStatus.EditValue = dsMain.Tables[Tables.Requirements].Rows[0][Requirements.JobStatusesID];
                luJobTitle.EditValue = dsMain.Tables[Tables.Requirements].Rows[0][Requirements.JobTitlesID];
                dtEarliestStart.EditValue = dsMain.Tables[Tables.Requirements].Rows[0][Requirements.EarliestStart];
                luSite.EditValue = dsMain.Tables[Tables.Requirements].Rows[0][Requirements.SitesID];
                txtComments.EditValue = dsMain.Tables[Tables.Requirements].Rows[0][Requirements.Comments];



                txtNoRequired.EditValue = dsMain.Tables[Tables.Requirements].Rows[0][Requirements.NoRequired];
                txtDaysPerWeek.EditValue = dsMain.Tables[Tables.Requirements].Rows[0][Requirements.DaysPerWeek];
                txtHourPerDay.EditValue = dsMain.Tables[Tables.Requirements].Rows[0][Requirements.HoursPerDay];
                txtDurtionPerWeek.EditValue = dsMain.Tables[Tables.Requirements].Rows[0][Requirements.DurationInWeeks];
                txtMustBring.EditValue = dsMain.Tables[Tables.Requirements].Rows[0][Requirements.MustBringText];


                chkJobOnWeb.Checked = Convert.ToBoolean(dsMain.Tables[Tables.Requirements].Rows[0][Requirements.DisplayJobOnWeb]);


                ucAttach.RefreshDataSource(dsMain.Tables[Tables.Attachments]);
                grdContract.DataSource = dsMain.Tables[Tables.Contracts];
                grdContract.RefreshDataSource();

                grdShortList.DataSource = dsMain.Tables[Tables.ShortlistContacts];
                grdShortList.RefreshDataSource();




                //grdTickets.DataSource = dsMain.Tables[Tables.RequirementTickets];
                //grdTickets.RefreshDataSource();

                luCode.Properties.Buttons[0].Caption = luCode.Text;
                lblReference.Text = luCode.Text;
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                Messages.Error(ex.Message);
            }
        }

        private void luCode_EditValueChanged(System.Object sender, System.EventArgs e)
        {
            //ClearFields();
            try
            {
                if (Convert.ToInt32(luCode.EditValue) == -1 || luCode.EditValue == null)
                {
                    lblEntry.Text = "New Entry";
                    isEdit = false;
                    //luCode.Text = dsMain.Tables[Tables.ExistingData].Rows[dsMain.Tables[Tables.ExistingData].Rows.Count - 1][Requirements.CompanyName].ToString();
                    //luCode.EditValue = -1;
                    isEdit = false;
                    return;
                }




                if (luCode.EditValue == null | object.ReferenceEquals(luCode.EditValue, DBNull.Value))
                {
                    isEdit = false;
                    luCode.Properties.Buttons[0].Caption = "";
                    lblReference.Text = string.Empty;
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

                if (dsMain.Tables[Tables.Requirements].Rows.Count == 0)
                    dsMain.Tables[Tables.Requirements].Rows.Add(dsMain.Tables[Tables.Requirements].NewRow());

                dsMain.Tables[Tables.Requirements].Rows[0][Requirements.RequirementTypesID] = luType.EditValue;
                dsMain.Tables[Tables.Requirements].Rows[0][Requirements.CompaniesID] = luCompany.EditValue;
                dsMain.Tables[Tables.Requirements].Rows[0][Requirements.PersonsID] = luPersons.EditValue;

                dsMain.Tables[Tables.Requirements].Rows[0][Requirements.JobStatusesID] = luStatus.EditValue;
                dsMain.Tables[Tables.Requirements].Rows[0][Requirements.JobTitlesID] = -1;
                dsMain.Tables[Tables.Requirements].Rows[0][Requirements.EarliestStart] = dtEarliestStart.EditValue;
                dsMain.Tables[Tables.Requirements].Rows[0][Requirements.SitesID] = luSite.EditValue;
                dsMain.Tables[Tables.Requirements].Rows[0][Requirements.Comments] = txtComments.EditValue;

                dsMain.Tables[Tables.Requirements].Rows[0][Requirements.NoRequired] = txtNoRequired.EditValue;
                dsMain.Tables[Tables.Requirements].Rows[0][Requirements.DaysPerWeek] = txtDaysPerWeek.EditValue;
                dsMain.Tables[Tables.Requirements].Rows[0][Requirements.HoursPerDay] = txtHourPerDay.EditValue;
                dsMain.Tables[Tables.Requirements].Rows[0][Requirements.DurationInWeeks] = txtDurtionPerWeek.EditValue;
                dsMain.Tables[Tables.Requirements].Rows[0][Requirements.DisplayJobOnWeb] = chkJobOnWeb.Checked;
                dsMain.Tables[Tables.Requirements].Rows[0][Requirements.MustBringText] = txtMustBring.EditValue;


                var jobTitleText = string.Empty;
                foreach (DataRow t in dsMain.Tables[Tables.RequirementTickets].Rows)
                {
                    DataRow ticketRow = t;

                    var ticketName = (from myRow in dsMain.Tables[Tables.Tickets].AsEnumerable()
                                      where myRow.Field<int>(Tickets.ID) == Convert.ToInt32(ticketRow[RequirementTickets.TicketsID])
                                      select myRow[Tickets.Name]).FirstOrDefault();

                    if (jobTitleText == string.Empty)
                        jobTitleText += ticketName;
                    else
                    {
                        jobTitleText += "," + ticketName;
                    }
                }

                dsMain.Tables[Tables.Requirements].Rows[0][Requirements.JobName] = jobTitleText;


                if (dsMain.Relations.Contains("relAttachment"))
                    dsMain.Relations.Remove("relAttachment");

                dsMain.Tables.Remove(Tables.Attachments);
                dsMain.Tables.Add(ucAttach.GetAttachmentTable().Copy());
                DataRelation relation = new DataRelation("relAttachment", dsMain.Tables[Tables.Requirements].Columns[Requirements.ID], dsMain.Tables[Tables.Attachments].Columns[Attachments.RecordID], false);
                dsMain.Relations.Add(relation);



                dsMain = bll.SaveComplex(dsMain, isEdit);



                ID = Convert.ToInt32(dsMain.Tables[0].Rows[0][Requirements.ID]);

                //if (isCalledFromContact)
                //{

                //    ((frmContacts)this.Owner).UpdateCompanyList(Convert.ToInt32(luCode.EditValue), luCode.Text, txtCompanyNo.Text, txtVATNo.Text);
                //    this.Close();
                //}
                //else
                //{
                //    ((frmRequirementsVW)(this.Owner)).RefreshData(Convert.ToInt32(luCode.EditValue));
                //    ((frmMain)(((frmRequirementsVW)(this.Owner)).MdiParent)).RefreshDiaryActions();
                //}
                return true;

            }
            catch (Exception ex)
            {
                Messages.Error(ex.Message);
                return false;
            }
            finally

            { }
        }


        private void UpdateView(int ID)
        {
            if (this.Owner.GetType() == typeof(frmRequirementsVW))
                ((frmRequirementsVW)(this.Owner)).RefreshData(ID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Save())
                    return;


                SetTableNames();
                RefreshData();

                if (luCode.EditValue == null || luCode.EditValue.ToString().Equals("-1"))
                    luCode.EditValue = dsMain.Tables[Tables.Requirements].Rows[0][Requirements.ID];

                RefreshData();
                BindFields();
                UpdateView(Convert.ToInt32(luCode.EditValue));
                lblEntry.Text = string.Empty;
                this.isEdit = true;
                btnDelete.Enabled = true;


            }
            catch (Exception ex)
            {
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



            double StandardChargeRate = (from c in dsMain.Tables[Tables.Contracts].AsEnumerable()
                                         where c.Field<int>(Contracts.RateTypesID) == 1
                                         select c.Field<double>(Contracts.ChargeRate)).FirstOrDefault();

            if (StandardChargeRate == 0)
            {
                MessageBox.Show("Please enter a standard charge rate for this requirment.", "No tickets selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                xtMain.SelectedTabPage = tpContract;
                tpContract.Show();
                xtMain.SelectedTabPage.BringToFront();

            }

            if (dsMain.Tables[Tables.RequirementTickets] == null || dsMain.Tables[Tables.RequirementTickets].Rows.Count < 1)
            {
                // Err.SetError(grdTickets, "Please choose one or more tickets that best describe this requirment");
                MessageBox.Show("Please choose one or more tickets that best describe this requirment", "No tickets selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                grdTickets.Focus();
                check = false;
            }

            if ((luSite.Text == string.Empty))
            {
                Err.SetError(luSite, "Select a site.");
                luSite.Focus();
                check = false;
            }

            else
            {
                Err.SetError(luSite, null);
            }

            Err.SetError(luJobTitle, null);

            if ((luStatus.Text == string.Empty))
            {
                Err.SetError(luStatus, "Select a status.");
                luStatus.Focus();
                check = false;
            }

            else
            {
                Err.SetError(luStatus, null);
            }


            if ((luPersons.Text == string.Empty))
            {
                Err.SetError(luPersons, "Select a contact.");
                luPersons.Focus();
                check = false;
            }

            else
            {
                Err.SetError(luPersons, null);
            }

            if ((luCompany.Text == string.Empty))
            {
                Err.SetError(luCompany, "Select a company.");
                luCompany.Focus();
                check = false;
            }

            else
            {
                Err.SetError(luCompany, null);
            }


            if ((luType.Text == string.Empty))
            {
                Err.SetError(luType, "Select a type.");
                luType.Focus();
                check = false;
            }

            else
            {
                Err.SetError(luType, null);
            }

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
                Messages.Error(ex.Message);
            }
            finally { }
        }

        private void btnSaveNClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Save())
                    return;
                SetTableNames();

                UpdateView(Convert.ToInt32(dsMain.Tables[Tables.Requirements].Rows[0][Requirements.ID]));

                dsMain = bll.GetByID(-1);
                SetTableNames();

                ClearFields();
                //luBranches.Focus();
                luCode.EditValue = null;

                RefreshData();
            }
            catch (Exception ex)
            {
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
                        // luCode.Properties.NullText = (string)e.DisplayValue;
                        // dr = dsMain.Tables[Tables.ExistingData].NewRow();
                        // dr["CompanyName"] = e.DisplayValue.ToString();
                        //// dr[ExistingData.ID] = e.DisplayValue.ToString(); ;
                        // dsMain.Tables[Tables.ExistingData].Rows.Add(dr);
                        //dsMain.Tables[Tables.ExistingData].AcceptChanges();

                        //luCode.DoValidate();

                        DataRow r = dsMain.Tables[Tables.ExistingData].Rows.Add(new object[] { });
                        r[luCode.Properties.DisplayMember] = e.DisplayValue.ToString();
                        r[luCode.Properties.ValueMember] = -1;
                        e.Handled = true;

                    }
                }
                else
                {
                    // ClearFields();
                    DataRow dr = dsMain.Tables[Tables.ExistingData].NewRow();
                    dr["CompanyName"] = e.DisplayValue.ToString();
                    //dr[ExistingData.ID] = e.DisplayValue.ToString(); ;
                    dsMain.Tables[Tables.ExistingData].Rows.Add(dr);
                }


                //isCalledFromProcessNewVal = true;
                //luCode.EditValue = -1;

                // e.Handled = true;
            }
            catch (Exception ex)
            {
                Messages.Error(ex.Message);
            }
            finally
            {
                //SetEditValuetoNewRec(); 
            }
        }

        private void SetEditValuetoNewRec()
        {
            if (isCalledFromProcessNewVal)
            {
                luCode.EditValue = -1;
                isCalledFromProcessNewVal = false;
            }
        }

        private void luCode_KeyDown(object sender, KeyEventArgs e)
        {
            //luCode.EditValue = null;
        }

        private void frmRequirements_Load(object sender, EventArgs e)
        {
            if (this.ID != null)
                luCode.EditValue = this.ID;
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
            //luCanType.Properties.DisplayMember = Requirements.CompanyName;
            //luCanType.Properties.ValueMember= Requirements.ID;

            // dt = dsMain.Tables[Tables.ExistingData];


            //luCanType.Properties.DataSource = dt;
            // luCanType.Properties.DisplayMember = Requirements.CompanyName;
            // luCanType.Properties.ValueMember = Requirements.ID;

            luCode.Properties.DataSource = dsMain.Tables[Tables.ExistingData];
            luCode.Properties.DisplayMember = Requirements.Reference;
            luCode.Properties.ValueMember = Requirements.ID;

            luCode.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
        }



        private void frmRequirements_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (isCalledFromContact && !luCode.EditValue.ToString().Equals("-1") && luCode.EditValue != null)

        }

        private void luCode_Leave(object sender, EventArgs e)
        {
            if (luCode.EditValue == null)
            {
                // ClearFields();
            }
            else
            {
                luCode_EditValueChanged(null, null);
            }
        }



        private void luCompany_EditValueChanged(object sender, EventArgs e)
        {

            Hashtable ht = new Hashtable();

            ht.Add(Companies.ID, luCompany.EditValue);
            DataSet ds = bll.ExecuteSP("usp_PersonsAndSitesGetByCompanyID", ht);

            ds.Tables[0].TableName = Tables.Persons;
            ds.Tables[1].TableName = Tables.CompanySites;
            ds.Tables[2].TableName = Tables.CompanyBackOffices;

            dsMain.Tables.Remove(Tables.Persons);
            dsMain.Tables.Remove(Tables.CompanySites);

            dsMain.Tables.Add(ds.Tables[Tables.Persons].Copy());
            dsMain.Tables.Add(ds.Tables[Tables.CompanySites].Copy());


            luPersons.Properties.ValueMember = Persons.ID;
            luPersons.Properties.DisplayMember = Persons.FullName;
            luPersons.Properties.DataSource = dsMain.Tables[Tables.Persons];

            luSite.Properties.ValueMember = CompanySites.ID;
            luSite.Properties.DisplayMember = CompanySites.Name;
            luSite.Properties.DataSource = dsMain.Tables[Tables.CompanySites];

            if (ds.Tables[Tables.CompanyBackOffices].Rows.Count > 0)
            {
                txtAddress1.Text = ds.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.Address1].ToString();
                txtAddress2.Text = ds.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.Address2].ToString();
                txtCity.Text = ds.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.City].ToString();
                txtPostCode.Text = ds.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.Postcode].ToString();
            }
            else
            {
                txtAddress1.Text = string.Empty;
                txtAddress2.Text = string.Empty;
                txtCity.Text = string.Empty;
                txtPostCode.Text = string.Empty;
            }
            luPersons.Refresh();
            luSite.Refresh();

            //if (luCompany.EditValue != null)
            //{
            //    DataRow[] drs = dsMain.Tables[Tables.Companies].Select(Companies.ID + " = " + luCompany.EditValue.ToString());

            //    if (drs.Length > 0)
            //    {
            //        txtAddress1.Text = drs[0][Companies.Address1].ToString();
            //        txtAddress2.Text = drs[0][Companies.Address2].ToString();
            //        txtCity.Text = drs[0][Companies.City].ToString();
            //        txtPostCode.Text = drs[0][Companies.Postcode].ToString();
            //    }


            //    drs = dsMain.Tables[Tables.Persons].Select(Persons.CompaniesID + " = " + luCompany.EditValue.ToString());

            //    for (int i = 0; i < dsMain.Tables[Tables.Persons].Rows.Count; i++)
            //    {
            //        if(!dsMain.Tables[Tables.Persons].Rows[i][Persons.CompaniesID].ToString().Equals(luCompany.EditValue.ToString()))
            //        {
            //            dsMain.Tables[Tables.Persons].Rows.RemoveAt(i);
            //            i--;
            //        }
            //        dsMain.Tables[Tables.Persons].AcceptChanges();
            //    }

            //    for (int i = 0; i < dsMain.Tables[Tables.CompanySites].Rows.Count; i++)
            //    {
            //        if(!dsMain.Tables[Tables.CompanySites].Rows[i][CompanySites.CompaniesID].ToString().Equals(luCompany.EditValue.ToString()))
            //        {
            //            dsMain.Tables[Tables.CompanySites].Rows.RemoveAt(i);
            //            i--;
            //        }
            //        dsMain.Tables[Tables.CompanySites].AcceptChanges();
            //    }




            //}
            //else
            //{

            //}
        }

        private void luPersons_EditValueChanged(object sender, EventArgs e)
        {

            if (luPersons.EditValue == null)
                return;

            DataRow[] drs = dsMain.Tables[Tables.Persons].Select(Persons.ID + " = " + luPersons.EditValue.ToString());


            if (drs.Length > 0)
            {
                txtWorkEmail.Text = drs[0][Persons.WorkEmail].ToString(); ;
                txtWorkTel.Text = drs[0][Persons.WorkTel].ToString(); ;
            }
            else
            {
                txtWorkEmail.Text = string.Empty;
                txtWorkTel.Text = string.Empty;

            }
        }

        private void luSite_EditValueChanged(object sender, EventArgs e)
        {

            if (luSite.EditValue == null)
                return;

            DataRow[] drs = dsMain.Tables[Tables.CompanySites].Select(CompanySites.ID + " = " + luSite.EditValue.ToString());

            if (drs.Length > 0)
            {
                txtSiteAddress1.Text = drs[0][CompanySites.Address1].ToString();
                txtSiteAddress2.Text = drs[0][CompanySites.Address2].ToString();
                txtSiteCity.Text = drs[0][CompanySites.City].ToString();
                txtSitePostcode.Text = drs[0][CompanySites.Postcode].ToString();
            }
            else
            {

            }
        }

        private void gvContract_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvContract.FocusedRowHandle < 0)
                return;

            double chargeRate = 0;

            double payRate = 0;

            try
            {
                chargeRate = Convert.ToDouble(gvContract.GetFocusedRowCellValue(cl_ChargeRate));

            }
            catch (Exception)
            {


            }

            try
            {
                payRate = Convert.ToDouble(gvContract.GetFocusedRowCellValue(cl_payRate));

            }
            catch (Exception)
            {


            }


            double profit = chargeRate - payRate;

            DataTable dt = new DataTable();
            dt.Columns.Add("ChargeRate", typeof(double));
            dt.Columns.Add("PayRate", typeof(double));
            dt.Columns.Add("Profit", typeof(double));

            dt.Rows.Add(dt.NewRow());

            dt.Rows[0][Contracts.PayRate] = payRate;
            dt.Rows[0][Contracts.ChargeRate] = chargeRate;
            dt.Rows[0]["Profit"] = profit;

            for (int i = 0; i < chartControl1.Series.Count; i++)
            {
                chartControl1.Series.RemoveAt(i);
                i--;
            }
            chartControl1.Series.Add(Contracts.ChargeRate, DevExpress.XtraCharts.ViewType.Bar);
            chartControl1.Series.Add(Contracts.PayRate, DevExpress.XtraCharts.ViewType.Bar);
            chartControl1.Series.Add("Profit", DevExpress.XtraCharts.ViewType.Bar);

            chartControl1.Series[0].Points.Add(new SeriesPoint(Contracts.ChargeRate, chargeRate));
            chartControl1.Series[1].Points.Add(new SeriesPoint(Contracts.PayRate, payRate));
            chartControl1.Series[2].Points.Add(new SeriesPoint("Profit", profit));



            //chartControl1.DataSource = dt;
            //chartControl1.RefreshData();

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

        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        //    string contactIDs = "-1";
        //    string ticketIDs = "-1";

        //    try
        //    {
        //        for (int i = 0; i < dsMain.Tables[Tables.RequirementTickets].Rows.Count; i++)
        //        {
        //            ticketIDs = ticketIDs + "," + dsMain.Tables[Tables.RequirementTickets].Rows[i][RequirementTickets.TicketsID].ToString();
        //        }

        //        for (int i = 0; i < dsMain.Tables[Tables.ShortlistContacts].Rows.Count; i++)
        //        {
        //            contactIDs = contactIDs + "," + dsMain.Tables[Tables.ShortlistContacts].Rows[i][ShortlistContacts.PersonsID].ToString();
        //        }

        //        contactIDs = "(" + contactIDs + ")";
        //        ticketIDs = "(" + ticketIDs + ")";

        //        frmRequirementSearch frm = new frmRequirementSearch(ticketIDs, contactIDs, TODO);
        //        frm.StartPosition = FormStartPosition.CenterScreen;
        //        frm.ShowDialog();

        //        if (frm.isCancel || frm.ds == null)
        //        {
        //            frm.Close();
        //            return;

        //        }



        //        for (int i = 0; i < frm.ds.Tables[0].Rows.Count; i++)
        //        {
        //            if (Convert.ToBoolean(frm.ds.Tables[0].Rows[i]["Select"]))
        //            {
        //                dsMain.Tables[Tables.ShortlistContacts].Rows.Add(dsMain.Tables[Tables.ShortlistContacts].NewRow());
        //                dsMain.Tables[Tables.ShortlistContacts].Rows[dsMain.Tables[Tables.ShortlistContacts].Rows.Count - 1][ShortlistContacts.PersonsID] = frm.ds.Tables[0].Rows[i][Persons.ID];
        //            }
        //        }

        //        grdShortList.RefreshDataSource();
        //    }
        //    catch (Exception ex)
        //    {
        //        Messages.Error(ex.Message);
        //    }
        //    finally
        //    {

        //    }

        //}

        private void gvShortList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (ID.HasValue == false)
                    throw new Exception("No requirment id set up on the form");

                if (gvShortList.FocusedRowHandle < 0 || ID.HasValue == false)
                    return;

                int candidteID = Convert.ToInt32(gvShortList.GetRowCellValue(gvShortList.FocusedRowHandle, ShortlistContacts.PersonsID));

                frmPlacement frmPlacement = new frmPlacement(true, candidteID, ID.Value);
                frmPlacement.Owner = this;

                frmPlacement.StartPosition = FormStartPosition.CenterScreen;
                frmPlacement.ShowDialog();

                if (frmPlacement.DialogResult == DialogResult.OK)
                {

                    frmPlacement.Dispose();

                    //
                    GetAllReqPlacements();

                    xtMain.SelectedTabPage = tpPlacements;
                    tpPlacements.Show();
                    xtMain.SelectedTabPage.BringToFront();
                }
                else
                {
                    frmPlacement.Dispose();
                }

            }
            catch (Exception ex)
            {
                Messages.Error(ex.Message);
            }
            finally
            {
            }
        }

        private void btnClientAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int? lookUpCompanyValue = null;

                if (luCompany.EditValue != null)
                    lookUpCompanyValue = Convert.ToInt32(luCompany.EditValue);


                frmCompanies frm = new frmCompanies(true, lookUpCompanyValue);
                frm.Owner = this;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();

                if (!frm.luCode.Text.ToString().Trim().Equals(string.Empty))
                    UpdateCompanyList(Convert.ToInt32(frm.luCode.EditValue), frm.luCode.Text);
                frm.Close();

            }
            catch (Exception ex)
            {
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        public void UpdateCompanyList(int CompanyID, string CompanyName)
        {
            dsMain.Tables[Tables.Companies].Rows.Add(dsMain.Tables[Tables.Companies].NewRow());

            dsMain.Tables[Tables.Companies].Rows[dsMain.Tables[Tables.Companies].Rows.Count - 1][Companies.ID] = CompanyID;
            dsMain.Tables[Tables.Companies].Rows[dsMain.Tables[Tables.Companies].Rows.Count - 1][Companies.CompanyName] = CompanyName;
            dsMain.AcceptChanges();

            luCompany.EditValue = CompanyID;

        }

        private void btnContactAdd_Click(object sender, EventArgs e)
        {
            if (luCompany.Text.Equals(string.Empty))
            {
                Messages.Information("First, select a company.");
                return;
            }


            frmContacts frm = new frmContacts(true, Convert.ToInt32(luCompany.EditValue));
            frm.Owner = this;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if (!luCode.Text.Equals(string.Empty))
                UpdateContactList(Convert.ToInt32(frm.luCode.EditValue), frm.luCode.Text.ToString());
            frm.Close();
        }

        public void UpdateContactList(int ContactID, string ContactName)
        {
            dsMain.Tables[Tables.Persons].Rows.Add(dsMain.Tables[Tables.Persons].NewRow());

            dsMain.Tables[Tables.Persons].Rows[dsMain.Tables[Tables.Persons].Rows.Count - 1][Persons.ID] = ContactID;
            dsMain.Tables[Tables.Persons].Rows[dsMain.Tables[Tables.Persons].Rows.Count - 1][Persons.FullName] = ContactName;
            dsMain.Tables[Tables.Persons].AcceptChanges();

            luPersons.EditValue = ContactID;

        }

        private void btnSiteAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (luCompany.Text.Equals(string.Empty))
                {
                    Messages.Information("Please select a company before selecting a site.");
                    return;
                }


                frmCompanies frm = new frmCompanies(true, Convert.ToInt32(luCompany.EditValue));
                frm.Owner = this;
                frm.xtMain.SelectedTabPage = frm.tpSites;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();



                for (int i = 0; i < frm.gvSites.RowCount; i++)
                {
                    int SiteID = Convert.ToInt32(frm.gvSites.GetRowCellValue(i, CompanySites.ID));

                    DataRow[] drs = dsMain.Tables[Tables.CompanySites].Select(CompanySites.ID + " = " + SiteID.ToString());

                    if (drs.Length == 0)
                    {
                        dsMain.Tables[Tables.CompanySites].Rows.Add(dsMain.Tables[Tables.CompanySites].NewRow());

                        dsMain.Tables[Tables.CompanySites].Rows[dsMain.Tables[Tables.CompanySites].Rows.Count - 1][CompanySites.ID] = SiteID;
                        dsMain.Tables[Tables.CompanySites].Rows[dsMain.Tables[Tables.CompanySites].Rows.Count - 1][CompanySites.Name] = frm.gvSites.GetRowCellValue(i, CompanySites.Name);
                        dsMain.Tables[Tables.CompanySites].Rows[dsMain.Tables[Tables.CompanySites].Rows.Count - 1][CompanySites.Address1] = frm.gvSites.GetRowCellValue(i, CompanySites.Address1);
                        dsMain.Tables[Tables.CompanySites].Rows[dsMain.Tables[Tables.CompanySites].Rows.Count - 1][CompanySites.Address2] = frm.gvSites.GetRowCellValue(i, CompanySites.Address2);
                        dsMain.Tables[Tables.CompanySites].Rows[dsMain.Tables[Tables.CompanySites].Rows.Count - 1][CompanySites.City] = frm.gvSites.GetRowCellValue(i, CompanySites.City);
                        dsMain.Tables[Tables.CompanySites].Rows[dsMain.Tables[Tables.CompanySites].Rows.Count - 1][CompanySites.Postcode] = frm.gvSites.GetRowCellValue(i, CompanySites.Postcode);
                        dsMain.Tables[Tables.CompanySites].Rows[dsMain.Tables[Tables.CompanySites].Rows.Count - 1][CompanySites.CountriesID] = frm.gvSites.GetRowCellValue(i, CompanySites.CountriesID);
                        dsMain.Tables[Tables.CompanySites].Rows[dsMain.Tables[Tables.CompanySites].Rows.Count - 1][CompanySites.CountiesID] = frm.gvSites.GetRowCellValue(i, CompanySites.CountiesID);


                        dsMain.Tables[Tables.CompanySites].AcceptChanges();
                    }

                }

                if (frm.dsMain.Tables[Tables.CompanySites].Rows.Count > 0)
                    luSite.EditValue = frm.dsMain.Tables[Tables.CompanySites].Rows[dsMain.Tables[Tables.CompanySites].Rows.Count - 1][CompanySites.ID];

                frm.Close();

            }
            catch (Exception ex)
            {
                Messages.Error(ex.Message);
            }
            finally
            { }
        }



        #region Releated To Placements
        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

        }

        private EditorButton button;
        protected EditorButton Button
        {
            get
            {
                if (button == null)
                    button = new EditorButton(ButtonPredefines.Ellipsis);
                return button;
            }
        }

        protected ObjectState GetObjectState(int rowHandle)
        {
            if (rowHandle == pressedRowHandle)
                return ObjectState.Pressed;
            else
                if (rowHandle == HighlightedRowHandle)
                    return ObjectState.Hot;
                else
                    return ObjectState.Normal;
        }

        private void DrawButton(GraphicsCache cache, Rectangle bounds, ActiveLookAndFeelStyle lookAndFeel, AppearanceObject appearance, ObjectState state, string Caption)
        {
            EditorButtonObjectInfoArgs args = new EditorButtonObjectInfoArgs(cache, Button, appearance);
            args.Bounds = bounds;
            BaseLookAndFeelPainters painters = LookAndFeelPainterHelper.GetPainter(lookAndFeel);
            args.State = state;
            painters.Button.DrawObject(args);
            args.Bounds = new Rectangle(args.Bounds.Left, args.Bounds.Top, args.Bounds.Width, args.Bounds.Height - 2);
            painters.Button.DrawCaption(args, Caption, appearance.Font, SystemBrushes.ControlText, args.Bounds, null);
        }

        GridHitInfo info = null;

        int pressedRowHandle = GridControl.InvalidRowHandle;
        int highlightedRowHandle = GridControl.InvalidRowHandle;

        public int PressedRowHandle
        {
            get { return pressedRowHandle; }
            set
            {
                if (pressedRowHandle != GridControl.InvalidRowHandle)
                {
                    int rowHandle = pressedRowHandle;
                    pressedRowHandle = GridControl.InvalidRowHandle;
                    gvShortList.InvalidateRowCell(rowHandle, gvShortList.Columns["AddPlacement"]);


                }
                pressedRowHandle = value;
                gvShortList.InvalidateRowCell(pressedRowHandle, gvShortList.Columns["AddPlacement"]);
            }
        }

        public int HighlightedRowHandle
        {
            get { return highlightedRowHandle; }
            set
            {
                if (highlightedRowHandle == value)
                    return;
                if (highlightedRowHandle != GridControl.InvalidRowHandle)
                {
                    int rowHandle = highlightedRowHandle;
                    highlightedRowHandle = GridControl.InvalidRowHandle;
                    gvShortList.InvalidateRowCell(rowHandle, gvShortList.Columns["AddPlacement"]);
                }
                else
                {
                    highlightedRowHandle = value;
                    PressedRowHandle = GridControl.InvalidRowHandle;
                }
                gvShortList.InvalidateRowCell(highlightedRowHandle, gvShortList.Columns["AddPlacement"]);
            }
        }

        private void gridView1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }

        protected virtual void OnButtonClick(int RowHandle)
        {
            Text += "!";
        }

        private void gridView1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }



        private void gridView1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }

        private void grdMain_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gvMain.FocusedRowHandle < 0)
                    return;

                int ID = Convert.ToInt32(gvMain.GetRowCellValue(gvMain.FocusedRowHandle, "ID"));
                frmPlacement frm;

                //if (FilterContactID > 0)
                //    frm = new frmContacts(this.FilterContactID.ToString(), ID);
                //else
                frm = new frmPlacement();
                frm.loadPlacement(ID);

                frm.Owner = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {

                    frm.Dispose();

                    //
                    GetAllReqPlacements();

                    xtMain.SelectedTabPage = tpPlacements;
                    tpPlacements.Show();
                    xtMain.SelectedTabPage.BringToFront();
                }
                else
                {
                    frm.Dispose();
                }
            }
            catch (Exception ex)
            {
                Messages.Error(ex.Message);
            }
            finally
            {
            }
        }

        private void grdView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle > -1)
            {
                var canceled = (bool)gvMain.GetRowCellValue(e.RowHandle, "Canceled");

                if (canceled)
                {
                    e.Appearance.BackColor = Color.Red;
                }
                else
                {
                    var startDate = (DateTime)gvMain.GetRowCellValue(e.RowHandle, "CreatedOn");

                    if (startDate.Date == DateTime.Now.Date)
                        e.Appearance.BackColor = Color.LightGreen;

                }
            }

        }

        private void btnTextReqToCandidates_Click_1(object sender, EventArgs e)
        {

            var dsShortList = dsMain.Tables[Tables.ShortlistContacts];

            var candidatePersonIdsQuery = from c in dsShortList.AsEnumerable()
                                          select c.Field<int>("PersonsId");




        }

        private void txtDeleteFromShortList_Click_1(object sender, EventArgs e)
        {

            var view = gvShortList;

            if (view == null || view.SelectedRowsCount == 0) return;


            DataRow[] rows = new DataRow[view.SelectedRowsCount];

            for (int i = 0; i < view.SelectedRowsCount; i++)

                rows[i] = view.GetDataRow(view.GetSelectedRows()[i]);



            view.BeginSort();

            try
            {

                foreach (DataRow row in rows)

                    row.Delete();

            }

            finally
            {

                view.EndSort();

            }

        }

        private void GetAllReqPlacements()
        {
            var rsysEntities = new RsysEntities1();

            var placements = from p in rsysEntities.Placements.Where(p => p.IsDeleted == false)
                             join c in rsysEntities.Companies on p.Requirement.CompaniesID equals c.ID
                             where p.Requirement.ID == ID.Value && p.IsDeleted == false
                             select new PlacementObject()
                             {
                                 ID = p.PlacementId,
                                 FirstName = p.Person.FirstName,
                                 LastName = p.Person.LastName,
                                 RequrimentRefrecnce = p.Requirement.Reference,
                                 StartDate = p.StartDate,
                                 StandardRate = p.StandardRate,
                                 OvertimeRate = p.OvertimeRate,
                                 WeekendRate = p.WeekendRate,
                                 IsCanceled = p.IsCanceled,
                                 ClientCompany = c.CompanyName,
                                 LastModifiedBy = rsysEntities.Persons.Where(x => x.ID == p.LastModifiedBy).FirstOrDefault().FirstName,
                                 CreatedBy = rsysEntities.Persons.Where(x => x.ID == p.CreatedBy).FirstOrDefault().FirstName,
                                 LastModifiedOn = p.LastModifiedOn,
                                 CreatedOn = p.CreatedOn,
                                 Canceled = p.IsCanceled,
                                 PlacementObjectStored = p
                             };

            grdMain.DataSource = placements;
            grdMain.RefreshDataSource();
        }
        #endregion

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string contactIDs = "-1";
            string ticketIDs = "-1";

            try
            {
                for (int i = 0; i < dsMain.Tables[Tables.RequirementTickets].Rows.Count; i++)
                {
                    ticketIDs = ticketIDs + "," + dsMain.Tables[Tables.RequirementTickets].Rows[i][RequirementTickets.TicketsID].ToString();
                }

                for (int i = 0; i < dsMain.Tables[Tables.ShortlistContacts].Rows.Count; i++)
                {
                    contactIDs = contactIDs + "," + dsMain.Tables[Tables.ShortlistContacts].Rows[i][ShortlistContacts.PersonsID].ToString();
                }

                contactIDs = "(" + contactIDs + ")";

                var dsTickets = dsMain.Tables[Tables.Tickets];


                frmRequirementSearch frm = new frmRequirementSearch(ticketIDs, contactIDs, dsMain.Tables[Tables.RequirementTickets], dsTickets);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();

                if (frm.isCancel || frm.ds == null)
                {
                    frm.Close();
                    return;

                }

                for (int i = 0; i < frm.ds.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToBoolean(frm.ds.Tables[0].Rows[i]["Select"]))
                    {
                        dsMain.Tables[Tables.ShortlistContacts].Rows.Add(dsMain.Tables[Tables.ShortlistContacts].NewRow());
                        dsMain.Tables[Tables.ShortlistContacts].Rows[dsMain.Tables[Tables.ShortlistContacts].Rows.Count - 1][ShortlistContacts.PersonsID] = frm.ds.Tables[0].Rows[i][Persons.ID];
                    }
                }

                grdShortList.RefreshDataSource();
            }
            catch (Exception ex)
            {
                Messages.Error(ex.Message);
            }
            finally
            {

            }
        }

        private void grdShortList_Click(object sender, EventArgs e)
        {

        }

        private void grpMain_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}