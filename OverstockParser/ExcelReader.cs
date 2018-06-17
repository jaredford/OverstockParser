using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace OverstockParser
{
    class ExcelReader
    {
        string path = "";
        _Application excel = new Application();
        Workbook wb;
        Worksheet ws;
        public ExcelReader(string path, int sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[sheet];
        }

        public string ReadCell(int row, int column)
        {
            row++;
            column++;
            return (ws.Cells[row, column].Value2 ?? "").ToString();
        }
        public object[,] GetValues()
        {
            Range range = ws.get_Range("A1", "CG5000");
            return (object[,])range.Value2;
        }
        public void Close()
        {
            var workbooks = excel.Workbooks;
            wb.Close();
            Marshal.ReleaseComObject(wb);
            Marshal.ReleaseComObject(workbooks);
            Marshal.ReleaseComObject(excel);
        }

    }
}
