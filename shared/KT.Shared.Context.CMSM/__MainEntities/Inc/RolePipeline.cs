using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public class RolePipeline
    {
        public List<RolePipelineFileSetting> FileSettings { get; set; } = new List<RolePipelineFileSetting>();
    }

    public class RolePipelineFileSetting
    {
        public int BusinessType { get; set; }

        public ObjectId StageId { get; set; }

        public List<int> EditFields { get; set; } = new List<int>();
    }
}
