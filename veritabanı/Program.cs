using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace veritabanı
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // The connection string assumes that the Access
            // Northwind.mdb is located in the c:\Data folder.
            string connectionString =
            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                + "c:\\user\\Dell\\Documents\\Database1.accdb ;User Id=admin;Password=;";

            // Provide the query string with a parameter placeholder.
            string queryString =
                "SELECT Alan1 from Tablo1 ;";

            // Specify the parameter value.
            //int paramValue = 5;

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (OleDbConnection connection =
                new OleDbConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                OleDbCommand command = new OleDbCommand(queryString, connection);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}",
                            reader[0]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
