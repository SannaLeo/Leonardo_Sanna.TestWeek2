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
                    if (livApprovazione != "RESPINTA")
                    {
                        spesaElaborata = GetSpesaFromCategoria(categoria, importo);
                    }
                    else
                    {
                        spesaElaborata.Categoria = categoria;
                        spesaElaborata.Importo = importo;
                    }
                    spesaElaborata.Approvazione = livApprovazione;
                    spesaElaborata.Descrizione = descrizione;
                    spesaElaborata.Data = data;
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine(spesaElaborata);
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    speseElaborate.Add(spesaElaborata);
                }
            }
            publisherSpesaEl.Publish(speseElaborate);
            return speseElaborate;
        }
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