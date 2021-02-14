using System;
using System.Collections.Generic;
using System.Text;

namespace TregHunt.Contracts.Models
{
    public class PubMedESearchResponse
    {
        public IEnumerable<string> IdList { get; set; }
    }
}
