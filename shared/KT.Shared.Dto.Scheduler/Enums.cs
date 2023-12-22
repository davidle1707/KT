using System.ComponentModel;

namespace KT.Shared.Dto.Scheduler
{
    public enum JobType
    {
        [Description(StdJobNames.Test)]
        Test,

        [Description(StdJobNames.CallApi)]
        CallApi
    }
}
