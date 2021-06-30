using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTest.Tests.UI
{
    public abstract class AbstractTest
    {
        public IWebDriver driver;
        public string homeURL;
        public string username;
        public string password;

        public void BrowserSetup()
        {
            homeURL = @"http://inst-csydkocpjocaewuqjpftzvyp-aerytg.ep-r.io/";
            username = "autobootstrap";
            password = "autobootstrap";

            var options = new ChromeOptions();
            options.AddArguments("--window-size=1920,1080", "--incognito");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(homeURL);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => ((IJavaScriptExecutor)driver)
                .ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void BrowserCleanup()
        {
            driver.Close();
        }
    }
}
