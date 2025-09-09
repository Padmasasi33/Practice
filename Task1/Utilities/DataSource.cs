using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Utilities
{
    public class DataSource
    {
        public static object[] CategoryNamesFromExcel()
        {
            object[] main = ExcelSource.GetSheetIntoObjectArray(@"C:\Users\I8547\source\repos\Task1\Task1\TestData\CategoryNames.xlsx", "Category");

            return main;

        }
    }
}
