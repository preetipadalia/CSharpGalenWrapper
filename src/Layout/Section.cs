using Newtonsoft.Json;

namespace CSharpGalenWrapper.Layout
{
    public partial class Section
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("place")]
        public Place Place { get; set; }

        [JsonProperty("objects")]
        public Object[] Objects { get; set; }

        [JsonProperty("sections")]
        public object Sections { get; set; }
    }
}