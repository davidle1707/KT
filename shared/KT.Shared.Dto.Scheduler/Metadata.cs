using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace KT.Shared.Dto.Scheduler
{
    [Serializable]
    public abstract class TriggerMetadata
    {
        public abstract bool IsValid();
    }


    [Serializable]
    public class CallApiMetadata : TriggerMetadata
    {
        public string Url { get; set; }

        public string Method { get; set; }

        public string AuthenSchema { get; set; }

        public string AuthenParameter { get; set; }

        public Dictionary<string, string> Headers { get; set; }

        public Dictionary<string, string> QueryStrings { get; set; }

        public JObject Body { get; set; }

        public override bool IsValid() => !string.IsNullOrWhiteSpace(Url) && !string.IsNullOrWhiteSpace(Method);
    }

    [Serializable]
    public class SendGridMetadata : TriggerMetadata
    {
        public string SendGridKey { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public MailAddress From { get; set; }

        public List<MailAddress> To { get; set; }

        public List<MailAddress> CC { get; set; }

        public List<MailAddress> Bcc { get; set; }

        public override bool IsValid() => !string.IsNullOrWhiteSpace(SendGridKey) 
            && !string.IsNullOrWhiteSpace(Subject)
            && !string.IsNullOrWhiteSpace(From?.Address)
            && To?.Count > 0;

        [Serializable]
        public class MailAddress
        {
            public string Address { get; set; }

            public string DisplayName { get; set; }
        }
    }
}
