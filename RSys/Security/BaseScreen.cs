using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DESCONIT.BLL;
namespace RSys
{
    public partial class BaseScreen : DevExpress.XtraEditors.XtraForm
    {
        protected DevExpress.XtraEditors.SimpleButton btnBaseAdd;
        protected DevExpress.XtraEditors.SimpleButton btnBaseEdit;
        protected DevExpress.XtraEditors.SimpleButton btnBaseDelete;

        public BaseScreen()
        {
            InitializeComponent();
            this.LoggedInUser = Program.clsuser.UserID;
        }

        public string SystemObjectName = "";
        private String _KeyFieldName;
        public String KeyFieldName
        {
            get { return this._KeyFieldName; }
            set { this._KeyFieldName = value; }
        }

        private int _LoggedInUser;
        public int LoggedInUser
        {
            get { return this._LoggedInUser; }
            set { this._LoggedInUser = value; }
        }

        private int _LoggedInUserGroup;
        public int LoggedInUserGroup
        {
            get { return this._LoggedInUserGroup; }
            set { this._LoggedInUserGroup = value; }
        }

        private String _TableName;
        public String TableName
        {
            get { return this._TableName; }
            set { this._TableName = value; }
        }

        private int _CompanyInfoID;
        public int CompanyInfoId
        {
            get { return this._CompanyInfoID; }
            set { this._CompanyInfoID = value; }
        }

        private int _BranchID;
        public int BranchId
        {
            get { return this._BranchID; }
            set { this._BranchID = value; }
        }

        private Boolean _CanView;
        public Boolean CanView
        {
            get { return this._CanView; }
            set
            {
                if (value != null)
                    this._CanView = value;
                else
                    this._CanView = false;
            }
        }

        private Boolean _CanAdd;
        public Boolean CanAdd
        {
            get { return this._CanAdd; }
            set
            {
                if (value != null)
                    this._CanAdd = value;
                else
                    this._CanAdd = false;
            }
        }

        private Boolean _CanUpdate;
        public Boolean CanUpdate
        {
            get { return this._CanUpdate; }
            set
            {
                if (value != null)
                    this._CanUpdate = value;
                else
                    this._CanUpdate = false;
            }
        }

        private Boolean _CanDelete;
        public Boolean CanDelete
        {
            get { return this._CanDelete; }
            set
            {
                if (value != null)
                    this._CanDelete = value;
                else
                    this._CanDelete = false;
            }
        }

        private Boolean _CanExecute;
        public Boolean CanExecute
        {
            get { return this._CanExecute; }
            set
            {
                if (value != null)
                    this._CanExecute = value;
                else
                    this._CanExecute = false;
            }
        }

        private Boolean _CanPrint;
        public Boolean CanPrint
        {
            get { return this._CanPrint; }
            set
            {
                if (value != null)
                    this._CanPrint = value;
                else
                    this._CanPrint = false;
            }
        }

        private Boolean _IsChanged;
        public Boolean IsChanged
        {
            get { return this._IsChanged; }
            set
            {
                if (value != null)
                    this._IsChanged = value;
                else
                    this._IsChanged = false;
            }
        }

        protected virtual void GetSecuritySettings()
        {
            try
            {
                if (LoggedInUser == 11)//Admin user id
                {
                    CanView = true;
                    CanAdd = true;
                    CanUpdate = true;
                    CanDelete = true;
                    CanExecute = true;
                    CanPrint = true;
                }
                else
                {
                    BLL bll = new BLL(Tables.GroupRights, Program.clsuser.CurrentDB, Program.clsuser.UserID);
                    Hashtable ht = new Hashtable();
                    ht.Add(UserGroups.PersonsID, Program.clsuser.UserID);
                    ht.Add("SystemObjectName", this.SystemObjectName);

                    DataSet ds = bll.ExecuteSP("usp_GetUserSecurity", ht);

                    //ToDo: Replace 
                    if (ds.Tables[0].Rows.Count == 0)
                    {

                        CanView = false;
                        CanAdd = false;
                        CanUpdate = false;
                        CanDelete = false;
                        CanExecute = false;
                        CanPrint = false;
                    }
                    else
                    {
                        SecurityRights sr = FillSecurityRights(ds.Tables[0]);
                        CanView = sr.CanView;
                        CanAdd = sr.CanAdd;
                        CanUpdate = sr.CanUpdate;
                        CanDelete = sr.CanDelete;
                        CanExecute = sr.CanExecute;
                        CanPrint = sr.CanPrint;

                    }

                    //CanView = true;
                    //CanAdd = true;
                    //CanUpdate = true;
                    //CanDelete = true;
                    //CanExecute = true;
                    //CanPrint = true;
                }
            }
            catch (Exception ex)
            {
                // Messages.Error(ex.Message);

                CanView = true;
                CanAdd = true;
                CanUpdate = true;
                CanDelete = true;
                CanExecute = true;
                CanPrint = true;
            }
        }

        private SecurityRights FillSecurityRights(DataTable Table)
        {
            SecurityRights sr = new SecurityRights();
            foreach (DataRow dRow in Table.Rows)
            {
                if (sr.CanExecute == false)
                {
                    sr.CanExecute = (bool)dRow["CanExecute"];
                }

                if (sr.CanAdd == false)
                {
                    sr.CanAdd = (bool)dRow["CanAdd"];
                }

                if (sr.CanDelete == false)
                {
                    sr.CanDelete = (bool)dRow["CanDelete"];
                }

                if (sr.CanUpdate == false)
                {
                    sr.CanUpdate = (bool)dRow["CanUpdate"];
                }

                if (sr.CanView == false)
                {
                    sr.CanView = (bool)dRow["CanView"];
                }

                if (sr.CanPrint == false)
                {
                    sr.CanPrint = (bool)dRow["CanPrint"];
                }
            }
            return sr;
        }



        private void BaseScreen_Load(object sender, EventArgs e)
        {

            try
            {
                GetSecuritySettings();
                IsChanged = false;
                if (CanView.Equals(false))
                {
                    //     Messages.Error(Constants.DontHaveRightsToViewScreen);
                }
                EnforceSecurity();
            }
            catch (Exception ex)
            {
                //  Messages.Error(ex.Message);
            }
        }

        private void BaseScreen_VisibleChanged(object sender, EventArgs e)
        {
            if (CanView.Equals(false))
            {
                this.Close();
            }
            IsChanged = false;
        }

        protected virtual void EnforceSecurity()
        {
            try
            {
                //TODO: put back
                if (btnBaseAdd != null)
                    btnBaseAdd.Enabled = CanAdd;

                if (btnBaseEdit != null)
                    btnBaseEdit.Enabled = CanAdd;

                if (btnBaseEdit != null)
                    btnBaseEdit.Enabled = CanDelete;

                if (btnBaseEdit != null)
                    btnBaseEdit.Enabled = CanUpdate;

                if (btnBaseDelete != null)
                    btnBaseDelete.Enabled = CanDelete;

                //if (!CanUpdate)
                //    btnBaseAdd.Enabled = false;

            }
            catch (Exception ex)
            {

                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
        }




        private void BaseScreen_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

    }
}