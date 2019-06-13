using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data.Common;
using ServiceStack.OrmLite;
using System.Data;
namespace NewsCrawler
{
    static public class Database
    {
        //static NpgsqlConnection npgSqlConnection;
        //static string LoginServer; 
        //static string PasswordServer;
        static OrmLiteConnectionFactory Factory = new OrmLiteConnectionFactory("Server=localhost;Port=5432;Database=mainDb;Username=postgres;Password=qwerty;", PostgreSqlDialect.Provider);

        //static public void SignIN(string Login, string Password)
        //{
        //    LoginServer = Login;
        //    PasswordServer = Password; 
        //}

        static public void AddNote(string TitleString, string ArticleString, string HtmlString, string urlString)
        {
            using (IDbConnection db = Factory.Open())
            {
                try
                {
                    db.Insert(new Note { Title = TitleString, Article = ArticleString, Html = HtmlString, Url = urlString });
                }
                catch
                {
                    
                }
            }
        }

        static public List<string> SearchNoteByTitle(string title)
        {
            List<string> ArticleList = new List<string> { };        
            using (IDbConnection db = Factory.Open())
            {
                var results = db.Select<Note>(x => x.Title.Contains(title));
                if (results.Count != 0)
                {
                    foreach (var res in results)
                    {
                        ArticleList.Add($"{res.Title}\n\n{res.Article})");
                    }
                }
                else
                {
                    ArticleList.Add("Ничего не найдено");
                }
                

            }
                return ArticleList;  
        }


        static public List<string> SearchNotesByKey(string keyword)
        {
            List<string> ArticleList = new List<string> { };
            using (IDbConnection db = Factory.Open())
            {
                var results = db.Select<Note>(x => x.Article.Contains(keyword));
                if (results.Count != 0)
                {
                    foreach (var res in results)
                    {
                        ArticleList.Add($"{res.Title}\n\n{res.Article})");
                    }
                }
                else
                {
                    ArticleList.Add("Ничего не найдено");
                }
            }
            return ArticleList;
        }

        static public List<string> ShowArticles()
        {
            List<string> ArticleList = new List<string> { };
            using (IDbConnection db = Factory.Open())
            {
                var results = db.Select<Note>();
                if (results.Count != 0)
                {
                    foreach (var res in results)
                    {
                        ArticleList.Add($"{res.Title}\n\n{res.Article})");
                    }
                }
                else
                {
                    ArticleList.Add("Ничего не найдено");
                }


            }
            return ArticleList;
        }
        static public void CreateTable<T>()
        {
            using (IDbConnection db = Factory.Open())
            {
                db.DropAndCreateTable<T>();
            }
        }


        static public Dictionary<string, string> GetArticleContent()
        {
            var Articles = new Dictionary<string, string>();            
            using (IDbConnection db = Factory.Open())
            {
                var res = db.Select<Note>();
                foreach (var note in res)
                    Articles.Add(note.Url, note.Article);                    
            }
            return Articles;
            
        }

        static public void InsertEntity(string fullName, string url)
        {
            using (IDbConnection db = Factory.Open())
            {
                //db.CreateTableIfNotExists<Entity>();
                db.Insert<Entity>(new Entity { FullName = fullName, Url = url });
            }
        }

        static public void InsertName(string fullName)
        {
            using (IDbConnection db = Factory.Open())
            {
                db.CreateTableIfNotExists<Name>();
                try
                {
                    db.Insert<Name>(new Name { FullName = fullName });
                }
                catch
                {
                    
                }
            }
        }

        static public List<string> GetNames()
        {
            var list = new List<string>();
            using (IDbConnection db = Factory.Open())
            {
                var res = db.Select<Name>();
                foreach (var name in res)
                    list.Add(name.FullName);
            }
            return list;
        }

        static public List<string> GetNamesByUrl (string url)
        {
            var list = new List<string>();
            using (IDbConnection db = Factory.Open())
            {
                var res = db.Select<Entity>(x => x.Url == url);
                foreach (var name in res)
                    list.Add(name.FullName);
            }
            return list;
        }

        static public List<string> GetUrlsByName (string name)
        {
            var list = new List<string>();
            using (IDbConnection db = Factory.Open())
            {
                var res = db.Select<Entity>(x => x.FullName == name);
                foreach (var url in res)
                    list.Add(url.Url);
            }
            return list;
        }
    }
}
