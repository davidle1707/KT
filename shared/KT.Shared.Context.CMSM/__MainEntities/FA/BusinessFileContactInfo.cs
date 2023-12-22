using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public class BusinessFileContactInfo
    {
        public string LoanOfficerName { get; set; }
        public string LoanOfficerPhone { get; set; }
        public string LoanOfficerEmail { get; set; }

        public string LoanProcessorName { get; set; }
        public string LoanProcessorPhone { get; set; }
        public string LoanProcessorEmail { get; set; }

        public string AppraisalName { get; set; }
        public string AppraisalPhone { get; set; }
        public string AppraisalEmail { get; set; }

        public string EscrowOfficerName { get; set; }
        public string EscrowOfficerPhone { get; set; }
        public string EscrowOfficerEmail { get; set; }

        public string TitleOfficerName { get; set; }
        public string TitleOfficerPhone { get; set; }
        public string TitleOfficerEmail { get; set; }
    }
}
