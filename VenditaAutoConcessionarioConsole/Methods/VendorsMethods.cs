﻿using System;
using System.Collections.Generic;
using System.Text;
using VenditaAutoConcessionarioConsole.Class;
using VenditaAutoConcessionarioConsole.Class.Base;
using VenditaAutoConcessionarioConsole.Class.Liste;

namespace VenditaAutoConcessionarioConsole.Methods
{
    /// <summary>
    /// Classe dei metodi Venditori. Non viene istanziata in quanto  in questo caso
    /// i metodi sono statici
    /// </summary>
    public class VendorsMethods
    {

        public static Venditori Registravenditore()
        {
            // Genero l' oggetto "v", di tipo  che conterrà i dati per delle proprietà

            Venditori v = new Venditori();

            Console.Clear();

            // Metodo vecchio Guid per l' autogenerazione dell' Id associato automaticamente

            
            


            // Metodo per inseirmento progressivo Id, sulla tabella db l' Id è chiave primaria, ma come entity deve essere impostato su NO
            // Se lo imposto YES eseguirà l'autoincrement

            /* */


            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("- Inserisci il Nome del Venditore : -");
            Console.WriteLine("-------------------------------------");


            v.NomeVenditore = Console.ReadLine();

            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("- Inserisci il Cognome del Venditore : -");
            Console.WriteLine("----------------------------------------");
            v.CognomeVenditore = Console.ReadLine();

            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("- Inserisci il Telefono del Venditore : -");
            Console.WriteLine("-----------------------------------------");
            v.TelefonoVenditore = Console.ReadLine();

            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("- Inserisci la Mail del Venditore : -");
            Console.WriteLine("-------------------------------------");
            v.MailVenditore = Console.ReadLine();


            // Un venditore è di default attivo, poi dovrò inabilitarlo creando un metodo apposito
            v.VenditoreAttivo = true;


            // Aggiunto metodo per inserimento ora di registrazione
            v.OraInserimento = DateTime.Now.ToString();


            // Aggiungere a liste
            // Aggiungo i valori delle proprietà alla lista Venditori, tramite metodo .Add. Devo passare l' oggetto che 
            // contiene i dati 

            // Liste.Venditori.Add(v);

            /* Aggiunta dei dati su db tramite query. Costruisco un oggetto "database" di tipo ConnectionStringSql che poi estendo con il metodo
               ExecuteQuery creato nella classe base */

            ConnectionStringSql dataBase = new ConnectionStringSql();

            /* Uso l' oggetto costruito ed estendo con l' ExecuteNotQuery che serve per il CRUD e gli passo la query estratta direttamente
               da SQL Management . Attenzione al $ per passare le variabili ed agli apici che sono comunque stringhe, ma necessrie a SQL */

            dataBase.ExecuteNotQuery($"INSERT INTO [dbo].[Venditori]([NomeVenditore]" +
           ",[CognomeVenditore]" +
           ",[TelefonoVenditore]" +
           ",[MailVenditore]" +
           ",[VenditoreAttivo]" +
           ",[OraInserimento])" +
            "VALUES" +
           "(" +
           $"'{v.NomeVenditore}'," +
           $"'{v.CognomeVenditore}'," +
           $"'{v.TelefonoVenditore}'," +
           $"'{v.MailVenditore}'," +
           $"'{v.VenditoreAttivo}'," +
           $"'{v.OraInserimento}'" +
           ")"
           );


            Console.Clear();


            //Mostro ad output cosa ho inserito

            Console.WriteLine("");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine($"- Hai inserito il venditore {v.NomeVenditore} - {v.CognomeVenditore} - Avente GuId - {v.Id} - ");
            Console.WriteLine($"- Il telefono è : {v.TelefonoVenditore} - La sua mail è : {v.MailVenditore}");
            Console.WriteLine($"- Il Venditore è attivo dal : {v.OraInserimento}");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine("");



            // Deve tornarmi qualcosa, che sono i dati del venditore, dato che il metodo non è Void
            // In questo caso i dati sono nell' oggetto "v" che contiene "Id, Nome, Cosgnome, telefono e mail"

            return v;


        }

