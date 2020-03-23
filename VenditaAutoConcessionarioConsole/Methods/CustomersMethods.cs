using System;
using System.Collections.Generic;
using System.Text;
using VenditaAutoConcessionarioConsole.Class;
using VenditaAutoConcessionarioConsole.Class.Liste;

namespace VenditaAutoConcessionarioConsole.Methods
{
    class CustomersMethods
    {

        public static Clienti RegistraClienti()
        {     

            Clienti c = new Clienti();

            if(c != null && Liste.Clienti.Count > 0)
            {
                int maxId = Liste.Clienti[0].Id;

                for (int i = 1; i < Liste.Clienti.Count; i++)
                {
                    if (maxId < Liste.Clienti[i].Id)
                    {
                        maxId = Liste.Clienti[i].Id + 1;
                    }

                }
                 
            }

            Liste.Clienti.Add(c);


            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("- Inserisci il Nome del Cliente  : -");
            Console.WriteLine("------------------------------------");


            c.NomeCliente = Console.ReadLine();

            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("- Inserisci il Cognome del Cliente : -");
            Console.WriteLine("--------------------------------------");


            c.CognomeCliente = Console.ReadLine();

            Console.Clear();


            Console.WriteLine();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("- Inserisci il Telefono del Cliente : -");
            Console.WriteLine("---------------------------------------");

            c.TelefonoCliente = Console.ReadLine();

            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("- Inserisci la Mail del Venditore : -");
            Console.WriteLine("-------------------------------------");

            c.MailCliente = Console.ReadLine();


            // Un venditore è di default attivo, poi dovrò inabilitarlo creando un metodo apposito
            c.ClienteAttivo = true;


            // Aggiunto metodo per inserimento ora di registrazione
            c.OraInserimento = DateTime.Now.ToString();


            // Aggiungo i valori delle proprietà alla lista Venditori, tramite metodo .Add
            Liste.Clienti.Add(c);

            Console.Clear();


            //Mostro ad output cosa ho inserito
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine($"- Hai inserito il venditore {c.NomeCliente} - {c.CognomeCliente} - Avente Id - {c.Id} - ");
            Console.WriteLine($"- Il telefono è : {c.TelefonoCliente} - La sua mail è : {c.MailCliente}");
            Console.WriteLine($"- Il Venditore è attivo dal : {c.OraInserimento}");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("");


            return c;

        }

        public static List<Clienti> ElencoClienti()
        {
            // Eseguo un ForEach per ciclare dalla lista i miei dati. A differenza del While che cicla un condizionale
            // e For che cicla una index, questo comando è dedicato alle liste.
            // Associa alla variabile "item", tramite il comando "in", la lista venditori e mostra in console cosa contengono

            foreach (var item in Liste.Clienti)
            {

                // Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine($"I Venditori presenti in Lista sono :  Nome - {item.NomeCliente} {item.CognomeCliente}| GuId - {item.Id}");
                Console.WriteLine($"                                      Telefono - {item.TelefonoCliente} | Mail - {item.MailCliente}");
                Console.WriteLine($"                                      Venditore Aggiunto il -  {item.OraInserimento}");
                Console.WriteLine("");
                Console.WriteLine("");

            }

            return Liste.Clienti;
        }

        public static void VerificaListaClienti()
        {
            string NomeCliente;

            Console.WriteLine("Inserisci Nome o Cognome del Cliente da cercare :");
            NomeCliente = Console.ReadLine();


            
            //string risultatoPositivo = ("Il Cliente è presente");
            //string risultatoNegativo = ("Il Cliente non è presente");

            //for (int i = 0; i < Liste.Clienti.Count; i++)
            //{
            //    if (Id == Liste.Clienti[i].Id && NomeCliente == Liste.Clienti[i].NomeCliente) ;
            //    { 
            //    Console.WriteLine(risultatoPositivo);
            //    return;
            //    }

            //}
               // Console.WriteLine(risultatoNegativo);

        }

        public static void RimuoviCliente()
        {
            string id, nomecliente;

            Console.WriteLine("Inserisci l' Id del Cliente da eliminare");
            id = Console.ReadLine();

            Console.WriteLine("Inserisci il nome del Cliente da eliminare");
            nomecliente =  Console.ReadLine();

            // Imposto la variabile di index per il confronto ed eseguo ciclo di controllo

            int index = -1;

            for (int i = 0; i < Liste.Clienti.Count; i++)
            {
                if (nomecliente == Liste.Clienti[i].NomeCliente)
                {
                    index = i;
                }
                if (index >= 0)
                {

                    Liste.Clienti.RemoveAt(index);
                    Console.WriteLine($"Hai rimosso il Cliente {id}  -   {nomecliente}");
                    Console.WriteLine("");
                    Console.WriteLine("");
                }
            }
            
        }
    }
}
