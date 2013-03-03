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
using DevExpress.Utils;
using DevExpress.XtraGrid;
using System.Collections;
using DESCONIT.BLL;

namespace RSys
{
    public partial class frmCanvassingClient :BaseScreen
    {
        BLL bll = new BLL(Tables.Companies, Program.clsuser.CurrentDB);
        bool isEdit;
        public DataSet dsMain;
        int? ID = null;
        DataTable dt = new DataTable();
        bool isCalledFromContact = false;
       string DeleteCol = "Deleted";
        public frmCanvassingClient()
        {
            InitializeComponent();
            Initialize();

            Hashtable ht = new Hashtable();
            ht.Add(Companies.ID, Convert.ToInt32(-2));
            ht.Add("Type", 1);
            dsMain = bll.ExecuteSP("usp_" + Tables.Companies + "GetByID", ht);
            SetTableNames();
            RefreshData();
        }

        public frmCanvassingClient(int ID)
        {
            InitializeComponent();
            Initialize();
            Hashtable ht = new Hashtable();
            ht.Add(Companies.ID, Convert.ToInt32(ID));
            ht.Add("Type", 1);
            dsMain = bll.ExecuteSP("usp_" + Tables.Companies + "GetByID", ht);            
            //dsMain = bll.GetByID(Convert.ToInt32(ID), 1);
            SetTableNames();
            //AddAttachmentCtrl();
            RefreshData();
            this.ID = ID;
            SendKeys.Send("{TAB}") ;
        }             
        
        public frmCanvassingClient(bool isCalledFromContact, int? CompanyID)
        {
            InitializeComponent();
            Initialize();
            Hashtable ht = new Hashtable();
            if (CompanyID == null)
            {
                ht.Add("ID", -2);
                ht.Add("Type", 1);
                dsMain = bll.ExecuteSP("usp_" + Tables.Companies + "GetByID", ht);                            
                //dsMain = bll.GetByID(-1,1);
                isEdit = true;
            }
            else
            {
                ht.Add("ID", Convert.ToInt32(CompanyID));
                ht.Add("Type", 1);
                dsMain = bll.ExecuteSP("usp_" + Tables.Companies + "GetByID", ht);                            
                //dsMain = bll.GetByID(Convert.ToInt32(CompanyID),1);
                this.ID = Convert.ToInt32(CompanyID);
                SendKeys.Send("{TAB}");
            }

            SetTableNames();
            //AddAttachmentCtrl();
            RefreshData();
            this.isCalledFromContact = isCalledFromContact;
            btnSaveNClear.Visible = false;
            luCode.Properties.Buttons.RemoveAt(0);
            btnSave.Text = "Save && Close";


        }

        private void Initialize()
        {
            base.btnBaseAdd = this.btnSaveNClear;
            base.btnBaseEdit = this.btnSave;
            base.btnBaseDelete = this.btnDelete;
            base.SystemObjectName = this.Name;
            ConditionsAdjustment();
        }
        
        private void SetTableNames()
        {
            
            dsMain.Tables[0].TableName = Tables.Companies;
            dsMain.Tables[1].TableName = Tables.ExistingData;
            dsMain.Tables[2].TableName = Tables.CompanyBackOffices;
            dsMain.Tables[13].TableName = Tables.Persons;
            dsMain.Tables[15].TableName = Tables.Consultant;
            dsMain.Tables[16].TableName = Tables.ConsultantHistory;
            dsMain.Tables[17].TableName = Tables.Notes; 

        }
       
        private void save()
        {
            
        }

        private void RefreshData()
        {
            luCode.Properties.ValueMember = ExistingData.ID;
            luCode.Properties.DisplayMember = "CompanyName";
            luCode.Properties.DataSource = dsMain.Tables[Tables.ExistingData];

            luConsultant.Properties.ValueMember = Persons.ID;
            luConsultant.Properties.DisplayMember = Persons.FullName;
            luConsultant.Properties.DataSource = dsMain.Tables[Tables.Consultant];

            grdCanvassingContact.DataSource = dsMain.Tables[Tables.Persons];
            grdCanvassingContact.RefreshDataSource();

            grdNotes.DataSource = dsMain.Tables[Tables.Notes];
            grdNotes.RefreshDataSource();
            gvNotes.ExpandAllGroups();

            grdConsultantHistory.DataSource = dsMain.Tables[Tables.ConsultantHistory];
            grdConsultantHistory.RefreshDataSource();
            


        }

