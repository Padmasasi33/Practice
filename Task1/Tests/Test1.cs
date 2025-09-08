using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Base;

namespace Task1.Tests
{
    public class Test1 : BrowserSetup
    {      

        [TestCase("Best of Electronics")]
        public void GetTheProducts(string section)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            IWebElement sectionElement = driver.FindElement(By.XPath($"//div[contains(text(),'{section}')]"));

            js.ExecuteScript("arguments[0].scrollIntoView(true);", sectionElement);

            var products = new List<string>();

            var productElements = driver.FindElements(By.XPath("//div[contains(text(),'Best of Electronics')]//following::div[@class='tLbyDf'][1]//following::div[2][@class='_58bkzq6e _3n8fna1co _3n8fna10j _3n8fnaod _3n8fna1 _3n8fnac7 _58bkzq2 _1i2djtb9 _1i2djt0']")); 

            foreach (var item in productElements)
            {
                products.Add(item.Text);

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
