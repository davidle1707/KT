using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(LetterTemplate))]
    public class LetterTemplate : KTWrapMongoEntity
    {
        public ObjectId OrganizationId { get; set; }

        public ObjectId? BranchId { get; set; }

        public ObjectId? OwnerId { get; set; }

        public int TemplateType { get; set; }

        public bool IsActive { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string TemplateName { get; set; }

        [BsonIgnoreIfNull]
        public SendEmailAction SendEmailAction { get; set; }
    }
}
