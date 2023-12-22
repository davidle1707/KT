using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace KT.Shared.Dto.Send
{
    [Serializable]
    public class SendSmsRequest : KT.Common.Dto.BaseRequest
    {
        public string SettingName { get; set; }

        public string FromNumber { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        public string ToNumber { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        public string Message { get; set; }

        public List<string> Categories { get; set; } = new List<string>();
    }

    [Serializable]
    public class SendSmsResponse : KT.Common.Dto.BaseResponse
    {
        public string MessageId { get; set; }

        public string MessageStatus { get; set; }

        public ObjectId? LogId { get; set; }
    }
}
