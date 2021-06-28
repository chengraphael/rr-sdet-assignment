using OpenQA.Selenium;
using SeleniumTest.Components;
using SeleniumTest.Element;

namespace SeleniumTest.Pages
{
    public class OverviewPage : AbstractElement
    {
        public NavigationComponent NavigationComponent;
        public SidebarComponent SidebarComponent;
        public ManageComponent ManageComponent;

        public OverviewPage(IWebDriver driver)
        {
            this.driver = driver;
            NavigationComponent = new NavigationComponent(this.driver);
            SidebarComponent = new SidebarComponent(this.driver);
            ManageComponent = new ManageComponent(this.driver);
        }
    }
}
