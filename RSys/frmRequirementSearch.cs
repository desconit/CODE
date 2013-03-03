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
using TextMsgTest;
using System.Linq;

namespace RSys
{
    public partial class frmRequirementSearch : DevExpress.XtraEditors.XtraForm
    {
        string defaultticketIDs = "", defaultPersonsID = "";
        public bool isCancel = false;
        public DataSet ds;
        DataSet dsMain;
        bool isNoReqSearch = false;

        public frmRequirementSearch(string ticketIDs, string PersonsID, DataTable dsReqTickets, DataTable dsTickets)
        {
            InitializeComponent();
            SetDefaults();
            this.defaultticketIDs = ticketIDs;
            this.defaultPersonsID = PersonsID;

            gvTickets.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            this.grdTickets.DataSource = dsReqTickets;
            this.grdTickets.RefreshDataSource();
            gvTickets.ExpandAllGroups();

            rluCategory.DataSource = dsTickets;
            rluCategory.ValueMember = Tickets.ID;
            rluCategory.DisplayMember = Tickets.Name;

            btnOK.Enabled = false;
            btnSendTextToCandidates.Visible = false;
            //gvTickets.OptionsBehavior.Editable = false;
            
        }


        public frmRequirementSearch(bool noRequirmentSearch)
        {
            SetUpForm(noRequirmentSearch);
        }

        private void SetUpForm(bool noRequirmentSearch)
        {
            isNoReqSearch = noRequirmentSearch;
            InitializeComponent();
            SetDefaults();
            if (isNoReqSearch)
            {
                //Not Opening from a requirment
                BLL bll = new BLL(Tables.Requirements, Program.clsuser.CurrentDB);

                this.defaultticketIDs = "(-1)";
                this.defaultPersonsID = "(-1)";

                dsMain = bll.GetByID(-1);

                SetTableNames();
                btnOK.Visible = false;
                btnSendTextToCandidates.Visible = true;

                grdTickets.DataSource = dsMain.Tables[Tables.RequirementTickets];
                grdTickets.RefreshDataSource();
                gvTickets.ExpandAllGroups();

                rluCategory.DataSource = dsMain.Tables[Tables.Tickets];
                rluCategory.ValueMember = Tickets.ID;
                rluCategory.DisplayMember = Tickets.Name;

                luCounty.Properties.DataSource = dsMain.Tables[Tables.Counties];
                luCounty.Properties.ValueMember = Counties.ID;
                luCounty.Properties.DisplayMember = Counties.Name;

                luTrades.Properties.DataSource = dsMain.Tables[Tables.Trades];
                luTrades.Properties.ValueMember = Trades.ID;
                luTrades.Properties.DisplayMember = Trades.Name;


                btnSendTextToCandidates.Enabled = false;
                //   gvTickets.OptionsBehavior.Editable = false;
             
            }
        }

        private void SetTableNames()
        {
            dsMain.Tables[0].TableName = Tables.Requirements;
            dsMain.Tables[1].TableName = Tables.ExistingData;
            dsMain.Tables[2].TableName = Tables.RequirementTypes;
            dsMain.Tables[3].TableName = Tables.Companies;
            dsMain.Tables[4].TableName = Tables.Persons;
            dsMain.Tables[5].TableName = Tables.CompanySites;
            dsMain.Tables[6].TableName = Tables.JobStatuses;
            dsMain.Tables[7].TableName = Tables.JobTitles;
            dsMain.Tables[8].TableName = Tables.Contracts;
            dsMain.Tables[9].TableName = Tables.Attachments;
            dsMain.Tables[10].TableName = Tables.RateTypes;
            dsMain.Tables[11].TableName = Tables.RateFrequencies;
            dsMain.Tables[12].TableName = Tables.ShortlistContacts;
            dsMain.Tables[13].TableName = "Contacts";
            dsMain.Tables[14].TableName = Tables.RequirementTickets;
            dsMain.Tables[15].TableName = Tables.Tickets;
            dsMain.Tables[17].TableName = Tables.Counties;
            dsMain.Tables[18].TableName = Tables.Trades;


            //DataRelation relation = new DataRelation("relContract", dsMain.Tables[Tables.Requirements].Columns[Requirements.ID], dsMain.Tables[Tables.Contracts].Columns[Contracts.RequirementsID], false);
            //dsMain.Relations.Add(relation);


            //relation = new DataRelation("relShortList", dsMain.Tables[Tables.Requirements].Columns[Requirements.ID], dsMain.Tables[Tables.ShortlistContacts].Columns[Contracts.RequirementsID], false);
            //dsMain.Relations.Add(relation);


            //relation = new DataRelation("relTickets", dsMain.Tables[Tables.Requirements].Columns[Requirements.ID], dsMain.Tables[Tables.RequirementTickets].Columns[RequirementTickets.RequirementsID], false);
            //dsMain.Relations.Add(relation);

        }

