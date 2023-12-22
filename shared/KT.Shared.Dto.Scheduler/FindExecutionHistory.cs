using System;

namespace KT.Shared.Dto.Scheduler
{
    [Serializable]
    public class FindExecutionHistoryRequest : BaseFindRequest
    {
        public string TriggerName { get; set; }
    }

    [Serializable]
    public class FindExecutionHistoryResponse : BaseFindResponse<ExecutionHistory>
    {
    }

    [Serializable]
    public class ExecutionHistory
    {
        #region Entity

        public string FireInstanceId { get; set; }

        public string SchedulerInstanceId { get; set; }

        public string SchedulerName { get; set; }

        public string Job { get; set; }

        public string Trigger { get; set; }

        public DateTime? ScheduledFireTimeUtc { get; set; }

        public DateTime ActualFireTimeUtc { get; set; }

        public bool Recovering { get; set; }

        public bool Vetoed { get; set; }

        public DateTime? FinishedTimeUtc { get; set; }

        public bool IsException { get; set; }

        public string ExceptionMessage { get; set; }

        public string ExecutedResult { get; set; }

        #endregion

        public string JobGroup { get; set; }

        public string JobName { get; set; }

        public string TriggerGroup { get; set; }

        public string TriggerName { get; set; }

        public string TriggerDescription { get; set; }

        public TimeSpan? Duration { get; set; }

        public string State { get; set; }
    }
}
