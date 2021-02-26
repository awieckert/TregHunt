using System.Collections.Generic;
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
            var allResponses = new List<PubMedESearchESumResponse>();

            foreach (var query in pubMedQueries)
            {
                var response = _pubMedApiService.Get<PubMedESearchResponse>(_queryFormatter.FormatESearchQuery(query));

                var postResponse = PubMedESummary(response);

                var fullSearchResult = new PubMedESearchESumResponse(query.PrimaryTerm, query.SecondaryTerm)
                {
                    Uids = response.IdList,
                    Articles = postResponse.Articles
                };

                allResponses.Add(fullSearchResult);
                Thread.Sleep(200);
            }

            return allResponses;
        }

        public PubMedESummaryResponse PubMedESummary(PubMedESearchResponse idList)
        {
            string ids = _queryFormatter.FormatIdQueryString(idList.IdList);

            var response = _pubMedApiService.PostReturnXmlContent($"esummary.fcgi?db=pubmed&id={ids}&tool={_settings.ApplicationName}&email={_settings.DevEmail}");

            return new PubMedESummaryResponse()
            {
                Articles = _xmlParser.MapESummaryResponseToArticles(response)
            };
        }
    }
}
