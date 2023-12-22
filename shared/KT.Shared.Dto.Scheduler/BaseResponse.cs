using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KT.Shared.Dto.Scheduler
{
    [Serializable]
    public class BaseResponse
    {
        public bool Success => Errors == null || Errors.Count == 0;

        public List<string> WarnMessages { get; set; }

        public List<ErrorItem> Errors { get; set; }

        [JsonIgnore]
        public IEnumerable<string> ErrorMessages => Errors?.Select(a => a.Message);

        public void AddError(string msg = "", int code = 500)
        {
            Errors ??= new List<ErrorItem>();
            Errors.Add(new ErrorItem(msg, code));
        }

        public void AddErrors(IEnumerable<ErrorItem> items)
        {
            Errors ??= new List<ErrorItem>();
            Errors.AddRange(items);
        }

        public static TResponse Create<TResponse>() where TResponse : BaseResponse, new() => new TResponse { };

        public static TResponse CreateError<TResponse>(params string[] messages) where TResponse : BaseResponse, new() => new TResponse
        {
            Errors = messages.Select(msg => new ErrorItem(msg)).ToList()
        };

        public static TResponse CreateError<TResponse>(params ErrorItem[] items) where TResponse : BaseResponse, new() => new TResponse
        {
            Errors = new List<ErrorItem>(items)
        };

        [Serializable]
        public class ErrorItem
        {
            public int? Code { get; set; }

            public string Message { get; set; }

            public ErrorItem(string message = "", int? code = 500)
            {
                Code = code;
                Message = message;
            }
        }
    }

    [Serializable]
    public class BaseTriggerRequest
    {
        private string _name;
        public string Name { get => _name.ToLower(); set => _name = value; }

        private string _group;
        internal string __Group { get => string.IsNullOrWhiteSpace(_group) ? null : _group.ToLower(); set => _group = value; }

        private string _timeZone = "Pacific Standard Time";
        public string TimeZone { get => string.IsNullOrWhiteSpace(_timeZone) ? "Pacific Standard Time" : _timeZone; set => _timeZone = value; }

        public bool LogExecutedHistory { get; set; } = true;

        public bool LogExecutedResult { get; set; } = true;

        public virtual bool IsValid => !string.IsNullOrWhiteSpace(_name) && !string.IsNullOrWhiteSpace(_group);
    }

    [Serializable]
    public abstract class BaseAddTriggerRequest : BaseTriggerRequest
    {
        public JobType Job { get; set; }

        public string Description { get; set; }

        public DateTime? UtcStartAt { get; set; }

        public DateTime? UtcEndAt { get; set; }

        public JObject Metadata { get; set; }

        public string IgnoreTimes { get; set; }

        public string IgnoreDays { get; set; }
    }

    [Serializable]
    public class BaseAddTriggerResponse : BaseResponse
    {
        public string Name { get; set; }
    }

    [Serializable]
    public class BaseFindRequest
    {
        private string _group;
        internal string __Group { get => string.IsNullOrWhiteSpace(_group) ? null : _group.ToLower(); set => _group = value; }

        public FindPaging Paging { get; set; } = new FindPaging { Index = 1, Size = 20 };
    }

    [Serializable]
    public class BaseFindResponse<T> : BaseResponse
    {
        public List<T> Records { get; set; } = new List<T>();

        public long TotalRecords { get; set; }
    }

    [Serializable]
    public class FindPaging
    {
        public int Index { get; set; }

        public int Size { get; set; }
    }
}
