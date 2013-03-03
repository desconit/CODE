using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors;
using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using System.IO;
using System.Collections;
using DevExpress.Utils.Serializing;
using DevExpress.XtraPrinting;
using DESCONIT.BLL;

namespace RSys
{
    public partial class frmCompaniesVW : BaseScreen
    {
        DataSet ds;
        BLL bll;
        int? consultantID;
        public frmCompaniesVW()
        {
            InitializeComponent();
            RefreshData();
            Initialize();
        }

        public frmCompaniesVW(int ? ConsultantID)
        {
            InitializeComponent();
            this.Text = "My Companies";
            this.consultantID = ConsultantID;
            RefreshData();
            Initialize();
            
        }

        private void Initialize()
        {
            
            base.btnBaseAdd = this.btnAdd;
            base.btnBaseEdit = this.btnEdit;
            base.btnBaseDelete = this.btnDelete;
            base.SystemObjectName = "frmCompanies";
        }
        public  void RefreshData()
        {
            bll = new BLL(Tables.Companies, Program.clsuser.CurrentDB, Program.clsuser.UserID);
           


            ds = bll.Search();

            DataRow[] drs;
            if (this.consultantID != null)
            {
                //drs = dsTemp.Tables[0].Select(Companies.ConsultantID + "=" + this.consultantID.ToString());



                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if(!ds.Tables[0].Rows[i][Companies.ConsultantID].ToString().Equals(this.consultantID.ToString()))
                    {
                        ds.Tables[0].Rows.RemoveAt(i);
                        i--;
                    }
                }

                //if (drs.Length > 0)
                //{
                   

                //    for (int i = 0; i < drs.Length; i++)
                //    {   
                //        DataRow dr = ds.Tables[0].NewRow();

                //        for (int col = 0; col < dr.Table.Columns.Count; col++)
                //            dr[col] = drs[i][col];

                //        // dr = drs[i];
                //        //dsTemp.Tables[0].Rows.Add(dr);
                //    }
                //    ds.AcceptChanges();
                //}
                //else
                //{
                    
                //}
            }
          

            ds.Tables[0].TableName = Tables.Companies;
            ds.Tables[1].TableName = Tables.Industries;
            ds.Tables[2].TableName = Tables.Statuses;
            ds.Tables[3].TableName = Tables.JobTitles;
            ds.Tables[4].TableName = "CanvasingClients";
            
            rluIndustry.ValueMember = Industries.ID;
            rluIndustry.DisplayMember = Industries.Name;
            rluIndustry.DataSource = ds.Tables[Tables.Industries];

            rluStatus.ValueMember = Statuses.ID;
            rluStatus.DisplayMember = Statuses.Name;
            rluStatus.DataSource = ds.Tables[Tables.Statuses];

            

            grdMain.DataSource = ds.Tables[Tables.Companies];
            grdMain.RefreshDataSource();

            grdCanvasing.DataSource = ds.Tables["CanvasingClients"];
            grdCanvasing.RefreshDataSource();
            DataTable dt = new DataTable();



            RefreshContactGrid();
        }

        public void RefreshData(int RecID)
        {
            BLL bll = new BLL(Tables.Companies, Program.clsuser.CurrentDB, Program.clsuser.UserID);
            
            DataSet ds = bll.Search();

            ds.Tables[0].TableName = Tables.Companies;
            ds.Tables[1].TableName = Tables.Industries;



            rluIndustry.ValueMember = Industries.ID;
            rluIndustry.DisplayMember = Industries.Name;
            rluIndustry.DataSource = ds.Tables[Tables.Industries];

            grdMain.DataSource = ds.Tables[Tables.Companies];
            grdMain.RefreshDataSource();

            for (int i = 0; i < ds.Tables[Tables.Companies].Rows.Count; i++)
            {
                if (ds.Tables[Tables.Companies].Rows[i][Companies.ID].ToString().Equals(RecID.ToString()))
                {
                    gvMain.FocusedRowHandle = i;
                    break;
                }
            }

            for (int i = 0; i < ds.Tables[Tables.Companies].Rows.Count; i++)
            {
                if (ds.Tables[Tables.Companies].Rows[i][Companies.ID].ToString().Equals(RecID.ToString()))
                {
                    gvCanvasing.FocusedRowHandle = i;
                    break;
                }
            }
        }

        private void frmCompaniesVW_Load(object sender, EventArgs e)
        {
            grpMain.Height = pnlButtons.Top - 5;
        }

        internal void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmCompanies frm = new frmCompanies();
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

                int ID = 0;
                if (xtMain.SelectedTabPage == tpAll)
                {
                    ID = Convert.ToInt32(gvMain.GetRowCellValue(gvMain.FocusedRowHandle, Companies.ID));
                    frmCompanies frm = new frmCompanies(ID);
                    frm.Owner = this;
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                }
                else
                {
                    ID = Convert.ToInt32(gvCanvasing.GetRowCellValue(gvCanvasing.FocusedRowHandle, Companies.ID));
                    frmCanvassingClient frm = new frmCanvassingClient(ID);
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

        public void RefreshGrid()
        {
 
        }

        private void grdMain_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void frmCompaniesVW_Paint(object sender, PaintEventArgs e)
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
                Functions.ExportToExcel(gvMain, "Clients.xls");
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }

            
        }

        private void gvMain_Click(object sender, EventArgs e)
        {
            RefreshContactGrid();
        }

        private void RefreshContactGrid()
        {
            //int companiesID = -1;
            //if (!(gvMain.FocusedRowHandle < 0))
            //    companiesID = Convert.ToInt32(gvMain.GetRowCellValue(gvMain.FocusedRowHandle, Companies.ID));

            //BLL bll = new BLL(Tables.Persons, Program.clsuser.CurrentDB, Program.clsuser.UserID);

            //Hashtable ht = new Hashtable();
            //ht.Add(Persons.CompaniesID, companiesID);
            //DataSet dsContact = bll.ExecuteSP("usp_" + Tables.Persons + "GetByFields", ht);
            

            //grdContacts.DataSource = dsContact.Tables[0];
            //grdContacts.RefreshDataSource();
        }

        internal void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvMain.FocusedRowHandle < 0)
                    return;

                if (!Messages.Delete())
                    return;

                bll.Delete(Convert.ToInt32(gvMain.GetRowCellValue(gvMain.FocusedRowHandle, Companies.ID)));
                RefreshData();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }

        }

        private void grdMain_Click(object sender, EventArgs e)
        {

        }
    }
}