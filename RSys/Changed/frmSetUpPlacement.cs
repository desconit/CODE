using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using RSys.Placements;

namespace RSys
{


    public partial class frmSetUpPlacement : DevExpress.XtraEditors.XtraForm
    {
        public frmSetUpPlacement()
        {
            InitializeComponent();

            luCode.EditValue = ID;
            luJob.EditValue = 0;

            luCode.Properties.Buttons.RemoveAt(0);

            luJob.Properties.Buttons.RemoveAt(0);

            RsysEntities1 rsysEntities = new RsysEntities1();

            IQueryable<ReqPopulated> jobs =
                (from j in rsysEntities.Requirements
                 join c in rsysEntities.Companies on j.CompaniesID equals c.ID
                 join s in rsysEntities.CompanySites on j.SitesID equals s.ID
                 orderby j.JobName, j.CompaniesID
                 select new ReqPopulated()
                            {
                                ID = j.ID,
                                JobName = j.JobName,
                                JobSiteName = s.Name,
                                CompanyName = c.CompanyName,
                                PostCode = s.Postcode
                            }
                 );

            var candidates = (from c in rsysEntities.Persons.Where(c => c.isActive && c.ConatactTypesID == 3)
                              orderby c.FirstName, c.LastName
                              select new CandidatePopulated()
                                         {
                                             ID = c.ID,
                                             Name = c.FirstName + " " + c.LastName,
                                             PosCode = c.Postcode
                                         }
                              );

            luCode.Properties.ValueMember = Persons.ID;
            luCode.Properties.DisplayMember = "Name";
            luCode.Properties.DataSource = candidates;

            luJob.Properties.ValueMember = Requirements.ID;
            luJob.Properties.DisplayMember = Requirements.JobName;
            luJob.Properties.DataSource = jobs;


            //  Hashtable ht = new Hashtable();
            //  ht.Add(Persons.ID, Convert.ToInt32(luCode.EditValue));
            //  ht.Add(Persons.CreatedBy, Program.clsuser.UserID);
            // // dsMain = bll.ExecuteSP("usp_" + Tables.Persons + "GetByID", ht);

            //  //dsMain = bll.GetByID(Convert.ToInt32(luCode.EditValue));
            /////  SetTableNames();
        }

        private void RefreshData()
        {
            // luCode.Properties.ValueMember = Persons.ID;
            // luCode.Properties.DisplayMember = "Name";
            // luCode.Properties.DataSource = dsMain.Tables[Tables.ExistingData];
        }

        protected int ID { get; set; }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            
            int candidateId = Convert.ToInt32(luCode.EditValue);
            int jobId = Convert.ToInt32(luJob.EditValue);

            if (candidateId != null && candidateId  > 0)
            {
                if (jobId != null && jobId  > 0)
                {
                    frmPlacement frmPlacement = new frmPlacement(false, candidateId, jobId);
                    frmPlacement.ShowDialog();
                }
            }
        }

        private void luCode_EditValueChanged(object sender, EventArgs e)
        {
            if (luCode.EditValue == null | object.ReferenceEquals(luCode.EditValue, DBNull.Value))
            {
               
            }
           
        }
    }

    public class ReqPopulated
    {

        public int ID { get; set; }

        public string JobName { get; set; }

        public string JobSiteName { get; set; }

        public string CompanyName { get; set; }

        public string PostCode { get; set; }
    }

    public class CandidatePopulated
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string PosCode { get; set; }
    }


}