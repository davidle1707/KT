using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM.FileDbEntities
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(FileExpireInfo))]
    public class FileExpireInfo : KTWrapMongoEntity
    {
        public List<string> Paths { get; set; } = new List<string>();

        public string FileName { get; set; }
    }
}
