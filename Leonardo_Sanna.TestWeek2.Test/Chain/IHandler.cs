using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo_Sanna.TestWeek2.Test.Chain
{
    public interface IHandler
    {
        //Metodo per settare l'anello successivo della catena
        IHandler SetNext(IHandler handler);
        //Metodo per gestire la richiesta
        string Handle(double richiesta);


    }
}
