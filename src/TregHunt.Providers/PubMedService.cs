using System.Collections.Generic;
using TregHunt.Contracts.Mappers;
using TregHunt.Contracts.Models;
using TregHunt.Contracts.Services;
using TregHunt.Services.Settings;

namespace TregHunt.Services
{
    public class PubMedService : IPubMedService
    {
        readonly IPubMedApiService _pubMedApiService;
        readonly PubMedApiSettings _settings;
        readonly IPubMedMapper _mapper;

        public PubMedService(IPubMedApiService pubMedApiService, PubMedApiSettings settings, IPubMedMapper mapper) 
        {
            _pubMedApiService = pubMedApiService;
            _settings = settings;
            _mapper = mapper;
        }

        public IEnumerable<PubMedESearchResponse> PubMedESearch(IEnumerable<PubMedQuery> pubMedQueries)
        {
            var allResponses = new List<PubMedESearchResponse>();

            foreach (var query in pubMedQueries)
            {
                //TODO: Extract out the query string building, this way we can have any number of search terms
                var response = _pubMedApiService.Get<PubMedESearchResponse>($@"{query.Eutility}?db=pubmed&term={query.PrimaryTerm}+AND+{query.SecondaryTerm}&tool={_settings.ApplicationName}&email={_settings.DevEmail}");

                var mappedResponse = _mapper.Map(response);

            }

            return allResponses;
        }

        public IEnumerable<Article> PubMedESummary(IEnumerable<string> ids)
        {

        }
    }
}
