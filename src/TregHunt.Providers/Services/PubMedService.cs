using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TregHunt.Contracts.Helpers;
using TregHunt.Contracts.Models;
using TregHunt.Contracts.Services;
using TregHunt.Services.Settings;

namespace TregHunt.Services.Services
{
    public class PubMedService : IPubMedService
    {
        readonly IPubMedApiService _pubMedApiService;
        readonly PubMedApiSettings _settings;
        readonly IXmlParser _xmlParser;
        readonly IQueryFormatter _queryFormatter;

        public PubMedService(IPubMedApiService pubMedApiService, PubMedApiSettings settings, IXmlParser xmlParser, IQueryFormatter queryFormatter) 
        {
            _pubMedApiService = pubMedApiService;
            _settings = settings;
            _xmlParser = xmlParser;
            _queryFormatter = queryFormatter;
        }

        public IEnumerable<PubMedESearchESumResponse> PubMedESearch(IEnumerable<PubMedQuery> pubMedQueries)
        {
            try
            {
                var allResponses = new List<PubMedESearchESumResponse>();

                foreach (var query in pubMedQueries)
                {
                    Console.WriteLine($"Searching for {query.PrimaryTerm} + {query.SecondaryTerm}");

                    var response = _pubMedApiService.Get<PubMedESearchResponse>(_queryFormatter.FormatESearchQuery(query));

                    if (response == null || response.IdList == null ||response.IdList.Count == 0)
                    {
                        Thread.Sleep(75);
                        continue;
                    }

                    Console.WriteLine($"ESearch successful for {query.PrimaryTerm} + {query.SecondaryTerm}");

                    var postResponse = PubMedESummary(response);

                    if (postResponse.Articles.Count() == 0)
                    {
                        Console.WriteLine($"No Esummary results returned for search terms {query.PrimaryTerm} + {query.SecondaryTerm}. It's possible the returned xml from pubmed could not be parse. Check logs for details");
                        Thread.Sleep(75);
                        continue;
                    }

                    var fullSearchResult = new PubMedESearchESumResponse(query.PrimaryTerm, query.SecondaryTerm) 
                    {
                        Uids = response.IdList,
                        Articles = postResponse.Articles
                    };

                    allResponses.Add(fullSearchResult);
                    Thread.Sleep(200);
                }

                Console.WriteLine($"Pubmed Search/ESum Completed Successfully.");

                return allResponses;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searhcing pub med", ex);
                throw;
            }

        }

        public PubMedESummaryResponse PubMedESummary(PubMedESearchResponse idList)
        {
            Console.WriteLine($"Formating ESummary Post");

            string ids = _queryFormatter.FormatIdQueryString(idList.IdList);

            var response = _pubMedApiService.PostReturnXmlContent($"esummary.fcgi?db=pubmed&id={ids}&retmax={_settings.MaxReturnResults}&tool={_settings.ApplicationName}&email={_settings.DevEmail}");

            return new PubMedESummaryResponse()
            {
                Articles = _xmlParser.MapESummaryResponseToArticles(response)
            };
        }
    }
}
