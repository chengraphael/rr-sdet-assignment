using OpenQA.Selenium;
using SeleniumTest.Components;
using SeleniumTest.Element;
using System.Linq;

namespace SeleniumTest.Pages
{
    class MapEditorPage : AbstractElement
    {
        readonly By ParentSelector = By.CssSelector("div#app-container>div>div>div:nth-child(2)>div>div>div");
        readonly By MapTopBar = By.CssSelector("div:nth-child(1)");
        readonly By MapTopBarButton = By.CssSelector("button");
        readonly By MapSideBar = By.CssSelector("div:nth-child(2)>div>div>div:nth-child(1)");
        readonly By MapSideBarOption = By.CssSelector("div a");

        public NavigationComponent NavigationComponent;
        public MapComponent MapComponent;
        public MapPropertiesComponent MapPropertiesComponent;

        public enum Modes
        {
            Select,
            Node,
            Edge,
            Spot,
            Region
        }

        public MapEditorPage(IWebDriver driver)
        {
            this.driver = driver;
            NavigationComponent = new NavigationComponent(this.driver);
            MapComponent = new MapComponent(this.driver);
        }

        public void EditMap()
        {
            var parent = FindElement(ParentSelector);
            var mapTopBar = FindElement(parent, MapTopBar);
            var buttons = FindElements(mapTopBar, MapTopBarButton);
            buttons.First().Click();
        }

        public void ExitMapEditor()
        {
            var parent = FindElement(ParentSelector);
            var mapTopBar = FindElement(parent, MapTopBar);
            var buttons = FindElements(mapTopBar, MapTopBarButton);
            buttons.Last().Click();
        }

        public void SelectMode(Modes mode)
        {
            var parent = FindElement(ParentSelector);
            var mapSideBar = FindElement(parent, MapSideBar);
            var options = FindElements(mapSideBar, MapSideBarOption);
            options.ElementAt((int)mode).Click();
        }
    }
}
