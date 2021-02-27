using System;
using System.Collections.Generic;
using System.Text;

namespace TregHunt.Contracts.Models
{
    public class FlatESearchESumResult
    {
        public string SearchTerms { get; set; }
        public string ArticleId { get; set; }
        public string Title { get; set; }
        public string Source { get; set; }
        public string PubDate { get; set; }
        public string Authors { get; set; }
    }
}
