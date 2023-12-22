using System;

namespace KT.Shared.Context.CMSM.FileDbEntities
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(FileExpire))]
    public class FileExpire : KTWrapMongoEntity
    {
        public DateTime ExpiredAt { get; set; }
    }
}
