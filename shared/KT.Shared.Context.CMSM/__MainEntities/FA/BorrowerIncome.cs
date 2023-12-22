using System;

namespace KT.Shared.Context.CMSM
{
	[Serializable]
	public class BorrowerIncome
	{
        public decimal MonthlyGrossIncome { get; set; }

        public decimal RentalIncome { get; set; }

        public decimal ChildSupport { get; set; }

        public decimal RoomsRentedIncome { get; set; }

        public decimal Unemployment { get; set; }

        public decimal Disability { get; set; }

        public decimal Commission { get; set; }

        public decimal Overtime { get; set; }

        public decimal OtherIncome1 { get; set; }

        public string OtherIncome1Description { get; set; }

        public decimal OtherIncome2 { get; set; }

        public string OtherIncome2Description { get; set; }

        public decimal LessFederalTaxes { get; set; }

        public decimal LessStateTaxes { get; set; }

        public decimal LessFICA { get; set; }

        public decimal LessDeductions { get; set; }

        public decimal TotalMonthlyIncome { get; set; }

        public decimal FamilySize { get; set; }

        public decimal DividendIncome { get; set; }

        public bool IsRentalIncomeOverride { get; set; }

        public string AlimonyName { get; set; }

        public bool AlimonyExcludeFromRatio { get; set; }

        public decimal AlimonyMonthlyPayment { get; set; }

        public int AlimonyMonthsLeft { get; set; }

        public bool JobExpenseExcludeFromRatio1 { get; set; }

        public string JobExpenseName1 { get; set; }

        public decimal JobExpenseMonthlyPayment1 { get; set; }

        public bool JobExpenseExcludeFromRatio2 { get; set; }

        public string JobExpenseName2 { get; set; }

        public decimal JobExpenseMonthlyPayment2 { get; set; }

        public decimal Bonus { get; set; }

        public decimal MilitaryBasePay { get; set; }

        public decimal MilitaryRationsAllowance { get; set; }

        public decimal MilitaryFlightPay { get; set; }

        public decimal MilitaryHazardPay { get; set; }

        public decimal MilitaryClothesAllowance { get; set; }

        public decimal MilitaryQuartersAllowance { get; set; }

        public decimal MilitaryPropPay { get; set; }

        public decimal MilitaryOverseasPay { get; set; }

        public decimal MilitaryCombatPay { get; set; }

        public decimal MilitaryVariableHousingAllowance { get; set; }

        public decimal Retirement { get; set; }

        public decimal Trust { get; set; }

        public decimal SocialSecurity { get; set; }

    }
}
