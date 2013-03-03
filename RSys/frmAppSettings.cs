using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using DESCONIT.BLL;


namespace RSys
{
    public partial class frmAppSettings : DevExpress.XtraEditors.XtraForm
    {

        
        BLL bll = new BLL(Tables.AppSettings, Program.clsuser.CurrentDB, Program.clsuser.UserID);
        DataSet dsMain;
        bool isEdit;

        public frmAppSettings()
        {
            InitializeComponent();
            dsMain = bll.Search();
            BindFields();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BindFields()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
            }
            finally
            { 
            }
        }

        private void txtSagePath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {

            }
            finally
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private bool Validattion()
        {
            bool check = true;
            Err.ClearErrors();



            if (txtSageConfimPwd.Text != txtSagePwd.Text)
            {
                Err.SetError(txtSagePwd, "Password and confirm password don't match.");
                txtSagePwd.Focus();
                check = false;
            }
            else
            {
                Err.SetError(txtSagePwd, null);
            }

            if (txtSageUser.Text == string.Empty)
            {
                Err.SetError(txtSageUser, "Please enter sage user.");
                txtSageUser.Focus();
                check = false;
            }
            else
            {
                Err.SetError(txtSageUser, null);
            }

            if (txtSagePath.Text == string.Empty || !Directory.Exists(txtSagePath.Text))
            {
                Err.SetError(txtSagePath, "Please enter a valid sage path.");
                txtSagePath.Focus();
                check = false;
            }
            else
            {
                Err.SetError(txtSagePath, null);
            }

            

            return check;

        }
    }
}