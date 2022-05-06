using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo_Sanna.TestWeek2.Test.Entities
{
    public class SpesaElaborata
    {
        public DateTime Data { get; set; }
        public string Categoria { get; set; }
        public string Descrizione { get; set; }
        public double Importo { get; set; }
        public string Approvazione { get; set; }

        public SpesaElaborata()
        {
        }
        public SpesaElaborata(DateTime data, string categoria, string descrizione, double importo, string approvazione)
        {
            Data = data;
            Categoria = categoria;
            Descrizione = descrizione;
            Importo = importo;
            Approvazione = approvazione;
        }

        public override string ToString()
        {
            return $"data: {Data}\t\tcategoria: {Categoria}\t\tdescrizione: {Descrizione}\t\timporto: {Importo}\t\tapprovazione: {Approvazione}";
        }
    }
}
