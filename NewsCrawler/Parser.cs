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
            if (title == "empty") return;
            article = FindArticle(Doc);
            if (title == "empty") return;
            //if (Database.CheckForUnique(URLString))
            //    Database.AddNote(title, article, parseString, URLString.ToString());
            Database.AddNote(title, article, parseString, URLString.ToString());
        }

        static string FindTitle(HtmlDocument Doc)
        {

            HtmlNode title = Doc.DocumentNode.SelectSingleNode("//h1[@class='name']");
            string TitleString;
            if (title != null)
                TitleString = title.InnerText;
            else
                TitleString = "empty";
            return TitleString; 
        }

        static string FindArticle(HtmlDocument Doc)
        {
            HtmlNodeCollection par = Doc.DocumentNode.SelectNodes("//div[@class='detail_text']");
            string ArticleString = "";

           if(par == null)
            {
                ArticleString = "Empty";
                return ArticleString; 
            }
            foreach (HtmlNode node in par)
            {
                ArticleString  += node.InnerText + "\n";
            }

            return ArticleString;
        }
    }
}
