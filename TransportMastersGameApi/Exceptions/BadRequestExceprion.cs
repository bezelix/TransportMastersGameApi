using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstStepsDotNet.Exceptions
{
    public class BadRequestExceprion : Exception

    {
        //w klasie ErrorHandlingMiddleware nalerzy dodać wyjątek aby go przechwycić przez midlleware
        public BadRequestExceprion(string message) : base(message)
        {

        }

    }
}
