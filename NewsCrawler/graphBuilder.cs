using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Common;
using System.Configuration;
using Npgsql;
namespace NewsCrawler
{
    class graphBuilder
    {
        static protected List<graph> Graph; 
        private static string connectionString;
        private static List<string> Names;
        public graphBuilder()
        {
           Names = new List<string>();
           connectionString = "Server = localhost; Port = 5432; Username = postgres; Password = 12qwasZX; Database = news";

        }

        private static NpgsqlConnection GetConnection()
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            return connection;
        }


        private static int isInString(string name)
        {
            for (int i = 0; i < Names.Count; i++)
            {
                if (Names[i] == name)
                    return i;
            }

            return -1;

        }

        private List<graph.pair> getRelations(string name, int n)
        {
            List<graph.pair> answer = new List<graph.pair>();
            graph.pair temp;
            List<string> URLs = new List<string>();
            List<string> humans = new List<string>();
            using (NpgsqlConnection connection = GetConnection())
            {
                NpgsqlCommand command = new NpgsqlCommand("select url from person where name = '"  + name + "'" , connection);
            



                NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
                if (npgsqlDataReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in npgsqlDataReader)
                    {
                        URLs.Add(dbDataRecord["url"].ToString());
                    }
                }
            }

         
                

                foreach (string e in URLs)
                {
                using (NpgsqlConnection connection = GetConnection())
                {
                    NpgsqlDataReader npgsqlDataReader;

                    NpgsqlCommand select = new NpgsqlCommand("select name from person where url = '" + e +"'", connection);
    
                    npgsqlDataReader = select.ExecuteReader();
                    if (npgsqlDataReader.HasRows)
                    {
                        foreach (DbDataRecord dbDataRecord in npgsqlDataReader)
                        {
                            if (!humans.Contains(dbDataRecord["name"].ToString()))
                                humans.Add(dbDataRecord["name"].ToString());
                            if (isInString(dbDataRecord["name"].ToString()) < 0)
                                Names.Add(dbDataRecord["name"].ToString());
                        }
                    }
                }
                }

                int k;
                for (int i = 0; i < humans.Count; i++)
                {
                    k = isInString(humans[i]);
                    temp.name = humans[i];
                    temp.iName = k;
                    temp.relation = "url";
                answer.Add(temp); 

                }

                return answer;
            
        }

       
        public struct graph
        {
           public struct pair 
                {
               public string relation;
               public string name;
               public int iName; 
                }
            public int depth;
            public string name;
            public string ancestorRelation; 
            public int iancestor;
            public List<pair> contacts; 
        }  

        private List<graph> CreateGraph(string name)
        {
            Graph = new List<graph>();
            graph temp;
            temp.name = name;
            temp.depth = 0;
            temp.ancestorRelation = "-";
            temp.iancestor = -1;
            temp.contacts = getRelations(name, 0);
            Graph.Add(temp); 
            int i = 0;

            do
            {

                if (Graph[i].depth < 1)
                {
                    for (int j = 0; j < Graph[i].contacts.Count; j++)
                        if (Graph[i].contacts[j].iName >= Graph.Count)
                        {
                            temp.depth = Graph[i].depth + 1;
                            temp.ancestorRelation = Graph[i].contacts[j].relation;
                            temp.iancestor = i;
                            temp.name = Graph[i].contacts[j].name;
                            temp.contacts = getRelations(temp.name, Graph.Count - 1);
                            Graph.Add(temp);
                        }
                }

                i++;
            }
            while (i < Graph.Count);


                return null; 

        }
        public List<graph> GetGraph(string name)
        {
            CreateGraph(name); 
            return Graph;  
        }


    }
}
