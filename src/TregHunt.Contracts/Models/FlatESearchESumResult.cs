using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TregHunt.Contracts.Models
{
    public class FlatESearchESumResult : IEquatable<FlatESearchESumResult>
    {
        public string SearchTerms { get; set; }
        public string ArticleId { get; set; }
        public string Title { get; set; }
        public string Source { get; set; }
        public string PubDate { get; set; }
        public string Authors { get; set; }

        public bool Equals(FlatESearchESumResult other)
        {
            if (ReferenceEquals(other, null)) return false;

            if (ReferenceEquals(this, other)) return true;

            return ArticleId.Equals(other.ArticleId);
        }

        public override int GetHashCode()
        {
            int hashArticleId = ArticleId == null ? 0 : ArticleId.GetHashCode();

            return hashArticleId;
        }
    }
}
