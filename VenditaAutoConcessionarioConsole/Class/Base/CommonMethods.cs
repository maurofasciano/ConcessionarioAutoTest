using System;
using System.Collections.Generic;
using System.Text;

namespace VenditaAutoConcessionarioConsole.Class.Base
{
    public static class CommonMethods
    {


        /// <summary>
        /// Medoto comune, chiamato quando l' utente usa numero non valido della select. ./Class/Base/Commonx.cs
        /// </summary>
        public static void RichiestaNonValida()



        {
            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("- Richiesta NON VALIDA ! Accetta SOLO selezioni indicate! -");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("");

        }

    }
}
