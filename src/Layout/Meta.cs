using Newtonsoft.Json;

namespace CSharpGalenWrapper.Layout
{
    public partial class Meta
    {
        [JsonProperty("from")]
        public From From { get; set; }

        [JsonProperty("to")]
        public From To { get; set; }

        [JsonProperty("expectedDistance")]
        public string ExpectedDistance { get; set; }

        [JsonProperty("realDistance")]
        public string RealDistance { get; set; }
    }
}