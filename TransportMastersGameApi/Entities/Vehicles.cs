using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportMastersGameApi.Entities
{
    public class Vehicles
    {
        public int Id { get; set; }
        public string ModelNameId { get; set; }
        public virtual ModelName ModelName { get; set; }
        public int CarManufacturerId { get; set; }
        public virtual CarManufacturer CarManufacturer { get; set; }
        public DateTime ManufactureDate { get; set; }
        public float Payload { get; set; }
        public float Speed { get; set; }
        public float Price { get; set; }
        public string LocalizationN { get; set; }
        public string LocalizationE { get; set; }
        public int CargoId { get; set; }
        public virtual Cargo Cargo { get; set; }
    }
}
