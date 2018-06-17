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
    class ExcelWriter
    {
        string path = "";
        _Application excel = new Application();
        Workbook wb;
        Worksheet ws;
        public ExcelWriter(string path)
        {
            this.path = path;
            var test = excel.Workbooks.Add();
            wb = excel.ActiveWorkbook;
            ws = wb.Worksheets[1];
        }

        public void WriteCell(int row, int column, object value)
        {
            ws.Cells[row, column].Value2 = value;
        }
        public void Save()
        {
            wb.SaveAs(path, XlFileFormat.xlCSVWindows);
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
