using System;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.Utils;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using DESCONIT.BLL;

namespace RSys
{
    public partial class ucAttachment : DevExpress.XtraEditors.XtraUserControl
    {
        private int ScreenId = 0;
        private string ScreenName = "";
        public DataTable dtAttach;
        private BLL bll;
        private const string DeleteCol = "Deleted";

        string AttachmentFolder = "";

        public ucAttachment(DataTable dt, int ScreenID, string ScreenName)
        {
            InitializeComponent();
            
            

            this.dtAttach = dt;
            this.ScreenId = ScreenID; 
            this.ScreenName = ScreenName;

            fillImages();
            FillAttachmentTypeCombo();
           
            grdAttach.DataSource = dtAttach;
            grdAttach.RefreshDataSource();
            gvAttach.ExpandAllGroups();
            lblAttachmentPath.Text = "Attachment Root Folder: " + Program.clsuser.AttachmentPath;
            AttachmentFolder = Program.clsuser.AttachmentPath + "\\" + ScreenName + "\\" + Program.clsuser.UserID.ToString() + "_" + Program.clsuser.UserName;
            AddDeleteColumn(dtAttach);
        }

        private void FillAttachmentTypeCombo()
        {
            bll = new BLL(Tables.AttachmentTypes, Program.clsuser.CurrentDB, Program.clsuser.UserID);

            Hashtable ht = new Hashtable();
            if(Screens.frmCompanies == this.ScreenId)
                ht.Add(AttachmentTypes.isForContact, 0);
            else
                ht.Add(AttachmentTypes.isForContact, 1);


            DataSet ds = bll.ExecuteSP("usp_AttachmentTypesGetByFields", ht); 

            rluRoles.DataSource = ds.Tables[0];
            rluRoles.DisplayMember = AttachmentTypes.Name;
            rluRoles.ValueMember = AttachmentTypes.ID;
        }

        private void fillImages()
        {
           // DevExpress.Utils.ImageCollection images = new DevExpress.Utils.ImageCollection();

            //images.AddImage(Image.FromFile("..\\..\\Minor.png"));
            //images.AddImage(imageCollection1.Images[0]);
            rImageCombo.SmallImages = images;
            rImageCombo.Items.Add(new ImageComboBoxItem("", (string)".doc", 0));
            rImageCombo.Items.Add(new ImageComboBoxItem("", (string)".docx", 0));
            rImageCombo.Items.Add(new ImageComboBoxItem("", (string)".xls", 1));
            rImageCombo.Items.Add(new ImageComboBoxItem("", (string)".xlsx", 1));
            rImageCombo.Items.Add(new ImageComboBoxItem("", (string)".pdf", 2));
            rImageCombo.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;

        }

        private byte[] GetByte(string Path)
        {
            FileStream st = new FileStream(Path, FileMode.Open);
            byte[] buffer = new byte[st.Length];
            st.Read(buffer, 0, (int)st.Length);
            st.Close();

            return buffer;


        }

