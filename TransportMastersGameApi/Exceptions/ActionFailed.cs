using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstStepsDotNet.Exceptions
{
    public class ActionFailed : Exception
    {
        public ActionFailed(string message) : base(message)
        {
            
        }
    }
}
