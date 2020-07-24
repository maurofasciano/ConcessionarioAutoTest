using System;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.Dynamic;
using System.Security;
>>>>>>> d3207a4cefc9bfed42f207fd8235e5ff87cabce8
using System.Text;

namespace VenditaAutoConcessionarioConsole.Class
{
    public class Veicoli
    {
<<<<<<< HEAD
        public int Id { get; set; }
        public string MarcaModello { get; set; }
        public int Cilindrata { get; set; }
        public string Targa { get; set; }
        public string Telaio { get; set; }
        public int? AnnoImmatricolazione { get; set; }
        public DateTime DataAcquisto { get; set; }
        public DateTime? DataVendita { get; set; }

        public Veicoli(int id, string marcamodello, int cilindrata, string targa, string telaio, int
            annoimmatriolazione, DateTime dataacquisto, DateTime datavendita)
        {
            Id = id;
            MarcaModello = marcamodello;
            Cilindrata = cilindrata;
            Targa = targa;
            Telaio = telaio;
            AnnoImmatricolazione = annoimmatriolazione;
            DataAcquisto = dataacquisto;
            DataVendita = datavendita;
        }

        /* Default "builder" */
        public Veicoli() { }

    }
}
=======
        
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modello { get; set; }
        public string TipoVeicolo { get; set; }
        public DateTime? DataImmatricolazione { get; set; }
        public string Targa { get; set; }
        public string Cilindrata { get; set; }
        public int Potenza { get; set; }
        public int NumeroRuote { get; set; }
        public DateTime DataAcquisto { get; set; }
        public DateTime? DataVendita { get; set; }
        public bool inMagazzino { get; set; }
        public bool VeicoloNuovo { get; set; }

        public Veicoli(int id, string tipoveicolo, DateTime dataimmatricolazione, string targa, string cilindrata, int potenza, int numeroruote, 
            DateTime dataacquisto, DateTime datavendita, bool inmagazzino, bool veicolonuovo)
        {
            this.Id = id;
            this.TipoVeicolo = tipoveicolo;
            DataImmatricolazione = dataimmatricolazione;
            Targa = targa;
            Cilindrata = cilindrata;
            Potenza = potenza;
            NumeroRuote = numeroruote;
            DataAcquisto = dataacquisto;
            DataVendita = datavendita;
            inMagazzino = inmagazzino;
            VeicoloNuovo = veicolonuovo;
        }

        public Veicoli()
        { }


    }

}



>>>>>>> d3207a4cefc9bfed42f207fd8235e5ff87cabce8
