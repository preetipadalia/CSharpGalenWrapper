using System;

namespace CSharpGalenWrapper.Driver
{
    internal class RemoteWebDriverHelper
    {
        public static Uri GetExecutorURLFromDriver(OpenQA.Selenium.Remote.RemoteWebDriver driver)
        {
            var executorField = typeof(OpenQA.Selenium.Remote.RemoteWebDriver)
                .GetField("executor",
                          System.Reflection.BindingFlags.NonPublic
                          | System.Reflection.BindingFlags.Instance);

            object executor = executorField.GetValue(driver);

            var internalExecutorField = executor.GetType()
                .GetField("internalExecutor",
                          System.Reflection.BindingFlags.NonPublic
                          | System.Reflection.BindingFlags.Instance);
            object internalExecutor = internalExecutorField.GetValue(executor);

            //executor.CommandInfoRepository
            var remoteServerUriField = internalExecutor.GetType()
                .GetField("remoteServerUri",
                          System.Reflection.BindingFlags.NonPublic
                          | System.Reflection.BindingFlags.Instance);
            var remoteServerUri = remoteServerUriField.GetValue(internalExecutor) as Uri;

            return remoteServerUri;
        }
    }
}