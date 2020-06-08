using System;
using System.Collections.Generic;
using System.Text;
using VenditaAutoConcessionarioConsole.Class;
using VenditaAutoConcessionarioConsole.Class.Base;
using VenditaAutoConcessionarioConsole.Class.Liste;
using VenditaAutoConcessionarioConsole.Models.Interfaces;

namespace VenditaAutoConcessionarioConsole.Methods
{
    public class ProgramMethods
    {
        public static void VendorSelect()
        {
            bool PassCodeBlockToCustomers = true;
            while (PassCodeBlockToCustomers)
            {
                Console.WriteLine();
                Console.WriteLine("------------------------------------");
                Console.WriteLine("- Cosa vuoi fare per i Venditori ? -");
                Console.WriteLine("------------------------------------");
                Console.WriteLine();

                Console.WriteLine("---------------------------------------");
                Console.WriteLine("---  Seleziona il Metodo Deiderato  ---");
                Console.WriteLine("- 1) Aggiungi un Venditore            -"); 
                Console.WriteLine("- 2) Lista tutti i Venditori          -");
                Console.WriteLine("- 3) Ricerca Un Venditore             -");
                Console.WriteLine("- 4) Modifica un Venditore            -");
                Console.WriteLine("- 5) Rimuovi Venditore                -");
                Console.WriteLine("- 6) Torna al MENU Principale         -");
                Console.WriteLine("- 7) Esci dal Programma               -");
                Console.WriteLine("---------------------------------------");



                //Faccio valorizzare la variabile risposta
                string risposta = Console.ReadLine();

                //Imposto altra booleana per il ciclo,  la uso per i seguenti motivi : 
                // "rispostaUtente" la uso per verificare la condizione "Argomento non valido" in caso l' utente 
                // inserisca una lettera al posto di un numero.
                // "Risposta viene convertita in int ed assegnata a per poterla usare nello switch 
                // 
                bool rispostaUtente = int.TryParse(risposta, out int rispostaUtenteInt);
                // Per trasformare la stringa inserita dall' utente da tastiera in intero da utilizzare nello switch
                // eseguo la funzione int. con metodo TryParse. Questo prende il valore string di risposta e la passa
                // a rispostaUtenteInt in valore int.

                // Immetto una condizione del ciclo  per visualizzare un messaggio errore in caso 
                // L' utente inserisca una lettera al posto di un numero.
                if (rispostaUtente == false)

                {
                    Console.Clear();

                    Console.WriteLine("");
                    Console.WriteLine("-----------------------------------------------");
                    Console.WriteLine("- Argomento NON VALIDO ! Accetta SOLO interi! -");
                    Console.WriteLine("-----------------------------------------------");
                    Console.WriteLine("");

                    // Se il valore di rispostaUtente è true, continua con la procedura
                    continue;
                }

                //Implemento lo Switch per la selezione dei case riferiti ai metodi
                switch (rispostaUtenteInt)
                {
                    case 1:
                        VendorsMethods.Registravenditore();
                        break;

                    case 2:
                        VendorsMethods.ElencoVenditori();
                        break;

                    case 3:
                        VendorsMethods.RicercaVenditore();
                        break;

                    case 4:
                        VendorsMethods.ModificaVenditori();
                        break;
                    

                    case 5:
                        VendorsMethods.RimuoviVenditore();
                        break;

                    case 6: //Selezione di skip block code
                        PassCodeBlockToCustomers = false;
                        Console.Clear();
                        break;
                        
                    case 7: // Quitta dal programma
                        Console.WriteLine("");
                        Console.WriteLine("---------------------------------------------------------------");
                        Console.WriteLine("------ Hai selezionato QUIT, premi INVIO per chiudere ! ------ ");
                        Console.WriteLine("---------------------------------------------------------------");
                        Console.WriteLine("");
                        Console.ReadLine();
                        Environment.Exit(0);
                        // Il return ti esegue il termine del proramma
                        return;

                    default: // Questo è il default, cioè  quando la scelta non
                             // corrisponde alle possibilità. Qui abbiamo impostato
                             // un metodo nostro, ma poteva anche essere un Console.Write()

                        CommonMethods.RichiestaNonValida();
                        // Imposto il break, altrimento con un return non potrebbe continuare la lettura del
                        // codice e del programma
                        continue;

                }

            }

        }

