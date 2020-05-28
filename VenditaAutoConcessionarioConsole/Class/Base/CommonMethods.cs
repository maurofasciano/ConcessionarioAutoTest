using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;

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

            return lista;

        }

    }
}
