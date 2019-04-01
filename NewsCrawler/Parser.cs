using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 
namespace NewsCrawler
{
    static class Parser
    {
        public static void Parse(String parseString)
        {
            String title, article, html, url;
            using (StreamWriter sw = new StreamWriter("Out.txt", false, System.Text.Encoding.Default))
            {
                sw.WriteLine(parseString);
            }
            title = FindTitle();
            article = FindArticle();
            html = GetHtml();
            url = GetUrl();

            Database.AddNote(title, article, html, url); 
        }

        static String FindTitle()
        {

            return (" "); 
        }

        static String FindArticle()
        {

            return (" "); 
        }

        static String GetUrl()
        {
            return null;
        }

        static String GetHtml()
        {
            return null;
        }

    }
}
