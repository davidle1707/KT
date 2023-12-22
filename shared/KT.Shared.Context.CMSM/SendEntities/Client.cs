using KT.Shared.Context.CMSM.SendEntities.Inc;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM.SendEntities
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(Client))]
    public class Client : KTWrapMongoEntity
    {
        public string Name { get; set; }

        public bool IsActive { get; set; }

        /// <summary>
        /// ClientId given for end user, must be unique
        /// </summary>
        public string PublishId { get; set; }

        public List<ClientApiKey> ApiKeys { get; set; } = new();

        public List<ClientSetting> Settings { get; set; } = new();

        public List<ClientOtpSetting> OtpSettings { get; set; } = new();
    }
}
