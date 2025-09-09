using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Utilities
{
    public class ExcelSource
    {
        public static object[] GetSheetIntoObjectArray(string file, string sheetName)
        {
            XLWorkbook book = new XLWorkbook(file);

            var sheet = book.Worksheet(sheetName); 

            var range = sheet.RangeUsed();

            int rowCount = range.RowCount();
            int columnCount = range.ColumnCount();

            object[] main = new object[rowCount - 1];

            for (int r = 2; r <= rowCount; r++)
            {
                string[] data = new string[columnCount];  
                for (int c = 1; c <= columnCount; c++)
                {
                    string cellValue = range.Cell(r, c).GetString();
                    Console.WriteLine(cellValue);
                    data[c - 1] = cellValue;
                }
                main[r - 2] = data;
            }


            book.Dispose();
            return main;
        }
    }
}
