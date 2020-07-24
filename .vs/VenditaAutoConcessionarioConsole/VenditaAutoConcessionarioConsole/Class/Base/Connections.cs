using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace VenditaAutoConcessionarioConsole.Class.Base
{
    // Connessione a Sql 2019
    public class ConnectionStringSql : IDisposable
    {
        public string connectionString = "Server=DAMAGE003\\SQLEXPRESS;Database=ConcessionarioAutoTest;User Id=faggiano;Password=cippi1;";
        SqlConnection connection = null;

        public string GetConnectionString()
        {
            // To avoid storing the connection string in your code, 
            // you can retrieve it from a configuration file, using the 
            // System.Configuration.ConfigurationManager.ConnectionStrings property 
            return connectionString;

        }

        public SqlDataReader ExecuteQuerys(string query)
        {
            connection = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            return command.ExecuteReader();
        }

        public void ExecuteNotQuery(string query)
        {
            using (connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public void ConnectionClose()
        {
            connection.Close();
        }

        public void Dispose()
        {

        }



        // Esempio di stringa connessione con query di lettura

        /* string connectionString = "Server=DAMAGE000\\SQLEXPRESS;Database=ConcessionarioAutoConsole;Integrated Security=true";

        string queryString =
             @"SELECT [Id]
              ,[NomeCliente]
              ,[CognomeCliente]
              ,[TelefonoCliente]
              ,[MailCliente]
              ,[ClienteAttivo]
              ,[OraInserimento]
          FROM[dbo].[Clienti]";

            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
    connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}, {1} {2}",
                            reader[0], reader[1], reader[2]));
                    }
                }
            }   */

    }


    public class ConnectionStringSql2 : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException()
            {


            };
        }
    }


}
   
