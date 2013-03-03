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
    public partial class frmDiaryActions : DevExpress.XtraEditors.XtraForm
    {
        ucDiaryActions ucDiaryCtrl;
        DataSet dsMain;

        public frmDiaryActions()
        {
            InitializeComponent();
            RefreshData();
            AddCtrl();
        }

        private void AddCtrl()
        {
            ucDiaryCtrl = new ucDiaryActions(dsMain.Tables[Tables.DiaryActions], null, "");
            ucDiaryCtrl.Location = new Point(0, 0);
            ucDiaryCtrl.Show();
            ucDiaryCtrl.Dock = DockStyle.Fill;
            this.Controls.Add(ucDiaryCtrl);
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
               
                    myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
               
                return myCp;
            }
        }

        public   void RefreshData()
        {

            dsMain = Functions.RefreshAppointmentData();

            dsMain.Tables[0].TableName = Tables.DiaryActions;

            if(ucDiaryCtrl != null)
                ucDiaryCtrl.RefreshDataSource(dsMain.Tables[Tables.DiaryActions]);
            
        }

        public void RefreshData(int RecID)
        {
            //BLL bll = new BLL(Tables.Companies, Program.clsuser.CurrentDB, Program.clsuser.UserID);

            //DataSet ds = bll.Search();

            //ds.Tables[0].TableName = Tables.Companies;
            //ds.Tables[1].TableName = Tables.Industries;



            //rluIndustry.ValueMember = Industries.ID;
            //rluIndustry.DisplayMember = Industries.Name;
            //rluIndustry.DataSource = ds.Tables[Tables.Industries];

            //grdMain.DataSource = ds.Tables[Tables.Companies];
            //grdMain.RefreshDataSource();

            //for (int i = 0; i < ds.Tables[Tables.Companies].Rows.Count; i++)
            //{
            //    if (ds.Tables[Tables.Companies].Rows[i][Companies.ID].ToString().Equals(RecID.ToString()))
            //    {
            //        gvMain.FocusedRowHandle = i;
            //        break;
            //    }
            //}
        }

       
        private void frmDiaryActions_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if(!((frmMain)this.MdiParent).isCalledFromLogout )
            //    e.Cancel = true;

            if (e.CloseReason != CloseReason.MdiFormClosing)
            {
                e.Cancel = true;
            }


            

        }
    }
}