using System;
using System.Collections.Generic;
using System.Text;

namespace TregHunt.Contracts.Models
{
    public class Article
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public List<string> AuthorList { get; set; }
        public string Source { get; set; }
        public int PubDate { get; set; }
    }
}
