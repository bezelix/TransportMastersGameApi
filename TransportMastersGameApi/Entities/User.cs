using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportMastersGameApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Level { get; set; }
        public int PremiumPoints { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string PasswordHash { get; set; }
        public int RoleNumber { get; set; } 
        public virtual Role Role { get; set; }
        public float? AccountBalance { get; set; }
        public virtual List<Driver> Drivers { get; set; }
        public virtual List<Vehicle> Vehicles { get; set; }
        public virtual List<Delivery> Deliveries { get; set; }

    }
}
