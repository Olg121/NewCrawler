using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql; 


namespace NewsCrawler
{
    static class Program
    {

        // Тест парсера
      
            
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DBCreate(); 
            Application.Run(new Form1());
            Application.Run(new Form2());

        }
        static void DBCreate()
        {

            // нужно изменять пароль в строке коннекта, можно добавить в интерфейс
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection("Server=localhost;Port=5432;Username=postgres;Password=qwerty;Database=news");
            //  NpgsqlConnection npgSqlConnection = new NpgsqlConnection("Server=localhost;Port=5432;Username={0};Password={1};Database=news", login, passw);
            try
            {
                npgSqlConnection.Open();
            }
            catch
            {
                // создает дб с названием news, если ее нет
                npgSqlConnection = new NpgsqlConnection("Server=localhost;Port=5432;Username=postgres;Password=qwerty");
                // npgSqlConnection = new NpgsqlConnection("Server=localhost;Port=5432;Username={0};Password={1};", login, passw);
                NpgsqlCommand createDb = new NpgsqlCommand("create database news;", npgSqlConnection);
                npgSqlConnection.Open();       
                createDb.ExecuteNonQuery();
                npgSqlConnection.Close();

                // подключаемся к только что созданной бд news и создаем в ней таблицу data
                npgSqlConnection = new NpgsqlConnection("Server=localhost;Port=5432;Username=postgres;Password=qwerty;Database=news");
                // npgSqlConnection = new NpgsqlConnection("Server=localhost;Port=5432;Username={0};Password={1};Database=news", login, passw);
                NpgsqlCommand createTbl = new NpgsqlCommand("create table data (url varchar, title varchar, content text, html text);", npgSqlConnection);
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
