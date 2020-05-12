using System;
using System.Collections.Generic;
using CSharpGalenWrapper.Report;
using CSharpGalenWrapper.Report.Validation;
using Newtonsoft.Json;
 

 public partial class Result
    {
        [JsonProperty("ExcludedTags")]
        public object[] ExcludedTags { get; set; }

        [JsonProperty("errors")]
        public long Errors { get; set; }

        [JsonProperty("includedTags")]
        public object IncludedTags { get; set; }

        [JsonProperty("objects")]
        public Dictionary<string,LayoutObjectDetails> Objects { get; set; }

        [JsonProperty("excludedTags")]
        public object[] ResultExcludedTags { get; set; }

        [JsonProperty("report")]
        public object Report { get; set; }

        [JsonProperty("validationResults")]
        public ValidationResult[] ValidationResults { get; set; }
    }

    


