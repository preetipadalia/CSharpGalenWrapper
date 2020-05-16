namespace CSharpGalenWrapper.API
{
    public class Browser
    {
        string browserType;
        string driverPath;
        int browserHeight;
        int browserWidth;
        string url;
 

        public string BrowserType { get => browserType; set => browserType = value; }
        public string DriverPath { get => driverPath; set => driverPath = value; }
        public int BrowserHeight { get => browserHeight; set => browserHeight = value; }
        public int BrowserWidth { get => browserWidth; set => browserWidth = value; }
        public string Url { get => url; set => url = value; }
    }
}