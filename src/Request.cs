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
  private String reportTitle;
        private SectionFilter sectionFilter;

        public string SessionId { get => sessionId; set => sessionId = value; }
        public string Url { get => url; set => url = value; }
        public string SpecPath { get => specPath; set => specPath = value; }
        public List<string> IncludedTags { get => includedTags; set => includedTags = value; }
        public string ReportPath { get => reportPath; set => reportPath = value; }
        public SectionFilter SectionFilter { get => sectionFilter; set => sectionFilter = value; }
        public string ReportTitle { get => reportTitle; set => reportTitle = value; }
        public string TestTitle { get => testTitle; set => testTitle = value; }
    }

    public class SectionFilter {
    
    private List<String> includedTags;
    private List<String> excludedTags;
    private String sectionName;

    public SectionFilter(List<String> includedTags, List<String> excludedTags) {
        this.setIncludedTags(includedTags);
        this.setExcludedTags(excludedTags);
    }

    public SectionFilter() {
    }

    public List<String> getIncludedTags() {
        return includedTags;
    }
    public void setIncludedTags(List<String> includedTags) {
        this.includedTags = includedTags;
    }
    public List<String> getExcludedTags() {
        return excludedTags;
    }
    public void setExcludedTags(List<String> excludedTags) {
        this.excludedTags = excludedTags;
    }

    public SectionFilter withSectionName(String sectionName) {
        this.sectionName = sectionName;
        return this;
    }

    public String getSectionName() {
        return sectionName;
    }

    public void setSectionName(String sectionName) {
        this.sectionName = sectionName;
    }
}

}
