using System;
using System.Collections.Generic;
using System.Text;
using VenditaAutoConcessionarioConsole.Models.Interfaces;

namespace VenditaAutoConcessionarioConsole.Class
{
    public class Moto : IVeicolo
    {
        public int Kilometri => throw new NotImplementedException();

        public string TipoVeicolo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Targa => throw new NotImplementedException();

        public string Marca => throw new NotImplementedException();

        public string Modello => throw new NotImplementedException();

        public string NumeroTelaio => throw new NotImplementedException();

        public string ProprietarioPrecedente { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime DataAcquistoConcessionaria { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? AnnoImmatricolazione { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime DataVendita { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Timbrata { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool VeicoloNuovo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Garanzia { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool TagliandoPreVendita { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Competizione { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int OreMotore { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Cilindrata { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
