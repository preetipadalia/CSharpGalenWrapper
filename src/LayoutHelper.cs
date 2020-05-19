using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using CSharpGalenWrapper.API;
using Newtonsoft.Json;
using CSharpGalenWrapper.Layout;
using CSharpGalenWrapper.Report;

namespace CSharpGalenWrapper
{
    public class LayoutHelper
    {
        CheckLayoutAPI layoutAPI;
        public LayoutHelper()
        {
            layoutAPI = new CheckLayoutAPI();
        }
        public LayoutReport CheckLayout(IWebDriver driver, string specFilePath, List<string> listIncluded)
        {
            var layoutRep = layoutAPI.CheckLayoutPost(driver, specFilePath, listIncluded, "", "", "");
            LayoutReport rep = GetLayoutReportObject(layoutRep);
            return rep;
        }
        public LayoutReport CheckLayout(IWebDriver driver, string specFilePath, SectionFilter filter)
        {
            var layoutRep = layoutAPI.CheckLayoutPost(driver, specFilePath, filter, "", "", "");
            LayoutReport rep = GetLayoutReportObject(layoutRep.ToString());
            return rep;
        }
        public LayoutReport CheckLayout(IWebDriver driver, string specFilePath, SectionFilter filter, Dictionary<string, string> properties)
        {
            var layoutRep = layoutAPI.CheckLayoutPost(driver, specFilePath, filter, properties, "", "", "");
            LayoutReport rep = GetLayoutReportObject(layoutRep.ToString());
            return rep;
        }


        public LayoutReport CheckLayoutAndCreateReport(IWebDriver driver, string specFilePath, List<string> listIncluded, string testTitle, string reportTitle, string reportPath)
        {
            var layoutRep = layoutAPI.CheckLayoutPost(driver, specFilePath, listIncluded, testTitle, reportTitle, reportPath);
            LayoutReport rep = GetLayoutReportObject(layoutRep);
            return rep;
        }
        public LayoutReport CheckLayoutAndCreateReport(IWebDriver driver, string specFilePath, SectionFilter filter, string testTitle, string reportTitle, string reportPath)
        {
            var layoutRep = layoutAPI.CheckLayoutPost(driver, specFilePath, filter, testTitle, reportTitle, reportPath);
            LayoutReport rep = GetLayoutReportObject(layoutRep.ToString());
            return rep;
        }
        public LayoutReport CheckLayoutAndCreateReport(IWebDriver driver, string specFilePath, SectionFilter filter, Dictionary<string, string> properties, string testTitle, string reportTitle, string reportPath)
        {
            var layoutRep = layoutAPI.CheckLayoutPost(driver, specFilePath, filter, properties, testTitle, reportTitle, reportPath);
            LayoutReport rep = GetLayoutReportObject(layoutRep.ToString());
            return rep;
        }
        public LayoutReport CheckLayout(Browser browser, string specFilePath, List<string> listIncluded)
        {
            var layoutRep = layoutAPI.CheckLayoutPost(browser, specFilePath, listIncluded, "", "", "");
            LayoutReport rep = GetLayoutReportObject(layoutRep);
            return rep;
        }
        public LayoutReport CheckLayout(Browser browser, string specFilePath, SectionFilter filter)
        {
            var layoutRep = layoutAPI.CheckLayoutPost(browser, specFilePath, filter, "", "", "");
            LayoutReport rep = GetLayoutReportObject(layoutRep.ToString());
            return rep;
        }
        public LayoutReport CheckLayout(Browser browser, string specFilePath, SectionFilter filter, Dictionary<string, string> properties)
        {
            var layoutRep = layoutAPI.CheckLayoutPost(browser, specFilePath, filter, properties, "", "", "");
            LayoutReport rep = GetLayoutReportObject(layoutRep.ToString());
            return rep;
        }


        public LayoutReport CheckLayoutAndCreateReport(Browser browser, string specFilePath, List<string> listIncluded, string testTitle, string reportTitle, string reportPath)
        {
            var layoutRep = layoutAPI.CheckLayoutPost(browser, specFilePath, listIncluded, testTitle, reportTitle, reportPath);
            LayoutReport rep = GetLayoutReportObject(layoutRep);
            return rep;
        }
        public LayoutReport CheckLayoutAndCreateReport(Browser browser, string specFilePath, SectionFilter filter, string testTitle, string reportTitle, string reportPath)
        {
            var layoutRep = layoutAPI.CheckLayoutPost(browser, specFilePath, filter, testTitle, reportTitle, reportPath);
            LayoutReport rep = GetLayoutReportObject(layoutRep.ToString());
            return rep;
        }
        public LayoutReport CheckLayoutAndCreateReport(Browser browser, string specFilePath, SectionFilter filter, Dictionary<string, string> properties, string testTitle, string reportTitle, string reportPath)
        {
            var layoutRep = layoutAPI.CheckLayoutPost(browser, specFilePath, filter, properties, testTitle, reportTitle, reportPath);
            LayoutReport rep = GetLayoutReportObject(layoutRep.ToString());
            return rep;
        }


        private LayoutReport GetLayoutReportObject(string layoutRep)
        {
            Result result = JsonConvert.DeserializeObject<Result>(layoutRep);
            if (result.ExceptionMessage != "no Exception")
            {
                throw new Exception(result.ExceptionMessage);
            }
            LayoutReport report = result.Report;
            report.Errors = result.Errors;
            report.ExceptionMessage = result.ExceptionMessage;
            report.Warnings = result.Warnings;
            report.ValidationResults = result.ValidationResults;
            return report;
        }
        public int StartGalenServer()
        {
            return ServerHelper.StartGalenServer();
        }
        public void StopGalenServer()
        {
            ServerHelper.StopGalenServer();
        }

    }
}
