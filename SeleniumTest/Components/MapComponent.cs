using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumTest.Element;

namespace SeleniumTest.Components
{
    public class MapComponent : AbstractElement
    {
        readonly By ParentSelector = By.CssSelector("div.konvajs-content");
        public MapComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Here is where I would put the map editing functions
        public void ClickOntoMap(int x, int y)
        {
            var parent = FindElement(ParentSelector);
            var origin = parent.Location;

            var actions = new Actions(driver);
            actions.MoveByOffset(origin.X + x, origin.Y + y).Click().Build().Perform();
        }
        public void DragOntoMap(int x1, int y1, int x2, int y2)
        {
            var parent = FindElement(ParentSelector);
            var origin = parent.Location;

            var actions = new Actions(driver);
            actions.MoveByOffset(origin.X + x1, origin.Y + y1).ClickAndHold()
                .MoveByOffset(x2, y2).Release().Build().Perform();
        }
    }
}
