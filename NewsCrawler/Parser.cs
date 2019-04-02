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
        public static void Parse(String parseString, Uri URLString)
        {
            String title, article;
            HtmlDocument Doc = new HtmlDocument();
            Doc.LoadHtml(parseString);


            title = FindTitle(Doc);
            article = FindArticle(Doc);

            
            
            Database.AddNote(title, article, parseString, URLString.ToString()); 
        }

        static String FindTitle(HtmlDocument Doc)
        {

            HtmlNode title = Doc.DocumentNode.SelectSingleNode("//h1[@class='title']");
            String TitleString;
            TitleString = title.InnerText;
            return TitleString; 
        }

        static String FindArticle(HtmlDocument Doc)
        {
            HtmlNodeCollection par = Doc.DocumentNode.SelectNodes("//p");
            String ArticleString = "";
            foreach (HtmlNode node in par)
            {
                ArticleString  += node.InnerText + "\n";
            }

            return ArticleString;
        }
    }
}
