# CSharpGalenWrapper

This is a wrapper around Galen framework for csharp. 
The NuGet can be used in folwwing ways:

If a new browser needs to be opened :
	
	          CSharpGalenWrapper.LayoutHelperhelper = new CSharpGalenWrapper.LayoutHelper();
            helper.StartGalenServer();
            Browser browser = new Browser();
            browser.BrowserHeight = 300;
            browser.BrowserWidth = 400;
            browser.BrowserType = "chrome";
            browser.DriverPath = "chromedriver/chromedriver";
            browser.Url = "http://google.com";
            LayoutReport rep = helper.CheckLayout(browser, "specs/GoogleFailure.spec", new List<string>());
            helper.StopGalenServer();
  
            
  if the project is having existing driver and want to reuse it:
  
            CSharpGalenWrapper.LayoutHelperhelper = new CSharpGalenWrapper.LayoutHelper();
            helper.StartGalenServer();
            driver = new ChromeDriver("chromedriver");
            driver.Navigate().GoToUrl("http://google.com");
            driver.Manage().Window.Size = new System.Drawing.Size(200, 300);
            LayoutReport rep = helper.CheckLayout(driver, "specs/GoogleFailure.spec", new List<string>());
            Assert.AreEqual(rep.ValidationResults[0].Error.Messages[0], "\"input\" is -106px below \"submit\" but it should be greater than or equal to 0px");
            helper.StopGalenServer();
            
  If along with validation,report also needs to be generated:
	
            CSharpGalenWrapper.LayoutHelperhelper = new CSharpGalenWrapper.LayoutHelper();
            helper.StartGalenServer();
            driver = new ChromeDriver("chromedriver");
            driver.Navigate().GoToUrl("http://google.com");
            List<string> includedTags = new List<string>();
            includedTags.Add("mobile");
            LayoutReport rep = helper.CheckLayoutAndCreateReport(driver, "specs/GoogleTestWithSectionFilter.spec", includedTags, "test", "Testing", "results/test");
            helper.StopGalenServer();
          
