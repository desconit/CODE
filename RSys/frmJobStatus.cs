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
using DevExpress.XtraGrid.Columns;
using DESCONIT.BLL;

namespace RSys
{
    public partial class frmJobStatus : BaseScreen
    {

        DataSet dsMain;
        bool isEdit;
        bool isForContact;
        BLL bll = new BLL(Tables.JobStatuses, Program.clsuser.CurrentDB, Program.clsuser.UserID);

        public frmJobStatus()
        {
            InitializeComponent();
            Initialize();
            this.isForContact = isForContact;
            RefreshData();

        }

        private void Initialize()
        {
            base.btnBaseAdd = this.btnSave;
            base.btnBaseEdit = this.btnSave;
            base.btnBaseDelete = this.btnDelete;
            base.SystemObjectName = this.Name;

        }

        private void form_Load(object sender, EventArgs e)
        {
            if (!base.CanAdd)
            {
                gvMain.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            }

            gvMain.OptionsBehavior.Editable = CanUpdate;

            if (base.CanAdd || base.CanUpdate)
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;
        }

        private void RefreshData()
        {
            dsMain = bll.Search();
           
            SetTableNames();
            grdMain.DataSource = dsMain.Tables[Tables.JobStatuses];
            grdMain.RefreshDataSource();

        }


        private void gvMain_ValidateRow(System.Object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            ColumnView view = (ColumnView)sender;
            GridColumn colName = view.Columns[JobStatuses.Name];
           
            string UserId = null;
            string BranchName = null;
         
            if (DBNull.Value == view.GetRowCellValue(e.RowHandle, colName))
            {
                BranchName = "";
            }
            else
            {
                BranchName = view.GetRowCellValue(e.RowHandle, colName).ToString();
            }

         

            if ((BranchName.Equals(string.Empty)))
            {
                view.SetColumnError(colName, "Please enter name.");
                e.Valid = false;
            }
            else
            {
                DataRow[] drs = dsMain.Tables[0].Select(Counties.Name + " = '" + BranchName + "'");

                if (drs.Length > 0 && gvMain.FocusedRowHandle < 0)
                {
                    view.SetColumnError(colName, "Value already exits.");
                    e.Valid = false;
                }
            }

        }


           

       private void gvMain_InvalidRowException(System.Object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
       {
           e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
       }

        private void SetTableNames()
        {
            dsMain.Tables[0].TableName = Tables.JobStatuses;
        }
        private void BindFields()
        {
            try
            {
               
                SetTableNames();


                grdMain.DataSource = dsMain.Tables[Tables.CurrencyConversions];
                grdMain.RefreshDataSource();
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
        }
        private void luCode_ProcessNewValue(System.Object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            try
            {
                if (e.DisplayValue == null || string.Empty.Equals(e.DisplayValue))
                {
                    return;
                }

                if (dsMain.Tables[Tables.ExistingData].Rows.Count > 0)
                {
                    DataRow dr = dsMain.Tables[Tables.ExistingData].Rows[dsMain.Tables[Tables.ExistingData].Rows.Count - 1];
                    if (dr[ExistingData.ID].ToString().Equals("-1"))
                    {
                        dr[ExistingData.Code] = e.DisplayValue.ToString();
                    }
                    else
                    {
                        ClearFields();
                        dr = dsMain.Tables[Tables.ExistingData].NewRow();
                        dr[ExistingData.Code] = e.DisplayValue.ToString();
                        dr[ExistingData.ID] = -1;
                        dsMain.Tables[Tables.ExistingData].Rows.Add(dr);
                        //luCode.EditValue = -1;
                    }
                }
                else
                {
                    ClearFields();
                    DataRow dr = dsMain.Tables[Tables.ExistingData].NewRow();
                    dr[ExistingData.Code] = e.DisplayValue.ToString();
                    dr[ExistingData.ID] = -1;
                    dsMain.Tables[Tables.ExistingData].Rows.Add(dr);
                }

                e.Handled = true;
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        private void ClearFields()
        {
            try
            {
                //txtName.Text = string.Empty;
                //txtSymbol.Text = string.Empty;
                //chkActive.Checked = true;
                //lblEntry.Text = string.Empty;
                //btnDelete.Enabled = false;
                dsMain = bll.GetByID(-1);
                SetTableNames();

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (!Messages.Save())
                    return;

               
                bll.SaveAllSimple(dsMain);

                for (int i = 0; i < dsMain.Tables[0].Rows.Count; i++)
                {
                    dsMain.Tables[0].Rows[i].AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvMain_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            if (gvMain.FocusedRowHandle < 0)
            {
                btnDelete.Enabled = false;
                return;
            }
                

            if (!gvMain.GetRowCellValue(gvMain.FocusedRowHandle, cl_ID).ToString().Equals(string.Empty))
            {
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvMain.FocusedRowHandle < 0)
                return;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                bll.Delete(Convert.ToInt32( gvMain.GetRowCellValue(gvMain.FocusedRowHandle,cl_ID)));
                gvMain.DeleteRow(gvMain.FocusedRowHandle);

            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);

            }
            finally {
                this.Cursor = Cursors.Default;
            }
        }

    }
}