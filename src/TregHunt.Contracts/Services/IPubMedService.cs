using System.Collections.Generic;
using TregHunt.Contracts.Models;

namespace TregHunt.Contracts.Services
{
    public interface IPubMedService
    {
        IEnumerable<PubMedESearchESumResponse> PubMedESearch(IEnumerable<PubMedQuery> pubMedQueries);
    }
}
