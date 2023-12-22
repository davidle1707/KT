using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(EmailServer))]
    public class EmailServer : KTWrapMongoEntity
    {
        public string ServerName { get; set; }

        public string IncomingServer { get; set; }

        public string OutgoingServer { get; set; }

        public bool OutgoingServerEnableSsl { get; set; }

        public int OutgoingServerPort { get; set; }

        public bool OutgoingRequireAnthen { get; set; }

        public string DefaultUserName { get; set; }

        public string DefaultPassword { get; set; }
    }
}
