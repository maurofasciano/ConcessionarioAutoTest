using System;
using System.Collections.Generic;
using System.Text;
using VenditaAutoConcessionarioConsole.Class;
using VenditaAutoConcessionarioConsole.Class.Base;
using VenditaAutoConcessionarioConsole.Class.Liste;


namespace VenditaAutoConcessionarioConsole.Methods
{
    class CustomerMethods
    {

        public static Clienti RegistraClienti()
        {

            Clienti c = new Clienti();

            // Vecchio metodo per autoincrement sullId in Liste

            /* if (Liste.Clienti.Count > 0)
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
            } */
            ConnectionStringSql database = new ConnectionStringSql();

            int maxId = 0;

            using (var reader = database.ExecuteQuerys("SELECT ISNULL(max(Id),0) as maxId from Clienti"))
            {
                while (reader.Read())
                {
                    maxId = Int32.Parse(reader["maxId"].ToString());
                }
            }

            c.Id = maxId + 1;

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

            // Vecchio inserimento in liste
            /* Liste.Clienti.Add(c); */

            Console.Clear();

            c.ClienteAttivo = true;

            c.OraInserimento = DateTime.Now.ToString();

            database.ExecuteNotQuery($"INSERT INTO [dbo].[Clienti]([Id]" +
                ",[NomeCliente]" +
                ",[CognomeCliente]" +
                ",[TelefonoCliente]" +
                ",[MailCliente]" +
                ",[ClienteAttivo]" +
                ",[OraInserimento])" +
                "VALUES" + "(" + $"{c.Id}," + $"'{c.NomeCliente}', '{c.CognomeCliente}', '{c.TelefonoCliente}'," +
                $"'{c.MailCliente}', '{c.ClienteAttivo}', '{c.OraInserimento}')");

            // database.ConnectionClose();
            database.Dispose();


            Console.WriteLine("");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine($"- Hai inserito il Cliente con {c.NomeCliente} - {c.CognomeCliente} - Avente Id - {c.Id} - ");
            Console.WriteLine($"- Il telefono è : {c.TelefonoCliente} - La sua mail è : {c.MailCliente}");
            Console.WriteLine($"- Il cliente è : " + (c.ClienteAttivo == true ? "Attivo" : "") + "  Registrato il : " + $"{c.OraInserimento}");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine("");

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Premi un tasto per continuare....");
            Console.ReadLine();
            Console.Clear();

            return c;

        }

        public static List<Clienti> ElencoClienti()
        {

            // Vecchio metodo con Lista

            /* Eseguo un ForEach per ciclare dalla lista i miei dati. A differenza del While che cicla un condizionale
            e For che cicla una index, questo comando è dedicato alle liste.
            Associa alla variabile "item", tramite il comando "in", la lista venditori e mostra in console cosa contengono

            Console.Clear();

            foreach (var item in Liste.Clienti)
            {               
                
                Console.WriteLine("");
                Console.WriteLine(" --------------------------------------------------------------------------------------");
                Console.WriteLine($"- I Clienti presenti sono :  Nome - {item.NomeCliente} | GuId - {item.Id}");
                Console.WriteLine($"                             Telefono - {item.TelefonoCliente} | Mail - {item.MailCliente}");    
                Console.WriteLine($"                             Cliente Aggiunto il -  {item.OraInserimento}");
                Console.WriteLine(" ---------------------------------------------------------------------------------------");
                Console.WriteLine("");
                              
            } */

            Console.Clear();

            List<Clienti> lista = new List<Clienti>();

   
            lista = CommonMethods.DbCustomersReader("" );
            

            Console.WriteLine("");
            Console.WriteLine(" --------------------------------------------------------------------------------------");
            Console.WriteLine($"I Clienti presenti in Lista sono : ");
            Console.WriteLine("");

            int output = 0;

            foreach (var c in lista)
            {
                output += 1;

                Console.WriteLine("");
                Console.WriteLine($"Id - {c.Id} | Nome - {c.NomeCliente} |  Cognome  -  {c.CognomeCliente} ");
                Console.WriteLine($"Telefono - {c.TelefonoCliente} | Mail - {c.MailCliente}");
                Console.WriteLine("Cliente Aggiunto il" + c.OraInserimento + " |  Il Venditore è : " + (c.ClienteAttivo == true ? "Attivo" : "Disattivo"));
                Console.WriteLine("");

                if (output % 5 == 0)
                {
                    Console.WriteLine(" ---------------------------------------------------------------------------------------");
                    Console.WriteLine("Premi un tasto per continuare .....");
                    Console.ReadLine();
                }

            }

            Console.WriteLine(" ---------------------------------------------------------------------------------------");
            Console.WriteLine(" --- Ricerca completata - Premi tasto per continuare ..... ");
            Console.WriteLine(" ---------------------------------------------------------------------------------------");
            Console.ReadLine();

            Console.Clear();
            // Liste.Clienti.Clear();
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
            string cognomeCliente = Console.ReadLine();

            List<Clienti> lista = new List<Clienti>();

            // Vecchiometodo con lista e segnaposto

            /* string risultatoPositivo1 ="Il Cliente {0} è presente - Il Cognome è {1}";
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
            } */

            // Genero un oggetto che non mi serve a nulla, se non a farlo passare nel metodo DbCustomerReader

            lista = CommonMethods.DbCustomersReader("WHERE CognomeCliente = '" + cognomeCliente + "'" +
                "OR NomeCliente = '" + cognomeCliente + "'");

            if (lista.Count == 0)
            {
                Console.WriteLine("");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("- Nessun Venditore Trovato con questo Nome o Cognome -");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("");

                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Premi un tasto per continuare ....");
                Console.ReadLine();
                Console.Clear();
                return;
            }

            Console.WriteLine("");
            Console.WriteLine("I Venditori trovati con quasto nome sono : ");
            Console.WriteLine("");

            int output = 0;
            foreach (var item in lista)
            {

                Console.WriteLine("");
                Console.WriteLine($"Id - {item.Id} | Nome - {item.NomeCliente} |  Cognome  -  {item.CognomeCliente} ");
                Console.WriteLine($"Telefono - {item.TelefonoCliente} | Mail - {item.MailCliente}");
                Console.WriteLine($"Venditore Aggiunto il -  {item.OraInserimento}  |  Il Cliente è :  " + (item.ClienteAttivo == true ? "Attivo" : "Disattivo"));
                Console.WriteLine("");

                if (output % 3 == 0)
                {
                    Console.WriteLine(" ---------------------------------------------------------------------------------------");
                    Console.WriteLine("Premi un tasto per continuare .....");
                    Console.ReadLine();
                }

            }

            Liste.Clienti.Clear();
        }

