using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace VenditaAutoConcessionarioConsole.Class.Base
{
    // Connessione a Sql 2019
    public class ConnectionStringSql
    {
        public string connectionString = "Server=DAMAGE003\\SQLEXPRESS;Database=ConcessionarioAutoTest;User Id=faggiano;Password=cippi1;";


        public  string GetConnectionString()
        {
            // To avoid storing the connection string in your code, 
            // you can retrieve it from a configuration file, using the 
            // System.Configuration.ConfigurationManager.ConnectionStrings property 
            return connectionString;

        }

        public SqlDataReader ExecuteQuerys(string query)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(
                query, connection);
                connection.Open();

                return command.ExecuteReader();
            }
        }

        public void ExecuteNotQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }   
}
   
