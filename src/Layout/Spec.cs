using Newtonsoft.Json;

namespace CSharpGalenWrapper.Layout
{
    public partial class Spec
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("place")]
        public Place Place { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("errors")]
        public string[] Errors { get; set; }

        [JsonProperty("meta")]
        public Meta[] Meta { get; set; }

        [JsonProperty("highlight")]
        public string[] Highlight { get; set; }

        [JsonProperty("imageComparison")]
        public object ImageComparison { get; set; }

        [JsonProperty("subLayout")]
        public object SubLayout { get; set; }
    }
}