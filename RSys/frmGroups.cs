using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DESCONIT.BLL;

namespace RSys
{
    public partial class frmGroups : DevExpress.XtraEditors.XtraForm
    {

        DataSet dsMain;
        bool isEdit;
        BLL bll = new BLL(Tables.Groups, Program.clsuser.CurrentDB, Program.clsuser.UserID);

        public frmGroups()
        {
            InitializeComponent();
            RefreshData();
            
        }

        private void RefreshData()
        {
            if (luCode.EditValue == null)
                dsMain = bll.GetByID(-1);
            else
                dsMain = bll.GetByID(Convert.ToInt32(luCode.EditValue));

            SetTableNames();

            luCode.Properties.DataSource = dsMain.Tables[Tables.ExistingData];
            luCode.Properties.ValueMember = Groups.ID;
            luCode.Properties.DisplayMember = Groups.Name;



            BindFields();
            
        }


        
           

       
        private void SetTableNames()
        {
            dsMain.Tables[0].TableName = Tables.Groups;
            dsMain.Tables[1].TableName = Tables.ExistingData;
            dsMain.Tables[2].TableName = Tables.UserGroups;
            dsMain.Tables[3].TableName = Tables.GroupRights;


            DataRelation relation = new DataRelation("relation", dsMain.Tables[Tables.Groups].Columns[Groups.ID], dsMain.Tables[Tables.UserGroups].Columns[UserGroups.GroupsID], false);
            dsMain.Relations.Add(relation);

            relation = new DataRelation("relation1", dsMain.Tables[Tables.Groups].Columns[Groups.ID], dsMain.Tables[Tables.GroupRights].Columns[GroupRights.GroupsID], false);
            dsMain.Relations.Add(relation);

        }
        private void BindFields()
        {
            try
            {
                if (dsMain.Tables[Tables.Groups].Rows.Count > 0)
                {
                    chkActive.Checked = Convert.ToBoolean(dsMain.Tables[Tables.Groups].Rows[0][Groups.isActive]);
                    lblEntry.Visible = false;
                }     
                lstUsers.Items.Clear();
                for (int i = 0; i < dsMain.Tables[Tables.UserGroups].Rows.Count; i++)
                {
                     CheckedListBoxItem chkItem = new CheckedListBoxItem((string)dsMain.Tables[Tables.UserGroups].Rows[i][Persons.FullName], dsMain.Tables[Tables.UserGroups].Rows[i]["Checked"].ToString() == "1");
                    lstUsers.Items.Add(chkItem);
                }


                grdScreens.DataSource = dsMain.Tables[Tables.GroupRights];
                grdScreens.RefreshDataSource();

                
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

                ClearFields();

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
                    dr[Groups.Name] = e.DisplayValue.ToString();
                    
                    dsMain.Tables[Tables.ExistingData].Rows.Add(dr);
                }


                //isCalledFromProcessNewVal = true;
                //luCode.EditValue = -1;

                // e.Handled = true;
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            {
                //SetEditValuetoNewRec(); 
            }
        }

        private void ClearFields()
        {
            try
            {

                RefreshData();

                //luCode.EditValue = null;
                chkActive.Checked = true;
                lblEntry.Text = "New Entry";
                lblEntry.Visible = true;
                
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

        private bool Validation()
        {
            bool check = true;
            //Err.ClearErrors();


            if ((luCode.Text == string.Empty))
            {
                Err.SetError(luCode, "Enter group name.");
                luCode.Focus();
                check = false;
            }

            else
            {
                Err.SetError(luCode, null);
            }


            return check;


        }

        private bool Save()
        {
            if (!Messages.Save())
                return false;

            if (!Validation())
                return false;

            try
            {

                if (dsMain.Tables[Tables.Groups].Rows.Count == 0)
                    dsMain.Tables[Tables.Groups].Rows.Add(dsMain.Tables[Tables.Groups].NewRow());


                dsMain.Tables[Tables.Groups].Rows[0][Groups.Name] = luCode.Text;
                dsMain.Tables[Tables.Groups].Rows[0][Groups.isActive] = chkActive.EditValue;

                //  Update GroupUsers Table
                for (int i = 0; i < lstUsers.Items.Count; i++)
                {
                    int CheckedState;
                    if (lstUsers.Items[i].CheckState == CheckState.Checked)
                    { CheckedState = 1; }
                    else
                    { CheckedState = 0; }


                    if (CheckedState ==1 && !dsMain.Tables[Tables.UserGroups].Rows[i]["Checked"].Equals(CheckedState))
                    {
                        dsMain.Tables[Tables.UserGroups].Rows[i].SetAdded();
                        dsMain.Tables[Tables.UserGroups].Rows[i]["Checked"] = CheckedState;
                    }
                    else if (CheckedState == 0 && !dsMain.Tables[Tables.UserGroups].Rows[i]["Checked"].Equals(CheckedState))
                    {
                        dsMain.Tables[Tables.UserGroups].Rows[i]["Checked"] = CheckedState;
                        dsMain.Tables[Tables.UserGroups].Rows[i].Delete();

                    }


                }
                dsMain.Tables[Tables.GroupRights].AcceptChanges();


                foreach (DataRow dr in dsMain.Tables[Tables.GroupRights].Rows)
                {
                    if (dr[GroupRights.ID] == DBNull.Value)
                        dr.SetAdded();
                    else
                        dr.SetModified();
                }

                bll.SaveComplex(dsMain, isEdit);

                
                RefreshData();
                BindFields();

                return true;

            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
                return false;
            }
            finally

            { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (!Save())
                    return;
                
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

        private void luCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(luCode.EditValue) == -1)
                {
                    lblEntry.Text = "New Entry";
                    isEdit = false;
                    return;
                }



                if (luCode.EditValue == null | object.ReferenceEquals(luCode.EditValue, DBNull.Value))
                {
                    isEdit = false;
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
                    RefreshData();
                    BindFields();

                }
            }
            catch (Exception ex)
            {
                Functions.LogError(ex); 
                Messages.Error(ex.Message);

            }
            finally
            { }
        }

        private void luCode_Leave(object sender, EventArgs e)
        {
            if (luCode.EditValue != null)
                luCode_EditValueChanged(null, null);
        }

        private void luCode_Closed(object sender, ClosedEventArgs e)
        {
            if (luCode.EditValue != null)
                SendKeys.Send("{TAB}");
        }

    }
}