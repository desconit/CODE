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
using DevExpress.Utils.Serializing;
using DevExpress.XtraPrinting;
using DESCONIT.BLL;

namespace RSys
{
    public partial class frmRequirementsVW : BaseScreen
    {
        BLL bll;
        int? consultantID;
        public frmRequirementsVW()
        {
            InitializeComponent();
            Initialize();
            
            RefreshData();
        }

        public frmRequirementsVW(int ? ConsultantID)
        {
            this.consultantID = ConsultantID;
            
            InitializeComponent();
            Initialize();
            this.Text = "My Jobs";
            RefreshData();
        }

        private void Initialize()
        {
            base.btnBaseAdd = this.btnAdd;
            base.btnBaseEdit = this.btnEdit;
            base.btnBaseDelete = this.btnDelete;
            base.SystemObjectName = "frmRequirements";
        }
        DataSet ds;

        private void SetTableNames()
        {
            bll = new BLL(Tables.Requirements, Program.clsuser.CurrentDB, Program.clsuser.UserID);

            ds = bll.Search();

            if (this.consultantID != null)
            {
                
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (!ds.Tables[0].Rows[i][Companies.ConsultantID].ToString().Equals(this.consultantID.ToString()))
                    {
                        ds.Tables[0].Rows.RemoveAt(i);
                        i--;
                    }
                }

              
            }

            ds.Tables[0].TableName = Tables.Requirements;
            ds.Tables[1].TableName = Tables.RateFrequencies;
            ds.Tables[2].TableName = Tables.Trades;
            ds.Tables[3].TableName = Tables.JobStatuses;
            ds.Tables[4].TableName = Tables.RequirementTypes;

        }
        public  void RefreshData()
        {

            SetTableNames();

            repositoryItemLookUpEdit1.ValueMember = Trades.ID;
            repositoryItemLookUpEdit1.DisplayMember = Trades.Name;
            repositoryItemLookUpEdit1.DataSource = ds.Tables[Tables.Trades];
            
            rluJobTitle.ValueMember = JobTitles.ID;
            rluJobTitle.DisplayMember = JobTitles.Name;
            rluJobTitle.DataSource = ds.Tables[Tables.JobTitles];

            rluStatus.ValueMember = Statuses.ID;
            rluStatus.DisplayMember = Statuses.Name;
            rluStatus.DataSource = ds.Tables[Tables.JobStatuses];

            rluType.ValueMember = RequirementTypes.ID;
            rluType.DisplayMember = RequirementTypes.Name;
            rluType.DataSource = ds.Tables[Tables.RequirementTypes];
           
            

            grdMain.DataSource = ds.Tables[Tables.Requirements];
            grdMain.RefreshDataSource();
        }

        public void RefreshData(int RecID)
        {
            RefreshData();


            grdMain.DataSource = ds.Tables[Tables.Requirements];
            grdMain.RefreshDataSource();

            for (int i = 0; i < ds.Tables[Tables.Requirements].Rows.Count; i++)
            {
                if (ds.Tables[Tables.Requirements].Rows[i][Requirements.ID].ToString().Equals(RecID.ToString()))
                {
                    gvMain.FocusedRowHandle = i;
                    break;
                }
            }
        }

        private void frmRequirementsVW_Load(object sender, EventArgs e)
        {
            grpMain.Height = pnlButtons.Top - 5;
            tmrJobs.Interval = 60000 * 10;// 10 minutes
            tmrJobs.Enabled = true;

        }

        internal void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmRequirements frm = new frmRequirements();
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

                int ID = Convert.ToInt32( gvMain.GetRowCellValue(gvMain.FocusedRowHandle, Requirements.ID));
                frmRequirements frm = new frmRequirements(ID);
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

        private void frmRequirementsVW_Paint(object sender, PaintEventArgs e)
        {
            grpMain.Height = pnlButtons.Top - 5;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string filePath = Application.StartupPath + "\\" +  "Requirements.xls";
            //TODO : Replace 
            //gvMain.ExportToXls(filePath, new XlsExportOptions(true, false));

            Messages.Information("File is generated at " + filePath);
        }

        internal void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvMain.FocusedRowHandle < 0)
                return;

            if (!Messages.Delete())
                return;

            bll.Delete(Convert.ToInt32(gvMain.GetRowCellValue(gvMain.FocusedRowHandle, Persons.ID)));
            RefreshData();
        }

        private void gvMain_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                int placements = Convert.ToInt32( View.GetRowCellValue(e.RowHandle, View.Columns["isPlacements"]));
                if (placements.Equals(0))
                {
                    e.Appearance.BackColor = Color.LightPink;
                    //e.Appearance.BackColor2 = Color.SeaShell;
                }
            }
        }

        private void tmrJobs_Tick(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}