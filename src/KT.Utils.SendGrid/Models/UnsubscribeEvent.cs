namespace KT.Utils.SendGrid.Models
{
    public class UnsubscribeEvent : Event
    {
        public string UserAgent { get; set; }

        public string IP { get; set; }

        public override object ToMetadata(bool full) => full ? this : new { IP, UserAgent };
    }
}
