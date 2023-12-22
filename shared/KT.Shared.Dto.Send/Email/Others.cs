using System;

namespace KT.Shared.Dto.Send
{
    [Serializable]
    public class EmailAddress
    {
        public string Address { get; set; }

        public string DisplayName { get; set; }

        public override string ToString() => string.IsNullOrWhiteSpace(DisplayName) ? Address : $"{DisplayName} ({Address})";

        public EmailAddress()
        {
        }

        public EmailAddress(string address, string displayName) : this()
        {
            Address = address;
            DisplayName = displayName;
        }

        public static implicit operator EmailAddress(string address) => new EmailAddress(address, null);
    }

    [Serializable]
    public class EmailAttachmentBase64
    {
        public string Content { get; set; }
      
        public string MediaType { get; set; }
      
        public string FileName { get; set; }
      
        public string Disposition { get; set; }
      
        public string ContentId { get; set; }
    }
}
