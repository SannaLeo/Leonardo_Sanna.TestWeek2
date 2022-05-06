using Xunit;
using Leonardo_Sanna.TestWeek2.Test.Entities;
using Leonardo_Sanna.TestWeek2.Test.Events;
using System;
using System.Collections.Generic;
using Leonardo_Sanna.TestWeek2.Test.Factory;
using System.IO;
using Leonardo_Sanna.TestWeek2.Test.Chain;

namespace Week2.Esercitazione.Test
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldBeAprovataAndMGRWithSpese100PerCentoRimborsato()
        {
            //Spese elaborate che dovrebbbero essere approvate con seguenti caratteristiche
            //      cat, importo, stato, livello, importo rimborsato
            //1. Alloggio, 350, approvato,  mgr, 350
            //2. Altro, 50, approvato,  mgr, 5

            IHandler MGR, OPM, CEO;
            MGR = new ManagerHandler();
            OPM = new OManagerHandler();
            CEO = new CEOHandler();
            MGR.SetNext(OPM).SetNext(CEO);
            double importo1 = 350, importo2 = 50;
            string livApprovazione1 = MGR.Handle(importo1);
            string livApprovazione2 = MGR.Handle(importo2);
            
            SpesaElaborata spesaelaborata1 = SpeseElaborateFactory.GetSpesaFromCategoria("Alloggio", importo1);
            spesaelaborata1.Approvazione = livApprovazione1;
            if (livApprovazione1 == "RESPINTA")
                spesaelaborata1.Importo = 0;

            SpesaElaborata spesaelaborata2 = SpeseElaborateFactory.GetSpesaFromCategoria("Altro", importo2);
            spesaelaborata2.Approvazione = livApprovazione2;
            if (livApprovazione2 == "RESPINTA")
                spesaelaborata2.Importo = 0;

            Assert.Equal("MGR", spesaelaborata1.Approvazione);
            Assert.Equal("MGR", spesaelaborata2.Approvazione);
            Assert.Equal(350, spesaelaborata1.Importo);
            Assert.Equal(5, spesaelaborata2.Importo);
        }

        [Fact]
        public void ShouldBeAprrovataAndOPSWithSpese100PerCentoRimborsatoPiu50()
        {
            //Spese elaborate che dovrebbbero essere approvate con seguenti caratteristiche
            //      cat, importo, stato, livello, importo rimborsato
            //1. Viaggio, 500, approvato, ops, 550
            

            IHandler MGR, OPM, CEO;
            MGR = new ManagerHandler();
            OPM = new OManagerHandler();
            CEO = new CEOHandler();
            MGR.SetNext(OPM).SetNext(CEO);
            double importo1 = 500;
            string livApprovazione1 = MGR.Handle(importo1);

            SpesaElaborata spesaelaborata1 = SpeseElaborateFactory.GetSpesaFromCategoria("Viaggio", importo1);
            spesaelaborata1.Approvazione = livApprovazione1;
            if (livApprovazione1 == "RESPINTA")
                spesaelaborata1.Importo = 0;

            Assert.Equal("OPS", spesaelaborata1.Approvazione);
            Assert.Equal(550, spesaelaborata1.Importo);
        }

        [Fact]
        public void ShouldBeAprovataAndCEOWithSpese70PerCentoRimborsato()
        {
            //Spese elaborate che dovrebbbero essere approvate con seguenti caratteristiche
            //      cat, importo, stato, livello, importo rimborsato
            //1. Vitto, 1400 approvato, ceo, 980


            IHandler MGR, OPM, CEO;
            MGR = new ManagerHandler();
            OPM = new OManagerHandler();
            CEO = new CEOHandler();
            MGR.SetNext(OPM).SetNext(CEO);
            double importo1 = 1400;
            string livApprovazione1 = MGR.Handle(importo1);

            SpesaElaborata spesaelaborata1 = SpeseElaborateFactory.GetSpesaFromCategoria("Vitto", importo1);
            if (livApprovazione1 == "RESPINTA")
                spesaelaborata1.Importo = 0;
            spesaelaborata1.Approvazione = livApprovazione1;


            Assert.Equal("CEO", spesaelaborata1.Approvazione);
            Assert.Equal(979.9999999999999, spesaelaborata1.Importo);
        }

        [Fact]
        public void ShouldNotBeAprovata()
        {
            
            //Spese elaborate che non dovrebbero essere approvate

            IHandler MGR, OPM, CEO;
            MGR = new ManagerHandler();
            OPM = new OManagerHandler();
            CEO = new CEOHandler();
            MGR.SetNext(OPM).SetNext(CEO);
            double importo1 = 3100;
            string livApprovazione1 = MGR.Handle(importo1);
            SpesaElaborata spesaelaborata1 = SpeseElaborateFactory.GetSpesaFromCategoria("Viaggio", importo1);
            if (livApprovazione1 == "RESPINTA")
                spesaelaborata1.Importo = 0;
            spesaelaborata1.Approvazione = livApprovazione1;


            Assert.Equal("RESPINTA", spesaelaborata1.Approvazione);
            Assert.Equal(0, spesaelaborata1.Importo);
        }
    }
}