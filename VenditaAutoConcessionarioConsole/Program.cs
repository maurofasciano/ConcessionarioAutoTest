using System;

using VenditaAutoConcessionarioConsole.Class;
using VenditaAutoConcessionarioConsole.Class.Base;
using VenditaAutoConcessionarioConsole.Methods;
using System.Data;
using System.Data.SqlClient;

namespace VenditaAutoConcessionarioConsole
{
    public class Program
    {


        static void Main(string[] args)
        {
        //    string connectionString = "Server=DAMAGE000\\SQLEXPRESS;Database=ConcessionarioAutoConsole;Integrated Security=true";

        //string queryString =
        //     @"SELECT [Id]
        //      ,[NomeCliente]
        //      ,[CognomeCliente]
        //      ,[TelefonoCliente]
        //      ,[MailCliente]
        //      ,[ClienteAttivo]
        //      ,[OraInserimento]
        //  FROM[dbo].[Clienti]";

        //    using (SqlConnection connection = new SqlConnection(
        //               connectionString))
        //    {
        //        SqlCommand command = new SqlCommand(
        //            queryString, connection);
        //        connection.Open();
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                Console.WriteLine(String.Format("{0}, {1} {2}",
        //                    reader[0], reader[1], reader[2]));
        //            }
        //        }
        //    }

            // bool passBlockCode = true;
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("- Seleziona il blocco su cui lavorare -");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("");
                Console.WriteLine();


                Console.WriteLine("1) Sezione Venditori");
                Console.WriteLine("2) Sezione Clienti");
                Console.WriteLine("3) Sezione Automezzi");
                Console.WriteLine("4) Esci dal Programma");

                string risposta = Console.ReadLine();

                bool rispostaUtente = int.TryParse(risposta, out int rispostaUtenteInt);

                Console.Clear();

                if (rispostaUtente == false)
                {
                    Console.Clear();

                    Console.WriteLine("");
                    Console.WriteLine("-----------------------------------------------");
                    Console.WriteLine("- Argomento non valido, Accetta SOLO interi ! -");
                    Console.WriteLine("-----------------------------------------------");

                    continue;

                }

                switch (rispostaUtenteInt)
                {

                    case 1:
                        ProgramMethods.VendorSelect();
                        break;

                    case 2:
                        ProgramMethods.CustomerSelect();
                        break;

                    case 3:

                        break;

                    case 4:
                        Console.WriteLine("");
                        Console.WriteLine("-----------------------------------------------------");
                        Console.WriteLine("- Hai selezionato QUIT, premi INVIO per chiudere ! - ");
                        Console.WriteLine("-----------------------------------------------------");
                        Console.WriteLine("");
                        Console.ReadLine();
                        Environment.Exit(0);
                        return; 


                    default:
                        CommonMethods.RichiestaNonValida();
                        break;

                }


            }   

        }
        

    }

}