        public static List<Venditori> ElencoVenditori()
        {
            // Vecchio metodo per le Liste
            /* Eseguo un ForEach per ciclare dalla lista i miei dati. A differenza del While che cicla un condizionale
               e For che cicla una index, questo comando è dedicato alle liste.
               Associa alla variabile "item", tramite il comando "in", la lista venditori e mostra in console cosa contengono */

            //foreach (var item in Liste.Clienti)
            //{

            //    Console.WriteLine("");
            //    Console.WriteLine(" --------------------------------------------------------------------------------------");
            //    Console.WriteLine($"- I Clienti presenti sono :  Nome - {item.NomeCliente} | GuId - {item.Id}");
            //    Console.WriteLine($"                             Telefono - {item.TelefonoCliente} | Mail - {item.MailCliente}");
            //    Console.WriteLine($"                             Cliente Aggiunto il -  {item.OraInserimento}");
            //    Console.WriteLine(" ---------------------------------------------------------------------------------------");
            //    Console.WriteLine("");

            //}

            //return Liste.Clienti;


            // Nuovo Metodo Lettura dal DB.
            /*    */
            Console.Clear();

            ConnectionStringSql dataBase = new ConnectionStringSql();
            using (var reader = dataBase.ExecuteQuerys(
                @"SELECT [Id]
                 ,[NomeVenditore]
                 ,[CognomeVenditore]
                 ,[TelefonoVenditore]
                 ,[MailVenditore]
                 ,[VenditoreAttivo]
                 ,[OraInserimento]
                FROM[dbo].[Venditori]"

                ))
            { 
                while (reader.Read())
                {
                    Liste.Venditori.Add(new Venditori()
                    {
                        Id = Int32.Parse(reader["Id"].ToString()),
                        NomeVenditore = reader["NomeVenditore"].ToString(),
                        CognomeVenditore = reader["CognomeVenditore"].ToString(),
                        TelefonoVenditore = reader["TelefonoVenditore"].ToString(),
                        MailVenditore = reader["MailVenditore"].ToString(),
                        VenditoreAttivo = Boolean.Parse(reader["VenditoreAttivo"].ToString())
                    });
                }
            }
            dataBase.ConnectionClose();

            Console.WriteLine("");
            Console.WriteLine(" --------------------------------------------------------------------------------------");
            Console.WriteLine($"I Venditori presenti in Lista sono : ");
            Console.WriteLine("");
            foreach (var item in Liste.Venditori)
            {         
                Console.WriteLine("");
                Console.WriteLine($"Nome - {item.NomeVenditore} | GuId - {item.Id}");
                Console.WriteLine($"Telefono - {item.TelefonoVenditore} | Mail - {item.MailVenditore}");
                Console.WriteLine($"Venditore Aggiunto il -  {item.OraInserimento}");
                Console.WriteLine("");
            }
            Console.WriteLine(" ---------------------------------------------------------------------------------------");
            Console.WriteLine("");
            return Liste.Venditori;
        }

        public static void VerificaListaVenditori()
        {
            // Genero il metodo di verifica presenza del Venditore
            // Imposto le variabili da richiamare per i confronti

            string nomevenditore = "";
            // string cognomevenditore = "";

            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("- Inserisci il Nome od il Cognome del Venditore per la ricerca -");
            Console.WriteLine("-------------- (Restituisce le Proprietà) ----------------------");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine();

            nomevenditore = Console.ReadLine();
            // cognomevenditore = Console.ReadLine();

            // Genero le variabili da utilizzare nella condizionale successiva
            string risultatoPositivo = "Il Venditore {0} è presente - Avente GuId {1} - " +
                "                       Il Cognome è {2} - Il Telefono è {3} - La Mail è {4}" +
                "                       E' attivo dal {5}";
            string risultatoNegativoNome = $"Il Venditore ''{nomevenditore}'' non è presente nella Lista";
            // string risultatoNegativoCognome = $"Il Venditore ''{cognomevenditore}'' non è presente nella Lista ";

            // Imposto Lettura ciclo : Ho un intero a -1, verifico che sia minore del conteggio della lista
            // e nel caso questo sia true, aggiungo 1
            // Definizione di For : https://docs.microsoft.com/it-it/dotnet/csharp/language-reference/keywords/for

            // Ciclo For con indice
            int index = -1;

            for (int i = 0; i < Liste.Venditori.Count; i++)
            {
                // Lancio la condizione, che dice : Se Id è uguale ad "i" (ora maggiorato) leggendo l' "Id"
                // della lista Venditori e "NomeVenditore" è positivo anch' esso, esegue il prossimo blocco istruzioni
                // if (Id.ToString() == Liste.Venditori[i].Id.ToString() && NomeVenditore == Liste.Venditori[i].NomeVenditore)

                //idVenditore = Liste.Venditori[i].Id.ToString();

                if (nomevenditore == Liste.Venditori[i].NomeVenditore || nomevenditore == Liste.Venditori[i].CognomeVenditore)

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
                Console.WriteLine(String.Format(risultatoPositivo, Liste.Venditori[index].NomeVenditore, Liste.Venditori[index].Id, Liste.Venditori[index].CognomeVenditore, Liste.Venditori[index].TelefonoVenditore, Liste.Venditori[index].MailVenditore, Liste.Venditori[index].OraInserimento));
                Console.WriteLine("----------------------------------------------------------");
            }
            // Oppure Visualizza il valore di risultatoNegativo
            else
            {
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine(risultatoNegativoNome); //risultatoNegativoCognome
                Console.WriteLine("---------------------------------------------------------");
            }



        }

