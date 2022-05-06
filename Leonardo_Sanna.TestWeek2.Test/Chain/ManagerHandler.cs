using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo_Sanna.TestWeek2.Test.Chain
{
    public class ManagerHandler : AbstractHandler
    {
        public override string Handle(double richiesta)
        {
            if(richiesta > 0 && richiesta <= 400)
            {
                return "MGR";
            }
            else
            {
                return base.Handle(richiesta);
            }
        }
    }
}