        private void rluCategory_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lkp = (LookUpEdit)(sender);

            if (lkp.EditValue == null)
            {
                return;
            }


            gvTickets.SetRowCellValue(gvTickets.FocusedRowHandle, "TicketType", lkp.GetColumnValue("TicketType"));

        }

        private void SetDefaults()
        {
            gvTickets.Appearance.Row.Font = new Font(gvTickets.Appearance.Row.Font.FontFamily, 12f, FontStyle.Regular);
            gvTickets.Appearance.HeaderPanel.Font = new Font(gvTickets.Appearance.HeaderPanel.Font.FontFamily, 12f, FontStyle.Regular);

            gvDetail.Appearance.Row.Font = new Font(gvDetail.Appearance.Row.Font.FontFamily, 12f, FontStyle.Regular);
            gvDetail.Appearance.HeaderPanel.Font = new Font(gvDetail.Appearance.HeaderPanel.Font.FontFamily, 12f, FontStyle.Regular);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BLL bll = new BLL(Program.clsuser.CurrentDB);
            Hashtable ht = new Hashtable();

            ht.Add(Persons.FirstName, txtFirstName.Text.Trim().Replace("'", "''"));
            ht.Add(Persons.LastName, txtLastName.Text.Trim().Replace("'", "''"));
            ht.Add(Persons.City, txtCity.Text.Trim().Replace("'", "''"));
            ht.Add("Tickets", this.chkTickets.Checked);

            if (isNoReqSearch)
            {
                var ticketIDs = string.Empty;
                for (int i = 0; i < dsMain.Tables[Tables.RequirementTickets].Rows.Count; i++)
                {
                    if (ticketIDs == string.Empty)
                        ticketIDs += dsMain.Tables[Tables.RequirementTickets].Rows[i][RequirementTickets.TicketsID].ToString();
                    else
                        ticketIDs += ("," + dsMain.Tables[Tables.RequirementTickets].Rows[i][RequirementTickets.TicketsID].ToString());


                }

                if (ticketIDs == string.Empty)
                {
                    ticketIDs = defaultticketIDs;
                }
                else
                {
                    defaultticketIDs = ticketIDs;
                }


                ht.Add("TicketsID", ticketIDs);
                ht.Add("PersonsID", defaultPersonsID);
            }
            else
            {
                ht.Add("TicketsID", defaultticketIDs);
                ht.Add("PersonsID", defaultPersonsID);
            }


            if(!luCounty.Text.Trim().Equals(string.Empty))
                ht.Add(Persons.CountiesID, luCounty.EditValue);

            if (!txtContactPostCode.Text.Trim().Equals(string.Empty))
                ht.Add(Persons.Postcode, txtContactPostCode.Text);

            if (!luTrades.Text.Trim().Equals(string.Empty))
                ht.Add(Persons.TradesID, luTrades.EditValue);

            if (!txtMobile.Text.Trim().Equals(string.Empty))
                ht.Add(Persons.PersonalMobile, txtMobile.Text);

            if (!txtEmail.Text.Trim().Equals(string.Empty))
                ht.Add(Persons.PersonalEmail, txtEmail.Text);
            

            if(chkCurrentlyPlacements.Checked)
                ht.Add("IncludePlacements", 1);


            ds = bll.ExecuteSP("usp_ShortListContactsAutoSearch", ht);

            grdDetails.DataSource = ds.Tables[0];
            grdDetails.RefreshDataSource();

            if (ds.Tables[0].Rows.Count == 0)
            {
                Messages.Warning("No record found.");
            }

            if (!isNoReqSearch)
                btnOK.Enabled = true;
            else
            {
                btnSendTextToCandidates.Enabled = true;
            }
        }

