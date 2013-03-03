using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RSys
{
    public partial class FrmPlacementsVW : BaseScreen
    {
        public FrmPlacementsVW()
        {
            InitializeComponent();

            RefreshData(null);
        }

        internal void GetAllPlacemnts()
        {
            //
            var rsysEntities = new RsysEntities1();

            var placements = from p in rsysEntities.Placements.Where(p => p.IsDeleted == false)
                             join c in rsysEntities.Companies on p.Requirement.CompaniesID equals c.ID
                             where p.IsDeleted == false
                             select new PlacementObject()
                                        {
                                            ID = p.PlacementId,
                                            FirstName = p.Person.FirstName,
                                            LastName = p.Person.LastName,
                                            RequrimentRefrecnce = p.Requirement.Reference,
                                            StartDate = p.StartDate,
                                            StandardRate = p.StandardRate,
                                            OvertimeRate = p.OvertimeRate,
                                            WeekendRate = p.WeekendRate,
                                            IsCanceled = p.IsCanceled,
                                            ClientCompany = c.CompanyName,
                                            LastModifiedBy = rsysEntities.Persons.Where(x => x.ID == p.LastModifiedBy).FirstOrDefault().FirstName,
                                            CreatedBy = rsysEntities.Persons.Where(x => x.ID == p.CreatedBy).FirstOrDefault().FirstName,
                                            LastModifiedOn = p.LastModifiedOn,
                                            CreatedOn = p.CreatedOn,
                                            Canceled = p.IsCanceled,
                                            PlacementObjectStored = p
                                             
                                         };


            grdMain.DataSource = placements;
            grdMain.RefreshDataSource();

     }

        private void grpMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void grdMain_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);

        }

        internal void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvMain.FocusedRowHandle < 0)
                    return;

                int ID = Convert.ToInt32(gvMain.GetRowCellValue(gvMain.FocusedRowHandle, "ID"));
                frmPlacement frm;


                //if (FilterContactID > 0)
                //    frm = new frmContacts(this.FilterContactID.ToString(), ID);
                //else
                    frm = new frmPlacement();
                frm.loadPlacement(ID);

                

                frm.Owner = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
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

        private void grdView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >  -1)
            {
                var canceled = (bool) gvMain.GetRowCellValue(e.RowHandle, "Canceled");

                if (canceled)
                {
                    e.Appearance.BackColor = Color.Red;
                }
                else
                {
                    var startDate = (DateTime)gvMain.GetRowCellValue(e.RowHandle, "CreatedOn");

                    if (startDate.Date == DateTime.Now.Date)
                        e.Appearance.BackColor = Color.LightGreen;

                }
            }

        }

        public void RefreshData(object o)
        {
            GetAllPlacemnts();
        }
    }



    public class PlacementObject
    {
        public string FirstName
        { get; set; }

        public string LastName
        { get; set; }

        public string RequrimentRefrecnce
        { get; set; }

        public DateTime StartDate
        { get; set; }

        public decimal StandardRate
        { get; set; }

        public decimal OvertimeRate
        { get; set; }

        public decimal WeekendRate
        { get; set; }

        public bool IsCanceled
        { get; set; }

        public string ClientCompany 
        { get; set; }

        public string LastModifiedBy
        { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastModifiedOn   { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool Canceled { get; set; }

        public int ID { get; set; }

        public Placement PlacementObjectStored { get; set; }

        public int CandidateID { get; set; }

        public int RequirmentId { get; set; }

        public string CompanyAddressLine2 { get; set; }

        public string CompanyAddressLine1 { get; set; }

        public string CompanyPostcode { get; set; }

        public string ReportTo { get; set; }

        public string CandidateMustBring { get; set; }

        public string ReportToContactNumber { get; set; }
    }
}
