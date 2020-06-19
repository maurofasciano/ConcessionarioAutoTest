using System;
using System.Collections.Generic;
using System.Text;

namespace VenditaAutoConcessionarioConsole.Class.Base
{
    public static class CommonMethods
    {
        /// <summary>
        /// Medoto comune, chiamato quando l' utente usa numero non valido della select. ./Class/Base/Commonx.cs
        /// </summary>
        public static void RichiestaNonValida()

        {
            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("- Richiesta NON VALIDA ! Accetta SOLO selezioni indicate! -");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("");

        }

        public static List<Venditori> DbVendorsReader(string whereCondition)
        {
            ConnectionStringSql dataBase = new ConnectionStringSql();

            List<Venditori> lista = new List<Venditori>();

            string query = @"SELECT [Id]
                ,[NomeVenditore]
                ,[CognomeVenditore] 
                ,[TelefonoVenditore]
                ,[MailVenditore]
                ,[VenditoreAttivo]
                ,[OraInserimento]
                FROM [dbo].[Venditori] ";

            if (!String.IsNullOrEmpty(whereCondition))
                query += whereCondition;

            using (var reader = dataBase.ExecuteQuerys(query))
            {
                while (reader.Read())
                {
                    /* Passo una nuova istanza della classe Venditori ed eseguo i tryparse per la conversione in stringa */
                    lista.Add(new Venditori()
                    {
                        Id = Int32.Parse(reader["Id"].ToString()),
                        NomeVenditore = reader["NomeVenditore"].ToString(),
                        CognomeVenditore = reader["CognomeVenditore"].ToString(),
                        TelefonoVenditore = reader["TelefonoVenditore"].ToString(),
                        MailVenditore = reader["MailVenditore"].ToString(),
                        VenditoreAttivo = Boolean.Parse(reader["VenditoreAttivo"].ToString()),
                        OraInserimento = reader["OraInserimento"].ToString()
                    });

                }
            }

            dataBase.Dispose();

            return lista;

        }

        public static List<Clienti> DbCustomersReader(string whereCondition, Clienti c)
        {
            ConnectionStringSql dataBase = new ConnectionStringSql();

            List<Clienti> lista = new List<Clienti>();

            string query = @"SELECT[Id]
                        ,[NomeCliente]
                        ,[CognomeCliente]
                        ,[TelefonoCliente]
                        ,[MailCliente]
                        ,[ClienteAttivo]
                        ,[OraInserimento]
                        FROM[dbo].[Clienti]";                       

            if (!String.IsNullOrEmpty(whereCondition))
                query += whereCondition;

            using(var reader = dataBase.ExecuteQuerys(query))
            {
                while (reader.Read())
                {
                    c.Id = Int32.Parse(reader["Id"].ToString());
                    c.NomeCliente = reader["NomeCliente"].ToString();
                    c.CognomeCliente = reader["CognomeCliente"].ToString();
                    c.TelefonoCliente = reader["TelefonoCliente"].ToString();
                    c.MailCliente = reader["MailCliente"].ToString();
                    c.ClienteAttivo = Boolean.Parse(reader["ClienteAttivo"].ToString());
                    c.OraInserimento = reader["OraInserimento"].ToString();

                }

            }

            dataBase.Dispose();
            return lista;

        }

        public static void DbVendorUpDater(string whereCondition, Venditori v)
        {
            ConnectionStringSql database = new ConnectionStringSql();

            string query = $"UPDATE[dbo].[Venditori]" +
                        "SET [NomeVenditore] = '" + v.NomeVenditore + "'" +
                        ",[CognomeVenditore] = '" + v.CognomeVenditore + "'" +
                        ",[TelefonoVenditore] = '" + v.TelefonoVenditore + "'" +
                        ",[MailVenditore] = '" + v.MailVenditore + "'" +
                        ",[VenditoreAttivo] = '" + v.VenditoreAttivo + "'";


            if (!String.IsNullOrEmpty(whereCondition))
                query += whereCondition;

            database.ExecuteNotQuery(query);
            database.Dispose();

        }

        public static void DbCustomersUpDater(string whereCondition, Clienti c)
        {

            ConnectionStringSql dataBase = new ConnectionStringSql();

            string query = $"UPDATE [dbo].[Clienti]" + 
                "SET [NomeCliente] = '" + c.NomeCliente + "'" +
                ",[CognomeCliente] = '" + c.CognomeCliente + "'" +
                ",[TelefonoCliente] = '" + c.TelefonoCliente + "'" +
                ",[MailCliente] = '" + c.MailCliente + "'" +
                ",[ClienteAttivo] = '" + c.ClienteAttivo + "'";

            if (!String.IsNullOrEmpty(whereCondition))
                query += whereCondition;

            

            dataBase.ExecuteNotQuery(query);

            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("I Nuovi dati del Venditore Modificato sono :");
            Console.WriteLine("");
            Console.WriteLine($"Id - {c.Id} | Nome - {c.NomeCliente} |  Cognome  -  {c.CognomeCliente} ");
            Console.WriteLine($"Telefono - {c.TelefonoCliente} | Mail - {c.MailCliente}");
            Console.WriteLine($"Venditore Aggiunto il -  {c.OraInserimento}  |  Il Venditore è " + (c.ClienteAttivo == true ? " Attivo " : " Disattivo"));
            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------------------------------------------------");

            Console.ReadLine();

            dataBase.Dispose();

        }

        public static void DbVendorDeleter(string whereCondition)

        {
            ConnectionStringSql database = new ConnectionStringSql();

            string query = $"delete from dbo.Venditori ";

            if (!String.IsNullOrEmpty(whereCondition))
                query += whereCondition;

            database.ExecuteNotQuery(query);
            database.Dispose();

        }

        public static void DbCustomerDeleter(string whereCondition)
        {
            ConnectionStringSql dataBase = new ConnectionStringSql();
            string query = $"DELETE from dbo.Venditori";

            if (!String.IsNullOrEmpty(query))
                query += whereCondition;
            dataBase.ExecuteNotQuery(query);
            dataBase.Dispose();

        }
    }


}
