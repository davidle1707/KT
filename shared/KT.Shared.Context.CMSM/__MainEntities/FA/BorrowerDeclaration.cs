using System;

namespace KT.Shared.Context.CMSM
{
	[Serializable]
	public class BorrowerDeclaration
    {
        public bool INotWishInformation { get; set; }

        public bool Ethnicity { get; set; }

        public bool RaceAmericanIndian { get; set; }

        public bool RaceAsian { get; set; }

        public bool RaceBlack { get; set; }

        public bool RaceNativeHawaiian { get; set; }

        public bool RaceWhite { get; set; }

        public bool Sex { get; set; }

        public bool DeclarationA { get; set; }
        public bool DeclarationB { get; set; }
        public bool DeclarationC { get; set; }
        public bool DeclarationD { get; set; }
        public bool DeclarationE { get; set; }
        public bool DeclarationF { get; set; }
        public bool DeclarationG { get; set; }
        public bool DeclarationH { get; set; }
        public bool DeclarationI { get; set; }
        public bool DeclarationJ { get; set; }
        public bool DeclarationK { get; set; }
        public bool DeclarationL { get; set; }
        public bool DeclarationM { get; set; }
        public string DeclarationMValue1 { get; set; } = "0"; // default
        public string DeclarationMValue2 { get; set; } = "0"; // default

        public string Citizenship { get; set; }
        
        public int BorrowerInterview { get; set; }
        public bool EthnicityHispanicOrLatino { get; set; }
        public bool EthnicityMexican { get; set; }
        public bool EthnicityPuertoRican { get; set; }
        public bool EthnicityCuban { get; set; }
        public bool EthnicityOrtherHispanicOrLatino { get; set; }
        public string EthnicityOrtherDescription { get; set; }
        public bool EthnicityNotHispanicOrLatino { get; set; }
        public bool EthnicityDoNotWishToProvide { get; set; }
        public int ECollectedByObservation { get; set; }
        public int SexCollectedByObservation { get; set; }
        public int RaceCollectedByObservation { get; set; }

        public int? HispanicTFallback { get; set; }
        public bool DoNotWishToFurnish { get; set; }
        public bool Lckd { get; set; }

        public bool UseOfficialContact { get; set; }

        public int? OfficialContactType { get; set; }

        public int? InterviewMethodType { get; set; }

        public bool Lock { get; set; }
        public DateTime? InterviewDate { get; set; }
        public string LoanOfficerName { get; set; }
        public string LoanOriginatorIdentifier { get; set; }
        public string LoanOfficerLicenseNumber { get; set; }
        public string LoanOfficerPhone { get; set; }
        public string LoanOfficerEmail { get; set; }
        public string LoanOfficerCompanyName { get; set; }

        #region New ULAD's Delacration

        public bool NewDecA { get; set; }

        public string NewDecA_Explanation { get; set; }

        public bool NewDecA_Yes { get; set; }

        public string NewDecA_Yes_Explanation { get; set; }

        public string NewDecA_Yes_Q1 { get; set; } = "0"; // default

        public string NewDecA_Yes_Q2 { get; set; } = "0"; // default

        public bool NewDecB { get; set; }

        public string NewDecB_Explanation { get; set; }

        public bool NewDecC { get; set; }

        public string NewDecC_Explanation { get; set; }

        public decimal NewDecC_Yes_Amount { get; set; }

        public bool NewDecD_Q1 { get; set; }

        public string NewDecD_Q1_Explanation { get; set; }

        public bool NewDecD_Q2 { get; set; }

        public string NewDecD_Q2_Explanation { get; set; }

        public bool NewDecE { get; set; }

        public string NewDecE_Explanation { get; set; }

        public bool NewDecF { get; set; }

        public string NewDecF_Explanation { get; set; }

        public bool NewDecG { get; set; }

        public string NewDecG_Explanation { get; set; }

        public bool NewDecH { get; set; }

        public string NewDecH_Explanation { get; set; }

        public bool NewDecI { get; set; }

        public string NewDecI_Explanation { get; set; }

        public bool NewDecJ { get; set; }

        public string NewDecJ_Explanation { get; set; }

        public bool NewDecK { get; set; }

        public string NewDecK_Explanation { get; set; }

        public bool NewDecL { get; set; }

        public string NewDecL_Explanation { get; set; }

        public bool NewDecM { get; set; }

        public string NewDecM_Explanation { get; set; }

        public bool NewDecM_Chapter7 { get; set; }

        public bool NewDecM_Chapter11 { get; set; }

        public bool NewDecM_Chapter12 { get; set; }

        public bool NewDecM_Chapter13 { get; set; }

        #endregion

    }
}