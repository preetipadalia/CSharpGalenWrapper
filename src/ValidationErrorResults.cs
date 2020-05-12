   using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

namespace  CSharpGalenWrapper.Report.Validation
{
public partial class ValidationResult
    {
        [JsonProperty("spec")]
        public Spec Spec { get; set; }

        [JsonProperty("validationObjects")]
        public ValidationObject[] ValidationObjects { get; set; }

        [JsonProperty("error")]
        public Error Error { get; set; }

        [JsonProperty("childValidationResults")]
        public object ChildValidationResults { get; set; }

        [JsonProperty("meta")]
        public Meta[] Meta { get; set; }
    }

    public partial class Error
    {
        [JsonProperty("messages")]
        public string[] Messages { get; set; }

        [JsonProperty("imageComparison")]
        public object ImageComparison { get; set; }

        [JsonProperty("onlyWarn")]
        public bool OnlyWarn { get; set; }
    }

    public partial class Meta
    {
        [JsonProperty("from")]
        public ToClass From { get; set; }

        [JsonProperty("to")]
        public ToClass To { get; set; }

        [JsonProperty("expectedDistance")]
        public string ExpectedDistance { get; set; }

        [JsonProperty("realDistance")]
        public string RealDistance { get; set; }
    }

    public partial class ToClass
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("edge")]
        public string Edge { get; set; }
    }

    public partial class Spec
    {
        [JsonProperty("originalText")]
        public string OriginalText { get; set; }

        [JsonProperty("properties")]
        public JsVariables Properties { get; set; }

        [JsonProperty("place")]
        public Place Place { get; set; }

        [JsonProperty("onlyWarn")]
        public bool OnlyWarn { get; set; }

        [JsonProperty("alias")]
        public object Alias { get; set; }

        [JsonProperty("jsVariables")]
        public JsVariables JsVariables { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("range")]
        public Range Range { get; set; }
    }

    public partial class JsVariables
    {
    }

    public partial class Place
    {
        [JsonProperty("filePath")]
        public string FilePath { get; set; }

        [JsonProperty("lineNumber")]
        public long LineNumber { get; set; }
    }

    public partial class Range
    {
        [JsonProperty("from")]
        public RangeFrom From { get; set; }

        [JsonProperty("to")]
        public object To { get; set; }

        [JsonProperty("percentageOfValue")]
        public object PercentageOfValue { get; set; }

        [JsonProperty("rangeType")]
        public string RangeType { get; set; }

        [JsonProperty("percentage")]
        public bool Percentage { get; set; }

        [JsonProperty("errorMessageSuffix")]
        public string ErrorMessageSuffix { get; set; }
    }

    public partial class RangeFrom
    {
        [JsonProperty("precision")]
        public long Precision { get; set; }
    }

    public partial class ValidationObject
    {
        [JsonProperty("area")]
        public Area Area { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Area
    {
        [JsonProperty("left")]
        public long Left { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("top")]
        public long Top { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("points")]
        public Point[] Points { get; set; }
    }

    public partial class Point
    {
        [JsonProperty("left")]
        public long Left { get; set; }

        [JsonProperty("top")]
        public long Top { get; set; }
    }
}