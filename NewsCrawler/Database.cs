using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data.Common; 
namespace NewsCrawler
{
    class Database
    {
       
       static NpgsqlConnection npgSqlConnection = new NpgsqlConnection("Server=localhost;Port=5432;Username=postgres;Password=1;Database=cyberforum;");


        static public void AddNote(string TitleString, string ArticleString)
        {
        npgSqlConnection.Open();
        

        }



        static public string SearchNote()
        {

            return " "; 
        }
    
    }
}
