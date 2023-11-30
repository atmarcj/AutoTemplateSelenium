using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace plataforma_automatizada.pages
{
    class BasePage
    {
        protected readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private protected void Click(By by)
        {
            driver.FindElement(by).Click();
        }

        private protected void SendKeys(By by, string text)
        {
            driver.FindElement(by).SendKeys(text);
        }

        private protected void Clear(By by)
        {
            driver.FindElement(by).Clear();
        }

        private protected string Text(By by)
        {
            return driver.FindElement(by).Text;
        }

        private protected string GetAttribute(By by, string attribute)
        {
            return driver.FindElement(by).GetAttribute(attribute);
        }

        private protected void SelectByIndex(By by, int index)
        {
            new SelectElement(driver.FindElement(by)).SelectByIndex(index);
        }

        private protected void SelectByText(By by, string text)
        {
            new SelectElement(driver.FindElement(by)).SelectByText(text);
        }

        private protected void SelectByValue(By by, string value)
        {
            new SelectElement(driver.FindElement(by)).SelectByValue(value);
        }

        private protected string Title()
        {
            return driver.Title;
        }

        private protected void Quit()
        {
            driver.Quit();
        }
    }
}
