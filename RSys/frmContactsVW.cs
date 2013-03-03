using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using System.IO;
using DevExpress.Utils.Serializing;
using DevExpress.XtraPrinting;

using DESCONIT.BLL;

namespace RSys
{
    public partial class frmContactsVW : BaseScreen
    {
        private struct _personTypes
        {
            internal int User, ClientContact, Candidate;
        }

        _personTypes personTypes;

        DataSet ds;
        int FilterContactID = -1;
        BLL bll;
        public frmContactsVW()
        {
            InitializeComponent();
            RefreshData(null);
            Initialize();

        }

        public frmContactsVW(int FilterContactID)
        {
            InitializeComponent();
            this.FilterContactID = FilterContactID;
            RefreshData(null);
            Initialize();


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

            //gvMain.Columns[Persons.ConatactTypesID].FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
            //gvMain.ActiveFilterString = "[" + Persons.ConatactTypesID + "] = " + FilterContactID.ToString();



            if (this.FilterContactID == personTypes.User)
            {
                gvMain.Columns["ConatactTypesID"].Visible = false;
                gvMain.Columns["CompaniesID"].Visible = false;
                gvMain.Columns["ConatactTypesID"].Visible = false;
                gvMain.Columns["JobTitlesID"].Visible = false;
                grpMain.Text = "Users";
            }
            else if (this.FilterContactID == personTypes.Candidate)
            {
                gvMain.Columns["ConatactTypesID"].Visible = false;
                gvMain.Columns["CompaniesID"].Visible = false;
                
                gvMain.Columns["JobTitlesID"].Visible = false;
                gvMain.Columns["WorkTel"].Visible = false;
                grpMain.Text = "Candidates";
            }
            else if (this.FilterContactID == personTypes.ClientContact)
            {
                gvMain.Columns["ConatactTypesID"].Visible = false;
                gvMain.Columns["CompaniesID"].Visible = true;
               
                gvMain.Columns["JobTitlesID"].Visible = true;
                grpMain.Text = "Client Contacts";
            }
        }

        private void Initialize()
        {
            base.btnBaseAdd = this.btnAdd;
            base.btnBaseEdit = this.btnEdit;
            base.btnBaseDelete = this.btnDelete;
            base.SystemObjectName = "frmContacts";
        }

        public void RefreshData(int? RecID)
        {
            bll = new BLL(Tables.Persons, Program.clsuser.CurrentDB, Program.clsuser.UserID);

            ds = bll.Search();

            ds.Tables[0].TableName = Tables.Persons;
            ds.Tables[1].TableName = Tables.Genders;
            ds.Tables[2].TableName = Tables.MartialStatuses;
            ds.Tables[3].TableName = Tables.JobTitles;
            ds.Tables[4].TableName = Tables.Companies;
            //TODO : Replace 
            //ds.Tables[5].TableName = Tables.ContactTypes;


            if (FilterContactID > 0)
            {
                for (int i = 0; i < ds.Tables[Tables.Persons].Rows.Count; i++)
                {
                    if (Convert.ToInt32(ds.Tables[Tables.Persons].Rows[i][Persons.ConatactTypesID]) != this.FilterContactID)
                    {
                        ds.Tables[Tables.Persons].Rows.RemoveAt(i);
                        i--;
                    }
                }
            }

            rluCompany.ValueMember = Companies.ID;
            rluCompany.DisplayMember = Companies.CompanyName;
            rluCompany.DataSource = ds.Tables[Tables.Companies];

            luGender.ValueMember = Genders.ID;
            luGender.DisplayMember = Genders.Name;
            luGender.DataSource = ds.Tables[Tables.Genders];

            rluMartialStatus.ValueMember = MartialStatuses.ID;
            rluMartialStatus.DisplayMember = MartialStatuses.Name;
            rluMartialStatus.DataSource = ds.Tables[Tables.MartialStatuses];

            rluJobTitle.ValueMember = JobTitles.ID;
            rluJobTitle.DisplayMember = JobTitles.Name;
            rluJobTitle.DataSource = ds.Tables[Tables.JobTitles];

            rluContactType.ValueMember = ContactTypes.ID;
            rluContactType.DisplayMember = ContactTypes.Name;
            rluContactType.DataSource = ds.Tables[Tables.ContactTypes];

            grdMain.DataSource = ds.Tables[Tables.Persons];
            grdMain.RefreshDataSource();

            if (RecID != null)
            {
                for (int i = 0; i < ds.Tables[Tables.Persons].Rows.Count; i++)
                {
                    if (ds.Tables[Tables.Persons].Rows[i][Persons.ID].ToString().Equals(RecID.ToString()))
                    {
                        gvMain.FocusedRowHandle = i;
                        break;
                    }
                }
            }
        }



        private void frmContactsVW_Load(object sender, EventArgs e)
        {
            grpMain.Height = pnlButtons.Top - 5;
        }

        internal void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmContacts frm;

                if (FilterContactID > 0)
                    frm = new frmContacts(this.FilterContactID.ToString());
                else
                    frm = new frmContacts();

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

        internal void btnQuickAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmQuickAddCandidate frm;

                //if (FilterContactID > 0)
                //    frm = new frmContacts(this.FilterContactID.ToString());
                //else
                frm = new frmQuickAddCandidate();

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

        internal void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvMain.FocusedRowHandle < 0)
                    return;

                int ID = Convert.ToInt32(gvMain.GetRowCellValue(gvMain.FocusedRowHandle, Persons.ID));
                frmContacts frm;


                if (FilterContactID > 0)
                    frm = new frmContacts(this.FilterContactID.ToString(), ID);
                else
                    frm = new frmContacts(ID);

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

        public void RefreshGrid()
        {

        }

        private void grdMain_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void frmContactsVW_Paint(object sender, PaintEventArgs e)
        {
            grpMain.Height = pnlButtons.Top - 5;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                Functions.ExportToExcel(gvMain, "Contacts.xls");
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        internal void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvMain.FocusedRowHandle < 0)
                return;

            if (!Messages.Delete())
                return;

            bll.Delete(Convert.ToInt32(gvMain.GetRowCellValue(gvMain.FocusedRowHandle, Persons.ID)));
            RefreshData(null);


        }

        private void btnExportToPDF_Click(object sender, EventArgs e)
        {
            try
            {
                Functions.ExportToExcel(gvMain, "Contacts.pdf");
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        public void btnClientContactQuickAdd(object o, object o1)
        {
            try
            {
                frmClientQuickRegistration frm;

                //if (FilterContactID > 0)
                //    frm = new frmContacts(this.FilterContactID.ToString());
                //else
                frm = new frmClientQuickRegistration();

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
    }
}