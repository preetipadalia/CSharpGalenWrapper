using Newtonsoft.Json;

namespace CSharpGalenWrapper.Layout
{
    public partial class From
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("edge")]
        public string Edge { get; set; }
    }
}