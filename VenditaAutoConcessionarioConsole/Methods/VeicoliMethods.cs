using System;
using System.Collections.Generic;
using System.Text;
using VenditaAutoConcessionarioConsole.Class;
using VenditaAutoConcessionarioConsole.Models.Interfaces;

namespace VenditaAutoConcessionarioConsole.Methods
{
    public class VeicoliMethods 
    {   
        /// <summary>
        /// Metodo per modifica lista Automezzi
        /// </summary>
        /// <param name="veicoli"></param>
        /// 
        
        // Genero il metodo che accetta come parametro di ingresso una lista di Iveicoli
        // veicoli è una il nome della variabile, di tipo ListaIveicolo ed è il paramentro  
        // input della funzione che viene poi usata  per esere valorizzata

        /* public static void Modifica (List<IVeicolo> veicoli)
        {   
            
            // Chiedo e valorizzo la variabile del telaio 
            Console.WriteLine("Inserisci il telaio da ricercare");
            string telaio = Console.ReadLine();

            // Dichiaro una variabile da usare nel condiziona di ricerca in lista, di tipo generico IVeicolo
            IVeicolo veicolo;

            // Lambda xpress : prende la variabile di tipo IVeicolo e cerca 
            // la variabile veicolo nella lista di veicoli passati in input
            // dove veicoli è il paramentro di input, Find è il metodo di ricerca
            // la condizione di ricerca è il numero di telaio dell' elemento che ciclo
            // deve essere uguale al telaio inserito da utente - v. è simile ad index[i]
            // Se il risultato è diverso da null, parte la coindizione
            if ((veicolo = veicoli.Find(v => v.NumeroTelaio == telaio)) != null)
            {
                while (true)
                {
                    Console.WriteLine("Indica cosa vuoi Modificare");
                    Console.WriteLine("");
                    Console.WriteLine("1) Modifica Dettagli Ciclistica");
                    Console.WriteLine("2) Modifica Dettagli Motore");
                    Console.WriteLine("3) Modifica Dettagli Officina");
                    string rispostautente = Console.ReadLine();




                    //switch:

                    //    {
                    //    break;
                    //    }
                    return;

                }
                  
            }
            else
            {
                Console.WriteLine("Veicolo non trovato");
                return;
            }
            
            veicolo = veicoli.Find(v => v.NumeroTelaio == telaio);

            veicolo.AnnoImmatricolazione = DateTime.Parse(Console.ReadLine());
        } */
        
    } 
}
