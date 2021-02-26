using System;
using System.Collections.Generic;
using System.Xml;
using TregHunt.Contracts.Models;
using TregHunt.Contracts.Helpers;

namespace TregHunt.Services.Services
{
    public class XmlParser : IXmlParser
    {
        public IEnumerable<Article> MapESummaryResponseToArticles(string xmlString)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);

            var docSums = xmlDoc.GetElementsByTagName("DocSum");

            var articles = new List<Article>();

            foreach (XmlNode docSum in docSums)
            {
                articles.Add(MapXmlNodesToArticle(docSum));
            }

            return articles;
        }

        private Article MapXmlNodesToArticle(XmlNode docSum)
        {
            var article = new Article();

            article.Id = docSum["Id"].InnerText;
            article.Title = docSum.SelectNodes("Item[@Name='Title']")[0].InnerText;
            article.PubDate = docSum.SelectNodes("Item[@Name='PubDate']")[0].InnerText;
            article.Source = docSum.SelectNodes("Item[@Name='Source']")[0].InnerText;

            var authorList = docSum.SelectNodes("Item[@Name='AuthorList']")[0].ChildNodes;
            var authors = new List<string>();
            
            for (int i = 0; i < authorList.Count; i++)
            {
                authors.Add(authorList[i].InnerText);
            }

            article.Authors = authors;

            return article;

        }
    }
}