        private void ClearFields()
        {
            try
            {
                Err.ClearErrors();
                
                txtTelNo.Text = string.Empty;
                txtEmail.Text = string.Empty;  
                
  
                lblEntry.Text = string.Empty;
                btnDelete.Enabled = false;
                luConsultant.EditValue = null;
                dtStartDate.EditValue = null;
                //grdSites.DataSource = null;

                try
                {
                    for (int i = 0; i < dsMain.Tables[Tables.Persons].Rows.Count; i++)
                    {
                        dsMain.Tables[Tables.Persons].Rows.RemoveAt(i);
                        i--;
                        dsMain.Tables[Tables.Persons].AcceptChanges();
                    }
                   
                    grdCanvassingContact.DataSource = dsMain.Tables[Tables.Persons];
                    grdCanvassingContact.RefreshDataSource();

                    for (int i = 0; i < dsMain.Tables[Tables.Notes].Rows.Count; i++)
                    {
                        dsMain.Tables[Tables.Notes].Rows.RemoveAt(i);
                        i--;
                        dsMain.Tables[Tables.Notes].AcceptChanges();
                    }
                    grdNotes.DataSource = dsMain.Tables[Tables.Notes];
                    grdNotes.RefreshDataSource();

                    for (int i = 0; i < dsMain.Tables[Tables.ConsultantHistory].Rows.Count; i++)
                    {
                        dsMain.Tables[Tables.ConsultantHistory].Rows.RemoveAt(i);
                        i--;
                        dsMain.Tables[Tables.ConsultantHistory].AcceptChanges();
                    }
                    grdConsultantHistory.DataSource = dsMain.Tables[Tables.Notes];
                    grdConsultantHistory.RefreshDataSource();
                

                }
                catch (Exception ex)
                {
                    Functions.LogError(ex);
                    Messages.Error(ex.Message);
                   
                }
               


                isEdit = false;
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

        private void GetByID()
        {
            Hashtable ht = new Hashtable();
            ht.Add(Companies.ID, Convert.ToInt32(luCode.EditValue));
            ht.Add("Type", 1);
            ht.Add(DiaryActions.CreatedBy, Program.clsuser.UserID);
            dsMain = bll.ExecuteSP("usp_" + Tables.Companies + "GetByID", ht);
            
            //dsMain = bll.GetByID(Convert.ToInt32(luCode.EditValue));
            SetTableNames();

            RefreshData();
        }

        private void BindFields()
        {
            try
            {
                if (dsMain.Tables[Tables.CompanyBackOffices].Rows.Count > 0)
                {
                    txtTelNo.Text = dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.Tel].ToString(); ;
                    txtEmail.Text = dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.Email].ToString();
                }
                if (dsMain.Tables[Tables.Companies].Rows[0][Companies.ConsultantStartDate].ToString() != "")
                    dtStartDate.DateTime = Convert.ToDateTime(dsMain.Tables[Tables.Companies].Rows[0][Companies.ConsultantStartDate].ToString());
                else
                    dtStartDate.DateTime = DateTime.Now;  

                luConsultant.EditValue = dsMain.Tables[Tables.Companies].Rows[0][Companies.ConsultantID];

                grdNotes.DataSource = dsMain.Tables[Tables.Notes];
                grdNotes.RefreshDataSource();
                gvNotes.ExpandAllGroups();

                grdConsultantHistory.DataSource = dsMain.Tables[Tables.ConsultantHistory];
                grdConsultantHistory.RefreshDataSource();

                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
        }

        private void luCode_EditValueChanged(System.Object sender, System.EventArgs e)
        {
            //ClearFields();
            try
            {
                if (Convert.ToInt32(luCode.EditValue) == -1)
                {
                    lblEntry.Text = "New Entry";
                    isEdit = false;
                    //luCode.Text = dsMain.Tables[Tables.ExistingData].Rows[dsMain.Tables[Tables.ExistingData].Rows.Count - 1][Companies.CompanyName].ToString();
                    //luCode.EditValue = -1;
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
                    lblEntry.Text = "";
                    GetByID();
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

        private void gvMain_InvalidRowException(System.Object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
        }

        private bool Save()
        {
            if (!Messages.Save())
                return false;

            if (!Validation())
                return false;

            try
            {
                MarkAsDelete();

                if (dsMain.Tables[Tables.Companies].Rows.Count == 0)
                    dsMain.Tables[Tables.Companies].Rows.Add(dsMain.Tables[Tables.Companies].NewRow());

                if (dsMain.Tables[Tables.CompanyBackOffices].Rows.Count == 0)
                    dsMain.Tables[Tables.CompanyBackOffices].Rows.Add(dsMain.Tables[Tables.CompanyBackOffices].NewRow());


                    dsMain.Tables[Tables.Companies].Rows[0][Companies.CompanyName] = luCode.Text;
                    if(!luConsultant.Text.Equals(string.Empty))
                        dsMain.Tables[Tables.Companies].Rows[0][Companies.ConsultantID] = luConsultant.EditValue;

                    if(!dtStartDate.Text.Equals(string.Empty))
                        dsMain.Tables[Tables.Companies].Rows[0][Companies.ConsultantStartDate] = dtStartDate.DateTime;
                    else
                        dsMain.Tables[Tables.Companies].Rows[0][Companies.ConsultantStartDate] = DBNull.Value;

                    dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.Tel] = txtTelNo.Text;
                    dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.Email] = txtEmail.Text;
                    dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.StatusesID] = 1;
                    dsMain.Tables[Tables.CompanyBackOffices].Rows[0][CompanyBackOffices.isActive] = 1;
                    dsMain.Tables[Tables.Companies].Rows[0][Companies.isVATStatus] = 0;   



                
                    dsMain.Tables[Tables.Companies].Rows[0][Companies.isActive] = chkActive.Checked;

                    DataRelation relation = new DataRelation("CompanyBackOffices", dsMain.Tables[Tables.Companies].Columns[Companies.ID], dsMain.Tables[Tables.CompanyBackOffices].Columns[CompanyBackOffices.CompaniesID], false);
                    dsMain.Relations.Add(relation);


                    relation = new DataRelation("Persons", dsMain.Tables[Tables.Companies].Columns[Companies.ID], dsMain.Tables[Tables.Persons].Columns[Persons.CompaniesID], false);
                    dsMain.Relations.Add(relation);


                    relation = new DataRelation("Notes", dsMain.Tables[Tables.Companies].Columns[Companies.ID], dsMain.Tables[Tables.Notes].Columns[Notes.RecordID], false);
                    dsMain.Relations.Add(relation);




                dsMain =  bll.SaveComplex(dsMain, isEdit);
                SetTableNames();

                if (this.Owner.Name == "frmCanvassingClientVW")
                {
                    ((frmCanvassingClientVW)(this.Owner)).RefreshData(Convert.ToInt32(luCode.EditValue));
                    ((frmMain)(((frmCanvassingClientVW)(this.Owner)).MdiParent)).RefreshDiaryActions();
                }
                else
                {
                    ((frmCompaniesVW)(this.Owner)).RefreshData(Convert.ToInt32(luCode.EditValue));
                    ((frmMain)(((frmCompaniesVW)(this.Owner)).MdiParent)).RefreshDiaryActions();
                }
                //((frmCanvassingClientVW)(this.Owner)).RefreshData(Convert.ToInt32(luCode.EditValue));
                

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
                if (!Save())
                    return;

                SetTableNames();
                RefreshData();
                if (luCode.EditValue == null || luCode.EditValue.ToString().Equals("-1"))
                    luCode.EditValue = dsMain.Tables[Tables.Companies].Rows[0][Companies.ID];

                RefreshData();
                BindFields();

                if (isCalledFromContact)
                {
                    //((frmContacts)this.Owner).UpdateCompanyList(Convert.ToInt32(luCode.EditValue), luCode.Text, txtCompanyNo.Text, txtVATNo.Text);
                    this.Visible = false;
                }
                else
                {
                    //((frmCanvassingClientVW)(this.Owner)).RefreshData(Convert.ToInt32(luCode.EditValue));
                    //((frmMain)(((frmCanvassingClientVW)(this.Owner)).MdiParent)).RefreshDiaryActions();
                }
                lblEntry.Text = string.Empty;
                this.isEdit = true;
                btnDelete.Enabled = true;


            
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


            //if (txtVATNo.Text.Trim().Equals(string.Empty))
            //{
            //    Err.SetError(txtVATNo, "Enter VAT number.");
            //    txtVATNo.Focus();
            //    check = false;
            //}
            //else
            //{
            //    Err.SetError(txtVATNo, null);
            //}


            if ((txtTelNo.Text.Trim() == string.Empty) )
            {
                Err.SetError(txtTelNo, "Enter Telno number.");
                txtTelNo.Focus();
                check = false;
            }

            else
            {
                Err.SetError(txtTelNo, null);
            }

            if ((txtEmail.Text.Trim() == string.Empty))
            {
                Err.SetError(txtEmail, "Enter email Address.");
                txtTelNo.Focus();
                check = false;
            }

            else
            {
                Err.SetError(txtEmail, null);
            }

            
            if ((luCode.Text == string.Empty))
            {
                Err.SetError(luCode, "Enter company name.");
                luCode.Focus();
                check = false;
            }

            else
            {
                Err.SetError(luCode, null);
            }


            return check;


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (luCode.EditValue != null)
                {
                    if (Messages.Delete())
                    {
                        bll.Delete(Convert.ToInt32(luCode.EditValue));
                        ClearFields();
                        luCode.EditValue = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally { }
        }

        private void grpMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSaveNClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Save())
                    return;
                
               
                ClearFields();
                //luBranches.Focus();
                luCode.EditValue = null;
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);

            }
            finally
            { }
        }

