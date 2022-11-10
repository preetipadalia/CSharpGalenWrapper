using Newtonsoft.Json;

namespace CSharpGalenWrapper.Layout
{
    public partial class Place
    {
        [JsonProperty("filePath")]
        public string FilePath { get; set; }

        [JsonProperty("lineNumber")]
        public long LineNumber { get; set; }
    }
}