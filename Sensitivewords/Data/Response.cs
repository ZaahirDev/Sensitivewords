using Newtonsoft.Json;

namespace Sensitivewords.Data
{
    public class Response
    {
        
        [JsonProperty("name")]
        public int Name { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("word")]
        public int Word { get; set; }

        [JsonProperty("data")]
        public List<SensitiveWords> SensitiveWords { get; set; }
    }
}