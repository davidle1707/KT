using System;
using System.ComponentModel.DataAnnotations;

namespace KT.Shared.Dto.FileDB
{
    [Serializable]
    public class CopyFileRequest : BaseFileRequest
    {
        [Required]
        public string FromFileName { get; set; }

        [Required]
        public string ToFileName { get; set; }

        public bool DeleteFrom { get; set; }
    }

    [Serializable]
    public class CopyFileResponse : BaseFileResponse
    {
    }
}
