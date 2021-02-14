using System.Collections.Generic;
using TregHunt.Contracts.Models;
using TregHunt.Contracts.Services;
using TregHunt.Services.Settings;

namespace TregHunt.Services
{
    public class PubMedService : IPubMedService
    {
        readonly IPubMedApiService _pubMedApiService;
        readonly PubMedApiSettings _settings;

        public PubMedService(IPubMedApiService pubMedApiService, PubMedApiSettings settings) 
        {
            _pubMedApiService = pubMedApiService;
            _settings = settings;
        }

        public IEnumerable<PubMedESearchResponse> GetArticleUIDs(IEnumerable<PubMedQuery> pubMedQueries)
        {
            var allResponses = new List<PubMedESearchResponse>();

            foreach (var query in pubMedQueries)
            {
                var response = _pubMedApiService.Get<PubMedESearchResponse>($@"{query.Eutility}?db=pubmed&term={query.PrimaryTerm}+AND+{query.SecondaryTerm}&tool={_settings.ApplicationName}&email={_settings.DevEmail}");
            }

            return allResponses;
        }
    }
}
