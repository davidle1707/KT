using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(GenCode))]
    public class GenCode : KTWrapMongoEntity
    {
    }

}
