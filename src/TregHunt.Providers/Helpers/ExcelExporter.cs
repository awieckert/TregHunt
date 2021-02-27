using System;
using System.Collections.Generic;
using System.Data;
using TregHunt.Contracts.Helpers;
using TregHunt.Contracts.Models;
using TregHunt.Services.Settings;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;

namespace TregHunt.Services.Helpers
{
    public class ExcelExporter : IExcelExporter
    {
        readonly FileSettings _fileSettings;

        public ExcelExporter(FileSettings fileSettings)
        {
            _fileSettings = fileSettings;
        }

        public void ExportToExcel(DataTable dataTable)
        {
            try
            {
                Console.WriteLine("Exporting data table to excel file.");

                DataSet dataSet = new DataSet();
                dataSet.DataSetName = dataTable.TableName;
                dataSet.Tables.Add(dataTable);

                // create a excel app, with workbook and worksheet and give a name to it
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook excelWorkBook = excelApp.Workbooks.Add();
                Excel._Worksheet xlWorksheet = (Excel._Worksheet)excelWorkBook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                foreach (DataTable table in dataSet.Tables)
                {
                    //Add a new worksheet to workbook with the Datatable name
                    Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkBook.Sheets.Add();
                    excelWorkSheet.Name = table.TableName;
                    // add all the columns
                    for (int i = 1; i < table.Columns.Count + 1; i++)
                    {
                        excelWorkSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
                    }
                    // add all the rows
                    for (int j = 0; j < table.Rows.Count; j++)
                    {
                        for (int k = 0; k < table.Columns.Count; k++)
                        {
                            excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                        }
                    }
                }
                //add date time but it can't have slashes duuhhhh
                excelWorkBook.SaveAs($"{_fileSettings.FileSaveLocation}{dataSet.DataSetName}");
                excelWorkBook.Close();
                excelApp.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error exporting data table to excel file.", ex);
                throw ex;
            }
        }
    }
}
