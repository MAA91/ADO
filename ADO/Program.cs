using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Console.WriteLine(connectionString);
            Console.WriteLine("\n------------------------------\n");

            SqlConnection connection = new SqlConnection(connectionString);

            string cmd_all_from_Authors = "SELECT * FROM Authors";
            SqlCommand command_all_from_Authors = new SqlCommand(cmd_all_from_Authors, connection);
            connection.Open();

            SqlDataReader reader_all_from_Authors = command_all_from_Authors.ExecuteReader();

            const int padding = 30;
            for (int i = 0; i < reader_all_from_Authors.FieldCount; i++) Console.Write(reader_all_from_Authors.GetName(i).PadRight(padding));
            Console.WriteLine();
            if (!reader_all_from_Authors.IsClosed)
            {
                while (reader_all_from_Authors.Read())
                {
                    for (int i = 0; i < reader_all_from_Authors.FieldCount; i++)
                        Console.Write(reader_all_from_Authors[i].ToString().PadRight(padding));
                    Console.WriteLine();
                }
            }
            reader_all_from_Authors.Close();
            Console.WriteLine("\n------------------------------\n");

            string cmd_all_from_Books = "SELECT * FROM Books";
            SqlCommand command_all_from_Books = new SqlCommand(cmd_all_from_Books, connection);

            SqlDataReader reader_all_from_Books = command_all_from_Books.ExecuteReader();

            for (int i = 0; i < reader_all_from_Books.FieldCount; i++) Console.Write(reader_all_from_Books.GetName(i).PadRight(padding));
            Console.WriteLine();
            if (!reader_all_from_Books.IsClosed)
            {
                while (reader_all_from_Books.Read())
                {
                    for (int i = 0; i < reader_all_from_Books.FieldCount; i++)
                        Console.Write(reader_all_from_Books[i].ToString().PadRight(padding));
                    Console.WriteLine();
                }
            }
            reader_all_from_Books.Close();
            Console.WriteLine("\n------------------------------\n");
            connection.Close();
        }
    }
}
