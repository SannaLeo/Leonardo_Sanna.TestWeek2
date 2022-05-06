using Leonardo_Sanna.TestWeek2.Test.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo_Sanna.TestWeek2.Test.Events
{
    internal class SubscriberSpesaElaborata
    { 
        //Metodi di subscribe/unsubscribe
        public void Subscribe(PublisherSpesaEl p)
        {
            //registrazione all'evento di notifica
            p.OnPublish += OnNotificationReceived;
        }

        public void UnSubscribe(PublisherSpesaEl p)
        {
            p.OnPublish -= OnNotificationReceived;
        }

        //Metodo che gestice la ricezione della notifica
        public void OnNotificationReceived(List<SpesaElaborata> spese)
        {
            //L'evento scatena una scrittura su file della lista
            string path = @"D:\Lavoro\lezioni\codice\Leonardo_Sanna.TestWeek2\Leonardo_Sanna.TestWeek2.Test\FilesTXT\spese_elaborate.txt";
            using (var sw = new StreamWriter(path))
            {
                foreach(SpesaElaborata s in spese)
                {
                    //in base allo stato della spesa salvo diverse cose
                    if (s.Approvazione.Equals("RESPINTA"))
                    {
                        sw.WriteLine($"{s.Data.ToShortDateString()};{s.Categoria};{s.Descrizione};{s.Approvazione};-;");
                    }
                    else
                    {
                        sw.WriteLine($"{s.Data.ToShortDateString()};{s.Categoria};{s.Descrizione};APPROVATA;{s.Approvazione};{s.Importo}");
                    }
                }
                
            }
        } 
    }
}
