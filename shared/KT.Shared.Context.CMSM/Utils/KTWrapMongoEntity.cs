#if !CMSM_NETCORE
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
#endif
using System;

namespace KT.Shared.Context
{

#if CMSM_NETCORE

    [Serializable]
    public class KTWrapMongoEntity : KT.Common.MongoEntity
    {
    }

    [Serializable]
    public class KTWrapMongoEntityId : KT.Common.MongoEntityId
    {
    }

    public interface IKTWrapCheckListItem 
    {
        string ListItemId { get; }

        string ListItemName { get; }
    }

#else
    [Serializable]
    public class KTWrapMongoEntity : BaseOldEntity
    {
    }

    [Serializable]
    public class KTWrapMongoEntityId : BaseOldEntityOnlyId
    {

    }

    public interface IKTWrapCheckListItem: ML.Utils.ObjectChange.ICheckListItem {  }

    [Serializable]
    public class BaseOldEntity : BaseOldEntityOnlyId
    {
        [BsonIgnoreIfNull, ChangeIgnoreCheck]
        public string Description { get; set; }

        [BsonIgnoreIfNull, ChangeIgnoreCheck]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [BsonIgnoreIfNull, ChangeIgnoreCheck]
        public ObjectId? CreatedBy { get; set; }

        [BsonIgnoreIfNull, ChangeIgnoreCheck]
        public DateTime? ModifiedDate { get; set; }

        [BsonIgnoreIfNull, ChangeIgnoreCheck]
        public ObjectId? ModifiedBy { get; set; }

        [BsonIgnoreIfNull, ChangeIgnoreCheck]
        public DateTime? DeletedDate { get; set; }

        [BsonIgnoreIfNull, ChangeIgnoreCheck]
        public ObjectId? DeletedBy { get; set; }
    }

    [Serializable]
    public class BaseOldEntityOnlyId : ML.Utils.MongoDb.BaseEntity
    {
    }
#endif
}
