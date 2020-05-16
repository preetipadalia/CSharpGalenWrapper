using System;
using System.Collections.Generic;
using System.IO;
using CSharpGalenWrapper.Driver;
using CSharpGalenWrapper.Layout;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using RestSharp;

namespace CSharpGalenWrapper.API
{
    internal class CheckLayoutAPI
    {
        internal string CheckLayoutPost(IWebDriver driver1, string specPath, List<string> includedTags, string testTitle, string reportTitle, string reportPath)
        {
            RemoteWebDriver driver = (RemoteWebDriver)driver1;
            Request request1 = new Request();

            request1.Url = RemoteWebDriverHelper.GetExecutorURLFromDriver(driver).AbsoluteUri;
            request1.SessionId = driver.SessionId.ToString();
            request1.SpecPath = ResolveRelativePath(specPath);
            request1.IncludedTags = includedTags;
            request1 = setupReportSettings(testTitle, reportTitle, reportPath, request1);
            return ExecuteRequest(request1);

        }

        internal string CheckLayoutPost(Browser browser, string specPath, List<string> includedTags, string testTitle, string reportTitle, string reportPath)
        {
            Request request1 = new Request();
            request1 = setupBrowserProperties(browser, request1);
            request1.SpecPath = ResolveRelativePath(specPath);
            request1.IncludedTags = includedTags;
            request1 = setupReportSettings(testTitle, reportTitle, reportPath, request1);
            return ExecuteRequest(request1);

        }

        private string ResolveRelativePath(string reportPath)
        {
            return Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), reportPath));
        }

        internal String CheckLayoutPost(IWebDriver driver, string specFilePath, SectionFilter sectionFilter, string testTitle, string reportTitle, string reportPath)
        {
            RemoteWebDriver driver1 = (RemoteWebDriver)driver;
            Request request1 = new Request();
            request1.Url = RemoteWebDriverHelper.GetExecutorURLFromDriver(driver1).AbsoluteUri;
            request1.SessionId = driver1.SessionId.ToString();
            request1.SpecPath = ResolveRelativePath(specFilePath);
            request1.SectionFilter = sectionFilter;
            request1 = setupReportSettings(testTitle, reportTitle, reportPath, request1);
            return ExecuteRequest(request1);
        }

        internal String CheckLayoutPost(Browser browser, string specFilePath, SectionFilter sectionFilter, string testTitle, string reportTitle, string reportPath)
        {

            Request request1 = new Request();
            request1 = setupBrowserProperties(browser, request1);
            request1.SpecPath = ResolveRelativePath(specFilePath);
            request1.SectionFilter = sectionFilter;
            request1 = setupReportSettings(testTitle, reportTitle, reportPath, request1);
            return ExecuteRequest(request1);
        }

        private Request setupReportSettings(string testTitle, string reportTitle, string reportPath, Request request1)
        {
            request1.ReportPath = ResolveRelativePath(reportPath);
            request1.TestTitle = testTitle;
            request1.ReportTitle = reportTitle;
            return request1;
        }

        internal String CheckLayoutPost(IWebDriver driver, string specFilePath, SectionFilter sectionFilter, Dictionary<string, string> properties, string testTitle, string reportTitle, string reportPath)
        {
            RemoteWebDriver driver1 = (RemoteWebDriver)driver;
            Request request1 = new Request();
            request1.Url = RemoteWebDriverHelper.GetExecutorURLFromDriver(driver1).AbsoluteUri;
            request1.SessionId = driver1.SessionId.ToString();
            request1.SpecPath = ResolveRelativePath(specFilePath);
            request1.SectionFilter = sectionFilter;
            request1.Properties = properties;
            request1 = setupReportSettings(testTitle, reportTitle, reportPath, request1);
            return ExecuteRequest(request1);
        }

        private static IRestResponse ExecuteRequestCheckLayout(string req)
        {
            var client = new RestClient("http://localhost:8080/checkLayout");
            var request = new RestRequest(Method.POST);
            request.Parameters.Clear();
            request.AddParameter("application/json", req, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response;
        }

        internal String CheckLayoutPost(Browser browser, string specFilePath, SectionFilter sectionFilter, Dictionary<string, string> properties, string testTitle, string reportTitle, string reportPath)
        {
            // RemoteWebDriver driver1=(RemoteWebDriver)driver;
            Request request1 = new Request();
            request1 = setupBrowserProperties(browser, request1);
            request1.SpecPath = ResolveRelativePath(specFilePath);
            request1.SectionFilter = sectionFilter;
            request1.Properties = properties;
            request1 = setupReportSettings(testTitle, reportTitle, reportPath, request1);
            return ExecuteRequest(request1);
        }

        private string ExecuteRequest(Request request1)
        {
            string req = GetRequestString(request1);
            IRestResponse response = ExecuteRequestCheckLayout(req);
            return response.Content;
        }

        private static Request setupBrowserProperties(Browser browser, Request request1)
        {
            request1.Url = browser.Url;
            request1.BrowserType = browser.BrowserType;
            request1.DriverPath = browser.DriverPath;
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