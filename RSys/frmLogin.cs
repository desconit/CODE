using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Configuration;
using System.Collections.Specialized;
using System.IO;
using System.Collections;
using DESCONIT.BLL;

namespace RSys
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {


        internal bool IsValidated = false;
        
        public frmLogin()
        {
            InitializeComponent();
            cmbDB.SelectedIndex = -1;
            GetUserValues();
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!Validation())
                return;

            CheckAppVersion();

            try
            {
                Program.clsuser.CurrentDB = cmbDB.Text;

                BLL bll = new BLL(Tables.Employees, Program.clsuser.CurrentDB);
                Hashtable ht = new Hashtable();

                ht.Add(Employees.Email, txtUserId.Text);
               // ht.Add(Employees.Email, luUser.Text);
                ht.Add(Employees.Password, txtPass.Text);

                DataSet ds = bll.ExecuteSP("usp_EmployeesLogin", ht);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Program.clsuser.UserID = Convert.ToInt32(ds.Tables[0].Rows[0][Employees.ID]);
                    Program.clsuser.UserName = ds.Tables[0].Rows[0][Employees.FirstName].ToString() + " " + ds.Tables[0].Rows[0][Employees.LastName].ToString();
                    Program.clsuser.Password = txtPass.Text;
                    Program.clsuser.CurrentDB = cmbDB.Text;
                    //Program.clsuser.CurrentDB = "RSys";
                    Program.clsuser.CompanyName = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                    Program.clsuser.BranchName = ds.Tables[0].Rows[0]["BranchName"].ToString();
                    Program.clsuser.CompanyID = Convert.ToInt32(ds.Tables[0].Rows[0]["CompanyID"].ToString());
                    Program.clsuser.BranchID = Convert.ToInt32(ds.Tables[0].Rows[0]["BranchID"].ToString());
                    //Program.clsuser.isAdmin = Convert.ToBoolean( ds.Tables[0].Rows[0]["Company]);

                    Program.clsuser.HomeCountryID = Convert.ToInt32(ds.Tables[0].Rows[0][Persons.CountriesID].ToString());
                    Program.clsuser.HomeCountryName = ds.Tables[0].Rows[0]["CountryName"].ToString();

                    ((frmMain)this.Owner).barUser.Caption = "USER: " + Program.clsuser.UserName;
                    ((frmMain)this.Owner).barCompany.Caption = "COMPANY: " + Program.clsuser.CompanyName;

                    if (Program.clsuser.BranchID != Program.clsuser.CompanyID)
                        ((frmMain)this.Owner).barBranch.Caption = "BRANCH: " + Program.clsuser.CompanyName;
                    else
                        ((frmMain)this.Owner).barBranch.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    

                    ((frmMain)this.Owner).barLoginTime.Caption = "LOGGED AT: " + DateTime.Now.ToShortTimeString();

                    //((frmMain)this.Owner).EnableDisable(true);


                    this.IsValidated = true;

                    CheckPasswordValidity();
                    this.Close();
                }
                else
                {
                    Messages.Error("Login and password don't match.");
                }
               
                SaveValues();
                //this.Visible = false;
                //this.Close();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
               
        }

        private void CheckPasswordValidity()
        {
            if (this.IsValidated)
            {
                if (!Functions.IsPasswordStrong(Program.clsuser.Password))
                {
                    Messages.Error("Password must be 6-15 digits, with a mix of letters, numbers & capitals.");

                    frmChangePassword frmPass = new frmChangePassword();
                    frmPass.Owner = this;
                    frmPass.ShowInTaskbar = false;
                    frmPass.StartPosition = FormStartPosition.CenterScreen;
                    frmPass.ShowDialog();
                    if (frmPass.isSuccess)
                    {
                        ((frmMain)(this.Owner)).EnableDisable(true);
                        ((frmMain)(this.Owner)).LoadDiaryAction();
                    }
                }
                else
                {
                    ((frmMain)(this.Owner)).EnableDisable(true);
                    ((frmMain)(this.Owner)).LoadDiaryAction();
                }
            }
            else
            {
                //frm.ShowDialog();

            }
        }

        private void GetUserValues()
        {
            NameValueCollection AppSettings = ConfigurationManager.AppSettings;
            string UserID = null;
            string Password = null;

            UserID = AppSettings["CurrUserID"].ToString();
            Password = Functions.Decrypt( AppSettings["CurrUserPass"].ToString(), Functions.GenerateAPassKey( "UserPasswordStr"));
            cmbDB.Text = AppSettings["CurrDB"].ToString();
            chkRememberMe.Checked = !string.IsNullOrEmpty(UserID);
            chkRememberPass.Checked = !string.IsNullOrEmpty(Password);
            
            this.txtUserId.Text = UserID;
            //this.luUser.EditValue = UserID;
            this.txtPass.Text = Password;

            if (UserID.Equals(string.Empty))
            {
                txtUserId.Focus();
                this.ActiveControl = txtUserId;
                //luUser.Focus();
                this.ActiveControl = luUser;
            }
            else
            {
                txtPass.Focus();
                this.ActiveControl = txtPass;
            }
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //config.ConnectionStrings[0]["CurrUserPass"].Value = "";
            ////config.AppSettings.Settings["CurrUserPass"].Value = "";
            ToggleConnectionStringProtection (System.Windows.Forms.Application.ExecutablePath, true);
        }

        private bool Validation()
        {
            bool check = true;
            Err.ClearErrors();

            if ((cmbDB.Text.Equals(string.Empty)))
            {
                Err.SetError(cmbDB, "Please select database.");
                cmbDB.Focus();
                check = false;
            }
            else
            {
                Err.SetError(cmbDB, null);
            }


            if (txtPass.Text.Trim().Equals(string.Empty))
            {
                Err.SetError(txtPass, "Please enter password.");
                txtPass.Focus();
                check = false;
            }
            else
            {
                Err.SetError(txtPass, null);
            }

            if (txtUserId.Text.Trim().Equals(string.Empty))
            {
                Err.SetError(txtUserId, "Please enter user id.");
                txtUserId.Focus();
                check = false;
            }
            else
            {
                Err.SetError(txtUserId, null);
            }



            return check;


        }

        private void SaveValues()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string UserID = null;
            string Password = null;


            if (chkRememberMe.Checked)
            {
               
                config.AppSettings.Settings["CurrUserID"].Value = txtUserId.Text.ToString();
                UserID = luUser.Text;
            }
            else
            {
                config.AppSettings.Settings["CurrUserID"].Value = "";
                UserID = "";
            }

            if (chkRememberPass.Checked)
            {
                config.AppSettings.Settings["CurrUserPass"].Value = Functions.Encrypt(txtPass.Text.ToString(), Functions.GenerateAPassKey("UserPasswordStr")); ;
                Password = txtPass.Text;
            }
            else
            {
                config.AppSettings.Settings["CurrUserPass"].Value = "";
                Password = "";
            }
            config.AppSettings.Settings["CurrDB"].Value = cmbDB.Text;

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void ProtectConnectionString()
        {
            ToggleConnectionStringProtection
        (System.Windows.Forms.Application.ExecutablePath, true);
        }

        public static void UnprotectConnectionString()
        {
            ToggleConnectionStringProtection
        (System.Windows.Forms.Application.ExecutablePath, false);
        }

        private static void ToggleConnectionStringProtection
                (string pathName, bool protect)
        {
            // Define the Dpapi provider name.
            string strProvider = "DataProtectionConfigurationProvider";
            // string strProvider = "RSAProtectedConfigurationProvider";

            System.Configuration.Configuration oConfiguration = null;
            System.Configuration.ConnectionStringsSection oSection = null;

            try
            {
                // Open the configuration file and retrieve 
                // the connectionStrings section.

                // For Web!
                // oConfiguration = System.Web.Configuration.
                //                  WebConfigurationManager.OpenWebConfiguration("~");

                // For Windows!
                // Takes the executable file name without the config extension.
                oConfiguration = System.Configuration.ConfigurationManager.
                                                OpenExeConfiguration(pathName);

                if (oConfiguration != null)
                {
                    bool blnChanged = false;

                    oSection = oConfiguration.GetSection("connectionStrings") as
                System.Configuration.ConnectionStringsSection;

                    if (oSection != null)
                    {
                        if ((!(oSection.ElementInformation.IsLocked)) &&
                (!(oSection.SectionInformation.IsLocked)))
                        {
                            if (protect)
                            {
                                if (!(oSection.SectionInformation.IsProtected))
                                {
                                    blnChanged = true;

                                    // Encrypt the section.
                                    oSection.SectionInformation.ProtectSection
                                (strProvider);
                                }
                            }
                            else
                            {
                                if (oSection.SectionInformation.IsProtected)
                                {
                                    blnChanged = true;

                                    // Remove encryption.
                                    oSection.SectionInformation.UnprotectSection();
                                }
                            }
                        }

                        if (blnChanged)
                        {
                            // Indicates whether the associated configuration section 
                            // will be saved even if it has not been modified.
                            oSection.SectionInformation.ForceSave = true;

                            // Save the current configuration.
                            oConfiguration.Save();
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Functions.LogError(ex);
                
                throw (ex);
            }
            finally
            {
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            

        }

        private void luUser_EditValueChanged(object sender, EventArgs e)
        {
            txtPass.Text = string.Empty;
            txtPass.Focus();
        }

        private void CheckAppVersion()
        {
            BLL bll = new BLL(Program.clsuser.CurrentDB); ;
            Hashtable ht = new Hashtable();
            DataSet ds = new DataSet();
            try
            {
                Program.clsuser.CurrentDB = cmbDB.Text;
                bll = new BLL(Tables.Employees, Program.clsuser.CurrentDB);
                ht = new Hashtable();
                ds = bll.ExecuteSP("usp_AppSettingsGetVersion");
            }
            catch (Exception ex)
            {
                //Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            string EncrpVersion = Functions.Encrypt(Constants.AppVersion.ToString(), Functions.GenerateAPassKey("ApplicaitonVersion"));
            string DecrpVersion = "0";

            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    DecrpVersion = Functions.Decrypt(ds.Tables[0].Rows[0][AppSettings.Version].ToString(), Functions.GenerateAPassKey("ApplicaitonVersion"));

                    if (DecrpVersion.Equals(string.Empty))
                        DecrpVersion = "0";


                    if (Convert.ToDouble(DecrpVersion) < Convert.ToDouble(Constants.AppVersion))
                    {
                        ht = new Hashtable();
                        ht.Add(AppSettings.Version, EncrpVersion);
                        ht.Add(AppSettings.ID, ds.Tables[0].Rows[0][AppSettings.ID]);

                        bll.ExecuteSP("usp_AppSettingsUpdateVersion", ht);
                    }
                    else if (Convert.ToDouble(DecrpVersion) > Convert.ToDouble(Constants.AppVersion))
                    {
                        Messages.Error("You are using an old version (" + Constants.AppVersion + ") of this application. Current version is " + DecrpVersion.ToString() + ", please contact your administrator.\n\nYou cannot proceed.");
                        Application.Exit();
                    }
                    lblVersion.Text = Constants.AppVersion;

                    
                }
                else
                {
                    ht = new Hashtable();
                    ht.Add(AppSettings.Version, EncrpVersion);
                    ht.Add(AppSettings.CreatedBy, Program.clsuser.UserID);

                    bll = new BLL("AppSettings", Program.clsuser.CurrentDB);
                    bll.ExecuteSP("usp_AppSettingsAdd", ht);

                }
            }
            catch (Exception ex)
            {
                Messages.Error("Application version is not set. Please contact your administrator.\n\nYou cannot proceed.");
                Application.Exit();
            }
        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void chkRememberPass_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkRememberMe_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LabelControl2_Click(object sender, EventArgs e)
        {

        }

        private void LabelControl1_Click(object sender, EventArgs e)
        {

        }

        private void txtPass_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtUserId_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbDB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void lblVersion_Click(object sender, EventArgs e)
        {

        }



    }
}