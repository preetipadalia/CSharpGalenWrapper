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
    public class Server
    {
        public static int StartGalenServer()
        {
            return ServerHelper.StartGalenServer();
        }
        public static void StopGalenServer()
        {
            ServerHelper.StopGalenServer();
        }
    }
}