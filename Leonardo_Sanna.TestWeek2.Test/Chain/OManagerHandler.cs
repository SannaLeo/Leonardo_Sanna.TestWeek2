using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo_Sanna.TestWeek2.Test.Chain
{
    public class OManagerHandler : AbstractHandler
    {
        public override string Handle(double richiesta)
        {
            if (richiesta > 400 && richiesta < 1000)
            {
                return "OPS";
            }
            else
            {
                return base.Handle(richiesta);
            }
        }
    }
}
