using System.Collections.Generic;
using CSharpGalenWrapper.Report;


internal class ReportHelper
{
    internal void GenerateReport(string reportTitle,List<LayoutReport> testReport)
    {
        ReportGenerator.Generate(reportTitle,testReport);
    }


   
}