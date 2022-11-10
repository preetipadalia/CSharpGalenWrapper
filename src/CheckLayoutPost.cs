using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using OpenQA.Selenium;
using RestSharp;

namespace CSharpGalenWrapper
{
    internal class CheckLayoutApi
    {
        internal string CheckLayoutPost(IWebDriver driver, string specPath, List<string> includedTags, string testTitle, string reportTitle, string reportPath, bool isReportEnabled = false)
        {
            var request1 = new Request();
            if (driver is WebDriver webDriver)
            {
                request1.Url = WebDriverHelper.GetExecutorUrlFromDriver(webDriver).AbsoluteUri;
                request1.SessionId = webDriver.SessionId.ToString();
            }
            else
            {
                throw new ArgumentException($"{driver.GetType().Name} is not compatible for using as {nameof(WebDriver)}");
            }

            request1 = GetSpecFilePath(specPath, request1);
            request1.IncludedTags = includedTags;
            request1.ReportEnabled = isReportEnabled;
            request1 = SetupReportSettings(testTitle, reportTitle, reportPath, request1);
            return ExecuteRequest(request1);

        }

        internal string CheckLayoutPost(Browser browser, string specPath, List<string> includedTags, string testTitle, string reportTitle, string reportPath, bool isReportEnabled = false)
        {
            var request1 = new Request();
            request1 = SetupBrowserProperties(browser, request1);
            request1 = GetSpecFilePath(specPath, request1);
            request1.IncludedTags = includedTags;
            request1.ReportEnabled = isReportEnabled;
            request1 = SetupReportSettings(testTitle, reportTitle, reportPath, request1);
            return ExecuteRequest(request1);

        }

        private string ResolveRelativePath(string reportPath)
        {
            var path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), reportPath));
            return path;
        }

        internal string CheckLayoutPost(IWebDriver driver, string specFilePath, SectionFilter sectionFilter, string testTitle, string reportTitle, string reportPath, bool isReportEnabled = false)
        {
            var request1 = new Request();
            if (driver is WebDriver webDriver)
            {
                request1.Url = WebDriverHelper.GetExecutorUrlFromDriver(webDriver).AbsoluteUri;
                request1.SessionId = webDriver.SessionId.ToString();
            }
            else
            {
                throw new ArgumentException($"{driver.GetType().Name} is not compatible for using as {nameof(WebDriver)}");
            }
            request1 = GetSpecFilePath(specFilePath, request1);
            request1.SectionFilter = sectionFilter;
            request1.ReportEnabled = isReportEnabled;
            request1 = SetupReportSettings(testTitle, reportTitle, reportPath, request1);
            return ExecuteRequest(request1);
        }

        internal string CheckLayoutPost(Browser browser, string specFilePath, SectionFilter sectionFilter, string testTitle, string reportTitle, string reportPath, bool isReportEnabled = false)
        {

            var request1 = new Request();
            request1 = SetupBrowserProperties(browser, request1);
            request1 = GetSpecFilePath(specFilePath, request1);
            request1.SectionFilter = sectionFilter;
            request1.ReportEnabled = isReportEnabled;
            request1 = SetupReportSettings(testTitle, reportTitle, reportPath, request1);
            return ExecuteRequest(request1);
        }

        private Request GetSpecFilePath(string specFilePath, Request request1)
        {
            request1.SpecPath = ResolveRelativePath(specFilePath);
            if (!File.Exists(request1.SpecPath))
                throw new Exception("Spec File doesnot exists in :" + request1.SpecPath);
            return request1;
        }

        private Request SetupReportSettings(string testTitle, string reportTitle, string reportPath, Request request1)
        {
            request1.ReportPath = ResolveRelativePath(reportPath);
            request1.TestTitle = testTitle;
            request1.ReportTitle = reportTitle;
            return request1;
        }

        internal string CheckLayoutPost(IWebDriver driver, string specFilePath, SectionFilter sectionFilter, Dictionary<string, string> properties, string testTitle, string reportTitle, string reportPath, bool isReportEnabled = false)
        {
            var request1 = new Request();
            if (driver is WebDriver webDriver)
            {
                request1.Url = WebDriverHelper.GetExecutorUrlFromDriver(webDriver).AbsoluteUri;
                request1.SessionId = webDriver.SessionId.ToString();
            }
            else
            {
                throw new ArgumentException($"{driver.GetType().Name} is not compatible for using as {nameof(WebDriver)}");
            }
            request1 = GetSpecFilePath(specFilePath, request1);
            request1.SectionFilter = sectionFilter;
            request1.Properties = properties;
            request1.ReportEnabled = isReportEnabled;
            request1 = SetupReportSettings(testTitle, reportTitle, reportPath, request1);
            return ExecuteRequest(request1);
        }

        private static IRestResponse ExecuteRequestCheckLayout(string req)
        {
            var client = new RestClient("http://localhost:" + ServerHelper.Port + "/checkLayout");
            var request = new RestRequest(Method.POST);
            request.Parameters.Clear();
            request.AddParameter("application/json", req, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }

        internal string CheckLayoutPost(Browser browser, string specFilePath, SectionFilter sectionFilter, Dictionary<string, string> properties, string testTitle, string reportTitle, string reportPath, bool isReportEnabled = false)
        {
            // RemoteWebDriver driver1=(RemoteWebDriver)driver;
            var request1 = new Request();
            request1 = SetupBrowserProperties(browser, request1);
            request1 = GetSpecFilePath(specFilePath, request1);
            request1.SectionFilter = sectionFilter;
            request1.Properties = properties;
            request1.ReportEnabled = isReportEnabled;
            request1 = SetupReportSettings(testTitle, reportTitle, reportPath, request1);
            return ExecuteRequest(request1);
        }

        private string ExecuteRequest(Request request1)
        {
            var req = GetRequestString(request1);
            var response = ExecuteRequestCheckLayout(req);
            return response.Content;
        }

        private Request SetupBrowserProperties(Browser browser, Request request1)
        {
            request1.Url = browser.Url;
            request1.BrowserType = browser.BrowserType;
            request1.DriverPath = ResolveRelativePath(browser.DriverPath);
            request1.BrowserHeight = browser.BrowserHeight;
            request1.BrowserWidth = browser.BrowserWidth;
            return request1;
        }

        private string GetRequestString(Request request1)
        {
            return JsonConvert.SerializeObject(request1);
        }
    }
}