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
    static class Database
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
                db.Insert(new Note { Title = TitleString, Article = ArticleString, Html = HtmlString, Url = urlString });
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
        static public void CreateTable()
        {
            using (IDbConnection db = Factory.Open())
            {
                db.DropAndCreateTable<Note>();
            }
        }

    }
}
