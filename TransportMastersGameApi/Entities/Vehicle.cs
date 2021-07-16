using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportMastersGameApi.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int VehicleMileage { get; set; }
        public string ModelNameNumber { get; set; }
        public virtual ModelName ModelName { get; set; }
        public int CarManufacturerNumber { get; set; }
        public virtual CarManufacturer CarManufacturer { get; set; }
        public string ManufactureDate { get; set; }
        public float Payload { get; set; }
        public float Speed { get; set; }
        public float StartPrice { get; set; }
        public int CarCondition { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public int Driver { get; set; }
        public int CargNumber { get; set; }
        public virtual Cargo Cargo { get; set; }
        public bool OnMarket { get; set; }
        public DateTime OfferStartTime { get; set; }
        public DateTime OfferEndTime { get; set; }

    }
}
