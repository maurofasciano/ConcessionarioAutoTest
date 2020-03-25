using System;
using System.Collections.Generic;
using System.Text;
using VenditaAutoConcessionarioConsole.Class;
using VenditaAutoConcessionarioConsole.Class.Base;
using VenditaAutoConcessionarioConsole.Class.Liste;

namespace VenditaAutoConcessionarioConsole.Methods
{
    class CustomersMethods
    {

        public static Clienti RegistraClienti()
        {

            Clienti c = new Clienti();

            if (Liste.Clienti.Count > 0)
            {
                int maxId = Liste.Clienti[0].Id;

                for (int i = 1; i < Liste.Clienti.Count; i++)
                {
                    // i = maxId;

                    if (maxId < Liste.Clienti[i].Id)
                    {
                        maxId = Liste.Clienti[i].Id;
                    }

                }

                c.Id = maxId + 1;
            }
            else
            {
                c.Id = 1;
            }

            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("- Inserisci il Nome del Cliente : -");
            Console.WriteLine("-----------------------------------");
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
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("- Inserisci la Mail del Cliente : -");
            Console.WriteLine("-----------------------------------");
            c.MailCliente = Console.ReadLine();

            c.ClienteAttivo = true;

            c.OraInserimento = DateTime.Now.ToString();

            Liste.Clienti.Add(c);

            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine($"- Hai inserito il Cliente {c.NomeCliente} - {c.CognomeCliente} - Avente GuId - {c.Id} - ");
            Console.WriteLine($"- Il telefono è : {c.TelefonoCliente} - La sua mail è : {c.MailCliente}");
            Console.WriteLine($"- Il Venditore è stato inserito il  : {c.OraInserimento}");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine("");
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
                Console.WriteLine(" ---------------------------------------------------------------------------------------------");
                Console.WriteLine($"- I Clienti presenti sono :  Nome - {item.NomeCliente} | GuId - {item.Id}");
                Console.WriteLine($"                             Telefono - {item.TelefonoCliente} | Mail - {item.MailCliente}   ");    
                Console.WriteLine($"                             Cliente Aggiunto il -  {item.OraInserimento}");
                Console.WriteLine(" ---------------------------------------------------------------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("");
                
            }
            Console.Clear();
            return Liste.Clienti;
            
            
        }

        public static void VerificaListaClienti()
        {

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("- Inserisci il Nome od il Cognome del Cliente per la ricerca -");
            Console.WriteLine("-------------- (Restituisce le Proprietà) --------------------");
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();
            string nomeCliente = Console.ReadLine();

            string risultatoPositivo1 ="Il Cliente {0} è presente - Il Cognome è {1}";
            string risultatoPositivo2 ="Il Telefono è {0} - La Mail è {1}";
            string risultatoPositivo3 = "Avente Id {0} - E' stato inserito il {1}";
            string risultatoNegativoNome = $"Il Venditore ''{nomeCliente}'' non è presente nella Lista";


            
            int index = -1;

            for (int i = 0; i < Liste.Clienti.Count; i++)
            {
                // Lancio la condizione, che dice : Se Id è uguale ad "i" (ora maggiorato) leggendo l' "Id"
                // della lista Venditori e "NomeVenditore" è positivo anch' esso, esegue il prossimo blocco istruzioni
                // if (Id.ToString() == Liste.Venditori[i].Id.ToString() && NomeVenditore == Liste.Venditori[i].NomeVenditore)

                //idVenditore = Liste.Venditori[i].Id.ToString();

                if (nomeCliente == Liste.Clienti[i].NomeCliente || nomeCliente == Liste.Clienti[i].CognomeCliente)

                {
                    index = i;
                    //// Visualizza risultatoPositivo ed interrompe il ciclo
                    //Console.WriteLine(risultatoPositivo); 
                }

            }

            if (index >= 0)
            {
                Console.Clear();

                // Le liste sono contenitori di dati e la posizone progressiva delle proprietà dei dati
                // è la Index. Il dato cercato viene confrontato ogni index e se l' associaazione è trovata, mostra il risultato
                // Utilizzo metodo String.format per rappresentare i dati

                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine(String.Format(risultatoPositivo1, Liste.Clienti[index].NomeCliente, Liste.Clienti[index].CognomeCliente));
                Console.WriteLine(String.Format(risultatoPositivo2, Liste.Clienti[index].TelefonoCliente, Liste.Clienti[index].MailCliente));
                Console.WriteLine(String.Format(risultatoPositivo3, Liste.Clienti[index].Id, Liste.Clienti[index].OraInserimento));
                Console.WriteLine("----------------------------------------------------------");

                
            }
            // Oppure Visualizza il valore di risultatoNegativo
            else
            {
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine(risultatoNegativoNome); 
                Console.WriteLine("---------------------------------------------------------");
            }

        }

