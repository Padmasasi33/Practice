using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Base
{
    public class BrowserSetup
    {
        protected IWebDriver driver;
        private DefaultWait<IWebDriver> _wait;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://www.flipkart.com/";

        }
       
        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Dispose();
            }
        }
    }
}

