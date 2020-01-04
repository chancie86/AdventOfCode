using System;
using System.Collections.Generic;
using System.Text;

namespace chancies.adventofcode
{
    public interface ILog
    {
        void TraceMsg(string msg, params object[] args);
        
        void TraceDebug(string msg, params object[] args);

        void TraceError(string msg, params object[] args);
    }
}
