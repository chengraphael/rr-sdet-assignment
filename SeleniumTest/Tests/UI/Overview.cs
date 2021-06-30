using NUnit.Framework;
using SeleniumTest.Pages;
using System;

namespace SeleniumTest.Tests.UI
{
    class Overview : AbstractTest
    {
        OverviewPage overviewPage;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            BrowserSetup();

            var loginPage = new LoginPage(driver);
            loginPage.SendLogin(username, password);
            overviewPage = new OverviewPage(driver);
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
