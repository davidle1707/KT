using System;

namespace KT.Shared.Context.CMSM.BA
{
    [Serializable]
    public sealed class AppStatusLog : KTWrapMongoEntity
    {
        public int Status { get; set; }
    }
}
