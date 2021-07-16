using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportMastersGameApi.Models
{
    public class UserSimpleDataDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public long AccountBalance { get; set; }
        public int Level { get; set; }
        public int PremiumPoints { get; set; }
    }
}
