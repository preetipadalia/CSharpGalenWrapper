﻿using System;
using System.Collections.Generic;
using CSharpGalenWrapper.Layout;
using OpenQA.Selenium;
using Newtonsoft.Json;

namespace CSharpGalenWrapper
{
    public class LayoutHelper
    {
        private readonly CheckLayoutApi _layoutApi;
        public LayoutHelper()
        {
            _layoutApi = new CheckLayoutApi();
        }
        /// <summary>
        /// Check layout With Existing Driver
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="specFilePath"></param>
        /// <param name="listIncluded"></param>
        /// <returns></returns>
        public LayoutReport CheckLayout(IWebDriver driver, string specFilePath, List<string> listIncluded)
        {
            var layoutRep = _layoutApi.CheckLayoutPost(driver, specFilePath, listIncluded, "", "", "");
            var rep = GetLayoutReportObject(layoutRep);
            return rep;
        }

        /// <summary>
        /// Check Layout With Existing Driver
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="specFilePath"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public LayoutReport CheckLayout(IWebDriver driver, string specFilePath, SectionFilter filter)
        {
            var layoutRep = _layoutApi.CheckLayoutPost(driver, specFilePath, filter, "", "", "");
            var rep = GetLayoutReportObject(layoutRep.ToString());
            return rep;
        }
        /// <summary>
        /// CheckLayout With Existing Driver
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="specFilePath"></param>
        /// <param name="filter"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        public LayoutReport CheckLayout(IWebDriver driver, string specFilePath, SectionFilter filter, Dictionary<string, string> properties)
        {
            var layoutRep = _layoutApi.CheckLayoutPost(driver, specFilePath, filter, properties, "", "", "");
            var rep = GetLayoutReportObject(layoutRep.ToString());
            return rep;
        }

        /// <summary>
        /// Check Layout With Existing Driver And Create Report
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="specFilePath"></param>
        /// <param name="listIncluded"></param>
        /// <param name="testTitle"></param>
        /// <param name="reportTitle"></param>
        /// <param name="reportPath"></param>
        /// <returns></returns>
        public LayoutReport CheckLayoutAndCreateReport(IWebDriver driver, string specFilePath, List<string> listIncluded, string testTitle, string reportTitle, string reportPath)
        {
            var layoutRep = _layoutApi.CheckLayoutPost(driver, specFilePath, listIncluded, testTitle, reportTitle, reportPath, true);
            var rep = GetLayoutReportObject(layoutRep);
            return rep;
        }
        /// <summary>
        /// Check Layout With Existing Driver And Create Report
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="specFilePath"></param>
        /// <param name="filter"></param>
        /// <param name="testTitle"></param>
        /// <param name="reportTitle"></param>
        /// <param name="reportPath"></param>
        /// <returns></returns>
        public LayoutReport CheckLayoutAndCreateReport(IWebDriver driver, string specFilePath, SectionFilter filter, string testTitle, string reportTitle, string reportPath)
        {
            var layoutRep = _layoutApi.CheckLayoutPost(driver, specFilePath, filter, testTitle, reportTitle, reportPath, true);
            var rep = GetLayoutReportObject(layoutRep.ToString());
            return rep;
        }
        /// <summary>
        /// Check Layout With Existing Driver And Create Report
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="specFilePath"></param>
        /// <param name="filter"></param>
        /// <param name="properties"></param>
        /// <param name="testTitle"></param>
        /// <param name="reportTitle"></param>
        /// <param name="reportPath"></param>
        /// <returns></returns>
        public LayoutReport CheckLayoutAndCreateReport(IWebDriver driver, string specFilePath, SectionFilter filter, Dictionary<string, string> properties, string testTitle, string reportTitle, string reportPath)
        {
            var layoutRep = _layoutApi.CheckLayoutPost(driver, specFilePath, filter, properties, testTitle, reportTitle, reportPath, true);
            var rep = GetLayoutReportObject(layoutRep.ToString());
            return rep;
        }

