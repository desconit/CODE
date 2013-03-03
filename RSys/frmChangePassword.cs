using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;
using DESCONIT.BLL;

namespace RSys
{
    public partial class frmChangePassword : DevExpress.XtraEditors.XtraForm
    {
        bool isCalledForSuperAdmin = false;
        internal bool isSuccess = false;
        string superAdminPassword = "";
        
        public frmChangePassword()
        {
            InitializeComponent();
            

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validation())
                    return;
                BLL bll = new BLL(Program.clsuser.CurrentDB);

                Hashtable ht = new Hashtable();
               
                ht.Add(Employees.ID, Program.clsuser.UserID);
                ht.Add(Employees.Password, txtNewPass.Text);
                bll.ExecuteSP("usp_ChangePassword", ht);
                Program.clsuser.Password = txtNewPass.Text;
                
               
               
                Messages.Information("Password changed successfully.");
                this.isSuccess = true;
                this.Close();
            }
            catch (Exception ex)
            {
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        private bool Validation()
        {
            bool isValid = true;

           

            if (txtConfirmPass.Text.Trim().Equals(string.Empty))
            {
                isValid = false;
                Err.SetError(txtConfirmPass, "Must enter confirm password.");
                txtConfirmPass.Focus();
            }
            else
            {
                Err.SetError(txtConfirmPass, null);
            }

            if (txtNewPass.Text.Trim().Equals(string.Empty))
            {
                isValid = false;
                Err.SetError(txtNewPass, "Must enter confirm password.");
                txtNewPass.Focus();
            }
            else
            {
                Err.SetError(txtNewPass, null);
            }




           



            if (txtOldPass.Text.Trim().Equals(string.Empty))
            {
                isValid = false;
                Err.SetError(txtOldPass, "Must enter password.");
                txtOldPass.Focus();
            }
            else if(isCalledForSuperAdmin)
            {
                if (!txtOldPass.Text.Trim().Equals(string.Empty) && !txtOldPass.Text.Trim().Equals(superAdminPassword))
                {
                    isValid = false;
                    Err.SetError(txtOldPass, "Must enter correct password.");
                    txtOldPass.Focus();
                }
                else
                {
                    Err.SetError(txtOldPass, null);
                }
            }
            else if(!isCalledForSuperAdmin)
            {

                if (!txtOldPass.Text.Trim().Equals(string.Empty) && !txtOldPass.Text.Trim().Equals(Program.clsuser.Password))
                {
                    isValid = false;
                    Err.SetError(txtOldPass, "Must enter correct password.");
                    txtOldPass.Focus();
                }
                else
                {
                    Err.SetError(txtOldPass, null);
                }
            }
            else
            {
                Err.SetError(txtOldPass, null);
            }


            if (!txtNewPass.Text.Trim().Equals(string.Empty) && !txtConfirmPass.Text.Trim().Equals(string.Empty))
            {
                if(!txtNewPass.Text.Trim().Equals(txtConfirmPass.Text.Trim()))
                {
                    Err.SetError(txtNewPass, "New password and confirm password don't match.");
                    txtNewPass.Focus();
                    isValid = false;
                }
                else
                {
                    Err.SetError(txtNewPass, null);
                }
            }


            if (txtNewPass.Text.Equals(txtConfirmPass.Text))
            {
                if (txtOldPass.Text.Equals(txtNewPass.Text))
                {
                    Err.SetError(txtOldPass, "Old and new passwords can not be the same.");
                    Err.SetError(txtNewPass, "Old and new passwords can not be the same.");
                    txtOldPass.Focus();
                    isValid = false;
                }

                if (!Functions.IsPasswordStrong(txtNewPass.Text))
                {
                    Err.SetError(txtNewPass, "Your password must be 6 to 15 characters long. Password should contain an uppercase,a lowercase and a digit.");
                    txtNewPass.Focus();
                    isValid = false;
                }


            }


            return isValid;
        
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        

    }
}