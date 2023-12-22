using KT.Shared.Context.CMSM.BA;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(BrokerApplication))]
    public class BrokerApplication : KTWrapMongoEntity
    {
        public BrokerCompany Company { get; set; } = new BrokerCompany();

        public int CurrentStep { get; set; }

        public List<BaseStep> StepDetails { get; set; } = new List<BaseStep>();

        public int AppStatus { get; set; }

        public ObjectId? FileId { get; set; }

        public ObjectId? FileOrgId { get; set; }

        public ObjectId? LinkOrgId { get; set; }

        public List<AppStatusLog> AppStatusLogs { get; set; } = new List<AppStatusLog>();

        public string[] LastUpdated { get; set; }

        public bool IsTest { get; set; }
    }
}
