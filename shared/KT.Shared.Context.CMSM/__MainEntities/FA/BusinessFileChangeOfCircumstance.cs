using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public class BusinessFileChangeOfCircumstance: KTWrapMongoEntity, IKTWrapCheckListItem
    {
        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? DateOfLoanEstimate { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? DateOfChange { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime? DateOfReDisclosure { get; set; }
        
        public string COCCategory { get; set; }

        public string COCReason { get; set; }

        public string ExplanationOfChange { get; set; }

        public int Status { get; set; }

        public List<ChangeOfCircumstanceNotifyRequest> NotifyRequests { get; set; }

        public string ListItemId => Id.ToString();

        public string ListItemName => Id.ToString();
    }

    [Serializable]
    public class ChangeOfCircumstanceNotifyRequest : KTWrapMongoEntity
    {

    }
}
