using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace KT.Shared.Dto.Send
{
    [Serializable]
    public class SendEmailRequest : KT.Common.Dto.BaseRequest
    {
        public string SettingName { get; set; }

        public EmailAddress From { get; set; }

        /// <summary>
        /// Required or Optinal (if CC > 0)
        /// </summary>
        public List<EmailAddress> To { get; set; } = new();

        /// <summary>
        /// Required or Optinal (if To > 0)
        /// </summary>
        public List<EmailAddress> CC { get; set; } = new();

        public List<EmailAddress> Bcc { get; set; } = new();

        /// <summary>
        /// Required
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        public string Body { get; set; }

        public List<string> Categories { get; set; } = new();

        public List<EmailAttachmentBase64> Attachments { get; set; } = new();
    }

    [Serializable]
    public class SendEmailResponse : KT.Common.Dto.BaseResponse
    {
        public string MessageId { get; set; }

        public ObjectId? LogId { get; set; }
    }
}
