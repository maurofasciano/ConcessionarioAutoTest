using System;
using System.Collections.Generic;
using System.Text;
using VenditaAutoConcessionarioConsole.Models.Interfaces;

namespace VenditaAutoConcessionarioConsole.Class
{
    public class Auto : IVeicolo 
    {
        public Int32 Kilometri { get; }
        public int NumeroRuote { get; }
        public string Targa { get; }
        public string Marca { get; }
        public string Modello { get; }
        public string NumeroTelaio { get; }
        public string ProprietarioPrecedente { get; set; }
        public DateTime DataAcquisto { get; set; }
        public DateTime? AnnoImmatricolazione { get; set; }
        public DateTime DataVendita { get; set; }
        public bool Timbrata { get; set; }
        public bool VeicoloNuovo { get; set; }
        public bool Garanzia { get; set; }
        public bool TagliandoVendita { get; set; }
        public string TipoVeicolo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime DataAcquistoConcessionaria { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool TagliandoPreVendita { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Competizione { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int OreMotore { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Cilindrata { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }


}



