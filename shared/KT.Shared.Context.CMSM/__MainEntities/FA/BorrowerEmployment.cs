using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM
{
	[Serializable]
	public class BorrowerEmployment
	{
        public string EmployerName { get; set; }

        public string CorporateAddress { get; set; }

        public string CorporateUnit { get; set; }

        public string CorporateCity { get; set; }

        public string CorporateState { get; set; }

        public string CorporateZip { get; set; }

        public string CorporatePhone { get; set; }

        public string CurrentTitle { get; set; }

        public bool SelfEmployed { get; set; }

        public string PayType { get; set; }

        public int YearInThisProfession { get; set; }

        public int HowLongInYear { get; set; }

        public int HowLongInMonth { get; set; }

        public string CorporateFax { get; set; }

        public DateTime? EmploymentVerifyDate { get; set; }

        public DateTime? EmploymentReorderDate { get; set; }

        public DateTime? EmploymentReceivedDate { get; set; }

        public DateTime? EmploymentExpectedDate { get; set; }

        public DateTime? EmploymentStartDate { get; set; }

        #region changes 3-9-2022

        public bool EmployedByFamilyMember { get; set; }

        public bool ForeignIncome { get; set; }

        public bool SeasonalIncome { get; set; }

        #endregion

        public string OwnershipInterest { get; set; }

    }
}
