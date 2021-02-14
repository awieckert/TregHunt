using LinqToExcel;
using System;
using System.Collections.Generic;
using System.Linq;
using TregHunt.Contracts.Models;
using TregHunt.Contracts.Services;
using TregHunt.Services.ExcelData;

namespace TregHunt.Services
{
    public class SearchTermImporter : ISearchTermImporter
    {
        readonly IPubMedService _pubMedService;

        public SearchTermImporter(IPubMedService pubMedService)
        {
            _pubMedService = pubMedService;
        }

        public void Import(string filePath)
        {
            var excel = new ExcelQueryFactory(filePath);

            var primaryTerms = excel.Worksheet<SearchTerm>("PrimarySearchTerms").ToList().Where(x => !string.IsNullOrWhiteSpace(x.Term));
            var secondaryTerms = excel.Worksheet<SearchTerm>("SecondarySearchTerms").ToList().Where(x => !string.IsNullOrWhiteSpace(x.Term));

            var pubmedQueries = new List<PubMedQuery>();

            foreach (var item in primaryTerms)
            {
                foreach (var term in secondaryTerms)
                {
                    pubmedQueries.Add(new PubMedQuery { PrimaryTerm = item.Term, SecondaryTerm = term.Term, StrictSearch = true });
                }
            }

            _pubMedService.GetArticleUIDs(pubmedQueries);

        }
    }
}
