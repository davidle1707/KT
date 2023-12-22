using KT.Shared.Dto.Send.Inc;
using System;

namespace KT.Shared.Dto.Send
{
    [Serializable]
    public class ClientOtpSettingDto
    {
        public string Name { get; set; }

        public OtpSettingDto Setting { get; set; }
    }
}
