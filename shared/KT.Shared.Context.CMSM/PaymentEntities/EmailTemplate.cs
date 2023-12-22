using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM.PaymentEntities
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(EmailTemplate))]
    public class EmailTemplate : KTWrapMongoEntity
    {
    }

}
