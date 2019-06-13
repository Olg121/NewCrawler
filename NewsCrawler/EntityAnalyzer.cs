using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EP.Ner;
namespace NewsCrawler
{
    static class EntityAnalyzer
    {
        public static void StartAnalyzer()
        {
            Sdk.Initialize();

            var articles = Database.GetArticleContent();
            var processor = ProcessorService.CreateProcessor();

            foreach(var article in articles)
            {
                AnalysisResult ar = processor.Process(new SourceOfAnalysis(article.Value));

                foreach (var e in ar.Entities)
                    if (e.TypeName == "PERSON")
                    {
                        Database.InsertName(e.ToString());
                        Database.InsertEntity(e.ToString(), article.Key);                        
                    }
            }
        }
    }
}
