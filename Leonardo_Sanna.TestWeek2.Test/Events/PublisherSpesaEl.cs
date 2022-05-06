using Leonardo_Sanna.TestWeek2.Test.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo_Sanna.TestWeek2.Test.Events
{
    internal class PublisherSpesaEl
    {
        public PublisherSpesaEl()
        {
        }

        //Delegato da utilizzare nell'evento
        public delegate void Save(List<SpesaElaborata> notification);


        //Evento
        public event Save OnPublish;

        //Metodo che effettivamente scatena l'evento
        public void Publish(List<SpesaElaborata> spesaElaborata)
        {
            if (OnPublish != null)
            {
                if(spesaElaborata != null)
                {
                    OnPublish(spesaElaborata);
                }
            }
        }
    }
}
