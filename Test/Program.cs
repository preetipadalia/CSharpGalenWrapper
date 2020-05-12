using System;
using System.Collections.Generic;
using CSharpGalenWrapper.Report;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

using RestSharp;

namespace test_api
{
    class Program
    {
        static void Main(string[] args)
        {
            TestCheckLayoutWithPost();
        }
        private static void TestCheckLayoutWithPost()
        {
            IWebDriver driver = new ChromeDriver("/Users/sachin/Preeti");
            driver.Navigate().GoToUrl("http://google.com");

            CSharpGalenWrapper.LayoutHelper helper=new CSharpGalenWrapper.LayoutHelper();
            Result rep=helper.CheckLayout(driver,"/Users/sachin/Preeti/Specs/sample.spec",null);
        }
    }
}
