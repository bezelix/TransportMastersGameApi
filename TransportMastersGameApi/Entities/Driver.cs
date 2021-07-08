using System;

namespace TransportMastersGameApi.Entities
{
    public class Driver
    {
        public int Id { get; set; }
        public int User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Level { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public int VehicleNumber { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public float HoursAtWork { get; set; }
        public float MaxHoursAtWork { get; set; }
        public float Payment { get; set; }
    }
}