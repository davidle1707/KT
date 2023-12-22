using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(ClientContact))]
    public partial class ClientContact : KTWrapMongoEntity
    {
        public ObjectId OrganizationId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string WorkPhone { get; set; }

        public string WorkPhoneExtension { get; set; }

        public string CellPhone { get; set; }

        public string Email { get; set; }

        public string NmlsLicense { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public int Status { get; set; }

        public string StatusDescription { get; set; }

        public ObjectId? OwnerId { get; set; }

        [BsonIgnoreIfNull]
        public ObjectId? LinkUserId { get; set; }

        public List<Note> Notes { get; set; } = new List<Note>();

        public List<OwnerLog> OwnerLogs { get; set; } = new List<OwnerLog>();

        public List<StatusLog> StatusLogs { get; set; } = new List<StatusLog>();

        public List<SendLog> SendLogs { get; set; } = new List<SendLog>();
    }

    public partial class ClientContact
    {
        /// <summary>
        /// Currently not set to db, only use in Find function => Aggregate.AddFields
        /// </summary>
        [BsonIgnoreIfNull]
        public DateTime? LastSendDate { get; set; }

        /// <summary>
        /// Currently not set to db, only use in Find function => Aggregate.AddFields
        /// </summary>
        [BsonIgnoreIfNull]
        public DateTime? LastStatusOpenDate { get; set; }

        [Serializable]
        public abstract class Child : KTWrapMongoEntity
        {
        }

        [Serializable]
        public class OwnerLog : Child
        {
            public ObjectId OwnerId { get; set; }
        }

        [Serializable]
        public class StatusLog : Child
        {
            public int Status { get; set; }

            [BsonIgnoreIfNull]
            public ObjectId? SendLogId { get; set; }
        }

        [Serializable]
        public class Note : Child
        {
            public string Content { get; set; }
        }

        [Serializable]
        public class SendLog : Child
        {
            public string Type { get; set; } // emai, sms

            public string MessageEventName { get; set; }

            public DateTime? MessageEventDate { get; set; }

            public ObjectId? ScheduleTriggerId { get; set; }

            public ObjectId? QueueJobId { get; set; }

            public ObjectId? EmailLogId { get; set; }

            public string BatchName { get; set; }

            [BsonIgnoreIfNull]
            public string GroupName { get; set; }

            [BsonIgnoreIfNull]
            public DateTime? GroupDate { get; set; }
        }
    }
}
