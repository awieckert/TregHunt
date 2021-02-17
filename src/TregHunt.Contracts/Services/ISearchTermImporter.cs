using System;
using System.Collections.Generic;
using System.Text;
using TregHunt.Contracts.Models;

namespace TregHunt.Contracts.Services
{
    public interface ISearchTermImporter
    {
        IEnumerable<PubMedQuery> Import(string filePath);
    }
}
