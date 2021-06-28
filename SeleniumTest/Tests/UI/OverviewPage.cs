using NUnit.Framework;
using System;

namespace SeleniumTest.Tests.UI
{
    class OverviewPage : AbstractTest
    {
        Pages.OverviewPage overviewPage;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            BrowserSetup();

            var loginPage = new Pages.LoginPage(driver);
            loginPage.SendLogin(username, password);
            overviewPage = new Pages.OverviewPage(driver);
        }

        [SetUp]
        public void Setup()
        {
            Console.WriteLine(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void TearDown()
        {
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            BrowserCleanup();
        }

        [Test(Description = "Verify create node")]
        public void VerifyCreateNode()
        {

        }
    }
}
