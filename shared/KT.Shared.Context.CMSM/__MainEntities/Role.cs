
using KT.Shared.Context.CMSM.Inc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
	[Serializable]
    [KTWrapMongoCollectionName(typeof(Role))]
    public class Role : KTWrapMongoEntity, IIdName
	{
        public string Name { get; set; }
        
        public ObjectId OrganizationId { get; set; }

        public ObjectId? BranchId { get; set; }

        public int? Department { get; set; }

        public List<RoleStage> Stages { get; set; } = new List<RoleStage>();

        public List<RoleContent> Contents { get; set; } = new List<RoleContent>();

        public RolePipeline Pipeline { get; set; }

        public ReportSetting Report { get; set; } = new ReportSetting();
    }
}
