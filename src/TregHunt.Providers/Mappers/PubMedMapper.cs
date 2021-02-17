using System;
using System.Collections.Generic;
using TregHunt.Contracts.Mappers;
using TregHunt.Contracts.Models;

namespace TregHunt.Services.Mappers
{
    public class PubMedMapper : IPubMedMapper
    {
        public IEnumerable<Article> Map(PubMedESearchResponse source)
        {
            var articles = new List<Article>();
            foreach (var id in source.IdList)
            {
                Int64 parsedId;
                Int64.TryParse(id, out parsedId);

                articles.Add(new Article { Id = parsedId });
            }

            return articles;
        }
    }
}
