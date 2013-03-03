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
    public partial class frmGroups_old :  DevExpress.XtraEditors.XtraForm
    {
        DataSet dsBind = new DataSet();
        private bool isTab = false;
        
        public frmGroups_old()
        {
           // PageMode = IIPageMode.Add;
            
            InitializeComponent();
            InitializeValues();
           
        }

        public frmGroups_old(int KID)
        {
            //PageMode = IIPageMode.Edit;

            InitializeComponent();
            InitializeValues();

        }


        private void InitializeValues()
        {
            //TableName = Tables.Groups;
            //KeyFieldName = Groups.ID;
            //BLL = new GroupBLL();
            
            //this.Text = Constants.frmGroupName;
            //base.btnBaseAdd = btnSaveNClear;
            //base.btnBaseEdit = btnSave;
            //base.btnBaseDelete = btnDelete;
            //chkActive.EditValue = true;
            //base.LoggedInUser = Program.UserSettings.UserID;
            //base.LoggedInUserGroup = Program.UserSettings.GroupID;
            //base.CompanyInfoId = Program.UserSettings.CompanyID;
            //base.BranchId = Program.UserSettings.BranchID;
            //base.luCode = luCode;
            //base.lblBaseNewEntry = lblNewEntry;
            //base.dErr = dxErr;

        }


       

    


   

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSaveNClear_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
               
            }

        }

        private void frmGroups_Load(object sender, EventArgs e)
        {
            //if (PageMode == IIPageMode.Edit)
            //{
            //    string oldValue = luCode.Text;
            //    BindCode();
            //    luCode.Text = oldValue;
            //    luCode.Focus();
            //}
            //else
            //{
            //    BindCode();
            //    luCode.Focus();
            //}

            //xtMain.SelectedTabPage = tpUsers;
        }

       

        bool IsValidating = false;

   
        private void luCode_Leave(object sender, EventArgs e)
        {
            if (this.ActiveControl.Name.Equals(btnCancel.Name))
            {
               return;
            }

            if (luCode.Text.Trim().Equals(string.Empty))
                luCode.EditValue = null;
            if (!IsValidating && !luCode.Text.Trim().Equals(string.Empty))
            {
                dxErr.SetError(luCode, null);
                if (IsValueChanged)
                {
                //    if (GetByCode(luCode.Text.Trim(), false))
                //    {
                //        IsValueChanged = false;
                //    }
                //    else
                //    {
                //        IsValueChanged = true;
                //        luCode.Focus();
                //    }
                   
                }
            }
            if (!luCode.IsModified)
                luCode.DoValidate();
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
             //txtName.Text = txtName.Text.Trim();
             //if (!IsValidating && !txtName.Text.Trim().Equals(string.Empty))
             //{
             //    dxErr.SetError(txtName, null);
             //}
        }

        //private void luCode_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        //{
        //    if (e.DisplayValue == null || string.Empty.Equals(e.DisplayValue))
        //        return;

        //    if (dsBind.Tables[Tables.ExistingData].Rows.Count > 0)
        //    {
        //        DataRow dr = dsBind.Tables[Tables.ExistingData].Rows[dsBind.Tables[Tables.ExistingData].Rows.Count - 1];
        //        if (dr[1] == "New Group")
        //        {
        //            dr[0] = e.DisplayValue.ToString();
        //            dr[1] = "New Group";
        //        }
        //        else
        //        {
        //            dr = dsBind.Tables[Tables.ExistingData].NewRow();
        //            dr[0] = e.DisplayValue.ToString();
        //            dr[1] = "New Group";
        //            dsBind.Tables[Tables.ExistingData].Rows.Add(dr);
        //        }
        //    }
        //    else
        //    {
        //        DataRow dr = dsBind.Tables[Tables.ExistingData].NewRow();
        //        dr[0] = e.DisplayValue.ToString();
        //        dr[1] = "New Group";
        //        dsBind.Tables[Tables.ExistingData].Rows.Add(dr);
        //    }
        //    e.Handled = true;
        //}


        private bool CheckChangeCode()
        {
            //if (base.iiDataSet.Tables[TableName].Rows.Count > 0)
            //{
            //    if (base.iiDataSet.Tables[TableName].Rows[0][Groups.Code] != luCode.Text)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //else
            //{
            //    return true;
            //}
            return true;
        }

        bool IsValueChanged = false;

        private void luCode_Modified(object sender, EventArgs e)
        {
            IsValueChanged = true;
        }

        private void chkActive_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Return)
            //{
            //    SendKeys.Send("{TAB}");
            //    e.Handled = true;
            //}
            //else
            //{
            //    this.IsChanged = true;
            //}
        }

        private void xtMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }


       
        private void txtName_Modified(object sender, EventArgs e)
        {
            
        }

        private void lstUsers_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            

        }

        private void luCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (luCode.Text.Equals(string.Empty))
                luCode.EditValue = null;
        }

        //private void luCode_Closed(object sender, ClosedEventArgs e)
        //{
        //    if (isTab)
        //    {
        //        isTab = false;
        //        return;
        //    }
        //    if (!luCode.Text.Trim().Equals(String.Empty))
        //        SendKeys.Send("{TAB}");
        //}

        private void luCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                isTab = true;
        }

        private void luCode_EditValueChanged(object sender, EventArgs e)
        {
            
        }






    }
}