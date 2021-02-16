using System;
using System.Collections.Generic;
using System.Text;

namespace TregHunt.Contracts.Models
{
    public class Articles
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public IList<string> Authors { get; set; }
        public string Journal { get; set; }
        public int Year { get; set; }
    }
}