        bool isCalledFromProcessNewVal = false;

       

        private void SetEditValuetoNewRec()
        {
            if (isCalledFromProcessNewVal)
            {
                luCode.EditValue = -1;
                isCalledFromProcessNewVal = false;
            }
        }

        private void luCode_KeyDown(object sender, KeyEventArgs e)
        {
            //luCode.EditValue = null;
        }

        private void frmCanvassingClient_Load(object sender, EventArgs e)
        {
            //luCode.Properties.DataSource = dsMain.Tables[Tables.ExistingData];
            //luCode.Properties.DisplayMember = Companies.CompanyName;
            //luCode.Properties.ValueMember = Companies.ID;
            
           

            //DataColumn dc = new DataColumn();
            //dc.ColumnName = "ID";
            //dc.DataType = typeof(int);

            //dt.Columns.Add(dc);

            //dc = new DataColumn();
            //dc.ColumnName = "CompanyName";

            //dt.Columns.Add(dc);


            //for (int i = 0; i < 3; i++)
            //    this.dt.Rows.Add(new object[] { i, "Name" + i });

            //luCanType.Properties.DataSource = dsMain.Tables[Tables.ExistingData];
            //luCanType.Properties.DisplayMember = Companies.CompanyName;
            //luCanType.Properties.ValueMember= Companies.ID;

            // dt = dsMain.Tables[Tables.ExistingData];


            //luCanType.Properties.DataSource = dt;
            // luCanType.Properties.DisplayMember = Companies.CompanyName;
            // luCanType.Properties.ValueMember = Companies.ID;


            if (this.ID != null)
                luCode.EditValue = this.ID;
            luCode.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            luCode.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
        }

