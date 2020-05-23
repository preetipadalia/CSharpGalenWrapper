using System.Collections.Generic;
using System.IO;
using CSharpGalenWrapper.API;
using CSharpGalenWrapper.Report;
using Newtonsoft.Json;
using RestSharp;
internal class ReportGenerator
{
    internal static string Generate(string reportPath, List<LayoutReport> testReport)
    {
        ReportRequest request = new ReportRequest();
        List<LayoutMap> maps = new List<LayoutMap>();
        foreach (LayoutReport rep in testReport)
        {
            LayoutMap map = new LayoutMap();
            map.Id = rep.Id;
            map.Title = rep.Title;
            if(map.Title==null)
            map.Title="";
            maps.Add(map);
        }
        request.ReportPath =Path.GetFullPath( Path.Combine(Directory.GetCurrentDirectory(), reportPath)); request.LayoutReport = maps;
        return ExecuteRequest(request);
    }

    private static string ExecuteRequest(ReportRequest request)
    {
        string req = GetRequestString(request);
        IRestResponse response = ExecuteRequestGenerateReport(req);
        if (response.ErrorException != null && response.ErrorException.Message.Trim() != "")
            return response.ErrorException.Message;
        else
        if (response.ErrorMessage != null && response.ErrorMessage.Trim() != "")
            return response.ErrorMessage;
        return response.Content;
    }

    private static IRestResponse ExecuteRequestGenerateReport(string req)
    {
        var client = new RestClient("http://localhost:" + ServerHelper.port + "/generateReport");
        var request = new RestRequest(Method.POST);
        request.Parameters.Clear();
        request.AddParameter("application/json", req, ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);
        return response;
    }

    private static string GetRequestString(ReportRequest request1)
    {
        return JsonConvert.SerializeObject(request1);
    }
}