using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportMastersGameApi.Models
{
    public class DriverDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Level { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public float MaxHoursAtWork { get; set; }
        public float Payment { get; set; }
    }
}
