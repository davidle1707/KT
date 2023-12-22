using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace KT.Shared.Context.CMSM.PaymentEntities.Inc
{
    [Serializable]
    public class CmsmFileInfo
    {
        public List<ObjectId> Ids { get; set; }

        public List<int> Numbers { get; set; }

        public List<ObjectId> OrgIds { get; set; }

        public ObjectId ShareDataId { get; set; }
    }
}
