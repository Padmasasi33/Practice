using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Base
{
    public class WebDriverKeyword 
    {
        private IWebDriver _driver;
        private DefaultWait<IWebDriver> _wait;
        public WebDriverKeyword(IWebDriver driver)
        {
            _driver = driver;
            SetupFluentWait();
        }
        public void SetupFluentWait(int timeout = 30000, int PollingTimeout = 500)
        {
            _wait = new DefaultWait<IWebDriver>(_driver);
            _wait.PollingInterval = TimeSpan.FromSeconds(PollingTimeout);
            _wait.Timeout = TimeSpan.FromSeconds(timeout);
            _wait.IgnoreExceptionTypes(typeof(Exception));
        }
        public string GetTextFromElement(By locator)
        {
            return _driver.FindElement(locator).Text;
        }

    }
}
