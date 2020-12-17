using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Extensions

{
    public class Node
    {
        public string Name { get; set; } = "";
        public int? Cost { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Priority Priority { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Currency Currency { get; set; }
    }
}