using System;
using System.Collections.Generic;
using CSharpGalenWrapper.Layout;
using Newtonsoft.Json;

namespace CSharpGalenWrapper
{
    public partial class Result
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("ExcludedTags")]
        public String[] ExcludedTags { get; set; }

        [JsonProperty("errors")]
        public long Errors { get; set; }

        [JsonProperty("warnings")]
        public long Warnings { get; set; }

        [JsonProperty("includedTags")]
        public String[] IncludedTags { get; set; }

        [JsonProperty("objects")]
        public Dictionary<string, LayoutObjectDetails> Objects { get; set; }

        [JsonProperty("report")]
        public LayoutReport Report { get; set; }

        [JsonProperty("validationResults")]
        public ValidationResult[] ValidationResults { get; set; }

        [JsonProperty("exceptionMessage")]
        public string ExceptionMessage { get; set; }
    }

    public partial class GalenTestInfo
    {
        [JsonProperty("name")]
        public object Name { get; set; }

        [JsonProperty("startedAt")]
        public string StartedAt { get; set; }

        [JsonProperty("endedAt")]
        public string EndedAt { get; set; }

        [JsonProperty("failed")]
        public bool Failed { get; set; }
    }
}