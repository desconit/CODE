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
using System.Collections;

namespace RSys
{
    public partial class frmAttachments : DevExpress.XtraEditors.XtraForm
    {

        DataSet dsMain;
        bool isEdit;
        BLL bll = new BLL(Tables.Attachments, Program.clsuser.CurrentDB, Program.clsuser.UserID);
        ucAttachment ctrlAttach;
        public frmAttachments()
        {
            InitializeComponent();
            RefreshData();
            ctrlAttach = new ucAttachment(dsMain.Tables[Tables.Attachments], Screens.frmAttachments, "");
            grpMain.Controls.Add(ctrlAttach);
            ctrlAttach.Dock = DockStyle.Fill;
           
        }

        private void RefreshData()
        {
            Hashtable ht = new Hashtable();

            ht.Add(Attachments.ScreensID, Screens.frmAttachments);
            ht.Add(CompanyRecords.CompanyID, Program.clsuser.CompanyID);
            ht.Add(CompanyRecords.BranchesID, Program.clsuser.BranchID);
            dsMain = bll.ExecuteSP("usp_AttachmentsSearch", ht);

            //dsMain = bll.Search();
            SetTableNames();
           

        }


        private void gvMain_ValidateRow(System.Object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            ColumnView view = (ColumnView)sender;
            GridColumn colName = view.Columns[Branches.Name];
           
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
                view.SetColumnError(colName, "Please enter  name.");
                e.Valid = false;
            }

        }


           

       private void gvMain_InvalidRowException(System.Object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
       {
           e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
       }

        private void SetTableNames()
        {
            dsMain.Tables[0].TableName = Tables.Attachments;
        }
        private void BindFields()
        {
            try
            {
               
                SetTableNames();


                //grdMain.DataSource = dsMain.Tables[Tables.CurrencyConversions];
                //grdMain.RefreshDataSource();
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

                for (int i = 0; i < dsMain.Tables[0].Rows.Count; i++)
                {
                    if (dsMain.Tables[0].Rows[i].RowState == DataRowState.Added)
                        dsMain.Tables[0].Rows[i][Attachments.RecordID] = 0;
                }

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

    }
}