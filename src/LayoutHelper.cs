using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using CSharpGalenWrapper.API;
using Newtonsoft.Json;

namespace CSharpGalenWrapper
{
    public class LayoutHelper
    {
        static CheckLayoutAPI layoutAPI=new CheckLayoutAPI();

       
        public Result CheckLayout(IWebDriver driver, string specFilePath, List<string> listIncluded)
        {
            var layoutRep=layoutAPI.CheckLayoutPost(driver,specFilePath,"",listIncluded);
            Result rep=GetLayoutReportObject(layoutRep);
            return rep;
        }

        private Result GetLayoutReportObject(string layoutRep)
        {
            return  JsonConvert.DeserializeObject<Result>(layoutRep); 
        }
    }
}
