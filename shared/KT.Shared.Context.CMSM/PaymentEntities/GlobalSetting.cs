using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KT.Shared.Context.CMSM.PaymentEntities
{
    [Serializable]
    [BsonDiscriminator(Required = true)]
    [KTWrapMongoCollectionName(typeof(GlobalSetting))]
    public partial class GlobalSetting
    {
    }

    //[BsonKnownTypes(typeof(EmailSetting))]
    //public partial class GlobalSetting
    //{
    //    [Serializable]
    //    [BsonDiscriminator(nameof(EmailSetting), Required = true)]
    //    public partial class EmailSetting : GlobalSetting
    //    {
    //    }
    //}
}
