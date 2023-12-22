using System;
using System.IO;

namespace KT.Shared.Dto.FileDB
{
    [Serializable]
    public class FormFileInfo
    {
        public string Name { get; set; }

        public string ContentType { get; set; }

        public Stream Contents { get; set; }
    }
}
