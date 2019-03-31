using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 
namespace NewsCrawler
{
    class Parser
    {
        public static void Parse(String parseString)
        {
            String title;
            String article;
            using (StreamWriter sw = new StreamWriter("Out.txt", false, System.Text.Encoding.Default))
            {
                sw.WriteLine(parseString);
            }
            title = FindTitle();
            article = FindArticle();

            Database.AddNote(title, article); 
        }

        static String FindTitle()
        {

            return (" "); 
        }

        static String FindArticle()
        {

            return (" "); 
        }

    }
}
