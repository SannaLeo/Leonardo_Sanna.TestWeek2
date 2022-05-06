using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo_Sanna.TestWeek2.Test.Chain
{
    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;
        public virtual string Handle(double richiesta)
        {
            if (_nextHandler != null)
                return _nextHandler.Handle(richiesta);
            else
                return "RESPINTA";
        }

        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }
    }
}