        private void gvDetail_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gvDetail.FocusedRowHandle < 0)
                    return;

                int ID = Convert.ToInt32(gvDetail.GetRowCellValue(gvDetail.FocusedRowHandle, Persons.ID));
               
              
                //Set the filter contactId so that the candidate type is setup
                 var frm = new frmContacts("3", ID);
               
                
                frm.Owner = this;
                frm.luCode.Enabled = false;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            isCancel = true;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            bool hasSelectedACandidate = false;


            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (Convert.ToBoolean(ds.Tables[0].Rows[i]["Select"]))
                {
                    hasSelectedACandidate = true;
                }
            }

            if (hasSelectedACandidate)
                this.Visible = false;
            else
                MessageBox.Show("No candidate selected, please tick a candidate to add to the shortlist.",
                                "No candidate selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void grdDetails_Click(object sender, EventArgs e)
        {

        }

        private void btnSendTextToCandidates_Click(object sender, EventArgs e)
        {
            bool hasSelectedACandidate = false;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (Convert.ToBoolean(ds.Tables[0].Rows[i]["Select"]))
                {
                    hasSelectedACandidate = true;
                }
            }

            if (hasSelectedACandidate)
            {
                string messageTicketsList = string.Empty;
                string messageLocation = string.Empty;

                RsysEntities1 rsysEntities = new RsysEntities1();

                DataTable dtTickets = dsMain.Tables[Tables.Tickets];

                List<String> ticketIdsToSelect = new List<String>(defaultticketIDs.Split(','));

                List<int> intTicketIds = new List<int>();

                if (defaultticketIDs != string.Empty)
                    foreach (var id in defaultticketIDs.Split(','))
                    {

                        int idCopy = -1;
                        try
                        {
                            if (id != "-1")
                            {
                                idCopy = Convert.ToInt32(id);

                                var name = (from t in rsysEntities.Tickets.Where(t => t.ID == idCopy)
                                            select t).FirstOrDefault().Name;

                                if (messageTicketsList == string.Empty)
                                    messageTicketsList += name;
                                else
                                {
                                    messageTicketsList += ", " + name;
                                }


                            }
                        }
                        catch (Exception ex)
                        {
                            Functions.LogError(ex);
                            Messages.Error(ex.Message);
                        }

                    }


                frmCandidateMessagePreview frmCandPrev = new frmCandidateMessagePreview(messageTicketsList);

                frmCandPrev.ShowDialog();

                if (frmCandPrev.DialogResult == DialogResult.OK)
                {
                    messageTicketsList = frmCandPrev.txtMessageTrade;
                    messageLocation = frmCandPrev.textMessageLocation;


                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(ds.Tables[0].Rows[i]["Select"]))
                        {

                            //Create candidate object 
                            var messageSender = new MessageSender();
                            var candidateMessage = new MessageSender.CandidateMessage();

                            candidateMessage.CandidateName = Convert.ToString(ds.Tables[0].Rows[i][Persons.FirstName]) +
                                                             " " +
                                                             Convert.ToString(ds.Tables[0].Rows[i][Persons.LastName]);

                            candidateMessage.CandidateNumber = "07958656944";
                            candidateMessage.TxtMessage =
                                string.Format("We are currently looking for a {0} to work in {1}",
                                              messageTicketsList, messageLocation);
                            candidateMessage.TxtMessage1 =
                                "Please call AJK Resources on 0208 952 1732 if you are intrested in this role";

                            candidateMessage.TextMessageSigniture = "Thanks AJK Resources LTD";

                            var msgResponse = messageSender.SendMailShotMessage(candidateMessage);

                            if (msgResponse.Success)
                            {
                                MessageBox.Show(
                                    "Your message has been sent to the candidate - " + candidateMessage.CandidateName,
                                    "Message Sent",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show(
                                    "There was an error sending sending your message to " +
                                    candidateMessage.CandidateName +
                                    ": please provide this error code to the system administrator: " +
                                    msgResponse.Response, "Error sending message", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                        }
                    }

                    //Send a message to candidates 
                    MessageBox.Show("Message(s) have been sent");
                }
                else
                    MessageBox.Show("No candidate selected, please tick a candidate before trying to send a message.",
                                    "No candidate selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void chkTickets_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTickets.Checked)
            {
                tpTickets.PageEnabled = true;
                xtMain.SelectedTabPage = tpTickets;
            }
            else
            {
                tpTickets.PageEnabled = false;
            }
        }

        private void gvTickets_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (gvTickets.FocusedRowHandle > -1)
                e.Cancel = true;
        }

        public void ResetForm()
        {
            SetUpForm(true);
        }

        private void grdTickets_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (gvTickets.FocusedRowHandle >= 0)
                {
                    gvTickets.GetDataRow(gvTickets.FocusedRowHandle).Delete();
                }
            }
        }

        
    }
}