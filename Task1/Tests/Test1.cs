using OpenQA.Selenium;
using Task1.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Base;
using System.Data.Common;
using Task1.Pages;

namespace Task1.Tests
{
    public class Test1 : BrowserSetup
    {

        [Test, TestCaseSource(typeof(DataSource), nameof(DataSource.CategoryNamesFromExcel))]
        public void GetTheProducts(string section)
        {
            ProductsPage productsPage = new ProductsPage(driver);
            productsPage.GetTheProductsFromTheSection(section);
        }
    }
}
