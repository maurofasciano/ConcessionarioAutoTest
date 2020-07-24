using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VenditaAutoConcessionarioConsole.Class;
using VenditaAutoConcessionarioConsole.Class.Base;

namespace VenditaAutoConcessionarioConsole.Methods
{
    public class VeicoliMethods 
    {
        public static Veicoli InserisciVeicolo()
        {
            Veicoli veicolo = new Veicoli();

            int maxId = 0;
            ConnectionStringSql database = new ConnectionStringSql();
            using (var reader = database.ExecuteQuerys("SELECT ISNULL(max(Id),0) as maxId FROM Veicoli "))
            {
                while (reader.Read())
                {
                    maxId = Int32.Parse(reader[maxId].ToString());
                }
            };

            veicolo.Id = maxId + 1;

            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("- Inserisci la tipologia del veicolo : -");
            Console.WriteLine("--------(Auto, Moto, Furgone)-----------");
            Console.WriteLine("----------------------------------------");

            veicolo.TipoVeicolo = Console.ReadLine();

            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("- Inserisci la Marca ed il Modello del Veicolo : -");
            Console.WriteLine("--(Es: Ford, Transit / Alfa Romeo, Giulietta)-----");
            Console.WriteLine("--------------------------------------------------");
            
            veicolo.MarcaModello = Console.ReadLine();

            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("- Se immatricolata inserisci la Data -: -");
            Console.WriteLine("----------(Formato DateTime)-------------");
            Console.WriteLine("-----------------------------------------");

            veicolo.DataImmatricolazione = Console.ReadLine.ToString();

            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("- Inserisci la Mail del Venditore : -");
            Console.WriteLine("-------------------------------------");
            v.MailVenditore = Console.ReadLine();


            /* Un venditore è di default attivo, poi dovrò inabilitarlo creando un metodo apposito */
            v.VenditoreAttivo = true;


            /* Aggiunto metodo per inserimento ora di registrazione */
            v.OraInserimento = DateTime.Now.ToString();




            return veicolo;
     
        }
    } 
}
