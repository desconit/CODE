using System;

namespace RSys
{
    [Serializable]
    public class WeeklyPlanRow
    {

        public int PlacementID { get; set; }


        public int CandidateID { get; set; }

        public string CandidateName { get; set; }

        public int RequirmentId { get; set; }

        public string RequrimentRef { get; set; }

        public DateTime StartDate { get; set; }

        public decimal StandardRate { get; set; }

        public decimal OvertimeRate { get; set; }

        public decimal WeekendRate { get; set; }

        public decimal StandardRateCharge { get; set; }

        public decimal OvertimeRateCharge { get; set; }

        public decimal WeekendRateCharge { get; set; }

        public bool IsDeleted { get; set; }

        public string ClientCompany { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public int LastModifiedByUserId { get; set; }

        public int CreatedByUserId { get; set; }

        public string Site { get; set; }

        public string PaymentType { get; set; }

        public decimal StandardHours { get; set; }

        public decimal WeekendHours { get; set; }

        public decimal OvertimeHours { get; set; }

        public String Trade { get; set; }

        public int Margin { get; set; }

        public bool Rollover { get; set; }

        public string CandidateFirstName { get; set; }

        public string CandidateSurname { get; set; }
    }
}