using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chromium;

namespace CSharpGalenWrapper
{
    internal class WebDriverHelper
    {
        public static Uri GetExecutorURLFromDriver(WebDriver driver)
        {
            var executorField = typeof(WebDriver)
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
