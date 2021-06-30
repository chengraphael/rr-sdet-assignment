using OpenQA.Selenium;
using SeleniumTest.Element;
using System.Linq;

namespace SeleniumTest.Components
{
    public class ManageComponent : AbstractElement
    {
        readonly By ParentSelector = By.CssSelector("div#app-container div.rramr-manage");
        readonly By TabParent = By.CssSelector("div.ant-tabs");
        readonly By Tab = By.CssSelector("div.ant-tabs-tab");
        readonly By MapList = By.CssSelector("div.rramr-map-list");
        readonly By Maps = By.CssSelector("div.ant-card");
        readonly By MapName = By.CssSelector("div.ant-card-body div.rramr-list-card__footer div.rramr-list-card__details span.rramr-list-card__details-text");

        public enum TabOptions
        {
            SiteOverview,
            Maps
        }

        public ManageComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SelectTab(TabOptions option)
        {
            var parent = FindElement(ParentSelector);
            var tabParent = FindElement(parent, TabParent);
            var tabs = FindElements(tabParent, Tab);
            tabs.ElementAt((int) option).Click();
            WaitForPage();
        }

        public void SelectMap(string mapName)
        {
            var parent = FindElement(ParentSelector);
            var mapList = FindElement(parent, MapList);
            var maps = FindElements(mapList, Maps);

            foreach (var map in maps)
            {
                var name = FindElement(map, MapName);
                if (name.Text.Equals(mapName))
                {
                    map.Click();
                    WaitForPage();
                    return;
                }
            }
        }
    }
}
