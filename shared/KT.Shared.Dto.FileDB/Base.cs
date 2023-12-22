using System;
using System.IO;
using System.Linq;

namespace KT.Shared.Dto.FileDB
{
    [Serializable]
    public class BaseFileRequest : KT.Common.Dto.BaseRequest
    {
        public string Client { get; set; }

        internal string __Project { get; set; }

        internal string ClientPath(params string[] filePaths)
        {
            if (filePaths == null || filePaths.Length == 0)
            {
                return Client;
            }

            if (filePaths.Length == 1)
            {
                return Path.Combine(Client, filePaths[0]);
            }

            return Path.Combine(new[] { Client }.Union(filePaths).ToArray());
        }
    }

    [Serializable]
    public class BaseFileResponse : KT.Common.Dto.BaseResponse
    {
    }
}



