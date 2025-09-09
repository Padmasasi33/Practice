using DocumentFormat.OpenXml.Bibliography;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Base;

namespace Task1.Pages
{
    public class ProductsPage : WebDriverKeyword
    {
        private IWebDriver _driver;
        public ProductsPage(IWebDriver driver): base (driver)
        { 
            _driver = driver;
        }

        public void GetTheProductsFromTheSection(string section)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;

            IWebElement sectionElement = _driver.FindElement(By.XPath($"//div[contains(text(),'{section}')]"));

            js.ExecuteScript("arguments[0].scrollIntoView(true);", sectionElement);

            var products = new HashSet<string>();

            int previousCount = 0;

            bool hasNext = true;
            while (hasNext)
            {
                var productElements = _driver.FindElements(By.XPath($"//div[contains(text(),'{section}')]//following::div[@class='tLbyDf'][1]//following::div[2][@class='_58bkzq6e _3n8fna1co _3n8fna10j _3n8fnaod _3n8fna1 _3n8fnac7 _58bkzq2 _1i2djtb9 _1i2djt0']"));

                foreach (var item in productElements)
                {
                    if (!string.IsNullOrWhiteSpace(item.Text))
                        products.Add(item.Text.Trim());

                }

                if (products.Count == previousCount)
                {
                    hasNext = false;
                    break;
                }

                previousCount = products.Count;
                try
                {
                    IWebElement nextButton = _driver.FindElement(By.XPath($"//div[contains(text(),'{section}')]//following::button[1]"));

                    if (nextButton.Displayed)
                    {
                        nextButton.Click();                        
                    }
                    else
                    {
                        hasNext = false;
                    }
                }
                catch (NoSuchElementException)
                {
                    hasNext = false;
                }
            }
            Console.WriteLine(products.Count);
            Console.WriteLine("Products found:");

            foreach (var p in products)
            {
                Console.WriteLine("- " + p);
            }

            Assert.IsTrue(products.Count > 0);

        }
    }
}

