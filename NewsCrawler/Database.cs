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
        static String LoginServer; 
        static String PasswordServer;

        static public void SignIN(String Login, String Password)
        {
            LoginServer = Login;
            PasswordServer = Password; 
        }

        static public void AddNote(String TitleString, String ArticleString, String HtmlString, String urlString)
        {
            
            
            // NpgsqlCommand addNote = new NpgsqlCommand("insert into data (title, content) values ('" + TitleString + "','" + ArticleString + "');", npgSqlConnection);


            NpgsqlCommand addNote = new NpgsqlCommand("insert into datanews (title, content, url, html) values " +
                "('" + TitleString + "','" + ArticleString + "','" + urlString + "',$$" + HtmlString + "$$);", npgSqlConnection);
            npgSqlConnection.Open();
            addNote.ExecuteNonQuery();
            npgSqlConnection.Close();
        

        }

        static public string[] SearchNoteByLabel()
        {
            string[] ArticleList = { };

            return ArticleList;  
        }

        static public string[] SearchNotesByKey()
        {
            string[] ArticleList = { };

            return ArticleList; 
        }

        static public string[] ShowArticles()
        {
            string[] ArticleList = { };

            

            return ArticleList; 
        }
        static public void DBCreate()
        {

            // нужно изменять пароль в строке коннекта, можно добавить в интерфейс
            npgSqlConnection = new NpgsqlConnection("Server=localhost;Port=5432;Username=" + LoginServer + ";Password=" + PasswordServer + ";Database=news");
            try
            {
                npgSqlConnection.Open();
                npgSqlConnection.Close();
            }
            catch
            {
                // создает дб с названием news, если ее нет
                npgSqlConnection = new NpgsqlConnection("Server=localhost;Port=5432;Username=" + LoginServer +  ";Password=" + PasswordServer);
                NpgsqlCommand createDb = new NpgsqlCommand("create database news;", npgSqlConnection);
                npgSqlConnection.Open();
                createDb.ExecuteNonQuery();
                npgSqlConnection.Close();

                // подключаемся к только что созданной бд news и создаем в ней таблицу data
                npgSqlConnection = new NpgsqlConnection("Server=localhost;Port=5432;Username=" + LoginServer + ";Password=" + PasswordServer + ";Database=news");

                NpgsqlCommand createTbl = new NpgsqlCommand("create table datanews (url varchar, title varchar, content text, html text);", npgSqlConnection);
                npgSqlConnection.Open();
                createTbl.ExecuteNonQuery();
                npgSqlConnection.Close();


            }
            finally
            {
               npgSqlConnection.Close();
            }

        }

    }
}
