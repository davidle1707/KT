using System;

namespace KT.Shared.Dto.FileDB
{
    [Serializable]
    public class CreateFileRequest : BaseFileRequest
    {
        public string FileName { get; set; }

        public DateTime? ExpiredUtcDateAt { get; set; }

        public int? ExpiredMinutesAt { get; set; }

        internal FormFileInfo __FileInfo { get; set; }
    }

    [Serializable]
    public class CreateFileResponse : BaseFileResponse
    {
    }
}
