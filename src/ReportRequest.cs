using System.Collections.Generic;
using CSharpGalenWrapper.Report;

public class ReportRequest
{
    string reportTitle;
    List<LayoutReport> layoutReport;

    public string ReportPath { get => reportTitle; set => reportTitle = value; }
    public List<LayoutReport> LayoutReport { get => layoutReport; set => layoutReport = value; }
}