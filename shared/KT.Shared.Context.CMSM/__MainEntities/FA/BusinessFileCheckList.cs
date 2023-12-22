using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public class BusinessFileCheckList
    {
        public ObjectId? QuestionnaireId { get; set; }

        public ObjectId? QuestionnaireAnswerId { get; set; }
    }
}
