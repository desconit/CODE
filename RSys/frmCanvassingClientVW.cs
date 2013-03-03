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
using System.Collections;
using DevExpress.Utils.Serializing;
using DevExpress.XtraPrinting;
using DESCONIT.BLL;

namespace RSys
{
    public partial class frmCanvassingClientVW : BaseScreen
    {
        DataSet ds;
        BLL bll;
        public frmCanvassingClientVW()
        {
            InitializeComponent();
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

        public void RefreshData()
        {
            bll = new BLL(Tables.Companies, Program.clsuser.CurrentDB, Program.clsuser.UserID);

            ds = bll.Search();

            ds.Tables[4].TableName = Tables.Companies;
            ds.Tables[5].TableName = Tables.Persons;
            ds.Tables[6].TableName = "NOConsultant";


            grdCanvasingClients.DataSource = ds.Tables[Tables.Companies];
            grdCanvasingClients.RefreshDataSource();

            gvCanvasing.ExpandAllGroups();

            grdWithoutConsulatant.DataSource = ds.Tables["NOConsultant"];
            grdWithoutConsulatant.RefreshDataSource();

        }

        public void RefreshData(int RecID)
        {
            BLL bll = new BLL(Tables.Companies, Program.clsuser.CurrentDB, Program.clsuser.UserID);

            DataSet ds = bll.Search();

            ds.Tables[4].TableName = Tables.Companies;
            ds.Tables[5].TableName = Tables.Persons;
            ds.Tables[6].TableName = "NOConsultant";


            grdCanvasingClients.DataSource = ds.Tables[Tables.Companies];
            grdCanvasingClients.RefreshDataSource();

            gvCanvasing.ExpandAllGroups();

            grdWithoutConsulatant.DataSource = ds.Tables["NOConsultant"];
            grdWithoutConsulatant.RefreshDataSource();

            for (int i = 0; i < ds.Tables[Tables.Companies].Rows.Count; i++)
            {
                if (ds.Tables[Tables.Companies].Rows[i][Companies.ID].ToString().Equals(RecID.ToString()))
                {
                    gvCanvasing.FocusedRowHandle = i;
                    xtMain.SelectedTabPageIndex = 0;
                    break;
                }
            }


            for (int i = 0; i < ds.Tables["NOConsultant"].Rows.Count; i++)
            {
                if (ds.Tables["NOConsultant"].Rows[i][Companies.ID].ToString().Equals(RecID.ToString()))
                {
                    gvWithoutConsulatant.FocusedRowHandle = i;
                    xtMain.SelectedTabPageIndex = 1;
                    break;
                }
            }
        }

        private void frmCanvassingClientVW_Load(object sender, EventArgs e)
        {
            grpMain.Height = pnlButtons.Top - 5;
        }

        internal void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmCanvassingClient frm = new frmCanvassingClient();
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
                if (gvCanvasing.FocusedRowHandle < 0)
                    return;

                int ID = 0;
                if (xtMain.SelectedTabPageIndex == 0)
                    ID = Convert.ToInt32(gvCanvasing.GetRowCellValue(gvCanvasing.FocusedRowHandle, Companies.ID));
                else
                    ID = Convert.ToInt32(gvWithoutConsulatant.GetRowCellValue(gvWithoutConsulatant.FocusedRowHandle, Companies.ID));

                frmCanvassingClient frm = new frmCanvassingClient(ID);
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


        private void frmCanvassingClientVW_Paint(object sender, PaintEventArgs e)
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
                Functions.ExportToExcel(gvCanvasing, "Clients.xls");
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }


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
                if (xtMain.SelectedTabPage == tpCanvasingOnly)
                {
                    if (gvCanvasing.FocusedRowHandle < 0)
                        return;

                    if (!Messages.Delete())
                        return;

                    bll.Delete(Convert.ToInt32(gvCanvasing.GetRowCellValue(gvCanvasing.FocusedRowHandle, Companies.ID)));
                }
                else
                {
                    if (gvWithoutConsulatant.FocusedRowHandle < 0)
                        return;

                    if (!Messages.Delete())
                        return;

                    bll.Delete(Convert.ToInt32(gvWithoutConsulatant.GetRowCellValue(gvWithoutConsulatant.FocusedRowHandle, Companies.ID)));
                }
                RefreshData();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }

        }

        private void grdCanvasingClients_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void gvCanvasing_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                if (!String.IsNullOrEmpty(View.GetRowCellValue(e.RowHandle, View.Columns["Duration"]).ToString()))
                {
                    int duration = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, View.Columns["Duration"]));
                    if (duration >= 90)
                    {
                        e.Appearance.BackColor = Color.Red;
                        //e.Appearance.BackColor2 = Color.SeaShell;
                    }
                }
            }
        }

        private void grdWithoutConsulatant_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        

    }
}
