using System.Collections.Generic;

namespace CSharpGalenWrapper
{
    public class Request
    {
        public string SessionId { get; set; }

        public string Url { get; set; }

        public string SpecPath { get; set; }

        public List<string> IncludedTags { get; set; }

        public string ReportPath { get; set; }

        public SectionFilter SectionFilter { get; set; }

        public string ReportTitle { get; set; }

        public string TestTitle { get; set; }

        public Dictionary<string, string> Properties { get; set; }

        public string BrowserType { get; set; }

        public string DriverPath { get; set; }

        public int BrowserHeight { get; set; }

        public int BrowserWidth { get; set; }

        public bool ReportEnabled { get; set; }
    }

    public class SectionFilter
    {
        public List<string> IncludedTags { get; set; }

        public List<string> ExcludedTags { get; set; }

        public string SectionName { get; set; }

        public SectionFilter()
        {
        }
      
    }

}
