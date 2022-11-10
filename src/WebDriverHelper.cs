using System;
using OpenQA.Selenium;

namespace CSharpGalenWrapper
{
    internal class WebDriverHelper
    {
        public static Uri GetExecutorUrlFromDriver(WebDriver driver)
        {
            var executorField = typeof(WebDriver)
                .GetField("executor",
                    System.Reflection.BindingFlags.NonPublic
                    | System.Reflection.BindingFlags.Instance);

            var executor = executorField.GetValue(driver);

            var internalExecutorField = executor.GetType()
                .GetField("internalExecutor",
                    System.Reflection.BindingFlags.NonPublic
                    | System.Reflection.BindingFlags.Instance);
            var internalExecutor = internalExecutorField.GetValue(executor);

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
