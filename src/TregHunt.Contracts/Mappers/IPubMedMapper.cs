using System;
using System.Collections.Generic;
using System.Text;
using TregHunt.Contracts.Models;

namespace TregHunt.Contracts.Mappers
{
    //TODO: make this a generic mapper class
    public interface IPubMedMapper
    {
        IEnumerable<Article> Map(PubMedESearchResponse source);
    }
}
