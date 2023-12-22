namespace KT.Utils.SendGrid.Models
{
    public class DroppedEvent : Event
    {
        public string Reason { get; set; }
        public string Status { get; set; }

        public override object ToMetadata(bool full) => full ? this : new { Reason, Status };
    }
}