        public static void ModificaClienti()
        {           
           
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("--- Scegli cosa desidere fare per i Clienti --- ");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("");

                Console.WriteLine("");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("1) ----- Esegui Metodo Modifica Cliente---------");
                Console.WriteLine("2) --- Ricerca Id Cliente per Nome o Cognome ---");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("");

                string risposta = Console.ReadLine();
                bool rispostaUtente = int.TryParse(risposta, out int rispostaUtenteInt);

                Console.Clear();

                if (rispostaUtente == false)
                {
                    Console.Clear();

                    Console.WriteLine("");
                    Console.WriteLine("---------------------------------------------------------------");
                    Console.WriteLine("- Argomento non valido, Accetta SOLO parametri di Selezione ! -");
                    Console.WriteLine("---------------------------------------------------------------");

                    continue;
                }

                Console.WriteLine("");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("- Inserisci L' Id del Cliente da Cercare -");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("");

                string idVenditore = Console.ReadLine();

                bool value = Guid.TryParse(idVenditore, out Guid idVenditoreGuid);

                int index = -1;

                if (value == true)
                {

                    for (int i = 0; i < Liste.Venditori.Count; i++)
                    {
                        if (idVenditoreGuid == Liste.Venditori[i].Id)
                        {
                            index = i;
                        }

                    }
                }

                switch (rispostaUtenteInt)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine("- Seleziona ciò che vuoi modificare del Cliente -");
                        Console.WriteLine("-------- (Ricerca Tramite Id Venditore) ---------");
                        Console.WriteLine("-------------------------------------------------");

                        Console.WriteLine("1) Modifica il Nome");
                        Console.WriteLine("2) Modifica il Cognome");
                        Console.WriteLine("3) Modifica il Telefono");
                        Console.WriteLine("4) Modificala la Mail");
                        Console.WriteLine("5) Torna al Menu precedente");


                        string selezioneUtente = Console.ReadLine();
                        bool selectUtente = int.TryParse(selezioneUtente, out int selectUtenteInt);

                        switch (selectUtenteInt)
                        {
                            case 1:

                                if (index >= 0)
                                {
                                    Console.WriteLine("Inserisci l' Id del Venditore da Modificare");

                                    Console.WriteLine("Inserisci il nuovo Nome del Venditore");
                                    // Inserime valore con vaviabile dichiarata vuota : string nuovoNome = Console.ReadLine();
                                    // Oppure come segue : 
                                    Liste.Venditori[index].NomeVenditore = Console.ReadLine();
                                }
                                break;

                            case 2:
                                if (index >= 0)
                                {
                                    Console.WriteLine("Inserisci il nuovo Cognome del Venditore");
                                    // Inserime valore con vaviabile dichiarata vuota : string nuovoCognome = Console.ReadLine();
                                    // Oppure come segue : 
                                    Liste.Venditori[index].CognomeVenditore = Console.ReadLine();
                                }
                                break;

                            case 3:
                                if (index >= 0)
                                {
                                    Console.WriteLine("Inserisci il nuovo Telefono del Venditore");
                                    Liste.Venditori[index].TelefonoVenditore = Console.ReadLine();
                                }
                                break;

                            case 4:
                                if (index >= 0)
                                {
                                    Console.WriteLine("Inserisci la nuova mail del Venditore");
                                    Liste.Venditori[index].MailVenditore = Console.ReadLine();
                                }
                                break;

                            case 5:
                                return;

                            default:
                                CommonMethods.RichiestaNonValida();
                                continue;

                        }

                        break;

                    case 2:
                        VerificaListaClienti();
                        break;

                    default:
                        CommonMethods.RichiestaNonValida();
                        continue;
                }


            }
        }

        public static void RimuoviCliente()
        {
            string id, nomecliente;

            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("1) ----- Esegui Metodo Elimina Cliente----------");
            Console.WriteLine("2) --- Ricerca Id Cliente per Nome o Cognome ---");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("");

            string risposta = Console.ReadLine();
            bool rispostaUtente = int.TryParse(risposta, out int rispostaUtenteInt);

            Console.Clear();

            //if (rispostaUtente == false)
            //{
            //    Console.Clear();

            //    Console.WriteLine("");
            //    Console.WriteLine("---------------------------------------------------------------");
            //    Console.WriteLine("- Argomento non valido, Accetta SOLO parametri di Selezione ! -");
            //    Console.WriteLine("---------------------------------------------------------------");

            //    continue;
            //}





            int index = -1;

            //for (int i = 0; i < Liste.Clienti.Count; i++)
            //{
            //    if (  id = Liste.Clienti[1].Id && nomecliente = Liste.Clienti[i].NomeCliente)
            //    {
            //        index = i;
            //    }
            //    if (index >= 0)
            //    {

            //        Liste.Clienti.RemoveAt(index);
            //        Console.WriteLine($"Hai rimosso il Cliente {id}  -   {nomecliente}");
            //        Console.WriteLine("");
            //        Console.WriteLine("");
            //    }
            //}
            
        }
    }
}
