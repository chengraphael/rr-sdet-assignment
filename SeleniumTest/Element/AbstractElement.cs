using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SeleniumTest.Element
{
    public class AbstractElement
    {
        public IWebDriver driver;
        private const int TimeoutInSeconds = 10;

        public void WaitForPage(int timeoutInSeconds = TimeoutInSeconds)
        {
            Thread.Sleep(1000);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(driver => ((IJavaScriptExecutor)driver)
                .ExecuteScript("return document.readyState").Equals("complete"));
        }

        public IWebElement FindElement(By by, int timeoutInSeconds = TimeoutInSeconds)
        {
            try
            {
                if (timeoutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    return wait.Until(d => d.FindElement(by));
                }
                return driver.FindElement(by);
            }
            catch
            {
                return null;
            }
        }

        public IReadOnlyCollection<IWebElement> FindElements(By by, int timeoutInSeconds = TimeoutInSeconds)
        {
            try
            {
                if (timeoutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    return wait.Until(d => d.FindElements(by));
                }
                return driver.FindElements(by);
            }
            catch
            {
                return null;
            }
        }

        public IWebElement FindElement(IWebElement parent, By by, int timeoutInSeconds = TimeoutInSeconds)
        {
            try
            {
                if (timeoutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    return wait.Until(d => parent.FindElement(by));
                }
                return parent.FindElement(by);
            }
            catch
            {
                return null;
            }
        }

        public IReadOnlyCollection<IWebElement> FindElements(IWebElement parent, By by, int timeoutInSeconds = TimeoutInSeconds)
        {
            try
            {
                if (timeoutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    return wait.Until(d => parent.FindElements(by));
                }
                return parent.FindElements(by);
            }
            catch
            {
                return null;
            }
        }
    }
}
