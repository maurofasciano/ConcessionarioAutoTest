using System;
using System.Collections.Generic;
using System.Text;

namespace VenditaAutoConcessionarioConsole.Models.Interfaces
{
    public interface IVeicolo
    {
        Int32 Kilometri { get; }
        int NumeroRuote { get; }
        string Targa { get; }
        string Marca { get; }
        string Modello { get; }
        string NumeroTelaio { get; }
        string ProprietarioPrecedente { get; set; }
        DateTime DataAcquisto { get; set; }
        DateTime? AnnoImmatricolazione { get; set; }
        DateTime DataVendita { get; set; }
        bool Timbrata { get; set; }
        bool VeicoloNuovo { get; set; }
        bool Garanzia { get; set; }
        bool TagliandoVendita { get; set; }

    }
}
