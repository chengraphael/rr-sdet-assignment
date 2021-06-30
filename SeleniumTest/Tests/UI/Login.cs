using NUnit.Framework;
using SeleniumTest.Pages;

namespace SeleniumTest.Tests.UI
{
    [TestFixture]
    public class Login : AbstractTest
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
        }

        [SetUp]
        public void Setup()
        {
            BrowserSetup();
        }

        [TearDown]
        public void TearDown()
        {
            BrowserCleanup();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
        }

        [Test(Description = "Verify login")]
        public void VerifyLogin()
        {
            var loginPage = new LoginPage(driver);
            loginPage.SendLogin(username, password);
            var overviewPage = new Pages.OverviewPage(driver);
            var loggedInUser = overviewPage.NavigationComponent.GetUsername();

            Assert.That(loggedInUser, Is.EqualTo(username));
        }

        [Test(Description = "Verify logout")]
        public void VerifyLogout()
        {
            var loginPage = new LoginPage(driver);
            loginPage.SendLogin(username, password);
            var overviewPage = new OverviewPage(driver);
            overviewPage.NavigationComponent.Logout();

            Assert.That(
                loginPage.CheckLoginPage(),
                Is.True);
        }
    }
}
