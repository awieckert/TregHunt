using System.Collections.Generic;
using TregHunt.Contracts.Models;

namespace TregHunt.Contracts.Services
{
    public interface IPubMedService
    {
        IEnumerable<PubMedESearchResponse> GetArticleUIDs(IEnumerable<PubMedQuery> pubMedQueries);
    }
}
