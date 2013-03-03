using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;
using DESCONIT.BLL;

namespace RSys
{
    public partial class ucDiaryActions : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDiaryActions()
        {
            InitializeComponent();
           
        }

        DataTable dtSchedule;
        int ? ScreenId;
        string ScreenName = "";

        public ucDiaryActions(DataTable dt, int? ScreenID, string ScreenName)
        {
            InitializeComponent();

            

            this.dtSchedule = dt;

            this.ScreenId = ScreenID;
            this.ScreenName = ScreenName;

            PrepareViews();
            InitializeScheduler();
            

        }

        void PrepareViews()
        {
            schedulerControl.WeekView.Enabled = false;
            schedulerControl.WorkWeekView.Enabled = false;
            schedulerControl.MonthView.Enabled = false;
            schedulerControl.TimelineView.Enabled = false;
            schedulerControl.DayView.DayCount = 7;
            schedulerControl.DayView.ShowAllDayArea = true;
            schedulerControl.DayView.ShowDayHeaders = true;
            schedulerControl.WorkDays.Add(DevExpress.XtraScheduler.WeekDays.Saturday);
            schedulerControl.Start = DateTime.Now.Date;





        }

        public DataTable GetScheduleTable()
        {
            return dtSchedule;
        }

        public void RefreshDataSource(DataTable dt)
        {
            dtSchedule = dt;
            InitializeScheduler();
        }

        private void InitializeScheduler()
        {
            schedulerStorage.Appointments.DataSource = dtSchedule;

          //  if (this.ScreenId == null)
                CreateResources();

            //schedulerStorage.Appointments.DataMember = Tables.DiaryActions;

            schedulerStorage.Appointments.Mappings.AllDay = DiaryActions.AllDay;
            schedulerStorage.Appointments.Mappings.Description = DiaryActions.Description;
            schedulerStorage.Appointments.Mappings.End = DiaryActions.EndTime;
            schedulerStorage.Appointments.Mappings.Location = DiaryActions.Location;
            schedulerStorage.Appointments.Mappings.Label = DiaryActions.Label;
            schedulerStorage.Appointments.Mappings.RecurrenceInfo = DiaryActions.RecurrenceInfo;
            schedulerStorage.Appointments.Mappings.ResourceId = DiaryActions.ResourceID;
           

            schedulerStorage.Appointments.Mappings.ReminderInfo = DiaryActions.ReminderInfo;
            schedulerStorage.Appointments.Mappings.Start = DiaryActions.StartTime;
            schedulerStorage.Appointments.Mappings.Status = DiaryActions.Status;
            schedulerStorage.Appointments.Mappings.Subject = DiaryActions.Subject;
            schedulerStorage.Appointments.Mappings.Type = DiaryActions.EventType;

            schedulerControl.Storage = schedulerStorage;

            if(ScreenId != null)
            {
                schedulerControl.GroupType = SchedulerGroupType.Resource;
                cbGroupBy.SelectedIndex = 2;
            }
            else
            {
                schedulerControl.GroupType = SchedulerGroupType.None;
                cbGroupBy.SelectedIndex = 0;
            }



            cbView.SelectedIndex = 0;

            schedulerControl.Views.MonthView.Enabled = true;
            schedulerControl.Views.DayView.Enabled = true;
            schedulerControl.Views.WeekView.Enabled = true;
            schedulerControl.Views.WorkWeekView.Enabled = true;
            schedulerControl.Views.TimelineView.Enabled = true;

        
        }

        void CreateResources()
        {
            schedulerStorage.Resources.Clear();


            DataRow[] drs = dtSchedule.Select(DiaryActions.Resource + " IS NOT NULL");
            for (int i = 0; i < drs.Length; i++)
            {
                Resource r = schedulerStorage.CreateResource(drs[i][DiaryActions.ResourceID].ToString());
                //r.Id = drs[i][DiaryActions.Resource].ToString();
                r.Caption = drs[i][DiaryActions.Resource].ToString();

                bool isFound = false;
                for (int res = 0; res < schedulerStorage.Resources.Count; res++)
                {
                    if (schedulerStorage.Resources[res].Caption == r.Caption)
                    {
                        isFound = true;
                        break;
                    }
                }
        
                if(!isFound)
                    schedulerStorage.Resources.Add(r);
            }
            

            
        }

        private void schedulerStorage_AppointmentInserting(object sender, DevExpress.XtraScheduler.PersistentObjectCancelEventArgs e)
        {
            //string test = ((DevExpress.XtraScheduler.Appointment)(e.Object))
            //e.Object.GetValue(
        }

