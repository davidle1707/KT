using System;
using static KT.Shared.Dto.Scheduler.CheckCronResponse;

namespace KT.Shared.Dto.Scheduler
{
    [Serializable]
    public class AddCronTriggerRequest : BaseAddTriggerRequest
    {
        public string Expression { get; set; }

        public override bool IsValid => base.IsValid && !string.IsNullOrWhiteSpace(Expression);
    }

    [Serializable]
    public class AddCronTriggerResponse : BaseAddTriggerResponse
    {
        public CronSummary CronSummary { get; set; }
    }
}
