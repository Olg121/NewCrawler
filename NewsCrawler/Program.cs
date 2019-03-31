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
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection("Server=localhost;Port=5432;Username=postgres;Password=1122;Database=");
            try
            {
                npgSqlConnection.Open();
            }
            catch
            {
               // Создание базы данных 
               // Добавление таблицы 
            }
            finally
            {
                npgSqlConnection.Close(); 
            }

        }
    }
}