        public static void CustomerSelect()

        {
            // Se implemento dei metodi nella classe program e questa è di tipo
            // static, anche i metodi dovranno essere tali
            // Se non ho funcioni, In base alla posizione, i metodi vengono richiamati.
            // Se non avessi la scelta del ciclo wile, ci sarebbe: 
            // Registravenditore(); AggiungiVenditore(); VerificaListaVenditori(); RimuoviVenditore();
            // Ora invece imposto i metodi di scelta case e metodi.

            //Implemento un ciclo while per la selezione utente di Venditori 
            //(che posso far ciclare una volta sola o più volte)
            //Dichiaro una booleana per il ciclo, dove : Quando true continua a ciclare, se diventa false (case 5)
            //esegue break del ciclo e continua con la procedura

            //Implemento un ciclo while per la selezione utente di Venditori
            //(che posso far ciclare una volta sola o più volte)

            bool PassCodeBlockToMenu = true;
            while (PassCodeBlockToMenu)
            {
                Console.WriteLine();
                Console.WriteLine("----------------------------------");
                Console.WriteLine("- Cosa vuoi fare per i Clienti ? -");
                Console.WriteLine("----------------------------------");
                Console.WriteLine();

                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("----  Seleziona il Metodo Deiderato  ----");
                Console.WriteLine("- 1) Aggiungi un Cliente                -");
                Console.WriteLine("- 2) Lista i Clienti ed i loro Id       -"); 
                Console.WriteLine("- 3) Verifica la presenza di un Cliente -");
                Console.WriteLine("- 4) Modifica un Cliente                -");
                Console.WriteLine("- 5) Rimuovi un Cliente                 -");
                Console.WriteLine("- 6) Torna al MENU Principale           -");
                Console.WriteLine("- 7) Esci dal Programma                 -");
                Console.WriteLine("-----------------------------------------");

                string risposta = Console.ReadLine();

                bool rispostaUtente = int.TryParse(risposta, out int rispostaUtenteInt);

                if (rispostaUtente == false)
                {
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("- Argomento NON VALIDO, usa SOLO le selezioni ! -");
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("");

                    continue;
                }

                switch (rispostaUtenteInt)

                {
                    case 1:
                        CustomersMethods.RegistraClienti();
                        break;

                    case 2:
                        CustomersMethods.ElencoClienti();
                        
                        break;

                    case 3:
                        CustomersMethods.VerificaListaClienti();
                        break;

                    case 4:
                        CustomersMethods.ModificaClienti();
                        break;


                    case 5:
                        CustomersMethods.RimuoviCliente();
                        break;

                    case 6:
                        PassCodeBlockToMenu = false;
                        Console.Clear();
                        break;

                    case 7:                        
                        Console.WriteLine("");
                        Console.WriteLine("---------------------------------------------------------------");
                        Console.WriteLine("- Hai selezionato QUIT, premi due volte INVIO per chiudere ! - ");
                        Console.WriteLine("---------------------------------------------------------------");
                        Console.WriteLine("");
                        Console.ReadLine();
                        Environment.Exit(0);
                        break;

                    default:
                        CommonMethods.RichiestaNonValida();
                        continue;

                }

            }

     
        }

        /* public static void AutoSelect()
        {
            string risposta = Console.ReadLine();

            bool rispostaUtente = int.TryParse(risposta, out int rispostaUtenteInt);

            if (rispostaUtente == false)
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("- Argomento NON VALIDO, usa SOLO le selezioni ! -");
                Console.WriteLine("-------------------------------------------------");

            }

            switch (rispostaUtenteInt)

            {
                case 1:
                    VeicoliMethods.Modifica(Liste.Auto.ConvertAll(a => (IVeicolo)a));
                    break;
            }
        } */
    }

}
