using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public class BorrowerDerogatorySummary
    {
        public int Total30DaysLate { get; set; }

        public int Total60DaysLate { get; set; }

        public int Total90DaysLate { get; set; }

        public int TotalCollection { get; set; }

        public int TotalLienOrJudment { get; set; }
    }
}
