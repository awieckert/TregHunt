using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TregHunt.Contracts.Models
{
    public class Article
    {
        public string Id { get; set; }
        public List<string> Authors { get; set; }
        public string Title { get; set; }
        public string Source { get; set; }
        public string PubDate { get; set; }
    }
}
