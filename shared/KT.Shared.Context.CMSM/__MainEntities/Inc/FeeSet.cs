using System;

namespace KT.Shared.Context.CMSM.Inc
{

    [Serializable]
    public class FeeSet : KTWrapMongoEntityId
    {
        public int HUDItem { get; set; }

        public string FeeName { get; set; }

        public double FeeValue { get; set; }

        public bool IsPercent { get; set; }

        public bool APRCalculate { get; set; }
    }
}