        private void GetAttachmentPath(ref object sender)
        {
            ButtonEdit txt = (ButtonEdit)sender;
            if ((!Directory.Exists(Program.clsuser.AttachmentPath)))
            {
                XtraMessageBox.Show("Attachments path is not set in application settings.", Constants.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                //dlg.Filter = "Word|*.doc;*.docx|Excel|*.xls;*.xlsx|PDF|*.pdf|All Supported Formats(Word, Excel, PDF)|*.doc;*.docx;*.xls;*.xlsx;*.pdf"
                //dlg.Filter = "PDF|*.pdf";
                string path = null;

                dlg.ShowDialog();
                //path = "\" & sTabs(ProdTabID) & "\" & dlg.SafeFileName
                path = dlg.FileName;

                if ((path.Trim().Equals(string.Empty)))
                {
                    return;
                }

                

                if (!File.Exists(AttachmentFolder + "\\" + dlg.SafeFileName))
                {
                    if ((!Directory.Exists(AttachmentFolder)))
                    {
                        Directory.CreateDirectory(AttachmentFolder);
                    }

                    File.Copy(path, AttachmentFolder + "\\" + dlg.SafeFileName, true);
                   

                    string _pth = Path.GetExtension(path);
                }

                txt.EditValue = dlg.SafeFileName;

                gvAttach.SetRowCellValue(gvAttach.FocusedRowHandle, cl_AttName, txt.EditValue);
                gvAttach.SetRowCellValue(gvAttach.FocusedRowHandle, cl_Attachment, txt.EditValue);
                gvAttach.SetRowCellValue(gvAttach.FocusedRowHandle, Attachments.AttPath, "\\" + ScreenName + "\\" + Program.clsuser.UserID.ToString() + "_" + Program.clsuser.UserName + "\\" + dlg.SafeFileName);
                gvAttach.SetRowCellValue(gvAttach.FocusedRowHandle, Attachments.AttType, Path.GetExtension(path));
                gvAttach.SetRowCellValue(gvAttach.FocusedRowHandle, Attachments.ScreensID, this.ScreenId);


            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
        }

        //private void GetAttachmentPath(ref object sender)
        //{
        //    ButtonEdit txt = (ButtonEdit)sender;
           
        //    try
        //    {
        //        OpenFileDialog dlg = new OpenFileDialog();
        //        dlg.Filter = "Word|*.doc;*.docx|Excel|*.xls;*.xlsx|PDF|*.pdf|All Supported Formats(Word, Excel, PDF)|*.doc;*.docx;*.xls;*.xlsx;*.pdf";
        //        //dlg.Filter = "PDF|*.pdf";
        //        string path = null;

        //        dlg.ShowDialog();
        //        //path = "\" & sTabs(ProdTabID) & "\" & dlg.SafeFileName
        //        path = dlg.FileName;

        //        if ((path.Trim().Equals(string.Empty)))
        //        {
        //            return;
        //        }

               
        //        if (!File.Exists( dlg.SafeFileName))
        //        {
        //            txt.EditValue =  dlg.SafeFileName;

        //        }
        //        else
        //        {
        //            txt.EditValue =  dlg.SafeFileName;
                    
        //        }

        //        gvAttach.SetRowCellValue(gvAttach.FocusedRowHandle, cl_AttName, txt.EditValue);
        //        gvAttach.SetRowCellValue(gvAttach.FocusedRowHandle, Attachments.AttType, Path.GetExtension(path));
        //        gvAttach.SetRowCellValue(gvAttach.FocusedRowHandle, Attachments.Attachment,  GetByte(path));
        //        gvAttach.SetRowCellValue(gvAttach.FocusedRowHandle, Attachments.ScreensID, this.ScreenId);
        //    }
        //    catch (Exception ex)
        //    {
        //        Messages.Error(ex.Message);
        //    }
        //}

        private void rbtnFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GetAttachmentPath(ref sender );
        }


        public void RefreshDataSource(DataTable dt)
        {
            dtAttach = dt;
            AddDeleteColumn(dtAttach);
            grdAttach.DataSource = dtAttach;
            grdAttach.RefreshDataSource();
        }

        public DataTable GetAttachmentTable()
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

        private void gvAttach_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            gvAttach.ClearColumnErrors();

            if (gvAttach.GetRowCellValue(e.RowHandle, Attachments.Attachment).ToString().Equals(string.Empty))
            {
                gvAttach.SetColumnError(cl_AttName, "Please select a valid file.");
                e.Valid = false;
            }

            if (gvAttach.GetRowCellValue(e.RowHandle, Attachments.AttachmentTypesID).ToString().Equals(string.Empty))
            {
                gvAttach.SetColumnError(cl_AttachmentType, "Please select attachment type.");
                e.Valid = false;
            }

            if (e.Valid)
                gvAttach.SetRowCellValue(gvAttach.FocusedRowHandle, cl_ScreensID, ScreenId);


        }

