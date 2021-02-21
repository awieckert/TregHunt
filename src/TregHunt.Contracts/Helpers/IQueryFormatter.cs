using System.Collections.Generic;
using TregHunt.Contracts.Models;

namespace TregHunt.Contracts.Helpers
{
    public interface IQueryFormatter
    {
        string FormatESearchQuery(PubMedQuery query);
        string FormatIdQueryString(IList<string> idList);
    }
}