        private void luCode_ProcessNewValue(System.Object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            try
            {
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
                        ClearFields();

                        DataRow r = dsMain.Tables[Tables.ExistingData].Rows.Add(new object[] { });
                        r[luCode.Properties.DisplayMember] = e.DisplayValue.ToString();
                        r[luCode.Properties.ValueMember] = -1;
                        e.Handled = true;

                    }
                }
                else
                {
                    // ClearFields();
                    //DataRow dr = dsMain.Tables[Tables.ExistingData].NewRow();
                    //dr["CompanyName"] = e.DisplayValue.ToString();
                    //dr[ExistingData.ID] = -1;
                    //dsMain.Tables[Tables.ExistingData].Rows.Add(dr);
                    //e.Handled = true;

                    DataRow r = dsMain.Tables[Tables.ExistingData].Rows.Add(new object[] { });
                    r[luCode.Properties.DisplayMember] = e.DisplayValue.ToString();
                    r[luCode.Properties.ValueMember] = -1;
                    e.Handled = true;
                    luCode.EditValue = -1;
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

        private void frmCanvassingClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (isCalledFromContact && !luCode.EditValue.ToString().Equals("-1") && luCode.EditValue != null)
            
        }

        private void luCode_Leave(object sender, EventArgs e)
        {
            if (luCode.EditValue == null)
                ClearFields();
            else
                luCode_EditValueChanged(null, null);
        }

