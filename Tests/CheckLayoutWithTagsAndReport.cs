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
    public class CheckLayoutWithTagsAndReport
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
            List<string> excludedTags = new List<string>();
            excludedTags.Add("desktop");
            CSharpGalenWrapper.LayoutHelper helper = new CSharpGalenWrapper.LayoutHelper();
            rep = helper.CheckLayoutAndCreateReport(driver, "specs/GoogleTestWithSectionFilter.spec", includedTags,"test","Testing","results/test");

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

        [Test]
        public void LayoutErrorMessageTest()
        {
            Assert.AreEqual(rep.ValidationResults.Length,0);
        }

        [Test]
        public void LayoutTestObjectNamePassTest()
        {
             var area = new Area();
            area.Height = 34;
            area.Left = 406;
            area.Top = 280;
            area.Width = 387;
            Assert.AreEqual(rep.Objects["input"].getArea()[0],406);
        }

    


        [OneTimeTearDown]
        public void CloseDriver()
        {
            driver.Close();
        }
    }
}