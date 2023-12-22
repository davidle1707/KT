namespace KT.Utils.SendGrid.Models
{
    public class DeferredEvent : DeliveredEvent
    {
        public int Attempt { get; set; }

        public override object ToMetadata(bool full) => full ? this : new { Attempt };
    }
}