        private void txtWebsite_DoubleClick(object sender, EventArgs e)
        {
            string txt = ((TextEdit)sender).Text;
            
            if (txt.Trim().Equals(string.Empty)  )
                return;

            if (!Functions.UrlIsValid(txt))
                return;

            if(!txt.StartsWith("www.",StringComparison.OrdinalIgnoreCase))
                txt = "www." + txt;

            System.Diagnostics.Process.Start(txt);

        }

        private void grdAttach_Click(object sender, EventArgs e)
        {

        }

        private void gvPersons_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            
            ColumnView view = (ColumnView)sender;
            GridColumn colName = view.Columns[Persons.FirstName];

            string UserId = null;
            string FirstName = null;

            gvPersons.SetRowCellValue(e.RowHandle, Persons.ConatactTypesID, 3);
            gvPersons.SetRowCellValue(e.RowHandle, Persons.JobTitlesID, -1);
            gvPersons.SetRowCellValue(e.RowHandle, Persons.CountriesID, -1);
            gvPersons.SetRowCellValue(e.RowHandle, Persons.isStaff, 0);
            gvPersons.SetRowCellValue(e.RowHandle, Persons.Address1, "Unknown");
            gvPersons.SetRowCellValue(e.RowHandle, Persons.GendersID, -1);
            gvPersons.SetRowCellValue(e.RowHandle, Persons.isActive, 1);
          
            //if (DBNull.Value == view.GetRowCellValue(e.RowHandle, colName))
            //{
            //    FirstName = "";
            //}
            //else
            //{
            //    FirstName = view.GetRowCellValue(e.RowHandle, colName).ToString();
            //}         


            if (view.GetRowCellValue(e.RowHandle, Persons.FirstName).ToString().Equals(string.Empty))
            {
                view.SetColumnError(colName, "Please enter firstname.");
                e.Valid = false;
            }

            if (view.GetRowCellValue(e.RowHandle, Persons.LastName).ToString().Equals(string.Empty))
                view.SetRowCellValue(e.RowHandle, Persons.LastName, "");

        }

        private void gvNotes_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            ColumnView view = (ColumnView)sender;
            GridColumn colName = view.Columns[Notes.Note];

            string UserId = null;
            string Note = null;

            gvNotes.SetRowCellValue(e.RowHandle, Notes.NotePrioritiesID, -1);
            gvNotes.SetRowCellValue(e.RowHandle, Notes.ScreensID, 6);

            if (DBNull.Value == view.GetRowCellValue(e.RowHandle, colName))
            {
                Note = "";
            }
            else
            {
                Note = view.GetRowCellValue(e.RowHandle, colName).ToString();
            }

