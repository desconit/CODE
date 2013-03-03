using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;


namespace RSys
{
    public partial class frmWeeklyPlanVW : DevExpress.XtraEditors.XtraForm
    {

        private bool isAdmin = false;

        public frmWeeklyPlanVW()
        {
            InitializeComponent();

            if (Program.clsuser.UserName.ToLower() == "Noel Azebiah" || Program.clsuser.UserName.ToLower() == "arthur kabalu" || Program.clsuser.UserName.ToLower() == "ali Jhonson")
            {
                isAdmin = true;
            }

            GetWeeklyPlans();

        }

        private void GetWeeklyPlans()
        {
            var rsysEntities = new RsysEntities1();

            IQueryable<WeeklyPlan> weeklyPlans;

            if (isAdmin)
                weeklyPlans = from p in rsysEntities.WeeklyPlans.Where(p => p.IsDeleted == false) select p;
            else
                weeklyPlans = from p in
                                  rsysEntities.WeeklyPlans.Where(p => p.IsDeleted == false && p.CreatedByUserId == Program.clsuser.UserID)
                              select p;

            grdMain.DataSource = weeklyPlans;
            grdMain.RefreshDataSource();
        }

        private void btnAddWeeklyPlan_Click(object sender, EventArgs e)
        {
            try
            {
                frmWeeklyPlan frm = new frmWeeklyPlan();
                frm.Owner = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {

                    frm.Dispose();

                    GetWeeklyPlans();
                }
                else
                {
                    frm.Dispose();
                }
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

        public void btnAdd_Click(object o, object o1)
        {

        }

        private void EditWeekly_Plan(object sender, EventArgs e)
        {
            try
            {

                if (gvMain.FocusedRowHandle < 0)
                    return;

                int ID = Convert.ToInt32(gvMain.GetRowCellValue(gvMain.FocusedRowHandle, "Id"));

                frmWeeklyPlan frm = new frmWeeklyPlan();
                frm.loadWeeklyPlan(ID);
                frm.Owner = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {

                    frm.Dispose();

                    GetWeeklyPlans();
                }
                else
                {
                    frm.Dispose();
                }
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

        public void RefreshData()
        {

            if (Program.clsuser.UserName.ToLower() == "Noel Azebiah" || Program.clsuser.UserName.ToLower() == "arthur kabalu" || Program.clsuser.UserName.ToLower() == "ali Jhonson")
            {
                isAdmin = true;
            }

            GetWeeklyPlans();
        }
    }
}