        public static void ModificaVenditori()
        {
            

            // Poteva anche essere senza passBlock e con while(true)
            bool passCodeBlock = true;
            while (passCodeBlock)
            {
                Console.WriteLine("");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("1) ---- Esegui Metodo Modifica Venditore -------");   
                Console.WriteLine("2) -- Ricerca Id Venditore per Nome o Cognome --");
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

                Console.WriteLine("Inserisci L' id venditore");
                string idVenditore = Console.ReadLine();

                bool value = Int32.TryParse(idVenditore, out int idVenditoreGuid);

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
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("- Seleziona ciò che vuoi modificare del Venditore -");
                        Console.WriteLine("-------- (Ricerca Tramite Id Venditore) -----------");
                        Console.WriteLine("---------------------------------------------------");

                        

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
                                    passCodeBlock = false;
                                    Console.Clear();
                                    break;

                                default:
                                    CommonMethods.RichiestaNonValida();
                                    continue;




                            }

                        
                        break;

                    case 2:
                        VerificaListaVenditori();
                        break;

                    default:
                        CommonMethods.RichiestaNonValida();
                        continue;
                    }
                
               
            }   
        }

        public static void CicloRicercaVenditoreId()
        {
            string idVenditore = Console.ReadLine();
            bool value = Int32.TryParse(idVenditore, out int idVenditoreGuid);
            if (value == true)
            {

                int index = -1;

                for (int i = 0; i < Liste.Venditori.Count; i++)
                {
                    if (idVenditoreGuid == Liste.Venditori[i].Id)
                    {
                        index = i;
                    }

                }
                if (index >= 0)
                {
                    
                }
            }
        }

        public static void RimuoviVenditore()
        {
            // dichiaro le variabili da usare nel metodo e confrontarle nel ciclo
            string NomeVenditore;

            // Chiedo all' utente di valorizzare le variabili richieste
            //Console.WriteLine("Inserisci il codice del venditore da eliminare");
            //Id = Console.ReadLine();

            Console.WriteLine("Inserisci il nome venditore da eliminare");
            NomeVenditore = Console.ReadLine();

            // Ora Imposto il ciclo per la verifica di presenza del contatto in lista
            // Imposto una variabile di indice da poter verificare successivamnte
            // La imposto negativa per verificare se questa andrà a 0, dopo la verifica
            // se viene aggiunti 1 ("i++") in caso esito positivo 

            int index = -1;

            // questo ciclo significa : 
            // prendi "i" di tipo intero , verifica se "i" ha valore relativo minone dei 
            // venditori in lista ed aggiungi +1
            // Utilizzo quindi il metodo .count associato alle funzioni Liste
            for (int i = 0; i < Liste.Venditori.Count; i++)
            {
                // Verifico la condizione come : 
                // Se variabili Id && NomeVenditore impostate dall' utente sono
                // uguali (quindi presente) nella lista, imposta la index con il valore
                // assegnato ad i dal ciclo.
                //if (Id.ToString() == Liste.Venditori[i].Id.ToString() && NomeVenditore == Liste.Venditori[i].NomeVenditore)
                //{
                //    index = i;
                //}

            }
            // Ora verifico la condizione di presenza che dice : 
            // Se index è maggiore od uguale a 0 (era impostata a -1)
            // utilizza il metodo .RemoveAt della index
            if (index >= 0)
            {
                Liste.Venditori.RemoveAt(index);
            }

            // Metodo per listare i venditori. Eseguo un ciclo ForEach , dato che serve proprio 
            // per ciclare le liste (a differenza del For che cicla sugli indici e While che cicla
            // sulle condizioni). Va impostata la variabile per contenere i dati (Item), "in" significa
            // In  quella data lista e la lista. Viene poi data l' istruzione a va passata la variabile
            // per mostrare, non essendo void, va fatto return, in questo caso è proprio la lista.
        }
    }
}

   



 






       

