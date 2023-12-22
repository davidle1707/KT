using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(MasterFeesSetup))]
    public class MasterFeesSetup : KTWrapMongoEntity
    {
        public int HUDItem { get; set; }

        public string FeeName { get; set; }

        public double FeeValue { get; set; }

        public bool IsPercent { get; set; }

        public bool APRCalculate { get; set; }

        public bool DisplayDescription { get; set; }

        public double FeeValueAmount { get; set; }

        public double FeeValuePercent { get; set; }

        public bool UseFeePercent { get; set; }

        public bool UseFeeAmount { get; set; } = true;

    }
}
