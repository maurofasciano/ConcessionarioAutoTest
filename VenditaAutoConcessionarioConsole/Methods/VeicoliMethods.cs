using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VenditaAutoConcessionarioConsole.Class;
using VenditaAutoConcessionarioConsole.Class.Base;

namespace VenditaAutoConcessionarioConsole.Methods
{
    public class VeicoliMethods 
    {
        public static Veicoli InserisciVeicolo()
        {
            Veicoli veicolo = new Veicoli();

            int maxId = 0;
            ConnectionStringSql database = new ConnectionStringSql();
            using (var reader = database.ExecuteQuerys("SELECT ISNULL(max(Id),0) as maxId FROM Veicoli "))
            {
                while (reader.Read())
                {
                    maxId = Int32.Parse(reader[maxId].ToString());
                }
            };

            veicolo.Id = maxId + 1;




            return veicolo;
     
        }
    } 
}
