using System;

namespace KT.Shared.Dto.FileDB
{
    [Serializable]
    public class ExistsFileRequest : BaseFileRequest
    {
        public string[] FileNames { get; set; }
    }

    [Serializable]
    public class ExistsFileResponse : BaseFileResponse
    {
        public ExistsFile[] Results { get; set; }

        [Serializable]
        public class ExistsFile
        {
            public string FileName { get; set; }

            public bool Exits { get; set; }
        }
    }
}
