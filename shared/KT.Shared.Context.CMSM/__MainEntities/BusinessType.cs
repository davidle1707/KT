using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(BusinessType))]
    public class BusinessType : KTWrapMongoEntity
    {
        public int Type { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}