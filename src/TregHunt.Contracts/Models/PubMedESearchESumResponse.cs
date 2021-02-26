using System;
using System.Collections.Generic;
using System.Text;

namespace TregHunt.Contracts.Models
{
    public class PubMedESearchESumResponse
    {
        private string PrimaryTerm;
        private string SecondaryTerm;
        public PubMedESearchESumResponse(string primaryTerm, string secondaryTerm)
        {
            PrimaryTerm = primaryTerm;
            SecondaryTerm = secondaryTerm;
        }
        public string SearchGrouping => $"{PrimaryTerm} + {SecondaryTerm}";
        public IEnumerable<string> Uids { get; set; }
        public IEnumerable<Article> Articles { get; set; }
    }
}
