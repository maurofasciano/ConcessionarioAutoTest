using System;
using System.Collections.Generic;
using System.Text;

namespace VenditaAutoConcessionarioConsole.Models.Interfaces
{
    public interface IVeicolo
    {
        Int32 Kilometri { get; }
        // string TipoVeicolo { get; set; } // Auto,Moto,Ciclomotore,Furgone,Camper,
        string Targa { get; set; }
        string Marca { get; }
        string Modello { get; }
        string NumeroTelaio { get; }
        string ProprietarioPrecedente { get; set; }
        DateTime DataAcquistoConcessionaria { get; set; }
        DateTime? AnnoImmatricolazione { get; set; }
        DateTime DataVendita { get; set; }
        bool Timbrata { get; set; }
        bool VeicoloNuovo { get; set; }
        bool Garanzia { get; set; }
        bool TagliandoPreVendita { get; set; }
        bool Competizione { get; set; }
        int OreMotore {get; set; }
        int Cilindrata { get; set; } 
    }
}
