using Leonardo_Sanna.TestWeek2.Test.Chain;
using Leonardo_Sanna.TestWeek2.Test.Entities;
using Leonardo_Sanna.TestWeek2.Test.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo_Sanna.TestWeek2.Test.Factory
{
     public static class SpeseElaborateFactory
     {
        public static string pathr = @"D:\Lavoro\lezioni\codice\Leonardo_Sanna.TestWeek2\Leonardo_Sanna.TestWeek2.Test\FilesTXT\spese.txt";
        /// <summary>
        /// Ritorna una lista di spese elaborate prese da un file di spese normali
        /// </summary>
        /// <returns>List<SpeseElaborate> speseElaborate</returns>
        public static List<SpesaElaborata> GetSpeseElaborate()
        {
            IHandler MGR, OPM, CEO;
            MGR = new ManagerHandler();
            OPM = new OManagerHandler();
            CEO = new CEOHandler();
            MGR.SetNext(OPM).SetNext(CEO);
            PublisherSpesaEl publisherSpesaEl = new();
            SubscriberSpesaElaborata subspesael = new();
            subspesael.Subscribe(publisherSpesaEl);
            List<SpesaElaborata> speseElaborate = new();
            
            using (StreamReader sr = new StreamReader(pathr))
            {
                string contenuto;
                contenuto = sr.ReadToEnd();
                if (string.IsNullOrEmpty(contenuto))
                {
                    return speseElaborate;
                }
                var righe = contenuto.Split("\r\n");
                for (int i = 0; i < righe.Length; i++)
                {
                    SpesaElaborata spesaElaborata = new();
                    string categoria, descrizione, livApprovazione;
                    double importoRimborsato = 0, importo;
                    DateTime data;
                    var campi = righe[i].Split(';');
                    if (!DateTime.TryParse(campi[0], out data))
                    {
                        Console.WriteLine("Errore nel caricamento da file ");
                        return speseElaborate;
                    }
                    categoria = campi[1];
                    descrizione = campi[2];
                    if (!double.TryParse(campi[3], out importo))
                    {
                        Console.WriteLine("Errore nel caricamento da file ");
                        return speseElaborate;
                    }
                    livApprovazione = MGR.Handle(importo);
                    //controllo che la chain non mi abbia restituito una spesa respinta
                    if (livApprovazione != "RESPINTA")
                    {
                        //chiamo il metodo Factory
                        spesaElaborata = GetSpesaFromCategoria(categoria, importo);
                    }
                    else
                    {
                        //assegno categoria e importo per le spese respinte
                        spesaElaborata.Categoria = categoria;
                        spesaElaborata.Importo = importo;
                    }
                    //assegno i dati rimanenti
                    spesaElaborata.Approvazione = livApprovazione;
                    spesaElaborata.Descrizione = descrizione;
                    spesaElaborata.Data = data;
                    //stampo e aggiungo alla lista che verrà poi salvata su  file
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine(spesaElaborata);
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    speseElaborate.Add(spesaElaborata);
                }
            }
            //pubblico l'evento per il salvataggio su file
            publisherSpesaEl.Publish(speseElaborate);
            return speseElaborate;
        }
        /// <summary>
        /// restituisce la spesa elaborata con l'importo rimborsato calcolato in base alla categoria
        /// </summary>
        /// <param name="categoria">categoria della spesa</param>
        /// <param name="importo">importo di partenza, ossia della spesa</param>
        /// <returns>SpesaElaborata spesa</returns>
        public static SpesaElaborata GetSpesaFromCategoria(string categoria, double importo)
        {
            double importoRimborsato;
            switch (categoria.ToLower())
            {
                case "viaggio":
                    importoRimborsato = importo + 50.0;
                    break;
                case "alloggio":
                    importoRimborsato = importo;
                    break;
                case "vitto":
                    importoRimborsato = importo * 0.70;
                    break;
                default:
                    importoRimborsato = importo * 0.10;
                    break;
            }
            
            SpesaElaborata spesaElaborata = new SpesaElaborata();
            spesaElaborata.Importo = importoRimborsato;
            spesaElaborata.Categoria = categoria;
            return spesaElaborata;
        }
     }
}