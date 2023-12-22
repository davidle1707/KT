namespace KT.Utils.SendGrid.Models
{
    public class DeliveredEvent : Event
    {
        public string Response { get; set; }

        public override object ToMetadata(bool full) => full ? this : new { Response };
    }
}
