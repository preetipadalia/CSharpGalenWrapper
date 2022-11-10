using Newtonsoft.Json;

namespace CSharpGalenWrapper.Layout
{
    public partial class Object
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("specs")]
        public Spec[] Specs { get; set; }

        [JsonProperty("specGroups")]
        public object SpecGroups { get; set; }

        [JsonProperty("area")]
        public object Area { get; set; }
    }
}