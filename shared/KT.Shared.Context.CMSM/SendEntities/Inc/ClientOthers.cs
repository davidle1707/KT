using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM.SendEntities.Inc
{
    [Serializable]
    [BsonDiscriminator(Required = true)]
    [BsonKnownTypes(typeof(Sms), typeof(Email))]
    public abstract class ClientSetting
    {
        public string Name { get; set; }

        public int SettingType { get; set; }

        public ObjectId SettingId { get; set; }

        [Serializable]
        [BsonDiscriminator(nameof(Sms), Required = true)]
        public class Sms : ClientSetting
        {
            public string DefaultNumber { get; set; }
        }

        [Serializable]
        [BsonDiscriminator(nameof(Email), Required = true)]
        public class Email : ClientSetting
        {
            public string DefaultAddress { get; set; }

            public string DefaultFullName { get; set; }
        }
    }

    [Serializable]
    public class ClientOtpSetting
    {
        public string Name { get; set; }

        public OTPSetting Setting { get; set; }
    }

    [Serializable]
    public class ClientApiKey
    {
        public string Name { get; set; }

        public string Key { get; set; }

        public bool IsActive { get; set; }

        public bool HasEmail { get; set; }

        public bool HasSms { get; set; }
    }
}


