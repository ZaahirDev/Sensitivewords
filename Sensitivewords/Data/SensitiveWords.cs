using Newtonsoft.Json;

namespace Sensitivewords.Data
{
    public class SensitiveWords
    {

        [JsonProperty("name")]
        public int Name { get; set; }

        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Word")]
        public string? Word { get; set; }
    }
}
