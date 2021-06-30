using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumTest.Element;
using System.Linq;

namespace SeleniumTest.Components
{
    public class NavigationComponent : AbstractElement
    {
        readonly By ParentSelector = By.CssSelector("div#app-container>div>div:nth-child(2)>div:nth-child(1)>div");
        readonly By Menu = By.CssSelector("div:nth-child(2)>div:nth-child(2)");
        readonly By MenuUsername = By.CssSelector("div:nth-child(2)>div>div>button>span");
        readonly By MenuItems = By.CssSelector("ul>li[role=\"menuitem\"]");

        public enum MenuOptions
        {
            AccountInformation,
            Organizations,
            Logout
        }

        public NavigationComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetUsername()
        {
            var parent = FindElement(ParentSelector);
            var username = FindElement(parent, MenuUsername);
            return username.Text;
        }

        public void Logout()
        {
            var actions = new Actions(driver);

            var parent = FindElement(ParentSelector);
            var hoverArea = FindElement(parent, Menu);
            actions.MoveToElement(hoverArea).Build().Perform();

            var menuItems = parent.FindElements(MenuItems);
            var logout = menuItems.ElementAt((int)MenuOptions.Logout);
            logout.Click();
            WaitForPage();
        }
    }
}
