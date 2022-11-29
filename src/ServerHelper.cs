using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using RestSharp;

namespace CSharpGalenWrapper
{
    internal class ServerHelper
    {
        static Process _process;
        internal static int Port;
        internal static int StartGalenServer(string serverPath = "")
        {
            ValidateIfGalenServerFileExists(serverPath); 
            if (serverPath.Trim() == "")
                serverPath = Environment.CurrentDirectory;
            Port = GetAvailablePort(9000);
            _process = new Process();
            _process.StartInfo.FileName = "Java";
            _process.StartInfo.WorkingDirectory = serverPath;
            _process.StartInfo.Arguments = "-jar -Dserver.port=" + Port + " GalenWrapperAPI-0.0.1.jar";
            var isStarted = _process.Start();
            if (isStarted)
            {

                var serverUp = false;

                while (!serverUp)
                {
                    ValidateIfServerProcessIsRunning(); 
                    serverUp = IsServerUp(serverUp);
                }
                if (!IsServerUp(serverUp))
                    throw new Exception("Unable to start the server.");
                return _process.Id;
            }
            else
                throw new Exception("Unable to start the server");

        }

        private static void ValidateIfServerProcessIsRunning()
        {
            if (_process.HasExited)
                throw new Exception("Galen server is not running or unable to start.");
        }

        private static void ValidateIfGalenServerFileExists(string serverPath)
        {
            if (!File.Exists(Path.GetFullPath( Path.Combine(serverPath, "GalenWrapperAPI-0.0.1.jar"))))
                throw new Exception("Galen Server jar :GalenWrapperAPI-0.0.1.jar not found at path :"+Path.GetFullPath( Path.Combine(serverPath, "GalenWrapperAPI-0.0.1.jar")));
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
                .Skip((new Random()).Next(100,1000)) // an attempt to solve `The Port is in use` issue
                .FirstOrDefault();

            return port;
        }

        private static bool IsServerUp(bool serverUp)
        {
            serverUp = false;
            var client = new RestClient("http://localhost:" + Port + "/checkHealth");
            var request = new RestRequest();
            //request.AddParameter("application/json", req, ParameterType.RequestBody);
            var response = client.Get(request);
            if (response.Content.Equals("I am up"))
                serverUp = true;
            return serverUp;
        }

        internal static void StopGalenServer()
        {
            _process.Kill();
            //return response;
        }
    }
}