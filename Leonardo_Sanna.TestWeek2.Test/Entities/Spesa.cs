using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo_Sanna.TestWeek2.Test.Entities
{
    public class Spesa
    {

        public DateTime Data { get; set; }
        public string Categoria { get; set; }
        public string Descrizione { get; set; }
        public double Importo { get; set; }
        public Spesa()
        {

        }
        public Spesa(DateTime data, string categoria, string descrizione, double importo)
        {
            Data = data;
            Categoria = categoria;
            Descrizione = descrizione;
            Importo = importo;
        }
    }
}
