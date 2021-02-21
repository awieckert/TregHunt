using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TregHunt.Contracts.Models
{
    public class PubMedESummaryResponse
    {
        public IEnumerable<Article> Articles { get; set; }
    }
}
