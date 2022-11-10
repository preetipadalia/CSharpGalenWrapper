using System.Collections.Generic;

namespace CSharpGalenWrapper
{
    public class ReportRequest
    {
        public List<LayoutMap> LayoutReport { get; set; }

        public string ReportPath { get; set; }

        public string TestTitle { get; set; }

        public string LayoutTitle { get; set; }
    }

    public class LayoutMap
    {
        public string Title { get; set; }

        public string Id { get; set; }
    }
}