using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsCrawler
{
    class Parser
    {
        public static void Parse(String parseString)
        {
            String title;
            String article;

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
