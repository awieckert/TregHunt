using System.Collections.Generic;
using TregHunt.Contracts.Helpers;
using TregHunt.Contracts.Models;

namespace TregHunt.Services.Helpers
{
    public class QueryFormatter : IQueryFormatter
    {
        public string FormatESearchQuery(PubMedQuery query)
        {
            return $@"{query.Eutility}?db=pubmed&term={query.PrimaryTerm}+AND+{query.SecondaryTerm}&tool={_settings.ApplicationName}&email={_settings.DevEmail}";
        }

        public string FormatIdQueryString(IList<string> idList)
        {
            string ids = "";
            for (int i = 0; i < idList.Count; i++)
            {
                if ((i + 1) == idList.Count)
                {
                    ids += $"{idList[i]}";
                    continue;
                }

                ids += $"{idList[i]},";
            }

            return ids;
        }
    }
}
