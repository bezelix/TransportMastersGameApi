using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstStepsDotNet.Exceptions
{
    public class NotFoundException : Exception
    {
        //w klasie ErrorHandlingMiddleware nalerzy dodać wyjątek aby go przechwycić przez midlleware
        public NotFoundException(string message) : base (message)
        {

        }
    }
}
