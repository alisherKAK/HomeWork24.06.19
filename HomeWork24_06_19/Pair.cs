using Newtonsoft.Json;

namespace HomeWork24_06_19
{
    public class Pair
    {
        [JsonProperty("fname")]
        public string MaleName { get; set; }

        [JsonProperty("sname")]
        public string FemaleName { get; set; }

        [JsonProperty("percentage")]
        public string Percentage { get; set; }

        [JsonProperty("result")]
        public string Comment { get; set; }
    }
}
