using Newtonsoft.Json;

namespace KT.Utils.SendGrid.Models
{
    public class GroupUnsubscribeEvent : ClickEvent
    {
        [JsonProperty("asm_group_id")]
        public int AsmGroupId { get; set; }

        public override object ToMetadata(bool full) => full ? this : new { AsmGroupId };
    }
}
