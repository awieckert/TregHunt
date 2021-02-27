using System.Collections.Generic;
using TregHunt.Contracts.Helpers;
using TregHunt.Contracts.Models;
using TregHunt.Services.Settings;

namespace TregHunt.Services.Helpers
{
    public class QueryFormatter : IQueryFormatter
    {
        readonly PubMedApiSettings _settings;

        public QueryFormatter(PubMedApiSettings settings)
        {
            _settings = settings;
        }
        public string FormatESearchQuery(PubMedQuery query)
        {
            var strictSearch = query.StrictSearch ? "%22" : "";

            return $@"{query.Eutility}?db=pubmed&term={strictSearch}{query.PrimaryTerm}{strictSearch}+AND+{query.SecondaryTerm}&retmax={_settings.MaxReturnResults}&tool={_settings.ApplicationName}&email={_settings.DevEmail}";
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
