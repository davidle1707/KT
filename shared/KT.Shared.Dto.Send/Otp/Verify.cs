using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace KT.Shared.Dto.Send
{
    [Serializable]
    public class VerifyOtpRequest : KT.Common.Dto.BaseRequest
    {
        public ObjectId TransactionId { get; set; }

        public string TransactionIpAddress { get; set; }

        public string Otp { get; set; }
    }

    [Serializable]
    public class VerifyOtpResponse : KT.Common.Dto.BaseResponse
    {
    }
}
