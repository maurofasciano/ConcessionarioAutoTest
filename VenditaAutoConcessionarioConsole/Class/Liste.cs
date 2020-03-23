using System;
using System.Collections.Generic;
using System.Text;
using VenditaAutoConcessionarioConsole.Class;
using VenditaAutoConcessionarioConsole.Models.Interfaces;

namespace VenditaAutoConcessionarioConsole.Class.Liste
{

    /// <summary>
    /// Classe delle liste
    /// </summary>
    public class Liste

        //Imposto una classe contenente le liste, se le liste sono public 
        // lo devono essere anche le classi.
    {   

        public static List<Venditori> Venditori = new List<Venditori>();

        public static List<Clienti> Clienti = new List<Clienti>();

        public static List<Auto> Auto = new List<Auto>();

        public static List<Moto> Moto = new List<Moto>();

    }

    

}

    