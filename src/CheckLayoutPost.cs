using System.Collections.Generic;
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
        internal  string CheckLayoutPost(IWebDriver driver1,string specPath,string reportPath,List<string> includedTags)
        {
            RemoteWebDriver driver=(RemoteWebDriver)driver1;
            string req = GetRequestString(driver,specPath,reportPath,includedTags);
            var client = new RestClient("http://localhost:8080/checkLayout");
            var request = new RestRequest(Method.POST);
            request.Parameters.Clear();
            request.AddParameter("application/json", req, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;

        }

        private string GetRequestString(RemoteWebDriver driver1,string specPath,string reportPath,List<string> includedTags)
        {
            Request request1 = new Request();
            request1.Url = RemoteWebDriverHelper.GetExecutorURLFromDriver(driver1).AbsoluteUri;
            request1.SessionId = driver1.SessionId.ToString();
            request1.SpecPath = specPath;
            request1.IncludedTags = includedTags;
            request1.ReportPath = reportPath;
            return JsonConvert.SerializeObject(request1);
        }
    }
}