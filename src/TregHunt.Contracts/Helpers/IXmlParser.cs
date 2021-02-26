using System;
using System.Collections.Generic;
using System.Text;
using TregHunt.Contracts.Models;

namespace TregHunt.Contracts.Helpers
{
    public interface IXmlParser
    {
        IEnumerable<Article> MapESummaryResponseToArticles(string xmlString);
    }
}
