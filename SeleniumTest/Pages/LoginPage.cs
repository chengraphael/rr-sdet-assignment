using OpenQA.Selenium;
using SeleniumTest.Element;

namespace SeleniumTest.Pages
{
    public class LoginPage : AbstractElement
    {
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SendLogin(string username, string password)
        {
            TypeUsername(username);
            TypePassword(password);
            ClickLoginButton();
        }

        public void TypeUsername(string username)
        {
            var usernameInput = FindElement(By.CssSelector("input[data-id=\"username\"]"));
            usernameInput.Clear();
            usernameInput.SendKeys(username);
        }

        public void TypePassword(string password)
        {
            var usernameInput = FindElement(By.CssSelector("input[data-id=\"password\"]"));
            usernameInput.Clear();
            usernameInput.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            var loginButton = FindElement(By.CssSelector("form button[type=\"submit\"]"));
            loginButton.Click();
            WaitForPage();
        }

        public bool CheckLoginPage()
        {
            var loginString = FindElement(By.CssSelector("form h4"));
            return loginString.Displayed;
        }
    }
}
