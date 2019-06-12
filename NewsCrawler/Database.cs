using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data.Common; 
namespace NewsCrawler
{
    static class Database
    {
        static NpgsqlConnection npgSqlConnection;
        static string LoginServer; 
        static string PasswordServer;

        static public void SignIN(string Login, string Password)
        {
            LoginServer = Login;
            PasswordServer = Password; 
        }

        static public void AddNote(string TitleString, string ArticleString, string HtmlString, string urlString)
        {
            
            
            // NpgsqlCommand addNote = new NpgsqlCommand("insert into data (title, content) values ('" + TitleString + "','" + ArticleString + "');", npgSqlConnection);


            NpgsqlCommand addNote = new NpgsqlCommand("insert into datanews (title, content, url, html) values " +
                "($$" + TitleString + "$$,$$" + ArticleString + "$$,$$" + urlString + "$$,$$" + HtmlString + "$$);", npgSqlConnection);
            npgSqlConnection.Open();
            addNote.ExecuteNonQuery();
            npgSqlConnection.Close();
        

        }

        static public List<string> SearchNoteByTitle(string title)
        {
            List<string> ArticleList = new List<string> { };

            NpgsqlCommand command = new NpgsqlCommand("select title,content from datanews where " +
                "lower(title) like lower('%" + title + "%');", npgSqlConnection);    
            
            npgSqlConnection.Open();
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            if (npgsqlDataReader.HasRows)
            {
                foreach (DbDataRecord dbDataRecord in npgsqlDataReader)
                {
                    ArticleList.Add(dbDataRecord["title"] + "\n\n" + dbDataRecord["content"]);
                }
            }
            else
            {
                ArticleList.Add("Ничего не найдено");
            }
            npgSqlConnection.Close();
            return ArticleList;  
        }


        static public List<string> SearchNotesByKey(string keyword)
        {
            List<string> ArticleList = new List<string> { };

            NpgsqlCommand command = new NpgsqlCommand("select title,content from datanews where " +
                "lower(content) like lower('%" + keyword + "%');", npgSqlConnection);

            npgSqlConnection.Open();
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            if (npgsqlDataReader.HasRows)
            {
                foreach (DbDataRecord dbDataRecord in npgsqlDataReader)
                {
                    ArticleList.Add(dbDataRecord["title"] + "\n\n" + dbDataRecord["content"]);
                }
            }
            else
            {
                ArticleList.Add("Ничего не найдено");
            }
            npgSqlConnection.Close();
            return ArticleList;
        }

        static public List<string> ShowArticles()
        {
            List<string> ArticleList = new List<string> { };

            NpgsqlCommand command = new NpgsqlCommand("select title,content from datanews;", npgSqlConnection);

            npgSqlConnection.Open();
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            if (npgsqlDataReader.HasRows)
            {
                foreach (DbDataRecord dbDataRecord in npgsqlDataReader)
                {
                    ArticleList.Add(dbDataRecord["title"] + "\n\n" + dbDataRecord["content"]);
                }
            }
            else
            {
                ArticleList.Add("Ничего не найдено");
            }
            npgSqlConnection.Close();
            return ArticleList;
        }

        static public bool CheckForUnique(Uri url)
        {
            NpgsqlCommand command = new NpgsqlCommand("select url from datanews where url like '%"+url+"%';", npgSqlConnection);
            npgSqlConnection.Open();
            NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
            bool IsUnique = !npgsqlDataReader.HasRows;
            npgSqlConnection.Close();
            return IsUnique;
        }

    
    }
}
