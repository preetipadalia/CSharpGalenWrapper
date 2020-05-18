using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using CSharpGalenWrapper.Driver;
using CSharpGalenWrapper.Layout;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using RestSharp;

namespace CSharpGalenWrapper.API
{
    internal class ServerHelper
    {
        static Process process;
        internal static int port;
        internal static int StartGalenServer()
        {
            port = GetAvailablePort(9000);
            process = new Process();
            process.StartInfo.FileName = "Java";
            process.StartInfo.Arguments = "-jar -Dserver.port=" + port + " GalenWrapperAPI-0.0.1.jar";
            DateTime previousTime = DateTime.Now;
            process.Start();
            bool serverUp = false;
            int timeouts = 120;
            DateTime newTime = DateTime.Now;

            while (!serverUp && (newTime - previousTime).Seconds <= 180)
            {
                serverUp = IsServerUp(serverUp);
                newTime = DateTime.Now;
            }
            if (!IsServerUp(serverUp))
                throw new Exception("Unable to start the server.");
                return process.Id;

        }
        internal static int GetAvailablePort(int startingPort)
        {
            var properties = IPGlobalProperties.GetIPGlobalProperties();

            //getting active connections
            var tcpConnectionPorts = properties.GetActiveTcpConnections()
                                .Where(n => n.LocalEndPoint.Port >= startingPort)
                                .Select(n => n.LocalEndPoint.Port);

            //getting active tcp listners - WCF service listening in tcp
            var tcpListenerPorts = properties.GetActiveTcpListeners()
                                .Where(n => n.Port >= startingPort)
                                .Select(n => n.Port);

            //getting active udp listeners
            var udpListenerPorts = properties.GetActiveUdpListeners()
                                .Where(n => n.Port >= startingPort)
                                .Select(n => n.Port);

            var port = Enumerable.Range(startingPort, ushort.MaxValue)
                .Where(i => !tcpConnectionPorts.Contains(i))
                .Where(i => !tcpListenerPorts.Contains(i))
                .Where(i => !udpListenerPorts.Contains(i))
                .FirstOrDefault();

            return port;
        }

        private static bool IsServerUp(bool serverUp)
        {
            serverUp = false;
            var client = new RestClient("http://localhost:" + port + "/checkHealth");
            var request = new RestRequest(Method.GET);
            request.Parameters.Clear();
            //request.AddParameter("application/json", req, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.Content.Equals("I am up"))
                serverUp = true;
            return serverUp;
        }

        internal static void StopGalenServer()
        {

            process.Kill();

            //return response;

        }
    }
}