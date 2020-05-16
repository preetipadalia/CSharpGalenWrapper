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
    public class TageCheckLayout
    {
        IWebDriver driver;
        LayoutReport rep;
        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver("/Users/sachin/Preeti");
            driver.Navigate().GoToUrl("http://google.com");
            
            List<string> includedTags = new List<string>();
            includedTags.Add("mobile");
           
            CSharpGalenWrapper.LayoutHelper helper = new CSharpGalenWrapper.LayoutHelper();
            rep = helper.CheckLayoutAndCreateReport(driver, Path.GetFullPath("specs/GooglePass.spec"),includedTags,"GoogleSearchPage","Validation of Google input","TestGoogleReport" );

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