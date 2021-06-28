using OpenQA.Selenium;
using SeleniumTest.Element;

namespace SeleniumTest.Components
{
    public class MapPropertiesComponent : AbstractElement
    {
        By Parent = By.CssSelector("aside.ant-layout-sider");
        public MapPropertiesComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Here is where I would put the properties editing functions
    }
}
