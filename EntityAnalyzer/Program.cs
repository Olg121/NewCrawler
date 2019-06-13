using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAnalyzer
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Console.WriteLine("Initilizing...\n");
            EP.Ner.Sdk.Initialize();
            EP.Ner.Repository.RepositoryBase rep = new EP.Ner.Repository.RepositoryBase();
            rep.Initialize();
            int id = 0;
            var articles = NewsCrawler.Database.GetArticleContent("лукашенко");
            foreach (var article in articles)
            {
                string text = article.Article;

                EP.Ner.AnalysisResult ar = rep.Processor.Process(new EP.Ner.SourceOfAnalysis(text));

                Dictionary<int, string> inputList = new Dictionary<int, string>();

                foreach (var e in ar.Entities)                    
                    inputList.Add(id++, e.ToString());

                foreach (var i in inputList)
                    Console.WriteLine($"Entity {i.Value} -> Id={i.Key}");
                Console.WriteLine();
            }

            rep.Deinitialize();
            
            Console.ReadKey();
        }
    }
}