        private void schedulerStorage_AppointmentsInserted(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.ScreenId == null)
                {
                    Appointment pt = (Appointment)e.Objects[0];

                 
                    
                    if (((DevExpress.XtraScheduler.Appointment)(e.Objects[0])).ResourceId.ToString().Equals("DevExpress.XtraScheduler.Native.EmptyResource"))
                    {
                        dtSchedule.Rows[dtSchedule.Rows.Count - 1][DiaryActions.ScreensID] = Screens.frmPersons;
                        dtSchedule.Rows[dtSchedule.Rows.Count - 1][DiaryActions.RecordID] = Program.clsuser.UserID;
                    }
                    else
                    {
                        string[] arr = ((DevExpress.XtraScheduler.Appointment)(e.Objects[0])).ResourceId.ToString().Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                        dtSchedule.Rows[dtSchedule.Rows.Count - 1][DiaryActions.ScreensID] = arr[0];
                        dtSchedule.Rows[dtSchedule.Rows.Count - 1][DiaryActions.RecordID] = arr[1];

                        //for (int i = 0; i < schedulerStorage.Resources.Count; i++)
                        //{
                        //    if (schedulerStorage.Resources[i].Caption == dtSchedule.Rows[dtSchedule.Rows.Count - 1][DiaryActions.Resource].ToString())
                        //    {
                        //        string ResourceID = schedulerStorage.Resources[i].Id.ToString();
                        //        string[] arr = ResourceID.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                        //        dtSchedule.Rows[dtSchedule.Rows.Count - 1][DiaryActions.ScreensID] = arr[0];
                        //        dtSchedule.Rows[dtSchedule.Rows.Count - 1][DiaryActions.RecordID] = arr[1];

                        //    }
                        //}

                    }
                    SaveAppointment();

                }
                else
                {
                    dtSchedule.Rows[dtSchedule.Rows.Count - 1][DiaryActions.ScreensID] = ScreenId;
                }

               
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

        private void schedulerStorage_AppointmentChanging(object sender, PersistentObjectCancelEventArgs e)
        {
            if (ScreenId == null)
            {

                //Appointment pt = (Appointment)e.Object;
               
                //string[] arr = pt.ResourceId.ToString().Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                //dtSchedule.Rows[dtSchedule.Rows.Count - 1][DiaryActions.ScreensID] = arr[0];
                //dtSchedule.Rows[dtSchedule.Rows.Count - 1][DiaryActions.RecordID] = arr[1];
                SaveAppointment();
            }
        }

        void SaveAppointment()
        {
            BLL bll = new BLL(Tables.DiaryActions, Program.clsuser.CurrentDB, Program.clsuser.UserID);

            bll.SaveAllSimple(dtSchedule);
            dtSchedule.AcceptChanges();
        }

        private void cbView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //schedulerControl.Views.MonthView.Enabled = true;
            //schedulerControl.Views.DayView.Enabled = true;
            //schedulerControl.Views.WeekView.Enabled = true;
            //schedulerControl.Views.WorkWeekView.Enabled = true;
            //schedulerControl.Views.TimelineView.Enabled = true;
            schedulerControl.ActiveViewType = (SchedulerViewType)cbView.EditValue;
            
            schedulerControl.ActiveViewType = (SchedulerViewType)cbView.EditValue;
            //dateNavigator.SchedulerControl.RefreshData();
           // schedulerControl.ActiveViewType = SchedulerViewType.Timeline;
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbGroupBy.Text.Equals("None",StringComparison.OrdinalIgnoreCase))
                schedulerControl.GroupType = SchedulerGroupType.None;
            else if(cbGroupBy.Text.Equals("Date",StringComparison.OrdinalIgnoreCase))
                schedulerControl.GroupType = SchedulerGroupType.Date;
            else if(cbGroupBy.Text.Equals("Resource",StringComparison.OrdinalIgnoreCase))
                schedulerControl.GroupType = SchedulerGroupType.Resource;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            schedulerControl.ActiveViewType = SchedulerViewType.Timeline;
        }

        private void schedulerStorage_AppointmentsDeleted(object sender, PersistentObjectsEventArgs e)
        {
            int ID = 0;
            try
            {

                //dtSchedule = Functions.RefreshAppointmentData().Tables[0];
                //schedulerStorage.RefreshData();
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

        private void schedulerStorage_AppointmentDeleting(object sender, PersistentObjectCancelEventArgs e)
        {
            int ID = 0;
            try
            {

                                 
                if (String.IsNullOrEmpty(((DevExpress.XtraScheduler.Appointment)(e.Object)).GetValue(schedulerStorage, DiaryActions.ID).ToString()))
                {
                    dtSchedule.Rows.RemoveAt(dtSchedule.Rows.Count - 1);
                    return;
                }
                else
                {
                    ID = Convert.ToInt32(((DevExpress.XtraScheduler.Appointment)(e.Object)).GetValue(schedulerStorage, DiaryActions.ID));
                }


                if (this.ScreenId == null)
                {
                    Functions.DeleteAppointmentData(ID);


                    for (int iRow = 0; iRow < dtSchedule.Rows.Count; iRow++)
                    {
                        if (dtSchedule.Rows[iRow].RowState == DataRowState.Deleted)
                        {
                            dtSchedule.RejectChanges();
                        }

                        if (dtSchedule.Rows[iRow][DiaryActions.ID].ToString().Equals(ID.ToString()))
                        {
                            dtSchedule.Rows.RemoveAt(iRow);
                            schedulerStorage.RefreshData();
                            return;
                        }
                    }

                }
                else
                {
                    for (int iRow = 0; iRow < dtSchedule.Rows.Count; iRow++)
                    {
                        if (dtSchedule.Rows[iRow][DiaryActions.ID].ToString().Equals(ID.ToString()))
                        {
                            //  dtSchedule.Rows[iRow].Delete();
                            // schedulerStorage.RefreshData();
                            return;
                        }
                    }

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
       
    }
}
