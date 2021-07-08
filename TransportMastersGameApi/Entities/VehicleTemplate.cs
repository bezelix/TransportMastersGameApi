using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportMastersGameApi.Entities
{
    public class VehicleTemplate
    {
        public int Id { get; set; }
        public string ModelNameNumber { get; set; }
        public int CarManufacturerNumber { get; set; }
        public int VehicleMileage { get; set; }
        public DateTime ManufactureDate { get; set; }
        public float Payload { get; set; }
        public float Speed { get; set; }
        public float StartPrice { get; set; }
        public int CarCondition { get; set; }
        public string LocalizationN { get; set; }
        public string LocalizationE { get; set; }
        public bool OnMarket { get; set; }
    }
}
