using System;

namespace KT.Shared.Dto.Scheduler
{
    [Serializable]
    public class AddSimpleTriggerRequest : BaseAddTriggerRequest
    {
        public bool IsNoRepeat { get; set; }

        public int RepeatIntervalSeconds { get; set; }

        /// <summary>
        /// -1 => forever
        /// </summary>
        public int RepeatCount { get; set; }

        public override bool IsValid => base.IsValid && (IsNoRepeat || (RepeatIntervalSeconds > 1 && RepeatCount >= -1));
    }

    [Serializable]
    public class AddSimpleTriggerResponse : BaseAddTriggerResponse
    {
        
    }
}
