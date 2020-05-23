using System;
using System.Collections.Generic;
using CSharpGalenWrapper.Report;

public class ReportRequest
{
    private List<LayoutMap> layoutReport;
    private String reportPath;
    private String testTitle;
    private String layoutTitle;

    public List<LayoutMap> LayoutReport { get => layoutReport; set => layoutReport = value; }
    public string ReportPath { get => reportPath; set => reportPath = value; }
    public string TestTitle { get => testTitle; set => testTitle = value; }
    public string LayoutTitle { get => layoutTitle; set => layoutTitle = value; }
}

public class LayoutMap
{
    string title;
    string id;

    public string Title { get => title; set => title = value; }
    public string Id { get => id; set => id = value; }
}
