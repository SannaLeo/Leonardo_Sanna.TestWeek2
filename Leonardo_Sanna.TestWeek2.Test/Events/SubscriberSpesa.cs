using Leonardo_Sanna.TestWeek2.Test.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo_Sanna.TestWeek2.Test.Events
{
    public class SubscriberSpesa
    {
        //Metodi di subscribe/unsubscribe
        public void Subscribe(PublisherSpesa p)
        {
            //registrazione all'evento di notifica
            p.OnPublish += OnNotificationReceived;
        }

        public void UnSubscribe(PublisherSpesa p)
        {
            p.OnPublish -= OnNotificationReceived;
        }

        //Metodo che gestice la ricezione della notifica
        public void OnNotificationReceived(Spesa s)
        {
            //L'evento scatena una stampa su console
            string path = @"D:\Lavoro\lezioni\codice\Leonardo_Sanna.TestWeek2\Leonardo_Sanna.TestWeek2.Test\FilesTXT\spese.txt";
            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine($"{s.Data.ToShortDateString()};{s.Categoria};{s.Descrizione};{s.Importo}");
            }
        }
    }
}
