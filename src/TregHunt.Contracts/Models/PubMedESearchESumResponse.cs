using System;
using System.Collections.Generic;
using System.Text;

namespace TregHunt.Contracts.Models
{
    public class PubMedESearchESumResponse
    {
        public string PrimaryTerm { get; set; }
        public string SecondaryTerm { get; set; }
        public IEnumerable<string> Uids { get; set; }
        public IEnumerable<Article> Articles { get; set; }
    }
}
