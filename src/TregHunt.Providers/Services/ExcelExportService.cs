using System;
using System.Collections.Generic;
using System.Text;
using TregHunt.Contracts.Helpers;
using TregHunt.Contracts.Models;
using TregHunt.Contracts.Services;

namespace TregHunt.Services.Services
{
    public class ExcelExportService : IExcelExportService
    {
        readonly IDatatableConverter _dataTableConverter;
        readonly IExcelExporter _excelExporter;

        public ExcelExportService(IDatatableConverter datatableConverter, IExcelExporter excelExporter)
        {
            _dataTableConverter = datatableConverter;
            _excelExporter = excelExporter;
        }

        public void ExportESearchESumResult(IEnumerable<PubMedESearchESumResponse> results)
        {
            try
            {
                var dataTable = _dataTableConverter.ListToDataTable(results);

                _excelExporter.ExportToExcel(dataTable);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
