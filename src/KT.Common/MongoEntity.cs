using MongoDB.Bson.Serialization.Attributes;

namespace KT.Common;

[Serializable]
public class MongoEntity : MongoEntityId
{
    public DateTime CreatedDate { get; set; }

    [BsonIgnoreIfNull]
    public ObjectId? CreatedBy { get; set; }

    [BsonIgnoreIfNull]
    public DateTime? ModifiedDate { get; set; }

    [BsonIgnoreIfNull]
    public ObjectId? ModifiedBy { get; set; }

    [BsonIgnoreIfNull]
    public DateTime? DeletedDate { get; set; }

    [BsonIgnoreIfNull]
    public ObjectId? DeletedBy { get; set; }

    [BsonIgnoreIfNull]
    public string Description { get; set; }
}

[Serializable]
public class MongoEntityId
{
    public MongoEntityId(bool newId = true)
    {
        if (newId)
        {
            Id = ObjectId.GenerateNewId();
        }
    }

    [BsonId]
    public ObjectId Id { get; set; }
}