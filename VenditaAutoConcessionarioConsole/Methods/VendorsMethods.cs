using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Net.Mail;
using System.Text;
using System.Xml.Linq;
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

            /* v.Id = Guid(); */

            // Metodo nuovo per inseirmento progressivo Id, sulla tabella db l' Id è chiave primaria, ma come entity deve essere impostato su NO
            // Se lo imposto YES eseguirà l'autoincrement. In questo esercizio eseguo l' inserimento Id manuale

            /* Apro la connessione ed inserisco una query per determinare il MaxId al posto di leggere, butare in lista e poi estrarre il dato */

            /* Genero prima l' oggetto "dataBase" di tipo ConnectionStringSql, che è il metodo che contiene la 
               ConnectionString. Essendo nel metodo di classe, verrà istanziato anche per le altre queries */

            ConnectionStringSql dataBase = new ConnectionStringSql();

            /* Imposto la variabile maxId su 0 */
            int maxId = 0;
            /* Utilizzo il comando "using" (che estende Idisposable, quindi brasabile dalla GarbageCollection)
               e gli passo la variabile reference type "reader" associandogli : 
               - L' oggetto DataBase
               - Il metodo ExecuteQuery
               - La query di Sql che determina il maxId del campo Id */
            using (var reader = dataBase.ExecuteQuerys("select ISNULL(max(Id),0) as maxId from Venditori"))
            {
                /*Eseguo il ciclo while passandogli la variabile "reader" con il metodo "Read" di Sql
                  Poi trasformo l' int maxId che contiene ora il valore rilevato in .ToString.
                  Questo perchè reader è di tipo Object e non è possibile convertirlo direttaemnte*/
                while (reader.Read())
                {
                    maxId = Int32.Parse(reader["maxId"].ToString());
                }
            }

            /* Estratto il massimo valore, aggiungo +1 e lo lego alla variabile Id di tipo "V" */
            v.Id = maxId + 1;

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


            /* Un venditore è di default attivo, poi dovrò inabilitarlo creando un metodo apposito */
            v.VenditoreAttivo = true;


            /* Aggiunto metodo per inserimento ora di registrazione */
            v.OraInserimento = DateTime.Now.ToString();

            // Vecchio Metodo di aggiunta alle liste
            /*--------------------------------------------------------------------------------
             Aggiungere a liste
               Aggiungo i valori delle proprietà alla lista Venditori, tramite metodo .Add. Devo passare l' oggetto che contiene i dati 

               Liste.Venditori.Add(v); 
               -------------------------------------------------------------------------------- */

            // Nuovo Metodo :  Aggiunta dei dati su db tramite query.

            /* Uso l' oggetto costruito "dataBase", estendo di tipo ExecuteNotQuery (che serve per il CRUD)  gli passo la query estratta direttamente
               da SQL Management . Attenzione al $ per passare le variabili ed agli apici che sono comunque stringhe, ma necessrie a SQL 
               Nota : Per generare la query da Sql fare = Tasto DX su tabella, Crea Script Tabella */

            dataBase.ExecuteNotQuery($"INSERT INTO [dbo].[Venditori]([Id]" +
           ",[NomeVenditore]" + 
           ",[CognomeVenditore]" +
           ",[TelefonoVenditore]" +
           ",[MailVenditore]" +
           ",[VenditoreAttivo]" +
           ",[OraInserimento])" +
            "VALUES" +
           "(" +
           $" {v.Id} ," +
           $"'{v.NomeVenditore}'," +
           $"'{v.CognomeVenditore}'," +
           $"'{v.TelefonoVenditore}'," +
           $"'{v.MailVenditore}'," +
           $"'{v.VenditoreAttivo}'," +
           $"'{v.OraInserimento}'" +
           ")"
           );


            Console.Clear();


            /* Mostro ad output cosa ho inserito */

            Console.WriteLine("");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine($"- Hai inserito il venditore {v.NomeVenditore} - {v.CognomeVenditore} - Avente Id - {v.Id} - ");
            Console.WriteLine($"- Il telefono è : {v.TelefonoVenditore} - La sua mail è : {v.MailVenditore}");
            Console.WriteLine($"- Il Venditore è attivo dal : {v.OraInserimento}");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine("");



            /* Deve tornarmi qualcosa, che sono i dati del venditore, dato che il metodo non è Void
               In questo caso i dati sono nell' oggetto "v" che contiene "Id, Nome, Cosgnome, telefono e mail" */

            return v;


        }

        public static List<Venditori> ElencoVenditori()
        {
            // Vecchio metodo per le Liste
            /* Eseguo un ForEach per ciclare dalla lista i miei dati. A differenza del While che cicla un condizionale
               e For che cicla una index, questo comando è dedicato alle liste.
               Associa alla variabile "item", tramite il comando "in", la lista venditori e mostra in console cosa contengono

            foreach (var item in Liste.Clienti)
            {

                Console.WriteLine("");
                Console.WriteLine(" --------------------------------------------------------------------------------------");
                Console.WriteLine($"- I Clienti presenti sono :  Nome - {item.NomeCliente} | GuId - {item.Id}");
                Console.WriteLine($"                             Telefono - {item.TelefonoCliente} | Mail - {item.MailCliente}");
                Console.WriteLine($"                             Cliente Aggiunto il -  {item.OraInserimento}");
                Console.WriteLine(" ---------------------------------------------------------------------------------------");
                Console.WriteLine("");

            }

            return Liste.Clienti; */

            Console.Clear();

            // Nuovo Metodo Lettura dal DB.
            /* Creo sempre un oggetto "database" di tipo Connectionstring, in modo da legare la connessione, ma utilizzo l' "using"
               altrimenti, se utilizzassi solo l' oggetto SqlDataReader, che è nella classe connessioni, dato che mi torna la connessione stessa,
               me la chiuderebbe prima di eseguire la lettura dati */

            ConnectionStringSql dataBase = new ConnectionStringSql();

            /* Eseguo il comando "using" (di tipo IDisposable) e gli passo la variabile "reader" contenente l' oggetto
               dataBase con il metodo ExecuteQuerys che contiene la query di lettura */

            using (var reader = dataBase.ExecuteQuerys(
                @"SELECT [Id] 
                 ,[NomeVenditore]
                 ,[CognomeVenditore]
                 ,[TelefonoVenditore]
                 ,[MailVenditore]
                 ,[VenditoreAttivo]
                 ,[OraInserimento]
                FROM[dbo].[Venditori]
                order by Id"
                ))



            // {
                /* Esco dal task ed eseguo un while per andare a riempire la lista da stampare a schermo.
                   Gli passo "reader" con il motodo .Read() e gli faccio richiamare il metodo .Add */ 
                while (reader.Read())
                {
                    /* Passo una nuova istanza della classe Venditori ed eseguo i tryparse per la conversione in stringa */
                    Liste.Venditori.Add(new Venditori()
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
            // }

            /* Ora posso chiudere la connessione con il metodo ConnectionClose */
            dataBase.ConnectionClose();

            /* Modificato OutPut in modo da avere solo una lista che segue la frase I Venditori presenti in Lista sono */
            Console.WriteLine("");
            Console.WriteLine(" --------------------------------------------------------------------------------------");
            Console.WriteLine($"I Venditori presenti in Lista sono : ");
            Console.WriteLine("");

            /* Inserisco tutto l' output nel foreach per implementare quanto scelto sopra */
            foreach (var item in Liste.Venditori)
            {         
                Console.WriteLine("");
                Console.WriteLine($"Id - {item.Id} | Nome - {item.NomeVenditore} |  Cognome  -  {item.CognomeVenditore} ");
                Console.WriteLine($"Telefono - {item.TelefonoVenditore} | Mail - {item.MailVenditore}");
                Console.WriteLine($"Venditore Aggiunto il -  {item.OraInserimento}  |  Il Venditore è {item.VenditoreAttivo} ");                
                Console.WriteLine("");
            }
            Console.WriteLine(" ---------------------------------------------------------------------------------------");
            Console.WriteLine("");

            return Liste.Venditori;
        }

        public static void RicercaVenditore()
        {
            // Vecchio metodo con Lista

            /* string nomeCognomeVenditore;
            
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("------------ Ricerca Id Venditore --------------");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("");


            nomeCognomeVenditore = Console.ReadLine();
            bool value = Int32.TryParse(nomeCognomeVenditore, out int idVenditoreId);
            if (value == true)
            {
                int index = -1;

                for (int i = 0; i < Liste.Venditori.Count; i++)
                {
                    // if (idVenditoreGuid == Liste.Venditori[i].Id)
                    {
                        index = i;
                    }

                }
                if (index >= 0)
                {

                } 
            }  */

            // Nuovo Metodo con Sql         

            Console.Clear();

            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("--------------- Ricerca Venditore -----------------");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("--------- Inserisci Cognome Per la ricerca --------");
            Console.WriteLine("--------------- (Verifica Id) ---------------------");
            Console.WriteLine("---------------------------------------------------");


            string cognomeVenditore = Console.ReadLine();

            ConnectionStringSql dataBase = new ConnectionStringSql();


            using (var reader = dataBase.ExecuteQuerys(
                @"SELECT [Id]
                ,[NomeVenditore]
                ,[CognomeVenditore] 
                ,[TelefonoVenditore]
                ,[MailVenditore]
                ,[VenditoreAttivo]
                ,[OraInserimento]
                FROM [dbo].[Venditori]
                WHERE CognomeVenditore = '" + cognomeVenditore + "'"))

             {
                while (reader.Read())
                {
                    Console.WriteLine("");
                    Console.WriteLine("I Venditori trovati con quasto nome sono : ");

                        Console.WriteLine("");
                        Console.WriteLine($"Nome - " +  reader["NomeVenditore"].ToString() + " | Cognome - " + reader["CognomeVenditore"].ToString());
                        Console.WriteLine($"Mail - " + reader["MailVenditore"].ToString() + " | Telefono - " + reader["TelefonoVenditore"].ToString());
                        Console.WriteLine($"Avente Id - " + reader["Id"].ToString() + " | Il Venditore è - " + reader["VenditoreAttivo"]);
                        Console.WriteLine($"Dalla Data - " + reader["OraInserimento"]);
                        Console.WriteLine("");
                   
                }

             }

        }

        public static void ModificaVenditori()
        {
            

            // Poteva anche essere senza passBlock e con while(true)
            // bool passCodeBlock = true;
            Console.Clear();
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("1) --- Esegui Metodo Modifica Venditore tramite Id ---");
                Console.WriteLine("2) ------- Ricerca Id Venditore per Cognome  ---------");
                Console.WriteLine("3) ------------ Torna al Menu Venditori  -------------");
                Console.WriteLine("------------------------------------------------------");
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


                // Vecchio Metodo 
                /* Console.WriteLine("Inserisci L' id venditore");
                   string idVenditore = "v";

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
                } */

                // Venditori v = new Venditori();

                // string idVenditore = string.Empty;

                Venditori v = new Venditori();

                string idVenditore = string.Empty;                

                ConnectionStringSql dataBase = new ConnectionStringSql();

                using (var reader = dataBase.ExecuteQuerys(
                @"SELECT [Id] 
                 ,[NomeVenditore]
                 ,[CognomeVenditore]
                 ,[TelefonoVenditore]
                 ,[MailVenditore]
                 ,[VenditoreAttivo]
                 ,[OraInserimento]
                FROM[dbo].[Venditori]
                order by Id"
                ))

                while (reader.Read())
                {

                    v.Id = Int32.Parse(reader["Id"].ToString());
                    v.NomeVenditore = reader["NomeVenditore"].ToString();
                    v.CognomeVenditore = reader["CognomeVenditore"].ToString();
                    v.TelefonoVenditore = reader["TelefonoVenditore"].ToString();
                    v.MailVenditore = reader["MailVenditore"].ToString();
                    v.VenditoreAttivo = Boolean.Parse(reader["VenditoreAttivo"].ToString());
                    v.OraInserimento = reader["OraInserimento"].ToString(););
                }

                switch (rispostaUtenteInt)
                {
                    case 1:

                        Console.WriteLine();
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("--- Inserisci l' Id del Venditore da modificare ---");
                        Console.WriteLine("---------------------------------------------------");

                        idVenditore = Console.ReadLine();

                        

                        Console.Clear();

                        Console.WriteLine();
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("- Seleziona ciò che vuoi modificare del Venditore -");
                        Console.WriteLine("------------- (Seleione tramite Id) ---------------");
                        Console.WriteLine("---------------------------------------------------");


                        Console.WriteLine("1) Modifica il Nome");
                        Console.WriteLine("2) Modifica il Cognome");
                        Console.WriteLine("3) Modifica il Telefono");
                        Console.WriteLine("4) Modificala la Mail");
                        Console.WriteLine("5) Modifica abilitazione Venditore");


                        string selezioneUtente = Console.ReadLine();
                        int.TryParse(selezioneUtente, out int selectUtenteInt);


                        switch (selectUtenteInt)
                        {

                            case 1:

                                // Vecchio Metodo
                                /* if (index >= 0)
                                {
                                    Console.WriteLine("Inserisci l' Id del Venditore da Modificare");

                                    Console.WriteLine("Inserisci il nuovo Nome del Venditore");
                                    // Inserime valore con vaviabile dichiarata vuota : string nuovoNome = Console.ReadLine();
                                    // Oppure come segue : 
                                    Liste.Venditori[index].NomeVenditore = Console.ReadLine();
                                } */

                                // Nuovo Metodo con Sql
                                Console.WriteLine(" ------------------------------------------");
                                Console.WriteLine(" - Inserisci il nuovo Nome del Venditore - ");
                                Console.WriteLine(" ------------------------------------------");
                                v.NomeVenditore = Console.ReadLine();

                                break;

                            case 2:
                                /* if (index >= 0)
                                {
                                    Console.WriteLine("Inserisci il nuovo Cognome del Venditore");
                                    // Inserime valore con vaviabile dichiarata vuota : string nuovoCognome = Console.ReadLine();
                                    // Oppure come segue : 
                                    Liste.Venditori[index].CognomeVenditore = Console.ReadLine();
                                } */

                                // Nuovo Metodo con Sql
                                Console.WriteLine(" ----------------------------------------------");
                                Console.WriteLine(" - Inserisci il nuovo Cognome  del Venditore - ");
                                Console.WriteLine(" ----------------------------------------------");
                                v.CognomeVenditore = Console.ReadLine();
                                break;

                            case 3:
                                /* if (index >= 0)
                                {
                                    Console.WriteLine("Inserisci il nuovo Telefono del Venditore");
                                    Liste.Venditori[index].TelefonoVenditore = Console.ReadLine();
                                } */
                                // Nuovo Metodo con Sql
                                Console.WriteLine(" ----------------------------------------------");
                                Console.WriteLine(" - Inserisci il nuovo Telefono del Venditore - ");
                                Console.WriteLine(" ----------------------------------------------");
                                v.TelefonoVenditore = Console.ReadLine();
                                break;

                            case 4:
                                /* if (index >= 0)
                                {
                                    Console.WriteLine("Inserisci la nuova mail del Venditore");
                                    Liste.Venditori[index].MailVenditore = Console.ReadLine();
                                } */
                                // Nuovo Metodo con Sql
                                Console.WriteLine(" ------------------------------------------");
                                Console.WriteLine(" - Inserisci la nuova Mail del Venditore - ");
                                Console.WriteLine(" ------------------------------------------");
                                v.MailVenditore = Console.ReadLine();
                                break;

                            case 5:
                                // Nuovo Metodo con Sql
                                Console.WriteLine(" ------------------------------------------------------------");
                                Console.WriteLine(" - Premi 1 per Abilitare o 2 per Disabilitare un Venditore - ");
                                Console.WriteLine(" ------------------------------------------------------------");

                                string abilita = Console.ReadLine();
                                bool abilitaUtente = int.TryParse(abilita, out int abilitaint);

                                Console.Clear();

                                if (abilitaUtente == false)
                                {
                                    Console.Clear();

                                    Console.WriteLine("");
                                    Console.WriteLine("-----------------------------------------------");
                                    Console.WriteLine("- Argomento non valido, Accetta SOLO interi ! -");
                                    Console.WriteLine("-----------------------------------------------");
                                    continue;

                                }

                                switch (abilitaint)                                 
                                { 
                                    case 1:
                                        v.VenditoreAttivo = true;
                                        break;

                                    case 2: 
                                        v.VenditoreAttivo = false;
                                        break;

                                    case 3:
                                        CommonMethods.RichiestaNonValida();
                                        break;

                                }
                                                             
                                /* passCodeBlock = false;
                                Console.Clear(); */
                                return;

                            case 6:
                                return;

                            default:
                                CommonMethods.RichiestaNonValida();
                                continue;
                        }
                        break;

                    case 2:
                        RicercaVenditore();
                        // VerificaListaVenditori();
                        break;

                    case 3:
                        return;

                    default:
                        CommonMethods.RichiestaNonValida();
                        continue;

                }

                if (!String.IsNullOrEmpty(idVenditore))
                {
                    dataBase.ExecuteNotQuery($"UPDATE[dbo].[Venditori]" +
                        "SET [NomeVenditore] = '" + v.NomeVenditore + "'" +
                        ",[CognomeVenditore] = '" + v.CognomeVenditore + "'" +
                        ",[TelefonoVenditore] = '" + v.TelefonoVenditore + "'" +
                        ",[MailVenditore] = '" + v.MailVenditore + "'" +
                        ",[VenditoreAttivo] = '" + v.VenditoreAttivo + "'" +
                        " WHERE [Id] = " + idVenditore);
                }
                else
                {
                    continue;
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

        // VerificaListaVenditori() - Metodo Vecchio - sostituito con RicercaVenditore()
        /* public static void VerificaListaVenditori()
        // {


        Genero il metodo di verifica presenza del Venditore
        Imposto le variabili da richiamare per i confronti

       string nomevenditore = "";
        string cognomevenditore = "";

       Console.Clear();

       Console.WriteLine();
       Console.WriteLine("----------------------------------------------------------------");
       Console.WriteLine("- Inserisci il Nome od il Cognome del Venditore per la ricerca -");
       Console.WriteLine("-------------- (Restituisce le Proprietà) ----------------------");
       Console.WriteLine("----------------------------------------------------------------");
       Console.WriteLine();

       nomevenditore = Console.ReadLine();


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



   } */

    }
}

   



 






       

