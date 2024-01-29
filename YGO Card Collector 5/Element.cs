//Joel Campos
//1/29/2024
//Element Class

using OpenQA.Selenium;
using System;

namespace YGO_Card_Collector_5
{
    public static class Element
    {
        public static void WaitUntilElementIsVisble(string xpath)
        {
            Driver.ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            Driver.ChromeDriver.FindElement(By.XPath(xpath));
        }
        public static void InputText(string xpath, string text)
        {
            Driver.ChromeDriver.FindElement(By.XPath(xpath)).SendKeys(text);
        }
        public static void ClickByXpath(string xpath)
        {
            Driver.ChromeDriver.FindElement(By.XPath(xpath)).Click();
        }
        public static string GetText(string xpath)
        {
            return Driver.ChromeDriver.FindElement(By.XPath(xpath)).Text;
        }
        public static int GetElementCount(string xpath)
        {
            return Driver.ChromeDriver.FindElements(By.XPath(xpath)).Count;
        }
        public static string GetElementAttribute(string xpath, string attributeName)
        {
            return Driver.ChromeDriver.FindElement(By.XPath(xpath)).GetAttribute(attributeName);
        }
        public static IWebElement ScrollToView(string xpath)
        {
            var element = Driver.ChromeDriver.FindElement(By.XPath(xpath));
            ScrollToView(element);
            return element;

            void ScrollToView(IWebElement element2)
            {
                if (element2.Location.Y > 200)
                {
                    ScrollTo(0, element2.Location.Y - 100); // Make sure element is in the view but below the top navigation pane
                }

            }

            void ScrollTo(int xPosition = 0, int yPosition = 0)
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.ChromeDriver; js.ExecuteScript(String.Format("window.scrollTo({0}, {1})", xPosition, yPosition));
            }
        }
        public static bool ElementExist(string xpath)
        {
            return GetElementCount(xpath) > 0;
        }
    }
}
