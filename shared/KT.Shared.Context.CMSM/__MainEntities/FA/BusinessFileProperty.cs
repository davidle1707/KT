
using KT.Shared.Context.CMSM.Utils;
using System;

namespace KT.Shared.Context.CMSM
{
	[Serializable]
	public class BusinessFileProperty
    {
        #region Address

        public bool CurrentResidence { get; set; }

        public string Occupancy { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public string ProAddress { get; set; }

        public string PropertyHouseNumber { get; set; }

        public string PropertyCity { get; set; }

        [LendingQbField("sSpCounty", IsSubmit = true, IsLoad = true)]
        public string PropertyCounty { get; set; }

        public string PropertyZipCode { get; set; }

        public string PropertyState { get; set; }

        #endregion

        #region Info

        public string YearAquire { get; set; }

        [LendingQbField("sUnitsNum", IsSubmit = true, IsLoad = true)]
        public string NumberOfUnits { get; set; }

        [LendingQbField("sGseSpT", IsSubmit = true)]
        public string PropertyType { get; set; }

        public int YearBuilt { get; set; }

        [LendingQbField("sApprVal", IsSubmit = true, IsLoad = true)]
        public decimal PropertyValue { get; set; }

        [LendingQbField("sPurchPrice", IsSubmit = true, IsLoad = true)]
        public decimal PropertyPurchasePrice { get; set; }

        public decimal MonthlyPropertyTax { get; set; }

        public decimal MonthlyPropertyInsurance { get; set; }

        public decimal MonthlyHOA { get; set; }

        public decimal MonthlyPropertyOtherExpense { get; set; }

        public decimal YearlyPropertyTax { get; set; }

        public decimal YearlyPropertyInsurance { get; set; }

        public decimal YearlyHOA { get; set; }

        public decimal YearlyPropertyOtherExpense { get; set; }

        public string HOAName { get; set; }

        #endregion

        #region New: 11/14/2018

        public decimal AVM { get; set; }

        public decimal ARValue { get; set; }

        public decimal BPO { get; set; }

        public decimal AppraisalValue1 { get; set; }

        public decimal AppraisalValue2 { get; set; }

        public decimal Relar { get; set; }

        public int ConfidentScore { get; set; }

        public decimal Stewart { get; set; }

        #endregion

        public bool TitleInTrust { get; set; }

        public int? AppraisalType  { get; set; }

        public string LegalDescription { get; set; }

        public string LeaseHoldProperty { get; set; }

        public decimal PropertyAcreage { get; set; }

        // new fields from 12/12/2019
        public int YearLotAcquired { get; set; }

        public decimal PresentLotValue { get; set; }

        public decimal CostOfImprovement { get; set; }

        public string DescribeImprovement { get; set; }

        public string EstateWillBeHeld { get; set; }

        public decimal ImprovementRepairs { get; set; }

        public decimal LandCost { get; set; }

        public decimal OrignalCost { get; set; }

        public decimal AmountExistingLiens { get; set; }

        public string SourceDownPayment { get; set; }

        public string WillHeldName { get; set; }

        public string TitleWillBeHeld { get; set; }

        public string PurposeOfRefinanceLoan { get; set; }

        #region 08/06/2021 huyngo

        public bool IsIntentLive14DaysPerYear { get; set; }

        public bool IsTitleHeldInEntity { get; set; }

        public string TitleHeldInEntityName { get; set; }

        #endregion
    }
}