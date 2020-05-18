using System.Collections.Generic;
using System.IO;
using CSharpGalenWrapper.API;
using CSharpGalenWrapper.Layout;
using CSharpGalenWrapper.Report;
using CSharpGalenWrapper.Report.Validation;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    [TestFixture]
    public class TestReportGeneration
    {
        IWebDriver driver;
        LayoutReport rep;
        List<LayoutReport> tests;
        [OneTimeSetUp]
        public void Setup()
        {
           Server.StartGalenServer();
            // ReportHelper reportHelper=new ReportHelper();
            // reportHelper.GenerateReport("TestingResult/Tests",tests);

        }

        [Test]
        public void TestCheckLayout()
        {
             driver = new ChromeDriver("/Users/sachin/Preeti");
            driver.Navigate().GoToUrl("http://google.com");

            CSharpGalenWrapper.LayoutHelper helper = new CSharpGalenWrapper.LayoutHelper();
            rep = helper.CheckLayout(driver, "specs/GoogleFailure.spec", new List<string>());

        }

         [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Server.StopGalenServer();
        }
    }
}
