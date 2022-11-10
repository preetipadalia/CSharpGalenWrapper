using System.Collections.Generic;
using Newtonsoft.Json;

namespace CSharpGalenWrapper.Layout
{
    public partial class LayoutReport
    {
        
        [JsonProperty("id")]
        public string Id{get;set;}
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("includedTags")]
        public string[] IncludedTags { get; set; }

        [JsonProperty("excludedTags")]
        public string[] ExcludedTags { get; set; }

        [JsonProperty("sections")]
        public Section[] Sections { get; set; }

        [JsonProperty("objects")]
        public Dictionary<string, LayoutObjectDetails> Objects { get; set; }

        [JsonProperty("screenshot")]
        public string Screenshot { get; set; }

        [JsonProperty("errors")]
        public long Errors { get; set; }

        [JsonProperty("warnings")]
        public long Warnings { get; set; }

        [JsonProperty("validationResults")]
        public ValidationResult[] ValidationResults { get; set; }

        [JsonProperty("exceptionMessage")]
        public string ExceptionMessage { get; set; }
    }
}
