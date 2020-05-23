using System.Collections.Generic;
using CSharpGalenWrapper.Report;


public class ReportHelper
{
    public static  void GenerateReport(string reportPath,List<LayoutReport> testReport)
    {
        ReportGenerator.Generate(reportPath,testReport);
    }


   
}