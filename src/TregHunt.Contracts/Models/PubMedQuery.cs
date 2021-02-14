using System;
using System.Collections.Generic;
using System.Text;

namespace TregHunt.Contracts.Models
{
    public class PubMedQuery
    {
        public string PrimaryTerm { get; set; }
        public string SecondaryTerm { get; set; }
        public bool StrictSearch { get; set; }
    }
}