            if ((Note.Equals(string.Empty)))
            {
                view.SetColumnError(colName, "Please enter Note.");
                e.Valid = false;
            }           

        }

        private void gvNotes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                DeleteNotes();
        }

        private void gvPersons_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                DeleteContact();
        }


        private void DeleteContact()
        {
            try
            {
                if (gvPersons.FocusedRowHandle > -1)
                {
                    //if (DialogResult.Yes == XtraMessageBox.Show(Constants.DeleteMsg, Constants.ApplicationTitle, MessageBoxButtons.YesNo))
                    //{
                    if (gvPersons.GetRowCellValue(gvPersons.FocusedRowHandle, Persons.ID) != DBNull.Value)
                    {
                        if (Convert.ToInt32(gvPersons.GetRowCellValue(gvPersons.FocusedRowHandle, DeleteCol)) == 1)
                        {
                            gvPersons.SetRowCellValue(gvPersons.FocusedRowHandle, DeleteCol, 0);
                           // dsMain.Tables[Tables.Persons].Rows[gvPersons.FocusedRowHandle][DeleteCol] = 0;

                        }
                        else
                        {
                            gvPersons.SetRowCellValue(gvPersons.FocusedRowHandle, DeleteCol, 1);
                            //dsMain.Tables[Tables.Persons].Rows[gvPersons.FocusedRowHandle][DeleteCol] = 1;

                        }


                        gvPersons.RefreshData();


                    }
                    else
                    {
                        dsMain.Tables[Tables.Persons].Rows[gvPersons.FocusedRowHandle].Delete();
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

        private void DeleteNotes()
        {
            try
            {
                if (gvNotes.FocusedRowHandle > -1)
                {
                    //if (DialogResult.Yes == XtraMessageBox.Show(Constants.DeleteMsg, Constants.ApplicationTitle, MessageBoxButtons.YesNo))
                    //{
                    if (gvNotes.GetRowCellValue(gvNotes.FocusedRowHandle, Attachments.ID) != DBNull.Value)
                    {
                        if (Convert.ToInt32(gvNotes.GetRowCellValue(gvNotes.FocusedRowHandle, DeleteCol)) == 1)
                        {
                            gvNotes.SetRowCellValue(gvNotes.FocusedRowHandle, DeleteCol, 0);


                        }
                        else
                        {
                            gvNotes.SetRowCellValue(gvNotes.FocusedRowHandle, DeleteCol, 1);


                        }


                        gvNotes.RefreshData();


                    }
                    else
                    {
                        dsMain.Tables[Tables.Notes].Rows[gvNotes.FocusedRowHandle].Delete();
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

        private void ConditionsAdjustment()
        {
            StyleFormatCondition cn;

            cn = new StyleFormatCondition(FormatConditionEnum.Equal, gvPersons.Columns[DeleteCol], null, 1);
            cn.ApplyToRow = true;
            cn.Appearance.Font = new Font(AppearanceObject.DefaultFont, FontStyle.Bold | FontStyle.Strikeout);

            cn.Appearance.BorderColor = Color.Red;
            //cn.Appearance.ForeColor = SystemColors.ControlDark;
            cn.Appearance.ForeColor = System.Drawing.Color.Red;
            gvPersons.FormatConditions.Add(cn);
            gvNotes.FormatConditions.Add(cn);
            gvNotes.BestFitColumns();
            gvContacts.BestFitColumns();
        }

        private void MarkAsDelete()
        {
            for (int i = 0; i < dsMain.Tables[Tables.Persons].Rows.Count; i++)
            {
                if (dsMain.Tables[Tables.Persons].Rows[i][DeleteCol].ToString().Equals("1"))
                {
                    if (dsMain.Tables[Tables.Persons].Rows[i].RowState == DataRowState.Unchanged)
                        dsMain.Tables[Tables.Persons].Rows[i].AcceptChanges();

                    dsMain.Tables[Tables.Persons].Rows[i].Delete();
                }
            }


            for (int i = 0; i < dsMain.Tables[Tables.Notes].Rows.Count; i++)
            {
                if (dsMain.Tables[Tables.Notes].Rows[i][DeleteCol].ToString().Equals("1"))
                {
                    if (dsMain.Tables[Tables.Notes].Rows[i].RowState == DataRowState.Unchanged)
                        dsMain.Tables[Tables.Notes].Rows[i].AcceptChanges();

                    dsMain.Tables[Tables.Notes].Rows[i].Delete();
                }
            }
        }

    }
}