using Newtonsoft.Json;

namespace CSharpGalenWrapper.Layout
{
    public partial class Input
    {
        [JsonProperty("area")]
        public long[] Area { get; set; }
    }
}