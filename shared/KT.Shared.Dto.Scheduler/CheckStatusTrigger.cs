using System;
using System.Collections.Generic;

namespace KT.Shared.Dto.Scheduler
{
    [Serializable]
    public class CheckStatusTriggerRequest
    {
        private string _group;
        internal string __Group { get => string.IsNullOrWhiteSpace(_group) ? null : _group.ToLower(); set => _group = value; }

        public List<string> Names { get; set; } = new List<string>();

        public bool CheckExecution { get; set; }
    }

    [Serializable]
    public class CheckStatusTriggerResponse : BaseResponse
    {
        public List<TriggerStatus> StatusList { get; set; } = new List<TriggerStatus>();

        [Serializable]
        public class TriggerStatus
        {
            public string Name { get; set; }

            public string Status { get; set; }

            public TriggerExecution Execution { get; set; }
        }

        [Serializable]
        public class TriggerExecution
        {
            public DateTime? ScheduledFireTimeUtc { get; set; }

            public DateTime ActualFireTimeUtc { get; set; }

            public DateTime? NextFireTimeUtc { get; set; }

            public TimeSpan RunTime { get; set; }
        }
    }
}
