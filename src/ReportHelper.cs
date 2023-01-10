using System.Collections.Generic;
using CSharpGalenWrapper.Layout;

namespace CSharpGalenWrapper
{
    public class ReportHelper
    {
        public static  void GenerateReport(string reportPath,List<LayoutReport> testReport)
        {
            ReportGenerator.Generate(reportPath,testReport);
        }


   
    }
}