        private void gvAttach_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
        }

        private void grdAttach_DoubleClick(object sender, EventArgs e)
        {
            //OpenAttachment();

            if (gvAttach.FocusedRowHandle < 0)
                return;

            OpenAttachment(Program.clsuser.AttachmentPath + "\\" + gvAttach.GetRowCellValue(gvAttach.FocusedRowHandle, Attachments.AttPath).ToString());
        }


        private void OpenAttachment(string Path)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                System.Diagnostics.Process.Start(Path);
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

        private void OpenAttachment()
        {
            try
            {
                if (gvAttach.FocusedRowHandle < 0)
                    return;

                this.Cursor = Cursors.WaitCursor;

                int iRow = gvAttach.FocusedRowHandle;
                string AttachType = dtAttach.Rows[iRow][Attachments.AttType].ToString();
                string AttachFile = dtAttach.Rows[iRow][Attachments.Attachment].ToString();

                string filePath = Application.StartupPath + "\\" + AttachFile;

                byte[] buffer = (byte[])dtAttach.Rows[iRow][Attachments.Attachment];

                if (File.Exists(filePath))
                    File.Delete(filePath);

                FileStream fs = new FileStream(filePath, FileMode.Create);
                fs.Write(buffer, 0, buffer.Length);
                fs.Close();

                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                Functions.LogError(ex);
                Messages.Error(ex.Message);
            }
            finally
            { this.Cursor = Cursors.Default; }

        }

        private void rluRoles_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lu = ((LookUpEdit)sender);

            //if (lu.EditValue == null)
            //    gvAttach.SetRowCellValue(gvAttach.FocusedRowHandle, cl_attachmentName, "");
            //else
            //    gvAttach.SetRowCellValue(gvAttach.FocusedRowHandle, cl_attachmentName, lu.GetColumnValue(AttachmentTypes.Name));

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

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

        private void gvAttach_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            grdAttach_KeyPress(null, null);
        }

        private void ConditionsAdjustment()
        {
            StyleFormatCondition cn;

            

            
            
            cn = new StyleFormatCondition(FormatConditionEnum.Equal, gvAttach.Columns[DeleteCol], null,1);
            cn.ApplyToRow = true;
            cn.Appearance.Font = new Font(AppearanceObject.DefaultFont,  FontStyle.Bold | FontStyle.Strikeout);
            
            cn.Appearance.BorderColor = Color.Red;
            //cn.Appearance.ForeColor = SystemColors.ControlDark;
            cn.Appearance.ForeColor = System.Drawing.Color.Red;
            gvAttach.FormatConditions.Add(cn);

            gvAttach.BestFitColumns();
        }

        private void grdAttach_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void ucAttachment_Load(object sender, EventArgs e)
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
                    //if (DialogResult.Yes == XtraMessageBox.Show(Constants.DeleteMsg, Constants.ApplicationTitle, MessageBoxButtons.YesNo))
                    //{
                    if (gvAttach.GetRowCellValue(gvAttach.FocusedRowHandle, Attachments.ID) != DBNull.Value)
                    {
                        if (Convert.ToInt32(gvAttach.GetRowCellValue(gvAttach.FocusedRowHandle, DeleteCol)) == 1)
                        {
                            gvAttach.SetRowCellValue(gvAttach.FocusedRowHandle, DeleteCol, 0);
                            //dtAttach.Rows[gvAttach.FocusedRowHandle].AcceptChanges();
                            //btnDelete.Text = "Delete";

                        }
                        else
                        {
                            gvAttach.SetRowCellValue(gvAttach.FocusedRowHandle, DeleteCol, 1);
                            
                           // dtAttach.Rows[gvAttach.FocusedRowHandle].AcceptChanges();
                            //btnDelete.Text = "Undo";
                            //if (dtAttach.Rows[gvAttach.FocusedRowHandle].RowState == DataRowState.Unchanged)
                            //    dtAttach.Rows[gvAttach.FocusedRowHandle].Delete();
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
