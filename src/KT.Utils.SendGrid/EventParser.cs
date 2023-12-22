using KT.Utils.SendGrid.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace KT.Utils.SendGrid
{
    public class EventParser
    {
        public static async Task<(string Json, IEnumerable<Event> Events)> ParseAsync(Stream stream, bool nullIfError = true)
        {
            var reader = new StreamReader(stream);
            var json = await reader.ReadToEndAsync();

            return (json, Parse(json, nullIfError));
        }

        public static (string Json, IEnumerable<Event> Events) Parse(Stream stream, bool nullIfError = true)
        {
            var reader = new StreamReader(stream);
            var json = reader.ReadToEnd();

            return (json, Parse(json, nullIfError));
        }

        public static IEnumerable<Event> Parse(string json, bool nullIfError = true)
            => JsonConvert.DeserializeObject<IEnumerable<Event>>(json, new EventConverter(nullIfError));
    }
}
