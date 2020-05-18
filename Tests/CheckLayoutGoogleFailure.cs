using System.Collections.Generic;
using System.IO;
using CSharpGalenWrapper.API;
using CSharpGalenWrapper.Report.Validation;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    public class CheckLayoutGoogleFailure
    {
        IWebDriver driver;
        CSharpGalenWrapper.Report.LayoutReport rep;
        [OneTimeSetUp]
        public void Setup()
        {
            Server.StartGalenServer();
            driver = new ChromeDriver("/Users/sachin/Preeti");
            driver.Navigate().GoToUrl("http://google.com");
            driver.Manage().Window.Size = new System.Drawing.Size(200, 300);

            CSharpGalenWrapper.LayoutHelper helper = new CSharpGalenWrapper.LayoutHelper();
            rep = helper.CheckLayout(driver, "specs/GoogleFailure.spec", new List<string>());
            Server.StopGalenServer();
        }

        [Test]
        public void TestCheckLayout()
        {
            Assert.Pass();
        }

        [Test]
        public void LayoutErrorCountTest()
        {
            Assert.AreEqual(rep.Errors, 1);
        }

        [Test]
        public void LayoutErrorMessageTest()
        {
            Assert.AreEqual(rep.ValidationResults[0].Error.Messages[0], "\"input\" is -106px below \"submit\" but it should be greater than or equal to 0px");
        }

        [Test]
        public void LayoutTestObjectNamePassTest()
        {
            Assert.AreEqual(rep.ValidationResults[0].ValidationObjects[0].Name, "input");
        }

        [Test]
        public void LayoutTestObjectAreaPassTest()
        {
            var area = new Area();
            area.Height = 34;
            area.Left = 406;
            area.Top = 280;
            area.Width = 387;
            Assert.AreEqual(rep.ValidationResults[0].ValidationObjects[0].Area.Top, area.Top);
        }


        [OneTimeTearDown]
        public void CloseDriver()
        {
            driver.Close();
        }
    }
}