using System.Collections.Generic;
using System.IO;
using CSharpGalenWrapper.Layout;
using Newtonsoft.Json;
using RestSharp;

namespace CSharpGalenWrapper
{
    internal class ReportGenerator
    {
        internal static string Generate(string reportPath, List<LayoutReport> testReport)
        {
            var request = new ReportRequest();
            var maps = new List<LayoutMap>();
            foreach (var rep in testReport)
            {
                var map = new LayoutMap
                {
                    Id = rep.Id,
                    Title = rep.Title
                };
                if(map.Title==null)
                    map.Title="";
                maps.Add(map);
            }
            request.ReportPath =Path.GetFullPath( Path.Combine(Directory.GetCurrentDirectory(), reportPath)); request.LayoutReport = maps;
            return ExecuteRequest(request);
        }

        private static string ExecuteRequest(ReportRequest request)
        {
            var req = GetRequestString(request);
            var response = ExecuteRequestGenerateReport(req);
            if (response.ErrorException != null && response.ErrorException.Message.Trim() != "")
                return response.ErrorException.Message;
            else
            if (response.ErrorMessage != null && response.ErrorMessage.Trim() != "")
                return response.ErrorMessage;
            return response.Content;
        }

        private static RestResponse ExecuteRequestGenerateReport(string req)
        {
            var client = new RestClient("http://localhost:" + ServerHelper.Port + "/generateReport");
            var request = new RestRequest();
            request.AddParameter("application/json", req, ParameterType.RequestBody);
            var response = client.Post(request);
            return response;
        }

        private static string GetRequestString(ReportRequest request1)
        {
            return JsonConvert.SerializeObject(request1);
        }
    }
}