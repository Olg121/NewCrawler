using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HtmlAgilityPack; 

namespace NewsCrawler
{
    static class Parser
    {
        public static void Parse(string parseString, Uri URLString)
        {
            string title, article;
            HtmlDocument Doc = new HtmlDocument();
            Doc.LoadHtml(parseString);


            title = FindTitle(Doc);
            article = FindArticle(Doc);
            if (Database.CheckForUnique(URLString))
                Database.AddNote(title, article, parseString, URLString.ToString()); 
        }

        static string FindTitle(HtmlDocument Doc)
        {

            HtmlNode title = Doc.DocumentNode.SelectSingleNode("//h1[@class='title']");
            string TitleString;
            TitleString = title.InnerText;                      
            return TitleString; 
        }

        static string FindArticle(HtmlDocument Doc)
        {
            HtmlNodeCollection par = Doc.DocumentNode.SelectNodes("//p");
            string ArticleString = "";
            foreach (HtmlNode node in par)
            {
                ArticleString  += node.InnerText + "\n";
            }

            return ArticleString;
        }
    }
}
