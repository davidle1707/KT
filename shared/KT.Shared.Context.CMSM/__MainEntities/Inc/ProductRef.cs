using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public class ProductRef : KTWrapMongoEntityId
    {
        public string Name { get; set; }

        public string Reference { get; set; }
    }

    [Serializable]
    public class RateRef : KTWrapMongoEntityId
    {
        public string Name { get; set; }

        public string Reference { get; set; }
    }

    [Serializable]
    public class FeeRef : KTWrapMongoEntityId
    {
        public string Name { get; set; }

        public string Reference { get; set; }
    }
}
