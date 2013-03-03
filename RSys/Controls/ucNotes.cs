using System;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System.Collections.Generic;
using DevExpress.XtraGrid;
using DevExpress.Utils;
using System.ComponentModel;
using System.Collections;
using DESCONIT.BLL;

namespace RSys
{
    public partial class ucNotes : DevExpress.XtraEditors.XtraUserControl
    {
        private int ScreenId = 0;
        private string ScreenName = "";
        private DataTable dtAttach;
        private BLL bll;
        private const string DeleteCol = "Deleted";

        string NotesFolder = "";

        public ucNotes(DataTable dt, int ScreenID, string ScreenName)
        {
            InitializeComponent();
            
            

            this.dtAttach = dt;
            this.ScreenId = ScreenID; 
            this.ScreenName = ScreenName;

            FillNotesTypeCombo();
           
            grdAttach.DataSource = dtAttach;
            grdAttach.RefreshDataSource();
            gvAttach.ExpandAllGroups();
            AddDeleteColumn(dtAttach);
            
        }

        private void FillNotesTypeCombo()
        {
            bll = new BLL(Tables.NotePriorities, Program.clsuser.CurrentDB, Program.clsuser.UserID);

            Hashtable ht = new Hashtable();


            DataSet ds = bll.ExecuteSP("usp_NotePrioritiesGetByFields", ht); 

            rluPriority.DataSource = ds.Tables[0];
            rluPriority.DisplayMember = NotePriorities.Name;
            rluPriority.ValueMember = NotePriorities.ID;
        }

        

        
        public void RefreshDataSource(DataTable dt)
        {
            dtAttach = dt;
            AddDeleteColumn(dtAttach);
            grdAttach.DataSource = dtAttach;
            grdAttach.RefreshDataSource();
        }

        public DataTable GetNotesTable()
        {
            MarkAsDelete();
            return dtAttach;
        }

        private void MarkAsDelete()
        {
            for (int i = 0; i < dtAttach.Rows.Count; i++)
            {
                if (dtAttach.Rows[i][DeleteCol].ToString().Equals("1"))
                {
                    if (dtAttach.Rows[i].RowState == DataRowState.Unchanged)
                        dtAttach.Rows[i].AcceptChanges();

                    dtAttach.Rows[i].Delete();
                }
            }
        }

        private void AddDeleteColumn(DataTable dt)
        {
            if (!dt.Columns.Contains(DeleteCol))
            {
                DataColumn cl = new DataColumn(DeleteCol);
                dt.Columns.Add(cl);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i][DeleteCol] = 0;
                }

            }
            dt.AcceptChanges();
        }

        private void ConditionsAdjustment()
        {
            StyleFormatCondition cn;





            cn = new StyleFormatCondition(FormatConditionEnum.Equal, gvAttach.Columns[DeleteCol], null, 1);
            cn.ApplyToRow = true;
            cn.Appearance.Font = new Font(AppearanceObject.DefaultFont, FontStyle.Bold | FontStyle.Strikeout);

            cn.Appearance.BorderColor = Color.Red;
            //cn.Appearance.ForeColor = SystemColors.ControlDark;
            cn.Appearance.ForeColor = System.Drawing.Color.Red;
            gvAttach.FormatConditions.Add(cn);

            gvAttach.BestFitColumns();
        }

        private void gvAttach_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            gvAttach.ClearColumnErrors();

            gvAttach.SetRowCellValue(e.RowHandle, cl_ScreensID, this.ScreenId);
            if (gvAttach.GetRowCellValue(e.RowHandle, Notes.Note).ToString().Equals(string.Empty))
            {
                gvAttach.SetColumnError(cl_Notes, "Must enter a note.");
                e.Valid = false;
            }

            if (gvAttach.GetRowCellValue(e.RowHandle, Notes.NotePrioritiesID).ToString().Equals(string.Empty))
            {
                //gvAttach.SetColumnError(cl_Priority, "Select a note priority.");
                //e.Valid = false;
                gvAttach.SetRowCellValue(gvAttach.FocusedRowHandle, cl_Priority, 2);
            }


        }

        private void gvAttach_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
        }

        private void grdAttach_DoubleClick(object sender, EventArgs e)
        {
            //OpenNotes();

           
        }


        private void rluRoles_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lu = ((LookUpEdit)sender);

            //if (lu.EditValue == null)
            //    gvAttach.SetRowCellValue(gvAttach.FocusedRowHandle, cl_NotesName, "");
            //else
            //    gvAttach.SetRowCellValue(gvAttach.FocusedRowHandle, cl_NotesName, lu.GetColumnValue(NotesTypes.Name));

        }

        private void ucNotes_Load(object sender, EventArgs e)
        {
            ConditionsAdjustment();
        }

        private void gvAttach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Delete();
            }
        }

        private void Delete()
        {
            try
            {
                if (gvAttach.FocusedRowHandle > -1)
                {
                    
                    if (gvAttach.GetRowCellValue(gvAttach.FocusedRowHandle, Attachments.ID) != DBNull.Value)
                    {
                        if (Convert.ToInt32(gvAttach.GetRowCellValue(gvAttach.FocusedRowHandle, DeleteCol)) == 1)
                        {
                            gvAttach.SetRowCellValue(gvAttach.FocusedRowHandle, DeleteCol, 0);
                    
                        }
                        else
                        {
                            gvAttach.SetRowCellValue(gvAttach.FocusedRowHandle, DeleteCol, 1);

                    
                        }


                        gvAttach.RefreshData();


                    }
                    else
                    {
                        dtAttach.Rows[gvAttach.FocusedRowHandle].Delete();
                    }

                    //}
                }
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally { }
        }

    }
}
