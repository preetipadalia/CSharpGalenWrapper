using System.Collections.Generic;
using System.IO;
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
            tests = new List<LayoutReport>();
            driver = new ChromeDriver("/Users/sachin/Preeti");
            driver.Navigate().GoToUrl("http://google.com");
            List<string> includedTags = new List<string>();
            includedTags.Add("mobile");
            CSharpGalenWrapper.LayoutHelper helper = new CSharpGalenWrapper.LayoutHelper();
            rep = helper.CheckLayoutAndCreateReport(driver, Path.GetFullPath("specs/GooglePass.spec"), includedTags, "GoogleSearchPage", "Validation of Google input", "TestGoogleReport");
            rep.Title = "This is testing";
            tests.Add(rep);
            LayoutReport rep1 = helper.CheckLayoutAndCreateReport(driver, Path.GetFullPath("specs/GooglePass.spec"), includedTags, "GoogleSearchPage", "Validation of Google input", "TestGoogleReport");
            rep1.Title = "This is another testing";
            tests.Add(rep1);
            // ReportHelper reportHelper=new ReportHelper();
            // reportHelper.GenerateReport("TestingResult/Tests",tests);

        }

        [Test]
        public void TestCheckLayout()
        {
            Assert.Pass();
        }
    }
}
