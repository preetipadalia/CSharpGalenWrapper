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
    public class TageCheckLayout
    {
        IWebDriver driver;
        CSharpGalenWrapper.LayoutHelper helper;
        LayoutReport rep;
        [OneTimeSetUp]
        public void Setup()
        {
             helper = new CSharpGalenWrapper.LayoutHelper();
            helper.StartGalenServer();
            driver = new ChromeDriver("chromedriver");
            driver.Navigate().GoToUrl("http://google.com");

            List<string> includedTags = new List<string>();
            includedTags.Add("mobile");

             rep = helper.CheckLayoutAndCreateReport(driver, "specs/GooglePass.spec", includedTags, "GoogleSearchPage", "Validation of Google input", "TestGoogleReport");
            helper.StopGalenServer();
        }

        [Test]
        public void TestCheckLayout()
        {
            Assert.Pass();
        }

        [Test]
        public void LayoutErrorCountTest()
        {
            Assert.AreEqual(rep.Errors, 0);
        }

        [OneTimeTearDown]
        public void CloseDriver()
        {
            driver.Close();
        }


    }
}