using System;
using System.Collections.Generic;
using System.Text;

namespace VenditaAutoConcessionarioConsole.Class
{
    public class Clienti
    {
        // Imposto le proprietà delle variabili
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public string CognomeCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public string MailCliente { get; set; }
        public bool ClienteAttivo { get; set; }
        public string OraInserimento { get; set; }



        //Imposto il costruttore delle variabili
        public Clienti(int Id, string nomecliente, string cognomecliente, string telefonocliente, string mailutente, bool clienteattivo,
            string orainserimento)

        {
            this.Id = Id;
            this.NomeCliente = nomecliente;
            CognomeCliente = cognomecliente;
            TelefonoCliente = telefonocliente;
            MailCliente = mailutente;
            OraInserimento = orainserimento;

        }

        public Clienti()
        {
        }
    }   // Possibilità di inserire ulteriori istanze

}
