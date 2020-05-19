# CSharpGalenWrapper

This is a C# wrapper for [Galen framework](http://galenframework.com/). It can be used to access Galen framework capabilities from C# projects.

## To open a new browser
	
```
CSharpGalenWrapper.LayoutHelper helper = new CSharpGalenWrapper.LayoutHelper();
helper.StartGalenServer();
Browser browser = new Browser();
browser.BrowserHeight = 300;
browser.BrowserWidth = 400;
browser.BrowserType = "chrome";
browser.DriverPath = "chromedriver/chromedriver";
browser.Url = "http://google.com";
LayoutReport rep = helper.CheckLayout(browser, "specs/GoogleFailure.spec", new List<string>());
helper.StopGalenServer();
```
  
            
## To reuse an existing driver
  
```
CSharpGalenWrapper.LayoutHelperhelper = new CSharpGalenWrapper.LayoutHelper();
helper.StartGalenServer();
IWebDriver driver = new ChromeDriver("chromedriver");
driver.Navigate().GoToUrl("http://google.com");
driver.Manage().Window.Size = new System.Drawing.Size(200, 300);
LayoutReport rep = helper.CheckLayout(driver, "specs/GoogleFailure.spec", new List<string>());
Assert.AreEqual(rep.ValidationResults[0].Error.Messages[0], "\"input\" is -106px below \"submit\" but it should be greater than or equal to 0px");
helper.StopGalenServer();
```
            
## To generate report
	
```
CSharpGalenWrapper.LayoutHelperhelper = new CSharpGalenWrapper.LayoutHelper();
helper.StartGalenServer();
IWebDriver driver = new ChromeDriver("chromedriver");
driver.Navigate().GoToUrl("http://google.com");
List<string> includedTags = new List<string>();
includedTags.Add("mobile");
LayoutReport rep = helper.CheckLayoutAndCreateReport(driver, "specs/GoogleTestWithSectionFilter.spec", includedTags, "test", "Testing", "results/test");
helper.StopGalenServer();
```
          
