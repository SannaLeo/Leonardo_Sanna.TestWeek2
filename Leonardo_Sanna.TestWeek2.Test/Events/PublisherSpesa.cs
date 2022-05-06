using Leonardo_Sanna.TestWeek2.Test.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo_Sanna.TestWeek2.Test.Events
{
    public class PublisherSpesa
    {

        public PublisherSpesa()
        {
        }

        //Delegato da utilizzare nell'evento
        public delegate void Save(Spesa notification);


        //Evento
        public event Save OnPublish;

        //Metodo che effettivamente scatena l'evento


        public void PublishSpesa(Spesa spesa)
        {
            if (OnPublish != null)
            {
                Spesa notifica = spesa;
                OnPublish(notifica);
            }
        }
    }
}
