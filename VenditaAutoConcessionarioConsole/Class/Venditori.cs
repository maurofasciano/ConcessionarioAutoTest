using System;
using System.Collections.Generic;
using System.Text;

namespace VenditaAutoConcessionarioConsole.Class
{
    public class Venditori
    {
        // imposto le proprietà delle variabili
        // Il nome delle proprietà va in maiuscolo per convenzione
        public Guid Id { set; get; }
        public string NomeVenditore { get; set; }
        public string CognomeVenditore { get; set; }
        public string TelefonoVenditore { get; set; }
        public string MailVenditore { get; set; }

        public bool VenditoreAttivo { get; set; }
        public string OraInserimento { get; set; }


        // Costruttore dei parametri, potrei anche omettere il this.
        // Passo i parametri dell' oggetto Venditori che di tipo lista, poi li costruisco associandoli alle proprietà
        // Or posso usare i parametri epr ottenere i valori da mettere in lista
        public Venditori(Guid id, string nomevenditore, string telefonovenditore,string mailvenditore, bool venditoreattivo, string orainserimento )
        {
            this.Id = id;
            this.NomeVenditore = nomevenditore;
            this.TelefonoVenditore = telefonovenditore;
            this.MailVenditore = mailvenditore;
            VenditoreAttivo = venditoreattivo;
            OraInserimento = orainserimento;
        }

        // Costruttore default della classe, se non eseguito il compilatore lo genera in automatico
        public Venditori()
        {
        }

        
    }

    
}
