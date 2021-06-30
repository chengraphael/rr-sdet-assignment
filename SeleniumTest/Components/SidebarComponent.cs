using OpenQA.Selenium;
using SeleniumTest.Element;
using System.Linq;

namespace SeleniumTest.Components
{
    public class SidebarComponent : AbstractElement
    {
        readonly By ParentSelector = By.CssSelector("div#app-container>div>div:nth-child(1)");
        readonly By SidebarButtons = By.CssSelector(":root>a");

        public enum SidebarOptions
        {
            Map,
            Agents,
            Manage
        }

        public SidebarComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SelectSidebarOption(SidebarOptions option)
        {
            var parent = FindElement(ParentSelector);
            var buttons = FindElements(parent, SidebarButtons);
            buttons.ElementAt((int) option).Click();
            WaitForPage();
        }
    }
}
