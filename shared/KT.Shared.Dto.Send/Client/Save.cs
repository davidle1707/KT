using System;
using Newtonsoft.Json;

namespace KT.Shared.Dto.Send.Client
{
    [Serializable]
    public class SaveClientRequest : KT.Common.Dto.BaseRequest
    {
        public string Name { get; set; }

        public string SmsDefaultNumber { get; set; }

        public string EmailDefaultAddress { get; set; }

        public string EmailDefaultFullName { get; set; }

        public ClientOtpSettingDto OtpSetting { get; set; }
    }

    [Serializable]
    public class SaveClientResponse : KT.Common.Dto.BaseResponse
    {
        [JsonProperty("ClientId")]
        public string PublishId { get; set; }

        public string ApiKey { get; set; }
    }
}
