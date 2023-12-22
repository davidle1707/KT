using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(AppSetting))]
    public class AppSetting : KTWrapMongoEntity, IIdName
    {
        public int SettingType { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public int Priority { get; set; }

        public int IdAsInt { get; set; }

        public ObjectId OrganizationId { get; set; }

        public string ForType { get; set; } = "CMSM";

        [BsonIgnoreIfNull]
        public string LqbValue { get; set; }

        [BsonIgnoreIfNull]
        public string ByteProValue { get; set; }

        public bool Enable { get; set; }

        [BsonIgnoreIfNull]
        public string ShortText { get; set; }
    }
}