        /// <summary>
        /// Check Layout With New Driver
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="specFilePath"></param>
        /// <param name="listIncluded"></param>
        /// <returns></returns>
        public LayoutReport CheckLayout(Browser browser, string specFilePath, List<string> listIncluded)
        {
            var layoutRep = _layoutApi.CheckLayoutPost(browser, specFilePath, listIncluded, "", "", "");
            var rep = GetLayoutReportObject(layoutRep);
            return rep;
        }
        /// <summary>
        /// Check Layout With New Driver
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="specFilePath"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public LayoutReport CheckLayout(Browser browser, string specFilePath, SectionFilter filter)
        {
            var layoutRep = _layoutApi.CheckLayoutPost(browser, specFilePath, filter, "", "", "");
            var rep = GetLayoutReportObject(layoutRep.ToString());
            return rep;
        }

        /// <summary>
        /// Check Layout With New Driver
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="specFilePath"></param>
        /// <param name="filter"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        public LayoutReport CheckLayout(Browser browser, string specFilePath, SectionFilter filter, Dictionary<string, string> properties)
        {
            var layoutRep = _layoutApi.CheckLayoutPost(browser, specFilePath, filter, properties, "", "", "");
            var rep = GetLayoutReportObject(layoutRep.ToString());
            return rep;
        }

        /// <summary>
        /// Check Layout With New Driver And Create Report
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="specFilePath"></param>
        /// <param name="listIncluded"></param>
        /// <param name="testTitle"></param>
        /// <param name="reportTitle"></param>
        /// <param name="reportPath"></param>
        /// <returns></returns>
        public LayoutReport CheckLayoutAndCreateReport(Browser browser, string specFilePath, List<string> listIncluded, string testTitle, string reportTitle, string reportPath)
        {
            var layoutRep = _layoutApi.CheckLayoutPost(browser, specFilePath, listIncluded, testTitle, reportTitle, reportPath, true);
            var rep = GetLayoutReportObject(layoutRep);
            return rep;
        }

        /// <summary>
        /// Check Layout With New Driver And Create Report
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="specFilePath"></param>
        /// <param name="filter"></param>
        /// <param name="testTitle"></param>
        /// <param name="reportTitle"></param>
        /// <param name="reportPath"></param>
        /// <returns></returns>
        public LayoutReport CheckLayoutAndCreateReport(Browser browser, string specFilePath, SectionFilter filter, string testTitle, string reportTitle, string reportPath)
        {
            var layoutRep = _layoutApi.CheckLayoutPost(browser, specFilePath, filter, testTitle, reportTitle, reportPath, true);
            var rep = GetLayoutReportObject(layoutRep.ToString());
            return rep;
        }

        /// <summary>
        /// Check Layout With New Driver
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="specFilePath"></param>
        /// <param name="filter"></param>
        /// <param name="properties"></param>
        /// <param name="testTitle"></param>
        /// <param name="reportTitle"></param>
        /// <param name="reportPath"></param>
        /// <returns></returns>
        public LayoutReport CheckLayoutAndCreateReport(Browser browser, string specFilePath, SectionFilter filter, Dictionary<string, string> properties, string testTitle, string reportTitle, string reportPath)
        {
            var layoutRep = _layoutApi.CheckLayoutPost(browser, specFilePath, filter, properties, testTitle, reportTitle, reportPath, true);
            var rep = GetLayoutReportObject(layoutRep.ToString());
            return rep;
        }


        private LayoutReport GetLayoutReportObject(string layoutRep)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<Result>(layoutRep);
                if (result.ExceptionMessage != "no Exception")
                {
                    throw new Exception(result.ExceptionMessage);
                }
                var report = result.Report;
                report.Id = result.Id;
                report.Errors = result.Errors;
                report.ExceptionMessage = result.ExceptionMessage;
                report.Warnings = result.Warnings;
                report.ValidationResults = result.ValidationResults;
                return report;
            }
            catch
            {
                throw new Exception(layoutRep);
            }

        }
        public int StartGalenServer(string serverPath = "")
        {
            return ServerHelper.StartGalenServer(serverPath);
        }
        public void StopGalenServer()
        {
            ServerHelper.StopGalenServer();
        }

    }
}
