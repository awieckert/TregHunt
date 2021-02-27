using System;
using System.Collections.Generic;
using System.Linq;
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

        public void ExportESearchESumResult(IEnumerable<FlatESearchESumResult> results)
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

        public IEnumerable<FlatESearchESumResult> FlattenESearchESumResult(IEnumerable<PubMedESearchESumResponse> searchResults)
        {
            try
            {
                Console.WriteLine($"Flattening search results for export to excel file.");

                var flattendResults = new List<FlatESearchESumResult>();

                if (searchResults.Count() == 0) return flattendResults;

                foreach (var result in searchResults)
                {
                    foreach (var article in result.Articles)
                    {
                        flattendResults.Add(new FlatESearchESumResult
                        {
                            SearchTerms = result.SearchGrouping,
                            ArticleId = article.Id,
                            Title = article.Title,
                            Source = article.Source,
                            PubDate = article.PubDate,
                            Authors = MapAuthorsToString(article.Authors)
                        });
                    }
                }

                return flattendResults;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error flattening search results.", ex);
                throw;
            }

        }

        private string MapAuthorsToString(List<string> authors)
        {
            string stringOfAuthors = "";
            for (int i = 0; i < authors.Count; i++)
            {
                if ((i + 1) == authors.Count)
                {
                    stringOfAuthors += $"{authors[i]}";
                    continue;
                }

                stringOfAuthors += $"{authors[i]}, ";
            }

            return stringOfAuthors;
        }
    }
}
