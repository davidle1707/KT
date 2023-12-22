namespace KT.Utils.SendGrid.Models
{
    public class ProcessedEvent : Event
    {
        public Pool Pool { get; set; }

        public override object ToMetadata(bool full) => full ? this : new { PoolId = Pool?.Id, PoolName = Pool?.Name };
    }
}
