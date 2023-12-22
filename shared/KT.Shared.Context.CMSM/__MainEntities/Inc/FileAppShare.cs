using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public abstract class FileAppShare : KTWrapMongoEntity
    {
        public List<ObjectId> FileIds { get; set; } = new List<ObjectId>();

        public List<int> FileNumbers { get; set; } = new List<int>();

        public List<ObjectId> OrgIds { get; set; } = new List<ObjectId>();

        public void SetShareInfo(ObjectId orgId, ObjectId fileId, int fileNumber)
        {
            if (!OrgIds.Contains(orgId))
            {
                OrgIds.Add(orgId);
            }

            if (!FileIds.Contains(fileId))
            {
                FileIds.Add(fileId);
            }

            if (!FileNumbers.Contains(fileNumber))
            {
                FileNumbers.Add(fileNumber);
            }
        }
    }
}
