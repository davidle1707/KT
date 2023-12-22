using System;
using System.ComponentModel.DataAnnotations;

namespace KT.Shared.Dto.FileDB
{
    [Serializable]
    public class DeleteFileRequest : BaseFileRequest
    {
        [Required]
        public string FileName { get; set; }
    }

    [Serializable]
    public class DeleteFileResponse : BaseFileResponse
    {
    }
}
