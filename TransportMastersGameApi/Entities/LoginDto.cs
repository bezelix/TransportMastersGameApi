using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstStepsDotNet.Models
{
    public class LoginDto
    {
        //należy dodać walidator 
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
