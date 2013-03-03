using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using System.Configuration;
using System.IO;
using DESCONIT.BLL;


namespace RSys
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        frmDiaryActions _frmDiaryActions;
        public bool isCalledFromLogout = false;

        /// <summary>
        /// Conatct IDs to use to filter Contact screen.
        int ClientContact = -1, User= -1, Candidate= -1;
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.UserSkins.OfficeSkins.Register();

            EnableDisable(false);
            this.IsMdiContainer = true;
        }

        private void btnLogin_ItemClick(object sender, ItemClickEventArgs e)
        {


            if ((btnLogin.Caption.ToLower().Equals("login")))
            {
                //btnLogin.Caption = "Logout"
                ClearStatusBars();
                CallLogin();

            }
            else
            {
                //btnLogin.Caption = "Login"
                EnableDisable(false);
                CloseAllForms();
                ClearStatusBars();

            }


        }

        private void ClearStatusBars()
        {
            barUser.Caption = string.Empty;
            barCompany.Caption = string.Empty;
            barLoginTime.Caption = string.Empty;
        }



        public void EnableDisable(bool flg)
        {
            if ((flg))
            {
                btnLogin.Caption = "Logout";
            }
            else
            {
                btnLogin.Caption = "Login";
                this.CloseAllForms();
            }

            //btnLogin.Enabled = Not flg
            
            
            
            
            mnuTheme.Enabled = flg;
            pgCompany.Visible = flg;
            pgContacts.Visible = flg;
            pgRequirement.Visible = flg;
            rpWeeklyPlan.Visible = flg;
            rpPlacements.Visible = flg;
            btnChangePass.Enabled = flg;
            btnSecurity.Enabled = flg;
            btnCompanyHQ.Enabled = flg;
            btnAttachments.Enabled = flg;
            pgCanvasing.Visible = flg;



            
        }

        private void CloseAllForms()
        {
            Form[] forms = this.MdiChildren;

            isCalledFromLogout = true;
            if ((forms.Length > 0))
            {
                foreach (Form frm in forms)
                {
                    frm.Close();
                    frm.Dispose();
                }
            }

            
        }

        public void RefreshDiaryActions()
        {
            _frmDiaryActions.RefreshData();
        }

        private void CallLogin()
        {
            frmLogin frm = new frmLogin();
            frm.Owner = this;
            frm.ShowDialog();

            //if (frm.IsValidated)
            //{
            //    if (!Functions.IsPasswordStrong(Program.clsuser.Password))
            //    {
            //        Messages.Error("Password must be 6-15 digits, with a mix of letters, numbers & capitals.");

            //        frmChangePassword frmPass = new frmChangePassword();
            //        frmPass.Owner = this;
            //        frmPass.ShowInTaskbar = false;
            //        frmPass.StartPosition = FormStartPosition.CenterScreen;
            //        frmPass.ShowDialog();
            //        if (frmPass.isSuccess)
            //        {
            //            this.EnableDisable(true);
            //            this.LoadDiaryAction();
            //        }
            //    }
            //    else
            //    {
            //        this.EnableDisable(true);
            //        this.LoadDiaryAction();
            //    }
            //}
            //else
            //{
            //    frm.ShowDialog();

            //}
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = Constants.AppTitle;
            Program.clsuser.AttachmentPath = "C:\\Temp";
            try
            {
                UserLookAndFeel dfLooknFeel = UserLookAndFeel.Default;
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                dfLooknFeel.SkinName = config.AppSettings.Settings["Theme"].Value;
                BuildInfo();
                //SetChkBox(dfLooknFeel.SkinName)

                foreach (SkinContainer cnt in SkinManager.Default.Skins)
                {
                    BarCheckItem item = new BarCheckItem(new BarManager(), false);
                    //item.Toggle()
                    item.Name = "SKN" + cnt.SkinName;
                    item.Caption = cnt.SkinName;
                    mnuTheme.ItemLinks.Add(item, false);

                    item.ItemClick += chkCaramel_CheckedChanged;
                    if (dfLooknFeel.SkinName.Equals(cnt.SkinName))
                    {
                        item.Checked = true;
                    }
                }



            }
            catch (Exception ex)
            {
            }

            btnLogin_ItemClick(null, null);

        }

        private void chkCaramel_CheckedChanged(System.Object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UserLookAndFeel dfLooknFeel = UserLookAndFeel.Default;

                ClearAllThemeChks();
                dfLooknFeel.SkinName = e.Item.Caption;

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["Theme"].Value = e.Item.Caption;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                //SetChkBox(e.Item.Caption)

                (e.Item as BarCheckItem).Checked = true;
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




        private void BuildInfo()
        {
            System.IO.FileInfo arch = new System.IO.FileInfo(Application.ExecutablePath.ToString());
            string buildInfo = string.Format("{0:dd MMMM yyyy}", arch.LastWriteTime);
            this.barBuildInfo.Caption = "RELEASE DATE: " + buildInfo;
            this.barVersion.Caption = "VERSION: " + Constants.AppVersion;
        }

        private void ClearAllThemeChks()
        {
            for (int i = 0; i <= mnuTheme.ItemLinks.Count - 1; i++)
            {
                (mnuTheme.ItemLinks[i].Item as BarCheckItem).Checked = false;
            }

        }

        private void btnUsers_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Program.clsuser.isAdmin)
            {
                Messages.Error("You don't have previliges to view this screen.");
            }
            else
            {
                //frmUser frm = new frmUser();
                //frm.ShowDialog();
            }
        }

        private void btnCurrencies_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (!Program.clsuser.isAdmin)
            {
                Messages.Error("You don't have previliges to view this screen.");
                return;
            }

            //frmRoles frm = new frmRoles();
            //frm.ShowDialog();
        }

       

       
      

       
     

       

       

        private void btnAppSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Program.clsuser.isAdmin)
            {
                Messages.Error("You don't have previliges to view this screen.");
            }
            else
            {
                frmAppSettings frm = new frmAppSettings();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
        }

       
        private void btnBranches_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Program.clsuser.isAdmin)
            {
                Messages.Error("You don't have previliges to view this screen.");
                return;
            }

            
            try
            {
                frmBranches frm = new frmBranches();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
        }


        frmCompaniesVW _frmCompaniesVW;
        private void btnCompanyHQ_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Program.clsuser.isAdmin)
            {
                Messages.Error("You don't have previliges to view this screen.");
                return;
            }
            try
            {
                if (_frmCompaniesVW == null || _frmCompaniesVW.IsDisposed)
                {
                    _frmCompaniesVW = new frmCompaniesVW();
                    _frmCompaniesVW.Owner = this;
                    _frmCompaniesVW.MdiParent = this;
                    _frmCompaniesVW.Show();

                }
                else
                {
                     //_frmCompaniesVW.RefreshData();
                    _frmCompaniesVW.Show();
                    _frmCompaniesVW.BringToFront();
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

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Program.clsuser.isAdmin)
            {
                Messages.Error("You don't have previliges to view this screen.");
                return;
            }
            try
            {
                frmAttachments frm = new frmAttachments();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        
        

        
        
        
        private void btnAttachmentTypes_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Program.clsuser.isAdmin)
            {
                Messages.Error("You don't have previliges to view this screen.");
                return;
            }
            try
            {
                frmAttachmentTypes frm = new frmAttachmentTypes(true);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

       
       
       
       
       
        private void btnMainCounties_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmCounties frm = new frmCounties();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        private void btnMainCountries_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmCountries frm = new frmCountries();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        private void btnMainIndustry_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmIndustries frm = new frmIndustries();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        private void btnTimeSheetFrequency_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTimeSheetFrequency frm = new frmTimeSheetFrequency();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        private void btnClientStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmStatus frm = new frmStatus(false);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        private void btnJobTitle_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmJobTitles frm = new frmJobTitles();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        private void btnTrade_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTrades frm = new frmTrades();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        private void btnStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmStatus frm = new frmStatus(true);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        private void btnTypeofWork_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmWorkTypes frm = new frmWorkTypes();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        private void btnContactType_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmContactTypes frm = new frmContactTypes();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        frmContactsVW _frmContactsVW;
        private void btnContacts_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Program.clsuser.isAdmin)
            {
                Messages.Error("You don't have previliges to view this screen.");
                return;
            }
            try
            {
                if (_frmContactsVW == null || _frmContactsVW.IsDisposed)
                {
                    _frmContactsVW = new frmContactsVW();
                    _frmContactsVW.Owner = this;
                    _frmContactsVW.MdiParent = this;
                    _frmContactsVW.Show();

                }
                else
                {
                    _frmContactsVW.RefreshGrid();
                    _frmContactsVW.Show();
                    _frmContactsVW.BringToFront();
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


        public void LoadDiaryAction()
        {
            isCalledFromLogout = false;
            if (!Program.clsuser.isAdmin)
            {
                Messages.Error("You don't have previliges to view this screen.");
                return;
            }
            try
            {
                if (_frmDiaryActions == null || _frmDiaryActions.IsDisposed)
                {
                    _frmDiaryActions = new frmDiaryActions();
                    //_frmDiaryActions.Owner = this;
                    _frmDiaryActions.MdiParent = this;
                    _frmDiaryActions.Show();

                }
                else
                {
                    _frmDiaryActions.BringToFront();
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

        private void btnPaymentMethod_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmPaymentMethods frm = new frmPaymentMethods();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        private void btnPaymentStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmPaymentTypes frm = new frmPaymentTypes();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        private void btnContactAttType_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmAttachmentTypes frm = new frmAttachmentTypes(true);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        private void btnClientAttType_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmAttachmentTypes frm = new frmAttachmentTypes(false);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        private void btnGroups_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmGroups frm = new frmGroups();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        private void btnSecurity_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmGroups frm = new frmGroups();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.isCalledFromLogout = true;

            Form[] forms = this.MdiChildren;

            
            if ((forms.Length > 0))
            {
                foreach (Form frm in forms)
                {
                    if (frm.Name == _frmDiaryActions.Name)
                    {
                        frm.Close();
                        frm.Dispose();
                    }
                }
            }

            isCalledFromLogout = false;
        }

        private void btnJobStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmJobStatus frm = new frmJobStatus();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        private void btnRateTypes_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmRateType frm = new frmRateType();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        private void btnRateFrequencies_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmRateFrequencies frm = new frmRateFrequencies();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        frmRequirementsVW _frmRequirementsVW;
        

        private void btnRequirement_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Program.clsuser.isAdmin)
            {
                Messages.Error("You don't have previliges to view this screen.");
                return;
            }
            try
            {
                if (_frmRequirementsVW == null || _frmRequirementsVW.IsDisposed)
                {
                    _frmRequirementsVW = new frmRequirementsVW();
                    _frmRequirementsVW.Owner = this;
                    _frmRequirementsVW.MdiParent = this;
                    _frmRequirementsVW.Show();

                }
                else
                {
                   //_frmRequirementsVW.RefreshData();
                    _frmRequirementsVW.Show();
                    _frmRequirementsVW.BringToFront();
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

        private void btnTickets_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTickets frm = new frmTickets();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        private void btnTicketTypes_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTicketTypes frm = new frmTicketTypes();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        frmContactsVW _frmClientContactVw;
        private void btnClientContact_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitializeContactIDs();

            try
            {
                if (_frmClientContactVw == null || _frmClientContactVw.IsDisposed)
                {
                    _frmClientContactVw = new frmContactsVW(ClientContact);
                    _frmClientContactVw.Owner = this;
                    _frmClientContactVw.MdiParent = this;
                    _frmClientContactVw.Text = "Client Contacts";
                    _frmClientContactVw.Show();

                }
                else
                {
                    _frmClientContactVw.RefreshData(null);
                    _frmClientContactVw.MdiParent = this;
                    _frmClientContactVw.Text = "Client Contacts";
                    _frmClientContactVw.Show();

                    _frmClientContactVw.BringToFront();
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

        private void InitializeContactIDs()
        {
            if (ClientContact != -1)
                return; ///already intialized
            
            BLL bll = new BLL(Tables.ContactTypes, Program.clsuser.CurrentDB, Program.clsuser.UserID);

            DataSet ds = bll.Search();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i][ContactTypes.Name].ToString().StartsWith("client", StringComparison.OrdinalIgnoreCase))
                    ClientContact = Convert.ToInt32(ds.Tables[0].Rows[i][ContactTypes.ID]);
                else if(ds.Tables[0].Rows[i][ContactTypes.Name].ToString().StartsWith("user", StringComparison.OrdinalIgnoreCase))
                    User = Convert.ToInt32(ds.Tables[0].Rows[i][ContactTypes.ID]);
                else if (ds.Tables[0].Rows[i][ContactTypes.Name].ToString().StartsWith("candidate", StringComparison.OrdinalIgnoreCase))
                    Candidate = Convert.ToInt32(ds.Tables[0].Rows[i][ContactTypes.ID]);
            }
        }

        frmContactsVW _frmCandidateContactVw;
        private void btnCandidates_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitializeContactIDs();

            try
            {
                if (_frmCandidateContactVw == null || _frmCandidateContactVw.IsDisposed)
                {
                    _frmCandidateContactVw = new frmContactsVW(Candidate);
                    _frmCandidateContactVw.Owner = this;
                    _frmCandidateContactVw.MdiParent = this;
                    _frmCandidateContactVw.Text = "Candidates";
                    _frmCandidateContactVw.Show();

                }
                else
                {
                    _frmCandidateContactVw.RefreshData(null);
                    _frmCandidateContactVw.Text = "Candidates";
                    _frmCandidateContactVw.Show();
                    _frmCandidateContactVw.BringToFront();
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

        frmContactsVW _frmUserContactVw;
        private void btnUsers_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            InitializeContactIDs();

            try
            {
                if (_frmUserContactVw == null || _frmUserContactVw.IsDisposed)
                {
                    _frmUserContactVw = new frmContactsVW(User);
                    _frmUserContactVw.Owner = this;
                    _frmUserContactVw.MdiParent = this;
                    _frmUserContactVw.Text = "Users";
                    _frmUserContactVw.Show();

                }
                else
                {
                  _frmContactsVW.RefreshData(null);
                    _frmUserContactVw.Text = "Users";
                    _frmUserContactVw.Show();
                    _frmUserContactVw.BringToFront();
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

        private void btnClientsAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnCompanyHQ_ItemClick(null, null);

            _frmCompaniesVW.btnAdd_Click(null, null);

            
        }

        private void btnClientsEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnCompanyHQ_ItemClick(null, null);

            _frmCompaniesVW.btnEdit_Click(null, null);
        }

        private void btnClientsDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnCompanyHQ_ItemClick(null, null);

            _frmCompaniesVW.btnDelete_Click(null, null);
        }

        private void btnContactAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnContacts_ItemClick(null, null);
            _frmContactsVW.btnAdd_Click(null, null);
        }

        private void btnAddQuickCandidate_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnCandidates_ItemClick(null, null);
            _frmCandidateContactVw.btnQuickAdd_Click(null, null);
        }

        private void btnContactEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnContacts_ItemClick(null, null);
            _frmContactsVW.btnEdit_Click(null, null);
        }

        private void btnContactDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnContacts_ItemClick(null, null);
            _frmContactsVW.btnDelete_Click(null, null);
        }

        private void btnRequirementAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnRequirement_ItemClick(null, null);
            _frmRequirementsVW.btnAdd_Click(null, null);
        }

        private void btnRequirementEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnRequirement_ItemClick(null, null);
            _frmRequirementsVW.btnEdit_Click(null, null);
        }

        private void btnRequirementDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnRequirement_ItemClick(null, null);
            _frmRequirementsVW.btnDelete_Click(null, null);
        }

        private void btnClientContactAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnClientContact_ItemClick(null, null);
            _frmClientContactVw.btnAdd_Click(null, null);
        }

        private void btnClientContactEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnClientContact_ItemClick(null, null);
            _frmClientContactVw.btnEdit_Click(null, null);
        }

        private void btnCandidateAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnCandidates_ItemClick(null, null);
            _frmCandidateContactVw.btnAdd_Click(null, null);
        }

        private void btnCandidateEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnCandidates_ItemClick(null, null);
            _frmCandidateContactVw.btnEdit_Click(null, null);
        }

        private void btnUserAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnUsers_ItemClick_1(null, null);
            _frmUserContactVw.btnAdd_Click(null, null);
        }

        private void btnUserEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnUsers_ItemClick_1(null, null);
            _frmUserContactVw.btnEdit_Click(null, null);
        }

        FrmPlacementsVW _frmPlacementsVW;
        frmWeeklyPlanVW _frmWeeklyPlansVW;
        frmRequirementSearch _frmRequirmentsSearch;
        frmSetUpPlacement _frmSetUpPlacement;

        private void bbViewPlacements_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_frmPlacementsVW == null || _frmPlacementsVW.IsDisposed)
            {
                _frmPlacementsVW = new FrmPlacementsVW();
                _frmPlacementsVW.Owner = this;
                _frmPlacementsVW.MdiParent = this;
                _frmPlacementsVW.Show();

            }
            else
            {
                _frmPlacementsVW.RefreshData(null);
                _frmPlacementsVW.Show();
                _frmPlacementsVW.BringToFront();
            }
        }

        private void bbWeeklyPlans_ItemClick(object sender, ItemClickEventArgs e)
        {
            //open weekly plan
            if (_frmWeeklyPlansVW == null || _frmWeeklyPlansVW.IsDisposed)
            {
                _frmWeeklyPlansVW = new frmWeeklyPlanVW();
                _frmWeeklyPlansVW.Owner = this;
                _frmWeeklyPlansVW.MdiParent = this;
                _frmWeeklyPlansVW.Show();
            }
            else
            {
                _frmWeeklyPlansVW = new frmWeeklyPlanVW();
                _frmWeeklyPlansVW.Owner = this;
                _frmWeeklyPlansVW.MdiParent = this;
                _frmWeeklyPlansVW.Show();
                _frmWeeklyPlansVW.BringToFront();
                
            }
        }

        private void btnFindCandidates_ItemClick(object sender, ItemClickEventArgs e)
        {
            //open weekly plan
            if (_frmRequirmentsSearch == null || _frmRequirmentsSearch.IsDisposed)
            {
                _frmRequirmentsSearch = new frmRequirementSearch(true);
                _frmRequirmentsSearch.Owner = this;
                _frmRequirmentsSearch.MdiParent = this;
                _frmRequirmentsSearch.Show();
            }
            else
            {
                _frmRequirmentsSearch.Close();

                _frmRequirmentsSearch = new frmRequirementSearch(true);
                _frmRequirmentsSearch.Owner = this;
                _frmRequirmentsSearch.MdiParent = this;
                _frmRequirmentsSearch.Show();

            }
        }

        private void btnQuickAddClientContact_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnClientConctactQuickAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnClientContact_ItemClick(null, null);
            _frmClientContactVw.btnClientContactQuickAdd(null, null);
           
        }

        private void btnRequirementType_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bbCreatePlacement_ItemClick(object sender, ItemClickEventArgs e)
        {
            //open weekly plan
            if (_frmSetUpPlacement == null || _frmSetUpPlacement.IsDisposed)
            {
                _frmSetUpPlacement = new frmSetUpPlacement();
                _frmSetUpPlacement.Owner = this;
                _frmSetUpPlacement.MdiParent = this;
                _frmSetUpPlacement.Show();
            }
            else
            {
                _frmSetUpPlacement.Close();

                _frmSetUpPlacement = new frmSetUpPlacement();
                _frmSetUpPlacement.Owner = this;
                _frmSetUpPlacement.MdiParent = this;
                _frmSetUpPlacement.Show();

            }
        }

        private void btnPlacementWizard_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmPlacementWizard frm = new frmPlacementWizard();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

        frmCanvassingClientVW _frmCanvassingClientVW;
        private void btnCanvasing_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (_frmCanvassingClientVW == null || _frmCanvassingClientVW.IsDisposed)
                {
                    _frmCanvassingClientVW = new frmCanvassingClientVW();
                    _frmCanvassingClientVW.Owner = this;
                    _frmCanvassingClientVW.MdiParent = this;
                   _frmCanvassingClientVW.Show();

                }
                else
                {
                    //_frmCanvassingClientVW.RefreshData();
                    _frmCanvassingClientVW.MdiParent = this;
                    _frmCanvassingClientVW.Show();
                    _frmCanvassingClientVW.BringToFront();
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

        frmCompaniesVW _frmMyCompaniesVW;
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            try
            {
                if (_frmMyCompaniesVW == null || _frmMyCompaniesVW.IsDisposed)
                {
                    _frmMyCompaniesVW = new frmCompaniesVW(Program.clsuser.UserID);
                    _frmMyCompaniesVW.Owner = this;
                    _frmMyCompaniesVW.MdiParent = this;
                    _frmMyCompaniesVW.Show();

                }
                else
                {
                    _frmMyCompaniesVW.RefreshData();
                    _frmMyCompaniesVW.Show();
                    _frmMyCompaniesVW.BringToFront();
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


        frmRequirementsVW _frmMyRequirementsVW;
        private void btnMyJobs_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (_frmMyRequirementsVW == null || _frmMyRequirementsVW.IsDisposed)
                {
                    _frmMyRequirementsVW = new frmRequirementsVW(Program.clsuser.UserID);
                    _frmMyRequirementsVW.Owner = this;
                    _frmMyRequirementsVW.MdiParent = this;
                    _frmMyRequirementsVW.Show();

                }
                else
                {
                    _frmMyRequirementsVW.RefreshData();
                    _frmMyRequirementsVW.Show();
                    _frmMyRequirementsVW.BringToFront();
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

        private void btnCanvasingAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnCanvasing_ItemClick(null, null);

            _frmCanvassingClientVW.btnAdd_Click(null, null);
        }

        private void btnCanvasingEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnCanvasing_ItemClick(null, null);

            _frmCanvassingClientVW.btnEdit_Click(null, null);
        }

        private void barButtonItem2_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            btnPlacementWizard_ItemClick(null, null);
        }

        private void btnChangePass_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmChangePassword frm = new frmChangePassword();
                frm.Owner = this;
                frm.ShowInTaskbar = false;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();

            }
            catch (Exception ex)
            {
                Messages.Error(ex.Message);
            }
            finally
            { }
        }

       
        
    }
}