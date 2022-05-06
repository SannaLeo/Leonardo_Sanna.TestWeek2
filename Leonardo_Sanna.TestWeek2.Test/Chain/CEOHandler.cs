using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo_Sanna.TestWeek2.Test.Chain
{
    public class CEOHandler : AbstractHandler
    {
        public override string Handle(double richiesta)
        {
            if (richiesta > 1000 && richiesta < 2500)
            {
                return "CEO";
            }
            else
            {
                return base.Handle(richiesta);
            }
        }
    }
}
