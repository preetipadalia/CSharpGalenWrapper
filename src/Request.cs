using System;
using System.Collections.Generic;

namespace CSharpGalenWrapper.Layout
{
    public class Request
    {
        private String sessionId;
        private String url;
        private String specPath;
        private List<String> includedTags;
        private string reportPath;
        private String testTitle;
        private Dictionary<String, String> properties;
        private String browserType;
        private String driverPath;
        private String reportTitle;
        private SectionFilter sectionFilter;
        private int browserHeight;
        private int browserWidth;

        public string SessionId { get => sessionId; set => sessionId = value; }
        public string Url { get => url; set => url = value; }
        public string SpecPath { get => specPath; set => specPath = value; }
        public List<string> IncludedTags { get => includedTags; set => includedTags = value; }
        public string ReportPath { get => reportPath; set => reportPath = value; }
        public SectionFilter SectionFilter { get => sectionFilter; set => sectionFilter = value; }
        public string ReportTitle { get => reportTitle; set => reportTitle = value; }
        public string TestTitle { get => testTitle; set => testTitle = value; }
        public Dictionary<string, string> Properties { get => properties; set => properties = value; }
        public string BrowserType { get => browserType; set => browserType = value; }
        public string DriverPath { get => driverPath; set => driverPath = value; }
        public int BrowserHeight { get => browserHeight; set => browserHeight = value; }
        public int BrowserWidth { get => browserWidth; set => browserWidth = value; }

    }

    public class SectionFilter
    {

        private List<String> includedTags;
        private List<String> excludedTags;
        private String sectionName;
    

        public List<string> IncludedTags { get => includedTags; set => includedTags = value; }
        public List<string> ExcludedTags { get => excludedTags; set => excludedTags = value; }
        public string SectionName { get => sectionName; set => sectionName = value; }
        
        public SectionFilter()
        {
        }
      
    }

}
