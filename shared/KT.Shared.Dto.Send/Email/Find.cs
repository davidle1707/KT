using System;
using KT.Common.Dto;

namespace KT.Shared.Dto.Send
{
    [Serializable]
    public partial class FindEmailLogRequest : FindRequest
    {
        public bool? Success { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public string Cc { get; set; }

        public string Bcc { get; set; }

        public string Subject { get; set; }

        public CategoryFilter[] Categories { get; set; }
    }

    public partial class FindEmailLogRequest
    {
        public class CategoryFilter
        {
            public string[] Categories { get; set; }

            public ListFilterMode ListMode { get; set; } = ListFilterMode.In;
        }
    }

    [Serializable]
    public class FindEmailLogResponse : FindResponse<EmailLogDto>
    {
    }

    [Serializable]
    public class EmailLogDto : BaseIdDto
    {
        public DateTime CreatedDate { get; set; }

        public bool Success { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public string Cc { get; set; }

        public string Bcc { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public string[] Categories { get; set; }
    }
}
