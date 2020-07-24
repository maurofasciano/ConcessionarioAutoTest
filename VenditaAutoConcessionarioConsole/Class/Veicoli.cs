using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Security;
using System.Text;

namespace VenditaAutoConcessionarioConsole.Class
{
    public class Veicoli
    {
        
        public int Id { get; set; }
        public string MarcaModello { get; set; }
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

        public Veicoli(int id, string tipoveicolo, string marcamodello, DateTime dataimmatricolazione, string targa, string cilindrata, int potenza, int numeroruote, 
            DateTime dataacquisto, DateTime datavendita, bool inmagazzino, bool veicolonuovo)
        {
            this.Id = id;
            this.TipoVeicolo = tipoveicolo;
            MarcaModello = marcamodello;
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



