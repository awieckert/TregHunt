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
        public SearchTermImporter(){}

        public IEnumerable<PubMedQuery> Import(string filePath)
        {
            var excel = new ExcelQueryFactory(filePath);

            var primaryTerms = excel.Worksheet<SearchTerm>("PrimarySearchTerms").ToList().Where(x => !string.IsNullOrWhiteSpace(x.Term));
            var secondaryTerms = excel.Worksheet<SearchTerm>("SecondarySearchTerms").ToList().Where(x => !string.IsNullOrWhiteSpace(x.Term));

            var pubmedQueries = new List<PubMedQuery>();

            //TODO: I think I need to seperate out the importing process and the forming of the queries. It would be nice to be able to form queries for different DBs/Eutilities
            //Think about how to let the user define the number of searches. Later.
            foreach (var item in primaryTerms)
            {
                foreach (var term in secondaryTerms)
                {
                    pubmedQueries.Add(new PubMedQuery { PrimaryTerm = item.Term, SecondaryTerm = term.Term, StrictSearch = true, Eutility = "esearch.fcgi" });
                }
            }

            return pubmedQueries;
        }
    }
}
