using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportMastersGameApi.Entities;

namespace TransportMastersGameApi.Models
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public int VehicleMileage { get; set; }
        public int ModelNameNumber { get; set; }
        public string ModelName { get; set; }
        public int CarManufacturerNumber { get; set; }
        public string CarManufacturer { get; set; }
        public DateTime ManufactureDate { get; set; }
        public float Payload { get; set; }
        public float Speed { get; set; }
        public float StartPrice { get; set; }
        public int CarCondition { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public int Driver { get; set; }
        public int CargNumber { get; set; }
        public bool OnMarket { get; set; }
        public DateTime OfferStartTime { get; set; }
        public DateTime OfferEndTime { get; set; }
    }
}
