using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Library2
{
    internal class Library
    {
        public static string connectionString = "";
        static SqlConnection connection = null;
        static readonly string delimetr1 = "\n------------------------";
        static readonly string delimetr2 = "\n========================";

        static  Library()
        { 
            connectionString = ConfigurationManager.ConnectionStrings["Library"].ConnectionString;
            connection = new SqlConnection(connectionString);
            Console.WriteLine(connectionString);
        }

        public static void Select(string filders, string tables, string condition="", int padding = 20)
        {
            string cmd = $"SELECT {filders} FROM {tables}";
            if (condition.Length > 0) cmd += $" WHERE {condition}";
            cmd += ";";
            SqlCommand command = new SqlCommand(cmd, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                Console.WriteLine(delimetr2);
                for(int i = 0; i < reader.FieldCount; i++) 
                    Console.Write(reader.GetName(i).PadRight(padding));
                Console.WriteLine(delimetr1);
                while (reader.Read())
                {
                    for(int i = 0; i < reader.FieldCount; i++)
                        Console.Write(reader[i].ToString().PadRight(padding));
                    Console.WriteLine();
                }
                Console.WriteLine(delimetr2);
            }
            reader.Close();
            connection.Close();
        }
    }
}