        public static void ModificaClienti()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("-----  Scegli cosa desidere fare in Modifica  ----- ");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("");

                Console.WriteLine("");
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("1) ----Esegui Metodo Modifica Cliente (Tramite Id) -----");
                Console.WriteLine("2) -----  Ricerca Id Cliente per Nome o Cognome --------");
                Console.WriteLine("3) -------------Torna al Menu Precedente----------------");
                Console.WriteLine("--------------------------------------------------------");
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

                Clienti c = new Clienti();               

                string idCliente = string.Empty;

                List<Clienti> lista = new List<Clienti>();

                switch (rispostaUtenteInt)
                {                    

                    case 1:

                        Console.WriteLine("");
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("- Inserisci L' Id del Cliente da Modificare -");
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("");

                        idCliente = Console.ReadLine();

                        if (string.IsNullOrEmpty(idCliente))
                        {
                            Console.WriteLine("");
                            Console.WriteLine("---------------------------------------------");
                            Console.WriteLine("- Inserisci un valore valido per la ricerca -");
                            Console.WriteLine("---------------------------------------------");
                            Console.WriteLine("");
                            Console.WriteLine("Premi un tasto per continuare");
                            Console.ReadLine();
                            Console.Clear();
                            continue;

                        }

                        lista = CommonMethods.DbCustomersReader("WHERE [Id] =" + idCliente);

                        if (lista.Count == 0)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("- Nessun Venditore Trovato con questo Id -");
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("");
                            Console.WriteLine("---------------------------------------");
                            Console.WriteLine("Premi un tasto per continuare ....");
                            Console.ReadLine();
                            Console.Clear();
                            continue;
                        }
                        c = lista[0];

                        Console.Clear();

                        Console.WriteLine();
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine("- Seleziona ciò che vuoi modificare del Cliente -");
                        Console.WriteLine("-------- (Ricerca Tramite Id Venditore) ---------");
                        Console.WriteLine("-------------------------------------------------");

                        Console.WriteLine("1) Modifica il Nome");
                        Console.WriteLine("2) Modifica il Cognome");
                        Console.WriteLine("3) Modifica il Telefono");
                        Console.WriteLine("4) Modificala la Mail");
                        Console.WriteLine("5) Modifica abilitazione Cliente");
                        Console.WriteLine("6) Torna al Menu precedente");

                        string selezioneUtente = Console.ReadLine();
                        int.TryParse(selezioneUtente, out int selectUtenteInt);


                        switch (selectUtenteInt)
                        {
                            case 1:                                        
                                Console.WriteLine("Inserisci il nuovo Nome del Cliente");
                                c.NomeCliente = Console.ReadLine();
                                        
                                break;

                            case 2:
                                Console.WriteLine("Inserisci il nuovo Cognome del Cliente");
                                c.CognomeCliente = Console.ReadLine();                                    
                                break;

                            case 3:
                                Console.WriteLine("Inserisci il nuovo Telefono del Cliente");
                                c.TelefonoCliente = Console.ReadLine();
                                break;

                            case 4:
                                    Console.WriteLine("Inserisci la nuova mail del Cliente");
                                    c.MailCliente = Console.ReadLine();
                                break;

                            case 5:
                                Console.WriteLine(" ----------------------------------------------------------");
                                Console.WriteLine(" - Premi 1 per Abilitare o 2 per Disabilitare il Cliente - ");
                                Console.WriteLine(" ----------------------------------------------------------");

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
                                        c.ClienteAttivo = true;
                                        break;

                                    case 2:
                                        c.ClienteAttivo = false;
                                        break;

                                    case 3:
                                        CommonMethods.RichiestaNonValida();
                                        continue;                                            

                                    default:
                                        CommonMethods.RichiestaNonValida();
                                        continue;
                                }
                                break;                               

                        }
                        break;

                    case 2:
                        VerificaListaClienti();
                        break;

                    case 3:
                        return;

                    default:
                        CommonMethods.RichiestaNonValida();
                        continue;

                }                               

                if (!String.IsNullOrEmpty(idCliente))
                {
                    CommonMethods.DbCustomersUpDater("WHERE [Id] = " + idCliente, c);
                }
                else
                {
                    continue;
                }
                
            }   
            
        }    

        public static void RimuoviCliente()
        {
            // string id, nomecliente;

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





            // int index = -1;

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

    
  

