using Leonardo_Sanna.TestWeek2.Test.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo_Sanna.TestWeek2.Test.Factory
{
    internal class SpeseFactory
    {
        /// <summary>
        /// richiesta dall'utente per salvare le spese, deprecato in quanto non era nella consegna
        /// </summary>
        /// <returns>Spesa spesa</returns>
        public static Spesa GetSpese()
        {
            DateTime data;
            string descrizione, categoria;
            double importo;
            Console.WriteLine("Inserire data della spesa ");
            while(!DateTime.TryParse(Console.ReadLine(), out data))
            {
                Console.WriteLine("Inserire una data valida");
            }
            Console.WriteLine("Inserire la categoria della spesa ");
            categoria = Console.ReadLine();
            while (string.IsNullOrEmpty(categoria))
            {
                Console.WriteLine("Inserire una categoria valida");
            }
            Console.WriteLine("Inserire una descrizione della spesa ");
            descrizione = Console.ReadLine();
            while (string.IsNullOrEmpty(descrizione))
            {
                Console.WriteLine("Inserire una descrizone valida");
            }
            Console.WriteLine("Inserire l'importo della spesa ");
            while (!double.TryParse(Console.ReadLine(), out importo))
            {
                Console.WriteLine("Inserire un importo valido");
            }
            Console.Clear();
            return new Spesa(data, categoria, descrizione, importo);
        }
    }
}
