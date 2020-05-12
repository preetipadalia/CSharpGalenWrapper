using System.Collections.Generic;
using Newtonsoft.Json;
namespace CSharpGalenWrapper.Report
{

    public partial class LayoutReport
    {
        [JsonProperty("title")]
        public object Title { get; set; }

        [JsonProperty("includedTags")]
        public object IncludedTags { get; set; }

        [JsonProperty("excludedTags")]
        public object[] ExcludedTags { get; set; }

        [JsonProperty("sections")]
        public Section[] Sections { get; set; }

        [JsonProperty("objects")]
        public Dictionary<string,LayoutObjectDetails> Objects { get; set; }

        [JsonProperty("screenshot")]
        public string Screenshot { get; set; }
    }

   

    public partial class Input
    {
        [JsonProperty("area")]
        public long[] Area { get; set; }
    }

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

    public partial class From
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("edge")]
        public string Edge { get; set; }
    }

    public partial class Place
    {
        [JsonProperty("filePath")]
        public string FilePath { get; set; }

        [JsonProperty("lineNumber")]
        public long LineNumber { get; set; }
    }
    
}
