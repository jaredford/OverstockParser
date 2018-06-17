using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Diagnostics;
using System.Threading;

namespace OverstockParser
{
    public partial class ExcelParser : Form
    {
        ExcelReader TrackingNumbers = null, Orders = null;
        StreamWriter sw;
        string fileName = $"{Directory.GetCurrentDirectory()}\\upload.csv";
        object[,] values = null, orderValues = null;
        const int RETAILER_NAME = 1;
        const int RETAILER_ORDER_NUMBER = 2;
        const int WAREHOUSE_NAME = 3;
        const int SOFS_ORDER_NUMBER = 4;
        const int SOFS_ORDER_LINE_NUMBER = 5;
        const int QUANTITY = 6;
        const int SUPPLIER_INVOICE_NUMBER = 7;
        const int CARRIER_CODE = 8;
        const int TRACKING_NUMBER = 9;
        const int SERVICE_LEVEL = 10;
        int error = 0, success = 0;
        List<string> sofsNumbers = new List<string>(), usedTrackingNumbers = new List<string>();
        public ExcelParser()
        {
            InitializeComponent();
            SaveLocationLabel.Text = fileName;
        }
        private void dropPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
            BackColor = Color.DeepSkyBlue;
        }

        private void dropPanel_DragDrop(object sender, DragEventArgs e)
        {
            BackColor = Color.SkyBlue;

            Info.Text = "Importing file(s)...";
            OpenSaveDialogButton.Enabled = false;
            new Thread(RunMainProcesses).Start(e);
            OpenSaveDialogButton.Enabled = true;
        }
        private void RunMainProcesses(object e)
        {
            var files = (string[])(e as DragEventArgs).Data.GetData(DataFormats.FileDrop, false);
            foreach (var file in files)
            {
                var excelFile = new ExcelReader(file.ToString(), 1);
                if (string.Equals(excelFile.ReadCell(0, 0), "Retailer Name", StringComparison.InvariantCultureIgnoreCase))
                {
                    Orders = excelFile;
                    OrdersLabel.Invoke((MethodInvoker)delegate
                    {
                        // Running on the UI thread
                        OrdersLabel.Text = "✔️ Orders File";
                    });
                }
                else if (string.Equals(excelFile.ReadCell(0, 0), "Label Type", StringComparison.InvariantCultureIgnoreCase))
                {
                    TrackingNumbers = excelFile;
                    TrackingNumbersLabel.Invoke((MethodInvoker)delegate
                    {
                        // Running on the UI thread
                        TrackingNumbersLabel.Text = "✔️ Tracking Numbers File";
                    });
                }
            }
            if (TrackingNumbers != null && Orders != null)
            {
                try
                {
                    Info.Invoke((MethodInvoker)delegate
                    {
                        // Running on the UI thread
                        Info.Text = "";
                    });
                    sw = new StreamWriter(fileName);
                    ParseFiles();

                    OrdersLabel.Invoke((MethodInvoker)delegate
                    {
                        // Running on the UI thread
                        OrdersLabel.Text = "✘ Orders File";
                    });
                    TrackingNumbersLabel.Invoke((MethodInvoker)delegate
                    {
                        // Running on the UI thread
                        TrackingNumbersLabel.Text = "✘ Tracking Numbers File";
                    });
                    Info.Invoke((MethodInvoker)delegate
                    {
                        // Running on the UI thread
                        Info.Text = $"Processed: {success} Errors: {error}";
                    });
                    ResetValues();
                }
                catch (Exception exc)
                {
                    OrdersLabel.Invoke((MethodInvoker)delegate
                    {
                        // Running on the UI thread
                        OrdersLabel.Text = "✘ Orders File";
                    });
                    TrackingNumbersLabel.Invoke((MethodInvoker)delegate
                    {
                        // Running on the UI thread
                        TrackingNumbersLabel.Text = "✘ Tracking Numbers File";
                    });
                    Info.Invoke((MethodInvoker)delegate
                    {
                        // Running on the UI thread
                        Info.Text = $"Processed: {success} Errors: {error}";
                    });
                    ResetValues();
                    if (sw != null)
                        sw.Close();
                    MessageBox.Show($"ERROR: {exc.Message}");
                }
            }
            else
            {
                Info.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    Info.Text = "Drag remaining files here";
                });
            }
        }
        private void ParseFiles()
        {
            int total = 2, iterator = 2;
            values = TrackingNumbers.GetValues();
            orderValues = Orders.GetValues();
            WriteHeadings();
            while (orderValues[iterator, 4] != null)
            {
                sofsNumbers.Add(orderValues[iterator, 4].ToString());
                if (orderValues[iterator, 1] != null)
                    total++;
                iterator++;
            }
            for (var i = 2; i < iterator; i++)
            {
                Info.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    Info.Text = $"Processing Order {i - 1}/{total - 2}";
                });
                if (orderValues[i, 1] != null)
                    ProcessData(i);
            }
            Orders.Close();
            TrackingNumbers.Close();
            sw.Close();
            GC.Collect();
        }

        private void OpenSaveDialogButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            SaveFileDialog.FilterIndex = 1;
            SaveFileDialog.RestoreDirectory = true;
            SaveFileDialog.OverwritePrompt = false;

            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = SaveFileDialog.FileName;
                SaveLocationLabel.Text = fileName;
            }
        }

        private void dropPanel_DragLeave(object sender, EventArgs e)
        {
            BackColor = Color.SkyBlue;
        }

        private string GetTrackingNumber(string contactName, object[,] values)
        {
            var row = 2;
            while (values[row, 3] != null)
            {
                if (values[row, 3].ToString().Contains(contactName) && !usedTrackingNumbers.Any(x => x == values[row, 2].ToString()))
                {
                    usedTrackingNumbers.Add(values[row, 2].ToString());
                    success++;
                    return values[row, 2].ToString().Replace("'", "");
                }
                row++;
            }
            error++;
            return "";
        }
        private void ProcessData(int row)
        {
            var retailerName = orderValues[row, RETAILER_NAME];
            var retailerOrderNumber = orderValues[row, RETAILER_ORDER_NUMBER];
            var warehouseName = orderValues[row, WAREHOUSE_NAME];
            var sofsOrderNumber = orderValues[row, SOFS_ORDER_NUMBER];
            var sofsOrderLineNumber = orderValues[row, 67];
            var amount = orderValues[row, 68];
            var contact = orderValues[row, 12].ToString();
            sw.WriteLine($"{retailerName},{retailerOrderNumber},{warehouseName},{sofsOrderNumber},{sofsOrderLineNumber},1,,USPS,{GetTrackingNumber(contact, values)},GROUND");
        }
        private void WriteHeadings()
        {
            sw.WriteLine("Retailer Name,Retailer Order Number,Warehouse Name,SOFS Order Number,SOFS Order Line Number,Quantity,Supplier Invoice Number,Carrier Code,Tracking Number,Service Level");
        }
        private void ResetValues()
        {
            TrackingNumbers = null;
            Orders = null;
            error = 0;
            success = 0;
            sofsNumbers.Clear();
            usedTrackingNumbers.Clear();
        }
    }
}
