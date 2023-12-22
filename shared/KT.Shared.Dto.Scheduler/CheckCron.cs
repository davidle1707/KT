using System;
using System.Collections.Generic;
using System.Linq;

namespace KT.Shared.Dto.Scheduler
{
    [Serializable]
    public class CheckCronRequest
    {
        public string Expression { get; set; }

        public bool IsGetDesc { get; set; }

        public bool IsGetNextDates { get; set; }

        public DateTime? NextUtcDateAt { get; set; }

        public int NextDateCount { get; set; } = 10;
    }

    [Serializable]
    public partial class CheckCronResponse : BaseResponse
    {
        public CronSummary Summary { get; set; }

        public string Description { get; set; }

        public List<DateTime> NextUtcDates { get; set; }
    }

    public partial class CheckCronResponse
    {
        [Serializable]
        public class CronSummary
        {
            public string Seconds { get; set; }

            public string Minutes { get; set; }

            public string Hours { get; set; }

            public string Months { get; set; }

            public string Years { get; set; }

            public string DaysOfMonth { get; set; }

            public string DaysOfWeek { get; set; }

            public CronSummary(string summary = null)
            {
                if (!string.IsNullOrWhiteSpace(summary))
                {
                    var values = summary.Trim().Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var prop in this.GetType().GetProperties())
                    {
                        var valItem = values.FirstOrDefault(a => a.StartsWith(prop.Name, StringComparison.OrdinalIgnoreCase));
                        if (!string.IsNullOrWhiteSpace(valItem))
                        {
                            prop.SetValue(this, valItem.Split(':')[1].Trim());
                        }
                    }
                }

            }
        }
    }
}
